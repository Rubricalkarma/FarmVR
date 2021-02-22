using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantType Type;
    public float GrowthStage;
    public float MaxGrowthStage;
    public float GrowthRate;
    public bool IsGrown;
    public bool IsBeingWatered;
    public GameObject ProductPrefab;
    public List<Vector3> ProductLocations;


    public void Start()
    {
        GrowthStage = 1;
        MaxGrowthStage = 15;
        GrowthRate = .007f;
        IsGrown = false;
        IsBeingWatered = false;

        ProductLocations.Add(new Vector3(0, 0, .06f));
        ProductLocations.Add(new Vector3(.04f, 0, .06f));

        GrowProduct();
    }

    public void Update()
    {
        if (IsBeingWatered && !IsGrown)
        {
            GrowthStage += GrowthRate;
            if (GrowthStage >= MaxGrowthStage)
            {
                IsGrown = true;
            }
            transform.localScale = new Vector3(GrowthStage, GrowthStage, GrowthStage);
        }  
    }

    public void GrowProduct()
    {
        foreach (Vector3 location in ProductLocations) {
            var product = Instantiate(ProductPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            product.transform.parent = gameObject.transform;
            product.transform.localPosition = location;
        }
    }


    public enum PlantType
    {
        Apple
    }
}
