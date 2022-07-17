using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChange(String sceneName)
    {
        StartCoroutine(Wait(sceneName));
        // SceneManager.LoadScene(sceneName);
    }

    IEnumerator Wait(String sceneName)
    {

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        print("Exit Game");
        Application.Quit();
    }
}
