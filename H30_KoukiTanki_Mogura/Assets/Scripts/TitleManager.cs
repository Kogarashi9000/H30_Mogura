using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小川
/// </summary>
public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject fadeOutObj;
    FadeOut fadeOut;
    bool endflag;
    string name = null;

    // Use this for initialization
    void Start()
    {
        name = null;
        endflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (endflag)
        {
            Next();
        }
    }

    public void StartSelect()
    {
        name = "Start";
        End();
    }

    public void EndSelect()
    {
        name = "End";
        End();
    }

    public void CreditSelect()
    {
        name = "Credit";
        End();
    }

    public void TutorialSelect()
    {
        name = "Tutorial";
        End();
    }

    public void End()
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
                case "Start":
                    GoToStartOrTitle.Instance.Start();
                    SceneLoad.Instance.Tutorial();
                    break;
                case "End":
                    SceneLoad.Instance.Exit();
                    break;
                case "Credit":
                    GoToStartOrTitle.Instance.Title();
                    SceneLoad.Instance.Credit();
                    break;
                case "Tutorial":
                    GoToStartOrTitle.Instance.Title();
                    SceneLoad.Instance.Tutorial();
                    break;
            }
        }
    }
}


