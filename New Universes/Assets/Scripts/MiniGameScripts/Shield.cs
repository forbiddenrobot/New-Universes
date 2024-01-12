using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    private float nextUse = 0f;
    private float waitTime = 60f;

    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;
    private bool shieldActive = false;

    private float timeLeft;
    private float timeEnd;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        nextUse = 0f;

        slider.maxValue = waitTime;
        slider.value = waitTime - nextUse;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(8, 10);

        if (shieldActive == false)
        {
            timeLeft = nextUse - Time.time;

            if (timeLeft > 0)
            {
                slider.value = waitTime - timeLeft;
            }
            else
            {
                slider.value = waitTime;
            }
        }
        else
        {
            timeLeft = timeEnd - Time.time;
            slider.value = timeLeft;
        }

        if (Input.GetMouseButton(1) && Time.time >= nextUse)
        {
            nextUse = Time.time + waitTime;
            SpawnShield();
            Invoke("DestroyShield", 5f);
            timeEnd = Time.time + 5f;
        }
    }

    void SpawnShield()
    {
        shield.SetActive(true);
        shieldActive = true;
        slider.maxValue = 5;
    }

    void DestroyShield()
    {
        shield.SetActive(false);
        shieldActive = false;
        slider.maxValue = waitTime;
    }
}
