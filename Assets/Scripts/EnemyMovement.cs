using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum movement {
        move,
        rotate
    }
    movement currentMovement = movement.move;
    public float moveSpeed;
    public float rotateCooldown = 0.5f;
    float rotateTimer;
    [SerializeField] List<GameObject> paths;
    [SerializeField] List<Transform> waypoints;
    Transform currentWaypoint;
    public int index = 0;

    public Transform vision;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddEnemy(this);
        ChangePathSet(0);
    }

    public void ChangePathSet(int index) {
        waypoints.Clear();
        for(int i = 0; i < paths[index].transform.childCount; i++) {
            waypoints.Add(paths[index].transform.GetChild(i).transform);
        }
        InitPosition();
    }

    public void InitPosition() {
        transform.position = waypoints[0].position;
        currentWaypoint = waypoints[0];
        rotateTimer = rotateCooldown;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        switch(currentMovement) {
            case movement.rotate:
                Rotate(); break;
            case movement.move:
                Move(); break;
        }
    }

    void Move()
    {
        if(Vector2.Distance(transform.position, currentWaypoint.position) > float.Epsilon) {
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            index = index == waypoints.Count - 1 ? 0 : index + 1;
            currentWaypoint = waypoints[index];
            currentMovement = movement.rotate;
        }
    }

    void Rotate()
    {
        if(rotateTimer > 0) {
            rotateTimer -= Time.deltaTime;
        }
        else {
            vision.transform.up = currentWaypoint.position - transform.position;
            rotateTimer = rotateCooldown;
            currentMovement = movement.move;
        }
    }
}
