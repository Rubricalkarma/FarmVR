using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{

    public GameObject HolePrefab;
    public AudioSource TillingSound;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Farmland")
        {
            //Debug.Log("Hit farmland");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                TillingSound.Play();
                GameObject hole = Instantiate(HolePrefab, hit.point, Quaternion.identity);

            }
        }
    }

}
