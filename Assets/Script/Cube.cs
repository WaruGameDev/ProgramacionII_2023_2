using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.ShaderGraph.Serialization;

public class Cube : MonoBehaviour
{
    public bool isSuscribed;
    public void Shake()
    {
        transform.DOShakePosition(1);
    }

    private void OnMouseDown()
    {
        if (!isSuscribed)
        {
            isSuscribed = true;
            CubeManager.instance.onPressButton += Shake;
        }
        else if(isSuscribed)
        {
            isSuscribed = false;
            CubeManager.instance.onPressButton -= Shake;
        }
    }
}
