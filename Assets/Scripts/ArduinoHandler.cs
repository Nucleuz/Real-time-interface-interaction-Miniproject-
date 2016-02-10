using UnityEngine;
using System.Collections;
using Uniduino;

public class ArduinoHandler : MonoBehaviour {

    public Player p;
    Arduino arduino;

    public int pin = 2;
    public int pinValue;
    public int testLed = 13;
    public bool useArduino = false;

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
        arduino.pinMode(pin, PinMode.INPUT);
        arduino.reportDigital((byte)(pin / 8), 1);
        // set the pin mode for the test LED on your board, pin 13 on an Arduino Uno
        arduino.pinMode(testLed, PinMode.OUTPUT);
    }

    void Update()
    {
        if (useArduino)
        {
            // read the value from the digital input
            pinValue = arduino.digitalRead(pin);
            // apply that value to the test LED
            arduino.digitalWrite(testLed, pinValue);
            if (pinValue == 1)
            {
                p.Jump();
            }
        }
        
    }
}
