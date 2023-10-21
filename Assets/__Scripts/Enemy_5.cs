using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : Enemy 
{    [Header("Set in Inspector: Enemy_5")]
    public float trackDuration = 15f; // Duration to track the player
    public float trackingSpeed = 80f; 
    private float birthTime;

    private Vector3 targetPosition;
    private Vector3 postTrackingDirection;
    private bool isTrackingFinished = false;

    void Start()
    {
        birthTime = Time.time;
    }

    public override void Move()
    {
        // If we're still within the tracking duration
        if (Time.time - birthTime <= trackDuration)
        {
            GameObject hero = GameObject.FindGameObjectWithTag("Hero");
            if (hero != null)
            {
                targetPosition = hero.transform.position;
            }
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            // When tracking duration just finishes, record the direction
            if (!isTrackingFinished)
            {
                postTrackingDirection = (targetPosition - transform.position).normalized;
                isTrackingFinished = true;
            }

            // Move in the recorded direction
            transform.position += postTrackingDirection * speed * Time.deltaTime;
        }
        if (!bndCheck.isOnScreen)
        {
            Destroy(gameObject);
        }
    }
}
