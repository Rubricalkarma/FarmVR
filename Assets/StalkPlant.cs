using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkPlant : MonoBehaviour
{
    public PlantType Type;
    public float GrowthStage;
    public float MaxGrowthStage;
    public float GrowthRate;
    public bool IsGrown;
    public bool IsBeingWatered;
    public bool HasProducts;
    public float Cooldown;
    public bool HadFirstGrow;
    public GameObject ProductPrefab;
    public List<Vector3> ProductLocations;
    public List<GameObject> Products;


    public void Start()
    {
        GrowthStage = 1;
        MaxGrowthStage = 15;
        GrowthRate = .007f;
        Cooldown = 10;
        IsGrown = false;
        HadFirstGrow = false;
        IsBeingWatered = false;
        HasProducts = false;

        ProductLocations.Add(new Vector3(.0284f, -.0262f, .0558f));
        ProductLocations.Add(new Vector3(.0284f, -.0686f, .0558f));
        ProductLocations.Add(new Vector3(.0284f, -.0979f, .0558f));
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
        if (IsGrown && !HadFirstGrow)
        {
            HadFirstGrow = true;
            GrowProduct();
        }     
    }

    public void GrowProduct()
    {
        foreach (Vector3 location in ProductLocations)
        {
            var product = Instantiate(ProductPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Products.Add(product);
            product.GetComponentInChildren<Rigidbody>().isKinematic = true;
            product.transform.parent = gameObject.transform;
            product.transform.localPosition = location;
        }
        HasProducts = true;
    }

    public void DropProducts()
    {
        foreach (GameObject product in Products)
        {
            product.GetComponentInChildren<Rigidbody>().isKinematic = false;
        }
        HasProducts = false;
        Products.Clear();
        StartCoroutine(SpawnProductTimer());
    }

    private IEnumerator SpawnProductTimer()
    {
        Debug.Log("Starting Spawn timer");
        float time = 0;
        while (time < Cooldown)
        {
            Debug.Log("Fruit dropping in " + (Cooldown - time));
            yield return new WaitForSeconds(1);
            time++;
        }
        GrowProduct();
    }


    public enum PlantType
    {
        Corn,
        Tomatoe
    }
}
