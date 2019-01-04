using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.NetworkInformation;
public class InteractWithServer:MonoBehaviour
    {
        public GameObject tips;
        private static byte[] result = new byte[1024];
        private static Socket sc;
        void Start(){
            tips=GameObject.Find("Tips");
        }
        public IEnumerator myWait(){
            yield return new WaitForSeconds(2f);
            tips.GetComponent<Text>().text="";
        }
        public IEnumerator DownloadCoroutine(){
            yield return null;
            IPAddress ip = IPAddress.Parse("104.224.129.246");
            sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sc.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReceiveTimeout,1000);
            try
            {
                tips.SetActive(true);
                tips.GetComponent<Text>().text="正在连接中...";
                if (Application.internetReachability== NetworkReachability.NotReachable)                
                {   
                    throw new Exception();
                } 
                sc.Connect(ip, 10000);
                tips.GetComponent<Text>().text="下载成功.";            
                StartCoroutine(myWait());
                Debug.Log("连接成功！");
                sc.Send(Encoding.UTF8.GetBytes("d"));
                sc.Receive(result,sizeof(int),0);
                int length=(result[0])|(result[1]<<8)|(result[2]<<16)|(result[3]<<24);
                Debug.Log("统计接受文件数目...");
                for (int i=1;i<=length;i++){
                    sc.Receive(result,128+sizeof(int),0);
                    string str=System.Text.Encoding.ASCII.GetString(result,0,127);
                    int filesize=(result[128])|(result[129]<<8)|(result[130]<<16)|(result[131]<<24);
                    int k=0;while (str[k]!='\0')k++;
                    string filename=@".\Assets\Data\Download\" + str.Substring(0,k);
                    Debug.Log("第"+i+"个文件：" + filename);
                    Debug.Log("文件大小："+filesize);
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
                Debug.Log("接受完毕 按任意键退出");
                sc.Close();
                GameObject ob=GameObject.Find("MyMapPanel");
                ob.GetComponent<LoadLocalMaps>().LoadMaps();
            }
            catch (Exception e)
            {
                Debug.Log("连接失败！");
                tips.GetComponent<Text>().text="连接失败，请稍后再试";   
                StartCoroutine(myWait());
            }
        }
        public void Download()
        {
            StartCoroutine(DownloadCoroutine());
        }
        public IEnumerator pingTest(){                
            System.Net.NetworkInformation.Ping ping=new System.Net.NetworkInformation.Ping();
            PingReply pr=ping.Send("61.135.169.105");
            yield return new WaitForSeconds(1f);
            if (pr.Status==IPStatus.TimedOut){
                throw new Exception();
            }
        }
        public IEnumerator uploadCoroutine(string fileName){
            yield return null;
            IPAddress ip = IPAddress.Parse("104.224.129.246");
            sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sc.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReceiveTimeout,1000);

            try
            {
                tips.SetActive(true);
                tips.GetComponent<Text>().text="正在连接中...";
                //StartCoroutine(pingTest());
                if (Application.internetReachability== NetworkReachability.NotReachable)                
                {   
                    throw new Exception();
                } 
                sc.Connect(ip, 10000);
                tips.GetComponent<Text>().text="上传成功.";            
                StartCoroutine(myWait());
                Debug.Log("连接成功！");
                sc.Send(Encoding.UTF8.GetBytes("u"));
                FileInfo fileInfo=new FileInfo(@".\Assets\Data\Mymap\"+fileName);
                int fileSize=(int)fileInfo.Length;
                Debug.Log(fileSize);
                //sc.Receive(result,sizeof(int),0);
                byte[] fhead=System.Text.Encoding.UTF8.GetBytes(fileName);
                sc.Send(fhead);for (int i=fhead.Length;i<128;i++) sc.Send(System.Text.Encoding.UTF8.GetBytes("\0"));
                sc.Send(BitConverter.GetBytes(fileSize));
                FileStream fileReader=new FileStream(@".\Assets\Data\Mymap\"+fileName,FileMode.Open);
                int j = 0;
                while (true){
                    int ret=fileReader.Read(result,0,1024);
                    Debug.Log((j++).ToString()) ;
                    if (ret!=0) sc.Send(result); else break;
                }
                fileReader.Close();
                sc.Close();
            }
            catch (Exception e)
            {
                Debug.Log("连接失败！");
                tips.GetComponent<Text>().text="连接失败，请稍后再试";   
                StartCoroutine(myWait());
            }
        }
        public void Upload(string fileName)
        {
            StartCoroutine(uploadCoroutine(fileName));
        }
    }