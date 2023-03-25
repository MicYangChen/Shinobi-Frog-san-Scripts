using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private GameObject[] waypoints; // [] Creates an array.
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        if (transform.position.x < waypoints[currentWaypointIndex].transform.position.x)
        {
            sprite.flipX = false;
        }
        else if (transform.position.x > waypoints[currentWaypointIndex].transform.position.x)
        {
            sprite.flipX = true;
        }

    }
}
