using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderManager : MonoBehaviour
{

    public TextMeshProUGUI OrderUI;
    public BoxManager boxManager;
    public enum myColor
    {
        Green,
        Blue,
        Cyan,
        Red,
        Black,
        Magenta,
        Yellow,
        Orange,
        Brown
    }
    [HideInInspector]
    myColor OrderColorName;
    public Color OrderColor;
    public ScoreManager scoreManager;
    public GameManager gameManager;
    public TextMeshProUGUI customerSanityLevelUI;
    [HideInInspector]
    public float sanityLevel = 15;
    public bool isJustLoaded = true;

    public void ReduceCustomerSanity()
    {
        if (!isJustLoaded)
        {
            if (sanityLevel >= 0)
            {
                sanityLevel -= Time.deltaTime;
                customerSanityLevelUI.text = ((int)sanityLevel).ToString();
            }
            else
            {
                sanityLevel = 15;
                GameObject boxToDeliver = GameObject.FindGameObjectWithTag("BoxToDeliver");
                Destroy(boxToDeliver);
                gameManager.life -= 1;
                gameManager.UpdateStatusUI();
                if(gameManager.life < 1)
                {
                    
                    gameManager.ResetGame();
                }
            }

        }
    }
    void Update()
    {
        ReduceCustomerSanity();
    }

    void GetButtonColor(Color color)
    {
        for (int i = 0; i < boxManager.boxColorList.Count; i++)
        {
            if (color == boxManager.boxColorList[i])
            {
                OrderColorName = (myColor)i;
                break;
            }
        }
    }

    int buttonNumber;
    public void SetRandomOrder()
    {
        buttonNumber = Random.Range(0, 4);
        switch (buttonNumber)
        {
            case 0:
                GetButtonColor(boxManager.buttonAColor);
                OrderColor = boxManager.buttonAColor;
                OrderUI.text = OrderColorName.ToString();
                break;
            case 1:
                GetButtonColor(boxManager.buttonBColor);
                OrderColor = boxManager.buttonBColor;
                OrderUI.text = OrderColorName.ToString();
                break;
            case 2:
                GetButtonColor(boxManager.buttonCColor);
                OrderColor = boxManager.buttonCColor;
                OrderUI.text = OrderColorName.ToString();
                break;
            case 3:
                GetButtonColor(boxManager.buttonDColor);
                OrderColor = boxManager.buttonDColor;
                OrderUI.text = OrderColorName.ToString();
                break;
        }
    }
}
