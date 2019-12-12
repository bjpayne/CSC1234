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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'media.media_types' table. You can move, or remove it, as needed.
            this.media_typesTableAdapter.Fill(this.media.media_types);
            // TODO: This line of code loads data into the 'media.media_types' table. You can move, or remove it, as needed.
            this.media_typesTableAdapter.Fill(this.media.media_types);
            this.mediaTableAdapter.Fill(this.media._media);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.mediaTableAdapter.FillBy(this.media._media);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.media_typesTableAdapter.FillBy(this.media.media_types);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.media_typesTableAdapter.FillBy1(this.media.media_types);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
