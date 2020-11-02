from flask import Flask, render_template, request           # import for opening server
import json                                                 # import for parsing data
import serial                                               # import for communicating arduino 
import time                                                 # import for delay

SER_PORT = '/dev/ttyACM0'                                   # Arduino PORT
SER_BUADRATE = 9600                                         # Communicate baud rate

SVR_PORT = 5000                                             # SERVER Listening PORT

print("Connecting Arudino...")
ser = serial.Serial(SER_PORT, SER_BUADRATE, timeout = 1)    # Serial(Arduino) Open
time.sleep(1)                                               # delay
print("Connected.")
pinr("============")

app = Flask(__name__)                                       # Flask define

# LED Setting URL
@app.route('/', methods=['POST'])                           
def setLed():
    rgb = [] * 3
    r = int(request.form['R'])
    g = int(request.form['G'])
    b = int(request.form['B'])
    str = 'L{0:0>3}{1:0>3}{2:0>3}'.format(r,g,b)            # Protocol -> L255255255 (R,G,B)(0~255)
    print(str)
    ser.write(bytes(str))                                   # Send Arduino
    return 'LED Setted R:{0}, G:{1}, B{2}'.format(r,g,b)

# Check Application connect URL
@app.route('/check', mothods=['GET'])
def checkConn():
    return "ok"

# Open Server
if __name__ == "__main__":
    app.run(host='0.0.0.0', port=SVR_PORT, debug=True)
