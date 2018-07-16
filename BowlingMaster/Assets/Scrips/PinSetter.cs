using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponentInParent<Pin>()) {
            Destroy(other.GetComponentInParent<Pin>().gameObject);
        }
    }

    public void RaisePins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Rise();
        }
    }

    public void LowerPins() {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }
    public void RenewPins() {
        Vector3 pinPosition = new Vector3(0, 40, 1829);
        Instantiate(pinSet, pinPosition, Quaternion.identity);
    }

    public void CallTidy() {
        animator.SetTrigger("Tidy");
    }

    public void CallReset()
    {
        animator.SetTrigger("Reset");
    }
}
