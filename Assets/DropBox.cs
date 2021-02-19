using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{
   
    public void SellItem(GameObject Product)
    {
        Product script = Product.GetComponentInParent<Product>();
        Debug.Log("Selling item for $" + script.Value);
        Destroy(Product.transform.parent.gameObject);
    }
}
