using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Game Details")]
    public static int score = 0;
    public static bool endlessMode = false;
    public static int obstacleSpeed = 15;

    [Header("Spawning Obstacles")]
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private Transform[] spawnLocation;

    [Header("UI Control")] 
    [SerializeField]
    private Text scoreDisplay;
    [SerializeField]
    private Text endScoreDisplay;
    [SerializeField]
    private Text endHiscoreDisplay;

    void Start()
    {
        ResetDisplay();
        //Check if the Hi Score already exists, if not, create it
        if (!PlayerPrefs.HasKey("hi_score"))
        {
            PlayerPrefs.SetInt("hi_score", 0);
        }
    }

    void Update()
    {
        //TODO: Code for spawning
    }

    private void ResetDisplay()
    {
        //Reset every display
        scoreDisplay.text = " Score: ";
        endScoreDisplay.text = "Score: ";
        endHiscoreDisplay.text = "Hi Score: ";
    }

    public void EndGame()
    {
        if (score >= PlayerPrefs.GetInt("hi_score"))
        {
            PlayerPrefs.SetInt("hi_score", score);
        }

        endScoreDisplay.text = "Score: " + score.ToString();
        endHiscoreDisplay.text = "Hi Score: " + PlayerPrefs.GetInt("hi_score").ToString();
    }

    public void RestartGame()
    {
        score = 0;
        ResetDisplay();
    }

    public void UpdateText()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    public void SpawnObstacle()
    {
        int obj = Random.Range(0, obstacles.Length-1); //What object to spawn
        int location = Random.Range(0, spawnLocation.Length); //Which location to spawn it at

        GameObject obs = Instantiate(obstacles[obj], spawnLocation[location]) as GameObject;
    }
}
