using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;

    private Animator enemyAnimator;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        enemyAnimator.SetTrigger("Die");
      //Debug.Log("Ouch!");
      Destroy(collision.gameObject);
      
      //Score
      if (CompareTag("one")) 
          OnEnemyDied?.Invoke(10);
      else if (CompareTag("two")) 
          OnEnemyDied?.Invoke(20);
      else if (CompareTag("three")) 
          OnEnemyDied?.Invoke(30);
      else if (CompareTag("four")) 
          OnEnemyDied?.Invoke(50);
      
      // To Do: Kill enemy
      yield return new WaitForSeconds(0.6f);
      Destroy(gameObject);
    }
}
