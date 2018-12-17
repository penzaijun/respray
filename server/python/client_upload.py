import socket
import time
import struct
import os

sc=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
address=('104.224.129.246',10000)
sc.connect(address)
while True:
	file_path="MissionTest.json"
	file_info_size=struct.calcsize('128sl')
	sc.send(struct.pack('c','u'))
	fhead=struct.pack('128sl',os.path.basename(file_path),os.stat(file_path).st_size)
	sc.send(fhead)
	print("sending file : ",file_path)
	fo=open(file_path,'rb')
	while True:
		fileData=fo.read(1024)
		if not fileData:
			break;
		else:
			sc.send(fileData)
	fo.close()
	print("sending finished...")
	sc.close()
	exit()