using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camara;
    const int distance = -13;

    // Start is called before the first frame update
    void Start()
    {
        camara = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, distance);
    }
}
