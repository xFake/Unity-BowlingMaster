using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMenu : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 startPosition;

    void Start () {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Reset", 10f, 10f);
        startPosition = transform.position;
    }
	

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }
}
