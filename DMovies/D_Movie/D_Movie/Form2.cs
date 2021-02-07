using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.OleDb;    // database methods

namespace D_Movie       // 178002002    DIEUVEILLE  BOUSSA ELLENGA 
{
    public partial class Form2 : Form
    {
        public string year, publisher, title, previewed, type;
        public int movieID;

        public Form2()
        { 
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = title;
            textBox2.Text = publisher;
            textBox3.Text = year;
            comboBox1.Text = type;
            if (previewed == "Yes") radioButton1.Checked = true;
            else if (previewed == "No") radioButton2.Checked = true;
        }

        #region Update
        private void button6_Click(object sender, EventArgs e)
        {
            //sql query 
            Form1 f1 = new Form1();
            string typeString;
            title = textBox1.Text.ToString();
            publisher = textBox2.Text.ToString();
            year = textBox3.Text.ToString();
            int yr = 0;
            if (year != "")
            {
                yr = f1.CheckYear(year);
            }
            try
            {
                typeString = comboBox1.SelectedItem.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show("You need to select movie type! \nError: " + ex.Message + "");
                return;
            }
            int type = 0;
            if (radioButton1.Checked == true)
            {
                previewed = "Yes";
            }
            else
            {
                previewed = "No";
            }
            if (yr != 1)
            {
                if (typeString == "Horror") type = 1;
                if (typeString == "Comedy") type = 2;
                if (typeString == "Action") type = 3;
                if (typeString == "Adventure") type = 4;
                if (typeString == "Animated") type = 5;
                if (typeString == "Drama") type = 6;
                if (typeString == "Crime") type = 7;
                if (typeString == "Sci-Fi") type = 8;
                if (typeString == "Fantasy") type = 9;
                if (typeString == "Thriller") type = 10;
                if (typeString == "Documentary") type = 11;
                if (typeString == "Porn") type = 12;
                if (typeString == "Historic") type = 13;
                if (typeString == "Biography") type = 14;
                if (typeString == "Romantic") type = 15;
                string SQLUpdateString;
                if (year == "")
                {
                    SQLUpdateString = "UPDATE movie SET Title ='" + title.Replace("'", "''") + "', MovieYear=NULL, Publisher='" + publisher + "', typeID=" + type + ", Previewed='" + previewed + "' WHERE movieID=" + movieID + "";
                }
                else
                {
                    SQLUpdateString = "UPDATE movie SET Title ='" + title.Replace("'", "''") + "', MovieYear=" + yr + ", Publisher='" + publisher + "', typeID=" + type + ", Previewed='" + previewed + "' WHERE movieID=" + movieID + "";
                }
                OleDbCommand SQLCommand = new OleDbCommand();
                SQLCommand.CommandText = SQLUpdateString;
                SQLCommand.Connection = f1.database;
                int response = SQLCommand.ExecuteNonQuery();
                MessageBox.Show("Update successful!","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else 
            {
                MessageBox.Show("The year format is not correct!\nPlease try to pick a valid year.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Clear();
                textBox3.Focus();
            }
        }
        #endregion

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(null, null);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}