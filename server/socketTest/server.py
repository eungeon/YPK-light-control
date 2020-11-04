from socket import *
from select import *

import sys

host = '0.0.0.0'
port = 3000

serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind((host, port))
serverSocket.listen(1)     
print('Listening on {0} PORT.'.format(port))

socketList = [serverSocket]

while True:
    try:
        r_socket, w_socket, e_socket = select(socketList, [], [], 1)
        
        for sock in r_socket :
            if sock == serverSocket :
                clientSocket, clientAddress = serverSocket.accept()
                socketList.append(clientSocket)
                print("Connection from " + str(clientAddress))

            else :
                data = sock.recv(30)
                print("Received data : " + data.decode("utf-8"))
                sock.send("data".encode("utf-8"))
                print("sent")

                if data.decode('utf-8') == 'disconn':
                    socketList.remove(sock)
                    print('disconnected')
                    break
                
    except ConnectionResetError:
        socketList.remove(sock)
        print('client exited')

    except ConnectionAbortedError:
        socketList.remove(sock)
        print('client not found')

    except KeyboardInterrupt:
        #socketList.remove(sock)
        serverSocket.close()
        print('Ctrl+C Pressed. Program end.')
        sys.exit()

    
    

    # # connSocket,addr = serverSocket.accept()
    # serverSocket.settimeout(1)
    # while True:
    #     try :
    #         try :
    #             connSocket,addr = serverSocket.accept()
    #             print("connected")
    #         except timeout :
    #             continue
    #         else:
    #             break
    #     except KeyboardInterrupt:
    #         serverSocket.close()
    #         print('Exit')
    #         sys.exit()

    # print("Connection from " + str(addr))

    # while True:
    
    #     data = connSocket.recv(10)
    #     print("Received data : " + data.decode("utf-8"))

    #     if data.decode('utf-8') == 'disconn':
    #         serverSocket.close()
    #         print('disconnected')
    #         break

    #     connSocket.send("server msg".encode("utf-8"))
    #     print("sent")
