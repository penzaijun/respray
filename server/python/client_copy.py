import socket
import time
import struct
import os

sc=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
address=('104.224.129.246',10000)
sc.connect(address)
while True:
	file_info_size=struct.calcsize('128sl')
	sc.send(struct.pack('c','d'))
	length=struct.unpack('l',sc.recv(struct.calcsize('l')))
	length=int(length[0])
	for i in range(length): 
		buf=sc.recv(file_info_size)
		filename,filesize=struct.unpack('128sl',buf) 
		print("receiving file: ",filename.strip('\00'),filesize)
		filename=os.path.join('missions/'+filename.strip('\00')) 
		recvd_size=0
		file=open(filename,'wb')
		print("start receiving data..")
		while not recvd_size==filesize:
			if filesize-recvd_size > 1024:
				rdata=sc.recv(1024)
				recvd_size+=len(rdata)
			else:
				rdata=sc.recv(filesize-recvd_size)
				recvd_size=filesize
			file.write(rdata)
		file.close()
		print("receiving finished...")
	sc.close()
	exit()