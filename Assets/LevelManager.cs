using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode
{
    unset,
    play,
    pause,
    end,
}

public class LevelManager : MonoBehaviour
{
    public static int score = 0;
    public static bool endlessMode = false;
    public static float obstacleSpeed = 15.0f;

    [SerializeField]
    private GameObject endMenu;
    public static GameMode gameMode = GameMode.unset;

    [Header("Spawning Obstacles")]
    [SerializeField]
    private GameObject[] upObstacles;
    [SerializeField]
    private GameObject[] downObstacles;
    [SerializeField]
    private Transform spawnUpLocation;
    [SerializeField]
    private Transform spawnDownLocation;

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
        gameMode = GameMode.unset;
    }

    public float timeSplice = 5.0f;
    public float currentTime = 0f;
    void Update()
    {
        if (gameMode == GameMode.play)
        {
            UpdateText();
            //TODO: Code for spawning
            if (currentTime >= timeSplice)
            {
                SpawnObstacle();
                currentTime = 0f;
            }
            else
            {
                currentTime += Time.deltaTime;
            }

            //Make game harder
            timeSplice -= 0.0001f;
            if (timeSplice < 0.7f) { timeSplice = 0.7f; }

            obstacleSpeed += 0.0002f;
            if (obstacleSpeed > 75f) { obstacleSpeed = 75f; }
        }

        if (gameMode == GameMode.end)
        {
            EndGame();
        }
    }

    #region Display Update
    private void ResetDisplay()
    {
        //Reset every display
        scoreDisplay.text = " Score: ";
        endScoreDisplay.text = "Score: ";
        endHiscoreDisplay.text = "Hi Score: ";
    }

    public void UpdateText()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    #endregion Code to manipulate the UI display 

    #region Game Control
    public void PlayGame()
    {
        gameMode = GameMode.play;
    }

    public void ToggleGameMode()
    {
        endlessMode = !endlessMode;
    }

    public void PauseGame()
    {
        gameMode = GameMode.pause;
    }

    public void EndGame()
    {
        gameMode = GameMode.unset;
        endMenu.SetActive(true);
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
    #endregion

    int lastLocation;
    int repeat = 0;
    public void SpawnObstacle()
    {
        int location = Random.Range(0, 2); //Which location to spawn it at(Up or Down)
        if (lastLocation == location)
        {
            repeat += 1;
            if (repeat > 2)
            {
                if(location == 1) 
                { 
                    location = 0; 
                }
                else if (location == 0)
                { 
                    location = 1; 
                }
                repeat = 0;
            }
        }
        lastLocation = location;

        if(location == 0)
        {
            //Spawn at Up Location
            int obj = Random.Range(0, upObstacles.Length);
            GameObject obs = Instantiate(upObstacles[obj], spawnUpLocation) as GameObject;
        }
        else
        {
            //Spawn at Down Location
            int obj = Random.Range(0, downObstacles.Length);
            GameObject obs = Instantiate(downObstacles[obj], spawnDownLocation) as GameObject;
        }
    }
}
