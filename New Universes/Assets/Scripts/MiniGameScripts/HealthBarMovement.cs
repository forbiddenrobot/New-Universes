using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMovement : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float posYOffset;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y - posYOffset, 0);
    }
}
