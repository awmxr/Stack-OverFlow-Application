using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace MyClient
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {


        public LoginForm()
        {
            InitializeComponent();
        }

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var paramsent = new Dictionary<string, string>
            {
                { "username", TextUsername.Text },
                { "password", Functions.HashString( TextPassword.Text) }
            };
            Dictionary<string, string> paramDictionary = new Dictionary<string, string>();
            paramDictionary = GetClass.Main_Get_Request(paramsent, "/LoginUser");
            labelControl1.Text = paramDictionary["res"];
            // labelControl1.Text =  GetClass.Login_User(TextUsername.Text,Functions.HashString( TextPassword.Text));
            // MessageBox.Show("true");
            if (labelControl1.Text == "true")
            {
                RibbonForm1 f = new RibbonForm1(TextUsername.Text);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("username or password Wrong!");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                // int size = sizeof(UInt32);
                // UInt32 on = 1;
                // UInt32 keepAliveInterval = 5000; //Send a packet once every 10 seconds.
                // UInt32 retryInterval = 1000; //If no response, resend every second.
                // byte[] inArray = new byte[size * 3];
                // Array.Copy(BitConverter.GetBytes(on), 0, inArray, 0, size);
                // Array.Copy(BitConverter.GetBytes(keepAliveInterval), 0, inArray, size, size);
                // Array.Copy(BitConverter.GetBytes(retryInterval), 0, inArray, size * 2, size);
                // GetClass.sender2.IOControl(IOControlCode.KeepAliveValues, inArray, null);
                // if (GetClass.IsConnected(GetClass.sender2))
                // {
                //
                // }
                // MessageBox.Show(GetClass.IsConnected(GetClass.sender2).ToString());

                
                GetClass.sender2.Connect(GetClass.localEndPoint);
                
                
            }
            catch (System.Net.Sockets.SocketException exception)
            {

                // MessageBox.Show(exception.ToString());
                // this.Close();
            }
            catch (Exception exception)
            {
                
                // MessageBox.Show(exception.ToString());
                // this.Close();
            }
            
        }

        private void TextUsername_EditValueChanged(object sender, EventArgs e)
        {

        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {


            SingUpForm F = new SingUpForm();
            this.Hide();
            F.ShowDialog();
            this.Close();

            //labelControl1.Text = Functions.HashString(TextPassword.Text);

            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            Form f2 = new Form();
            f2 = new RibbonForm1("test");
            f2.Show();
        }
    }
}
