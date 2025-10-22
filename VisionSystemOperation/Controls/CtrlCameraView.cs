using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using OpenCvSharp;
using VisionSystemOperation.Device;

namespace VisionSystemOperation.Controls
{
    public partial class CtrlCameraView : UserControl
    {
        private bool _isOK = false;

        private delegate void InitializeUIDele();
        private delegate void UpdateImageDele(Bitmap bmp, double ratio, bool IsOk, CogGraphicInteractiveCollection cogGraphic);      
        private delegate void SaveDisplayImageDele(string path, string fileName);

        private Bitmap bitmap;
        public CtrlCameraView()
        {
            InitializeComponent();

            this.cogDisplayToolbarV21.Display = cogDisplay;
            this.cogDisplay.BackColor = Color.Black;
        }


        public void UpdateDisplay(Bitmap bmp, double ratio, bool IsOk, CogGraphicInteractiveCollection cogGraphic)      // 221019 메인에서 CAM 이미지 크게 보기
        {
            if (this.InvokeRequired)
            {
                UpdateImageDele callBack = UpdateDisplay;
                BeginInvoke(callBack, bmp, ratio, IsOk, cogGraphic);      // 221019 메인에서 CAM 이미지 크게 보기
                return;
            }
            _isOK = IsOk;

            if (bmp != null)
            {
                cogDisplay.InteractiveGraphics.Clear();

                cogDisplay.Image = new CogImage8Grey(bmp);
                cogDisplay.AutoFit = true;
                cogDisplay.InteractiveGraphics.AddList(cogGraphic, "Result", false);

            }
        }

        internal void InitializeUI()
        {
            if (this.InvokeRequired)
            {
                InitializeUIDele callBack = InitializeUI;
                BeginInvoke(callBack);      // 221019 메인에서 CAM 이미지 크게 보기
                return;
            }
            cogDisplay.Image = null;

        }

        internal void SaveDisplayImage(string path, string fileName)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SaveDisplayImageDele callBack = SaveDisplayImage;
                    BeginInvoke(callBack, path, fileName);      // 221019 메인에서 CAM 이미지 크게 보기
                    return;
                }

                //string preName =  Machine.config.setup.ImagePath + "\\images";
                if (Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string resultStr = "OK";
                if (!_isOK)
                    resultStr = "NG";

                string ImgPath = path + fileName + $"_{resultStr}.jpg";
                Bitmap bitmap = (Bitmap)cogDisplay.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image);
                bitmap.Save(ImgPath, ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                //added log
            }
        }

        internal void ShowImgDB(Bitmap bmp)
        {
            cogDisplay.InteractiveGraphics.Clear();

            cogDisplay.Image = new CogImage24PlanarColor(bmp);
            cogDisplay.AutoFit = true;

            bitmap = bmp;
        }

        internal void ShowImg(Bitmap bmp)
        {
            cogDisplay.InteractiveGraphics.Clear();

            cogDisplay.Image = new CogImage8Grey(bmp);
            cogDisplay.AutoFit = true;

            bitmap = bmp;
        }

        internal void SaveImg()
        {
            if (bitmap == null)
            {
                Machine.logger.WriteAsync(eLogType.ERROR, "Error saving image: " + "Try to save before loading an image.");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save Image",
                Filter = "BMP Image|*.bmp",
                DefaultExt = "jpg",
                FileName = "image"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                    bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                catch (Exception ex)
                {
                    Machine.logger.WriteAsync(eLogType.ERROR,"Error saving image: " + ex.Message);
                }
            }
        }
    }
}
