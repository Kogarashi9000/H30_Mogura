using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 空のGameObjectの正面からRayを飛ばし、
/// NPCが正面にいることを伝えるスクリプト
/// 
/// 使う際はMoguraにこのスクリプトをAddしたGameObjectをRayを飛ばしたい方向に向かせ、
/// SerializeFieldなどで登録できるようにしてAddして使うこと
/// 
/// 作成者:田中颯馬
/// 編集者:田中颯馬
/// 作成日時:2018/9/11
/// </summary>
public class MoguraRay : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    [SerializeField]
    private int layerMask;

    #region プロパティ
    //ヒットしたか
    public bool IsHit { get; private set; }
    #endregion

    // Use this for initialization
    void Start()
    {
        IsHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Rayの始点
        ray.origin = transform.position;
        //Rayの方向
        ray.direction = transform.forward;

        //Rayが特定layerのObjectに当たったら
        if (Physics.Raycast(ray, out hit, 1000f, layerMask))
        {
            IsHit = true;
        }
        else
        {
            IsHit = false;
        }
    }
}
