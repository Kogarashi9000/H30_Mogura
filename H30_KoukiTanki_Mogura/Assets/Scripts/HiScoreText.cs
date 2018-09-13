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
    int hiScore = Score.score;

    void Awake()
    {
        HiScoreStore.GetInstance().ReadFile();
        if (HiScoreStore.GetInstance().HiScore < Score.score)
        {
            text.text = "はいすこあ:" + Score.score;
            HiScoreStore.GetInstance().HiScore = Score.score;

        }
        else
        {
            text.text = "はいすこあ:" + HiScoreStore.GetInstance().HiScore;

        }
    }

    /// <summary>
    /// シーンが消えるとき
    /// </summary>
    private void OnDestroy()
    {
        if (hiScore >= HiScoreStore.GetInstance().HiScore)
        {
            HiScoreStore.GetInstance().WriteFile();
        }
    }
}
