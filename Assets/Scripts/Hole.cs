using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Hole : MonoBehaviour
{
    private GameObject PlantPrefab;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Seed" && !other.gameObject.GetComponent<Seed>().isHeld)
        {
            PlantPrefab = other.gameObject.GetComponent<Seed>().PlantPrefab;
            Debug.Log("Seed entered hole");
            Transform holeLocation = gameObject.transform;
            Debug.Log(holeLocation.position);
            GameObject plant = Instantiate(PlantPrefab, holeLocation.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
