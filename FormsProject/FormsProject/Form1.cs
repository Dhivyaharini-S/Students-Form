using System;
using System.IO;
using System.Windows.Forms;

namespace FormsProject
{
    public partial class Form1 : Form
    {
        string photoPath = "";
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            comboBox1.Items.Add("Fresher");
            comboBox1.Items.Add("1-2 Years");
            comboBox1.Items.Add("2-5 Years");
            comboBox1.Items.Add("5+ Years");
        }

        // Browse button
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                photoPath = ofd.FileName;
                pictureBox1.ImageLocation = photoPath;
            }
        }

        // Submit button
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string dob = dateTimePicker1.Text;
            string gender = "";
            string maritalStatus = "";
            string qualification = "";
            string experience = comboBox1.Text;
            string aboutProject = richTextBox1.Text;

            // Gender
            if (radioButton1.Checked)
                gender = radioButton1.Text;
            else if (radioButton2.Checked)
                gender = radioButton2.Text;

            // Marital Status
            if (radioButton3.Checked)
                maritalStatus = radioButton3.Text;
            else if (radioButton4.Checked)
                maritalStatus = radioButton4.Text;

            // Qualification
            if (checkBox1.Checked)
                qualification += checkBox1.Text + " ";
            if (checkBox2.Checked)
                qualification += checkBox2.Text + " ";
            if (checkBox3.Checked)
                qualification += checkBox3.Text + " ";

            // Show all entered details
            string details =
                "Photo Path: " + photoPath + "\n" +
                "Name: " + name + "\n" +
                "Date of Birth: " + dob + "\n" +
                "Gender: " + gender + "\n" +
                "Marital Status: " + maritalStatus + "\n" +
                "Qualification: " + qualification + "\n" +
                "Experience: " + experience + "\n" +
                "About Project: " + aboutProject;

            MessageBox.Show(details, "Entered Details");

            // Save details in text file
            string fileData =
                "---------------------------\n" +
                "Photo Path: " + photoPath + "\n" +
                "Name: " + name + "\n" +
                "Date of Birth: " + dob + "\n" +
                "Gender: " + gender + "\n" +
                "Marital Status: " + maritalStatus + "\n" +
                "Qualification: " + qualification + "\n" +
                "Experience: " + experience + "\n" +
                "About Project: " + aboutProject + "\n";

            File.AppendAllText("FormDetails.txt", fileData);

            MessageBox.Show("Details submitted successfully!");
        }

       
       
    }
}
