using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小川
/// </summary>
public class ClickNextScene : MonoBehaviour
{
    [SerializeField] GameObject fadeOutObj;
    FadeOut fadeOut;
    bool endFlag;

    // Use this for initialization
    void Start()
    {
        endFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!endFlag)
        {
            Click();
        }
        else
        {
            Next();
        }
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fadeOutObj = Instantiate(fadeOutObj);
            fadeOut = fadeOutObj.GetComponent<FadeOut>();
            endFlag = true;
        }
    }

    void Next()
    {
        if (fadeOut.Endflag)
        {
            if (!GoToStartOrTitle.Instance.IsStart) SceneLoad.Instance.Title();
            else SceneLoad.Instance.Main();
        }
    }
}
