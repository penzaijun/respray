using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

    class client
    {
        private static byte[] result = new byte[1024];
        private static Socket sc;
        static void Main(string[] args)
        {

            IPAddress ip = IPAddress.Parse("104.224.129.246");
            sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sc.Connect(ip, 10000);
                Console.WriteLine("连接成功！");

            }
            catch (Exception e)
            {
                Console.WriteLine("连接失败！");
                return;
            }
            sc.Send(Encoding.UTF8.GetBytes("d"));
            sc.Receive(result,sizeof(int),0);
            int length=(result[0])|(result[1]<<8)|(result[2]<<16)|(result[3]<<24);
            Console.WriteLine("统计接受文件数目...");
            for (int i=1;i<=length;i++){
                sc.Receive(result,128+sizeof(int),0);
                string str=System.Text.Encoding.ASCII.GetString(result,0,127);
                int filesize=(result[128])|(result[129]<<8)|(result[130]<<16)|(result[131]<<24);
                int k=0;while (str[k]!='\0')k++;
                string filename=str.Substring(0,k);
                Console.WriteLine("第"+i+"个文件：" + filename);
                Console.WriteLine("文件大小："+filesize);
                int recvd_size=0;
                FileStream file=new FileStream(filename,FileMode.Create);
                while (recvd_size!=filesize){
                    if (filesize-recvd_size>1024){
                        sc.Receive(result,1024,0);
                        file.Write(result,0,1024);
                        recvd_size+=1024;
                    }
                    else{
                        sc.Receive(result,filesize-recvd_size,0);
                        file.Write(result,0,filesize-recvd_size);
                        recvd_size=filesize;
                    }
                }
                file.Close();
            }
            Console.WriteLine("接受完毕 按任意键退出");
            Console.ReadKey();
            sc.Close();
        }
    }