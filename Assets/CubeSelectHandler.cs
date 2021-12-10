using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


public class CubeSelectHandler : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        Select();
    }

    public void Select()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}