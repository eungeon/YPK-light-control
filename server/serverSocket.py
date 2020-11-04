#from socket import *
from socket import *
from select import *

import json                                                 # import for parsing data
import serial                                               # import for communicating arduino 
import time                                                 # import for delay
import sys                                                  # import for shutdown

SER_PORT = '/dev/ttyACM0'                                   # Arduino PORT
SER_BUADRATE = 9600                                         # Communicate baud rate

SVR_HOST = '0.0.0.0'
SVR_PORT = 3000                                             # SERVER Listening PORT

def LED_Init():
    for _ in range(0,3):
        ser.write(bytes('L255255255'.encode()))                      # Send Arduino
        time.sleep(0.05)
        ser.write(bytes('L000000000'.encode()))                      # Send Arduino
        time.sleep(0.05)

print("Connecting Arudino...")
try:
    ser = serial.Serial(SER_PORT, SER_BUADRATE, timeout = 1)# Serial(Arduino) Open
except serial.SerialException as e:
    print('Port Open failed')
    print(e)
    sys.exit()

time.sleep(1)                                               # delay
print("Connected Arduino.")
print("============")
LED_Init()


serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind((SVR_HOST, SVR_PORT))
serverSocket.listen(1)     
print('Listening on {0} PORT.'.format(SVR_PORT))

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

                try:
                    ser.write(bytes(data))                               # Send Arduino
                except serial.SerialException as e:
                    print('Port communicate failed')
                    print(e)
                    sys.exit()

                sock.send("data".encode("utf-8"))
                print("sent")

                if data.decode('utf-8') == 'disconn':
                    socketList.remove(sock)
                    print('disconnected')
                    break
                
    except ConnectionResetError:
        socketList.remove(sock)
        print('client exited')
        try:
            ser.write(bytes('L000000000'.encode()))                               # Send Arduino
        except serial.SerialException as e:
            print('Port communicate failed')
            print(e)
            sys.exit()

    except ConnectionAbortedError:
        socketList.remove(sock)
        print('client not found')
        try:
            ser.write(bytes('L000000000'.encode()))                               # Send Arduino
        except serial.SerialException as e:
            print('Port communicate failed')
            print(e)
            sys.exit()

    except KeyboardInterrupt:
        #socketList.remove(sock)
        serverSocket.close()
        print('Ctrl+C Pressed. Program end.')
        try:
            ser.write(bytes('L000000000'.encode()))                               # Send Arduino
        except serial.SerialException as e:
            print('Port communicate failed')
            print(e)
            sys.exit()
        sys.exit()


# app = Flask(__name__)                                       # Flask define

# # LED Setting URL
# @app.route('/', methods=['POST'])                           
# def setLed():
#     print(request.form)
    
#     if not(request.form.has_key('R') and request.form.has_key('G') and request.form.has_key('B')):
#         print('error')
#         abort(404)
        
#     r = int(request.form['R'])
#     g = int(request.form['G'])
#     b = int(request.form['B'])
#     str = 'L{0:0>3}{1:0>3}{2:0>3}'.format(r,g,b)            # Protocol -> L255255255 (R,G,B)(0~255)
#     print(str)
#     try:
#         ser.write(bytes(str))                               # Send Arduino
#     except serial.SerialException as e:
#         print('Port communicate failed')
#         print(e)
#         sys.exit()

#     return 'LED Setted R:{0}, G:{1}, B:{2}'.format(r,g,b)

# # Check Application connect URL
# @app.route('/check', methods=['GET'])
# def checkConn():
#     return "ok"

# # Open Server
# if __name__ == "__main__":
#     app.run(host='0.0.0.0', port=SVR_PORT, debug=True)
