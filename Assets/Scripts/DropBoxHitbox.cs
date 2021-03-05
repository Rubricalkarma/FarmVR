using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxHitbox : MonoBehaviour
{
    private DropBox ParentScript;

    public void Start()
    {
        ParentScript = GetComponentInParent<DropBox>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Product")
        {
            ParentScript.SellItem(other.gameObject);
        }
    }
}
