using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public Plant PlantScript;
    public AudioSource WateringSound;

    public void Start()
    {
        PlantScript = gameObject.GetComponentInParent<Plant>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WateringCan")
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
