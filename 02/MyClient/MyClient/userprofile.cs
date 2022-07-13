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
using DevExpress.Utils.Svg;

namespace MyClient
{
    public partial class userprofile : DevExpress.XtraEditors.XtraUserControl
    {
        private string username0;
        public userprofile(string username)
        {
            username0 = username;
            InitializeComponent();
        }

        private void LB_Click(object sender, EventArgs e)
        {

            LabelControl label = sender as LabelControl;

            QuestionForm f2 = new QuestionForm(label);
            RibbonForm1.Panel1Control.Controls.RemoveAt(0);
            RibbonForm1.Panel1Control.Controls.Add(f2);

            RibbonForm1.Panel1Control.Show();
            //label.Text = "clicked";
            //RibbonForm1.panel1;

        }

        private void userprofile_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();

            var paramssent = new Dictionary<string, string>
            {

                { "username", username0 }
            };
            parametrsDictionary = GetClass.Main_Get_Request(paramssent, "/GetMyNQuestions");
            // parametrsDictionary = GetClass.Get_MyQuestions();
            List<List<string>> qList = new List<List<string>>();
            labelControl3.Text = "My Questions : " + parametrsDictionary["numberq"];
            labelControl2.Text = "My Answers : " + parametrsDictionary["numbera"];
            labelControl4.Text = "vote up : " + parametrsDictionary["mosbat"];
            labelControl5.Text = "vote down : " + parametrsDictionary["manfi"];
            NameLBL.Text = parametrsDictionary["name"] + " " + parametrsDictionary["last"];
            EmailLBL.Text = parametrsDictionary["email"];
            UsernameLBL.Text = username0;

            List<string> valuesparamList = parametrsDictionary.Values.ToList();
            for (int i = 0; i < Int32.Parse(parametrsDictionary["number"]); i++)
            {
                List<string> list01 = new List<string> { parametrsDictionary["userid" + i.ToString()], parametrsDictionary["head" + i.ToString()], parametrsDictionary["qid" + i.ToString()], parametrsDictionary["view" + i.ToString()], parametrsDictionary["numbera" + i.ToString()] };
                //MessageBox.Show(parametrsDictionary["userid" + i.ToString()]);
                string tags = parametrsDictionary["tags" + i.ToString()];
                string[] ar = tags.Split(new string[] { "<*****>" }, StringSplitOptions.None);

                ar = ar.Where(val => val != "").ToArray();


                List<string> tags1List = ar.ToList();
                qList.Add(list01);
                qList.Add(tags1List);



            }
            string head1 = "How to get the indexes of the same values in a list 1 2 3 4 5 6 7 8?";
            string t1 = "python";
            string t2 = "java";
            string t3 = "C#";
            string t4 = "django";

            //List<string> list01 = new List<string> { "awmxr", head1};
            //List<string> tags1List = new List<string> {t1, t4};
            //List<string> list02 = new List<string> { "amir", head1};
            //List<string> tags2List = new List<string> { t2, t3 };


            //qList.Add(list01);
            //qList.Add(tags1List);
            //qList.Add(list02);
            //qList.Add(tags2List);
            //qList.Add(list01);
            //qList.Add(tags1List);
            //qList.Add(list02);
            //qList.Add(tags2List);
            //qList.Add(list01);
            //qList.Add(tags1List);
            //qList.Add(list02);
            //qList.Add(tags2List);
            //qList.Add(list01);
            //qList.Add(tags1List);
            //qList.Add(list02);
            //qList.Add(tags2List);
            //qList.Add(list01);
            //qList.Add(tags1List);
            //qList.Add(list02);
            //qList.Add(tags2List);
            //qList.Add(list01);
            //qList.Add(tags1List);
            //qList.Add(list02);
            //qList.Add(tags2List);


            for (int i = 0; i < (qList.Count / 2); i++)
            {
                GroupControl gc1 = new GroupControl();
                //gc1.Text = qList[i * 2][0];
                //gc1.Text = "12121212";
                //MessageBox.Show(qList[i * 2][0].ToString());
                gc1.Size = new Size(850, 160);
                gc1.Location = new Point(60, 140 + i * 170);
                LabelControl lbc = new LabelControl();
                lbc.Text = qList[i * 2][1];
                // gc1.Name = parametrsDictionary["qid" + i.ToString()];
                lbc.Font = new Font("Arial", 18, FontStyle.Regular);
                lbc.Location = new Point(30, 60);
                lbc.Click += new System.EventHandler(this.LB_Click);
                lbc.Name = gc1.Text = qList[i * 2][2];
                gc1.Controls.Add(lbc);


                int j = 0;
                foreach (string tag in qList[2 * i + 1])
                {
                    SimpleButton b1 = new SimpleButton();
                    b1.Text = tag;
                    b1.Name = tag;
                    // b1.Click += new System.EventHandler(this.Tag_BTN_Click);
                    b1.Location = new Point(50 + 100 * j, 110);
                    b1.Enabled = false;
                    j++;
                    gc1.Controls.Add(b1);
                }

                // MessageBox.Show(qList[i * 2].ToString());
                gc1.Text = "View : " + qList[i * 2][3] + "\t\t\t Answer : " + qList[2 * i][4];
                //MessageBox.Show(gc1.Text);
                // SimpleButton deleteButton = new SimpleButton();
                //
                // deleteButton.Location = new Point(gc1.Location.X - 40, gc1.Height / 2 + gc1.Location.Y);
                // deleteButton.Size = new Size(35, 30);
                // deleteButton.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\delete.svg");
                // deleteButton.Click += new System.EventHandler(this.Delete_BTN_Click);
                // deleteButton.Name = parametrsDictionary["qid" + i.ToString()];



                // SvgImage.FromFile(@"D:\Amir\Network\Network\03\down.svg");
                // this.Controls.Add(deleteButton);

                this.Controls.Add(gc1);

            }
        }
    }
}
