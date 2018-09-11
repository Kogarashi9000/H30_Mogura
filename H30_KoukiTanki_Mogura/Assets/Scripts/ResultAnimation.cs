using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 小川
/// </summary>
public class ResultAnimation : MonoBehaviour
{
    [SerializeField] Text[] texts;
    [SerializeField] Button[] buttons;
    IEnumerator anim;
    float alpha = 0;
    const float NUM = 0.02f;

    // Use this for initialization
    void Start()
    {
        alpha = 0;
        anim = Animation();
        StartCoroutine(anim);
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(2.0f);

        while (true)
        {
            alpha += NUM;
            ChangeColor(0);

            if (alpha >= 1)
            {
                alpha = 0;
                break;
            }

            yield return null;
        }

        while (true)
        {
            alpha += NUM;
            ChangeColor(1);

            if (alpha >= 1)
            {
                alpha = 0;
                break;
            }

            yield return null;
        }

        while (true)
        {
            alpha += NUM;
            ChangeColor(2);

            if (alpha >= 1)
            {
                alpha = 0;
                break;
            }

            yield return null;
        }

        while (true)
        {
            alpha += NUM;
            ChangeColor(3);
            ChangeColor(4);

            if (alpha >= 1)
            {
                alpha = 0;
                break;
            }

            yield return null;
        }

        Array.ForEach(buttons, all => all.enabled = true);
        StopCoroutine(anim);
    }

    void ChangeColor(int i)
    {
        Color color = texts[i].color;
        color = new Color(color.r, color.g, color.b, alpha);
        texts[i].color = color;
    }
}
