using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPickUp : MonoBehaviour
{
    public Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnPickup()
    {
        rb.isKinematic = false;
    }
}
