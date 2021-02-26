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
    public bool HasProducts;
    public float Cooldown;
    public bool HadFirstGrow;
    public bool Growing;
    public GameObject ProductPrefab;
    public List<Vector3> ProductLocations;
    public List<GameObject> Products;


    public void Start()
    {
        //GrowthStage = 1;
        MaxGrowthStage = 15;
        GrowthRate = .007f;
        Cooldown = 10;
        IsGrown = false;
        HadFirstGrow = false;
        IsBeingWatered = false;
        HasProducts = false;
        Growing = false;

        ProductLocations.Add(new Vector3(0, 0, .067f));
        ProductLocations.Add(new Vector3(.04f, 0, .067f));
        ProductLocations.Add(new Vector3(0, -0.02f, -0.0585f));
        ProductLocations.Add(new Vector3(0.0264f, -0.0518f, -0.0585f));
        ProductLocations.Add(new Vector3(0.0412f, 0.0208f, -0.0585f));
    }

    public void Update()
    {
        if (IsBeingWatered && !IsGrown)
        {
            GrowthStage += GrowthRate;
            transform.localScale = new Vector3(GrowthStage, GrowthStage, GrowthStage);
        }
        if (GrowthStage >= MaxGrowthStage && !IsGrown)
        {
            IsGrown = true;
            GrowProduct();
        }
    }

    public void GrowProduct()
    {
        if (Time.time > 3)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        Growing = false;
        foreach (Vector3 location in ProductLocations) {
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
        if (Growing)
        {
            return;
        }
        Growing = true;
        foreach(GameObject product in Products)
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
        while(time < Cooldown)
        {
            Debug.Log("Fruit dropping in " + (Cooldown - time));
            yield return new WaitForSeconds(1);
            time++;
        }
        GrowProduct();
    }


    public enum PlantType
    {
        Apple,
        Pear,
        Orange
    }
}
