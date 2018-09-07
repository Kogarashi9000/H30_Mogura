using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小川
/// </summary>
public class MouseInfo
{
    static MouseInfo instance;
    public static MouseInfo Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = new MouseInfo();
            }
            else
            {
                return instance;
            }
        }
    }

    public GameObject MouseRay()
    {
        Debug.Log(Input.mousePosition);
        Ray ray = new Ray();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.collider.gameObject;
        }

        return null;
    }
}
