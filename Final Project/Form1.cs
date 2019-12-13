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
        private String databasePath = "C:\\Projects\\CSCI234 Final\\Final Project\\data.mdb";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.media_typesTableAdapter.Fill(this.dataDataSet.media_types);
            this.existing_mediaTableAdapter.Fill(this.dataDataSet.existing_media);
        }

        private void estToolStripReload_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.Refresh();

            dataGridView1.DataSource = dataDataSet.existing_media;

            this.existing_mediaTableAdapter.Fill(this.dataDataSet.existing_media);
        }

        private void estToolStripExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void estToolStripAbout_Click(object sender, EventArgs e)
        {
            String message = "Add a new item by entering in the information and clicking " +
                "'submit' or edit an existing element using the table\n\nWritten by Ben Payne";

            MessageBox.Show(message);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Model model = new Model(databasePath);

            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            IOrganize media = model.GetMedia(id);

            mediaId.Text = id;
            type.SelectedIndex = type.FindStringExact(media.TypeId);
            title.Text = media.Title;
            description.Text = media.Description;
            genre.Text = media.Genre;
            length.Text = media.Length;
            artist.Text = media.Artists;
            cost.Text = media.Cost;
            dateReleased.Text = media.DateReleased;
            publisher.Text = media.Publisher;
            location.Text = media.Location;
            format.Text = media.Format;
            size.Text = media.Size;
        }

        private void submit_Click(object sender, EventArgs eventArgs)
        {
            if (mediaId.TextLength > 0)
            {
                UpdateMedia();

                return;
            }

            DataRowView dataRowView = type.SelectedItem as DataRowView;

            String mediaType = string.Empty;

            if (dataRowView != null)
            {
                mediaType = dataRowView.Row["type"].ToString();
            }

            IOrganize media = null;

            switch (mediaType)
            {
                case "Game":
                    media = new Game();
                    break;
                case "Movie":
                    media = new Movie();
                    break;
                case "Music":
                    media = new Music();
                    break;
                default:
                    MessageBox.Show("Invalid media type selected.");
                    break;
            }

            Model model = new Model(databasePath);

            if (media != null)
            {
                try
                {
                    media.TypeId = dataRowView.Row["id"].ToString();
                    media.Title = title.Text;
                    media.Description = description.Text;
                    media.Genre = genre.Text;
                    media.Length = length.Text;
                    media.Artists = artist.Text;
                    media.Cost = cost.Text;
                    media.DateReleased = dateReleased.Text;
                    media.Publisher = publisher.Text;
                    media.Location = location.Text;
                    media.Format = format.Text;
                    media.Size = size.Text;

                    model.InsertMedia(media);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.existing_mediaTableAdapter.FillBy(this.dataDataSet.existing_media);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void UpdateMedia()
        {

            Model model = new Model(databasePath);

            IOrganize media = model.GetMedia(mediaId.Text);

            DataRowView dataRowView = type.SelectedItem as DataRowView;

            try
            {
                media.TypeId = dataRowView.Row["id"].ToString();
                media.Title = title.Text;
                media.Description = description.Text;
                media.Genre = genre.Text;
                media.Length = length.Text;
                media.Artists = artist.Text;
                media.Cost = cost.Text;
                media.DateReleased = dateReleased.Text;
                media.Publisher = publisher.Text;
                media.Location = location.Text;
                media.Format = format.Text;
                media.Size = size.Text;

                model.UdpateMedia(media, mediaId.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mediaId.Text = "";
            type.SelectedIndex = 0;
            title.Text = "";
            description.Text = "";
            genre.Text = "";
            length.Text = "";
            artist.Text = "";
            cost.Text = "";
            dateReleased.Text = "";
            publisher.Text = "";
            location.Text = "";
            format.Text = "";
            size.Text = "";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mediaId.TextLength == 0)
            {
                return;
            }

            Model model = new Model(databasePath);

            model.DeleteMedia(mediaId.Text);

            newToolStripMenuItem_Click(sender, e);
        }
    }
}
