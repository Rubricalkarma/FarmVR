using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : MonoBehaviour
{

    public GameObject HolePrefab;
    public AudioSource TillingSound;
    public bool OnCooldown = false;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Farmland" && !OnCooldown)
        {
            OnCooldown = true;
            StartCoroutine(Cooldown());
            //Debug.Log("Hit farmland");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                TillingSound.Play();
                GameObject hole = Instantiate(HolePrefab, hit.point, Quaternion.identity);
            }
        }
    }

    public IEnumerator Cooldown()
    {
        float time = 0;
        while (time < 3)
        {
            time++;
            yield return new WaitForSeconds(1);
        }
        OnCooldown = false;
    }

}
