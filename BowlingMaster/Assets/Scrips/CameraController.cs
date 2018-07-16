using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

    void Start () {
        offset = transform.position - ball.transform.position;
	}

    void Update(){
        if (ball.transform.position.z <= 1500f && ball.transform.position.x <= Mathf.Abs(40))
        {
            transform.position = ball.transform.position + offset;
        }
    }

}
