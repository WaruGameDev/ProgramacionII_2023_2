using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProductInfo : MonoBehaviour
{
    public TextMeshProUGUI productName, buttonName;
    public Button buyButton;
    public int price;

    private void Start()
    {
        MoneyManager.instance.onGainMoney += DetectMoney;
        DetectMoney();
    }

    public void FillInfo(string nameProduct, int quantity)
    {
        productName.text = nameProduct.ToString();
        buttonName.text = quantity + "u";
        price = quantity;
    }

    public void DetectMoney()
    {
        if (MoneyManager.instance.money >= price)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }
}
