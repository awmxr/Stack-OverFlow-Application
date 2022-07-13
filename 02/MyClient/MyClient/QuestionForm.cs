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
using DevExpress.Utils;
using DevExpress.Utils.Svg;

namespace MyClient
{
    public partial class QuestionForm : DevExpress.XtraEditors.XtraUserControl
    {
        private string Question;
        private int Qid;
        private LabelControl questionlbl;
        public QuestionForm(LabelControl Question1)
        {
            questionlbl = Question1;
            Question = Question1.Text;
            Qid = Int32.Parse(Question1.Name);
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        private void Up_Click(object sender, EventArgs e)
        {

            SimpleButton Up = sender as SimpleButton;

            //QuestionForm f2 = new QuestionForm(label);
            //panel1.Controls.RemoveAt(0);
            //panel1.Controls.Add(f2);

            //panel1.Show();
            //label.Text = "clicked";
            //RibbonForm1.panel1;

            QuestionLabel.Text = Up.Name;

        }

        MemoEdit MemoAnswer = new MemoEdit();
        private void QuestionForm_Load(object sender, EventArgs e)
        {
            // Functions.UpdateList.Add(Qid.ToString());
            //MessageBox.Show(Qid.ToString());
            Dictionary<string, string> senp = new Dictionary<string, string>();
            senp["qid"] = Qid.ToString();
            senp["username"] = RibbonForm1.username;


            Dictionary<string, string> parametrsDictionary = GetClass.Main_Get_Request(senp, "/GetNQuestionAnswer");
            // Dictionary<string, string> parametrsDictionary = GetClass.Get_Quesntion_Answer(senp);
            QuestionLabel.Text = parametrsDictionary["head"];
            QuestionDes.Text = parametrsDictionary["describ"];
            Usernamelbl.Text = parametrsDictionary["username"] + " :";
            Viewlbl.Text = "View : " + parametrsDictionary["view"];

            // MessageBox.Show(parametrsDictionary["username"]);


            List<List<string>> Answers = new List<List<string>>();

            for (int i = 0; i < Int32.Parse(parametrsDictionary["number"]); i++)
            {
                List<string> answ1List = new List<string>
                {
                    parametrsDictionary["userid" + i.ToString()],
                    parametrsDictionary["answer" + i.ToString()],
                    parametrsDictionary["voteup" + i.ToString()],
                    parametrsDictionary["votedown" + i.ToString()]
                };

                Answers.Add(answ1List);

            }
            //List<string> answ1List = new List<string>
            //{
            //    "amir",
            //    "his should do it\nlist = [1,2,3,4,5,3]\ndeletes = 0;\nfor element in list:\nif element == 3:\nprint(list.index(element) + deletes)\ndeletes = +1;\nlist.remove(3)\n\n\nWe get the index of the element , remove one so it can find the next one and increment by 1 the next index so it matches the original list idddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd d dddddddddddddndex. Outputs:\n2\n5",
            //    "2", "3"
            //};
            //List<string> answ2List = new List<string>
            //{
            //    "awmxr",
            //    "his should do it\nlist = [1,2,3,4,5,3]\ndeletes = 0;\nfor element in list:\nif element == 3:\nprint(list.index(element) + deletes)\ndeletes = +1;\nlist.remove(3)\n\n\nWe get the index of the element , remove one so it can find the next one and increment by 1 the next index so it matches the original list index. Outputs:\n2\n5",
            //    "2", "3"
            //};

            this.AutoScroll = true;
            //this.scroll

            //Answers.Add(answ1List);
            //Answers.Add(answ2List);
            //Answers.Add(answ1List);
            //Answers.Add(answ2List);
            //Answers.Add(answ1List);
            //Answers.Add(answ2List);
            //Answers.Add(answ1List);
            //Answers.Add(answ2List);
            //QuestionLabel.Text = Question;
            //QuestionDes.Text = "Say I have a list like this:\n\nl = [1, 2, 3, 4, 5, 3]\n\nhow do I get the indexes of those 3s that have been repeated ? ";
            var lines2 = QuestionDes.Text.Split('\n');
            int lines2number = QuestionDes.Text.Split('\n').Length;

            foreach (var jomle in lines2)
            {
                if (jomle.Length >= 123)
                {
                    //MessageBox.Show(jomle.Length.ToString());
                    int x = jomle.Length / 123;
                    lines2number += x;
                }
            }

            //MessageBox.Show(lines2number.ToString());

            int z = 0;
            //lines2number = 60;
            int z2 = 160 + lines2number*20 + 20;

            for (int i = 0; i < (Answers.Count); i++)
            {

                SimpleButton voteUpButton = new SimpleButton();
                SimpleButton voteDownButton = new SimpleButton();
                LabelControl voteLabelControl = new LabelControl();
                //voteUpButton.Image = Image.FromFile(@"D:\\Amir\\Network\\03\\c53f07ae-9285-466e-ac93-4819fe605b9b.jpg");
                //SvgImageCollection collection = SvgImageCollection.FromResources("WindowsFormsApp1.Images", typeof(QuestionForm).Assembly);
                voteUpButton.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\up.svg");
                voteDownButton.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\down.svg");
                voteDownButton.Size = new Size(40, 40);
                voteUpButton.Size = new Size(40, 40);
                voteUpButton.Click += new System.EventHandler(this.Up_BTN_Click);
                voteDownButton.Click += new System.EventHandler(this.Down_BTN_Click);
                voteUpButton.Name = parametrsDictionary["aid" + i.ToString()];
                voteDownButton.Name = parametrsDictionary["aid" + i.ToString()];





                int VoteT = Int32.Parse( parametrsDictionary["vote" + i.ToString()]);

                voteLabelControl.Text = VoteT.ToString();

                
                GroupControl gc1 = new GroupControl();
                gc1.Text = Answers[i][0];
                int linenumber = Answers[i][1].Split('\n').Length;
                //MessageBox.Show(linenumber.ToString());
                if (linenumber < 7)
                {
                    linenumber = 7;
                }
                
                var lines = Answers[i][1].Split('\n');

                foreach (var jomle in lines)
                {
                    //MessageBox.Show(jomle);
                    if (jomle.Length >= 123)
                    {
                        //MessageBox.Show(jomle.Length.ToString());
                        int x = jomle.Length / 123;
                        linenumber += x;
                    }
                }
                gc1.Size = new Size(850, linenumber*22);
                z += z2+ 10;
                voteLabelControl.Font = new Font("Arial", 10, FontStyle.Regular);
                voteLabelControl.Name = parametrsDictionary["aid" + i.ToString()];
                //voteDownButton.Text = "down";
                //voteUpButton.Text = "up";
                // voteUpButton.Name = "12";
                voteUpButton.Location = new Point(50, z );
                voteLabelControl.Location = new Point(65, z + 60);
                voteDownButton.Location = new Point(50, z + 100);
                gc1.Location = new Point(150, z);
                z2 =  linenumber * 22;

                LabelControl lbc = new LabelControl();
                lbc.Text = Answers[i][1];
                lbc.Font = new Font("Arial", 10, FontStyle.Regular);
                lbc.AutoSizeMode = LabelAutoSizeMode.Vertical;
                lbc.Size = new Size(750, linenumber * 22);
                lbc.Location = new Point(30, 60);
                //lbc.Click += new System.EventHandler(this.LB_Click);
                gc1.Controls.Add(lbc);
                // voteUpButton.Click += new System.EventHandler(this.Up_Click);
                // voteUpButton.Click += new System.EventHandler(this.Down_BTN_Click);
                


                //int j = 0;
                //foreach (string tag in qList[2 * i + 1])
                //{
                //    SimpleButton b1 = new SimpleButton();
                //    b1.Text = tag;
                //    b1.Location = new Point(50 + 100 * j, 110);
                //    j++;
                //    gc1.Controls.Add(b1);
                //}
                //gc1.AutoSize = true;
                this.Controls.Add(gc1);

                if (Answers[i][0] != RibbonForm1.username)
                {
                    this.Controls.Add(voteUpButton);
                    // this.Controls.Add(voteLabelControl);
                    this.Controls.Add(voteDownButton);
                }
                if (Answers[i][0] == RibbonForm1.username)
                {
                    SimpleButton deleteanswerBTN = new SimpleButton();
                    deleteanswerBTN.Location = new Point(50, z);
                    deleteanswerBTN.Size = new Size(40, 40);
                    deleteanswerBTN.ImageOptions.SvgImage = SvgImage.FromFile(@"D:\Amir\Network\Network\03\delete.svg");
                    deleteanswerBTN.Name = parametrsDictionary["aid" + i.ToString()];
                    deleteanswerBTN.Click += new EventHandler(this.Delete_Answer_BTN_Click);
                    this.Controls.Add(deleteanswerBTN);


                }
                this.Controls.Add(voteLabelControl);



            }

            z += z2;
            
            SimpleButton SubmitAnswerBTN = new SimpleButton();
            MemoAnswer.Size = new Size(850, 200);
            MemoAnswer.Font = new Font("Arial", 15, FontStyle.Regular);
            MemoAnswer.Location = new Point(150, z + 30);
            SubmitAnswerBTN.Location = new Point(150, z + MemoAnswer.Height + 40);
            SubmitAnswerBTN.Text = "Submit";
            SubmitAnswerBTN.Click += new System.EventHandler(this.Submit_Answer_BTN_Click);
            // SubmitAnswerBTN.Name = Qid.ToString();

            if (parametrsDictionary["username"] != RibbonForm1.username)
            {
                this.Controls.Add(MemoAnswer);
                this.Controls.Add(SubmitAnswerBTN);
            }
            


        }

        private void Delete_Answer_BTN_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;

            var paramssent = new Dictionary<string, string>
            {
                { "aid", btn.Name }

            };

            Dictionary<string, string> res = GetClass.Main_Get_Request(paramssent, "/DeleteAnswer");
            // Dictionary<string,string> res =  GetClass.Delete_Answer(btn.Name);
            RibbonForm1.Panel1Control.Controls.RemoveAt(0);


            QuestionForm q = new QuestionForm(questionlbl);
            RibbonForm1.Panel1Control.Controls.Add(q);
            // MessageBox.Show(res["res"]);
            



            //delete by aid




            // update up


        }

