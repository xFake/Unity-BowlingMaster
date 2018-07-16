﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

    private GameManager gameManager;

    private void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerExit(Collider other){
        if (other.GetComponent<Ball>()) {
            gameManager.SetBallLeftBox(true);
        }
    }

}
