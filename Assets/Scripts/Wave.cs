using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    [SerializeField] Ovni ovni;
    [SerializeField] Transform[] waypoints; //way point path of game object
    private float moveSpeed = 50f;
    private int waypointIndex = 0;

    private int count = 3 * 5;
    private bool isWait = true;

    private void Awake()
    {
        Enemy.OnEnemyDied += addSpeed;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= addSpeed;
    }

    void Start()
    {
        StartCoroutine(StartDelay());
    }

    private void Update()
    {
        if (!isWait)
        {
            Move();
        }
    }

    private void Move()
    {
        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            if (waypointIndex%2 == 0 && waypointIndex+1 < waypoints.Length)
            {
                transform.position = waypoints[waypointIndex+1].transform.position;
            }
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            //Enemy won
        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        StartCoroutine(StartDelay());
    }
    
    IEnumerator StartDelay()
    {
        isWait = true; //object now waits to move
        yield return new WaitForSeconds(1);
        isWait = false; //object is no longer waiting to move
    }

    public void addSpeed(int point)
    {
        // Called on enemy death
        count -= 1;
        if (count == 10 || count == 5)
        {
            Instantiate(ovni);
        }
        else if (count == 0)
        {
            LoadCredits();
        }
        moveSpeed += 25f;
        Debug.Log($"speed is {moveSpeed}");
    }
    
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
