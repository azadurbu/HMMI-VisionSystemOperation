using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PMAlign;

using VisionSystemOperation.Device;
using VisionSystemOperation.MasterImage.UIForm;
using VisionSystemOperation.Inspection;
using VisionSystemOperation.Inspection.MotorCar;
using VisionSystemOperation.Inspection.Model;
using VisionSystemOperation.Inspection.MotorCar.Model;

namespace VisionSystemOperation.Forms
{
    enum eROIDataViewColHeader
    {
        AreaName,
        X,
        Y,
        Width,
        Height,
        Use,
        Count
    }
    public partial class FormInterface : Form
    {
        public delegate void DeleUpdateImage(int nIndex, object ob = null);

        private FormModelSetting formModelSetting = new FormModelSetting();
        private FormPLCInterface formPLCInterface = null;

        //////Change Machine.InspManager
        InspectionManager inspectionManager = new InspectionManager(2);
        CarManager carManager = new CarManager();
        ///

        public FormInterface()
        {
            InitializeComponent();

        }

        private void InitGridView()
        {
            try
            {
                foreach (eROIDataViewColHeader item in Enum.GetValues(typeof(eROIDataViewColHeader)))
                {
                    if (item == eROIDataViewColHeader.Count)
                        continue;
                    if (item == eROIDataViewColHeader.Use)
                        continue;

                    dgvROISetList.Columns.Add(item.ToString(), item.ToString());
                }

                DataGridViewCheckBoxColumn chkUse = new DataGridViewCheckBoxColumn();
                chkUse.HeaderText = eROIDataViewColHeader.Use.ToString();
                chkUse.Name = eROIDataViewColHeader.Use.ToString();
                dgvROISetList.Columns.Add(chkUse); // 6

                dgvROISetList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvROISetList.RowHeadersVisible = false;

                for (int i = 0; i < dgvROISetList.ColumnCount; i++)
                {
                    dgvROISetList.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvROISetList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvROISetList.Columns[i].ReadOnly = true;
                }

                dgvROISetList.Columns[(int)eROIDataViewColHeader.AreaName].Width = 80;
                dgvROISetList.Columns[(int)eROIDataViewColHeader.Use].ReadOnly = false; // Use CheckBox;
            }
            catch (Exception ex)
            {
            }
        }


        private void FormInterface_Load(object sender, EventArgs e)
        {
            //formPLCInterface = new FormPLCInterface();
            //formPLCInterface.TopLevel = false;

            //tbcInterfaceType.TabPages[1].Controls.Add(formPLCInterface);
            //formPLCInterface.WindowState = FormWindowState.Maximized;
            //formPLCInterface.Show();


            InitGridView();
            cogDisplayToolbar.Display = cogDisplay;
            cogDisplayStatusBarV21.Display = cogDisplay;

            /////Camera Count Check
            //int camCount = Machine.camManager.GetConnectedCount();
            int camCount = 2;
            for (int i = 0; i < camCount; i++)
            {
                cbxCamList.Items.Add("CAM" + i.ToString());
            }
            cbxCamList.SelectedIndex = 0;


        }

