using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public GameObject infoProduct;
    public Transform scroll;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventory.Add("Manzana", 1);
        inventory.Add("Pera", 2);
        inventory.Add("Sandia", 4);
        inventory["Manzana"] += 5;
        foreach (var i in inventory)
        {
            GameObject go = Instantiate(infoProduct, scroll);
            go.GetComponent<ProductInfo>().FillInfo(i.Key,i.Value);
        }
    }
}
