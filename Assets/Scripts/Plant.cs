using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantType Type;
    public float GrowthStage;
    public bool IsGrown;


    public void Start()
    {
        GrowthStage = 0;
        IsGrown = false;
    }

    public enum PlantType
    {
        Apple
    }
}
