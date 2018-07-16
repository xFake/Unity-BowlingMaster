using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private float dragStartTime, dragEndTime;
    private Vector3 dragStartPosition, dragEndPosition;

    void Start() {
        ball = GetComponent<Ball>();
    }
    
    public void DragStart() {
        dragStartTime = Time.time;
        dragStartPosition = Input.mousePosition;
    }

    public void DragEnd(){
        dragEndTime = Time.time;
        dragEndPosition = Input.mousePosition;

        float dragTime = dragEndTime - dragStartTime;

        float launchSpeedX = (dragEndPosition.x - dragStartPosition.x) / dragTime;
        float launchSpeedZ = (dragEndPosition.y - dragStartPosition.y) / dragTime;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);
        ball.Launch(launchVelocity);
    }
}
