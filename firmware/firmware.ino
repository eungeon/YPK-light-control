volatile char rx_buff;
unsigned char rgb[3], rgb_buff[10];
volatile int rx_cnt, rx_flg;

int rgbPin[3] = {5, 6, 7};

void setup() {
  // put your setup code here, to run once:
  for(int i=0; i<3; i++) pinMode(rgbPin[i],HIGH);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  digitalWrite(13,HIGH);
  
  if(Serial.available()){
    rx_buff = Serial.read();
    if(rx_buff == 'L') rx_cnt = 0;
    rgb_buff[rx_cnt++] = rx_buff;
  }

  
  if(rx_cnt >= 10){
    rx_cnt = 0;
    rgb[0] = (rgb_buff[1]-'0')*100 + (rgb_buff[2]-'0')*10 + (rgb_buff[3]-'0');
    rgb[1] = (rgb_buff[4]-'0')*100 + (rgb_buff[5]-'0')*10 + (rgb_buff[6]-'0');
    rgb[2] = (rgb_buff[7]-'0')*100 + (rgb_buff[8]-'0')*10 + (rgb_buff[9]-'0');

    Serial.print(rgb[0]);
    Serial.print(" ");
    Serial.print(rgb[1]);
    Serial.print(" ");
    Serial.println(rgb[2]);
    for(int i=0; i<3; i++){
      analogWrite(rgbPin[i], rgb[i]);  
    }
  }
  
}
