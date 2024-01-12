using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looks : MonoBehaviour
{
    [SerializeField] private GameObject starFlare;
    [SerializeField] private Camera camera;

    private float low = 5f;
    private float high = 15f;
    private float timer = 0f;
    private float waitTime;

    private void Start()
    {
        waitTime = Random.Range(low, high);
    }

    private void Update()
    {
        if (timer > waitTime)
        {
            Spawn();
            timer = 0;
            waitTime = Random.Range(low, high);
        }
        timer += Time.deltaTime;
    }

    private void Spawn()
    {
        float distanceFromCamera = camera.nearClipPlane; // Change this value if you want
        Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, distanceFromCamera));
        Vector3 bottomRight = camera.ViewportToWorldPoint(new Vector3(1, 0, distanceFromCamera));

        float x = Random.Range(topLeft.x, bottomRight.x);
        float y = Random.Range(bottomRight.y, topLeft.y);

        GameObject starFlareRef = Instantiate(starFlare, new Vector3(x, y, distanceFromCamera), Quaternion.identity);
        Destroy(starFlareRef, Random.Range(0.1f, 0.3f));
    }
}
