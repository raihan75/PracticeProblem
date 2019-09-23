using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProblem
{
    public partial class Student : Form
    {
        List<string> ids = new List<string> { };
        List<string> names = new List<string> { };
        List<string> mobiles = new List<string> { };
        List<int> ages = new List<int> { };
        List<string> addresses = new List<string> { };
        List<double> gpas = new List<double> { };

        int age;
        string id,name, mobile, address;
        double gpa;

        double sum = 0.00;
        



        public Student()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(idTextBox.Text) && !String.IsNullOrEmpty(nameTextBox.Text) && !String.IsNullOrEmpty(mobileTextBox.Text))
            {

                if(idTextBox.Text.Length == 4)
                {
                    if (ids.Contains(idTextBox.Text) == true)
                    {
                        MessageBox.Show("This ID has already taken!!!");
                    }
                    else
                    {
                        id = idTextBox.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid ID!!!");
                    return;
                }

                if (nameTextBox.Text.Length <= 30)
                {
                    name = nameTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Name!!!");
                }

                if (mobileTextBox.Text.Length == 11)
                {
                    mobile = mobileTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Invalid ID!!!");
                }

                age = int.Parse(ageTextBox.Text);
                address = addressTextBox.Text;
                

                if(Convert.ToDouble(gpaTextBox.Text) >= 0.00 && Convert.ToDouble(gpaTextBox.Text) <= 4.00)
                {
                    gpa = Convert.ToDouble(gpaTextBox.Text);
                }
                else
                {
                    MessageBox.Show("GPA must be between 0 - 4 !!!!");
                    return;
                }

                
                AddIntoList();
            }
            else
            {
                MessageBox.Show("You have to enter id, name and mobile!!!");
                return;
            }
            ShowOneStudentDetails();
            ClearData();
        }

        private void ShowOneStudentDetails()
        {
            displayRichTextBox.Clear();
            displayRichTextBox.AppendText("\n------------\nID: " + id + "\nName: " + name + "\nMobie: " + mobile + "\nAge: " + age + "\nAdress: " + address +
                "\nGPA Point: " + gpa + "\n\n------------------");
        }

        

        private void AddIntoList()
        {
            ids.Add(id);
            names.Add(name);
            mobiles.Add(mobile);
            ages.Add(age);
            addresses.Add(address);
            gpas.Add(gpa);
        }

        private void ClearData()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            mobileTextBox.Clear();
            ageTextBox.Clear();
            addressTextBox.Clear();
            gpaTextBox.Clear();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            displayRichTextBox.Clear();
            string AllStudent = "";
            for (int i = 0; i < names.Count(); i++)
            {
                AllStudent += "\n------------\nID: " + ids[i] + "\nName: " + names[i] + "\nMobie: " + mobiles[i] + "\nAge: " + ages[i] + "\nAdress: " + addresses[i] +
                "\nGPA Point: " + gpas[i] + "\n\n------------------";

            }
            displayRichTextBox.AppendText(AllStudent);

            maxTextBox.Text = gpas.Max().ToString();
            maxNameTextBox.Text = names[gpas.IndexOf(gpas.Max())];

            minTextBox.Text = gpas.Min().ToString();
            minNameTextBox.Text = names[gpas.IndexOf(gpas.Min())];

            avgTextBox.Text = gpas.Average().ToString();

            sum = gpas.Sum();
            totalGpaTextBox.Text = Convert.ToString(sum);

            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            displayRichTextBox.Clear();
            string SearchResult = "";
            int i = 0;
            if(idRadioButton.Checked == true)
            {
                if (ids.Contains(searchTextBox.Text)== true)
                {
                    i = ids.IndexOf(searchTextBox.Text);
                    SearchResult = "\n------------\nID: " + ids[i] + "\nName: " + names[i] + "\nMobie: " + mobiles[i] + "\nAge: " + ages[i] + "\nAdress: " + addresses[i] +
                                    "\nGPA Point: " + gpas[i] + "\n\n------------------";
                    displayRichTextBox.AppendText(SearchResult);
                }
                else
                {
                    MessageBox.Show("ID does not found!!!");
                }
            }
            else if(nameRadioButton.Checked == true)
            {
                if (names.Contains(searchTextBox.Text) == true)
                {
                    i = names.IndexOf(searchTextBox.Text);
                    SearchResult = "\n------------\nID: " + ids[i] + "\nName: " + names[i] + "\nMobie: " + mobiles[i] + "\nAge: " + ages[i] + "\nAdress: " + addresses[i] +
                                    "\nGPA Point: " + gpas[i] + "\n\n------------------";
                    displayRichTextBox.AppendText(SearchResult);
                }
                else
                {
                    MessageBox.Show("Nmae does not found!!!");
                }
            }

            else if (mobileRadioButton.Checked == true)
            {
                if (mobiles.Contains(searchTextBox.Text) == true)
                {
                    i = mobiles.IndexOf(searchTextBox.Text);
                    SearchResult = "\n------------\nID: " + ids[i] + "\nName: " + names[i] + "\nMobie: " + mobiles[i] + "\nAge: " + ages[i] + "\nAdress: " + addresses[i] +
                                    "\nGPA Point: " + gpas[i] + "\n\n------------------";
                    displayRichTextBox.AppendText(SearchResult);
                }
                else
                {
                    MessageBox.Show("Mobile does not found!!!");
                }
            }
            

        }
    }
}
