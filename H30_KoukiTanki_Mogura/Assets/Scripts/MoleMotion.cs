using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Motion
{
    UP, Down, Idle, Top,
}

/// <summary>
/// 小川
/// </summary>
public class MoleMotion : MonoBehaviour
{
    [SerializeField]
    GameObject mole;
    public Motion Now { get; private set; }
    Vector3 startPos;
    Vector3 targetPos;
    float rate;
    float downNum;
    public bool GameEndFlag { get; private set; }
    bool isDamage;

    public Canvas canvas;

    // Use this for initialization
    void Start()
    {
        isDamage = false;
        GameEndFlag = false;
        downNum = 2;
        rate = 0;
        startPos = mole.transform.position;
        Now = Motion.Idle;
        targetPos = new Vector3(mole.transform.position.x, mole.transform.position.y + 3, mole.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        switch (Now)
        {
            case Motion.UP:
                rate += Time.deltaTime / 5;
                mole.transform.position = Vector3.Lerp(mole.transform.position, targetPos, rate);
                if (rate >= 1)
                {
                    rate = 0;
                    Now = Motion.Top;
                }
                break;

            case Motion.Down:
                if (!GameEndFlag)
                {
                    if (!isDamage)
                    {
                        rate += Time.deltaTime * 2;
                    }
                    else if (isDamage)
                    {
                        rate += Time.deltaTime / 3;
                    }
                }
                else
                {
                    rate += Time.deltaTime / 10;
                }

                mole.transform.position = Vector3.Lerp(mole.transform.position, startPos, rate);
                if (mole.transform.position == startPos)
                {
                    if (isDamage) isDamage = false;
                    rate = 0;
                    Now = Motion.Idle;
                }
                break;
        }
    }

    public void Up()
    {
        if (Now == Motion.Idle && CounterTimer.CanStart && canvas.GetComponent<Cast_Time_sqript>().isCast)
        {
            MotionReset();
            Now = Motion.UP;
            if (canvas.GetComponent<Cast_Time_sqript>().UIobj_limit.fillAmount <= 0.0f)
            {
                PlaySE.PlaySeUpForce();
            }
            else
            {
                PlaySE.PlaySeUp();
            }
        }
    }

    public void Down()
    {
        if ((Now == Motion.Top || Now == Motion.UP) && CounterTimer.CanStart)
        {
            MotionReset();
            Now = Motion.Down;
            PlaySE.PlaySeDown();
        }
    }

    public void Damage()
    {
        if ((Now == Motion.Top || Now == Motion.UP) && CounterTimer.CanStart)
        {
            isDamage = true;
            MotionReset();
            Now = Motion.Down;
            PlaySE.PlaySeDown();
        }
    }

    void MotionReset()
    {
        rate = 0;
    }

    public void GameEnd(GameTimer gameTimer)
    {
        if (Now == Motion.Top || Now == Motion.UP)
        {
            GameEndFlag = gameTimer.GameEndFlag;
            Down();
        }
    }
}
