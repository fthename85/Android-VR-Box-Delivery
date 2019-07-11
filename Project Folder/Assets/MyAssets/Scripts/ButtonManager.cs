using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public BoxManager boxManager;
    public OrderManager orderManager;
    public GameManager gameManager;
    public ScoreManager scoreManager;
    public GameObject buttonUI, uiHolder, CameraUIHolder;
    void Start()
    {
        material = GameObject.FindGameObjectWithTag("BoxToDeliver").GetComponent<Renderer>().material;
    }
    void Update()
    {
        ButtonFunction();
    }
    #region ButtonKeyMap
    KeyCode buttonA = KeyCode.JoystickButton3,
    buttonB = KeyCode.JoystickButton0,
    buttonC = KeyCode.JoystickButton2,
    buttonD = KeyCode.JoystickButton1,
    R1 = KeyCode.JoystickButton5,
    R2 = KeyCode.JoystickButton4;
    #endregion endButtonKeyMap

    #region of ButtonInputFunctions
    public void ButtonFunction()
    {

        bool num1 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Keypad1);
        bool num2 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Keypad2);
        bool num3 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Keypad3);
        bool num4 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Keypad4);
        bool num5 = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Keypad5);
        //Letter button

        if (Input.GetKeyDown(buttonA) || num1)
        {
            ButtonAFunction();
        }
        else if (Input.GetKeyDown(buttonB) || num2)
        {
            ButtonBFunction();
        }
        else if (Input.GetKeyDown(buttonC) || num3)
        {
            ButtonCFunction();
        }
        else if (Input.GetKeyDown(buttonD) || num4)
        {
            ButtonDFunction();
        }
        if (Input.GetKeyDown(R1) || num5)
        {
            ButtonR1Function();
        }

        if (Input.GetKey(R2) || Input.GetKey(KeyCode.Keypad6))
        {
            ButtonR2DownFunction();
        }
        else if (Input.GetKeyUp(R2) || Input.GetKeyUp(KeyCode.Keypad6))
        {
            ButtonR2UpFunction();
        }
    }
    #endregion of ButtonInputFunctions

    [HideInInspector]
    public Material material;
    //[HideInInspector]
    public GameObject BoxToDeliver;
    public GameObject OrderUI;
    void ButtonAFunction()
    {
        if (boxManager.buttonAColor != new Color(0, 0, 0, 0))
        {
            material.SetColor("_Color", boxManager.buttonAColor);
        }
        Debug.Log("ButtonAFunction");
    }
    void ButtonBFunction()
    {
        if (boxManager.buttonBColor != new Color(0, 0, 0, 0))
        {
            material.SetColor("_Color", boxManager.buttonBColor);
        }
        Debug.Log("ButtonBFunction");
    }
    void ButtonCFunction()
    {
        if (boxManager.buttonCColor != new Color(0, 0, 0, 0))
        {
            material.SetColor("_Color", boxManager.buttonCColor);
        }
        Debug.Log("ButtonCFunction");
    }
    void ButtonDFunction()
    {
        if (boxManager.buttonDColor != new Color(0, 0, 0, 0))
        {
            material.SetColor("_Color", boxManager.buttonDColor);
        }
        Debug.Log("ButtonDFunction");
    }
    void ButtonR1Function()
    {
        gameManager.LevelHandler();
        orderManager.sanityLevel = 15;
        scoreManager.SetScore();
        Destroy(BoxToDeliver);
        boxManager.ChangeButton();
        orderManager.SetRandomOrder();
        Debug.Log("R1 button is pressed");
        
    }
    Transform originalParent;
    void ButtonR2DownFunction()
    {
        uiHolder.SetActive(true);
      // uiHolder.transform.SetParent(null);
        OrderUI.SetActive(false);
        Debug.Log("ButtonR2DownFunction");
    }
    void ButtonR2UpFunction()
    {
        OrderUI.SetActive(true);
       // uiHolder.transform.SetParent(CameraUIHolder.transform);
        uiHolder.transform.SetPositionAndRotation(CameraUIHolder.transform.position, CameraUIHolder.transform.rotation);
        uiHolder.SetActive(false);
        Debug.Log("ButtonR2UpFunction");
    }
}