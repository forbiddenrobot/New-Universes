using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private GameObject ex;

    private void Start()
    {
        Invoke("Death", 5f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            ex = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(ex, 1f);
            Destroy(gameObject);
            return;
        }
    }

    private void Death()
    {
        ex = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(ex, 1f);
        Destroy(gameObject);
        return;
    }

}
