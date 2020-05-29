using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverLifetime : MonoBehaviour
{
    [SerializeField] float lifetime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //todo objectpooling
        Destroy(this.gameObject, lifetime);
    }

   
}
