using System;
using System.Windows.Forms;

namespace WorkoutTracker.View
{
    public partial class MainWindow : Form
    {
        private Controller _controller;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new Controller(this);
        }

        private void buttonSaveNumericData_Click(object sender, EventArgs e)
        {
            _controller.SaveDataToFile();
            
        }

        private void buttonLoadData_Click(object sender, EventArgs e)
        {
            _controller.LoadDataFromFile();
        }

        private void dataGridView_CellClicked(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dataGridView.NewRowIndex)
            {
                _controller.AddNewRowInline(e);
            } 
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (row.Selected) dataGridView.Rows.Remove(row);
            }
        }

        private void buttonManageCategories_Click(object sender, EventArgs e)
        {
            _controller.ShowCategoriesEditWindow();
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = dataGridView.SelectedRows.Contains(dataGridView.CurrentRow) && !dataGridView.SelectedRows.Contains(dataGridView.Rows[dataGridView.NewRowIndex]);
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _controller.UpdateDatesFromDataTable();
        }

        public void UpdateCategoriesReference(object categories)
        {
            _controller.DoUpdateReferenes(categories);
        }
    }
}
