using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Dispose();
        }
    }
}
