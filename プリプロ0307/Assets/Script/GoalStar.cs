﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 0f, 2f));
    }
}
