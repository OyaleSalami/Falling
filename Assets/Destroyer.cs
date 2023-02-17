using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            LevelManager.score += 1;
            Destroy(collision.gameObject, 4f);
        }
    }
}
