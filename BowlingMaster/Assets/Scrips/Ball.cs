using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private bool inPlay = false;
    private Rigidbody rb;
    private AudioSource audioSource;
    private Vector3 clampedPosition;
    private Vector3 startPosition;

    void Start (){
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.useGravity = false;
        startPosition = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        if (!inPlay)
        {
            rb.useGravity = true;
            rb.velocity = velocity;
            PlaySound();
            inPlay = true;
        }
    }

    private void PlaySound() {
        audioSource.loop = true;
        audioSource.Play();
    }

    public void MoveStart(float xNudge) {
        if (!inPlay){
            ClampedPosition();
            transform.Translate(new Vector3(xNudge, 0, 0));
            Debug.Log(xNudge);
        }
    }

    private void ClampedPosition()
    {
        clampedPosition.x = Mathf.Clamp(transform.position.x, -40f, 40f);
        clampedPosition.y = Mathf.Clamp(transform.position.y, 0f, 20f);
        clampedPosition.z = Mathf.Clamp(transform.position.z, 0f, 2000f);
        transform.position = clampedPosition;
    }
    public void Reset() {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        inPlay = false;

        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        audioSource.Stop();
    }
}
