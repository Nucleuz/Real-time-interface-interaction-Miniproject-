using UnityEngine;
using System.Collections;
using Uniduino;

public class ArduinoHandler : MonoBehaviour {

    public Player p;
    Arduino arduino;

    public int pinShoot = 2;
    public int pinShootValue;

    public int pinBuzzer = 3;

    public int pinDistanceSensor = 4;
    public float distanceSensorValue;

    public int testLed = 13;
    
    public bool useArduino = false;

    public Obstacle obstacle;


	// Use this for initialization
	void Start () {
        if(p == null)
        {
            Debug.Log("Please select the ArduinoHandler and dragNdrop the player into the P in the inspector.");
        }
        else
        {
            p.GetComponent<Player>();
        }
        
        if (useArduino)
        {
            arduino = Arduino.global;
            arduino.Setup(ConfigurePins);
        }
	}
	
	
	void ConfigurePins () {
        arduino.pinMode(pinShoot, PinMode.INPUT);
        arduino.reportDigital((byte)(pinShoot / 8), 1);
        // set the pin mode for the test LED on your board, pin 13 on an Arduino Uno
        arduino.pinMode(testLed, PinMode.OUTPUT);
        arduino.pinMode(pinDistanceSensor, PinMode.ANALOG);
        arduino.reportAnalog(pinDistanceSensor, 1);
    }

    void Update()
    {
        if (useArduino)
        {
            // read the value from the digital input
            pinShootValue = arduino.digitalRead(pinShoot);
            
            // apply that value to the test LED
            arduino.digitalWrite(testLed, pinShootValue);
            if (pinShootValue == 1)
            {
                p.Shoot();
            }

            if (p.hitByObject)
            {
                arduino.digitalWrite(pinBuzzer, Arduino.HIGH);
            }
            else
            {
                arduino.digitalWrite(pinBuzzer, Arduino.LOW);
            }

            
            distanceSensorValue = arduino.analogRead(pinDistanceSensor);
            p.SetVerticalPos(distanceSensorValue);
            Debug.Log(distanceSensorValue);
        }
        
    }
}
