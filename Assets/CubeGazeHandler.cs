using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


public class CubeGazeHandler : MonoBehaviour, IFocusable
{
    Color originalColor;

    void Start()
    {
        originalColor=gameObject.GetComponent<MeshRenderer>().material.color;
    }

    public void OnFocusEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void OnFocusExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = originalColor;
    }
}