using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 6.0f * 10f * Time.deltaTime);
	}
}
