using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(sender);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void estToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void mediaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.media_typesTableAdapter.Fill(this.dataDataSet.media_types);
            this.existing_mediaTableAdapter.Fill(this.dataDataSet.existing_media);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
