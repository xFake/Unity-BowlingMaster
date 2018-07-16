using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMenu : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 startPosition;
    private Vector3 velocity;

    void Start () {
        rb = GetComponent<Rigidbody>();
        velocity = new Vector3(-400, 0, 0);
        startPosition = transform.position;
        InvokeRepeating("Reset", 1f, 5f);
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rb.velocity = velocity;
    }

}
