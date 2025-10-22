using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionSystemOperation.Class;
using VisionSystemOperation.Device;

namespace VisionSystemOperation.Forms
{
    public partial class FormShift : Form
    {
        private Setup setup = Machine.config.setup;
        public FormShift()
        {
            InitializeComponent();

            dtDayShiftStart.Format = DateTimePickerFormat.Time;
            dtDayShiftStart.ShowUpDown = true;
            dtDayShiftStart.Value = DateTime.ParseExact(Machine.config.setup.shiftProperty.DayShiftStart,"HH:mm:ss",System.Globalization.CultureInfo.CurrentCulture);

            dtDayShiftEnd.Format = DateTimePickerFormat.Time;
            dtDayShiftEnd.ShowUpDown = true;
            dtDayShiftEnd.Value = DateTime.ParseExact(Machine.config.setup.shiftProperty.DayShiftEnd, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

            dtNightShiftStart.Format = DateTimePickerFormat.Time;
            dtNightShiftStart.ShowUpDown = true;
            dtNightShiftStart.Value = DateTime.ParseExact(Machine.config.setup.shiftProperty.NightShiftStart, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

            dtNightShiftEnd.Format = DateTimePickerFormat.Time;
            dtNightShiftEnd.ShowUpDown = true;
            dtNightShiftEnd.Value = DateTime.ParseExact(Machine.config.setup.shiftProperty.NightShiftEnd, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ShiftProperty shiftProperty = new ShiftProperty();

                shiftProperty.DayShiftStart = dtDayShiftStart.Value.TimeOfDay.ToString();
                shiftProperty.DayShiftEnd = dtDayShiftEnd.Value.TimeOfDay.ToString();
                shiftProperty.NightShiftStart = dtNightShiftStart.Value.TimeOfDay.ToString();
                shiftProperty.NightShiftEnd = dtNightShiftEnd.Value.TimeOfDay.ToString();
                setup.shiftProperty.SetProperty(shiftProperty);

                Machine.config.SaveConfig();
                Machine.config.LoadConfig();
                MessageBox.Show("Sucess Save config");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed Save config  : " + ex.Message);
                Machine.logger.WriteException(eLogType.ERROR, ex);
            }
        }
    }
}
