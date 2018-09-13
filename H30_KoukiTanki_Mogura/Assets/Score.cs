using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text text;

    public static int score;
    public static int hit;

    // Use this for initialization
    void Start()
    {
        hit = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "すこあ：" + score;
    }

    public void add(int point)
    {
        score += point;
        text.text = "すこあ：" + score;
    }


}
