using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{

    [SerializeField]bool isVisible = false;

    public void Unhide()
    {
        isVisible = true;
        this.transform.parent = GameObject.FindObjectOfType<PatrolPath>().transform;
        GameObject.FindObjectOfType<PatrolPath>().AddNode(this);
    }

    public void Hide()
    {
        this.transform.parent = null;
        GameObject.FindObjectOfType<PatrolPath>().RemoveNode(this);

    }


}
