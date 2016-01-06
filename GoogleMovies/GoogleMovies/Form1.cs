using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace GoogleMovies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //var movie = txtTitle.Text;
                //SearchClient search = new SearchClient();
                //var movieOutput = search.getFirstMovie(movie).Items.FirstOrDefault();
                //var a = movieOutput.Title.Replace(" - Wikipedia, the free encyclopedia", null);
                //txtTitle2.Text = a.Replace(" - IMDb", null);
                //txtIMDB.Text = movieOutput.FormattedUrl;
                //txtSynopsis.Text = movieOutput.Snippet;

                var movie = txtTitle.Text;
                SearchClient search = new SearchClient();
                search.searchTMDb(movie);

                txtOriginalTitle.Text = search.originalTitle;
                txtSynopsis.Text = search.overview;
                txtTitle2.Text = search.mTitle;
                txtYearReleased.Text = search.releaseDate.Value.Year.ToString();


            }
            catch (Exception er)
            {
                Console.WriteLine("Searching movie error: " + er.ToString());
                MessageBox.Show("Movie not found.", "Error");
            }
            
        }
    }
}