        private void Submit_Answer_BTN_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;
            string x = MemoAnswer.Text;

            if (x == "")
            {
                MessageBox.Show("fill answer box");
            }
            else
            {

                var paramssent = new Dictionary<string, string>
                {

                    { "username", RibbonForm1.username },
                    { "qid", Qid.ToString() },
                    {"Describ" , x}

                };
                Dictionary<string, string> paramsDictionary = GetClass.Main_Get_Request(paramssent, "/Postanswer");
                // Dictionary<string, string> paramsDictionary = GetClass.Submit_answer(x,Qid.ToString());
                if (paramsDictionary["state"] != "true")
                {
                    MessageBox.Show("try again");
                }
                else
                {
                    MemoAnswer.Text = "";
                    RibbonForm1.Panel1Control.Controls.RemoveAt(0);


                    QuestionForm q = new QuestionForm(questionlbl);
                    RibbonForm1.Panel1Control.Controls.Add(q);
                    

                }
            }

            

            
            // update up


        }

        private void Up_BTN_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;

            var paramssent = new Dictionary<string, string>
            {

                { "username", RibbonForm1.username },
                {"vote" , "up"},
                {"aid" , btn.Name}
            };

            Dictionary<string, string> paramsDictionary = GetClass.Main_Get_Request(paramssent, "/GetVote");

