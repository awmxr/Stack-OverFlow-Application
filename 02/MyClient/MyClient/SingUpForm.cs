using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClient
{
    public partial class SingUpForm : DevExpress.XtraEditors.XtraForm
    {
        public SingUpForm()
        {
            InitializeComponent();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (UsernameText.Text == "")
            {
                ErrorLabel.Text = "please enter username";
            }
            else if (NameText.Text == "")
            {
                ErrorLabel.Text = "please enter name";
            }
            else if (LastnameText.Text == "")
            {
                ErrorLabel.Text = "please enter lastname";
            }
            else if (EmailText.Text == "")
            {
                ErrorLabel.Text = "please enter email";
            }
            else if (PasswordText.Text == "")
            {
                ErrorLabel.Text = "please enter password";
            }
            else if (PasswordReText.Text == "")
            {
                ErrorLabel.Text = "please enter password repeat";
            }
            else if(tagsList.Count == 0)
            {
                ErrorLabel.Text = "please enter at least 1 thing that you are intrested in";
            }
            else
            {
                if (PasswordText.Text == PasswordReText.Text)
                {
                    string sex = "";
                    if (MaleRadio.Checked)
                    {
                        sex = "male";
                    }
                    else if (FemaleRadio.Checked)
                    {
                        sex = "female";
                    }
                    else
                    {
                        ErrorLabel.Text = "please choose youe sex";
                        ErrorLabel.ForeColor = Color.Red;
                    }

                    if (sex != "")
                    {


                        if (EmailText.Text.ToLower().Contains(".com") == false && EmailText.Text.ToLower().Contains("@") == false)
                        {
                            ErrorLabel.Text = "Incorrect email";
                        }
                        else
                        {
                            var parameters = new Dictionary<string, string>
                                {
                                    { "username", UsernameText.Text },
                                    {"name" , NameText.Text },
                                    {"lastname" ,LastnameText.Text  },
                                    {"email" ,EmailText.Text  },
                                    { "password", Functions.HashString( PasswordText.Text) },
                                    { "sex", sex }
                                };
                            parameters["tagnumbers"] = tagsList.Count.ToString();
                            for (int i = 0; i < tagsList.Count; i++)
                            {
                                parameters["tag" + i.ToString()] = tagsList[i];
                            }
                            string res = PostClass.SignUp(parameters);
                            ErrorLabel.Text = res;



                            // LoginForm f = new LoginForm();
                            // f.Show();
                            // LoginForm.F.Hide();

                            LoginForm F = new LoginForm();
                            this.Hide();
                            F.ShowDialog();
                            this.Close();




                            // Application.Restart();
                            // Environment.Exit(0);

                        }
                    }
                    else
                    {
                        ErrorLabel.Text = "please choose youe sex";
                        ErrorLabel.ForeColor = Color.Red;
                    }



                    //string Username = UsernameText.Text;
                    //string Name = NameText.Text;
                    //string Lastname = LastnameText.Text;
                    //string Email = EmailText.Text;
                    //string Password = PasswordText.Text;


                    //ErrorLabel.ForeColor = Color.Red;
                }
                else
                {
                    ErrorLabel.Text = "password != password repeat";
                    ErrorLabel.ForeColor = Color.Red;

                }
            }
            
            

        }

        private void SingUpForm_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            Dictionary<string, string> tags_id = GetClass.Main_Get_Request(null, "/GetTags");
            tags_id.Remove("number");
            // Dictionary<string, string> tags_id = GetClass.Get_Tags();
            // TagGroup.MaximumSize = TagGroup.Size;
            // TagGroup.AutoSize = true;
            // TagGroup.Dock = DockStyle.Fill;
            foreach (var i in tags_id.Keys)
            {
                collection.Add(i);
                //MessageBox.Show(i);
            }

            // TagGroup.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //collection.Add("python");
            //collection.Add("C#");
            //collection.Add("C++");
            //collection.Add("Java");
            //collection.Add("Django");

            TagText.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TagText.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TagText.MaskBox.AutoCompleteCustomSource = collection;
        }

        private void BTN_TAG_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;

            // QuestionForm f2 = new QuestionForm(label);
            // panel1.Controls.RemoveAt(0);
            // panel1.Controls.Add(f2);
            //
            // panel1.Show();
            //label.Text = "clicked";
            //RibbonForm1.panel1;
            //MessageBox.Show(btn.Name);
            //gc1Control.Controls.Clear();
            // var x = gc1Control.Controls;
            foreach (GroupControl gc2 in TagGroup.Controls.OfType<GroupControl>())
            {
                if (btn.Name == gc2.Name)
                {
                    int z = gc2.Size.Height;
                    int index = tagsList.FindIndex(a => a == gc2.Name);


                    foreach (var gc22 in TagGroup.Controls.OfType<GroupControl>())
                    {
                        int index2 = tagsList.FindIndex(a => a == gc22.Name);
                        if (index <= index2)
                        {
                            Point gc2loc = new Point();
                            gc2loc = gc22.Location;

                            gc2loc.Y -= z;
                            gc22.Location = gc2loc;
                        }

                        // gc22.X -= z;
                    }
                    TagGroup.Controls.Remove(gc2);
                    tagsList.Remove(btn.Name);
                    break;
                }

            }
            TagGroup.Controls.Remove(btn);


        }

        private List<string> tagsList = new List<string>();
        private Dictionary<string, List<string>> tagsList2 = new Dictionary<string, List<string>>();


        private void textEdit1_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Point gc2loc = new Point();
                foreach (GroupControl gc2 in TagGroup.Controls.OfType<GroupControl>())
                {
                    gc2loc.Y += gc2.Size.Height;

                    //gc2loc.X += gc2.Size.Height;


                }

                gc2loc.Y += 15 - labelControl8.Location.Y;


                //labelControl5.Text += textEdit3.Text;
                GroupControl gc2Control = new GroupControl();
                //gc1Control.Location = labelControl5.Location;
                gc2Control.Location = new Point(labelControl8.Location.X, labelControl8.Location.Y + gc2loc.Y);
                // gc2Control.Location = new Point(labelControl8.Location.X, tagsList.Count  * 25 + labelControl8.Location.Y  );
                LabelControl lbl = new LabelControl();
                lbl.Location = new Point(40, 40);
                lbl.Text = TagText.Text;
                lbl.Font = new Font("Arial", 8, FontStyle.Regular);
                labelControl8.Hide();
                SimpleButton btn = new SimpleButton();
                btn.Text = "X";
                int l = 0;
                if (lbl.Text.Length > 2)
                {
                    l = lbl.Text.Length - 2;

                }
                ///////////////////btn.Location = new Point(lbl.Location.X + 20 + l*8, lbl.Location.Y - 25);
                this.Controls.Add(btn);
                btn.Size = new Size(20, 20);
                //gc1Control.Controls.Add(lbl);
                //gc1Control.Controls.Add(btn);
                gc2Control.Controls.Add(lbl);
                gc2Control.Controls.Add(btn);
                gc2Control.ShowCaption = false;
                gc2Control.Name = TagText.Text;
                btn.Name = TagText.Text;
                lbl.Name = TagText.Text;
                tagsList.Add(TagText.Text);

                gc2Control.Size = new Size(lbl.Size.Width + btn.Size.Width + 50, lbl.Size.Height + btn.Size.Height + 5);
                gc2Control.AutoSize = true;
                gc2Control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                //lbl.Location = new Point((gc2Control.Size.Width/2) - (btn.Size.Width), (gc2Control.Size.Height / 2) - (btn.Size.Height/2));
                lbl.Location = new Point(0, (gc2Control.Size.Height / 2) - (btn.Size.Height / 2));
                btn.Location = new Point(lbl.Location.X + lbl.Size.Width, lbl.Location.Y);
                TagGroup.Controls.Add(gc2Control);
                btn.Click += new System.EventHandler(this.BTN_TAG_Click);
                // this.Controls.Add(gc1Control);

                //this.Controls.Add(btn);
                //MessageBox.Show(lbl.Location.ToString());


                TagText.Text = "";
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            LoginForm F = new LoginForm();
            this.Hide();
            F.ShowDialog();
            this.Close();
        }
    }
}