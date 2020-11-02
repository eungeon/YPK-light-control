#define BAUD_RATE 9600                              // Serial communication Speed
int rgbPin[3] = {5, 6, 7};                          // R,G,B LED Pin number

volatile char rx_buff, rx_cnt;                      // Serial communication buffer
unsigned char rgb[3], rgb_buff[10];                 // RGB data and buffer

/*
Protocol
Data:     L    0    0    0    0    0    0    0    0    0
Mean: Header  R100  R10  R1  G100  G10  G1  B100  B10  B1
idx :     0    1    2    3    4    5    6    7    8    9
*/

void setup() {
  // put your setup code here, to run once:
  for(int i=0; i<3; i++) pinMode(rgbPin[i],HIGH);   // R,G,B LED Pin I/O setting
  Serial.begin(BAUD_RATE);                          // Serial communicaion begin 
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()){
    rx_buff = Serial.read();
    if(rx_buff == 'L') rx_cnt = 0;                  // Detect packet header ('L')
    rgb_buff[rx_cnt++] = rx_buff;
  }
  
  // Data parsing
  if(rx_cnt >= 10){
    rx_cnt = 0;
    rgb[0] = (rgb_buff[1]-'0')*100 + (rgb_buff[2]-'0')*10 + (rgb_buff[3]-'0');  // R data
    rgb[1] = (rgb_buff[4]-'0')*100 + (rgb_buff[5]-'0')*10 + (rgb_buff[6]-'0');  // G data
    rgb[2] = (rgb_buff[7]-'0')*100 + (rgb_buff[8]-'0')*10 + (rgb_buff[9]-'0');  // B data

/*  Serial.print(rgb[0]);
    Serial.print(" ");
    Serial.print(rgb[1]);
    Serial.print(" ");
    Serial.println(rgb[2]);*/

    for(int i=0; i<3; i++){
      analogWrite(rgbPin[i], rgb[i]);               // LED ON (R,G,B)
    }
  }
  
}
