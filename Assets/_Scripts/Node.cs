using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    Vector3 hiddenPos;
    Vector3 visiblePos;
    public bool isVisible = false;


    private void Awake()
    {
        hiddenPos = new Vector3(transform.position.x, 2.1f, transform.position.z);
        visiblePos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        this.transform.position = hiddenPos;
    }
    public void Unhide()
    {
        isVisible = true;
        this.transform.position = visiblePos;
        this.transform.parent = GameObject.FindObjectOfType<PatrolPath>().transform;
        GameObject.FindObjectOfType<PatrolPath>().AddNode(this);
    }

    public void Hide()
    {
        this.transform.parent = null;
        this.transform.position = hiddenPos;
        GameObject.FindObjectOfType<PatrolPath>().RemoveNode(this);

    }


}
