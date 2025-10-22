using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystemOperation.Class
{
	public class InspectionResultDB
	{
		public int InspectionResultID { get; set; }
		public DateTime TactTime { get; set; }
		public int CameraNum { get; set; }
		public string ImgPath { get; set; }
		public double Average { get; set; }
		public string VinID { get; set; }
		public string Shift { get; set; }
        public string CarName { get; set; }
		public string Result { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime LastModifyDate { get; set; }

		public InspectionResultDB() { }
	}

	public class ROIResultDB
	{
		public int ROIResultID { get; set; }
		public int InspectionResultID { get; set; }
		public double Score { get; set; }
		public string RoiName { get; set; }
		public string Result { get; set; }
		public double TrainRectangleX { get; set; }
		public double TrainRectangleY { get; set; }
		public double TrainRectangleHeight { get; set; }
		public double TrainRectangleWidth { get; set; }

		public ROIResultDB() { }
	}

	public class InspectionNGResult
	{
		public int InspectionNGResultID { get; set; }
		public int InspectionResultID { get; set; }
		public int ROIResultID { get; set; }

		public InspectionNGResult() { }
	}
}