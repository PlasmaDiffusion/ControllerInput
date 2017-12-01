using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Runtime.InteropServices;


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
        //GUILayout.Label(controllerTexture);


        EditorGUI.DrawTextureTransparent(new Rect(0, 0, 528, 297), controllerTexture);

        for (int i = 0; i < controllerCount; i++)
        {


            if (controller[i].inputA)
            {
                EditorGUI.DrawTextureTransparent(new Rect(340, 100, 25, 25), circleTexture);
                EditorGUI.LabelField(new Rect(340, 100, 25, 25), (i + 1).ToString());
            }


        
        }


        Repaint();
    }

    // Use this for initialization
    void Awake()
    {
        controller = new ControllerInput[controllerCount];

       controllerTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Images/Xbox One Controller.jpg", typeof(Texture2D));
       circleTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Images/Circle.png", typeof(Texture2D));

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
