
namespace VisionSystemOperation.Controls
{
    partial class CtrlCameraView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCameraView));
            this.cogDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayToolbarV21 = new Cognex.VisionPro.CogDisplayToolbarV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // cogDisplay
            // 
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay.DoubleTapZoomCycleLength = 2;
            this.cogDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(1164, 762);
            this.cogDisplay.TabIndex = 0;
            // 
            // cogDisplayToolbarV21
            // 
            this.cogDisplayToolbarV21.Location = new System.Drawing.Point(10, 6);
            this.cogDisplayToolbarV21.Margin = new System.Windows.Forms.Padding(2);
            this.cogDisplayToolbarV21.Name = "cogDisplayToolbarV21";
            this.cogDisplayToolbarV21.Size = new System.Drawing.Size(169, 20);
            this.cogDisplayToolbarV21.TabIndex = 1;
            // 
            // CtrlCameraView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cogDisplayToolbarV21);
            this.Controls.Add(this.cogDisplay);
            this.Name = "CtrlCameraView";
            this.Size = new System.Drawing.Size(1164, 762);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Display.CogDisplay cogDisplay;
        private Cognex.VisionPro.CogDisplayToolbarV2 cogDisplayToolbarV21;
    }
}
