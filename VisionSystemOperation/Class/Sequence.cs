using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using OpenCvSharp;

using VisionSystemOperation.Forms;
using VisionSystemOperation.Device;
using VisionSystemOperation.Device.PLC_Library;
using VisionSystemOperation.Inspection.MotorCar;
using VisionSystemOperation.Inspection.MotorCar.Model;
using VisionSystemOperation.Inspection;
using VisionSystemOperation.Controls;

namespace VisionSystemOperation.Class
{
    public class Sequence
    {
        private bool[] _isSeqData = new bool[(int)eVision2PLCSeq.SEQ_COUNT];
        public bool[] IsSeqData { get => _isSeqData; }
        private bool _isStop = false;
        List<Device.Camera.CameraProperty> cameraProp = Machine.config.setup.cameraProp;
        public bool IsStop
        {
            get { return _isStop; }
            set { _isStop = value; }
        }

        public string OnCountChange { get; set; }

        public string CAR_ID { get; set; } = "TestID";

        private Mat[] SubImage;
        private string ImgPath = "";
        private eSeqStep _seqStep = eSeqStep.SEQ_STOP;
        private Thread _seqThread = null;
        string ErrorMessage { get; set; } = "";

        public eSeqStep SeqStep
        {
            get { return _seqStep; }
            set { _seqStep = value; }
        }


        private void InitPLCSeqFlag()
        {
            for (int i = (int)eVision2PLCSeq.BT_MATCH_OK; i < (int)eVision2PLCSeq.MASK_PASS; i++)
            {
                if ((int)eVision2PLCSeq.VISION_PASS == i)
                    continue;

                _isSeqData[i] = false;
            }
        }
        private FormMdi formMdi;
        public Sequence(FormMdi _formMdi)
        {
            formMdi = _formMdi;
            //SaveImage();
        }

        public void StartSequence(eSeqStep step)
        {
            _seqStep = step;
            _isStop = false;

            Thread.Sleep(1000);

            if(_seqThread != null)
            {
                if (_seqThread.IsAlive)
                    _seqThread.Abort();
            }

            _seqThread = new Thread(ThreadFunc);
            _seqThread.Start();
        }
        private void ThreadFunc()
        {
            while (!_isStop)
            {
                if (formMdi.CtrlButton.CurProgramMode == eProgramMode.Inspection || formMdi.CtrlButton.CurProgramMode == eProgramMode.ByPass)
                {
                    try { SeqSteps(); }
                    catch (Exception e)
                    {
                        Machine.logger.WriteException(eLogType.ERROR, e);
                    }
                }
                else
                {
                    _isStop = true;
                }
                Thread.Sleep(50);
            }
            //_subSequence = null;
            formMdi.Log(eLogType.SEQ, "End ThreadFunc.", DateTime.Now, true);
        }

        public void CurrentDeviceStatus(out bool camStatus, out bool plcStatus, out bool lightStatus)
        {
            camStatus = Machine.camManager.IsOpen();
            plcStatus = Machine.plc.IsConnected();
            lightStatus = Machine.lightmodule.isConnected();
        }

        public Car ReadCarTypeFromPLC()
        {
            int modelIdx = 0;
            int engineIdx = 0;
            int[] carOptionPLCArray = null;
            int[] modelIdxs = Machine.carManager.GetCarModelIndexList();
            int[] engineIdxs = Machine.carManager.GetCarOptEngIndexList(Inspection.MotorCar.eCarOptEngType.Engine);
            int[] optionIdxs = Machine.carManager.GetCarOptEngIndexList(Inspection.MotorCar.eCarOptEngType.Option);

            Car currentCar = null;
            int readCount = 3;
            for (int i = 0; i < readCount; i++)
            {
                Machine.plc.ReadCarTypeIdx(ref modelIdxs, ref engineIdxs, ref optionIdxs, out modelIdx, out engineIdx, out carOptionPLCArray);
                //Load Recipe
                Car car = Machine.carManager.GetCarByIdx(modelIdx, engineIdx, carOptionPLCArray);
                if (modelIdx == -1 || engineIdx == -1) // Should not Model idx == -1
                {
                    currentCar = null;
                }
                if (car != null)
                {
                    currentCar = car;
                    break;
                }
                Thread.Sleep(500);
            }

            return currentCar;
        }
        public string ReadVinIDFromPLC()
        {
            string id = "";

            int readCount = 3;
            for (int i = 0; i < readCount; i++)
            {
                id = Machine.plc.ReadWordString(eReadSignalType.CAR_ID);
                if (id != "")
                    break;

                Thread.Sleep(300);
            }

            return id;
        }


