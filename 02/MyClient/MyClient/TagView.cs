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
    public partial class TagView : DevExpress.XtraEditors.XtraUserControl
    {
        private string tag;
        private PanelControl panel1;
        public TagView(string Tag , PanelControl panel2)
        {
            tag = Tag;
            panel1 = panel2;
            InitializeComponent();
        }

        private void LB_Click(object sender, EventArgs e)
        {

            LabelControl label = sender as LabelControl;

            QuestionForm f2 = new QuestionForm(label);
            panel1.Controls.RemoveAt(0);
            panel1.Controls.Add(f2);

            panel1.Show();
            //label.Text = "clicked";
            //RibbonForm1.panel1;

        }


        private void delete_from_intrested(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;
            // tag username

            Dictionary<string, string> paramsent = new Dictionary<string, string>();
            paramsent["username"] = RibbonForm1.username;
            paramsent["tag"] = tag;
            paramsent["state"] = btn.Name;

            Dictionary<string, string> paramdDictionary = GetClass.Main_Get_Request(paramsent, "/Changeintrested");

            if (paramdDictionary["res"] == "true")
            {
                if (btn.Name == "delete")
                {
                    btn.Name = "add";
                    btn.Text = "add this tag to my intrest list";
                    btn.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\Add.svg");

                }
                else
                {
                    btn.Name = "delete";
                    btn.Text = "delete this tag from my intrest list";
                    btn.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\delete2.svg");
                }
            }



            //label.Text = "clicked";
            //RibbonForm1.panel1;

        }
        private void TagView_Load(object sender, EventArgs e)
        {
            labelControl1.Text = tag;

            this.AutoScroll = true;
            Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
            Dictionary<string, string> paramssent = new Dictionary<string, string>
            {
                {"tag", tag},
                {"username" , RibbonForm1.username}
            };
            parametrsDictionary = GetClass.Main_Get_Request(paramssent, "/GetSpecialTagsQuestion");
            if (parametrsDictionary["intres"] == "true")
            {
                intrestbtn.Text = "delete this tag from my intrest list";
                intrestbtn.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\delete2.svg");
                intrestbtn.Name = "delete";
                intrestbtn.Click += new EventHandler(delete_from_intrested);
            }
            else
            {
                intrestbtn.Text = "add this tag to my intrest list";
                intrestbtn.Name = "add";
                intrestbtn.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\Add.svg");
                intrestbtn.Click += new EventHandler(delete_from_intrested);
            }
            // parametrsDictionary = GetClass.Get_Special_TagsQuestion(tag);
            labelControl2.Text =  "This tag has been asked "  + parametrsDictionary["numberq"] + " times";
            List<List<string>> qList = new List<List<string>>();

            List<string> valuesparamList = parametrsDictionary.Values.ToList();
            for (int i = 0; i < Int32.Parse(parametrsDictionary["number"]); i++)
            {
                List<string> list01 = new List<string> { parametrsDictionary["userid" + i.ToString()], parametrsDictionary["head" + i.ToString()], parametrsDictionary["qid" + i.ToString()] };
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
                    LabelControl b1 = new LabelControl();
                    b1.Text = tag;
                    b1.Name = tag;
                    
                    b1.Location = new Point(50 + 100 * j, 110);
                    j++;
                    gc1.Controls.Add(b1);
                }
                gc1.Text = qList[i * 2][0];
                //MessageBox.Show(gc1.Text);
                this.Controls.Add(gc1);

            }
        }
    }
}
