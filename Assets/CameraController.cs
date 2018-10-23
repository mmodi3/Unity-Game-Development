using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float smoothSpeed = .125f;
	
	public Transform target;
	public Vector3 offset;
	// Use this for initialization
	void LateUpdate(){
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
		transform.position = smoothedPosition;
		
		transform.LookAt(target);
	}

}
