using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace VisionSystemOperation.Inspection.MotorCar.Model
{
    enum eHeaderColumn
    {
        Name,
        PLC_MAP_Index,
        Count
    }
    public partial class FormCarRecipe : Form
    {
        CarManager Manager = new CarManager();

        private int CurModelSelRowIdx { get; set; } = 0;
        private int CurEngSelRowIdx { get; set; } = 0;
        private int CurOptListSelRowIdx { get; set; } = 0;
        private int CurSelectedOptListSelRowIdx { get; set; } = 0;

        public FormCarRecipe()
        {
            InitializeComponent();

            //Car sCar = new Car();
            //sCar.ModelName = "SU2id";
            //sCar.Index = 0;

            //Car kCar = new Car();
            //kCar.ModelName = "KS";
            //kCar.Index = 1;

            //sEngineType gEngType = new sEngineType("GM2", 10);
            //sEngineType kEngType = new sEngineType("KPA", 11);
            //sEngineType nEngType = new sEngineType("None", -1);

            //sOptionType fOptType = new sOptionType("F/L", 15);
            //sOptionType nOptType = new sOptionType("None", -1);


            ////SU2id Gammma F/L
            //sCar.EngineType = gEngType.CopyTo();
            //sCar.OptionType = fOptType.CopyTo();

            //Manager.CarDB.Add(sCar.CopyTo());

            ////SU2id KAPPA F/L
            //sCar.EngineType = kEngType.CopyTo();
            //sCar.OptionType = fOptType.CopyTo();
            //Manager.CarDB.Add(sCar.CopyTo());

            ////SU2id Gammma None
            //sCar.EngineType = gEngType.CopyTo();
            //sCar.OptionType = nOptType.CopyTo();

            //Manager.CarDB.Add(sCar.CopyTo());

            ////SU2id KAPPA None
            //sCar.EngineType = kEngType.CopyTo();
            //sCar.OptionType = nOptType.CopyTo();
            //Manager.CarDB.Add(sCar.CopyTo());

            ////KS None
            //kCar.EngineType = nEngType.CopyTo();
            //kCar.OptionType = nOptType.CopyTo();
            //Manager.CarDB.Add(kCar.CopyTo());

            ////KS F/L
            //kCar.EngineType = nEngType.CopyTo();
            //kCar.OptionType = fOptType.CopyTo();
            //Manager.CarDB.Add(kCar.CopyTo());
        }

        private void AddNewGird(ref DataGridView dataGridView, string name, int idx)
        {
            dataGridView.Rows.Add(new object[] {
                        name,
                        idx
            });
        }

        public bool CheckSameValue(ref DataGridView dataGridView, int cols, string value)
        {
            bool r = false;

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if(dataGridView[cols, i].Value.ToString() == value)
                {
                    r = true;
                    break;
                }
            }

            return r;
        }

        public void InitCarEngineData(List<Car> curCarModel)
        {
            dgvCarEngineType.Rows.Clear();

            for (int i = 0; i < curCarModel.Count; i++)
            {
                Car curCar = curCarModel[i];
                string[] dataRows = new string[2];

                if (dgvCarEngineType.Rows.Count == 0)
                {
                    //dataRows[0] = curCar.EngineType.Name;
                    //dataRows[1] = curCar.EngineType.index.ToString();
                    //dgvCarEngineType.Rows.Add(dataRows);

                    dgvCarEngineType.Rows.Add();
                    dgvCarEngineType[(int)eHeaderColumn.Name, dgvCarEngineType.Rows.Count - 1].Value = curCar.EngineType.Name;
                    dgvCarEngineType[(int)eHeaderColumn.PLC_MAP_Index, dgvCarEngineType.Rows.Count - 1].Value = curCar.EngineType.index;
                }
                else
                {
                    if(!CheckSameValue(ref dgvCarEngineType, 0, curCar.EngineType.Name))
                    {
                        //dataRows[0] = curCar.EngineType.Name;
                        //dataRows[1] = curCar.EngineType.index.ToString();
                        //dgvCarEngineType.Rows.Add(dataRows);'                    
                        dgvCarEngineType.Rows.Add();
                        dgvCarEngineType[(int)eHeaderColumn.Name, dgvCarEngineType.Rows.Count - 1].Value = curCar.EngineType.Name;
                        dgvCarEngineType[(int)eHeaderColumn.PLC_MAP_Index, dgvCarEngineType.Rows.Count - 1].Value = curCar.EngineType.index;
                    }
                }
            }

            if (dgvCarEngineType.Rows.Count <= CurEngSelRowIdx)
                CurEngSelRowIdx = dgvCarEngineType.Rows.Count - 1;

            if (CurEngSelRowIdx == -1) return;

            dgvCarEngineType.Rows[CurEngSelRowIdx].Selected = true;

        }
        public void InitCarOptData(Car curCarModel)
        {
            dgvCarUseOpts.Rows.Clear();

            SelectedOptions options = curCarModel.OptionTypes;
            for (int i = 0; i < options.SelectedOptTypes.Count; i++)
            {
                dgvCarUseOpts.Rows.Add();
                dgvCarUseOpts[(int)eHeaderColumn.Name, dgvCarUseOpts.Rows.Count - 1].Value = options.SelectedOptTypes[i].Name;
                dgvCarUseOpts[(int)eHeaderColumn.PLC_MAP_Index, dgvCarUseOpts.Rows.Count - 1].Value = options.SelectedOptTypes[i].plcIBitIdx;
            }

            if (dgvCarUseOpts.Rows.Count <= CurSelectedOptListSelRowIdx)
                CurSelectedOptListSelRowIdx = dgvCarUseOpts.Rows.Count - 1;

            if (CurSelectedOptListSelRowIdx == -1) return;

            dgvCarUseOpts.Rows[CurSelectedOptListSelRowIdx].Selected = true;

            //{
            //    Car curCar = curCarModel[i];
            //    string[] dataRows = new string[2];

            //    if (dgvCarOptType.Rows.Count == 0)
            //    {
            //        dataRows[0] = curCar.OptionType.Name;
            //        dataRows[1] = curCar.OptionType.plcIBitIdx.ToString();
            //        dgvCarOptType.Rows.Add(dataRows);
            //    }
            //    else
            //    {
            //        if (!CheckSameValue(ref dgvCarOptType, 0, curCar.OptionType.Name))
            //        {
            //            dataRows[0] = curCar.OptionType.Name;
            //            dataRows[1] = curCar.OptionType.plcIBitIdx.ToString();
            //            dgvCarOptType.Rows.Add(dataRows);
            //        }
            //    }
            //}
            //if (dgvCarOptType.Rows.Count <= CurEngSelRowIdx)
            //    CurOptSelRowIdx = dgvCarOptType.Rows.Count - 1;

            //dgvCarOptType.Rows[CurOptSelRowIdx].Selected = true;
        }

        private void InitGridView(ref DataGridView dataGridView, bool IsMulti = false)
        {
            try
            {
                foreach (eHeaderColumn item in Enum.GetValues(typeof(eHeaderColumn)))
                {
                    if (item == eHeaderColumn.Count) continue;

                    dataGridView.Columns.Add(item.ToString(), item.ToString());
                }
                //if(IsOptions)
                //{
                //    DataGridViewCheckBoxColumn chkUse = new DataGridViewCheckBoxColumn();
                //    chkUse.HeaderText = eHeaderColumn.Use.ToString();
                //    chkUse.Name = eHeaderColumn.Use.ToString();
                //    dataGridView.Columns.Add(chkUse); // 6
                //}

                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView.RowHeadersVisible = false;

                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[i].ReadOnly = true;
                    dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

                    if (IsMulti)
                        dataGridView.MultiSelect = true;
                }
                dataGridView.Columns[(int)eHeaderColumn.PLC_MAP_Index].ValueType = typeof(int);


                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;

            }
            catch (Exception)
            {
            }
        }

        public void ShowModelNameList()
        {
            lbxModelNameList.Items.Clear();
            for (int i = 0; i < Manager.CarDB.Count; i++)
            {
                Car curCar = Manager.CarDB[i];

                List<string> fullNames = curCar.GetCarFullNames();
                foreach (string fullName in fullNames)
                {
                    lbxModelNameList.Items.Add(fullName);
                }
            }
        }

        private void InitCarModelData()
        {
            try
            {
                dgvCarModel.Rows.Clear();
                for (int i = 0; i < Manager.CarDB.Count; i++)
                {
                    Car curCar = Manager.CarDB[i];
                    string[] dataRows = new string[2];

                    if (dgvCarModel.Rows.Count == 0)
                    {
                        //dataRows[0] = curCar.ModelName;
                        //dataRows[1] = curCar.Index.ToString();
                        //dgvCarModel.Rows.Add(dataRows);

                        dgvCarModel.Rows.Add();
                        dgvCarModel[(int)eHeaderColumn.Name, dgvCarModel.Rows.Count - 1].Value = curCar.ModelName;
                        dgvCarModel[(int)eHeaderColumn.PLC_MAP_Index, dgvCarModel.Rows.Count - 1].Value = curCar.Index;
                    }
                    else
                    {
                        if (!CheckSameValue(ref dgvCarModel, 0, curCar.ModelName))
                        {
                            dgvCarModel.Rows.Add();
                            dgvCarModel[(int)eHeaderColumn.Name, dgvCarModel.Rows.Count - 1].Value = curCar.ModelName;
                            dgvCarModel[(int)eHeaderColumn.PLC_MAP_Index, dgvCarModel.Rows.Count - 1].Value = curCar.Index;
                        }
                    }
                }
                if (dgvCarModel.Rows.Count <= CurModelSelRowIdx)
                    CurModelSelRowIdx = dgvCarModel.Rows.Count - 1;

                if (CurModelSelRowIdx == -1) return;

                dgvCarModel.Rows[CurModelSelRowIdx].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed Add Model. Select model and retry.");
                return;
            }

            int iModelRow = dgvCarModel.SelectedRows[0].Index;
            try
            {
                if (iModelRow == -1)
                    return;

                string carModel = dgvCarModel[0, iModelRow].Value.ToString();

                List<Car> carModels = Manager.GetCarListByModel(carModel);
                InitCarEngineData(carModels);
            }
            catch (Exception exs)
            {
                MessageBox.Show("Failed Add Engine. Select model and retry.");
                return;
            }

            try
            {
                if (iModelRow == -1)
                    return;

                string carModel = dgvCarModel[0, iModelRow].Value.ToString();
                int iEngineRow = dgvCarEngineType.SelectedRows[0].Index;
                if (iEngineRow == -1)
                    return;
                string carEngine = dgvCarEngineType[0, iEngineRow].Value.ToString();

                Car car = Manager.GetCar(carModel, carEngine);
                InitCarOptData(car);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed Add Option. Select model&Engine and retry.");
                return;
            }

            dgvCarModel_CellClick(null, null);
        }

        private void FormCarRecipe_Load(object sender, EventArgs e)
        {
            Manager.LoadDB();

            InitGridView(ref dgvCarModel);
            InitGridView(ref dgvCarEngineType);
            InitGridView(ref dgvCarOptTypes, true);
            InitGridView(ref dgvCarUseOpts);

            InitCarModelData();
            ShowModelNameList();
            ShowOptionTypeList();
        }

        private void btnAddCarModel_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "") return;
           // if (CheckSpecialChar(txbName.Text))
            //{
            //    MessageBox.Show("No Write Special Characters: " + expStr);
            //    return;
            //}

            if (!Manager.AddCar(txbName.Text, Int32.Parse(txbPLCIdx.Text)))
            {
                string str = "Added Failed.";
            }
            InitCarModelData();
            ShowModelNameList();
        }

        private void btnDelCarModel_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "" || txbPLCIdx.Text == "") return;
            //if (CheckSpecialChar(txbName.Text))
            //{
            //    MessageBox.Show("No Write Special Characters: " + expStr);
            //    return;
            //}

            if (MessageBox.Show("Delete this model? -> " + txbName.Text, "Check", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool isBackup = false;
                if (MessageBox.Show("Backup this model? -> " + txbName.Text, "Check", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isBackup = true;
                }

                if (!Manager.DelCar(txbName.Text, Int32.Parse(txbPLCIdx.Text), isBackup))
                {
                    string str = "Del Failed.";
                }
                InitCarModelData();
                ShowModelNameList();
            }
        }

        private void btnModCarModel_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "" || txbPLCIdx.Text == "") return;
            //if (CheckSpecialChar(txbName.Text))
            //{
            //    MessageBox.Show("No Write Special Characters: " + expStr);
            //    return;
            //}

            int iRow = dgvCarModel.SelectedRows[0].Index;
            if (iRow == -1)
                return;

            string oldName = dgvCarModel[0, iRow].Value.ToString();
            string oldIndex = dgvCarModel[1, iRow].Value.ToString();

            if (!Manager.ModifyCar(oldName, txbName.Text, Int32.Parse(txbPLCIdx.Text)))
            {
                string str = "MOdify Failed.";
            }
            InitCarModelData();
            ShowModelNameList();
        }


        private void btnAddCarEngineType_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "" || txbPLCIdx.Text == "") return;
            //if (CheckSpecialChar(txbName.Text))
            //{
            //    MessageBox.Show("No Write Special Characters: " + expStr);
            //    return;
            //}

            int iModelRow = dgvCarModel.SelectedRows[0].Index;
            if (iModelRow == -1)
                return;
            string modelName = dgvCarModel[0, iModelRow].Value.ToString();

            if (txbName.Text == "") return;

            if (!Manager.AddCarEngine(modelName, txbName.Text, Int32.Parse(txbPLCIdx.Text)))
            {
                string str = "Added Failed.";
            }

            InitCarModelData();
            ShowModelNameList();
        }

        private void btnDelCarEngineType_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "" || txbPLCIdx.Text == "") return;
            //if (CheckSpecialChar(txbName.Text))
            //{
            //    MessageBox.Show("No Write Special Characters: " + expStr);
            //    return;
            //}

            int iModelRow = dgvCarModel.SelectedRows[0].Index;
            if (iModelRow == -1)
                return;
            string modelName = dgvCarModel[0, iModelRow].Value.ToString();

            if (txbName.Text == "") return;
            if (MessageBox.Show("Delete this engine? -> " + txbName.Text, "Check", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool isBackup = false;
                if (MessageBox.Show("Backup this model? -> " + txbName.Text, "Check", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isBackup = true;
                }
                if (!Manager.DelCar(modelName, txbName.Text, isBackup))
                {
                    string str = "Del Failed.";
                }
            }

            InitCarModelData();
            ShowModelNameList();
        }

        private void btnModCarEngineType_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "" || txbPLCIdx.Text == "") return;
            //if (CheckSpecialChar(txbName.Text))
            //{
            //    MessageBox.Show("No Write Special Characters: " + expStr);
            //    return;
            //}

            int iModelRow = dgvCarModel.SelectedRows[0].Index;
            if (iModelRow == -1)
                return;

            int iOptRow = dgvCarEngineType.SelectedRows[0].Index;
            if (iOptRow == -1)
                return;

            if (txbName.Text == "") return;

            string modelName = dgvCarModel[0, iModelRow].Value.ToString();
            string optName = dgvCarEngineType[0, iOptRow].Value.ToString();

            if (txbName.Text == "") return;

            if (!Manager.ModifyCar(modelName, optName, txbName.Text, Int32.Parse(txbPLCIdx.Text)))
            {
                string str = "modify Failed.";
            }

            InitCarModelData();
            ShowModelNameList();
        }

        private void UpdateCurRowIdx()
        {
            int iModelRow = dgvCarModel.SelectedRows[0].Index;
            if (iModelRow != -1)
                CurModelSelRowIdx = iModelRow;

            if (dgvCarEngineType.SelectedRows.Count == 0) return;

            int iEngRow = dgvCarEngineType.SelectedRows[0].Index;
            if (iEngRow != -1)
                CurEngSelRowIdx = iEngRow;

            if (dgvCarUseOpts.SelectedRows.Count == 0) return;

            int iUseOptRow = dgvCarUseOpts.SelectedRows[0].Index;
            if (iUseOptRow != -1)
                CurSelectedOptListSelRowIdx = iUseOptRow;
        }

        private void dgvCarModel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int iRow = e.RowIndex;
            //if (iRow == -1)
            //    return;
            int iModelRow = dgvCarModel.SelectedRows[0].Index;
            if (iModelRow == -1)
                return;

            UpdateCurRowIdx();

            string carModel = dgvCarModel[0, iModelRow].Value.ToString();
            List<Car> cars = Manager.GetCarListByModel(carModel);

            InitCarEngineData(cars);

            int iRow = dgvCarEngineType.SelectedRows[0].Index;
            if (iRow == -1)
                return;
            string engName = dgvCarEngineType[0, iRow].Value.ToString();

            Car car = Manager.GetCar(carModel, engName);
            InitCarOptData(car);

            txbName.Text = dgvCarModel[0, iModelRow].Value.ToString();
            txbPLCIdx.Text = dgvCarModel[1, iModelRow].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Manager.SaveDB();
            Manager.LoadDB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        string expStr = @"[~!@\#$%^&*\()\=+|\\/:;?""<>']";
        private bool CheckSpecialChar(string str)
        {
            Regex rex = new System.Text.RegularExpressions.Regex(str);

            return rex.IsMatch(str);
        }

        private void dgvCarEngineType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iModelRow = dgvCarModel.SelectedRows[0].Index;
                if (iModelRow == -1)
                    return;

                int iEngRow = dgvCarEngineType.SelectedRows[0].Index;
                if (iEngRow == -1)
                    return;

                UpdateCurRowIdx();

                string carModel = dgvCarModel[(int)eHeaderColumn.Name, iModelRow].Value.ToString();
                string engName = dgvCarEngineType[(int)eHeaderColumn.Name, iEngRow].Value.ToString();

                Car car = Manager.GetCar(carModel, engName);
                InitCarOptData(car);

                //string carModel = dgvCarModel[0, iRow].Value.ToString();
                //List<Car> cars = Manager.GetCarModelList(carModel);

                //InitCarEngineData(cars);
                //InitCarOptData(cars);

                txbName.Text = dgvCarEngineType[(int)eHeaderColumn.Name, iEngRow].Value.ToString();
                txbPLCIdx.Text = dgvCarEngineType[(int)eHeaderColumn.PLC_MAP_Index, iEngRow].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnOpenRecipeFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CarManager.PARAM_PATH);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] modelNames = Manager.GetCarModelNameList();
            string[] engineNames = Manager.GetCarEngineNameList();
            string[] optNames = Manager.GetCarOptionNameList();
        }

        private void btnAddCarOption_Click(object sender, EventArgs e)
        {
            if (txbName.Text == "" || txbPLCIdx.Text == "") return;

            if (!Manager.AddOption2DB(txbName.Text, Int32.Parse(txbPLCIdx.Text)))
            {
                string str = "Option Added Failed.";
                MessageBox.Show(str);
            }

            ShowOptionTypeList();
        }

        public void ShowOptionTypeList()
        {
            try
            {
                dgvCarOptTypes.Rows.Clear();
                if (Manager.OptionDB.Count == 0)
                {
                    sOptionType opt = new sOptionType(SelectedOptions.NoneType.Name, SelectedOptions.NoneType.plcIBitIdx);

                    dgvCarOptTypes.Rows.Add();
                    dgvCarOptTypes[(int)eHeaderColumn.Name, dgvCarOptTypes.Rows.Count - 1].Value = opt.Name;
                    dgvCarOptTypes[(int)eHeaderColumn.PLC_MAP_Index, dgvCarOptTypes.Rows.Count - 1].Value = opt.plcIBitIdx;

                    Manager.OptionDB.Add(opt);
                }
                else
                {
                    for (int i = 0; i < Manager.OptionDB.Count; i++)
                    {
                        sOptionType opt = Manager.OptionDB[i];
                        dgvCarOptTypes.Rows.Add();
                        dgvCarOptTypes[(int)eHeaderColumn.Name, dgvCarOptTypes.Rows.Count - 1].Value = opt.Name;
                        dgvCarOptTypes[(int)eHeaderColumn.PLC_MAP_Index, dgvCarOptTypes.Rows.Count - 1].Value = opt.plcIBitIdx;
                    }
                }


                if (dgvCarOptTypes.Rows.Count <= CurOptListSelRowIdx)
                    CurOptListSelRowIdx = dgvCarOptTypes.Rows.Count - 1;

                if (CurOptListSelRowIdx == -1) return;

                dgvCarOptTypes.Sort(dgvCarOptTypes.Columns[(int)eHeaderColumn.PLC_MAP_Index], ListSortDirection.Ascending);
                dgvCarOptTypes.Rows[CurOptListSelRowIdx].Selected = true;
            }
            catch (Exception)
            {
            }
        }

        private void btnDelCarOption_Click(object sender, EventArgs e)
        {

        }

        private void btnAddModOption_Click(object sender, EventArgs e)
        {

        }

        private void btnMovOptList2UseOpts_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Did you change want all thins?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                dgvCarUseOpts.Rows.Clear();
                foreach (DataGridViewRow row in dgvCarOptTypes.SelectedRows)
                {
                    string name = row.Cells[eHeaderColumn.Name.ToString()].Value.ToString();
                    string plcIdx = row.Cells[eHeaderColumn.PLC_MAP_Index.ToString()].Value.ToString();

                    sOptionType opt = new sOptionType(name, Int32.Parse(plcIdx));
                    //string[] dataRows = new string[(int)eHeaderColumn.Count];
                    //dataRows[(int)eHeaderColumn.Name] = opt.Name;
                    //dataRows[(int)eHeaderColumn.PLC_MAP_Index] = opt.plcIBitIdx;

                    //dgvCarUseOpts.Rows.Add(dataRows);

                    dgvCarUseOpts.Rows.Add();
                    dgvCarUseOpts[(int)eHeaderColumn.Name, dgvCarUseOpts.Rows.Count - 1].Value = opt.Name;
                    dgvCarUseOpts[(int)eHeaderColumn.PLC_MAP_Index, dgvCarUseOpts.Rows.Count - 1].Value = opt.plcIBitIdx;
                }
                dgvCarUseOpts.Sort(dgvCarUseOpts.Columns[(int)eHeaderColumn.PLC_MAP_Index], ListSortDirection.Ascending);
            }
            catch (Exception)
            {
            }
        }

        private void btnDelOptionDBList_Click(object sender, EventArgs e)
        {
            try
            {
                int iOptListRow = dgvCarOptTypes.SelectedRows[0].Index;
                if (iOptListRow == -1)
                    return;

                string optName = dgvCarOptTypes[(int)eHeaderColumn.Name, iOptListRow].Value.ToString();
                string plcBitIdx = dgvCarOptTypes[(int)eHeaderColumn.PLC_MAP_Index, iOptListRow].Value.ToString();

                if (!Manager.DelOption2DB(optName, Int32.Parse(plcBitIdx)))
                {
                    string str = "Option Delete Failed.";
                    MessageBox.Show(str);
                }

                ShowOptionTypeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured. select one and delete. Error: " + ex.ToString());
            }

        }

        private void btnModOptionDBList_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbName.Text == "" || txbPLCIdx.Text == "") return;

                int iOptListRow = dgvCarOptTypes.SelectedRows[0].Index;
                if (iOptListRow == -1)
                    return;

                string optName = dgvCarOptTypes[(int)eHeaderColumn.Name, iOptListRow].Value.ToString();

                if (!Manager.ModOption2DB(optName, txbName.Text, Int32.Parse(txbPLCIdx.Text)))
                {
                    string str = "Option Modify Failed.";
                    MessageBox.Show(str);
                }

                ShowOptionTypeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured. select one and modify. Error: " + ex.ToString());
            }

        }

        private void dgvCarOptTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iOptRow = dgvCarOptTypes.SelectedRows[0].Index;
            if (iOptRow == -1)
                return;

            txbName.Text = dgvCarOptTypes[(int)eHeaderColumn.Name, iOptRow].Value.ToString();
            txbPLCIdx.Text = dgvCarOptTypes[(int)eHeaderColumn.PLC_MAP_Index, iOptRow].Value.ToString();
        }

        private void btnUpdateSelOpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarUseOpts.Rows.Count == 0) return;

                int iModelRow = dgvCarModel.SelectedRows[0].Index;
                if (iModelRow == -1)
                    return;
                string modelName = dgvCarModel[(int)eHeaderColumn.Name, iModelRow].Value.ToString();

                int iEngRow = dgvCarEngineType.SelectedRows[0].Index;
                if (iEngRow == -1)
                    return;
                string engineName = dgvCarEngineType[(int)eHeaderColumn.Name, iEngRow].Value.ToString();

                SelectedOptions selectedOpts = new SelectedOptions();
                foreach (DataGridViewRow row in dgvCarUseOpts.Rows)
                {
                    string name = row.Cells[(int)eHeaderColumn.Name].Value.ToString();
                    string plcIdx = row.Cells[(int)eHeaderColumn.PLC_MAP_Index].Value.ToString();

                    selectedOpts.SelectedOptTypes.Add(new sOptionType(name, Int32.Parse(plcIdx)));
                }

                selectedOpts.SelectedOptTypes.Sort(new Comparison<sOptionType>((n1, n2) => n1.plcIBitIdx.CompareTo(n2.plcIBitIdx)));

                Manager.AddOptions(modelName, engineName, selectedOpts);
                ShowModelNameList();
            }
            catch (Exception ex)
            {
            }
        }

        public void AddSeletedOption2CarModel()
        {

        }

        private bool IsExist(DataGridView datagrid, string name, string plcIdx)
        {
            bool r = false;

            foreach (DataGridViewRow row in dgvCarUseOpts.Rows)
            {
                if(row.Cells[(int)eHeaderColumn.Name].Value.ToString() == name)
                {
                    if (row.Cells[(int)eHeaderColumn.PLC_MAP_Index].Value.ToString() == plcIdx)
                    {
                        r = true;
                        break;
                    }
                }
            }

            return r;
        }

        private void btnMovOptList2SingleUseOpt_Click(object sender, EventArgs e)
        {

            int iSingleRow = dgvCarOptTypes.SelectedRows[0].Index;
            if (iSingleRow == -1) return;

            string name = dgvCarOptTypes[eHeaderColumn.Name.ToString(), iSingleRow].Value.ToString();
            string plcIdx = dgvCarOptTypes[eHeaderColumn.PLC_MAP_Index.ToString(), iSingleRow].Value.ToString();
            if (!IsExist(dgvCarUseOpts, name, plcIdx))
            {
                sOptionType opt = new sOptionType(name, Int32.Parse(plcIdx));
                //string[] dataRows = new string[(int)eHeaderColumn.Count];
                //dataRows[(int)eHeaderColumn.Name] = opt.Name;
                //dataRows[(int)eHeaderColumn.PLC_MAP_Index] = opt.plcIBitIdx.ToString();

                //dgvCarUseOpts.Rows.Add(dataRows);
                dgvCarUseOpts.Rows.Add();
                dgvCarUseOpts[(int)eHeaderColumn.Name, dgvCarUseOpts.Rows.Count - 1].Value = opt.Name;
                dgvCarUseOpts[(int)eHeaderColumn.PLC_MAP_Index, dgvCarUseOpts.Rows.Count - 1].Value = opt.plcIBitIdx;

                dgvCarUseOpts.Sort(dgvCarUseOpts.Columns[(int)eHeaderColumn.PLC_MAP_Index], ListSortDirection.Ascending);
            }
            else
            {
                MessageBox.Show($"Exist That Options.  Name:{name}, PLC index:{plcIdx}");
            }
        }

        private void btnSetNoneType_Click(object sender, EventArgs e)
        {
            txbName.Text = SelectedOptions.NoneType.Name;
            txbPLCIdx.Text = SelectedOptions.NoneType.plcIBitIdx.ToString();
        }

        private void dgvCarUseOpts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = dgvCarUseOpts.SelectedRows[0].Index;
            if (iRow == -1)
                return;

            txbName.Text = dgvCarUseOpts[(int)eHeaderColumn.Name, iRow].Value.ToString();
            txbPLCIdx.Text = dgvCarUseOpts[(int)eHeaderColumn.Name, iRow].Value.ToString();
        }
    }
}
