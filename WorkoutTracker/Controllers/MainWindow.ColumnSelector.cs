using System.Drawing;
using System.Windows.Forms;

namespace WorkoutTracker.View
{
    public partial class MainWindow
    {
        internal class DataGridViewColumnSelector
        {
            private DataGridView _dataGridView;

            private readonly CheckedListBox _checkedListBox;

            private readonly ToolStripDropDown _popup;

            private readonly string _dateColumnName;

            public int MaxHeight = 500;
            public int Width = 100;

            public DataGridView DataGridView
            {
                get { return _dataGridView; }
                set
                {
                    if (_dataGridView != null) _dataGridView.CellMouseClick -= new DataGridViewCellMouseEventHandler(_dataGridView_CellMouseClick);
                    _dataGridView = value;
                    if (_dataGridView != null) _dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(_dataGridView_CellMouseClick);
                }
            }

            void _dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right && e.RowIndex == -1 && e.ColumnIndex == -1)
                {
                    _checkedListBox.Items.Clear();
                    foreach (DataGridViewColumn c in _dataGridView.Columns)
                    {
                        if (c.Name.Equals(_dateColumnName))
                            _checkedListBox.Items.Add("", CheckState.Indeterminate);
                        else _checkedListBox.Items.Add(c.HeaderText, c.Visible);
                    }
                    int PreferredHeight = (_checkedListBox.Items.Count * 16) + 7;
                    _checkedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                    _checkedListBox.Width = this.Width;
                    _popup.Show(_dataGridView.PointToScreen(new Point(e.X, e.Y)));
                }
            }

            public DataGridViewColumnSelector(string dateColumnName)
            {
                _checkedListBox = new CheckedListBox();
                _checkedListBox.CheckOnClick = true;
                _checkedListBox.ItemCheck += new ItemCheckEventHandler(_checkedListBox_ItemCheck);

                ToolStripControlHost controlHost = new ToolStripControlHost(_checkedListBox);
                controlHost.Padding = Padding.Empty;
                controlHost.Margin = Padding.Empty;
                controlHost.AutoSize = false;

                _popup = new ToolStripDropDown();
                _popup.Padding = Padding.Empty;
                _popup.Items.Add(controlHost);
                _dateColumnName = dateColumnName;
            }

            public DataGridViewColumnSelector(string dateColumnName, DataGridView dataGridView) : this(dateColumnName)
            {
                this.DataGridView = dataGridView;
            }

            void _checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                if (!_dataGridView.Columns[e.Index].Name.Equals(_dateColumnName))
                    _dataGridView.Columns[e.Index].Visible = (e.NewValue == CheckState.Checked);
            }
        }
    }
}
