using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Renderer area;
    public float speed;
    private Renderer thisArea;
    private bool isPatrol;
    private Vector3 NextPosition;

    // Start is called before the first frame update
    void Start()
    {
        thisArea = GetComponent<Renderer>();
        isPatrol = false;
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("Min Area : " + GetMinArea());
            Debug.Log("Max Area : " + GetMaxArea());
        }
    }

    public void Patrolling() {
        if (isPatrol) {
            transform.position = Vector3.MoveTowards(transform.position, NextPosition, speed * Time.deltaTime);
        
            if (Vector3.Distance(transform.position, NextPosition) < 0.3f) {
                isPatrol = false;
            }
        } else {
            NextPosition = new Vector3(GetNextPositionX(), transform.position.y , GetNextPositionZ());
            transform.LookAt(NextPosition);
            isPatrol = true;
        }
    }

    public float GetNextPositionX() {
        return Random.Range(GetMinArea().x, GetMaxArea().x);
    }

    public float GetNextPositionZ() {
        return Random.Range(GetMinArea().z, GetMaxArea().z);
    }

    public Vector3 GetMinArea() {
        return (area.transform.position - area.bounds.extents) + thisArea.bounds.extents;
    }

    public Vector3 GetMaxArea() {
        return (area.transform.position + area.bounds.extents) - thisArea.bounds.extents;
    }
}
