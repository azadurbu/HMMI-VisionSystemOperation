using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystemOperation.Device.Light
{
    public enum LightGroup
    {
        ALL,
        Top,
        Bottom,
        Left,
        Right
    }
    public class LightProperty
    {
        public int Level { get; set; } = 1000;
        public int Channel { get; set; } = 1;
        public string Comport { get; set; } = "com8";
        public int Channel1 { get; set; } = 600;
        public int Channel2  { get; set; } = 600;
        public int Channel3  { get; set; } = 600;
        public int Channel4  { get; set; } = 600;
        public int Channel5  { get; set; } = 600;
        public int Channel6  { get; set; } = 600;
        public int Channel7  { get; set; } = 600;
        public int Channel8  { get; set; } = 600;
        public int Channel9 { get; set; }  = 600;
        public int Channel10 { get; set; } = 600;

        public void SetProperty(LightProperty property)
        {
            this.Level = property.Level;
            this.Channel = property.Channel;
            this.Comport = property.Comport;
            this.Channel1 = property.Channel1;
            this.Channel2 = property.Channel2;
            this.Channel3 = property.Channel3;
            this.Channel4 = property.Channel4;
            this.Channel5 = property.Channel5;
            this.Channel6 = property.Channel6;
            this.Channel7 = property.Channel7;
            this.Channel8 = property.Channel8;
            this.Channel9 = property.Channel9;
            this.Channel10 = property.Channel10;
        }

        public LightProperty Copy()
        {
            LightProperty property = new LightProperty();
            property.Level = this.Level;
            property.Channel = this.Channel;
            property.Comport = this.Comport; 
            property.Channel1 = this.Channel1;
            property.Channel9 = this.Channel2;
            property.Channel8 = this.Channel3;
            property.Channel7 = this.Channel4;
            property.Channel6 = this.Channel5;
            property.Channel5 = this.Channel6;
            property.Channel4 = this.Channel7;
            property.Channel3 = this.Channel8;
            property.Channel2 = this.Channel9;
            property.Channel10 = this.Channel10;

            return property;
        }
    }
}
