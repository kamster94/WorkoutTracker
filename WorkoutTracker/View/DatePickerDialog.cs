using System;
using System.Windows.Forms;

namespace WorkoutTracker.View
{
    public partial class DatePickerDialog : Form
    {
        public DatePickerDialog()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
