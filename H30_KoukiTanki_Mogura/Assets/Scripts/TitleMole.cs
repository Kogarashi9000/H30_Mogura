using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMole : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField] GameObject[] moles;
    [SerializeField] TitleManager titleManager;
    Vector3 endPos;
    float rate = 0;
    bool endFlag;

    // Use this for initialization
    void Start()
    {
        endFlag = false;
    }

    IEnumerator Motion(int i)
    {
        endPos = new Vector3(moles[i].transform.position.x, moles[i].transform.position.y + 3, moles[i].transform.position.z);
        bool isRate = false;
        while (true)
        {
            rate += Time.deltaTime / 5;
            moles[i].transform.position = Vector3.Lerp(moles[i].transform.position, endPos, rate);

            if (rate >= 0.2f && !isRate)
            {
                titleManager.End();
                isRate = true;
            }

            if (rate >= 1)
            {
                yield break;
            }
            yield return null;
        }
    }

    public void StartClick()
    {
        if (!endFlag)
        {
            endFlag = true;
            audioSource.Play();
            titleManager.StartSelect();
            StartCoroutine(Motion(0));
        }
    }

    public void EndClick()
    {
        if (!endFlag)
        {
            titleManager.EndSelect();
            endFlag = true;
            StartCoroutine(Motion(1));
        }
    }

    public void TutorialClick()
    {
        if (!endFlag)
        {
            titleManager.TutorialSelect();
            endFlag = true;
            StartCoroutine(Motion(2));
        }
    }

    public void CreditClick()
    {
        if (!endFlag)
        {
            titleManager.CreditSelect();
            endFlag = true;
            StartCoroutine(Motion(3));
        }
    }
}
