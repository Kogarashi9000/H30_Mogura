using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小川
/// </summary>
public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject fadeOutObj;
    FadeOut fadeOut;
    bool endflag = false;
    string name = null;

    // Use this for initialization
    void Start()
    {
        endflag = false;
        name = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (endflag)
        {
            Next();
        }
    }

    public void TitleSelect()
    {
        name = "Title";
        End();
    }

    public void RetrySelect()
    {
        name = "Retry";
        End();
    }

    void End()
    {
        endflag = true;
        fadeOutObj = Instantiate(fadeOutObj);
        fadeOut = fadeOutObj.GetComponent<FadeOut>();
    }

    void Next()
    {
        if (fadeOut.Endflag)
        {
            switch (name)
            {
                case "Title":
                    SceneLoad.Instance.Title();
                    break;
                case "Retry":
                    SceneLoad.Instance.Main();
                    break;
            }
        }
    }
}
