using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoButton : MonoBehaviour
{
    public GameObject reference;

    public void Awake()
    {  
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(reference);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    public void LoadGameScene()
    {
        StartCoroutine(_loadGameScene());

        IEnumerator _loadGameScene()
        {
            AsyncOperation loadOp = SceneManager.LoadSceneAsync("DemoScene");
            while (!loadOp.isDone) yield return null;
        
            GameObject player = GameObject.Find("Player");
            Debug.Log(player.name);
        }
    }
}