        private void SeqSteps()
        {
            try
            {
                switch (_seqStep)
                {
                    case eSeqStep.SEQ_STOP:
                        Machine.plc.SetInit();
                        formMdi.Log(eLogType.SEQ, "Sequence Stop.", DateTime.Now, true);
                        break;
                    case eSeqStep.SEQ_START:

                        _isSeqData[(int)eVision2PLCSeq.READY_ON] = true;
                        _isSeqData[(int)eVision2PLCSeq.AUTO_START] = true;
                        _isSeqData[(int)eVision2PLCSeq.EM_STOP] = true;
                        if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                ErrorMessage = "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG;
                                formMdi.Log(eLogType.SEQ, ErrorMessage, DateTime.Now, true);
                                _seqStep = eSeqStep.SEQ_ERROR;
                            }
                            break;
                        }

                        _seqStep = eSeqStep.SEQ_INIT;
                        formMdi.Log(eLogType.SEQ, "Sequence Start.", DateTime.Now, true);
                        break;
                    case eSeqStep.SEQ_INIT:

                        TowerLampManager.StartLampOn();
                        ////Check PLC AutoStart from PLC 
                        //if (!Machine.plc.CheckedPLC2VisionSeq(ePLC2VisionSeq.AUTO_START))
                        //{
                        //    if (Machine.plc.ERR_MSG != "")
                        //    {
                        //        formMdi.Log(eLogType.SEQ, "Error Read Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);

                        //        ErrorMessage = "Error Read Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString();
                        //    }
                        //    //ErrorMessage = "Check to PLC AUTO START. Now Bit Off   " + ErrorMessage;

                        //    //_seqStep = eSeqStep.SEQ_ERROR;
                        //    //break;
                        //}

                        formMdi.Log(eLogType.SEQ, "Sequence Init.", DateTime.Now, true);

                        //Init Data
                        Machine.plc.InitStatusFlagData();
                        InitPLCSeqFlag();
                        Machine.inspManager.initData(Machine.config.setup.maxCamCount);

                        formMdi.Log(eLogType.SEQ, "Sequence Wait.", DateTime.Now, true);
                        _seqStep = eSeqStep.SEQ_START_WAIT;
                        break;
                    case eSeqStep.SEQ_START_WAIT:
                        //Check Device Connect
                        bool isCamConnect = false, isPLCConnect = false, isLightConnect = false;
                        CurrentDeviceStatus(out isCamConnect, out isPLCConnect, out isLightConnect);
                        if(!isCamConnect || !isPLCConnect || !isLightConnect)
                        {
                            string message = $"[Connect Error] CamConnect = {isCamConnect.ToString()},  PLCConnect = {isPLCConnect.ToString()},  LightConnect = {isLightConnect.ToString()}";
                            formMdi.Log(eLogType.ERROR, "Sequence Init.", DateTime.Now, true);

                            _isSeqData[(int)eVision2PLCSeq.PC_COMM_ERROR] = true;
                            if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                            {
                                if (Machine.plc.ERR_MSG != "")
                                    formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);
                            }

                            if(!isCamConnect) ErrorMessage = $"CamConnect = {isCamConnect.ToString()}";
                            if(!isPLCConnect) ErrorMessage = $"PLCConnect = {isPLCConnect.ToString()}";
                            if(!isLightConnect) ErrorMessage = $"LightConnect = {isLightConnect.ToString()}";

                            _seqStep = eSeqStep.SEQ_ERROR;
                            break;
                        }
                        //

