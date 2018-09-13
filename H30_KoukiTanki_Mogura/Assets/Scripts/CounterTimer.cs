using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シーンが読み込まれたら自動でカウントダウンを行うスクリプト
/// 
/// 使う際は変更するテキストに付けておく
/// 
/// 作成者:田中颯馬
/// 編集者:田中颯馬
/// 作成日時:2018/9/12
/// </summary>
public class CounterTimer : MonoBehaviour
{
    //スタートするまでの時間
    [SerializeField]
    private float startTime = 0;

    //キャンバスのテキスト
    [SerializeField]
    private Text text;

    [SerializeField]
    private GameTimer gameTimer;

    #region プロパティ
    //スタート可能か？
    public static bool CanStart { get; private set; }
    #endregion

    // Use this for initialization
    void Start()
    {
        CanStart = false;
        text.text = ((int)startTime).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanStart)
        {
            //1秒ずつ減るようにする
            startTime = startTime - 1 * Time.deltaTime;

            if (startTime < 1)
            {
                text.text = "Start";
            }
            else
            {
                text.text = ((int)startTime).ToString();
            }

            if (startTime <= 0 && !CanStart)
            {
                gameTimer.GameStart();
                CanStart = true;
                text.gameObject.SetActive(false);
            }
        }
    }
}
