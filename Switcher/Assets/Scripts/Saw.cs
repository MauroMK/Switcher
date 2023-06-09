using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentWP = 0;

    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWP].position) < 0.1f)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        Vector3 direction = (waypoints[currentWP].position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

}
