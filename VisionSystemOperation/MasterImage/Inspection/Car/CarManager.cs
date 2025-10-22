using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using VisionSystemOperation.Inspection.MotorCar.Model;

namespace VisionSystemOperation.Inspection.MotorCar
{
    public enum eCarOptEngType
    {
        Option,
        Engine
    }

    public class CarManager
    {
        public static string PARAM_PATH = System.Environment.CurrentDirectory + @"\Config\Recipe\";

        public string VinID { get; set; } = "";
        public Car CurCar { get; set; } = new Car();

        private object mFfileLoadLock = new object();
        private List<Car> mCars = new List<Car>();
        public List<Car> CarDB { get { return mCars; } }
        public List<sOptionType> OptionDB { get; set; } = new List<sOptionType>();

        public CarManager()
        {
            if (Directory.Exists(PARAM_PATH) == false)
                Directory.CreateDirectory(PARAM_PATH);
        }
        
        public void CreateCarRecipeFolder()
        {
            for (int i = 0; i < mCars.Count; i++)
            {
                Car curCar = mCars[i];

                //20250609 jskim modify when create new Inspection folder
                List<string> fullNames = curCar.GetCarFullNames();
                foreach (string fullName in fullNames)
                {
                    string path = PARAM_PATH + fullName;
                    if (Directory.Exists(path) == false)
                        Directory.CreateDirectory(path);
                }

                //string path = PARAM_PATH + curCar.GetCarFullName();
                //if (Directory.Exists(path) == false)
                //    Directory.CreateDirectory(path);
            }
        }

        public void SaveDB()
        {
            ////Car DB
            string path = System.Environment.CurrentDirectory + @"\Config\";
            string fileName = "CarDataSheet.csv";

            using (StreamWriter sw = new StreamWriter(path + fileName, false, Encoding.Default))
            {
                string header = "ModelName,PLCIdx,EngineName,PLCIdx,OptionName,PLCIdx";
                sw.WriteLine(header);

                for (int i = 0; i < mCars.Count; i++)
                {
                    Car curCar = mCars[i];
                    string content = "";
                    string modelEngName = string.Format($"{curCar.ModelName},{curCar.Index},{curCar.EngineType.Name},{curCar.EngineType.index}");

                    SelectedOptions selectedOptions = curCar.OptionTypes;
                    for (int optIdx = 0; optIdx < selectedOptions.SelectedOptTypes.Count; optIdx++)
                    {
                        if (optIdx == 0)
                            content = $"{modelEngName},{selectedOptions.SelectedOptTypes[optIdx].Name},{selectedOptions.SelectedOptTypes[optIdx].plcIBitIdx}";
                        else
                            content += $",{selectedOptions.SelectedOptTypes[optIdx].Name},{selectedOptions.SelectedOptTypes[optIdx].plcIBitIdx}";
                    }
                    sw.WriteLine(content);
                }
            }

            ////Option DB
            path = System.Environment.CurrentDirectory + @"\Config\";
            fileName = "OptionDataSheet.csv";

            using (StreamWriter sw = new StreamWriter(path + fileName, false, Encoding.Default))
            {
                string header = "OptionName,PLCIdx";
                sw.WriteLine(header);

                for (int i = 0; i < OptionDB.Count; i++)
                {
                    sOptionType curOpt = OptionDB[i];
                    string content = string.Format($"{curOpt.Name},{curOpt.plcIBitIdx}");
                    sw.WriteLine(content);
                }
            }

            CreateCarRecipeFolder();
        }

