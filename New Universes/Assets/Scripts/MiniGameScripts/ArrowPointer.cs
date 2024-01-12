using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;

    private float closestDistance;
    private GameObject closestEnemy;

    // Update is called once per frame
    void Update()
    {
        enemyList.Clear();
        enemyList = new List<GameObject>((GameObject.FindGameObjectsWithTag("Enemy")));
        closestDistance = Mathf.Infinity;

        Vector3 myPos = GameObject.Find("Player").transform.position;
        foreach (GameObject enemy in enemyList)
        {
            float distance = Vector3.Distance(enemy.transform.position, myPos);
            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        Vector3 direction = closestEnemy.transform.position - myPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10000 * Time.deltaTime);
    }
}
