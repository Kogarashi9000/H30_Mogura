using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTimer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float timer;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject fadeOutObj;
    [SerializeField] Text endText;
    [SerializeField] MoleMotion[] moleMotions;
    FadeOut fadeOut;
    string time_str = "たいむ:";
    bool endFlag;
    public bool GameEndFlag { get; private set; }

    // Use this for initialization
    void Start()
    {
        GameEndFlag = false;
        int timer_int = (int)timer;
        timerText.text = time_str + timer_int.ToString();
        endFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (endFlag)
        {
            if (fadeOut.Endflag)
            {
                SceneLoad.Instance.Result();
            }
        }
    }

    IEnumerator Timer()
    {
        //ゲームスタート
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            timer -= Time.deltaTime;
            int timer_int = (int)timer;
            timerText.text = time_str + timer_int.ToString();

            if (timer <= 0)
            {
                PlaySE.PlaySETimeUp();
                //ここで終わる処理
                Array.ForEach(buttons, all => all.enabled = false);
                GameEndFlag = true;
                Array.ForEach(moleMotions, all => all.GameEnd(this));
                StartCoroutine(EndAction());

                yield break;
            }
            yield return null;
        }
    }

    IEnumerator EndAction()
    {
        //テキストの点滅処理
        float alpha = 0;
        endText.enabled = true;
        int cnt = 0;
        while (true)
        {
            if (cnt % 2 == 0)
            {
                alpha = 1;
            }
            else
            {
                alpha = 0;
            }
            Color color = endText.color;
            color = new Color(color.r, color.g, color.b, alpha);
            endText.color = color;
            cnt++;

            if (cnt >= 9)
            {
                //フェード処理
                fadeOutObj = Instantiate(fadeOutObj);
                fadeOut = fadeOutObj.GetComponent<FadeOut>();
                endFlag = true;
                yield break;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void GameStart()
    {
        Array.ForEach(buttons, all => all.enabled = true);
        StartCoroutine(Timer());
    }
}