        public void LoadDB()
        {
            string path = System.Environment.CurrentDirectory + @"\Config\";
            string fileName = "CarDataSheet.csv";
            lock (mFfileLoadLock)
            {
                CarDB.Clear();
                OptionDB.Clear();
                try
                {
                    using (StreamReader sr = new StreamReader(path + fileName, Encoding.Default))
                    {
                        string data = "";
                        while (!sr.EndOfStream)
                        {
                            data = sr.ReadLine();

                            string[] carInforms = data.Split(',');
                            if (carInforms[0] == "ModelName") continue;

                            int informIdx = 0;

                            Car newCar = new Car();
                            newCar.ModelName = carInforms[informIdx++];
                            newCar.Index = Int32.Parse(carInforms[informIdx++]);

                            newCar.EngineType = new sEngineType(carInforms[informIdx++], Int32.Parse(carInforms[informIdx++]));

                            for (int i = informIdx; i < carInforms.Count(); i += 2)
                            {
                                sOptionType newOption = new sOptionType(carInforms[i], Int32.Parse(carInforms[i + 1]));
                                newCar.OptionTypes.SelectedOptTypes.Add(newOption);
                            }

                            CarDB.Add(newCar);
                        }
                    }

                    fileName = "OptionDataSheet.csv";
                    using (StreamReader sr = new StreamReader(path + fileName, Encoding.Default))
                    {
                        string data = "";
                        while (!sr.EndOfStream)
                        {
                            data = sr.ReadLine();

                            string[] carInforms = data.Split(',');
                            if (carInforms[0] == "OptionName") continue;

                            int informIdx = 0;

                            sOptionType newOPtion = new sOptionType(carInforms[informIdx++], Int32.Parse(carInforms[informIdx++]));

                            OptionDB.Add(newOPtion);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public bool IsExistCar(string name)
        {
            bool r = false;

            for (int i = 0; i < mCars.Count; i++)
            {
                if(mCars[i].ModelName == name)
                {
                    r = true;
                    break;
                }
            }

            return r;
        }
        private bool IsExistCar(string modelName, string engineName)
        {
            bool r = false;

            for (int i = 0; i < mCars.Count; i++)
            {
                if (mCars[i].ModelName == modelName)
                {
                    if (mCars[i].EngineType.Name == engineName)
                    {
                        r = true;
                        break;
                    }
                }
            }

            return r;
        }

        public List<Car> GetCarListByModel(string modelName)
        {
            List<Car> cars = new List<Car>();

            if (CarDB.Count == 0) return cars;

            if (modelName == "")
            {
                modelName = CarDB[0].ModelName;
            }

            for (int i = 0; i < CarDB.Count; i++)
            {
                if (modelName == CarDB[i].ModelName)
                {
                    cars.Add(CarDB[i].CopyTo());
                }
            }

            return cars;
        }
        public string GetCarModelNameByIndex(int idx)
        {
            string name = "";
            for (int i = 0; i < CarDB.Count; i++)
            {
                if (CarDB[i].Index == idx)
                {
                    name = CarDB[i].ModelName;
                    break;
                }
            }

            return name;
        }

        public string GetCarEngineNameByIndex(int idx)
        {
            string name = "";
            for (int i = 0; i < CarDB.Count; i++)
            {
                if (CarDB[i].EngineType.index == idx)
                {
                    name = CarDB[i].EngineType.Name;
                    break;
                }
            }

            return name;
        }
        public string[] GetCarModelNameList()
        {
            List<string> modelNameList = new List<string>();

            for (int i = 0; i < CarDB.Count; i++)
            {
                if (!modelNameList.Contains(CarDB[i].ModelName))
                {
                    modelNameList.Add(CarDB[i].ModelName);
                }
            }

            return modelNameList.ToArray();
        }

        public int[] GetCarModelIndexList()
        {
            List<int> carIndexs = new List<int>();

            if (CarDB.Count == 0) return null;

            for (int i = 0; i < CarDB.Count; i++)
            {
                if(!carIndexs.Contains(CarDB[i].Index))
                {
                    carIndexs.Add(CarDB[i].Index);
                }
            }

            return carIndexs.ToArray();
        }


        public Car GetCarByIdx(int carModelIdx, int carEngineIdx, int[] carOptionPLCArray)
        {
            CurCar = null;

            LoadDB();

            for (int i = 0; i < CarDB.Count; i++)
            {
                if (CarDB[i].Index == carModelIdx)
                {
                    if (CarDB[i].EngineType.index == carEngineIdx)
                    {
                        if (CarDB[i].OptionTypes.IsExistOpts(carOptionPLCArray))
                        {
                            CurCar = CarDB[i];
                            CurCar.OptionTypes.SetCurOptionName(carOptionPLCArray);
                            break;
                        }
                    }
                }
            }

            return CurCar;
        }

        public Car GetCarByName(string carModeName, string carEngineName, string optNames)
        {
            CurCar = null;

            LoadDB();

            for (int i = 0; i < CarDB.Count; i++)
            {
                if (CarDB[i].ModelName == carModeName)
                {
                    if (CarDB[i].EngineType.Name == carEngineName)
                    {
                        bool bFind = true;
                        List<string> curOptNames = CarDB[i].OptionTypes.GetNames();

                        if (!curOptNames.Contains(optNames))
                        {
                            bFind &= false;
                        }
                        else
                        {
                            CurCar = CarDB[i];
                            CurCar.OptionTypes.CurOptionName = optNames;
                        }
                        if (!bFind)
                            CurCar = null;
                        else
                            break;
                    }
                }
            }

            return CurCar;
        }

        internal Car GetCar(string carModel, string carEngine)
        {
            Car car = new Car();

            for (int i = 0; i < CarDB.Count; i++)
            {
                if(CarDB[i].ModelName == carModel)
                {
                    if (CarDB[i].EngineType.Name == carEngine)
                    {
                        car = CarDB[i].CopyTo();
                    }
                }
            }

            return car;
        }

        public bool AddCar(string name, int idx)
        {
            bool result = true;
            if (!IsExistCar(name))
            {
                Car car = new Car();
                car.ModelName = name;
                car.Index = idx;

                sEngineType nEngType = new sEngineType(SelectedOptions.NoneType.Name, SelectedOptions.NoneType.plcIBitIdx);
                sOptionType nOptType = new sOptionType(SelectedOptions.NoneType.Name, SelectedOptions.NoneType.plcIBitIdx);

                mCars.Add(car);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public string[] GetCarEngineNameList()
        {
            List<string> engineNameList = new List<string>();

            for (int i = 0; i < CarDB.Count; i++)
            {
                Car curCar = CarDB[i];
                if (!engineNameList.Contains(curCar.EngineType.Name))
                {
                    engineNameList.Add(curCar.EngineType.Name);
                }
            }

            return engineNameList.ToArray();
        }

        public string[] GetCarOptionNameList()
        {
            List<string> optionNameList = new List<string>();
            ////Change to using SelectedOptions jskim 20250410

            for (int i = 0; i < CarDB.Count; i++)
            {
                Car curCar = CarDB[i];
                List<string> curCarOptNameList = curCar.OptionTypes.GetNames();
                if (optionNameList.Count == 0)
                    optionNameList.AddRange(curCarOptNameList);

                else
                {
                    foreach (string item in curCarOptNameList)
                    {
                        if (!optionNameList.Contains(item))
                            optionNameList.Add(item);
                    }
                }
            }

            return optionNameList.ToArray();
        }

        public Dictionary<string, int> GetCarOptEngList(string modelName, eCarOptEngType type)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            for (int i = 0; i < mCars.Count; i++)
            {
                Car curCar = mCars[i];
                if (mCars[i].ModelName == modelName)
                {
                    if (type == eCarOptEngType.Option)
                    {
                        results = curCar.OptionTypes.GetSelectedOptions();
                    }
                    if (type == eCarOptEngType.Engine)
                    {
                        if (!results.ContainsKey(curCar.EngineType.Name))
                            results.Add(curCar.EngineType.Name, curCar.EngineType.index);
                    }
                }
            }

            return results;
        }

        //public Dictionary<string, int> GetCarOptEngList(string modelName, eCarOptEngType type)
        //{
        //    Dictionary<string, int> results = new Dictionary<string, int>();

        //    for (int i = 0; i < mCars.Count; i++)
        //    {
        //        Car curCar = mCars[i];
        //        if (mCars[i].ModelName == modelName)
        //        {
        //            if (type == eCarOptEngType.Option)
        //            {
        //                if (!results.ContainsKey(curCar.OptionType.Name))
        //                    results.Add(curCar.OptionType.Name, curCar.OptionType.plcIBitIdx);
        //            }
        //            if (type == eCarOptEngType.Engine)
        //            {
        //                if (!results.ContainsKey(curCar.EngineType.Name))
        //                    results.Add(curCar.EngineType.Name, curCar.EngineType.index);
        //            }
        //        }
        //    }

        //    return results;
        //}

        public int[] GetCarOptEngIndexList(eCarOptEngType type)
        {
            List<int> results = new List<int>();

            for (int i = 0; i < mCars.Count; i++)
            {
                Car curCar = mCars[i];
                {
                    if (type == eCarOptEngType.Option)
                    {
                        List<int> curCatIdxType = curCar.OptionTypes.GetSelectedOptionsIndex();
                        for (int optIdx = 0; optIdx < curCatIdxType.Count; optIdx++)
                        {
                            if(!results.Contains(curCatIdxType[optIdx]))
                            {
                                results.Add(curCatIdxType[optIdx]);
                            }
                        }
                    }
                    if (type == eCarOptEngType.Engine)
                    {
                        if (curCar.EngineType.index == SelectedOptions.NoneType.plcIBitIdx) continue;

                        if (!results.Contains(curCar.EngineType.index))
                            results.Add(curCar.EngineType.index);
                    }
                }
            }

            return results.ToArray();
        }
        //public int[] GetCarOptEngIndexList(eCarOptEngType type)
        //{
        //    List<int> results = new List<int>();

        //    for (int i = 0; i < mCars.Count; i++)
        //    {
        //        Car curCar = mCars[i];
        //        {
        //            if (type == eCarOptEngType.Option)
        //            {
        //                if (curCar.OptionType.plcIBitIdx == -1) continue;

        //                if (!results.Contains(curCar.OptionType.plcIBitIdx))
        //                    results.Add(curCar.OptionType.plcIBitIdx);
        //            }
        //            if (type == eCarOptEngType.Engine)
        //            {
        //                if (curCar.EngineType.index == -1) continue;

        //                if (!results.Contains(curCar.EngineType.index))
        //                    results.Add(curCar.EngineType.index);
        //            }
        //        }
        //    }

        //    return results.ToArray();
        //}

        //public int[] GetCarOptEngIndexList(eCarOptEngType type)
        //{
        //    List<int> results = new List<int>();

        //    for (int i = 0; i < mCars.Count; i++)
        //    {
        //        Car curCar = mCars[i];
        //        {
        //            if (type == eCarOptEngType.Option)
        //            {
        //                if (curCar.OptionType.plcIBitIdx == -1) continue;

        //                if (!results.Contains(curCar.OptionType.plcIBitIdx))
        //                    results.Add(curCar.OptionType.plcIBitIdx);
        //            }
        //            if (type == eCarOptEngType.Engine)
        //            {
        //                if (curCar.EngineType.index == -1) continue;

        //                if (!results.Contains(curCar.EngineType.index))
        //                    results.Add(curCar.EngineType.index);
        //            }
        //        }
        //    }

        //    return results.ToArray();
        //}

        public bool IsExistOption(string optName, int plcIndex)
        {
            bool r = false;

            for (int i = 0; i < OptionDB.Count; i++)
            {
                if(
                    OptionDB[i].Name == optName ||
                    OptionDB[i].plcIBitIdx == plcIndex
                    )
                {
                    r = true;
                    break;
                }
            }

            return r;
        }
        public bool DelOption2DB(string optName, int plcIndex)
        {
            bool r = true;

            try
            {
                for (int i = OptionDB.Count - 1; i >= 0; i--)
                {
                    if (OptionDB[i].Name == optName && OptionDB[i].plcIBitIdx == plcIndex)
                    {
                        OptionDB.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }
        public bool AddOption2DB(string optName, int plcIndex)
        {
            bool r = false;

            try
            {
                if(!IsExistOption(optName, plcIndex))
                {
                    OptionDB.Add(new sOptionType(optName, plcIndex));
                    r = true;
                }
            }
            catch (Exception ex)
            {
            }

            return r;
        }

        public bool AddCarEngine(string modelName, string optEngName, int plcIndex)
        {
            bool result = true;
            if (!IsExistCar(modelName, optEngName))
            {
                Car curCarModel = null;
                for (int i = 0; i < mCars.Count; i++)
                {
                    if (mCars[i].ModelName == modelName)
                    {
                        curCarModel = mCars[i];
                        break;
                    }
                }
                if (curCarModel == null)
                    result = false;
                else
                {
                    Car newModel = curCarModel.CopyTo();

                    newModel.EngineType = new sEngineType(optEngName, plcIndex);
                    newModel.OptionTypes = new SelectedOptions();

                    mCars.Add(newModel);
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool DelCar(string name, int index, bool isBackup)
        {
            bool r = true;

            try
            {
                for (int i = mCars.Count - 1; i >= 0; i--)
                {
                    if (mCars[i].ModelName == name)
                    {
                        mCars.RemoveAt(i);

                        string path = PARAM_PATH + mCars[i].GetCarFullName();
                        if (Directory.Exists(path))
                        {
                            if(isBackup)
                                Directory.Move(path, path + "_bak_" + $"{DateTime.Now.Hour.ToString()}{DateTime.Now.Minute.ToString()}{DateTime.Now.Second.ToString()}");
                            else
                                Directory.Delete(path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }
        public bool DelCar(string modelName, string optEngName, bool isBackup)
        {
            bool r = true;

            try
            {
                for (int i = mCars.Count - 1; i >= 0; i--)
                {
                    if (mCars[i].ModelName == modelName)
                    {
                        if (mCars[i].EngineType.Name == optEngName)
                        {
                            string path = PARAM_PATH + mCars[i].GetCarFullName();
                            if (Directory.Exists(path))
                            {
                                if (isBackup)
                                    Directory.Move(path, path + "_bak_" + $"{DateTime.Now.Hour.ToString()}{DateTime.Now.Minute.ToString()}{DateTime.Now.Second.ToString()}");
                                else
                                    Directory.Delete(path, true);
                            }

                            mCars.RemoveAt(i);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }

        public bool ModOption2DB(string oldName, string optNewName, int newIdx)
        {
            bool r = true;

            try
            {
                for (int i = mCars.Count - 1; i >= 0; i--)
                {
                    if (OptionDB[i].Name == oldName)
                    {
                        OptionDB[i] = new sOptionType(optNewName, newIdx);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }

        public bool ModifyCar(string oldName, string newName, int newIdx)
        {
            bool r = true;

            try
            {
                for (int i = mCars.Count - 1; i >= 0; i--)
                {
                    if (mCars[i].ModelName == oldName)
                    {
                        string oldPath = PARAM_PATH + mCars[i].GetCarFullName();

                        mCars[i].ModelName = newName;
                        mCars[i].Index = newIdx;

                        string modPath = PARAM_PATH + mCars[i].GetCarFullName();

                        if (Directory.Exists(oldPath))
                        {
                            Directory.Move(oldPath, modPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }

        public bool ModifyCar(string modelName, string oldOptEngName, string newOptEngName, int newOptEngIdx)
        {
            bool r = true;

            try
            {
                for (int i = mCars.Count - 1; i >= 0; i--)
                {
                    if (mCars[i].ModelName == modelName)
                    {
                        string oldPath = PARAM_PATH + mCars[i].GetCarFullName();
                            if (mCars[i].EngineType.Name == oldOptEngName)
                            {
                                mCars[i].EngineType = new sEngineType(newOptEngName, newOptEngIdx);

                                List<string> modPaths = mCars[i].GetCarFullNames();
                                foreach (string item in modPaths)
                                {
                                    string modPath = PARAM_PATH + item;
                                    if (Directory.Exists(oldPath))
                                    {
                                        Directory.Move(oldPath, modPath);
                                    }
                                }

                            }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }

        public bool AddOptions(string modelName, string engineName, SelectedOptions selectedOpts)
        {
            bool r = true;

            try
            {
                for (int i = mCars.Count - 1; i >= 0; i--)
                {
                    if (mCars[i].ModelName == modelName)
                    {
                        if (mCars[i].EngineType.Name == engineName)
                        {
                            mCars[i].OptionTypes = selectedOpts;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.ToString();
                r = false;
            }

            return r;
        }
    }
}
