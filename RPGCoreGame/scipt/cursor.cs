using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour {

	CameraRaycaster CameraRay;
	// Use this for initialization
	void Start () {
		//
		CameraRay = GetComponent<CameraRaycaster> ();
	}
	
	// Update is called once per frame
	void Update () {
		print (CameraRay.hit.point);
	}
}
