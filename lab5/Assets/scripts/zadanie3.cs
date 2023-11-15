using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 1.8f;
    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private bool isPlatformMoving = false;

    void Start()
    {
        InitializePlatformPosition();
    }

    void Update()
    {
        if (isPlatformMoving && waypoints.Count > 0)
        {
            MovePlatformToWaypoint();
        }
    }

    private void InitializePlatformPosition()
    {
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0];
        }
    }

    private void MovePlatformToWaypoint()
    {
        Vector3 targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 moveDirection = (targetWaypoint - transform.position).normalized;
        transform.position += speed * Time.deltaTime * moveDirection;

        if (Vector3.Distance(transform.position, targetWaypoint) < 0.1f)
        {
            HandleWaypointReached();
        }
    }

    private void HandleWaypointReached()
    {
        if (movingForward)
        {
            HandleMovingForward();
        }
        else
        {
            HandleMovingBackward();
        }
    }

    private void HandleMovingForward()
    {
        if (currentWaypointIndex >= waypoints.Count - 1)
        {
            Debug.Log("Moving backwards");
            movingForward = false;
            currentWaypointIndex = waypoints.Count - 2;
        }
        else
        {
            currentWaypointIndex++;
        }
    }

    private void HandleMovingBackward()
    {
        if (currentWaypointIndex <= 0)
        {
            Debug.Log("At the start");
            currentWaypointIndex = 1;
            movingForward = true;
            isPlatformMoving = false;
        }
        else
        {
            currentWaypointIndex--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the platform.");
            isPlatformMoving = true;
        }
    }
}