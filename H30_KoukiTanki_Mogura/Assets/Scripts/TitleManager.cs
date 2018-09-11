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
    string nameTag = null;

    // Use this for initialization
    void Start()
    {
        nameTag = null;
        endflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!endflag)
        {
            Select();
        }
        else
        {
            Next();
        }
    }

    void Select()
    {

        if (Input.GetMouseButtonDown(0) && MouseInfo.Instance.MouseRay2D())
        {
            nameTag = MouseInfo.Instance.MouseRay2D().tag;
        }

        if (nameTag == "Start" || nameTag == "End" || nameTag == "Credit" || nameTag == "Tutorial")
        {
            endflag = true;
            fadeOutObj = Instantiate(fadeOutObj);
            fadeOut = fadeOutObj.GetComponent<FadeOut>();
        }
    }

    void Next()
    {
        if (fadeOut.Endflag)
        {
            switch (nameTag)
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


