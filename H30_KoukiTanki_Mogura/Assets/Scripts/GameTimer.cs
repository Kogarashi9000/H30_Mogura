using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTimer : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] float timer;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject fadeOutObj;
    FadeOut fadeOut;
    string time_str = "たいむ:";

    // Use this for initialization
    void Start()
    {
        int timer_int = (int)timer;
        text.text = time_str + timer_int.ToString();

        GameStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            timer -= Time.deltaTime;
            int timer_int = (int)timer;
            text.text = time_str + timer_int.ToString();

            if (timer <= 0)
            {
                Array.ForEach(buttons, all => all.enabled = false);
                StartCoroutine(EndAction());
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator EndAction()
    {
        while (true)
        {

        }
    }

    public void GameStart()
    {
        Array.ForEach(buttons, all => all.enabled = true);
        StartCoroutine(Timer());
    }
}
