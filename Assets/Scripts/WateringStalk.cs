using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringStalk : MonoBehaviour
{
    public StalkPlant PlantScript;
    public AudioSource WateringSound;

    public void Start()
    {
        PlantScript = gameObject.GetComponentInParent<StalkPlant>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WateringCan")
        {
            WateringSound = other.GetComponent<AudioSource>();
            WateringSound.Play();
            Debug.Log("Watering Can found!");
            PlantScript.IsBeingWatered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WateringCan")
        {
            WateringSound.Stop();
            PlantScript.IsBeingWatered = false;
        }
    }
}