        private void dgvROISetList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private int GetGridRowsByName(ref DataGridView gridView, string name)
        {
            int idx = -1;

            try
            {
                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    if( gridView[(int)eROIDataViewColHeader.AreaName, i].Value.ToString() == name)
                    {
                        idx = i;
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }

            return idx;
        }

        private void roi_DraggingStopped(object sender, CogDraggingEventArgs e)
        {
            try
            {
                {
                    CogRectangle rect = (CogRectangle)e.DragGraphic;
                    string name = rect.TipText;

                    int iRow = dgvROISetList.SelectedRows[0].Index;
                    if (iRow == -1)
                        return;

                    int camIdx = cbxCamList.SelectedIndex;
                    if (camIdx == -1) return;

                    // 테이블에 데이터가 아직 없을 경우 리턴.
                    if (dgvROISetList.RowCount < 0)
                    {
                        return;
                    }

                    InspParam param = inspectionManager.GetParam(camIdx, name);
                    if(param == null)
                    {
                        MessageBox.Show("Failed Search Param: roi_DraggingStopped");
                        return;
                    }

                    InspParam newParam = param.CopyTo();
                    newParam.ROI = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
                    inspectionManager.ModifyInspParam(camIdx, name, newParam);

                    //{
                    //    Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[iRow].roi.X = (float)rect.X;
                    //    Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[iRow].roi.Y = (float)rect.Y;
                    //    Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[iRow].roi.Width = (float)rect.Width;
                    //    Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[iRow].roi.Height = (float)rect.Height;
                    //}

                    dgvROISetList[(int)eROIDataViewColHeader.X, iRow].Value = rect.X.ToString("F1");
                    dgvROISetList[(int)eROIDataViewColHeader.Y, iRow].Value = rect.Y.ToString("F1");
                    dgvROISetList[(int)eROIDataViewColHeader.Width, iRow].Value = rect.Width.ToString("F1");
                    dgvROISetList[(int)eROIDataViewColHeader.Height, iRow].Value = rect.Height.ToString("F1");

                    dgvROISetList.ClearSelection();

                    int iCurRow = GetGridRowsByName(ref dgvROISetList, name);
                    if (iCurRow == -1) return;

                    dgvROISetList[(int)eROIDataViewColHeader.AreaName, iCurRow].Selected = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AddNewCogRectangle(string name, Rectangle roi)
        {
            CogRectangle rect = new CogRectangle();
            rect.TipText = name;  
            rect.X = roi.X;
            rect.Y = roi.Y;
            rect.Width = roi.Width;
            rect.Height = roi.Height;
            rect.Interactive = true;
            rect.GraphicDOFEnable = CogRectangleDOFConstants.All;
            rect.DraggingStopped += new CogDraggingStoppedEventHandler(roi_DraggingStopped);
            rect.Color = CogColorConstants.Green;
            cogDisplay.InteractiveGraphics.Add(rect, "ROI" + name, false);
        }

        private void AddNewGird(string Type, Rectangle roi, bool use)
        {
            dgvROISetList.Rows.Add(new object[] {
                        Type.ToString(),
                        roi.X.ToString("F1"),
                        roi.Y.ToString("F1"),
                        roi.Width.ToString("F1"),
                        roi.Height.ToString("F1"),
                        use
            });

            dgvROISetList.Rows[dgvROISetList.Rows.Count - 1].Selected = true;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //List<SCREWInsp> list = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList;

            string name = txtName.Text;
            if (name == "") return;

            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;

            InspParam inspParam = new InspParam();
            Rectangle rect = new Rectangle();

            List<InspectionParameter> inspParams = inspectionManager.InspParams;
            List<InspParam> param = inspParams[camIdx].Params;

            rect.X = (int)((param.Count > 0) ? param[param.Count - 1].ROI.X + 50 : 500);
            rect.Y = (int)((param.Count > 0) ? param[param.Count - 1].ROI.Y + 50 : 500);
            rect.Width = (int)((param.Count > 0) ? param[param.Count - 1].ROI.Width : 100);
            rect.Height = (int)((param.Count > 0) ? param[param.Count - 1].ROI.Height : 100);

            inspParam.ROI = rect;
            inspParam.Name = name;
            inspParam.VppPath = "";
            inspParam.Use = true;

            if(inspectionManager.AddInspParam(camIdx, inspParam))
            {
                AddNewCogRectangle(inspParam.Name, rect);
                AddNewGird(name, rect, true);
            }
        }

        public void ResetUI()
        {
            this.Focus();
            Application.DoEvents();
            //m_isJpgImage = false;

            if (this.cogDisplay.InteractiveGraphics.FindItem("Result", CogDisplayZOrderConstants.Front) != -1)
                this.cogDisplay.InteractiveGraphics.Remove("Result");

            dgvROISetList.Rows.Clear();
            cogDisplay.InteractiveGraphics.Clear();
            rtbResultTable.Clear();

        }
        private string GetSelectedGridName(ref DataGridView grid)
        {
            string name = "";
            try
            {
                if (grid.SelectedRows != null && grid.SelectedRows.Count > 0)
                {
                    int iSelectedRow = grid.SelectedRows[0].Index;
                    if (iSelectedRow == -1)
                        return "";


                    name = grid[0, iSelectedRow].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return name;
        }


        private void UpdateGridRoi()
        {
            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;

            if (inspectionManager.InspParams.Count <= camIdx) return;
            List<InspParam> InspParams = inspectionManager.InspParams[camIdx].Params;

            foreach (InspParam item in InspParams)
            {
                AddNewGird(item.Name, item.ROI, item.Use);
                AddNewCogRectangle(item.Name, item.ROI);
            }
        }

        private void btnGridDel_Click(object sender, EventArgs e)
        {
            Application.DoEvents();

            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;

            try
            {
                string name = GetSelectedGridName(ref dgvROISetList);
                if (name == "")
                    return;
                inspectionManager.DelInspParam(camIdx, name);

                ResetUI();

                UpdateGridRoi();

            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            this.Focus();
            Application.DoEvents();

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();


                DialogResult result = dlg.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                    return;

                if (
                    System.IO.Path.GetExtension(dlg.FileName) == ".jpg" ||
                    System.IO.Path.GetExtension(dlg.FileName) == ".png" ||
                    System.IO.Path.GetExtension(dlg.FileName) == ".bmp" ||
                    System.IO.Path.GetExtension(dlg.FileName) == ".jpeg" ||
                    System.IO.Path.GetExtension(dlg.FileName) == ".gif"
                    )
                {
                    // 이미지 적용
                    Image bmpImage = Bitmap.FromFile(dlg.FileName);
                    CogImage8Grey cogImageInput = new CogImage8Grey((Bitmap)bmpImage);
                    cogDisplay.Image = cogImageInput;

                    string filenameWithoutPath = System.IO.Path.GetFileName(dlg.FileName);
                    lbImage.Text = filenameWithoutPath;

                    cogDisplay.Image = cogImageInput;
                }
                else
                {
                    MessageBox.Show("Select Image File.");
                    return;
                }
            }
            catch (Exception)
            {
                // throw;
            }
        }

        private void btnSetRoiSize_Click(object sender, EventArgs e)
        {
            try
            {
                ResetUI();

                double ratio = Convert.ToDouble(txtSetRoiSize.Text) * 0.01;
                Rectangle old = new Rectangle();
                {
                    //for (int i = 0; i < Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList.Count; i++)
                    //{
                    //    SCREWInsp screw = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[i];
                    //    old.X = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[i].roi.X;
                    //    old.Y = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[i].roi.Y;
                    //    old.Width = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[i].roi.Width;
                    //    old.Height = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].SCREWInspList[i].roi.Height;

                    //    screw.roi.Height = Convert.ToSingle(screw.roi.Height * ratio);
                    //    screw.roi.Width = Convert.ToSingle(screw.roi.Width * ratio);
                    //    screw.roi.X -= ((screw.roi.Width - old.Width) / 2);
                    //    screw.roi.Y -= ((screw.roi.Height - old.Height) / 2);
                    //}
                }

                UpdateGridRoi();
            }
            catch (Exception)
            {
            }
        }

        private void cbxCamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;

            //Bitmap bitmap = new Bitmap(1,1);
            //cogDisplay.Image = new CogImage8Grey(bitmap);

            ResetUI();
            ///Camera
            OpenCvSharp.Mat image = Machine.camManager.GetGrabImage(camIdx);
            if (image != null)
                cogDisplay.Image = new CogImage8Grey(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image));
            ///
            UpdateGridRoi();

        }

        private void ModelSettingClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //CarManager Update
                if (formModelSetting.SelectedModel != null)
                {
                    lblSelectedRcp.Text = formModelSetting.SelectedModel.GetCarFullName();

                    formModelSetting.FormClosing -= new FormClosingEventHandler(ModelSettingClosing);

                    //Machine.CarManager
                    carManager.LoadDB();
                    carManager.CurCar = formModelSetting.SelectedModel.CopyTo();


                    if (!inspectionManager.Load(CarManager.PARAM_PATH + $"\\{lblSelectedRcp.Text}\\"))
                    {
                        MessageBox.Show("Inspection Load Failed");
                    }
                    //

                    ResetUI();
                    UpdateGridRoi();
                }
                else
                {
                    MessageBox.Show("Check Car Type Recipe");
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void btnLoadRcp_Click(object sender, EventArgs e)
        {
            formModelSetting = new FormModelSetting();

            formModelSetting.FormClosing += new FormClosingEventHandler(ModelSettingClosing);
            formModelSetting.Show();
        }

        private void btnRecipeSave_Click(object sender, EventArgs e)
        {

        }

        private void btnRecipeSaveAs_Click(object sender, EventArgs e)
        {

        }

        public void UpdateResultGraphic(int nIndex, object ob = null)
        {
            //try
            //{
            if (InvokeRequired)
            {
                DeleUpdateImage d = new DeleUpdateImage(UpdateResultGraphic);
                Invoke(d, new object[] { nIndex, ob });
                return;
            }

            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;

            if (nIndex == -1)
            {
                if (this.cogDisplay.InteractiveGraphics.FindItem("Result", CogDisplayZOrderConstants.Front) == -1)
                    return;

                this.rtbResultTable.Clear();
                this.cogDisplay.InteractiveGraphics.Remove("Result");
                return;
            }
            if (inspectionManager.ResultGraphics.Count != 0)
                cogDisplay.InteractiveGraphics.AddList(inspectionManager.ResultGraphics[camIdx], "Result", false);

            //InspResult insp = (InspResult)ob;
            //if (insp.m_RoiImage != null)
            //{
            //    this.ui_cogDisplay.Image = insp.m_RoiImage;
            //    this.ui_cogDisplay.AutoFit = true;
            //}

            //    CogGraphicInteractiveCollection graphics = new CogGraphicInteractiveCollection();

            //    for (int i = 0; i < insp.mOcrResultList.Count(); i++)
            //    {
            //        ResultInRoi_Ocr result = insp.mOcrResultList[i];
            //        if (insp.mOcrResultList[i].PatternResult != null)
            //        {
            //            if (insp.mOcrResultList[i].RecipeParam.ocrPatternParam.UsePattern)
            //            {
            //                CogCompositeShape pattern = insp.mOcrResultList[i].PatternResult.CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchFeatures);
            //                graphics.Add(pattern);
            //            }
            //        }

            //        CogGraphicLabel label = new CogGraphicLabel();
            //        label.X = result.RecipeParam.roi.X + 5;
            //        label.Y = result.RecipeParam.roi.Y + 5;

            //        label.Text = result.RecipeParam.Name + " " + result.OCRResultType + " ";

            //        if (result.OCRResultType == ResultOCRType.PATTERN)
            //        {
            //            label.Text += (result.PatternResult.Score * 100).ToString("F1");
            //        }
            //        else if (result.OCRResultType == ResultOCRType.OCR)
            //        {
            //            label.Text += "[" + result.LineResult + "] " + result.ScoreAvg.ToString("F1");
            //        }

            //        label.Font = mFont;

            //        label.Color = (result.Result == ResultConstants.OK) ? CogColorConstants.Green : CogColorConstants.Red;
            //        graphics.Add(label);
            //    }

            //    for (int i = 0; i < insp.mScrewResultList.Count(); i++)
            //    {
            //        if (insp.mScrewResultList[i].AddBlobInspResults != null)
            //        {
            //            if (insp.mScrewResultList[i].RecipeParam.AddBlobInsp)
            //            {
            //                for (int iBlackhole = 0; iBlackhole < insp.mScrewResultList[i].AddBlobInspResults.GetBlobs().Count; iBlackhole++)
            //                {
            //                    CogPolygon aff = insp.mScrewResultList[i].AddBlobInspResults.GetBlobs()[iBlackhole].GetBoundary();
            //                    aff.Color = CogColorConstants.Orange;
            //                    aff.LineWidthInScreenPixels += 3;
            //                    graphics.Add(aff);
            //                }
            //            }
            //        }

            //        foreach (CogBlobResult blob in insp.mScrewResultList[i].BlobResults.GetBlobs())
            //        {
            //            CogPolygon aff = blob.GetBoundary();
            //            graphics.Add(aff);
            //        }

            //        ResultInRoi_Screw result = insp.mScrewResultList[i];
            //        result.RecipeParam.Name = result.RecipeParam.Name.ToString();

            //        CogGraphicLabel label = new CogGraphicLabel();
            //        label.X = result.RecipeParam.roi.X + result.RecipeParam.roi.Width + 5;
            //        label.Y = result.RecipeParam.roi.Y + 5;

            //        if (result.blackHoleVal == "")
            //        {
            //            label.Text = result.RecipeParam.Name + " / "
            //                + result.ScrewResultType + " Area[" + result.BlobArea.ToString("F1") + "]"
            //                + " Count[" + result.BlobCount.ToString() + "] " + result.Result.ToString();
            //        }
            //        else
            //        {
            //            label.Text = result.RecipeParam.Name + " / "
            //                + result.ScrewResultType + " Area[" + result.BlobArea.ToString("F1") + "]"
            //                + " Count[" + result.BlobCount.ToString() + "] " + " BlackHole[" + result.blackHoleVal + "]" + result.Result.ToString();
            //        }

            //        label.Font = mFont;
            //        label.Color = (result.Result == ResultConstants.OK) ? CogColorConstants.Green : CogColorConstants.Red;
            //        label.SelectedSpaceName = ".";
            //        graphics.Add(label);
            //    }

            //    this.ui_cogDisplay.InteractiveGraphics.AddList(graphics, "Result", false);
            //}
            //catch
            //{
            //    Machine.mLogger.log("frmRecipe: 결과 그래픽 업데이트 실패", LogType.ERROR, false);
            //}
        }
        public void UpdateResult()
        {
            rtbResultTable.Text = "";
            string s = "";
            //for (int i = 0; i < m_inspection.m_InspResult.mScrewResultList.Count; i++)
            //{
            //    ResultInRoi_Screw screw = m_inspection.m_InspResult.mScrewResultList[i];
            //    s += screw.RecipeParam.Name + " / "
            //        + screw.ScrewResultType + " / "
            //        + "Count: " + screw.BlobCount + " / "
            //        + "Area: " + screw.BlobArea.ToString("F0") + " / "
            //        + screw.Result.ToString()
            //        + "\r\n";
            //}
            rtbResultTable.Text = s;
        }


        private void btnInspect_Click(object sender, EventArgs e)
        {
            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;

            UpdateResultGraphic(-1);

            Car curCar = carManager.CurCar;
            inspectionManager.initData(Machine.config.setup.maxCamCount);
            inspectionManager.RunInsp(ref curCar, (CogImage8Grey)cogDisplay.Image, camIdx);

            UpdateResultGraphic(0, inspectionManager.InspResults);

            rtbResultTable.Clear();
            rtbResultTable.Text = inspectionManager.GetResultString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            carManager.SaveDB();
            if (!inspectionManager.Save(CarManager.PARAM_PATH + $"\\{lblSelectedRcp.Text}\\"))
            {
                MessageBox.Show("Inspection Save Failed");
            }
        }

        private void btnGridModify_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            int camIdx = cbxCamList.SelectedIndex;
            if (camIdx == -1) return;
            try
            {
                string oldName = GetSelectedGridName(ref dgvROISetList);
                if (oldName == "")
                    return;
                string newName = txtName.Text;
                if (newName == "")
                    return;

                ResetUI();

                inspectionManager.ModifyInspParam(camIdx, oldName, newName);
                UpdateGridRoi();

            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                //throw;
            }
        }

        private void dgvROISetList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string name = GetSelectedGridName(ref dgvROISetList);
                if (name == "") return;

                int camIdx = cbxCamList.SelectedIndex;
                if (camIdx == -1) return;

                InspParam curInspParam = inspectionManager.GetParam(camIdx, name);
                if (curInspParam == null) return;

                //string path = Recipe.Modifying.GetPath(Recipe.enPath.Align);
                //string filename = Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].PMAlignToolPath;
                string path = CarManager.PARAM_PATH + $"{carManager.CurCar.GetCarFullName()}\\";
                string filename = $"PM_Parameter_{curInspParam.Name}_{camIdx}.vpp";

                string fullpath = path + filename;

                FormToolPMMultiAlign form = new FormToolPMMultiAlign();

                // 지정한 이미지 vpp 파일명이 없거나 실제 파일이 존재하지 않을 경우.
                if (filename == "" || File.Exists(fullpath) == false)
                {
                    // 신규 오픈
                    form.cogPMAlignEdit.Subject = new CogPMAlignMultiTool();
                    form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.ApproximateNumberToFind = 1;

                    // 코그넥스 맥스 라이센스.
                    form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.BestTrained;
                }
                else
                {
                    form.cogPMAlignEdit.Subject = (CogPMAlignMultiTool)CogSerializer.LoadObjectFromFile(fullpath);
                    if ((form.cogPMAlignEdit.Subject is CogPMAlignMultiTool) == false)
                    {
                        MessageBox.Show("PM vpp 파일 로딩 실패");
                        form.Dispose();
                        return;
                    }
                }

                form.cogPMAlignEdit.Subject.InputImage = cogDisplay.Image;

                CogRectangle cogRectangle = new CogRectangle();
                cogRectangle.X = curInspParam.ROI.X;
                cogRectangle.Y = curInspParam.ROI.Y;
                cogRectangle.Width = curInspParam.ROI.Width;
                cogRectangle.Height = curInspParam.ROI.Height;

                form.cogPMAlignEdit.Subject.SearchRegion = cogRectangle;

                form.ui_lb_vppFilename.Text = fullpath;
                form.WindowState = FormWindowState.Maximized;

                if (form.ShowDialog(this) == DialogResult.OK)
                {

                    //// BGRYU 20200916
                    //double neworigin_X = form.cogPMAlignEditV21.Subject.Pattern.Origin.TranslationX;
                    //double neworigin_Y = form.cogPMAlignEditV21.Subject.Pattern.Origin.TranslationY;
                    //Relocation_roi(origin_X, origin_Y, neworigin_X, neworigin_Y);

                    form.cogPMAlignEdit.Subject.InputImage = null;

                    form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                    form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.ZoneAngle.Low = (Math.PI/ 180) * -45;
                    form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.ZoneAngle.High = (Math.PI / 180) * 45;
                    form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.ZoneAngle.Overlap = (Math.PI / 180) * 360;
                    form.cogPMAlignEdit.Subject.RunParams.StopSequentialThreshold = form.cogPMAlignEdit.Subject.RunParams.PMAlignRunParams.AcceptThreshold;

                    CogPMAlignMulti cogPMAlignsMulti = form.cogPMAlignEdit.Subject.Operator;
                    for (int i = 0; i < cogPMAlignsMulti.Count; i++)
                    {
                        double trainRegionCX = cogPMAlignsMulti[i].Pattern.TrainRegion.EnclosingRectangle(CogCopyShapeConstants.All).CenterX;
                        double trainRegionCY = cogPMAlignsMulti[i].Pattern.TrainRegion.EnclosingRectangle(CogCopyShapeConstants.All).CenterY;
                        cogPMAlignsMulti[i].Pattern.Origin.TranslationX = trainRegionCX;
                        cogPMAlignsMulti[i].Pattern.Origin.TranslationY = trainRegionCY;
                    }

                    CogSerializer.SaveObjectToFile(form.cogPMAlignEdit.Subject, fullpath);
                    curInspParam.VppPath = fullpath;
                    //Recipe.Modifying.StepList[mSelStep].CamInspList[mSelUIPos].PMAlignToolPath = filename;
                    //Machine.mLogger.loguser(Recipe.Modifying.Info.ToString() + " 이미지 등록됨 : " + Utility.StepCam(mSelStep, mSelCamPos));
                }

                form.Dispose();

                //ResetUI();
                //UpdateUI(true);
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                //Machine.mLogger.log("frmRecipe: PMAlignTool 로드 실패", LogType.ERROR, false);
            }
        }

        private void dgvROISetList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = GetSelectedGridName(ref dgvROISetList);
            if (name == "")
                return;
            try
            {
                txtName.Text = name;

                int iRect = cogDisplay.InteractiveGraphics.FindItem("ROI" + name, CogDisplayZOrderConstants.Front);
                if (iRect != -1)
                {
                    cogDisplay.InteractiveGraphics[iRect].Selected = true;
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }
        }

        private void dgvROISetList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int camIdx = cbxCamList.SelectedIndex;
                if (camIdx == -1) return;

                // 체크박스 처리 필요.
                if (e.ColumnIndex == dgvROISetList.ColumnCount - 1 && e.RowIndex != -1 && e.RowIndex < dgvROISetList.Rows.Count)
                {
                    DataGridViewCheckBoxCell checkbox = dgvROISetList.Rows[dgvROISetList.CurrentRow.Index].Cells[dgvROISetList.ColumnCount - 1] as DataGridViewCheckBoxCell;

                    // 마우스 클릭 시, 그리드에 값을 직접 바꿔줘야함
                    // ( gridList 를 통으로 ReadOnly로 설정하고, 특정 컬럼만 ReadOnly를 풀 때만 이럼... 닷넷 문제? )
                    bool bValue = Convert.ToBoolean(checkbox.Value);
                    bool bNewValue = !bValue;
                    checkbox.Value = bNewValue;

                    inspectionManager.InspParams[camIdx].Params[e.RowIndex].Use = bNewValue;
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
            }
        }
        private void UpdateAlignStatus(double dScore)
        {
            //if (dScore > Inspection.PMAlignDefaultSocre)
            //{
            //    lbAlignStaus.BackColor = System.Drawing.Color.LightGreen;
            //    lbAlignStaus.Text = (dScore * 100).ToString("F1");
            //}
            //else
            //{
            //    lbAlignStaus.BackColor = System.Drawing.Color.Tomato;
            //    lbAlignStaus.Text = (dScore * 100).ToString("F1");
            //}
        }

        private void ApplyAlignment(CogImage8Grey cogImageInput)
        {
            //UpdateAlignStatus(0);
            //m_inspection.m_inputImage = cogImageInput;
            //m_inspection.Insp_Align(mSelStep, mSelCamPos, Recipe.Modifying);
            //if (m_inspection.m_InspResult.m_AlignResult == ResultAlign.Accepted)
            //{
            //    ui_cogDisplay.Image = m_inspection.m_InspResult.m_RoiImage;
            //}
            //else
            //{
            //    ui_cogDisplay.Image = m_inspection.m_inputImage;
            //}
            //UpdateAlignStatus(m_inspection.m_InspResult.m_AlignScore);
        }

        private void btnLoadPMAlignTool_Click(object sender, EventArgs e)
        {

        }

        private void lbAlignStaus_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tbcInterfaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcInterfaceType.SelectedTab == inpection)
            {

            } else if (tbcInterfaceType.SelectedTab == plc)
            {
                if (formPLCInterface == null)
                    formPLCInterface = new FormPLCInterface();
                formPLCInterface.TopLevel = false;
                tbcInterfaceType.TabPages[1].Controls.Add(formPLCInterface);
                formPLCInterface.WindowState = FormWindowState.Maximized;
                formPLCInterface.Show();
            }
        }
    }
}
