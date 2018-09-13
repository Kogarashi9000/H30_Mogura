using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 小川
/// </summary>
public class HitText : MonoBehaviour
{
    [SerializeField] Text text;
    int hitCnt = 0;

    // Use this for initialization
    void Start()
    {
        hitCnt = ScorePresent.Instance.Hit;
        text.text = "ひっと　　:" + hitCnt.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
