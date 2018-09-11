using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject fadeOutObj;
    FadeOut fadeOut;
    bool endflag = false;
    string nameTag = null;

    // Use this for initialization
    void Start()
    {
        endflag = false;
        nameTag = null;
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

        if (nameTag == "Title" || nameTag == "Retry")
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
