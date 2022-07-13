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
using DevExpress.XtraEditors.Filtering;

namespace MyClient
{
    public partial class AskQuestionForm : DevExpress.XtraEditors.XtraUserControl
    {
        private string username;
        public AskQuestionForm(string Username)
        {
            username = Username;
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AskQuestionForm_Load(object sender, EventArgs e)
        {
            // Functions.UpdateList.Add("Tags");
            ErrorLabel.Text = "";
            ErrorLabel.ForeColor = Color.Red;
            
            labelControl5.Text = "";
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            //get request for tags

            // put then i=on collection
            Dictionary<string, string> tags_id = GetClass.Main_Get_Request(null, "/GetTags");
            tags_id.Remove("number");
            // Dictionary<string, string> tags_id = GetClass.Get_Tags();

            foreach (var i in tags_id.Keys)
            {
                collection.Add(i);
                //MessageBox.Show(i);
            }

            //collection.Add("python");
            //collection.Add("C#");
            //collection.Add("C++");
            //collection.Add("Java");
            //collection.Add("Django");

            textEdit3.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textEdit3.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textEdit3.MaskBox.AutoCompleteCustomSource = collection;
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            //labelControl5.Text += textEdit3.Text;
            //textEdit3.Text = "";
        }

        private void textEdit3_Click(object sender, EventArgs e)
        {
            //labelControl5.Text += textEdit3.Text;
            //textEdit3.Text = "";
        }

        private void textEdit3_Enter(object sender, EventArgs e)
        {
            
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
            foreach (GroupControl gc2 in gc1Control.Controls.OfType< GroupControl>())
            {
                if (btn.Name ==gc2.Name )
                {
                    int z = gc2.Size.Width;
                    int index = tagsList.FindIndex(a => a == gc2.Name);
                    
                    
                    foreach (var gc22 in gc1Control.Controls.OfType<GroupControl>())
                    {
                        int index2 = tagsList.FindIndex(a => a == gc22.Name);
                        if (index <= index2)
                        {
                            Point gc2loc = new Point();
                            gc2loc = gc22.Location;

                            gc2loc.X -= z;
                            gc22.Location = gc2loc;
                        }
                        
                        // gc22.X -= z;
                    }
                    gc1Control.Controls.Remove(gc2);
                    tagsList.Remove(btn.Name);
                    break;
                }
                
            }
            gc1Control.Controls.Remove(btn);
            

        }
        private List<string> tagsList = new List<string>();
        private void textEdit3_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tagsList.Count > 3)
                {
                    MessageBox.Show("at most 4 tag");
                }
                else
                {
                    Point gc2loc = new Point();
                    foreach (GroupControl gc2 in gc1Control.Controls.OfType<GroupControl>())
                    {
                        gc2loc.X += gc2.Size.Width;

                        //gc2loc.X += gc2.Size.Height;


                    }

                    gc2loc.X += 5 - labelControl5.Location.X;


                    //labelControl5.Text += textEdit3.Text;
                    GroupControl gc2Control = new GroupControl();
                    //gc1Control.Location = labelControl5.Location;
                    gc2Control.Location = new Point(labelControl5.Location.X + gc2loc.X, labelControl5.Location.Y);
                    LabelControl lbl = new LabelControl();
                    lbl.Location = new Point(40, 40);
                    lbl.Text = textEdit3.Text;
                    lbl.Font = new Font("Arial", 8, FontStyle.Regular);
                    labelControl5.Hide();
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
                    gc2Control.Name = textEdit3.Text;
                    btn.Name = textEdit3.Text;
                    lbl.Name = textEdit3.Text;
                    tagsList.Add(textEdit3.Text);

                    gc2Control.Size = new Size(lbl.Size.Width + btn.Size.Width + 50, lbl.Size.Height + btn.Size.Height + 5);
                    gc2Control.AutoSize = true;
                    gc2Control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    //lbl.Location = new Point((gc2Control.Size.Width/2) - (btn.Size.Width), (gc2Control.Size.Height / 2) - (btn.Size.Height/2));
                    lbl.Location = new Point(0, (gc2Control.Size.Height / 2) - (btn.Size.Height / 2));
                    btn.Location = new Point(lbl.Location.X + lbl.Size.Width, lbl.Location.Y);
                    gc1Control.Controls.Add(gc2Control);
                    btn.Click += new System.EventHandler(this.BTN_TAG_Click);
                    this.Controls.Add(gc1Control);

                    //this.Controls.Add(btn);
                    //MessageBox.Show(lbl.Location.ToString());


                    textEdit3.Text = "";
                }

                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (HeadTextBox.Text == "")
            {
                ErrorLabel.Text = "Please Enter the Head!";
            }
            else if(DescribTextBox.Text == "")
            {
                ErrorLabel.Text = "Please Enter the Describ!";
            }
            else if (tagsList.Count == 0)
            {
                ErrorLabel.Text = "Please Enter tags";
            }
            else
            {
                //add question and tags
                Dictionary<string, string> parametrDictionary = new Dictionary<string, string>();
                // MessageBox.Show(RibbonForm1.username);
                parametrDictionary["username"] = RibbonForm1.username;
                parametrDictionary["head"] = HeadTextBox.Text;
                parametrDictionary["Describ"] = DescribTextBox.Text;
                parametrDictionary["number"] = tagsList.Count.ToString();
                for (int i = 0; i < tagsList.Count; i++)
                {
                    parametrDictionary["tag" + i.ToString()] = tagsList[i];
                }

                Dictionary<string, string> paramDictionary =
                    GetClass.Main_Get_Request(parametrDictionary, "/PostQuestion");

                string result = paramDictionary["res"];

                // string result = PostClass.Post_Question(parametrDictionary);
                if (result == "true")
                {
                    ErrorLabel.Text = "true";
                    ErrorLabel.ForeColor = Color.Green;

                    

                    LabelControl x = new LabelControl();
                    x.Text = HeadTextBox.Text;
                    x.Name = paramDictionary["qid"];
                    RibbonForm1.askQuestionform = new AskQuestionForm(RibbonForm1.username);
                    QuestionForm q2 = new QuestionForm(x);
                    RibbonForm1.Panel1Control.Controls.RemoveAt(0);
                    
                    RibbonForm1.Panel1Control.Controls.Add(q2);



                    // RibbonForm1.askQuestionform = new AskQuestionForm();

                }


            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            foreach (var gc22 in RibbonForm1.Questionsform.Controls.OfType<GroupControl>())
            {
                var gc2loc = gc22.Location;
                gc2loc.Y += gc22.Height;
                gc22.Location = gc2loc;

                // gc22.X -= z;
            }
            
        }

        
    }
}
