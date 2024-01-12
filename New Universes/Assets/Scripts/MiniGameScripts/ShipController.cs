using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;

    [SerializeField] private Slider slider;
    [SerializeField] private GameObject parent;
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient;
    public TrailRenderer trail;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Transform firePointRight;
    [SerializeField] private Transform firePointLeft;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextFire;

    public float bulletForce = 20f;
    public static int bulletDamage = 1;

    [SerializeField] private GameObject explosion;
    private GameObject ex;

    private void Awake()
    {
        playerHealth = playerMaxHealth;
    }

    private void Start()
    {
        slider.maxValue = playerMaxHealth;
        slider.value = playerHealth;
        fill.color = gradient.Evaluate(1f);
    }

    void Shoot()
    {
        GameObject rightBullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        GameObject leftBullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);

        Rigidbody2D rbR = rightBullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rbL = leftBullet.GetComponent<Rigidbody2D>();

        rbR.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
        rbL.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
            if (trail.enabled == false)
            {
                trail.enabled = true;
            }
        }

        else if (Input.GetKey("s"))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            transform.position += -transform.up * Time.deltaTime * moveSpeed;
            if (trail.enabled == true)
            {
                trail.enabled = false;
            }
        }

        if (Input.GetKey("d"))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * rotationSpeed, Space.World);
        }

        else if (Input.GetKey("a"))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed, Space.World);
        }

        if (Input.GetMouseButton(0) && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "PlayerBullet")
        {
            if (collision.collider.tag == "EnemyBullet")
            {
                playerHealth -= 1;
                slider.value = playerHealth;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                HealthCheck();
            }
            else if (collision.collider.tag == "Enemy")
            {
                Death();
            }
        }
    }

    private void HealthCheck()
    {
        if (playerHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        ex = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(ex, 1f);
        Destroy(parent);
        Destroy(gameObject);
    }
}
