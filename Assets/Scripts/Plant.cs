using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantType Type;
    public float GrowthStage;
    public float MaxGrowthStage;
    public bool IsGrown;
    public bool IsBeingWatered;


    public void Start()
    {
        GrowthStage = 0;
        MaxGrowthStage = 15;
        IsGrown = false;
    }

    public void Update()
    {
        if (IsBeingWatered && !IsGrown)
        {
            GrowthStage += .00001f;
            if(GrowthStage >= 1)
            {
                IsGrown = true;
            }
            transform.localScale += new Vector3(.01f, .01f, .01f);
        }  
    }


    public enum PlantType
    {
        Apple
    }
}
