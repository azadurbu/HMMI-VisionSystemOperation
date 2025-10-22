using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VisionSystemOperation.Inspection.Model
{
    //public class sRectangle
    //{
    //    public string Name = "";
    //    public double X = 0;
    //    public double Y = 0;
    //    public double Width = 50;
    //    public double Height = 50;

    //    public sRectangle CopyTo()
    //    {
    //        sRectangle newObj = new sRectangle();

    //        newObj.Name = this.Name;

    //        newObj.X = this.X;
    //        newObj.Y = this.Y;
    //        newObj.Width = this.Width;
    //        newObj.Height = this.Height;

    //        return newObj;
    //    }
    //}

    public class InspParam
    {
        public bool Use { get; set; } = true;
        public int No { get; set; } = 0;
        public string Name { get; set; } = "";
        public string VppPath { get; set; } = "";
        public Rectangle ROI { get; set; } = new Rectangle();
        public InspParam CopyTo()
        {
            InspParam newObj = new InspParam();

            newObj.No = this.No;
            newObj.Use = this.Use;

            newObj.Name = this.Name;
            newObj.VppPath= this.VppPath;

            newObj.ROI = new Rectangle(this.ROI.X, this.ROI.Y, this.ROI.Width, this.ROI.Height);
            //foreach (sRectangle item in this.ROIList)
            //{
            //    newObj.ROIList.Add(item.CopyTo());
            //}

            return newObj;
        }

    }
}
