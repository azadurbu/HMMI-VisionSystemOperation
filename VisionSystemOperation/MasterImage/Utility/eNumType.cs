using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Utility
{
    public enum eDirectionType
    {
        Left,
        Right,
        Top,
        Bottom,
        None
    }
    public enum eCornerType
    {
        LeftTop,
        RightTop,
        RightBottom,
        LeftBottom,
        None
    }

    public enum eDirection
    {
        None,
        Horizon, //가로
        Vertical, // 세로
        All,
    }
    public enum eResultConstants { NONE, OK, NG };


}
