using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stress : MonoBehaviour {
    public Text stressText;//ストレスゲージのパーセンテージ表記
    public Slider stressSlider;//ストレスゲージ
    bool isAnger = false;//怒り状態かどうか

    float interval = 3;//怒り時のストレスゲージ減少までの間隔

	// Use this for initialization
	void Start ()
    {
        stressSlider.value = 0;
        isAnger = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        stressText.text = stressSlider.value + "%";
        if (isAnger)
        {
            AngerCondition();
        }
    }

	void FixedUpdate ()
    {
        if (!isAnger)
        {
            StressUp();
            StressDown();
        }

        if (Input.GetKeyDown(KeyCode.A) && stressSlider.value==100)
        {
            isAnger = true;
        }
	}

    /// <summary>
    /// ストレスゲージの上昇処理
    /// </summary>
    void StressUp()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            stressSlider.value += 10;
        }
    }

    /// <summary>
    /// ストレスゲージの減少処理
    /// </summary>
    void StressDown()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            stressSlider.value -= 20;
        }
    }

    /// <summary>
    /// 怒り状態時の処理
    /// </summary>
    void AngerCondition()
    {
        if (isAnger)
        {
            interval--;
            if (interval <= 0)
            {
                stressSlider.value--;
                interval = 3;
            }

            if (stressSlider.value == 0)
            {
                isAnger = false;
            }
        }
    }
}
