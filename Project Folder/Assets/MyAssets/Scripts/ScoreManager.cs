using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public OrderManager orderManager;
    public ButtonManager buttonManager;
    public GameManager gameManager;
    public GameObject correctEffects;

    public TextMeshProUGUI currentScoreUI;

    [HideInInspector]
    public float score = 0;
    [HideInInspector]
    public float level = 0;
    public void SetScore()
    {
        if (gameManager.currentLevel != 0)
        {
            if (orderManager.OrderColor == buttonManager.BoxToDeliver.GetComponent<Renderer>().material.GetColor("_Color"))
            {
                Instantiate(correctEffects,buttonManager.BoxToDeliver.transform.position, correctEffects.transform.rotation);
                score++;
                currentScoreUI.text = "Score: " + score;
            }
            else
            {
                gameManager.life--;
                if (gameManager.life <= 0)
                {
                    gameManager.ResetGame();
                }
            }

            level++;
            if (level >= 5)
            {
                level = 0;
                score += 5;
                currentScoreUI.text = "Score: " + score;
            }
            gameManager.UpdateStatusUI();
        }

    }
}
