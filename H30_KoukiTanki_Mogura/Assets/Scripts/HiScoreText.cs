using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 小川
/// </summary>
public class HiScoreText : MonoBehaviour
{
    [SerializeField] Text text;
    int hiScore = 0;

    void Awake()
    {
        text.text = "はいすこあ:" + hiScore.ToString();
    }
}
