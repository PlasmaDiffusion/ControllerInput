using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

//Scott Cooper 100580683
//Lucas Harvey 100585553
//Kenneth Ho 100583602

public class InputGetter : MonoBehaviour {

    //Script for the demo. Uses input plugin

    [DllImport("InputPlugin")]
    public static extern void createControllers(int amount);
    [DllImport("InputPlugin")]
    public static extern void updateControllers();
    [DllImport("InputPlugin")]
    public static extern bool getButton(int player, int button);
    [DllImport("InputPlugin")]
    public static extern bool getDpad(int player, int button);
    [DllImport("InputPlugin")]
    public static extern float getThumbstick(int player, int axis);
    [DllImport("InputPlugin")]
    public static extern float getTrigger(int player, int trigger);
    [DllImport("InputPlugin")]
    public static extern void removeControllers();

    private bool inputA;
    private bool inputB;
    private bool inputX;
    private bool inputY;
    
    private bool inputStart;
    private bool inputBack;
    
    private bool inputLeftStick;
    private bool inputRightStick;
    
    private bool inputDpadRight;
    private bool inputDpadLeft;
    private bool inputDpadUp;
    private bool inputDpadDown;
    
    private bool inputRB;
    private bool inputLB;
    
    private float rightTrigger;
    private float leftTrigger;
    
    private float leftStickX;
    private float leftStickY;
    
    private float rightStickX;
    private float rightStickY;

    private Transform childA;
    private Transform childB;
    private Transform childY;
    private Transform childX;
    private Transform childRB;
    private Transform childLB;
    private Transform childStart;
    private Transform childBack;
    private Transform childRS;
    private Transform childLS;
    private Transform childUp;
    private Transform childDown;
    private Transform childRight;
    private Transform childLeft;
    private Transform childRT;
    private Transform childLT;


    // Use this for initialization
    void Start () {
        childA = transform.GetChild(0);
        childB = transform.GetChild(1);
        childY = transform.GetChild(2);
        childX = transform.GetChild(3);
        childRB = transform.GetChild(4);
        childLB = transform.GetChild(5);
        childStart = transform.GetChild(6);
        childBack = transform.GetChild(7);
        childRS = transform.GetChild(8);
        childLS = transform.GetChild(9);
        childUp = transform.GetChild(10);
        childDown = transform.GetChild(11);
        childRight = transform.GetChild(12);
        childLeft = transform.GetChild(13);
        childLT = transform.GetChild(14);
        childRT = transform.GetChild(15);
        createControllers(1);
	}
	
	// Update is called once per frame
	void Update () {
        updateControllers();

        //A: 0, B: 1, Y: 2, X: 3, RB: 4, LB: 5, Start: 6, Back: 7, RS: 8, LS: 9
        inputA = getButton(0, 0);
        inputB = getButton(0, 1);
        inputY = getButton(0, 2);
        inputX = getButton(0, 3);

        inputRB = getButton(0, 4);
        inputLB = getButton(0, 5);

        inputStart = getButton(0, 6);
        inputBack = getButton(0, 7);

        inputRightStick = getButton(0, 8);
        inputLeftStick = getButton(0, 9);

        leftStickX = getThumbstick(0, 0);
        leftStickY = getThumbstick(0, 1);

        rightStickX = getThumbstick(0, 2);
        rightStickY = getThumbstick(0, 3);

        leftTrigger = getTrigger(0, 0);
        rightTrigger = getTrigger(0, 1);

        inputDpadUp = getDpad(0, 0);
        inputDpadDown = getDpad(0, 1);
        inputDpadRight = getDpad(0, 2);
        inputDpadLeft = getDpad(0, 3);

        //Transform objects in the scene from inputs
        transformButton(childA, inputA);
        transformButton(childB, inputB);
        transformButton(childY, inputY);
        transformButton(childX, inputX);

        transformButton(childRB, inputRB);
        transformButton(childLB, inputLB);

        transformButton(childStart, inputStart);
        transformButton(childBack, inputBack);

        transformButton(childRS, inputRightStick);
        transformButton(childLS, inputLeftStick);

        transformButton(childUp, inputDpadUp);
        transformButton(childDown, inputDpadDown);
        transformButton(childRight, inputDpadRight);
        transformButton(childLeft, inputDpadLeft);


        transformStickR(childRS, rightStickX, rightStickY);
        transformStickL(childLS, leftStickX, leftStickY);

        transformTrigger(childRT, rightTrigger);
        transformTrigger(childLT, leftTrigger);

        
    }

    void transformButton(Transform t, bool pressed)
    {
        if(pressed)t.position = new Vector3(t.position.x, -0.25f, t.position.z);
        else t.position = new Vector3(t.position.x, 0.25f, t.position.z);
    }

    void transformStickR(Transform t, float x, float y)
    {
        t.transform.position = new Vector3(10.25f + x, t.transform.position.y, -5.25f + y);
    }

    void transformStickL(Transform t, float x, float y)
    {
        t.transform.position = new Vector3(-10.25f + x, t.transform.position.y, 5.25f + y);
    }

    void transformTrigger(Transform t, float amount)
    {
        t.transform.localPosition = new Vector3(-0.6f + amount, t.transform.localPosition.y, t.transform.localPosition.z);
    }

    void OnDestroy()
    {
        removeControllers();
    }

}
