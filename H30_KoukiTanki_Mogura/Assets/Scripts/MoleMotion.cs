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
    [SerializeField] GameObject mole;
    public Motion Now { get; private set; }
    Vector3 startPos;
    Vector3 targetPos;
    float rate;

    // Use this for initialization
    void Start()
    {
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
                rate += Time.deltaTime * 2;

                mole.transform.position = Vector3.Lerp(mole.transform.position, startPos, rate);
                if (mole.transform.position == startPos)
                {
                    rate = 0;
                    Now = Motion.Idle;
                }
                break;
        }
    }

    public void Up()
    {
        if (Now == Motion.Idle)
        {
            MotionReset();
            Now = Motion.UP;
        }
    }

    public void Down()
    {
        if (Now == Motion.Top)
        {
            MotionReset();
            Now = Motion.Down;
        }
    }

    public void HalfWayDown()
    {
        if (Now == Motion.UP )
        {
            MotionReset();
            Now = Motion.Down;
        }
    }

    void MotionReset()
    {
        rate = 0;
    }
}
