using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;

namespace MyClient
{
    public partial class QuestionsForm : DevExpress.XtraEditors.XtraUserControl
    {
        private PanelControl panel1;
        public QuestionsForm(PanelControl panel2)
        {
            //mainForm = callingForm as RibbonForm1;
            panel1 = panel2;
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
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

        private void Tag_BTN_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;

            // QuestionForm f2 = new QuestionForm(label);
            TagView f2 = new TagView(btn.Name , panel1);
            panel1.Controls.RemoveAt(0);
            panel1.Controls.Add(f2);

            panel1.Show();
            //label.Text = "clicked";
            //RibbonForm1.panel1;

        }

        private void Refresh_click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;
            panel1.Controls.RemoveAt(0);
            QuestionsForm questionsform2 = new QuestionsForm(panel1);
            panel1.Controls.Add(questionsform2);

            
            //this.Refresh();
            

            
            //label.Text = "clicked";
            //RibbonForm1.panel1;

        }

        public static SimpleButton refreshButton = new SimpleButton();
        private List<string> tagsList = new List<string>();

        public static string comboboxtext = "My intrested's";
        // public static Thread t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        private void QuestionForm_Load(object sender, EventArgs e)
        {
            

            
            // comboBoxEdit1.Properties.IncrementalFilteringMode = IncrementalFilteringMode.None;
            // comboBoxEdit1.Properties.DropDownStyle = DropDownStyle.DropDownList;

            Dictionary<string, string> tags_id = GetClass.Main_Get_Request(null, "/GetTags");
            tags_id.Remove("number");

            // Dictionary<string, string> tags_id = GetClass.Get_Tags();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

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

            
            comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxEdit1.Text = comboboxtext;
            // if (t.IsAlive == false)
            // {
            //     t.Start();
            // }


            //MessageBox.Show("test");
            //refreshButton.Location = button1.Location;
            //refreshButton.Text = "Refresh";
            //refreshButton.Size = button1.Size;
            // refreshButton.Enabled = false;
            //button1.Hide();
            //refreshButton.Click += new System.EventHandler(this.Refresh_click);
            //this.Controls.Add(refreshButton);
            Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
            string filter1 = comboboxtext;
            string filter2 = "1234123";
            if (filter1 == "")
            {
                filter1 = "123123";
            }
            var paramssent = new Dictionary<string, string>
            {
                { "filter1", filter1 },
                { "filter2", filter2 },
                { "username", RibbonForm1.username },
            };

            parametrsDictionary = GetClass.Main_Get_Request(paramssent, "/GetNQuestion");
            // parametrsDictionary = GetClass.Get_NQuestions(comboboxtext);
            List<List<string>> qList = new List<List<string>>();

            List<string> valuesparamList = parametrsDictionary.Values.ToList();
            for (int i = 0; i < Int32.Parse( parametrsDictionary["number"]) ; i++)
            {
                List<string> list01 = new List<string> { parametrsDictionary["userid" + i.ToString()], parametrsDictionary["head" + i.ToString()] , parametrsDictionary["qid" + i.ToString()] };
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
            
            
            for (int i = 0; i < (qList.Count/2); i++)
            {
                GroupControl gc1 = new GroupControl();
                //gc1.Text = qList[i * 2][0];
                //gc1.Text = "12121212";
                //MessageBox.Show(qList[i * 2][0].ToString());
                gc1.Size = new Size(850, 160);
                gc1.Location = new Point(60, 140 + i*170);
                LabelControl lbc = new LabelControl();
                lbc.Text = qList[i * 2][1];
                // gc1.Name = parametrsDictionary["qid" + i.ToString()];
                lbc.Font = new Font("Arial", 18, FontStyle.Regular);
                lbc.Location = new Point(30, 60);
                lbc.Click += new System.EventHandler(this.LB_Click );
                lbc.Name = gc1.Text = qList[i * 2][2];
                gc1.Controls.Add(lbc);

                
                int j = 0;
                foreach (string tag in qList[2*i + 1])
                {
                    SimpleButton b1 = new SimpleButton();
                    b1.Text = tag;
                    b1.Name = tag;
                    b1.Click += new System.EventHandler(this.Tag_BTN_Click);
                    b1.Location = new Point(50 + 100 * j, 110);
                    j++;
                    gc1.Controls.Add(b1);
                }
                gc1.Text = qList[i * 2][0];
                //MessageBox.Show(gc1.Text);
                this.Controls.Add(gc1);

            }



            //SimpleButton b1 = new SimpleButton();
            //b1.Text = t1;
            //SimpleButton b2 = new SimpleButton();
            //b2.Text = t2;
            //string dec2 = "Say I have a list like this:\nl = [1, 2, 3, 4, 5, 3]\nhow do I get the indexes of those 3s that have been repeated ? ";
            //GroupControl gc1 = new GroupControl();
            //GroupControl gc2 = new GroupControl();
            //gc1.Size = new Size(850, 160);
            //gc2.Size = new Size(850, 160);
            //gc1.Location = new Point(60, 140);
            //gc2.Location = new Point(60, 310);
            //LabelControl lbc = new LabelControl();
            //lbc.Text = head1;
            //LabelControl lbc2 = new LabelControl();
            //lbc2.Text = dec2;
            //lbc.Font = new Font("Arial", 18, FontStyle.Regular);
            //lbc2.Font = new Font("Arial", 10, FontStyle.Regular);
            //lbc.Location = new Point(30, 60);
            //b1.Location = new Point(50, 110);
            //b2.Location = new Point(150, 110);
            //lbc2.Location = new Point(50, 110);
            //gc1.Controls.Add(lbc);
            //gc1.Controls.Add(b1);
            //gc1.Controls.Add(b2);

            //gc2.Controls.Add(lbc);
            //gc2.Controls.Add(b1);
            //gc2.Controls.Add(b2);
            //gc1.Controls.Add(lbc2);
            //this.Controls.Add(gc1);
            //this.Controls.Add(gc2);


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
            


        }
        

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.RemoveAt(0);
            QuestionsForm questionsform2 = new QuestionsForm(panel1);
            panel1.Controls.Add(questionsform2);
        }

        private void comboBoxEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TextTags_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("true");
            // panel1.Controls.RemoveAt(0);
            // QuestionsForm questionsform2 = new QuestionsForm(panel1);
            // panel1.Controls.Add(questionsform2);
            comboboxtext = comboBoxEdit1.Text;
        }

        private void textEdit1_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void comboBoxEdit1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void comboBoxEdit1_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            panel1.Controls.RemoveAt(0);
            QuestionsForm questionsform2 = new QuestionsForm(panel1);
            panel1.Controls.Add(questionsform2);
        }
    }
}

