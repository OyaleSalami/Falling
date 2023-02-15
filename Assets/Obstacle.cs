using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(-5, 0) * LevelManager.obstacleSpeed * Time.deltaTime);
    }
}
