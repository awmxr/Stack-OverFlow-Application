using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;

namespace MyClient
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        //private string username;
        public static string username;
        // public static string comboboxtext = "My intrested's";
        public RibbonForm1(string Username)
        {
            //barListItem1.Caption = Username;
            username = Username;
            InitializeComponent();
            
        }

        MyQuestions myquestions = new MyQuestions(Panel1Control);
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

            Panel1Control.Controls.RemoveAt(0);
            Questionsform = new QuestionsForm(Panel1Control);
            Panel1Control.Controls.Add(Questionsform);
            // Panel1Control.Controls.RemoveAt(0);
            // Panel1Control.Controls.Add(myquestions);
        }





        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Panel panel1 = new Panel();
            //SingUpForm form1 = new SingUpForm();
            //LoginForm form3 = new LoginForm();

            //LoginForm myForm = new LoginForm();
            //myForm.TopLevel = false;
            //myForm.AutoScroll = true;
            //this.panel1.Controls.Add(myForm);
            //myForm.Show();

            //myForm.Show();
            //myForm2.Hide();
            Panel1Control.Controls.RemoveAt(0);
            UsersForm userform0 = new UsersForm();

            Panel1Control.Controls.Add(userform0);



        }
        int XF = 0;
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Panel1Control.Controls.RemoveAt(0);
            TagsForm tagform0 = new TagsForm();

            Panel1Control.Controls.Add(tagform0);


        }

        public static PanelControl Panel1Control = new PanelControl();
        
        public static QuestionsForm Questionsform = new QuestionsForm(Panel1Control); //xf = 0

        //SingUpForm myForm2 = new SingUpForm();
        // public static Thread thread = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Maximized;
            // e.ShowCustomizationMenu = false;

            // thread.Start();
            // Functions.UpdateList.Add("Questions");
            barListItem1.Caption = username;
            //myForm.TopLevel = false;
            Panel1Control.Anchor = (AnchorStyles.Top  | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left);
            Panel1Control.Dock = DockStyle.Fill;
            Panel1Control.AutoSize = true;
            Panel1Control.Size = new Size(2000, 2000);
            //Panel1Control.Location = new Point(150, 160);
            this.Controls.Add(Panel1Control);
            this.panelControl2.Controls.Add(Panel1Control);
            //Questionform.AutoScroll = true;
            //this.panel1.Controls.Add(Questionform);
            Panel1Control.Controls.Add(Questionsform);
            Questionsform.Show();
            ////****************************************
            
            //myForm2.TopLevel = false;
            //myForm2.AutoScroll = true;
            //this.panel1.Controls.Add(myForm2);
            //myForm2.Show();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            
            Panel1Control.Controls.RemoveAt(0);
            Panel1Control.Controls.Add(Questionsform);
            //Questionform.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }


        public static AskQuestionForm askQuestionform = new AskQuestionForm(username);
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //AskQuestionForm askQuestionform = new AskQuestionForm(username);
            Panel1Control.Controls.RemoveAt(0);
            Panel1Control.Controls.Add(askQuestionform);
        }

        private void barListItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RibbonForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Dictionary<string, string> paramsent = new Dictionary<string, string>();

                // paramsent["fin"] = "fin";
                // GetClass.Main_Get_Request(paramsent , "/FinsihP");
                GetClass.sender2.Shutdown(SocketShutdown.Both);
                GetClass.sender2.Close();
                System.Environment.Exit(0);
            }
            catch (Exception exception)
            {
                
            }

            
            
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Panel1Control.Controls.RemoveAt(0);
            Panel1Control.Controls.Add(myquestions);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {

            // GetClass.sender2.Shutdown(SocketShutdown.Both);
            // GetClass.sender2.Close();
            // GetClass.sender2 = new Socket(GetClass.ipAddr.AddressFamily,
            //     SocketType.Stream, ProtocolType.Tcp);
            // LoginForm f = new LoginForm();
            //
            //
            //
            // this.Close();
            // f.Show();
            // Application.Restart();
            try
            {
                GetClass.sender2.Shutdown(SocketShutdown.Both);
                GetClass.sender2.Close();
                // System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
            catch (System.AccessViolationException es)
            {

            }
            catch (Exception exception)
            {
                
            }
            
        }
    }
}