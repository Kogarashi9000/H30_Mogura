using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStartOrTitle
{
    static GoToStartOrTitle instance;

    public static GoToStartOrTitle Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = new GoToStartOrTitle();
            }
            return instance;
        }
    }

    bool isStart;

    public void Start()
    {
        isStart = true;
    }

    public void Title()
    {
        isStart = false;
    }

    public bool IsStart { get { return isStart; } }
}
