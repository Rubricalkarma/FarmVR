using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public bool isHeld;
    public GameObject PlantPrefab;

    public void toggleHeld()
    {
        isHeld = !isHeld;
    }
}
