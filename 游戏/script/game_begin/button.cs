using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    

    public void OnStartGame2(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        StaticVarious.playernum = 2;
    }

    public void OnStartGame3(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        StaticVarious.playernum = 3;
    }

    public void OnStartGame4(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        StaticVarious.playernum = 4;
    }
}
