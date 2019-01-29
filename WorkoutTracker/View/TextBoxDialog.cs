using System;
using System.Windows.Forms;

namespace WorkoutTracker.View
{
    public partial class TextBoxDialog : Form
    {
        public TextBoxDialog(bool orderEditsEnabled, int? id = null, string name = null)
        {
            InitializeComponent();
            textBox.Text = name;
            numericId.Value = orderEditsEnabled ? (decimal)id : 1;
            if (!orderEditsEnabled)
            {
                groupBoxId.Visible = false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
