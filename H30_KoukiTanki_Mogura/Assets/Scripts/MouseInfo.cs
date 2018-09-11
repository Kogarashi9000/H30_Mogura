using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    /// <summary>
    /// マウスの位置で
    /// GameObjectを返す
    /// </summary>
    /// <returns></returns>
    public GameObject MouseRay()
    {

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(RayShoot(), out hit, Mathf.Infinity))
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    /// <summary>
    /// 2D用
    /// </summary>
    /// <returns></returns>
    public GameObject MouseRay2D()
    {
        if (Physics2D.Raycast(RayShoot().origin, RayShoot().direction))
        {
            return Physics2D.Raycast(RayShoot().origin, RayShoot().direction).collider.gameObject;
        }

        return null;
    }

    Ray RayShoot()
    {
        Ray ray = new Ray();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        return ray;
    }
}
