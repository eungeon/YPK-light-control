from socket import *
import sys

host = '0.0.0.0'
port = 3000

try:
    while True:
        serverSocket = socket(AF_INET, SOCK_STREAM)
        serverSocket.bind((host, port))
        serverSocket.listen(1)        
        print('Listening on {0} PORT.'.format(port))

        connSocket,addr = serverSocket.accept()
        print("Connection from " + str(addr))

        while True:
            data = connSocket.recv(10)
            print("Received data : " + data.decode("utf-8"))

            if data.decode('utf-8') == 'disconn':
                serverSocket.close()
                print('disconnected')
                break

            connSocket.send("server msg".encode("utf-8"))
            print("sent")

except KeyboardInterrupt:
    print('Exit')
    serverSocket.close()
    sys.exit()