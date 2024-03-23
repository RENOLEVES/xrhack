using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour
{
    public Transform target; // Reference to the big ball

    public float speed = 2f; // Floating speed

    void Update()
    {
        if (target != null)
        {
            // Move towards the target (big ball)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}

