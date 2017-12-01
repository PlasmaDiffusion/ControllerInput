using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Runtime.InteropServices;


public class ControllerWindow : EditorWindow {



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
    private Texture2D controllerTexture;
    private Texture2D circleTexture;

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

    bool guiA;
    bool guiB;

    float trig;

    [MenuItem("Window/Controller Window")]
	// Use this for initialization
	public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(ControllerWindow));
	}


    void OnGUI()
    {
        //GUILayout.Label(controllerTexture);


        if (inputA) EditorGUI.DrawTextureTransparent(new Rect(340, 100, 25, 25), circleTexture);
        EditorGUI.DrawTextureTransparent(new Rect(0, 0, 528, 297), controllerTexture);

        Repaint();
    }

    // Use this for initialization
    void Awake()
    {
     
       controllerTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Images/Xbox One Controller.jpg", typeof(Texture2D));
       circleTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Images/Circle.png", typeof(Texture2D));

        createControllers(1);
    }

    // Update is called once per frame
   public void Update()
    {
        updateControllers();

        inputA = getButton(0, 0);
        inputB = getButton(0, 1);

        rightTrigger = getTrigger(0, 1);
        
    }

    public void OnDestroy()
    {
        removeControllers();
    }
}
