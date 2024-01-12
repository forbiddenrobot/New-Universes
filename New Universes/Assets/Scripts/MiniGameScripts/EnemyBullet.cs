using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private GameObject ex;
    private float timer = 0f;

    private void Start()
    {
        Invoke("Death", 5f);
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timer > 0.05f)
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
