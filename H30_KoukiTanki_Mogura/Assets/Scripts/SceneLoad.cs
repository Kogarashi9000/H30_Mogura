using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 小川
/// </summary>
public class SceneLoad
{
    static SceneLoad instance;

    public static SceneLoad Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = new SceneLoad();
            }
            else
            {
                return instance;
            }
        }
    }

    public void Main()
    {
        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Result()
    {
        SceneManager.LoadScene("Result");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

}
