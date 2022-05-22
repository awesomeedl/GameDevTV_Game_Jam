using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public List<Transform> waypoints;
    Transform currentWaypoint;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        if(Vector2.Distance(transform.position, currentWaypoint.position) > float.Epsilon) {
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            transform.up = currentWaypoint.position - transform.position;
        }
        else
        {
            index = index == waypoints.Count - 1 ? 0 : index + 1;
            currentWaypoint = waypoints[index];
        }
    }
}
