using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNode : MonoBehaviour
{
    [SerializeField] Transform down;
    public LayerMask levelLayer;
    public float range = 0.5f;
    Node node;

    // Start is called before the first frame update
    void Start()
    {
        node = GetComponent<Node>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (!Physics.Raycast(down.position, down.forward, out hit, range, levelLayer)) {
            node.Unhide();
        }

        if (Physics.Raycast(down.position, down.forward, out hit, range, levelLayer))
        {
            node.Hide();
        }

    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, -transform.up * range, Color.yellow);
    }
}
