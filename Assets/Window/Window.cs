using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Runtime.InteropServices;

//Scott Cooper 100580683
//Lucas Harvey 100585553
//Kenneth Ho 100583602

//This is the window class with a controller image

public class ControllerWindow : EditorWindow {



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
    private Texture2D controllerTexture;
    private Texture2D circleTexture;

    //A: 0, B: 1, Y: 2, X: 3, RB: 4, LB: 5, Start: 6, Back: 7, RS: 8, LS: 9

    public int controllerCount = 4;

    struct ControllerInput
    {
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
    }

    private ControllerInput[] controller;
    
    [MenuItem("Window/Controller Window")]
	// Use this for initialization
	public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(ControllerWindow));
	}


    void OnGUI()
    {

        //Draw controller (Googled xbox one controller. Its from https://ebgames.com.au/xbox-one-217314-Xbox-One-S-Wireless-Controller-Xbox-One
        EditorGUI.DrawTextureTransparent(new Rect(0, 0, 528, 297), controllerTexture);

        //Draw a circle over every input, also put a number based on what controller number it is
        for (int i = 0; i < controllerCount; i++)
        {


            if (controller[i].inputA) drawCircle(344, 85, i);
            if (controller[i].inputY) drawCircle(344, 36, i);
            if (controller[i].inputX) drawCircle(320, 60, i);
            if (controller[i].inputB) drawCircle(369, 62, i);

            if (controller[i].inputLeftStick) drawCircle(159 + (controller[i].leftStickX * 5.0f), 60 + (controller[i].leftStickY * -5.0f), i);
            if (controller[i].inputRightStick) drawCircle(300 + (controller[i].rightStickX * 5.0f), 115 + (controller[i].rightStickY * -5.0f), i);

            if (controller[i].inputDpadRight) drawCircle(226, 119, i);
            if (controller[i].inputDpadLeft) drawCircle(180, 119, i);
            if (controller[i].inputDpadDown) drawCircle(204, 139, i);
            if (controller[i].inputDpadUp) drawCircle(204, 97, i);


            if (controller[i].inputBack) drawCircle(229, 60, i);
            if (controller[i].inputStart) drawCircle(279, 60, i);

            if (controller[i].rightTrigger != 0.0f) drawCircle(350, 0, i);
            if (controller[i].leftTrigger != 0.0f) drawCircle(154, 0, i);

            if (controller[i].inputRB) drawCircle(345, 10, i);
            if (controller[i].inputLB) drawCircle(159, 10, i);

        }


        Repaint();
    }

    void drawCircle(float x, float y, int player)
    {
        EditorGUI.DrawTextureTransparent(new Rect(x, y, 25, 25), circleTexture);
        EditorGUI.LabelField(new Rect(x, y, 25, 25), (player + 1).ToString());

    }

    // Use this for initialization
    void Awake()
    {
        controller = new ControllerInput[controllerCount];

       controllerTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Images/Xbox One Controller.jpg", typeof(Texture2D));
       circleTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Images/Circle.png", typeof(Texture2D));

        for (int i = 0; i < controllerCount; i++)
        {


            //Default values
            controller[i].inputA = false;
            controller[i].inputB = false;
            controller[i].inputX = false;
            controller[i].inputY = false;

            controller[i].inputStart = false;
            controller[i].inputBack = false;

            controller[i].inputLeftStick = false;
            controller[i].inputRightStick = false;

            controller[i].inputDpadRight = false;
            controller[i].inputDpadLeft = false;
            controller[i].inputDpadUp = false;
            controller[i].inputDpadDown = false;
            controller[i].inputRB = false;
            controller[i].inputLB = false;

            controller[i].rightTrigger = 0.0f;
            controller[i].leftTrigger = 0.0f;

            controller[i].leftStickX =0.0f;
            controller[i].leftStickY = 0.0f;

            controller[i].rightStickX = 0.0f;
            controller[i].rightStickY = 0.0f;
        }

        createControllers(4);

        Debug.Log("created controllers");
        
    }

    // Update is called once per frame
    public void Update()
    {
        updateControllers();

        //Get all new inputs for every controller
        for (int i = 0; i < controllerCount; i++)
        {

            //A: 0, B: 1, Y: 2, X: 3, RB: 4, LB: 5, Start: 6, Back: 7, RS: 8, LS: 9
            controller[i].inputA = getButton(i, 0);
            controller[i].inputB = getButton(i, 1);
            controller[i].inputY = getButton(i, 2);
            controller[i].inputX = getButton(i, 3);

            controller[i].inputRB = getButton(i, 4);
            controller[i].inputLB = getButton(i, 5);

            controller[i].inputStart = getButton(i, 6);
            controller[i].inputBack = getButton(i, 7);

            controller[i].inputRightStick = getButton(i, 8);
            controller[i].inputLeftStick = getButton(i, 9);

            controller[i].leftStickX = getThumbstick(i, 0);
            controller[i].leftStickY = getThumbstick(i, 1);

            controller[i].rightStickX = getThumbstick(i, 2);
            controller[i].rightStickY = getThumbstick(i, 3);

            controller[i].leftTrigger = getTrigger(i, 0);
            controller[i].rightTrigger = getTrigger(i, 1);

            controller[i].inputDpadUp = getDpad(i, 0);
            controller[i].inputDpadDown = getDpad(i, 1);
            controller[i].inputDpadRight = getDpad(i, 2);
            controller[i].inputDpadLeft = getDpad(i, 3);
            
        }
    }

    public void OnDestroy()
    {
        removeControllers();

        Debug.Log("removed controllers");
    }
}
