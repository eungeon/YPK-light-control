from socket import *

ip = '127.0.0.1'
port = 3000

clientCocket = socket(AF_INET, SOCK_STREAM)

print('Connecting...')
clientCocket.connect((ip, port))
print('Connected.')

clientCocket.send('L200200200'.encode('utf-8'))
print('sent')

data = clientCocket.recv(1024)
print("Received data : " + data.decode("utf-8"))

clientCocket.close()