using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAnimationController : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow))) {
			anim.SetBool("IsWalking", true);
 		} else {
			anim.SetBool("IsWalking", false);
		}
		if(Input.GetKey(KeyCode.LeftShift) && ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)))) {
			anim.SetBool("IsRunning", true);
		} else {
			anim.SetBool("IsRunning", false);
		}

		if(Input.GetKey(KeyCode.Space)){
			anim.SetBool("IsJumping", true);
		} else {
			anim.SetBool("IsJumping", false);
		}
	}
}
