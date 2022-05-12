using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView2.Visible = false;
            labelAverageAge.Visible = false;
            textBoxAverageAge.Visible = false;
        }
        private int id = 0;


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxID.Text) || string.IsNullOrEmpty(textBoxAuthor.Text) || string.IsNullOrEmpty(textBoxBookName.Text) || string.IsNullOrEmpty(dateTimeDATEofISSUE.Text) || string.IsNullOrEmpty(textBoxEdit.Text) || string.IsNullOrEmpty(textBoxYearPUBL.Text) || string.IsNullOrEmpty(textBoxRETURN.Text))
            {
                buttonAdd.Visible = false;
                return;
            }
            ListViewItem item = new ListViewItem((++id).ToString());
            item.SubItems.Add(textBoxID.Text);
            item.SubItems.Add(textBoxAuthor.Text);
            item.SubItems.Add(dateTimeDATEofISSUE.Text);
            item.SubItems.Add(textBoxBookName.Text);
            item.SubItems.Add(textBoxEdit.Text);
            item.SubItems.Add(textBoxYearPUBL.Text);
            item.SubItems.Add(textBoxRETURN.Text);
            item.SubItems.Add(textBoxFlat.Text);
            listView1.Items.Add(item);
            button2.Visible = true;
            button2.PerformClick();
            button3.PerformClick();
            listView1.Show();
            //textBoxName.Clear();
            //numericUpDownAmount.Clear();
            //numericUpDownWeight.Clear();
            //textBoxFlightNumber.Clear();
            //this.dateTimePicker1.Value = System.DateTime.Now;
            //textBoxFtime.Clear();
            //textBoxDestination.Clear();
            //buttonAdd.Visible = false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count >0){
                try{
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    buttonRemove.Visible = false;
                    buttonEdit.Visible = false;
                }
                catch
                {

                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Visible = true;
            buttonEdit.Visible = true;

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ListView listView;
            if (listView1.Visible)
            {
                listView = listView1;
            }
            else
            {
                listView = listView2;
            }
            if (listView.SelectedItems.Count==0)
            {
                return;
            }
            textBoxID.Text = listView.SelectedItems[0].SubItems[1].Text;
            textBoxAuthor.Text = listView.SelectedItems[0].SubItems[2].Text;
            dateTimeDATEofISSUE.Text = listView.SelectedItems[0].SubItems[3].Text;
            textBoxBookName.Text = listView.SelectedItems[0].SubItems[4].Text;
            textBoxEdit.Text = listView.SelectedItems[0].SubItems[5].Text;
            textBoxYearPUBL.Text = listView.SelectedItems[0].SubItems[6].Text;
            textBoxRETURN.Text = listView.SelectedItems[0].SubItems[7].Text;
            textBoxFlat.Text = listView.SelectedItems[0].SubItems[8].Text;
            buttonAdd.Visible = false;
            button1.Visible = true;
            buttonRemove.Visible = false;
            buttonEdit.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            listView1.SelectedItems[0].SubItems[1].Text= textBoxID.Text;
            listView1.SelectedItems[0].SubItems[2].Text = textBoxAuthor.Text;
            listView1.SelectedItems[0].SubItems[3].Text= this.dateTimeDATEofISSUE.Text;
            listView1.SelectedItems[0].SubItems[4].Text= textBoxBookName.Text;
            listView1.SelectedItems[0].SubItems[5].Text= textBoxEdit.Text;
            listView1.SelectedItems[0].SubItems[6].Text= textBoxYearPUBL.Text;
            listView1.SelectedItems[0].SubItems[7].Text= textBoxRETURN.Text;
            listView1.SelectedItems[0].SubItems[8].Text = textBoxFlat.Text;
            button2.Visible = true;
            button2.PerformClick();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxID.Clear();
            //textBoxName.Text = listView1.;
            textBoxAuthor.Clear();
            textBoxBookName.Clear();
            this.dateTimeDATEofISSUE.Value = System.DateTime.Now;
            
            textBoxEdit.Clear();
            textBoxYearPUBL.Clear();
            textBoxRETURN.Clear();
            textBoxFlat.Clear();
            buttonAdd.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrWhiteSpace(textBoxFindDays.Text))
            {
                MessageBox.Show("Enter the values!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            buttonFind.Visible = false;    
            foreach (ListViewItem item in listView1.Items)
            {
                string diff = (DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) - DateTime.Parse(item.SubItems[3].Text)).TotalDays.ToString();
                int diff2 = Convert.ToInt32(diff);
                if ( diff2 - Convert.ToInt32(item.SubItems[7].Text)>Convert.ToInt32(textBoxFindDays.Text)) 
                {
                    ListViewItem item1 = new ListViewItem(item.SubItems[0].Text);
                    item1.SubItems.Add(item.SubItems[1].Text);
                    item1.SubItems.Add(item.SubItems[2].Text);
                    item1.SubItems.Add(item.SubItems[3].Text);
                    item1.SubItems.Add(item.SubItems[4].Text);
                    item1.SubItems.Add(item.SubItems[5].Text);
                    item1.SubItems.Add(item.SubItems[6].Text);
                    item1.SubItems.Add(item.SubItems[7].Text);
                    item.SubItems.Add(item.SubItems[8].Text);

                    listView2.Items.Add(item1); 
                }
            }
            if(listView2.Items.Count == 0)
            {
                MessageBox.Show("No one lives at such an address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonFind.Visible = true;
                return;
            }
            AverageAge(sender, e);
            listView2.Visible = true;
            button3.Visible = true;
        }
        private void AverageAge(object sender, EventArgs e)
        {
            
        }
        private long CalculateAge(DateTime Startdate, DateTime EndDate)
        {
            System.TimeSpan ts = new TimeSpan(Startdate.Ticks - EndDate.Ticks);
            long age = (long)(ts.Days / 365);
            return age;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listView2.Visible = false;
            buttonFind.Visible = true;
            listView1.Visible = true;
            button3.Visible = false;
            labelAverageAge.Visible = false;
            textBoxAverageAge.Visible = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "SaveFileDialog Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            string str;
                            str = item.SubItems[0].Text;
                            str += " ";
                            str += item.SubItems[1].Text;
                            str += " ";
                            str += item.SubItems[2].Text;
                            str += " ";
                            str += item.SubItems[3].Text;
                            str += " ";
                            str += item.SubItems[4].Text;
                            str += " ";
                            str += item.SubItems[5].Text;
                            str += " ";
                            str += item.SubItems[6].Text;
                            str += " ";
                            str += item.SubItems[7].Text;
                            str += " ";
                            str += item.SubItems[8].Text;
                            
                            sw.WriteLine(str);
                            //sw.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}", item.SubItems[0].Text, " ",
                            //    item.SubItems[1].Text, " ",
                            //    item.SubItems[2].Text, " ",
                            //    item.SubItems[3].Text, " ",
                            //    item.SubItems[4].Text, " ",
                            //    item.SubItems[5].Text, " ",
                            //    item.SubItems[6].Text, " ",
                            //    item.SubItems[7].Text, "\n");
                        }
                    }
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

            string filename = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "OpenFileDialog Export2File";
            ofd.Filter = "Text File (.txt) | *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (listView1 != null)
                {
                    listView1.Items.Clear();

                }
                filename = ofd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        string stringlong;
                        while (!string.IsNullOrEmpty(stringlong = sr.ReadLine()))
                        {
                           
                            string[] arrsr = stringlong.Split(' ');
                            ListViewItem item = new ListViewItem(arrsr[0]); 
                            item.SubItems.Add(arrsr[1]);
                            item.SubItems.Add(arrsr[2]);
                            item.SubItems.Add(arrsr[3]);
                            item.SubItems.Add(arrsr[4]);
                            item.SubItems.Add(arrsr[5]);
                            item.SubItems.Add(arrsr[6]);
                            item.SubItems.Add(arrsr[7]);
                            item.SubItems.Add(arrsr[8]);
                            listView1.Items.Add(item);
                        }
                        
                    }
                }
            }

            listView1.Show();
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            buttonAdd.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFindDays_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
