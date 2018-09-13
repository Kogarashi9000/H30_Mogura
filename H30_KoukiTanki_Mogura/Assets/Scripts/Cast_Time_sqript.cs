using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cast_Time_sqript : MonoBehaviour {

    public Image back;
    public Image UIobj_cast;
    public Image UIobj_limit;
    public bool roop;//仮

    public GameObject mogura;
    public GameObject backpanel;
    
    public float castTime;
    public float limitTime;

    private void Start() {
        UIobj_cast.fillAmount = 0;
        backpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        if(mogura.GetComponent<MoleMotion>().Now == Motion.Idle)
        {
            if(UIobj_cast.fillAmount <= 0.0f && UIobj_limit.fillAmount <= 0.0f)
            {
                backpanel.SetActive(true);
                back.fillAmount = 1.0f;
                UIobj_cast.fillAmount = 1.0f;
            }

            if (UIobj_cast.fillAmount <= 0.0f)
            {
                if(UIobj_limit.fillAmount >= 0.0f)
                {
                    UIobj_limit.fillAmount -= 1.0f / limitTime * Time.deltaTime;
                    if (UIobj_limit.fillAmount <= 0.0f)
                    {
                        back.fillAmount = 0.0f;
                        mogura.GetComponent<MoleMotion>().Up();
                    }
                }
            }
            
            if (UIobj_cast.fillAmount >= 0.0f)
            {
                if (UIobj_limit.fillAmount <= 0.0f)
                {
                    UIobj_cast.fillAmount -= 1.0f / castTime * Time.deltaTime;
                    if(UIobj_cast.fillAmount <= 0.0f)
                    {
                        backpanel.SetActive(false);
                        UIobj_limit.fillAmount = 1.0f;
                    }
                }
            }
        }

        if (mogura.GetComponent<MoleMotion>().Now == Motion.UP)
        {
            if (UIobj_limit.fillAmount >= 0.0f)
            {
                back.fillAmount = 0.0f;
                UIobj_limit.fillAmount = 0.0f;
            }
        }


    }
}
