using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace Inspection.Utility
{
    public class ImgCaliBlobParam
    {
        private double _xResolution = 1;
        public double XResolution { get {return _xResolution; } set{_xResolution = value; }}

        private double _yResolution = 1;
        public double YResolution { get {return _yResolution; } set{_yResolution = value; }}

        //Auto ROI Param
        private int _caliThreshold = 0;
        public int CaliThreshold { get {return _caliThreshold; } set{_caliThreshold = value;} }

        private int _binThreshold = 0;
        public int BinThreshold { get {return _binThreshold; } set{_binThreshold = value; }}

        private int _roiMinWidth = 0;
        public int RoiMinWidth { get {return _roiMinWidth; } set{_roiMinWidth = value; }}

        private int _roiMinHeight = 0;
        public int RoiMinHeight { get {return _roiMinHeight; } set{_roiMinHeight = value;} }

        private int _roiMaxWidth = 999999;
        public int RoiMaxWidth { get {return _roiMaxWidth; } set{_roiMaxWidth = value; }}

        private int _roiMaxHeight = 999999;
        public int RoiMaxHeight { get {return _roiMaxHeight; } set{_roiMaxHeight = value;} }

        //left X -> +, rightX -> -
        private int _ignoreX = 0;
        public int IgnoreX { get {return _ignoreX; } set{_ignoreX = value; }}

        //Top Y -> +, Bottom Y -> -
        private int _ignoreY = 0;
        public int IgnoreY { get { return _ignoreY; } set { _ignoreY = value; } }

        public ImgCaliBlobParam Copy()
        {
            ImgCaliBlobParam param = new ImgCaliBlobParam();

            param._xResolution = this._xResolution;
            param._yResolution = this._yResolution;

            param._caliThreshold = this._caliThreshold;
            param._binThreshold = this._binThreshold;
            param._roiMinWidth = this._roiMinWidth;
            param._roiMinHeight = this._roiMinHeight;
            param._roiMaxWidth = this._roiMaxWidth;
            param._roiMaxHeight = this._roiMaxHeight;

            param._ignoreX = this._ignoreX;
            param._ignoreY = this._ignoreY;

            return param;
        }
    }


    public static class HanMechImageHelper
    {
        public static Bitmap ConvertTo8BitGrayBitmap(Bitmap src, int width, int height)
        {
            Bitmap result = new Bitmap(src.Width, src.Height, PixelFormat.Format8bppIndexed);

            ColorPalette resultPalette = result.Palette;

            for (int i = 0; i < 256; i++)
            {
                resultPalette.Entries[i] = Color.FromArgb(255, i, i, i);
            }

            result.Palette = resultPalette;

            BitmapData data = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            // Copy the bytes from the image into a byte array
            byte[] bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    var c = src.GetPixel(x, y);
                    var rgb = (byte)((c.R + c.G + c.B) / 3);

                    bytes[y * data.Stride + x] = rgb;
                }
            }

            // Copy the bytes from the byte array into the image
            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);

            result.UnlockBits(data);

            return result;
            //Color p;
            //Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

            ////grayscale
            //for (int y = 0; y < height; y++)
            //{
            //    for (int x = 0; x < width; x++)
            //    {
            //        //get pixel value
            //        p = src.GetPixel(x, y);

            //        //extract pixel component ARGB
            //        int a = p.A;
            //        int r = p.R;
            //        int g = p.G;
            //        int b = p.B;

            //        //find average
            //        int avg = (r + g + b) / 3;

            //        //set new pixel value
            //        bmp.SetPixel(x, y, Color.From(avg, avg, avg));
            //    }
            //}


            //Bitmap bmp = new Bitmap(width, hegiht, PixelFormat.Format8bppIndexed);
            //ColorPalette paletee = bmp.Palette;

            //Color[] _entries = paletee.Entries;
            //for (int i = 0; i < 256; i++)
            //{
            //    Color b = new Color();
            //    b = Color.FromArgb((byte)i, (byte)i, (byte)i);
            //    _entries[i] = b;
            //}
            //bmp.Palette = paletee;

            //BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            //Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            //bmp.UnlockBits(bmpData);

            //return bmp;
        }

        public static Bitmap Create8BitGreyBitmap(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette paletee = bmp.Palette;
            Color[] _entries = paletee.Entries;
            for (int i = 0; i < 256; i++)
            {
                Color b = new Color();
                b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                _entries[i] = b;
            }
            bmp.Palette = paletee;

            return bmp;
        }

        public static Mat ImgPreProcByBlur(ref Mat src, int blurCount)
        {
            Mat result = src.Clone();

            for (int i = 0; i < blurCount; i++)
            {
                if(i == 0)
                    Cv2.GaussianBlur(src, result, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Reflect101);
                else 
                    Cv2.GaussianBlur(result, result, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Reflect101);
            }

            return result;
        }

        public static Mat ImgPreProcBySharpening(ref Mat src, int sharpeningCount, int blurCount)
        {
            Mat result = src.Clone();
            Mat blur = result.Clone();

            for (int i = 0; i < sharpeningCount; i++)
            {
                Cv2.GaussianBlur(blur, blur, new OpenCvSharp.Size(0, 0), 7);
                Cv2.AddWeighted(result, 1.5, blur, -0.5, 0, result);
            }

            for (int i = 0; i < blurCount; i++)
            {
                Cv2.GaussianBlur(result, result, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Reflect101);
            }

            blur.Dispose();

            return result;
        }

        public static void DrawPointList(ref Bitmap bmp, List<System.Drawing.Point> pointList, int value)
        {
            unsafe
            {
                BitmapData newBmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = newBmpData.Scan0;
                int stride = newBmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                foreach (System.Drawing.Point point in pointList)
                {
                    int index = point.Y * stride + point.X;
                    data[index] = Convert.ToByte(value);
                }
                bmp.UnlockBits(newBmpData);
            }
        }

        public static float[] GetAvgArray(float[] array, int avergeCount)
        {
            try
            {
                float[] avgArray = null;
                // 일단 avergeCount 가 4의 배수라고 생각
                if (array.Count() % avergeCount != 0)
                {
                    int orgCount = array.Count();
                    for (int i = array.Count(); i >= 0; i--)
                    {
                        if(orgCount % avergeCount != 0)
                        {
                            orgCount--;
                        }
                        else
                        {
                            break;
                        }
                    }
                    avgArray = new float[(int)(orgCount / avergeCount)];
                }
                else
                {
                    avgArray = new float[(int)(array.Count() / avergeCount)];

                }
                int index = 0;
                for (int i = 0; i < array.Count(); i += avergeCount)
                {
                    if (avgArray.Count() <= index)
                    {
                        return avgArray;
                    }

                    float avgSum = 0;
                        
                    for (int j = 0; j < avergeCount; j++)
                    {
                        int valueIndex = (i + j);
                        avgSum += array[i + j];
                    }
                    
                    avgArray[index] = avgSum / avergeCount;
                    index++;
                }

                return avgArray;
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
                return null;
            }
        }

        public static Bitmap ProcessTwoDerivative(Bitmap bmp, eDirection direction, int referenceValue)
        {
            try
            {
                if (bmp == null)
                    return null;

                Mat mat = BitmapConverter.ToMat(bmp);
                if (mat.Channels() != 1)
                    Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2GRAY);

                Bitmap newBitmap = null;
                Mat blur = mat.Clone();

                for (int i = 0; i < 3; i++)
                {
                    //if(i == 0)
                    //Cv2.MedianBlur(blur, blur, 3);
                    //else
                    Cv2.GaussianBlur(blur, blur, new OpenCvSharp.Size(0, 0), 7);
                    Cv2.AddWeighted(mat, 1.5, blur, -0.5, 0, mat);
                    //mat.ImWrite("1.bmp");
                }
                //mat = mat + (2 * mat - 2 * blur);

                for (int i = 0; i < 3; i++)
                {
                    Cv2.GaussianBlur(mat, mat, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Reflect101);
                }
                //for (int i = 0; i < avgCount; i++)
                //{
                //    Cv2.GaussianBlur(blur, blur, new OpenCvSharp.Size(avgCount, avgCount), 3, 3, BorderTypes.Reflect101);
                //    Cv2.AddWeighted(mat, 1.5, blur, -0.5, 0, mat);
                //    mat.ImWrite(i.ToString() + ".bmp");
                //}

                //mat = mat + (2 * mat - 2 * blur);

                Bitmap blurBmp = BitmapConverter.ToBitmap(mat);
        
                if (direction == eDirection.Vertical) // 세로
                {
                    List<System.Drawing.Point> drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    newBitmap = HanMechImageHelper.Create8BitGreyBitmap(blurBmp.Width, blurBmp.Height);
                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);
              
                    return newBitmap;
                }
                else if (direction == eDirection.Horizon) // 세로
                {
                    blurBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    List<System.Drawing.Point> drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    newBitmap = HanMechImageHelper.Create8BitGreyBitmap(blurBmp.Width, blurBmp.Height);
                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);

                    newBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    return newBitmap;
                }
                else if (direction == eDirection.All) // 가로, 세로
                {
                    List<System.Drawing.Point> drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    newBitmap = HanMechImageHelper.Create8BitGreyBitmap(blurBmp.Width, blurBmp.Height);
                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);

                    blurBmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    newBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    drawPoints.Clear();

                    drawPoints = GetVerticalPointList(blurBmp, referenceValue);

                    HanMechImageHelper.DrawPointList(ref newBitmap, drawPoints, 255);

                    newBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    return newBitmap;
                }
                else
                { }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<System.Drawing.Point> GetHorizonPointList(Bitmap bmp, int referenceValue)
        {
            List<System.Drawing.Point> pointList = new List<System.Drawing.Point>();

            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                for (int w = 0; w < bmp.Width; w++)
                {
                    byte[] array = new byte[bmp.Height];

                    for (int h = 0; h < bmp.Height; h++)
                    {
                        int index = w + (h * stride);
                        array[h] = data[index];
                    }

                    float[] OneDerivativeArray = HanMechMathHelper.Derivative(array); // 1차 미분
                    float[] twoDerivativeArray = HanMechMathHelper.Derivative(OneDerivativeArray); // 2차 미분

                    for (int i = 0; i < twoDerivativeArray.Count(); i++)
                    {
                        if (Math.Abs(twoDerivativeArray[i]) >= referenceValue)
                        {
                            System.Drawing.Point pt = new System.Drawing.Point();
                            pt.X = w; // +2는 2차 미분해서
                            pt.Y = i;
                            pointList.Add(pt);
                        }
                    }
                }
                bmp.UnlockBits(bmpData);
            }

            return pointList;
        }

        public static List<System.Drawing.Point> GetVerticalPointList(Bitmap bmp, int referenceValue)
        {
            List<System.Drawing.Point> pointList = new List<System.Drawing.Point>();

            unsafe
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                IntPtr ptrData = bmpData.Scan0;
                int stride = bmpData.Stride;
                byte* data = (byte*)(void*)ptrData;

                for (int h = 0; h < bmp.Height; h++)
                {
                    int index = h * stride;
                    byte[] array = new byte[bmp.Width];
                    Marshal.Copy(ptrData, array, 0, bmp.Width);

                    float[] OneDerivativeArray = HanMechMathHelper.Derivative(array); // 1차 미분
                    float[] twoDerivativeArray = HanMechMathHelper.Derivative(OneDerivativeArray); // 2차 미분

                    for (int i = 0; i < twoDerivativeArray.Count(); i++)
                    {
                        if (Math.Abs(twoDerivativeArray[i]) >= referenceValue)
                        {
                            System.Drawing.Point pt = new System.Drawing.Point();
                            pt.X = i + 2; // +2는 2차 미분해서
                            pt.Y = h;
                            pointList.Add(pt);
                        }
                    }
                    ptrData += stride;
                }
                bmp.UnlockBits(bmpData);
            }

            return pointList;
        }

        public static Mat CropInspArea(Mat src, int ignoreX, int ignoreY, ref int startIdxX, ref int startIdxY)
        {
            Mat dst = new Mat();
            Rect inspAreaRect = new Rect();

            startIdxX = 0;
            if(ignoreX >= 0)
                startIdxX = ignoreX;

            int width = src.Width - Math.Abs(ignoreX);

            startIdxY = 0;
            if (ignoreY >= 0)
                startIdxY = ignoreY;

            int height = src.Height - Math.Abs(ignoreY);

            inspAreaRect = new Rect(startIdxX, startIdxY, width, height);
            
            dst = src.Clone(inspAreaRect);
            return dst;
        }

        public static Mat ProcessThreshold(ref Mat src, int threshold, bool isWhite, bool isClose, int openCloseCount)
        {
            Mat bin = new Mat(src.Rows, src.Cols, MatType.CV_8SC1);

            if(isWhite)
                Cv2.Threshold(src, bin, threshold, 255, ThresholdTypes.Binary); 
            else
                Cv2.Threshold(src, bin, threshold, 255, ThresholdTypes.BinaryInv); 

            if (isClose) //이진화 후처리 팽창 후 침식
            {
                int postCount = openCloseCount;
                for (int c = 0; c < postCount; c++)
                    Cv2.Dilate(bin, bin, new Mat());
                for (int c = 0; c < postCount; c++)
                    Cv2.Erode(bin, bin, new Mat());
            }
            else    //이진화 후처리 침식 후 팽창
            {
                int postCount = openCloseCount;
                for (int c = 0; c < postCount; c++)
                    Cv2.Erode(bin, bin, new Mat());
                for (int c = 0; c < postCount; c++)
                    Cv2.Dilate(bin, bin, new Mat());
            }
            return bin;
        }

        public static Mat ProcessCanny(Mat src, int avgCount, double threshold1, double threshold2, bool IsClose, int openCloseCount, int kernelSize)
        {
            if (src.Channels() != 1)
            {
                Cv2.CvtColor(src, src, OpenCvSharp.ColorConversionCodes.BGR2GRAY);
            }
            Mat blur = new Mat(src.Rows, src.Cols, src.Type());
            Mat dst = new Mat(src.Rows, src.Cols, src.Type());

            //mat.ImWrite("0.bmp");

            //이미지 전처리
            for (int i = 0; i < avgCount; i++) //블러 처리 및 샤프닝 기법 사용 횟수
            {
                //if(i == 0)
                //Cv2.MedianBlur(blur, blur, 3);
                //else
                if (i == 0)
                {
                    Cv2.GaussianBlur(src, blur, new OpenCvSharp.Size(0, 0), kernelSize);   //블러 처리로 잡음 제거
                    Cv2.AddWeighted(src, 1.5, blur, -0.5, 0, dst);// 샤프닝 기법으로 틀어진 포커스 완화
                }
                else
                {
                    Cv2.GaussianBlur(blur, blur, new OpenCvSharp.Size(0, 0), kernelSize);   //블러 처리로 잡음 제거
                    Cv2.AddWeighted(dst, 1.5, blur, -0.5, 0, dst);// 샤프닝 기법으로 틀어진 포커스 완화
                }

                //mat.ImWrite("1.bmp");
            }
            //mat = mat + (2 * mat - 2 * blur);

            for (int i = 0; i < avgCount; i++) // 샤프닝 기법으로 인해 생긴 잡음 제거
            {
                Cv2.GaussianBlur(dst, dst, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Reflect101);
            }
            //mat.ImWrite("2.bmp");

            //Cv2.Canny(dst, dst, threshold1, threshold2); //엣지 검출 이진화
            Cv2.Threshold(dst, dst, (double)threshold1, 255, ThresholdTypes.BinaryInv); //엣지 검출 이진화
            //Cv2.AdaptiveThreshold(dst, dst, 255, AdaptiveThresholdTypes.MeanC, ThresholdTypes.BinaryInv, 1, 1); //엣지 검출 이진화

            if (IsClose) //이진화 후처리 팽창 후 침식
            {
                int postCount = openCloseCount;
                for (int c = 0; c < postCount; c++)
                    Cv2.Dilate(dst, dst, new Mat());
                for (int c = 0; c < postCount; c++)
                    Cv2.Erode(dst, dst, new Mat());
            }
            else    //이진화 후처리 침식 후 팽창
            {
                int postCount = openCloseCount;
                for (int c = 0; c < postCount; c++)
                    Cv2.Erode(dst, dst, new Mat());
                for (int c = 0; c < postCount; c++)
                    Cv2.Dilate(dst, dst, new Mat());
            }

            blur.Dispose();

            return dst;
        }
        public static void createThumbnail(double rate, Mat src, out Mat thumb)
        {
            Bitmap bmp = BitmapConverter.ToBitmap(src);
            int width = (int)(bmp.Width * rate);
            int height = (int)(bmp.Height * rate);
            System.Drawing.Size size = new System.Drawing.Size(width, height);

            thumb = BitmapConverter.ToMat((Bitmap)bmp.GetThumbnailImage(width, height, null, new IntPtr()));
        }
        public static void createThumbnail(double rate, Image bmp, out Image thumb)
        {
            //double rate = (double)bmp.Width / (double)nThumbWidth;
            int width = (int)(bmp.Width * rate);
            int height = (int)(bmp.Height * rate);
            System.Drawing.Size size = new System.Drawing.Size(width, height);

            thumb = bmp.GetThumbnailImage(width, height, null, new IntPtr());
        }
    }
}
