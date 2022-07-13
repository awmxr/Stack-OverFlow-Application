using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MyClient
{
    class GetClass
    {


        public static IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        public static IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        public static Socket sender2 = new Socket(ipAddr.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);



        public static bool IsConnected(Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }

        public static Dictionary<string, string> Main_Get_Request(Dictionary<string, string> parameters, string path)
        {
            // if (QuestionsForm.t.IsAlive)
            // {
            //     QuestionsForm.t.Abort();
            // }

            if (IsConnected(sender2) == false)
            {
                sender2.Shutdown(SocketShutdown.Both);
                sender2.Close();
                sender2 = new Socket(ipAddr.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                sender2.Connect(localEndPoint);

            }
            string result = "";
            try
            {


                // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
                // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);


                /*Socket sender2 = new Socket(ipAddr.AddressFamily,
                           */
                // SocketType.Stream, ProtocolType.Tcp);

                try
                {

                    // sender2.Connect(localEndPoint);

                    // We print EndPoint information
                    // that we are connected
                    //Console.WriteLine("Socket connected to -> {0} ",
                    //              sender2.RemoteEndPoint.ToString());

                    // Creation of message that
                    // we will send to Server

                    // var parameters = new Dictionary<string, string>
                    // {
                    //   { "tag", tag }
                    //   
                    //   // { "username", RibbonForm1.username },
                    // };
                    string z = "";
                    if (parameters != null)
                    {
                        z = Functions.UrlEncode(parameters);
                    }

                    // MessageBox.Show(z);


                    string fin = "<SSFINSS>";
                    byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + path + Setting.SplitChar + z + Setting.SplitChar + fin);
                    // while (true)
                    // {
                    //     try
                    //     {
                    //         int byteSent = sender2.Send(messageSent);
                    //         break;
                    //     }
                    //     catch (Exception e)
                    //     {
                    //         sender2.Connect(localEndPoint);
                    //     }
                    // }


                    int byteSent = sender2.Send(messageSent);

                    // Data buffer
                    string a = "";
                    while (a.Contains(fin) == false)
                    {
                        byte[] messageReceived = new byte[100];
                        int byteRecv = sender2.Receive(messageReceived);
                        result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
                        a += result;

                    }

                    a = Functions.Replace_Fin(a);
                    result = a;


                    // sender2.Shutdown(SocketShutdown.Both);
                    // sender2.Close();
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception ee)
                {
                    Console.WriteLine("Unexpected exception : {0}", ee.ToString());
                }
            }

            catch (Exception re)
            {

                Console.WriteLine(re.ToString());
            }

            string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
            //var url = new Uri(ar[2]);
            //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);

            //foreach (var VARIABLE in queryDictionary)
            //{
            //    MessageBox.Show(VARIABLE.ToString());
            //}
            Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
            parametrsDictionary = Functions.UrlDecode(ar[2]);
            //MessageBox.Show(queryDictionary.Get("number").ToString());
            //MessageBox.Show(queryDictionary.Keys[0].ToString());
            // if (QuestionsForm.t.IsAlive == false)
            // {
            //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
            //     QuestionsForm.t.Start();
            // }

            return parametrsDictionary;
        }

        // public static string Login_User(string username,string password)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //         
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //         //
        //         //
        //         // Socket sender2 = new Socket(ipAddr.AddressFamily,
        //         //            SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             var parameters = new Dictionary<string, string>
        //             {
        //               { "username", username },
        //               { "password", password }
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET"+ Setting.SplitChar+"/LoginUser"+Setting.SplitChar+ z  + Setting.SplitChar + fin);
        //             int byteSent = sender2.Send(messageSent);
        //
        //
        //
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //                 // MessageBox.Show(a);
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             // MessageBox.Show(a);
        //             result = a;
        //
        //
        //             // Data buffer
        //             //byte[] messageReceived = new byte[1024];
        //
        //             //// We receive the message using
        //             //// the method Receive(). This
        //             //// method returns number of bytes
        //             //// received, that we'll use to
        //             //// convert them to string
        //             
        //             //int byteRecv = sender2.Receive(messageReceived);
        //             //result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //
        //             //Console.WriteLine("Message from Server -> {0}",
        //             //      Encoding.ASCII.GetString(messageReceived,
        //             //                                 0, byteRecv));
        //
        //             // Close Socket using
        //             // the method Close()
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             //Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         //Console.WriteLine(re.ToString());
        //     }
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //     return result;
        // }


        // public static Dictionary<string, string> Get_NQuestions(string filter1 = "123123" , string filter2 = "123123")
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //         
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //         
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //         
        //         /*Socket sender2 = new Socket(ipAddr.AddressFamily,
        //                    */
        //                    // SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             if (filter1 == "")
        //             {
        //                 filter1 = "123123";
        //             }
        //             var parameters = new Dictionary<string, string>
        //             {
        //               { "filter1", filter1 },
        //               { "filter2", filter2 },
        //               { "username", RibbonForm1.username },
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             // MessageBox.Show(z);
        //             
        //
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetNQuestion" + Setting.SplitChar +z + Setting.SplitChar + fin);
        //             // while (true)
        //             // {
        //             //     try
        //             //     {
        //             //         int byteSent = sender2.Send(messageSent);
        //             //         break;
        //             //     }
        //             //     catch (Exception e)
        //             //     {
        //             //         sender2.Connect(localEndPoint);
        //             //     }
        //             // }
        //
        //
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //             
        //
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //     // MessageBox.Show(parametrsDictionary["number"]);
        //     return parametrsDictionary;
        // }

        // public static Dictionary<string, string> Delete_Question(string qid)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //
        //         /*Socket sender2 = new Socket(ipAddr.AddressFamily,
        //                    */
        //         // SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             
        //             var parameters = new Dictionary<string, string>
        //             {
        //               { "qid", qid },
        //               
        //               
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             // MessageBox.Show(z);
        //
        //
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/DeleteQuestion" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             // while (true)
        //             // {
        //             //     try
        //             //     {
        //             //         int byteSent = sender2.Send(messageSent);
        //             //         break;
        //             //     }
        //             //     catch (Exception e)
        //             //     {
        //             //         sender2.Connect(localEndPoint);
        //             //     }
        //             // }
        //
        //
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //     // MessageBox.Show(parametrsDictionary["number"]);
        //     return parametrsDictionary;
        // }

        // public static Dictionary<string, string> Get_MyQuestions()
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //
        //         /*Socket sender2 = new Socket(ipAddr.AddressFamily,
        //                    */
        //         // SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             
        //             var parameters = new Dictionary<string, string>
        //             {
        //               
        //               { "username", RibbonForm1.username }
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             // MessageBox.Show(z);
        //
        //
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetMyNQuestions" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             // while (true)
        //             // {
        //             //     try
        //             //     {
        //             //         int byteSent = sender2.Send(messageSent);
        //             //         break;
        //             //     }
        //             //     catch (Exception e)
        //             //     {
        //             //         sender2.Connect(localEndPoint);
        //             //     }
        //             // }
        //
        //
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //
        //     return parametrsDictionary;
        // }




        // public static Dictionary<string, string> Get_Vote(string vote , string aid)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //
        //         /*Socket sender2 = new Socket(ipAddr.AddressFamily,
        //                    */
        //         // SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //
        //             var parameters = new Dictionary<string, string>
        //             {
        //
        //               { "username", RibbonForm1.username },
        //               {"vote" , vote},
        //               {"aid" , aid}
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             // MessageBox.Show(z);
        //
        //
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetVote" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             // while (true)
        //             // {
        //             //     try
        //             //     {
        //             //         int byteSent = sender2.Send(messageSent);
        //             //         break;
        //             //     }
        //             //     catch (Exception e)
        //             //     {
        //             //         sender2.Connect(localEndPoint);
        //             //     }
        //             // }
        //
        //
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //
        //     return parametrsDictionary;
        // }


        // public static Dictionary<string, string> Submit_answer(string Answer , string qid)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //
        //         /*Socket sender2 = new Socket(ipAddr.AddressFamily,
        //                    */
        //         // SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //
        //             var parameters = new Dictionary<string, string>
        //             {
        //
        //               { "username", RibbonForm1.username },
        //               { "qid", qid },
        //               {"Describ" , Answer}
        //               
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             // MessageBox.Show(z);
        //
        //
        //             string fin = "<SSFINSS>";
        //
        //             byte[] messageSent = Encoding.ASCII.GetBytes("POST" + Setting.SplitChar + "/Postanswer" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             
        //
        //
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //
        //     return parametrsDictionary;
        // }


        // public static Dictionary<string, string> Get_Quesntion_Answer(Dictionary<string,string> parameters)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //
        //     string result = "";
        //     try
        //     {
        //
        //         //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //         //
        //         //
        //         // Socket sender2 = new Socket(ipAddr.AddressFamily,
        //         //            SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             //var parameters = new Dictionary<string, string>
        //             //{
        //             //  { "username", username },
        //             //  { "password", password }
        //             //};
        //             string z = Functions.UrlEncode(parameters);
        //             string fin = "<SSFINSS>";
        //             // MessageBox.Show("GET" + Setting.SplitChar + "/GetNQuestionAnswer" + Setting.SplitChar + z +
        //             //                 Setting.SplitChar + fin);
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetNQuestionAnswer" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // byte[] messageReceived = new byte[4096];
        //             //
        //             // // We receive the message using
        //             // // the method Receive(). This
        //             // // method returns number of bytes
        //             // // received, that we'll use to
        //             // // convert them to string
        //             // int byteRecv = sender2.Receive(messageReceived);
        //             // result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //
        //             //Console.WriteLine("Message from Server -> {0}",
        //             //      Encoding.ASCII.GetString(messageReceived,
        //             //                                 0, byteRecv));
        //
        //             // Close Socket using
        //             // the method Close()
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //             MessageBox.Show("SocketException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             // Console.WriteLine("SocketException : {0}", se.ToString());
        //
        //             MessageBox.Show("SocketException : " + se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //             MessageBox.Show("SocketException : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         //Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //     return parametrsDictionary;
        // }


        // public static Dictionary<string, string> Delete_Answer(string aid)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //
        //     string result = "";
        //     try
        //     {
        //
        //         //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //         //
        //         //
        //         // Socket sender2 = new Socket(ipAddr.AddressFamily,
        //         //            SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             var parameters = new Dictionary<string, string>
        //             {
        //               { "aid", aid }
        //               
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             string fin = "<SSFINSS>";
        //             // MessageBox.Show("GET" + Setting.SplitChar + "/GetNQuestionAnswer" + Setting.SplitChar + z +
        //             //                 Setting.SplitChar + fin);
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/DeleteAnswer" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // byte[] messageReceived = new byte[4096];
        //             //
        //             // // We receive the message using
        //             // // the method Receive(). This
        //             // // method returns number of bytes
        //             // // received, that we'll use to
        //             // // convert them to string
        //             // int byteRecv = sender2.Receive(messageReceived);
        //             // result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //
        //             //Console.WriteLine("Message from Server -> {0}",
        //             //      Encoding.ASCII.GetString(messageReceived,
        //             //                                 0, byteRecv));
        //
        //             // Close Socket using
        //             // the method Close()
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //             MessageBox.Show("SocketException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             // Console.WriteLine("SocketException : {0}", se.ToString());
        //
        //             MessageBox.Show("SocketException : " + se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //             MessageBox.Show("SocketException : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         //Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //     return parametrsDictionary;
        // }



        // public static Dictionary<string, string> Get_Tags()
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //         
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //         
        //         // Socket sender2 = new Socket(ipAddr.AddressFamily,
        //         //            SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             //var parameters = new Dictionary<string, string>
        //             //{
        //             //  { "username", username },
        //             //  { "password", password }
        //             //};
        //             //string z = Functions.UrlEncode(parameters);
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetTags" + Setting.SplitChar + fin);
        //             int byteSent = sender2.Send(messageSent);
        //
        //
        //
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //
        //             // Data buffer
        //             // byte[] messageReceived = new byte[1024];
        //             //
        //             // // We receive the message using
        //             // // the method Receive(). This
        //             // // method returns number of bytes
        //             // // received, that we'll use to
        //             // // convert them to string
        //             // int byteRecv = sender2.Receive(messageReceived);
        //             // result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //
        //             //Console.WriteLine("Message from Server -> {0}",
        //             //      Encoding.ASCII.GetString(messageReceived,
        //             //                                 0, byteRecv));
        //
        //             // Close Socket using
        //             // the method Close()
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             //Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         //Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     parametrsDictionary.Remove("number");
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //     return parametrsDictionary;
        // }



        // public static Dictionary<string, string> Get_Special_TagsQuestion(string tag)
        // {
        //     // if (QuestionsForm.t.IsAlive)
        //     // {
        //     //     QuestionsForm.t.Abort();
        //     // }
        //
        //     if (IsConnected(sender2) == false)
        //     {
        //         sender2.Shutdown(SocketShutdown.Both);
        //         sender2.Close();
        //         sender2 = new Socket(ipAddr.AddressFamily,
        //             SocketType.Stream, ProtocolType.Tcp);
        //         sender2.Connect(localEndPoint);
        //
        //     }
        //     string result = "";
        //     try
        //     {
        //
        //
        //         // IPAddress ipAddr = IPAddress.Parse(Setting.IP);
        //         // IPEndPoint localEndPoint = new IPEndPoint(ipAddr, Setting.Port);
        //
        //
        //         /*Socket sender2 = new Socket(ipAddr.AddressFamily,
        //                    */
        //         // SocketType.Stream, ProtocolType.Tcp);
        //
        //         try
        //         {
        //
        //             // sender2.Connect(localEndPoint);
        //
        //             // We print EndPoint information
        //             // that we are connected
        //             //Console.WriteLine("Socket connected to -> {0} ",
        //             //              sender2.RemoteEndPoint.ToString());
        //
        //             // Creation of message that
        //             // we will send to Server
        //             
        //             var parameters = new Dictionary<string, string>
        //             {
        //               { "tag", tag }
        //               
        //               // { "username", RibbonForm1.username },
        //             };
        //             string z = Functions.UrlEncode(parameters);
        //             // MessageBox.Show(z);
        //
        //
        //             string fin = "<SSFINSS>";
        //             byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetSpecialTagsQuestion" + Setting.SplitChar + z + Setting.SplitChar + fin);
        //             // while (true)
        //             // {
        //             //     try
        //             //     {
        //             //         int byteSent = sender2.Send(messageSent);
        //             //         break;
        //             //     }
        //             //     catch (Exception e)
        //             //     {
        //             //         sender2.Connect(localEndPoint);
        //             //     }
        //             // }
        //
        //
        //             int byteSent = sender2.Send(messageSent);
        //
        //             // Data buffer
        //             string a = "";
        //             while (a.Contains(fin) == false)
        //             {
        //                 byte[] messageReceived = new byte[100];
        //                 int byteRecv = sender2.Receive(messageReceived);
        //                 result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                 a += result;
        //
        //             }
        //
        //             a = Functions.Replace_Fin(a);
        //             result = a;
        //
        //
        //             // sender2.Shutdown(SocketShutdown.Both);
        //             // sender2.Close();
        //         }
        //
        //         // Manage of Socket's Exceptions
        //         catch (ArgumentNullException ane)
        //         {
        //
        //             Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //         }
        //
        //         catch (SocketException se)
        //         {
        //
        //             Console.WriteLine("SocketException : {0}", se.ToString());
        //         }
        //
        //         catch (Exception ee)
        //         {
        //             Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //         }
        //     }
        //
        //     catch (Exception re)
        //     {
        //
        //         Console.WriteLine(re.ToString());
        //     }
        //
        //     string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //     //var url = new Uri(ar[2]);
        //     //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //     //foreach (var VARIABLE in queryDictionary)
        //     //{
        //     //    MessageBox.Show(VARIABLE.ToString());
        //     //}
        //     Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //     parametrsDictionary = Functions.UrlDecode(ar[2]);
        //     //MessageBox.Show(queryDictionary.Get("number").ToString());
        //     //MessageBox.Show(queryDictionary.Keys[0].ToString());
        //     // if (QuestionsForm.t.IsAlive == false)
        //     // {
        //     //     QuestionsForm.t = new Thread(new ThreadStart(AlwaysClass.ThreadListenForUpdate));
        //     //     QuestionsForm.t.Start();
        //     // }
        //
        //     return parametrsDictionary;
        // }




    }
}