            // Dictionary<string,string> paramsDictionary =  GetClass.Get_Vote("up", btn.Name);

            foreach (LabelControl lb2 in this.Controls.OfType<LabelControl>())
            {

                if (lb2.Name == btn.Name)
                {
                    lb2.Text = paramsDictionary["votes"];
                    break;
                }
                


            }


            // MessageBox.Show(paramsDictionary["state"]);
            // update up







        }

        private void Down_BTN_Click(object sender, EventArgs e)
        {

            SimpleButton btn = sender as SimpleButton;
            var paramssent = new Dictionary<string, string>
            {

                { "username", RibbonForm1.username },
                {"vote" , "down"},
                {"aid" , btn.Name}
            };

            Dictionary<string, string> paramsDictionary = GetClass.Main_Get_Request(paramssent, "/GetVote");

            // Dictionary<string, string> paramsDictionary = GetClass.Get_Vote("down", btn.Name);

            foreach (LabelControl lb2 in this.Controls.OfType<LabelControl>())
            {

                if (lb2.Name == btn.Name)
                {
                    lb2.Text = paramsDictionary["votes"];
                    break;
                }



            }

            // MessageBox.Show(paramsDictionary["state"]);


        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // RibbonForm1.thread.Abort();
            
            
            // Functions.UpdateList.Remove(Qid.ToString());
            RibbonForm1.Panel1Control.Controls.RemoveAt(0);
            RibbonForm1.Questionsform = new QuestionsForm(RibbonForm1.Panel1Control);
            RibbonForm1.Panel1Control.Controls.Add(RibbonForm1.Questionsform);


            // RibbonForm1.thread = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
            // RibbonForm1.thread.Start();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            RibbonForm1.Panel1Control.Controls.RemoveAt(0);


            QuestionForm q = new QuestionForm(questionlbl);
            RibbonForm1.Panel1Control.Controls.Add(q);
        }
    }
}
