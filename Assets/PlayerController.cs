using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bodies;

    private Rigidbody2D rb;
    private AudioSource sd;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sd = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown == true)
        {
            rb.gravityScale = rb.gravityScale * -1;
            sd.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            if (LevelManager.endlessMode == true)
            {
                //Change Shape
                if (bodies[0].activeSelf == true)
                {
                    bodies[0].SetActive(false);
                    bodies[1].SetActive(true);
                }
                else
                {
                    bodies[0].SetActive(true);
                    bodies[1].SetActive(false);
                }
            }
            else
            {
                //Game Over
            }
        }
    }
}
