using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money;
    private float actualT;
    private float totalT = 1;
    public Action onGainMoney;
    public TextMeshProUGUI moneyUI;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (actualT < totalT)
        {
            actualT += 1 * Time.deltaTime;
            if (actualT >= totalT)
            {
                actualT = 0;
                AddMoney(1);
            }
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyUI.text = "$" + money;
        onGainMoney?.Invoke();
        
    }
}
