using System;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static CubeManager instance;
    public Action onPressButton;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPressButton?.Invoke();
        }
    }
}
