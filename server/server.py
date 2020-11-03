from flask import Flask, render_template, request, abort    # import for opening server
import json                                                 # import for parsing data
import serial                                               # import for communicating arduino 
import time                                                 # import for delay
import sys                                                  # import for shutdown

SER_PORT = '/dev/ttyACM0'                                   # Arduino PORT
SER_BUADRATE = 9600                                         # Communicate baud rate

SVR_PORT = 5000                                             # SERVER Listening PORT

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

app = Flask(__name__)                                       # Flask define

# LED Setting URL
@app.route('/', methods=['POST'])                           
def setLed():
    print(request.form)
    
    if not(request.form.has_key('R') and request.form.has_key('G') and request.form.has_key('B')):
        print('error')
        abort(404)
        
    r = int(request.form['R'])
    g = int(request.form['G'])
    b = int(request.form['B'])
    str = 'L{0:0>3}{1:0>3}{2:0>3}'.format(r,g,b)            # Protocol -> L255255255 (R,G,B)(0~255)
    print(str)
    try:
        ser.write(bytes(str))                               # Send Arduino
    except serial.SerialException as e:
        print('Port communicate failed')
        print(e)
        sys.exit()
        
    return 'LED Setted R:{0}, G:{1}, B:{2}'.format(r,g,b)

# Check Application connect URL
@app.route('/check', methods=['GET'])
def checkConn():
    return "ok"

# Open Server
if __name__ == "__main__":
    app.run(host='0.0.0.0', port=SVR_PORT, debug=True)
