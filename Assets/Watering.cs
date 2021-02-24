using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public Plant PlantScript;

    public void Start()
    {
        PlantScript = gameObject.GetComponentInParent<Plant>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WateringCan")
        {
            Debug.Log("Watering Can found!");
            PlantScript.IsBeingWatered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlantScript.IsBeingWatered = false;
    }
}
