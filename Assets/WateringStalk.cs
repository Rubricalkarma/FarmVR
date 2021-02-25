using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringStalk : MonoBehaviour
{
    public StalkPlant PlantScript;

    public void Start()
    {
        PlantScript = gameObject.GetComponentInParent<StalkPlant>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WateringCan")
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
