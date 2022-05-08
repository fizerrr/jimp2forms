using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace projektforms
{
    public partial class Ptak : Form
    {
        private static List<dvd> data = new List<dvd>();
        private static string filePath = "db.txt";

        private static void load_list()
        {
            FileStream db = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader streamreader = new StreamReader(db);
            while (!streamreader.EndOfStream)
            {
                string title_converter = streamreader.ReadLine();
                string direction_converter = streamreader.ReadLine();
                string type_converter = streamreader.ReadLine();
                string music_converter = streamreader.ReadLine();
                string date_of_production_converter = streamreader.ReadLine();
                string time_converter = streamreader.ReadLine();


                data.Add(new dvd(title_converter, direction_converter, type_converter, music_converter, date_of_production_converter, time_converter));


            }

        }

        private void display()
        {
            data.ForEach(delegate (dvd tmp)
            {
                this.dataGridView1.Rows.Add(
                        tmp.return_title(),
                        tmp.return_direction(),
                        tmp.return_type(),
                        tmp.return_music(),
                        tmp.return_date_of_production(),
                        tmp.return_time()
                    );
            });
        }

        private void search(string title)
        {
            bool Is = true;
            title = title.ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
                string title_row = System.Convert.ToString(row.Cells["Title"].Value);
                title_row = title_row.ToLower();
                if (title_row == title && title_row != "")
                {
                    row.Selected = true;
                    Is = false;
                }
            }
            if(Is) MessageBox.Show("Not found!");
            else MessageBox.Show("Found title is selected!");
        }


        private void save()
        {

            try
            {
                FileStream db = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter streamwriter = new StreamWriter(db);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Title"].Value == null)
                        break;


                    streamwriter.WriteLine(System.Convert.ToString(row.Cells["Title"].Value));

                    streamwriter.WriteLine(System.Convert.ToString(row.Cells["Direction"].Value));

                    streamwriter.WriteLine(System.Convert.ToString(row.Cells["Type"].Value));

                    streamwriter.WriteLine(System.Convert.ToString(row.Cells["Music"].Value));

                    streamwriter.WriteLine(System.Convert.ToString(row.Cells["Date"].Value));

                    streamwriter.WriteLine(System.Convert.ToString(row.Cells["Time"].Value));

                }

                streamwriter.Flush();
                streamwriter.Close();

                MessageBox.Show("Saved !");
            }
            catch (Exception e2)
            {
                MessageBox.Show("Not Saved !");
            }
        }
    
    




        public Ptak()
        {
            InitializeComponent();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            




        }

  

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
            this.dataGridView1.Rows.Clear();
            load_list();
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.Clear();
            this.dataGridView1.Rows.Clear();
            load_list();
            display();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            String word = textBox1.Text;
            search(word);

        }
    }
}
