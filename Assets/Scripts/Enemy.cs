using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float rotateCooldown = 0.5f;
    bool isMoving;
    float rotateTimer;
    public List<GameObject> paths;
    List<Transform> waypoints = new List<Transform>();
    Transform currentWaypoint;
    int wayPtIndex = 0;
    Animator animator;
    Transform vision;

    void Awake()
    {
        animator = GetComponent<Animator>();
        vision = transform.GetChild(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.reference.AddEnemy(this);
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
        GetComponentInChildren<EnemyVision>().ResetVisionColor();
        animator.SetTrigger("Respawn");
        transform.position = waypoints[0].position;
        currentWaypoint = waypoints[1];
        wayPtIndex = 1;
        rotateTimer = 0;
        Rotate();
        rotateTimer = rotateCooldown;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        if(isMoving) {
            Move();
        }
        else
        {
            Rotate();
        }
    }

    void Move()
    {
        if(Vector2.Distance(transform.position, currentWaypoint.position) > float.Epsilon) {
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            wayPtIndex = wayPtIndex == waypoints.Count - 1 ? 0 : wayPtIndex + 1;
            currentWaypoint = waypoints[wayPtIndex];
            isMoving = false;
        }
    }

    void Rotate()
    {
        if(rotateTimer > 0) {
            rotateTimer -= Time.deltaTime;
        }
        else {
            Vector2 dir = (currentWaypoint.position - transform.position).normalized;
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            vision.transform.up = dir;
            rotateTimer = rotateCooldown;
            isMoving = true;
        }
    }
}
