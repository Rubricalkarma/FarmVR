using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHitbox : MonoBehaviour
{
    public Plant PlantScript;
    public AudioSource HitSound;

    public void Start()
    {
        PlantScript = gameObject.transform.parent.GetComponentInParent<Plant>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HitSound.Play();
            PlantScript.DropProducts();
        }
    }
}
