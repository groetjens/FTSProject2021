using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


public class CubeDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public void DropCube()
    {
        var rbody = gameObject.GetComponent<Rigidbody>();
        if (rbody == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        else
        {
            rbody.WakeUp();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            var rbody = gameObject.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.Sleep();
            }
            gameObject.transform.position = new Vector3(0, 0, 2);
        }
    }
}