                        ////Check Flag PLC VISION START
                        if (!Machine.plc.CheckedPLC2VisionSeq(ePLC2VisionSeq.VISION_START))
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                formMdi.Log(eLogType.SEQ, "Error Read Vision Sequence from PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);
                                ErrorMessage = "Falied Write to PLC Data 3 times. PLC ERR: " + Machine.plc.ERR_MSG.ToString();
                                _seqStep = eSeqStep.SEQ_ERROR;
                            }
                            break;
                        }
                        ///

                        formMdi.FormMainWindow.InitializeUI();

                        _seqStep = eSeqStep.SEQ_READ_CAR_ID;
                        break;
                    case eSeqStep.SEQ_READ_CAR_ID:
                        formMdi.Log(eLogType.SEQ, "Start Read Car ID.", DateTime.Now, true);

                        ////Check CarID
                        CAR_ID = ReadVinIDFromPLC();
                        if (CAR_ID == "")
                        {
                            DateTime now = DateTime.Now;
                            CAR_ID = "CAR_" + now.ToString("yyyyMMdd_HHmmdd");
                            formMdi.Log(eLogType.SEQ, "Failed Read Car ID. Replace to " + CAR_ID, DateTime.Now, true);

                            //if (PLC.ERR_MSG != "")
                            //{
                            //    _seqStep = eSeqStep.SEQ_ERROR;
                            //}
                        }
                        ////
                        Machine.carManager.VinID = CAR_ID;
                        formMdi.Log(eLogType.SEQ, "Sucess Read Car ID.", DateTime.Now, true);

                        _seqStep = eSeqStep.SEQ_READ_CAR_TYPE;
                        break;
                    case eSeqStep.SEQ_READ_CAR_TYPE:

                        formMdi.Log(eLogType.SEQ, "Start Read Car Type From PLC.", DateTime.Now, true);

                        Machine.carManager.LoadDB();

                        Car car = ReadCarTypeFromPLC();

                        if (car == null) // Should not Model idx == -1
                        {
                            ErrorMessage = "Failed Read Car Type. Not registed car type or Not TurnOn PLC Bit about Car Information.";
                            formMdi.Log(eLogType.SEQ, "Failed Read Car ID. Replace to " + CAR_ID, DateTime.Now, true);
                            formMdi.Log(eLogType.ERROR, "Failed Read Car ID. Replace to " + CAR_ID, DateTime.Now, true);

                            _isSeqData[(int)eVision2PLCSeq.BT_MATCH_OK] = false;
                            _isSeqData[(int)eVision2PLCSeq.BT_UNMATCH] = true;

                            if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                            {
                                if (Machine.plc.ERR_MSG != "")
                                {
                                    formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);
                                }
                            }

