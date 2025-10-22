using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OpenCvSharp;

namespace Inspection.Utility
{
    public class HanMechMathHelper
    {
        object lockMath = new object();

        public static float[] Derivative(float[] array)
        {
            int nSize = array.Count() - 1;
            float[] derivativeArray = new float[nSize];

            for (int i = 0; i < nSize; i++)
            {
                derivativeArray[i] = array[i + 1] - array[i];
            }
            return derivativeArray;
        }

        public static float[] Derivative(byte[] array)
        {
            int nSize = array.Count() - 1;
            float[] derivativeArray = new float[nSize];

            for (int i = 0; i < nSize; i++)
            {
                int nextValue = Convert.ToInt32(array[i + 1]);
                int value = Convert.ToInt32(array[i]);
                derivativeArray[i] = Convert.ToSingle(nextValue - value);
            }
            return derivativeArray;
        }

        public static int GetMinVal(int[] value)
        {
            int minval = 9999999;
            if (value[0] == 0 && value[1] == 0 && value[2] == 0)
                return 0;
            for (int i = 0; i < value.Count(); i++)
            {
                if (value[i] < minval && value[i] != 0)
                {
                    minval = value[i];
                }
            }
            return minval;
        }

        public static int GetMaxVal(int[] value)
        {
            int maxval = 0;
            for (int i = 0; i < value.Count(); i++)
            {
                if (value[i] > maxval)
                {
                    maxval = value[i];
                }
            }

            return maxval;
        }

        public static bool IsDigit(string str)
        {
            bool result = true;

            for (int i = 0; i < str.Length; i++)
            {
                if(!Char.IsDigit(str, i))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static System.Drawing.Point GetCrossingPoint(PointF startLineP1, PointF endLineP1, PointF startLineP2, PointF endLineP2)
        {
            System.Drawing.Point crossingPoint = new System.Drawing.Point(0, 0);

            if (
                startLineP1 == null ||
                endLineP1 == null ||
                startLineP2 == null ||
                endLineP2 == null
                )
                return crossingPoint;

            double t, s;
            double under = (endLineP2.Y - startLineP2.Y) * (endLineP1.X - startLineP1.X) - (endLineP2.X - startLineP2.X) * (endLineP1.Y - startLineP1.Y);
            if (under != 0)
            {
                double _t = (endLineP2.X - startLineP2.X) * (startLineP1.Y - startLineP2.Y) - (endLineP2.Y - startLineP2.Y) * (startLineP1.X - startLineP2.X);
                double _s = (endLineP1.X - startLineP1.X) * (startLineP1.Y - startLineP2.Y) - (endLineP1.Y - startLineP1.Y) * (startLineP1.X - startLineP2.X);

                t = _t / under;
                s = _s / under;

                if (t < 0.0 || t > 1.0 || s < 0.0 || s > 1.0)
                    return crossingPoint;

                if (_t == 0 && _s == 0)
                    return crossingPoint;

                crossingPoint.X = (int)(startLineP1.X + t * (double)(endLineP1.X - startLineP1.X));
                crossingPoint.Y = (int)(startLineP1.Y + t * (double)(endLineP1.Y - startLineP1.Y));
            }

            return crossingPoint;
        }

        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
