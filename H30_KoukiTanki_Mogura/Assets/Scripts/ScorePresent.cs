using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePresent
{
    static ScorePresent instance;
    public static ScorePresent Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = new ScorePresent();
            }
            else
            {
                return instance;
            }
        }
    }

    public int Hit;
    public int Score;
}
