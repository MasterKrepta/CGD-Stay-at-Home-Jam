using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public List<Node> Nodes = new List<Node>();
    private int _childCount;

    int oldChildCount;
    public int ChildCount
    {
        get { return _childCount; }
        set { _childCount = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        oldChildCount = ChildCount;
        PopulateNodes();
    }

    private void PopulateNodes()
    {
         var children= this.GetComponentsInChildren<Node>();
        //print(children.Length);
        foreach (var node in children)
        {
            Nodes.Add(node);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddNode(Node n)
    {
        Nodes.Add(n);
    }

    public void RemoveNode(Node n)
    {
        Nodes.Remove(n);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < Nodes.Count - 1; i++)
        {
            Debug.DrawLine(Nodes[i].transform.position, Nodes[i + 1].transform.position, Color.green);
        }
    }
}
