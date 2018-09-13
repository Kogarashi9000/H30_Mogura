using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 小川
/// </summary>
public class ScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    int score = 0;

    void Awake()
    {
        score = ScorePresent.Instance.Score;
        text.text = "すこあ　　:" + score.ToString();
    }
}
