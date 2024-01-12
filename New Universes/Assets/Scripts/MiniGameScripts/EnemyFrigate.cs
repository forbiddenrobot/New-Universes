using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrigate : MonoBehaviour
{

    [SerializeField] private GameObject parent;
    [SerializeField] private float value;

    [SerializeField] private GameObject explosion;
    private GameObject ex;

    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float shootingRange;
    [SerializeField] private float runningRange;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;

    [SerializeField] private List<Transform> firePoints;

    private float nextFire = 0f;
    [SerializeField] private float fireRate = 1f;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector2 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if (Vector2.Distance(transform.position, player.transform.position) > shootingRange)
        {
            transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime, Space.Self);
        }
        else
        {
            if (Vector2.Distance(transform.position, player.transform.position) < runningRange)
            {
                transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime, Space.Self);
            }
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < firePoints.Count; i++)
        {
            GameObject Bullet = Instantiate(bulletPrefab, firePoints[i].position, transform.rotation);
            Rigidbody2D bRb = Bullet.GetComponent<Rigidbody2D>();
            bRb.AddForce(firePoints[i].up * bulletForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            Death();
        }
        else if (collision.collider.tag == "Player")
        {
            Death();
        }
    }

    private void Death()
    {
        MiniGameMaster.moneyMadeMiniGame += value * GameMaster.coinsPerSec;
        ex = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(ex, 1f);
        Destroy(parent);
        Destroy(gameObject);
    }
}
