using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWaypoint : MonoBehaviour
{
    public Transform[] waypoints;
    public PatrolType patrolType;
    public bool isPatrol;
    public float speed;
    public Transform destination;

    int currentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartPatrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPatrol) return;

        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination.position) <= 0.1f) {
            destination = SelectWaypoint(patrolType);
            transform.LookAt(destination);
        } 
    }

    public void StartPatrol() {
        if (waypoints.Length <= 0) return;
        isPatrol = true; 
        destination = SelectWaypoint(patrolType);
    }

    public Transform SelectWaypoint(PatrolType type) {
        if(type == PatrolType.Random) {
            return waypoints[Random.Range(0, waypoints.Length - 1)];
        } else {
            if (currentWaypointIndex >= waypoints.Length) {
                ResetPatrol();
                return waypoints[currentWaypointIndex];
            } else {
                return waypoints[currentWaypointIndex++];
            }
        }
    }

    public void ResetPatrol() {
        currentWaypointIndex = 0;
    }
}

public enum PatrolType {
    Random,
    Sequential,
}