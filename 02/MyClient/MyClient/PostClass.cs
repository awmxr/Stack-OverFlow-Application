using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClient
{
    class PostClass
    {
        public static string SignUp(Dictionary<string , string> parameters)
        {
            // if (QuestionsForm.t.IsAlive)
            // {
            //     QuestionsForm.t.Abort();
            // }
            if (GetClass.IsConnected(GetClass.sender2) == false)
            {
                GetClass.sender2.Shutdown(SocketShutdown.Both);
                GetClass.sender2.Close();
                GetClass.sender2 = new Socket(GetClass.ipAddr.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                GetClass.sender2.Connect(GetClass.localEndPoint);

            }
            string result = "";
            try
            {

                
                // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
                // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
                //
                // Socket sender2 = new Socket(ipAddr.AddressFamily,
                //            SocketType.Stream, ProtocolType.Tcp);

                try
                {

                    
                    

                    
                    //var parameters = new Dictionary<string, string>
                    //{
                    //  { "username", username },
                    //  { "password", password }
                    //};
                    string z = Functions.UrlEncode(parameters);
                    byte[] messageSent = Encoding.ASCII.GetBytes("Post"+Setting.SplitChar+"/SignUp"+Setting.SplitChar + z +Setting.SplitChar + Setting.fin);
                    int byteSent = GetClass.sender2.Send(messageSent);





                    string a = "";
                    while (a.Contains(Setting.fin) == false)
                    {
                        byte[] messageReceived = new byte[100];
                        int byteRecv = GetClass.sender2.Receive(messageReceived);
                        result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
                        a += result;
                        // MessageBox.Show(a);

                    }

                    a = Functions.Replace_Fin(a);
                    // MessageBox.Show(a);
                    result = a;




                    // Data buffer
                    // byte[] messageReceived = new byte[1024];
                    //
                    // // We receive the message using
                    // // the method Receive(). This
                    // // method returns number of bytes
                    // // received, that we'll use to
                    // // convert them to string
                    // int byteRecv = sender2.Receive(messageReceived);
                    // result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);

                    //Console.WriteLine("Message from Server -> {0}",
                    //      Encoding.ASCII.GetString(messageReceived,
                    //                                 0, byteRecv));

                    // Close Socket using
                    // the method Close()
                    // GetClass.sender2.Shutdown(SocketShutdown.Both);
                    // GetClass.sender2.Close();
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    //Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception ee)
                {
                    //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
                }
            }

            catch (Exception re)
            {

                //Console.WriteLine(re.ToString());
            }


            // if (QuestionsForm.t.IsAlive == false)
            // {
            //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
            //     QuestionsForm.t.Start();
            // }
            return result;

        }



        public static string Post_Question(Dictionary<string, string> parameters)
        {
            // if (QuestionsForm.t.IsAlive)
            // {
            //     QuestionsForm.t.Abort();
            // }

            if (GetClass.IsConnected(GetClass.sender2) == false)
            {
                GetClass.sender2.Shutdown(SocketShutdown.Both);
                GetClass.sender2.Close();
                GetClass.sender2 = new Socket(GetClass.ipAddr.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                GetClass.sender2.Connect(GetClass.localEndPoint);

            }
            string result = "";
            try
            {


                // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
                // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
                //
                // Socket sender2 = new Socket(ipAddr.AddressFamily,
                //            SocketType.Stream, ProtocolType.Tcp);

                try
                {


                    // GetClass.sender2.Connect(localEndPoint);


                    //var parameters = new Dictionary<string, string>
                    //{
                    //  { "username", username },
                    //  { "password", password }
                    //};
                    string z = Functions.UrlEncode(parameters);
                    byte[] messageSent = Encoding.ASCII.GetBytes("Post" + Setting.SplitChar + "/PostQuestion" + Setting.SplitChar + z + Setting.SplitChar + Setting.fin);
                    int byteSent = GetClass.sender2.Send(messageSent);





                    string a = "";
                    while (a.Contains(Setting.fin) == false)
                    {
                        byte[] messageReceived = new byte[100];
                        int byteRecv = GetClass.sender2.Receive(messageReceived);
                        result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
                        a += result;
                        // MessageBox.Show(a);

                    }

                    a = Functions.Replace_Fin(a);
                    MessageBox.Show(a);
                    result = a;




                    // Data buffer
                    // byte[] messageReceived = new byte[1024];
                    //
                    // // We receive the message using
                    // // the method Receive(). This
                    // // method returns number of bytes
                    // // received, that we'll use to
                    // // convert them to string
                    // int byteRecv = sender2.Receive(messageReceived);
                    // result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);

                    //Console.WriteLine("Message from Server -> {0}",
                    //      Encoding.ASCII.GetString(messageReceived,
                    //                                 0, byteRecv));

                    // Close Socket using
                    // the method Close()
                    // GetClass.sender2.Shutdown(SocketShutdown.Both);
                    // GetClass.sender2.Close();
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    //Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception ee)
                {
                    //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
                }
            }

            catch (Exception re)
            {

                //Console.WriteLine(re.ToString());
            }


            
            return result;

        }

    }
}
