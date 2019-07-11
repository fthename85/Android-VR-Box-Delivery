using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public OrderManager orderManager;
    [HideInInspector]
    public List<Color> boxColorList = new List<Color>();

    public GameObject buttonACube, buttonBCube, buttonCCube, buttonDCube;

    public Color buttonAColor
    {
        get { return buttonACube.GetComponent<Renderer>().material.GetColor("_Color"); }
        set { buttonACube.GetComponent<Renderer>().material.SetColor("_Color", value); }
    }
    public Color buttonBColor
    {
        get { return buttonBCube.GetComponent<Renderer>().material.GetColor("_Color"); }
        set { buttonBCube.GetComponent<Renderer>().material.SetColor("_Color", value); }
    }
    public Color buttonCColor
    {
        get { return buttonCCube.GetComponent<Renderer>().material.GetColor("_Color"); }
        set { buttonCCube.GetComponent<Renderer>().material.SetColor("_Color", value); }
    }
    public Color buttonDColor
    {
        get { return buttonDCube.GetComponent<Renderer>().material.GetColor("_Color"); }
        set { buttonDCube.GetComponent<Renderer>().material.SetColor("_Color", value); }
    }

    private int buttonsCount = 4;
    public Color Orange;
    public Color Brown;


    void Start()
    {
        #region adding colors
        boxColorList.Add(Color.green);
        boxColorList.Add(Color.blue);
        boxColorList.Add(Color.cyan);
        boxColorList.Add(Color.red);
        boxColorList.Add(Color.black);
        boxColorList.Add(Color.magenta);
        boxColorList.Add(Color.yellow);
        boxColorList.Add(Orange);
        boxColorList.Add(Brown);
        #endregion

        FirstLoad();
    }

    Color[] ChooseColorSet(int numRequired)
    {
        Color[] result = new Color[numRequired]; // initializing result array

        int numToChoose = numRequired; // how many colors from list to choose

        for (int numLeft = boxColorList.Count; numLeft > 0; numLeft--) // iterating backwards
        {
            float prob = (float)numToChoose / (float)numLeft; // calculating probability (0, 1) for next item to be chosen

            if (Random.value <= prob) // if item is chosen
            {
                numToChoose--; // we need to choose one item less

                result[numToChoose] = boxColorList[numLeft - 1];

                if (numToChoose == 0) // if all required items are chosen - break
                {
                    break;
                }
            }
        }
        // shuffling result array, so items won't be in the same order they had in the original array
        for (int i = 0; i < result.Length; i++)
        {
            int randomIndex = Random.Range(0, result.Length);
            Color temp = result[i];
            result[i] = result[randomIndex];
            result[randomIndex] = temp;
        }

        return result;
    }


    public void FirstLoad()
    {
        Color[] buttonColors = ChooseColorSet(buttonsCount); // unqiue random colors for buttons

        for (int i = 0; i < buttonsCount; i++)
        {
            ChangeButtonColor(i, buttonColors[i]); // changing color for one button at a time
            if (i >= buttonsCount)
            {
                orderManager.SetRandomOrder();
            }
        }
    }

    void ChangeButtonColor(int buttonToChangeNumber, Color randomColor)
    {
        switch (buttonToChangeNumber)
        {
            case 0:
                buttonAColor = randomColor;
                break;
            case 1:
                buttonBColor = randomColor;
                break;
            case 2:
                buttonCColor = randomColor;
                break;
            case 3:
                buttonDColor = randomColor;
                break;
        }
    }

    public void ChangeButton()
    {
        int buttonToChangeNumber = Random.Range(0, buttonsCount); // random button number

        for (int i = 0; i < boxColorList.Count; i++)
        {
            if (IsColorUnique(boxColorList[i])) // if other button have different color
            {
                ChangeButtonColor(buttonToChangeNumber, boxColorList[i]); // change to new color
                break;
            }
        }
    }

    bool IsColorUnique(Color color)
    {
        return color != buttonAColor &&
            color != buttonBColor &&
            color != buttonCColor &&
            color != buttonDColor;
    }
}