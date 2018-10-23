using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public float wSpeed = 1.75f;
	public float sSpeed = 2.5f;
	public float jumpForce;
	private float moveInput;

	[HideInInspector] public bool isGrounded;
	public Transform feetPos;
	public float checkGroundRadius;
	public LayerMask whatIsGround;

	private bool onWall;
	public Transform bodyPos;
	public float checkWallRadius;
	public LayerMask whatIsWall;

	private float  jumpTimeCounter;
	public float jumpTime;
	private bool isJumping;

	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	void Awake() {
	}

	// Update is called once per frame


	void FixedUpdate() {

		if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
			rb.velocity = Vector2.up * jumpForce;
			isJumping = true;
			jumpTimeCounter = jumpTime;
		} else if (Input.GetKey(KeyCode.Space) && isJumping){
			if (jumpTimeCounter > 0){
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			} else {
				isJumping = false;
			}
		}
		if(onWall){
			if(Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftArrow)){
				rb.velocity = Vector2.up * jumpForce;
				rb.AddForce(transform.right * jumpForce);
			} else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow)){
				rb.velocity = Vector2.up * jumpForce;
				rb.AddForce(-transform.right * jumpForce);
			}
		}
		if(rb.velocity == new Vector2(0, 0)){
			anim.Play("Fox-Idle");
		}
		if (!isGrounded){
			anim.Play("Fox-Jump");
		}

		if(Input.GetKeyUp(KeyCode.Space)){
			isJumping = false;
		}

		moveInput = Input.GetAxisRaw("Horizontal");
		if (Input.GetKey(KeyCode.LeftShift) && isGrounded){
			rb.velocity = new Vector2(moveInput * sSpeed, rb.velocity.y);
			if(rb.velocity.x != 0 && isGrounded){
				anim.Play("Fox-Run");
			}
		} else {
			rb.velocity = new Vector2(moveInput * wSpeed, rb.velocity.y);
			if(rb.velocity.x != 0 && isGrounded){
				anim.Play("Fox-Walk");
			}
		}


	}

	void Update () {
		isGrounded = Physics2D.OverlapCircle(feetPos.position, checkGroundRadius, whatIsGround);
		onWall = Physics2D.OverlapCircle(bodyPos.position, checkWallRadius, whatIsWall);

		if(moveInput >= 0){
			transform.eulerAngles = new Vector3(0,0,0);
		}else {
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
	}

}
