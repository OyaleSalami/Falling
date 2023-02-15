using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Destroyed Object");
        if(collision.gameObject.tag == "obstacle")
        {
            LevelManager.score += 1;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(collision.gameObject, 5f);
            Debug.Log("Destroyed Object");
        }
    }
}
