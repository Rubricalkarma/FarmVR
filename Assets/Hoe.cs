using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{

    public GameObject HolePrefab;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Farmland")
        {
            Debug.Log("Hit farmland");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                Debug.Log("Point of contact: " + hit.point);
                /*
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.GetComponent<BoxCollider>().enabled = false;
                cube.transform.localScale = new Vector3(.5f, .5f, .5f);
                cube.transform.position = hit.point;
                */

                GameObject hole = Instantiate(HolePrefab, hit.point, Quaternion.identity);
            }
        }
    }

}
