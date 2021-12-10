using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    bool dragging = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDrag ()
    {
        dragging = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp (0))
        {
            dragging = false;
        }
    }
}
