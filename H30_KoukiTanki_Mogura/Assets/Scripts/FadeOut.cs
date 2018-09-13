using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 小川
/// </summary>
public class FadeOut : MonoBehaviour
{
    [HideInInspector] public bool Endflag { get; private set; }
    [SerializeField] Image image;
    IEnumerator fade;
    float alpha;

    void Awake()
    {
        alpha = 0;
        Endflag = false;
        fade = Fade();
        StartCoroutine(fade);
    }

    IEnumerator Fade()
    {
        while (true)
        {
            alpha += 0.01f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            if (alpha >= 1)
            {
                Endflag = true;
                yield break;
            }
            yield return null;
        }
    }
}
