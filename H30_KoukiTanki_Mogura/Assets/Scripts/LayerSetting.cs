using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSetting : MonoBehaviour
{
    [SerializeField] Renderer renderer;

    // Use this for initialization
    void Start()
    {
        
        renderer.sortingLayerName = "Default";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