                            _seqStep = eSeqStep.SEQ_ERROR;
                            break;
                        }
                        formMdi.Log(eLogType.SEQ, "Sucess Read Car Type From PLC. And Load Recipe : " + car.GetCarFullName(), DateTime.Now, true);

                        // if Success for LoadRecipe

                        _isSeqData[(int)eVision2PLCSeq.BT_MATCH_OK] = true;
                        _isSeqData[(int)eVision2PLCSeq.BT_UNMATCH] = false;
                        if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);
                            }
                            ErrorMessage = "Not Exist Car Body Type.";
                            _seqStep = eSeqStep.SEQ_ERROR;
                            break;
                        }

                        formMdi.CtrlCarTypeVin.CarTypeVinIDDisplay(car.GetCarFullName(), CAR_ID);

                        _seqStep = eSeqStep.SEQ_GRAB;
                        break;
                    case eSeqStep.SEQ_GRAB:
                        _isSeqData[(int)eVision2PLCSeq.VISION_START] = true;
                        if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);
                            }

                            ErrorMessage = "Falied Write to PLC Data 3 times";
                            _seqStep = eSeqStep.SEQ_ERROR;
                            break;
                        }

                        //light on
                        LightOn();
                        formMdi.Log(eLogType.SEQ, "Turnon Light ", DateTime.Now, true);

                        //image grab
                        if (!StartGrab())
                            formMdi.Log(eLogType.SEQ, "Failed Camera Grab ", DateTime.Now, true);

                        _seqStep = eSeqStep.SEQ_START_INSP;
                        break;
                    case eSeqStep.SEQ_START_INSP:

                        if (Machine.camManager.IsGrabbing())
                            break;

                        StopGrab();
                        formMdi.Log(eLogType.SEQ, "Sucess Camera Grab ", DateTime.Now, true);
                        //light off
                        LightOff();
                        formMdi.Log(eLogType.SEQ, "Turnoff Light ", DateTime.Now, true);

                        formMdi.Log(eLogType.SEQ, "Start Inspection.", DateTime.Now, true);
                        Car curCar = Machine.carManager.CurCar;
                        if (!Machine.inspManager.Load(CarManager.PARAM_PATH + $"\\{curCar.GetCarFullName()}\\"))
                        {
                            formMdi.Log(eLogType.SEQ, "Inspection Load Failed : " + curCar.GetCarFullName(), DateTime.Now, true);

                            ErrorMessage = $"Not Exist Inspection parameter about Car Type. {curCar.GetCarFullName()}. Check & Create Inspection Recipe" ;
                            _seqStep = eSeqStep.SEQ_ERROR;

                            break;
                        }

                        //jskim 20250408 check using Camera s
                        List<Device.Camera.CameraProperty> cameraProperties = Machine.config.setup.cameraProp;
                        SubImage = new Mat[Machine.config.setup.maxCamCount];
                        for (int i = 0; i < SubImage.Length; i++)
                        {
                            if (cameraProperties[i].Using == "No") continue;

                            SubImage[i] = Machine.camManager.GetGrabImage(i);
                            if (SubImage[i] != null)
                                Machine.inspManager.RunInspByAsync(ref curCar, new Cognex.VisionPro.CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(SubImage[i])), CAR_ID, i);
                            else
                            {
                                ErrorMessage = $"Image is wrong. Camera:{i}. Check connection Camera No.{i}.  if not operating, change 'Using -> No' in Camera Setting";
                                _seqStep = eSeqStep.SEQ_ERROR;
                                break;
                            }
                            //jskim 20250408 check using Camera e

                            Thread.Sleep(10);
                        }

                        _seqStep = eSeqStep.SEQ_END_INSP;
                        break;
                    case eSeqStep.SEQ_END_INSP:

                        ////Wait Inspection End
                        if(!Machine.inspManager.IsFinished())
                        {
                            break;
                        }
                        ///
                        formMdi.Log(eLogType.SEQ, "End Inspection. Result: " + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        ResultConstants inspResult = Machine.inspManager.Result;
                        if (inspResult == ResultConstants.OK)
                        {
                            _isSeqData[(int)eVision2PLCSeq.LAST_COMPL] = true;
                            _isSeqData[(int)eVision2PLCSeq.VISION_NG] = false;
                            _isSeqData[(int)eVision2PLCSeq.ERROR] = false;
                        }
                        else if (inspResult == ResultConstants.NG)
                        {
                            _isSeqData[(int)eVision2PLCSeq.VISION_NG] = true;
                            _isSeqData[(int)eVision2PLCSeq.LAST_COMPL] = false;
                            _isSeqData[(int)eVision2PLCSeq.ERROR] = false;

                            TowerLampManager.StopLampOn();
                        }
                        else if (inspResult == ResultConstants.ERR)
                        {
                            _isSeqData[(int)eVision2PLCSeq.ERROR] = true;
                            _isSeqData[(int)eVision2PLCSeq.VISION_NG] = false;
                            _isSeqData[(int)eVision2PLCSeq.LAST_COMPL] = false;

                            if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                            {
                                if (Machine.plc.ERR_MSG != "")
                                {
                                    formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);

                                    ErrorMessage = "Falied Write to PLC Data 3 times" + Machine.plc.ERR_MSG.ToString();
                                }

                                ErrorMessage += "\r\n";
                                ErrorMessage += "Check Inspection Pattern Recipe. " + Machine.carManager.CurCar.GetCarFullName();
                            }
                            _seqStep = eSeqStep.SEQ_ERROR;
                            break;
                        }

                        _seqStep = eSeqStep.SEQ_SEND_RESULT;
                        break;
                    case eSeqStep.SEQ_SEND_RESULT:
                        if (!Machine.plc.CheckedPLC2VisionSeq(ePLC2VisionSeq.VISION_OK))
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                formMdi.Log(eLogType.SEQ, "Error Read Vision Sequence from PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);

                                ErrorMessage = "Error Read Vision Sequence from PLC : " + Machine.plc.ERR_MSG.ToString();
                                _seqStep = eSeqStep.SEQ_ERROR;
                            }
                            break;
                        }

                        formMdi.Log(eLogType.SEQ, "Send Result to PLC." + Machine.inspManager.Result.ToString(), DateTime.Now, true);
                        if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);

                                ErrorMessage = "Falied Write to PLC Data 3 times" + Machine.plc.ERR_MSG.ToString();

                                _seqStep = eSeqStep.SEQ_ERROR;
                            }
                            break;
                        }

                        _isSeqData[(int)eVision2PLCSeq.VISION_END] = true;
                        Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16);
                        formMdi.Log(eLogType.SEQ, "Sucess Send Result to PLC." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        formMdi.Log(eLogType.SEQ, "Start Save Result to DB." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        //db result save
                        try { AddDBResultData(Machine.inspManager.InspResults); } catch (Exception ex) { formMdi.Log(eLogType.SEQ, "Failed result save to DB." + Machine.inspManager.Result.ToString(), DateTime.Now, true); }

                        //Copy CogImage to Bitmap

                        //jskim 20250408 check using Camera s
                        List<Device.Camera.CameraProperty> cameraProps = Machine.config.setup.cameraProp;
                        for (int i = 0; i < Machine.config.setup.maxCamCount; i++)
                        {
                            if (cameraProps[i].Using == "No") continue;
                            System.Drawing.Bitmap bitmap = Machine.inspManager.ResultImages[i];
                            //bitmap.Save(@"C:\WorkSpace\Hanmech\Project\대명TS\Program\WorkingSpace\Main Program\VisionSystemOperation\bin\bitmap" + i.ToString() + ".bmp");
                            formMdi.FormMainWindow.UpdateUI(i, bitmap, Machine.inspManager.Result, Machine.inspManager.ResultGraphics[i]);
                        }
                        ///
                        //string count = OnCountChange;
                        string totalCount = formMdi.InspCount();
                        formMdi.Log(eLogType.SEQ, "Inspectino Total Count: ." + totalCount.ToString(), DateTime.Now, true);
                        //jskim 20250408 check using Camera e

                        _seqStep = eSeqStep.SEQ_SAVE_IMAGE;
                        break;
                    case eSeqStep.SEQ_SAVE_IMAGE:
                        formMdi.Log(eLogType.SEQ, "Save Result to Image." + Machine.inspManager.Result.ToString(), DateTime.Now, true);
                        if(!SaveImage())
                            formMdi.Log(eLogType.SEQ, "Failed Save Image." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        _seqStep = eSeqStep.SEQ_DELETE_DATA;
                        break;
                    case eSeqStep.SEQ_DELETE_DATA:
                        formMdi.Log(eLogType.SEQ, "Delete Old Image." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        System.Threading.Thread thread = new System.Threading.Thread(DeleteImageProc);
                        thread.Start();
                        formMdi.Log(eLogType.SEQ, "Delete File start.", DateTime.Now, true);

                        _seqStep = eSeqStep.SEQ_END;
                        break;
                    case eSeqStep.SEQ_END:
                        ////Check End all works PLC 
                        if (!Machine.plc.CheckedPLC2VisionSeq(ePLC2VisionSeq.STN_WORK_COMPL))
                        {
                            if (Machine.plc.ERR_MSG != "")
                            {
                                formMdi.Log(eLogType.SEQ, "Error Read Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);

                                ErrorMessage = "Error Read Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString();
                                _seqStep = eSeqStep.SEQ_ERROR;
                            }
                            break;
                        }
                        TowerLampManager.StartLampOn();

                        formMdi.Log(eLogType.SEQ, "Finished All Sequence." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        _seqStep = eSeqStep.SEQ_INIT;
                        break;
                    case eSeqStep.SEQ_ERROR:
                        _isSeqData[(int)eVision2PLCSeq.ERROR] = true;
                        if (!Machine.plc.WriteVistion2PLCSeq(_isSeqData, 16)) //1Word = 2byte = 16bit
                        {
                            formMdi.Log(eLogType.SEQ, "Error Write Vision Sequence to PLC : " + Machine.plc.ERR_MSG.ToString(), DateTime.Now, true);
                        }

                        formMdi.Log(eLogType.ERROR, "Sequence Error." + ErrorMessage, DateTime.Now, true);
                        Machine.ShowErrorInfoDlg("Error occured. : " + ErrorMessage, true, formMdi);

                        formMdi.Log(eLogType.SEQ, "Save Result to Image." + Machine.inspManager.Result.ToString(), DateTime.Now, true);
                        if (!SaveImage())
                            formMdi.Log(eLogType.SEQ, "Failed Save Image." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                        TowerLampManager.StopLampOn();

                        IsStop = true;

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                formMdi.Log(eLogType.ERROR, "Occured Exception Sequence." + Machine.inspManager.Result.ToString(), DateTime.Now, true);

                Machine.ShowErrorInfoDlg("Occured Exception Sequence. Current Step: " + SeqStep.ToString() + "\r\nCheck Step and Start Initialize.", true, formMdi);
                IsStop = true;
            }
        }

        private void DeleteImageProc()
        {
            try
            {
                string imgPath = Machine.config.setup.ImagePath;
                string usedDiskPercentage = Machine.config.setup.usedDiskPercentage;
                string drive = imgPath.Split('\\')[0];
                FileDeleteManager fileManager = new FileDeleteManager(drive);
                fileManager.DeleteOldImage(imgPath, usedDiskPercentage);

                string logDir = Path.Combine(Directory.GetCurrentDirectory(), "log");
                string logUsedDiskPer = (Int32.Parse(usedDiskPercentage) - 20).ToString();
                fileManager.DeleteOldImage(logDir, logUsedDiskPer);

                formMdi.Log(eLogType.SEQ, "Delete File End.", DateTime.Now, true);
            }
            catch (Exception ex)
            {
                formMdi.Log(eLogType.SEQ, "Delete File Error.", DateTime.Now, true);
                formMdi.Log(eLogType.ERROR, "Delete File Error.", DateTime.Now, true);

                Machine.logger.WriteException(eLogType.SEQ, ex);
                Machine.logger.WriteException(eLogType.ERROR, ex);

                Console.WriteLine("이미지 삭제 에러");
            }
        }

        private void AddDBResultData(List<InspectionResult> results)
        {
            DateTime now = DateTime.Now;
            //jskim 20250408 check using Camera s
            List<Device.Camera.CameraProperty> cameraProperties = Machine.config.setup.cameraProp;
            foreach (InspectionResult result in results)
            {
                InspectionResultDB resultDB = new InspectionResultDB();

                //Inspection Result Example
                int camNo = result.CamNum;
                if (@cameraProperties[camNo].Using == "No") continue;
                //jskim 20250408 check using Camera e
                double avg = result.Average; //    Average = Score each PatternMatching ROI / Total ROI COUNT
                string carName = result.CarName;
                List<ROIResult> roiResults = result.ROIResults;

                resultDB.VinID = CAR_ID;
                resultDB.InspectionResultID = camNo;
                resultDB.CameraNum = camNo;
                resultDB.CarName = carName;
                resultDB.ImgPath = Machine.config.setup.ImagePath + @"\" + result.ImageSavePath;
                resultDB.Average = avg;
                resultDB.TactTime = result.TactTime;

                resultDB.Result = result.Result.ToString();
                resultDB.Shift = ShiftManager.CurrentShift();
                resultDB.CreateDate = DateTime.Now;
                resultDB.LastModifyDate = DateTime.Now;

                List<ROIResultDB> roiResultsDB = new List<ROIResultDB>();
                int idx = 0;
                foreach (ROIResult roiResult in roiResults)
                {
                    ROIResultDB roiResultDB = new ROIResultDB();
                    roiResultDB.ROIResultID = idx;
                    roiResultDB.Result = roiResult.Result.ToString();
                    roiResultDB.RoiName = roiResult.RoiName;
                    roiResultDB.Score = roiResult.Score;

                    if (roiResult.TrainRectangle != null)
                    {
                        roiResultDB.TrainRectangleX = roiResult.TrainRectangle.X;
                        roiResultDB.TrainRectangleY = roiResult.TrainRectangle.Y;
                        roiResultDB.TrainRectangleWidth = roiResult.TrainRectangle.Width;
                        roiResultDB.TrainRectangleHeight = roiResult.TrainRectangle.Height;
                    }
                    else
                    {
                        roiResultDB.TrainRectangleX = 10;
                        roiResultDB.TrainRectangleY = 10;
                        roiResultDB.TrainRectangleWidth = 10;
                        roiResultDB.TrainRectangleHeight = 10;
                    }

                    roiResultsDB.Add(roiResultDB);
                }

                Machine.HanMechDBHelper.InsertInspectionResult(resultDB, roiResultsDB);
            }

        }

        #region Helping Functions
        public string LightOn()
        {
            string command = "*O001$";
            while (Machine.lightmodule.SendDataAsync(command))
            {
                System.Threading.Thread.Sleep(120);
                break;
            }
            string response = Machine.lightmodule.ReceiveData();
            formMdi.Log(eLogType.SEQ, "Light ON Result : " + response, DateTime.Now, true);

            return response;
        }

        public string LightOff()
        {
            string command = "*O000$";
            while (Machine.lightmodule.SendDataAsync(command))
            {
                System.Threading.Thread.Sleep(120);
                break;
            }
            string response = Machine.lightmodule.ReceiveData();
            formMdi.Log(eLogType.SEQ, "Light OFF Result : " + response, DateTime.Now, true);

            return response;
        }

        private bool StartGrab()
        {
            var isGrabed = Machine.camManager.StartGrab();
            //WaitImageGrabing();

            return isGrabed;
        }

        private async void WaitImageGrabing()
        {
            while (Machine.camManager.IsGrabbing() == true)
            {
                await Task.Delay(50);
            }
        }

        private bool StopGrab()
        {
            return Machine.camManager.StopGrab();
        }
        public bool SaveImage()
        {
            try
            {
                string rootPath = Machine.config.setup.ImagePath + @"\";
                string imagePath = rootPath;
                for (int i = 0; i < Machine.camManager.GetConnectedCount(); i++)
                {
                    if(Machine.inspManager.InspResults.Count > i)
                    {
                        imagePath = rootPath + Machine.inspManager.InspResults[i].ImageSavePath;

                        if (!Directory.Exists(imagePath))
                            Directory.CreateDirectory(imagePath);

                        Mat Image = Machine.camManager.GetGrabImage(i);
                        //jskim 20250408 check using Camera s
                        if (Image == null) continue;
                        string fullPath = imagePath + $"OriginImage_{i}" + ".bmp";
                        Cv2.ImWrite(fullPath, Image);

                        Image.Dispose();
                    }
                }
                formMdi.FormMainWindow.SaveDisplayImages(imagePath, "ResultImage");
                //jskim 20250408 check using Camera e
                //formMdi.FormMainWindow.SaveDisplayImages(imagePath, "ResultImage");

                return true;
            }
            catch (Exception e)
            {
                string err = e.ToString();
                Machine.logger.WriteAsync(eLogType.ERROR, err);
                Machine.logger.WriteAsync(eLogType.SEQ, "SaveImage Error");
                return false;
            }
        }

        private void SendDatatoTowerLamp(byte[] data)
        {
            Socket clientSock = null;
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSock.Connect(Machine.config.setup.TowerLampHost, Machine.config.setup.TowerLampPort);

            byte[] recvBuffer = new byte[1400];
            if (clientSock.Connected)
            {
                clientSock.Send(data);

                clientSock.ReceiveTimeout = Machine.config.setup.TowerLampReceiveTimeout;
                int recvSize = clientSock.Receive(recvBuffer);
                string frame = Encoding.Default.GetString((recvBuffer), 0, recvSize);
            }
            clientSock.Close();
        }

        private byte BitData2Byte(bool[] bitData) //1Byte == 8Bit
        {
            byte byteData = 0;

            int typeSize = (sizeof(byte) * 8);
            if (bitData.Length > typeSize) return byteData;

            int bitSize = typeSize;
            // This assumes the array never contains more than 8 elements!
            int index = bitSize - bitData.Length;
            // Loop through the array
            foreach (bool b in bitData)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    byteData |= (byte)(1 << ((bitSize - 1) - index));

                index++;
            }

            return byteData;
        }

        private void TowerLampOn()
        {
            bool[] bRunnigData = { false, false, false, false, false, false, false, true }; // Green Turn on
            bool[] soundOff = { false, false, false, false, false, false, false, false };

            byte[] towerData = new byte[3];
            towerData[0] = 0x57;
            towerData[1] = BitData2Byte(bRunnigData);
            towerData[2] = BitData2Byte(soundOff);

            SendDatatoTowerLamp(towerData);
        }

        private void WarningTowerLampOn()
        {
            bool[] bWarnningData = { false, false, false, false, false, false, true, false }; // Orange Turn on
            bool[] soundOff = { false, false, false, false, false, false, false, false };

            byte[] towerData = new byte[3];
            towerData[0] = 0x57;
            towerData[1] = BitData2Byte(bWarnningData);
            towerData[2] = BitData2Byte(soundOff);

            SendDatatoTowerLamp(towerData);
        }

        private void StopLampOn()
        {
            bool[] bStopData = { false, false, false, false, false, true, false, false }; // Red Turn on
            bool[] soundOn = { false, false, false, false, false, true, false, false };

            byte[] towerData = new byte[3];
            towerData[0] = 0x57;
            towerData[1] = BitData2Byte(bStopData);
            towerData[2] = BitData2Byte(soundOn);

            SendDatatoTowerLamp(towerData);
        }

        private void TowerLampOff()
        {
            bool[] bStopData = { false, false, false, false, false, false, false, false }; // Turn off
            bool[] soundOff = { false, false, false, false, false, false, false, false };

            byte[] towerData = new byte[3];
            towerData[0] = 0x57;
            towerData[1] = BitData2Byte(bStopData);
            towerData[2] = BitData2Byte(soundOff);

            SendDatatoTowerLamp(towerData);
        }

        #endregion
    }
}
