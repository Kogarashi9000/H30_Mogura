using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 小川
/// </summary>
public class FadeIn : MonoBehaviour
{
    [SerializeField] Image image;
    float alpha = 1;

    void Awake()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (true)
        {
            alpha -= 0.01f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            yield return null;

            if (alpha < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
