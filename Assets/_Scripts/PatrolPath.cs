using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public List<Node> Nodes = new List<Node>();



    // Start is called before the first frame update
    void Awake()
    {
        
        PopulateNodes();
    }

    private void PopulateNodes()
    {
         
        //print(children.Length);
        foreach (var node in this.GetComponentsInChildren<Node>())
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
        if (Nodes.Contains(n)) return;
        
        Nodes.Add(n);
        //print($"{n.name} Added");
    }

    public void RemoveNode(Node n)
    {
        if (!Nodes.Contains(n)) return;

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
