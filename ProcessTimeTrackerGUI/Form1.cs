using ProcessTimeTracker.Handler;
using System.Data;

namespace ProcessTimeTrackerGUI
{
    public partial class Form1 : Form
    {
        private GuiHandler handler;

        public Form1()
        {
            InitializeComponent();
            handler = new GuiHandler();
            
            //Load all Processes
            dataGridView1.DataSource = handler.GetUntrackedProcesses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Process to tracking list
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView1.Rows.Count)
            {
                // Lesen Sie den Wert der Zelle in der Spalte "Name" der ausgewählten Zeile
                int id = Int32.Parse(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value.ToString());
                handler.TrackProcessByListID(id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Refresh tracking list
            dataGridView2.DataSource = new object();
            dataGridView2.DataSource = handler.GetTrackedProcesses();
        }
    }
}