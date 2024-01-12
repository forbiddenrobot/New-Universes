using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    public void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1) * rotationSpeed * Time.deltaTime);
    }
}
