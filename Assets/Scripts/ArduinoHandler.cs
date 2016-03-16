using UnityEngine;
using System.Collections;
using Uniduino;

public class ArduinoHandler : MonoBehaviour {

    public Player p;
    Arduino arduino;

    public int pinShoot = 2;
    public int pinShootValue;

    public int pinBuzzer = 3;

    public int pinPotentiometer = 4;
    public float pinPotentiometerValue;

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
        arduino.pinMode(pinPotentiometer, PinMode.ANALOG);
        arduino.reportAnalog(pinPotentiometer, 1);
    }

    void Update()
    {
        if (useArduino)
        {
            // read value from the digital input
            pinShootValue = arduino.digitalRead(pinShoot);
            
            // apply value to the test LED
            arduino.digitalWrite(testLed, pinShootValue);

            // Check if button is pressed
            if (pinShootValue == 1)
            {
                // shoot if button is pressed
                p.Shoot();
            }

            // Check if player gets hit by object
            if (p.hitByObject)
            {
                // activate buzzer if hit by object
                arduino.digitalWrite(pinBuzzer, Arduino.HIGH);
            }
            else
            {
                // keep buzzer disabled when we dont hit anything
                arduino.digitalWrite(pinBuzzer, Arduino.LOW);
            }

            // read value from the potentiometer
            pinPotentiometerValue = arduino.analogRead(pinPotentiometer);

            // set the players vertical position to the value from the potentiometer
            p.SetVerticalPos(pinPotentiometerValue);
            
        }
        
    }
}
