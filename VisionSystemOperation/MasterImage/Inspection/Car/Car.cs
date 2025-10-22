using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionSystemOperation.Inspection.MotorCar.Model
{
    public struct sEngineType
    {
        public string Name;
        public int index;

        public sEngineType(string name, int idx)
        {
            this.Name = name;
            this.index = idx;
        }
        public sEngineType CopyTo()
        {
            sEngineType newObj = new sEngineType(this.Name, this.index);

            return newObj;
        }
    }
    public struct sOptionType
    {
        public string Name;
        public int plcIBitIdx;

        public sOptionType(string name, int idx)
        {
            this.Name = name;
            this.plcIBitIdx = idx;
        }
        public sOptionType CopyTo()
        {
            sOptionType newObj = new sOptionType(this.Name, this.plcIBitIdx);

            return newObj;
        }
    }

    public class SelectedOptions
    {
        public static sOptionType NoneType { get; } = new sOptionType("None", -1);

        public List<sOptionType> SelectedOptTypes { get; set; } = new List<sOptionType>();
        public string CurOptionName { get; set; } = "";

        public string GetFullName(int[] carOptionBitOnIndexs)
        {
            string fullName = "";

            ////켜져있는 Bit address를 가져와야하는데...
            List<int> turnOnBitIndexs = GetTurnOnBitIdx(carOptionBitOnIndexs);

            if (turnOnBitIndexs.Count == 0)
            {
                int noneIdx = GetSelectedIndex(NoneType.plcIBitIdx);
                if (noneIdx != -1)
                {
                    CurOptionName = NoneType.Name;
                }
            }
            else
            {
                for (int i = 0; i < turnOnBitIndexs.Count; i++)
                {
                    int turnOnBitAddress = turnOnBitIndexs[i];
                    int optIdx = GetSelectedIndex(turnOnBitAddress);
                    if (optIdx != -1)
                    {
                        CurOptionName += SelectedOptTypes[optIdx].Name;

                        if(turnOnBitIndexs.Count - 1 != i)
                        {
                            CurOptionName += "_";
                        }
                    }

                }
            }

            return CurOptionName;
        }

        public int GetSelectedIndex(int plcIndexBitAddress)
        {
            int r = -2;

            for (int index = 0; index < SelectedOptTypes.Count; index++)
            {
                if (plcIndexBitAddress == SelectedOptTypes[index].plcIBitIdx)
                {
                    r = index;
                }
            }

            return r;
        }

        public int GetMinMaxIdx(bool isMax)
        {
            if (SelectedOptTypes.Count < 0) return -1;
            if (SelectedOptTypes.Count < 1) return 0;

            int minMaxIdx = SelectedOptTypes[0].plcIBitIdx;

            for (int i = 0; i < SelectedOptTypes.Count - 1; i++)
            {
                if(isMax)
                    minMaxIdx = Math.Max(minMaxIdx, SelectedOptTypes[i + 1].plcIBitIdx);
                else
                    minMaxIdx = Math.Min(minMaxIdx, SelectedOptTypes[i + 1].plcIBitIdx);
            }

            return minMaxIdx;
        }

        public Dictionary<string, int> GetSelectedOptions()
        {
            Dictionary<string, int> optionList = new Dictionary<string, int>();

            for (int i = 0; i < SelectedOptTypes.Count; i++)
            {
                if (!optionList.ContainsKey(SelectedOptTypes[i].Name))
                    optionList.Add(SelectedOptTypes[i].Name, SelectedOptTypes[i].plcIBitIdx);
            }

            return optionList;
        }

        public List<int> GetTurnOnBitIdx(int[] carOptionBitOnIndexs)
        {
            int startIdx = GetMinMaxIdx(false);
            int endIdx = GetMinMaxIdx(true) + 1; //Max 15

            if (carOptionBitOnIndexs.Length < endIdx) endIdx = carOptionBitOnIndexs.Length;

            List<int> turnOnBitIndexs = new List<int>();

            for (int i = startIdx; i < endIdx; i++)
            {
                int v = carOptionBitOnIndexs[i];
                if (v == 1)
                    turnOnBitIndexs.Add(i);
            }

            return turnOnBitIndexs;
        }

        public bool IsExistOpts(int[] carOptionBitOnIndexs) // 이미 PLC 클래스에서 확인하고 정의한 Bit 켜진 BitAddress Array
        {
            bool r = false;

            ////켜져있는 Bit address를 가져와야하는데...
            //List<int> turnOnBitIndexs = GetTurnOnBitIdx(carOptionBitOnIndexs);

            if (carOptionBitOnIndexs.Count() == 0)
            {
                int noneIdx = GetSelectedIndex(SelectedOptions.NoneType.plcIBitIdx);
                if (noneIdx != -1)
                    r = true;
            }
            else
            {
                for (int i = 0; i < carOptionBitOnIndexs.Count(); i++)
                {
                    int turnOnBitAddress = carOptionBitOnIndexs[i];
                    int optIdx = GetSelectedIndex(turnOnBitAddress);
                    if (optIdx != -1)
                        r |= true;

                }
            }

            return r;
        }

        public List<int> GetSelectedOptionsIndex()
        {
            List<int> indexList = new List<int>();

            for (int i = 0; i < SelectedOptTypes.Count; i++)
            {
                if (SelectedOptTypes[i].plcIBitIdx == NoneType.plcIBitIdx) continue;

                if (!indexList.Contains(SelectedOptTypes[i].plcIBitIdx))
                    indexList.Add(SelectedOptTypes[i].plcIBitIdx);
            }

            return indexList;
        }

        public List<string> GetNames()
        {
            List<string> fullNames = new List<string>();

            SelectedOptTypes.Sort(new Comparison<sOptionType>((n1, n2) => n1.plcIBitIdx.CompareTo(n2.plcIBitIdx)));

            for (int i = 0; i < SelectedOptTypes.Count; i++)
            {
                fullNames.Add(SelectedOptTypes[i].Name);
            }

            for (int prevIdx = 0; prevIdx < SelectedOptTypes.Count - 1; prevIdx++)
            {
                if (SelectedOptTypes[prevIdx].Name == NoneType.Name)
                    continue;
                for (int curIdx = prevIdx + 1; curIdx < SelectedOptTypes.Count; curIdx++)
                {
                    string name = SelectedOptTypes[prevIdx].Name + "_" + SelectedOptTypes[curIdx].Name;
                    if (!fullNames.Contains(name))
                    {
                        fullNames.Add(name);
                    }
                }
            }

            return fullNames;
        }

        internal void SetCurOptionName(int[] carOptionPLCArray)
        {
            if (carOptionPLCArray.Count() == 0)
                CurOptionName = NoneType.Name;
            else
            {
                for (int i = 0; i < carOptionPLCArray.Length; i++)
                {
                    int optIdx = GetSelectedIndex(carOptionPLCArray[i]);
                    if (optIdx == -2) continue;

                    CurOptionName += SelectedOptTypes[optIdx].Name;
                    if (carOptionPLCArray.Length - 1 != i)
                    {
                        CurOptionName += "_";
                    }
                }

            }
        }
    }


    public class Car
    {
        public int Index { get; set; } = -1;
        public string ModelName { get; set; } = "None";

        public sEngineType EngineType { get; set; } = new sEngineType(SelectedOptions.NoneType.Name, SelectedOptions.NoneType.plcIBitIdx);
        //public sOptionType OptionType { get; set; } = new sOptionType(SelectedOptions.NoneType.Name, SelectedOptions.NoneType.plcIBitIdx);
        public SelectedOptions OptionTypes { get; set; } = new SelectedOptions();

        public Car CopyTo()
        {
            Car newObj = new Car();

            newObj.Index = this.Index;
            newObj.ModelName = this.ModelName;

            newObj.EngineType = this.EngineType.CopyTo();

            for (int i = 0; i < this.OptionTypes.SelectedOptTypes.Count; i++)
            {
                newObj.OptionTypes.SelectedOptTypes.Add(this.OptionTypes.SelectedOptTypes[i].CopyTo());
            }
            newObj.OptionTypes.CurOptionName = this.OptionTypes.CurOptionName;
            return newObj;
        }

        public string GetCarFullName()
        {
            string fullName = ModelName + "_" + EngineType.Name + "_" + OptionTypes.CurOptionName;

            return fullName;
        }

        public List<string> GetCarFullNames()
        {
            List<string> fullNames = new List<string>();

            string fullName = ModelName + "_" + EngineType.Name + "_" ;

            List<string> optionNames = OptionTypes.GetNames();
            for (int i = 0; i < optionNames.Count; i++)
            {
                fullNames.Add(fullName + optionNames[i]);
            }

            return fullNames;
        }


    }
}
