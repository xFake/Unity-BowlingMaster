using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour{

    public float standingThreshold = 3f;
    public float distanceToRise = 40f;

    private Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    public bool IsStanding(){
        float tiltX = (transform.eulerAngles.x < 180f) ? transform.eulerAngles.x : 360 - transform.eulerAngles.x;
        float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;
        if (tiltX > standingThreshold || tiltZ > standingThreshold){
            return false;
        }
        else {
            return true;
        }
    }
    public void Rise() {
        if(IsStanding()){
            rb.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRise, 0));
            transform.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void Lower(){
        transform.Translate(new Vector3(0, -distanceToRise, 0));
        rb.useGravity = true;
    }

}
