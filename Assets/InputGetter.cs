using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class InputGetter : MonoBehaviour {

    [DllImport("ControllerInput")]
    public static extern void createControllers(int amount);
    [DllImport("ControllerInput")]
    public static extern void updateControllers();
    [DllImport("ControllerInput")]
    public static extern bool getButton(int player, int button);
    [DllImport("ControllerInput")]
    public static extern bool getDpad(int player, int button);
    [DllImport("ControllerInput")]
    public static extern float getThumbstick(int player, int axis);
    [DllImport("ControllerInput")]
    public static extern float getTrigger(int player, int trigger);
    [DllImport("ControllerInput")]
    public static extern void removeControllers();

    public bool inputA;
    public bool inputB;
    public bool inputX;
    public bool inputY;

    public bool inputStart;
    public bool inputBack;

    public bool inputLeftStick;
    public bool inputRightStick;

    public bool inputDpadRight;
    public bool inputDpadLeft;
    public bool inputDpadUp;
    public bool inputDpadDown;

    public bool inputRB;
    public bool inputLB;

    public float rightTrigger;
    public float leftTrigger;

    public float leftStickX;
    public float leftStickY;

    public float rightStickX;
    public float rightStickY;

    // Use this for initialization
    void Start () {
        createControllers(1);
	}
	
	// Update is called once per frame
	void Update () {
        updateControllers();

        inputA = getButton(0, 0);
        
	}

    void OnDestroy()
    {
        removeControllers();
    }

}
