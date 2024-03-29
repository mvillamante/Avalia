﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT114L_MachineProblem {
    public partial class NewMovie : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] genres = { "Action", "Adventure", "Comedy", "Drama", "Family", "Fantasy", "History", "Horror", "Mystery", "Romance", "Sci-Fi", "Sport", "Thriller" };
                foreach (string genre in genres)
                {
                    ListItem item = new ListItem(genre, genre);
                    cblGenres.Items.Add(item);
                }

                cblGenres.RepeatColumns = 3;

                foreach (ListItem listItem in cblGenres.Items)
                {
                    listItem.Attributes["style"] = "margin-right: 10px";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {

            string title = TextBox1.Text;
            string description = TextBox2.Text;
            string date = TextBox3.Text;
            string duration = TextBox4.Text;
            string price = TextBox5.Text;

            List<string> selectedGenres = new List<string>();
            foreach (ListItem item in cblGenres.Items) {
                if (item.Selected) {
                    selectedGenres.Add(item.Value);
                }
            }
            string genre = string.Join(",", selectedGenres);

            string imgPath = null;
            if (FileUpload1.HasFile) {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                string filePath = Server.MapPath("~/Uploads/") + fileName;
                FileUpload1.SaveAs(filePath);
                imgPath = "/Uploads/" + fileName;
            }



            var connString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""{HostingEnvironment.MapPath("/")}App_Data\AvaliaDB.mdf"";Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString)) {
                conn.Open();


                string insertMovie = "INSERT INTO Movie (title, description, genre, imagePath, price) VALUES (@Title, @Description, @Genre, @ImagePath, @Price); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(insertMovie, conn)) {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@ImagePath", imgPath);
                    cmd.Parameters.AddWithValue("@Price", double.Parse(price));

                    int movieID = Convert.ToInt32(cmd.ExecuteScalar());

                    string insertSchedule = "INSERT INTO SCHEDULE (scheduleTime, duration, movieID, CinemaRoom) VALUES (@ScheduleTime, @Duration, @MovieID, 1)";
                    using (SqlCommand cmdSchedule = new SqlCommand(insertSchedule, conn)) {
                        cmdSchedule.Parameters.AddWithValue("@ScheduleTime", date);
                        cmdSchedule.Parameters.AddWithValue("@Duration", duration);
                        cmdSchedule.Parameters.AddWithValue("@MovieID", movieID);

                        cmdSchedule.ExecuteNonQuery();
                    }
                    
                }
            }
        }
    }
}