import socket
import SocketServer
import struct
import os

address=("",10000)

class MyRequestHandler(SocketServer.BaseRequestHandler):
    def recv_upload(self):
        fileinfo_size=struct.calcsize('128sl') #传输信息大小 fileinfo_size=132bytes，128string+int文件名+文件大小
        self.buf=self.request.recv(fileinfo_size) #获取远程的文件信息
        if self.buf:
            self.filename,self.filesize=struct.unpack('128sl',self.buf)
            print("filename and size : ",self.filename.strip('\00'),self.filesize)
            self.filename=os.path.join('UD/new'+self.filename.strip('\00'))#解包操作
            recvd_size=0
            file=open(self.filename,'wb')
            print("start receiving data..") #1024bytes分段接受远程信息
            while not recvd_size==self.filesize:
                if self.filesize-recvd_size > 1024:
                    rdata=self.request.recv(1024)
                    recvd_size+=len(rdata)
                else:
                    rdata=self.request.recv(self.filesize-recvd_size)
                    recvd_size=self.filesize
                file.write(rdata)
            file.close() # 文件写到服务器上存储后结束
            print('data.....finish')
    def send_pre_installed_file(self):
        files=[]
        sc=self.request
        fileinfo_size=struct.calcsize('128sl')
        for maindir,subdir,file_name_list in os.walk('missions'): #枚举远程文件信息
            for filename in file_name_list:
                apath=os.path.join(maindir,filename)
                files.append(apath)
        sc.send(struct.pack('l',len(files)))
        for eachfile in files:
            fhead=struct.pack('128sl',os.path.basename(eachfile),os.stat(eachfile).st_size)
            sc.send(fhead) #发送文件头信息 128string + int 
            print("sending file : ",eachfile)
            fo=open(eachfile,'rb') # 1024bytes分段发送信息
            while True:
                fileData=fo.read(1024)
                if not fileData:
                    break;
                else:
                    sc.send(fileData)
            fo.close()
    def handle(self):
        print("connect from : ",self.client_address)
        req=self.request.recv(struct.calcsize('c'))
        if req=='u':
            self.recv_upload()
        if req=='d':
            self.send_pre_installed_file()
if __name__ == '__main__':
    tcpSever=SocketServer.ThreadingTCPServer(address,MyRequestHandler)
    print('waiting...')
    tcpSever.serve_forever()
