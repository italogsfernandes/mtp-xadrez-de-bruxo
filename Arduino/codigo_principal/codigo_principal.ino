//Codigo de controle do sistema
//Autores: Italo, Jones.



#define A pinos[0]
#define B pinos[1]
#define C pinos[2]
#define D pinos[3]

int i;
int pinos[4] = {
  3, 4, 5, 6};

void setup()
{
  for(i=0;i<4;i++){
    pinMode(pinos[i], OUTPUT);
  }
  Serial.begin(9600);  //inicia comunicação serial com 9600
  Serial.println("Configuracoes realizada");

}

void loop()
{
  if(Serial.available())        //se algum dado disponível
  {
    delay(1000);
    char c = Serial.read();   //le o byte disponivel para avalia-lo
    Serial.println("Sinal recebido");
    if(c == 'z'){ //avalia sinal
      mover(60, 's', 50);
    }
  }
}

void mover(int n, char modo, int time){
  //modos: s para single, h para half, d para double
  if(modo == 's')
  {
    for(i = 0; i<n;i++){
      Serial.print("AD-");
      digitalWrite(A, 1);
      digitalWrite(B, 0);
      digitalWrite(C, 0);
      digitalWrite(D, 1);
      delay(time);
      Serial.print("BD-");
      digitalWrite(A, 0);
      digitalWrite(B, 1);
      digitalWrite(C, 0);
      digitalWrite(D, 1);
      delay(time);
      Serial.print("BC-");
      digitalWrite(A, 0);
      digitalWrite(B, 1);
      digitalWrite(C, 1);
      digitalWrite(D, 0);
      delay(time);
      Serial.println("AC-");
      digitalWrite(A, 1);
      digitalWrite(B, 0);
      digitalWrite(C, 1);
      digitalWrite(D, 0);
      delay(time);
    }
    Serial.println("OFF");
    digitalWrite(A, LOW);
    digitalWrite(B, LOW);
    digitalWrite(C, LOW);
    digitalWrite(D, LOW);
    delay(time);
  }


}
//TODO: controle do servo motor
//Referencias: http://blog.filipeflop.com/motores-e-servos/controlando-motor-de-passo-5v-28byj-48-com-motor-shield.html
//http://www.arduinoecia.com.br/2014/08/ponte-h-l298n-motor-de-passo.html
//http://www.arduinoecia.com.br/2013/11/ligando-motor-de-passo-28byj-48-e.html

