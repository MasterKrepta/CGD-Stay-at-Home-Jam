using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float range = 1.2f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeBite();
        }
    }

    private void TakeBite()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);


        if (Physics.Raycast(transform.position, fwd, out hit, range))
        {
            var temp = hit.transform.GetComponent<Dirt>();

            if (temp != null)
            {
                temp.BiteDirt();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, fwd * range, Color.yellow);
    }
}
