using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPickUp : MonoBehaviour
{
    public Rigidbody rb;
    public bool HasBeenPicked;

    public void Start()
    {
        HasBeenPicked = false;
        rb = GetComponent<Rigidbody>();
    }

    public void OnPickup()
    {
        rb.isKinematic = false;
        HasBeenPicked = true;
    }
}
