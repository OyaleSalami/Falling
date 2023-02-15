using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            rb.gravityScale = rb.gravityScale * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            Debug.Log("Hit An Obstacle");
            //Game Over
        }
    }
}
