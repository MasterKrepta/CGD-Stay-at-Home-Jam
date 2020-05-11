using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockVisibiity))]
public class ToggleMaterial : MonoBehaviour
{
    BlockVisibiity bv;

    public Material HiddenMat;

    // Start is called before the first frame update
    void Start()
    {
        bv = GetComponent<BlockVisibiity>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bv.isExposed)
        {
            bv.GetComponent<IHideable>().ToggleMat();
        }
        else
        {
            HideBlock();
        }
        
    }

    void HideBlock()
    {
        bv.GetComponent<IHideable>().HideMat(HiddenMat);
    }
}
