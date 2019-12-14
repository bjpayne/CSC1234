using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

        private String mediaId = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataDataSet.media_images' table. You can move, or remove it, as needed.
            this.media_imagesTableAdapter.Fill(this.dataDataSet.media_images);
            this.media_typesTableAdapter.Fill(dataDataSet.media_types);
            this.existing_mediaTableAdapter.Fill(dataDataSet.existing_media);
        }

        private void FileMenuNewClick(object sender, EventArgs e)
        {
            ClearForm();

            ReloadData();
        }

        private void FileMenuDeleteClick(object sender, EventArgs e)
        {
            if (mediaId.Length == 0)
            {
                return;
            }

            Model model = new Model(databasePath);

            IOrganize media = model.GetMedia(mediaId);

            if (media == null)
            {
                MessageBox.Show("Media not found.");

                return;
            }

            String message = $"Are you sure you want to delete {media.Title}?";

            String caption = "Media Delete";

            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the yes button was pressed ...
            if (result == DialogResult.Yes)
            {
                model.DeleteMedia(mediaId);

                ClearForm();

                ReloadData();

                return;
            }

            // No was pressed
        }

        private void FileMenuReloadClick(object sender, EventArgs eventArgs)
        {
            ClearForm();

            ReloadData();
        }

        private void FileMenuExitClick(object sender, EventArgs e)
        {
            String message = "Are you sure that you would like to exit the program?";

            String caption = "Form Closing";

            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }

            Close();
        }

        private void HelpMenuAboutClick(object sender, EventArgs e)
        {
            String message = "Add a new item by entering in the information and clicking " +
                "'submit' or edit an existing element using the table\n\nWritten by Ben Payne";

            MessageBox.Show(message);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            Model model = new Model(databasePath);

            IOrganize media = model.GetMedia(id);

            mediaId = id;
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

        private void Submit_Click(object sender, EventArgs eventArgs)
        {
            if (mediaId.Length > 0)
            {
                UpdateMedia();
            }
            else
            {
                CreateNewMedia();
            }

            ReloadData();


            ClearForm();
        }

        private void CreateNewMedia()
        {
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

        private void UpdateMedia()
        {
            if (mediaId.Length == 0)
            {
                return;
            }

            Model model = new Model(databasePath);

            IOrganize media = model.GetMedia(mediaId);

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

                model.UdpateMedia(media, mediaId);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ReloadData()
        {
            Model model = null;

            try
            {
                model = new Model(databasePath);
                model.OpenConnection();

                OleDbDataAdapter adapter = model.GetAdapterForDataGridView("SELECT * FROM existing_media");

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet, "existing_media");

                dataGridView1.DataSource = dataSet;
                dataGridView1.DataMember = "existing_media";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (model != null)
                {
                    model.CloseConnection();
                }
            }
        }

        private void ClearForm()
        {
            mediaId = "";
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
    }
}
