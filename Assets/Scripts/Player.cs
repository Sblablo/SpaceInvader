using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public Transform shottingOffset;
  private Animator playerAnimator;

  public float speed;
  
  void Start()
  {
    Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    Ovni.OnOvniDie += EnemyOnOnEnemyDied;
    playerAnimator = GetComponent<Animator>();
  }

  private void OnDestroy()
  {
    Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    Ovni.OnOvniDie -= EnemyOnOnEnemyDied;
  }

  void EnemyOnOnEnemyDied(int points)
  {
    Debug.Log($"I know about dead enemy, points: {points}");
  }
  
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      playerAnimator.SetTrigger("Shooting Trigger");
      GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
      //Debug.Log("Bang!");

      Destroy(shot, 3f);
    }

    float move = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.down * (move * Time.deltaTime * speed));
  }
}
