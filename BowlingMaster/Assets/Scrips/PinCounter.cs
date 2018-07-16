using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour {

    public int CountStanding()
    {
        int pinCountStanding = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pinCountStanding++;
            }
        }
        return pinCountStanding;
    }
}
