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
    public partial class TagsForm : DevExpress.XtraEditors.XtraUserControl
    {
        public TagsForm()
        {
            InitializeComponent();
        }
        public static string comboboxtext = "My intrested";



        private void Tag_BTN_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;

            // QuestionForm f2 = new QuestionForm(label);
            TagView f2 = new TagView(btn.Name, RibbonForm1.Panel1Control);
            RibbonForm1.Panel1Control.Controls.RemoveAt(0);
            RibbonForm1.Panel1Control.Controls.Add(f2);

            RibbonForm1.Panel1Control.Show();
            //label.Text = "clicked";
            //RibbonForm1.panel1;

        }

        private void TagsForm_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;


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

            SerchTXT.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            SerchTXT.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            SerchTXT.MaskBox.AutoCompleteCustomSource = collection;




            Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
            // string filter1 = comboboxtext;
            // string filter2 = "1234123";
            // if (filter1 == "")
            // {
            //     filter1 = "123123";
            // }
            // var paramssent = new Dictionary<string, string>
            // {
            //     { "filter1", filter1 },
            //     { "filter2", filter2 },
            //     { "username", RibbonForm1.username },
            // };

            parametrsDictionary = GetClass.Main_Get_Request(null, "/GetNTagsForm");
            // parametrsDictionary = GetClass.Get_NQuestions(comboboxtext);
            // List<List<string>> qList = new List<List<string>>();

            // List<string> valuesparamList = parametrsDictionary.Values.ToList();
            // for (int i = 0; i < Int32.Parse(parametrsDictionary["number"]); i++)
            // {
            //     List<string> list01 = new List<string> { parametrsDictionary["userid" + i.ToString()], parametrsDictionary["head" + i.ToString()], parametrsDictionary["qid" + i.ToString()] };
            //     //MessageBox.Show(parametrsDictionary["userid" + i.ToString()]);
            //     string tags = parametrsDictionary["tags" + i.ToString()];
            //     string[] ar = tags.Split(new string[] { "<*****>" }, StringSplitOptions.None);
            //
            //     ar = ar.Where(val => val != "").ToArray();
            //
            //
            //     List<string> tags1List = ar.ToList();
            //     qList.Add(list01);
            //     qList.Add(tags1List);
            //
            //
            //
            // }
            // string head1 = "How to get the indexes of the same values in a list 1 2 3 4 5 6 7 8?";
            // string t1 = "python";
            // string t2 = "java";
            // string t3 = "C#";
            // string t4 = "django";

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


            for (int i = 0; i < Int32.Parse(parametrsDictionary["number"]); i++)
            {
                GroupControl gc1 = new GroupControl();
                //gc1.Text = qList[i * 2][0];
                //gc1.Text = "12121212";
                //MessageBox.Show(qList[i * 2][0].ToString());
                gc1.Size = new Size(850, 160);
                gc1.Location = new Point(60, 140 + i * 170);
                gc1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                SimpleButton btntag = new SimpleButton();
                btntag.AutoSize = true;
                
                LabelControl lbc2 = new LabelControl();
                btntag.Text = parametrsDictionary["tag" + i.ToString()];
                lbc2.Text = "Asked : " + parametrsDictionary["asked" + i.ToString()];
                lbc2.Font = new Font("Arial", 15, FontStyle.Regular);
                // gc1.Name = parametrsDictionary["qid" + i.ToString()];
                btntag.Font = new Font("Arial", 20, FontStyle.Regular);
                btntag.Location = new Point(30, 60);
                lbc2.Location = new Point(30, 60 + btntag.Location.Y + 5);
                btntag.Name = parametrsDictionary["tag" + i.ToString()];
                btntag.Click += new EventHandler(Tag_BTN_Click);
                // lbc.Click += new System.EventHandler(this.LB_Click);
                // lbc.Name = gc1.Text = qList[i * 2][2];
                // btntag.Size = new Size(btntag.Size.Width + 20, btntag.Size.Height + 3);
                gc1.Controls.Add(btntag);
                gc1.Controls.Add(lbc2);


                // int j = 0;
                // foreach (string tag in qList[2 * i + 1])
                // {
                //     SimpleButton b1 = new SimpleButton();
                //     b1.Text = tag;
                //     b1.Name = tag;
                //     // b1.Click += new System.EventHandler(this.Tag_BTN_Click);
                //     b1.Location = new Point(50 + 100 * j, 110);
                //     j++;
                //     gc1.Controls.Add(b1);
                // }
                // gc1.Text = qList[i * 2][0];
                //MessageBox.Show(gc1.Text);
                this.Controls.Add(gc1);

            }
        }

        private void textEdit1_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                TagView f2 = new TagView(SerchTXT.Text, RibbonForm1.Panel1Control);
                RibbonForm1.Panel1Control.Controls.RemoveAt(0);
                RibbonForm1.Panel1Control.Controls.Add(f2);

                RibbonForm1.Panel1Control.Show();
            }
        }
    }
}
