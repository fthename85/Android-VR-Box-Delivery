using UnityEngine;
using TMPro;

public class GameManager : SingletonScript<GameManager>
{

    public GameObject cubePrefab;
    public ScoreManager scoreManager;
    public OrderManager orderManager;
    public BoxManager boxManager;
    public Transform MainTransform;
    [HideInInspector]
    public int life = 3, currentLevel = 1;
    [HideInInspector]
    public float currentScore, currentTime = 999.0f;
    public TextMeshProUGUI highScoreUI, currentScoreUI, previousScoreUI, currentTimeUI, currentLifeUI, currentLevelUI;
    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
        else
        {
            highScoreUI.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString();
        }
        if (!PlayerPrefs.HasKey("PreviousScore"))
        {
            PlayerPrefs.SetFloat("PreviousScore", 0);
        }
        else
        {
            previousScoreUI.text = "Previous Score: " + PlayerPrefs.GetFloat("PreviousScore").ToString();
        }
    }
    void Update()
    {
        OnAccelerometer();
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            currentTimeUI.text = "Time remaining: " + ((int)currentTime).ToString();
        }else{
            ResetGame();
        }
    }

    public void ResetGame()
    {
        currentLevel = 0;
        currentScore = scoreManager.score;
        scoreManager.score = 0;
        life = 3;
        scoreManager.level = 0;
        currentTime = 999;
        orderManager.sanityLevel = 999;
        PlayerPrefs.SetFloat("PreviousScore", currentScore);
        currentScoreUI.text = "Score: " + 0;
        if (currentScore > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }
    }
    public void UpdateStatusUI()
    {
        currentLifeUI.text = "Current Life: " + life.ToString();
    }
    void OnAccelerometer()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            MainTransform.Rotate(Input.acceleration.x, Input.acceleration.y, 0);
        }
    }
    int DivBy10 = 0;
    public void LevelHandler()
    {
        currentLevel++;
        DivBy10++;
        if(DivBy10 >= 10)
        {
            DivBy10 = 0;
            boxManager.FirstLoad();
        }
        currentLevelUI.text = "Current Level: " + currentLevel.ToString();
    }
}
