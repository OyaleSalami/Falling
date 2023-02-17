using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        if (LevelManager.gameMode == GameMode.play)
        {
            transform.Translate(new Vector2(-5, 0) * LevelManager.obstacleSpeed * Time.deltaTime);
        }
    }
}
