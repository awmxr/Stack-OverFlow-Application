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
    class AlwaysClass
    {
        // public static void ThreadListenForUpdate()
        // {
        //     while (true)
        //     {
        //         
        //         Thread.Sleep(2000);
        //
        //         string result = "";
        //         try
        //         {
        //
        //
        //
        //
        //             Socket sender2 = GetClass.sender2;
        //
        //             try
        //             {
        //
        //
        //                 // sender2.Connect(localEndPoint);
        //
        //
        //                 // var parameters2 = new Dictionary<string, string>
        //                 // {
        //                 //   { "username", username },
        //                 //   { "password", password }
        //                 // };
        //
        //                 var parameters = new Dictionary<string, string>();
        //
        //
        //                 // string z = Functions.UrlEncode();
        //                 if (Functions.UpdateList.Contains("Questions"))
        //                 {
        //                     parameters["Questions"] = "1";
        //                 }
        //                 if(Functions.UpdateList.Contains("Tags"))
        //                 {
        //                     parameters["Tags"] = "1";
        //                 }
        //
        //                 int i2 = 0;
        //                 foreach (var x in Functions.UpdateList)
        //                 {
        //                     if (x == "Questions")
        //                     {
        //                         continue;
        //                     }
        //                     if (x == "Tags")
        //                     {
        //                         continue;
        //                     }
        //
        //                     parameters["Qid" + i2] = x;
        //                     i2++;
        //                 }
        //                 string z = Functions.UrlEncode(parameters);
        //
        //
        //
        //                 byte[] messageSent = Encoding.ASCII.GetBytes("GET" + Setting.SplitChar + "/GetUpdate" + Setting.SplitChar + z + Setting.fin);
        //                 int byteSent = sender2.Send(messageSent);
        //
        //
        //
        //
        //
        //                 string a = "";
        //                 while (a.Contains(Setting.fin) == false)
        //                 {
        //                     byte[] messageReceived = new byte[100];
        //                     int byteRecv = sender2.Receive(messageReceived);
        //                     result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //                     a += result;
        //                     // MessageBox.Show(a);
        //
        //                 }
        //
        //                 a = Functions.Replace_Fin(a);
        //                 MessageBox.Show(a);
        //                 result = a;
        //                 
        //
        //
        //
        //
        //
        //
        //
        //                 // Data buffer
        //                 // byte[] messageReceived = new byte[1024];
        //                 //
        //                 // // We receive the message using
        //                 // // the method Receive(). This
        //                 // // method returns number of bytes
        //                 // // received, that we'll use to
        //                 // // convert them to string
        //                 // int byteRecv = sender2.Receive(messageReceived);
        //                 // result = Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        //
        //                 //Console.WriteLine("Message from Server -> {0}",
        //                 //      Encoding.ASCII.GetString(messageReceived,
        //                 //                                 0, byteRecv));
        //
        //                 // Close Socket using
        //                 // the method Close()
        //                 // sender2.Shutdown(SocketShutdown.Both);
        //                 // sender2.Close();
        //             }
        //
        //             // Manage of Socket's Exceptions
        //             catch (ArgumentNullException ane)
        //             {
        //
        //                 //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //             }
        //
        //             catch (SocketException se)
        //             {
        //
        //                 //Console.WriteLine("SocketException : {0}", se.ToString());
        //             }
        //
        //             catch (Exception ee)
        //             {
        //                 //Console.WriteLine("Unexpected exception : {0}", ee.ToString());
        //             }
        //         }
        //
        //         catch (Exception re)
        //         {
        //
        //             //Console.WriteLine(re.ToString());
        //         }
        //
        //
        //
        //
        //         string[] ar = result.Split(new string[] { Setting.SplitChar }, StringSplitOptions.None);
        //         //var url = new Uri(ar[2]);
        //         //var queryDictionary = System.Web.HttpUtility.ParseQueryString(ar[2]);
        //
        //         //foreach (var VARIABLE in queryDictionary)
        //         //{
        //         //    MessageBox.Show(VARIABLE.ToString());
        //         //}
        //         Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
        //         parametrsDictionary = Functions.UrlDecode(ar[2]);
        //         List<string> keyList = new List<string>(parametrsDictionary.Keys);
        //         if (keyList.Contains("Questions"))
        //         {
        //             // 
        //         }
        //
        //
        //     }
        //
        //
        //
        //
        //
        // }
    }
    }

