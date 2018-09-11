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

    /// <summary>
    /// マウスの位置で
    /// GameObjectを返す
    /// </summary>
    /// <returns></returns>
    public GameObject MouseRay()
    {
        Ray ray = new Ray();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
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
        Ray ray = new Ray();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics2D.Raycast(ray.origin, ray.direction))
        {
            return Physics2D.Raycast(ray.origin, ray.direction).collider.gameObject;
        }

        return null;
    }
}
