using UnityEngine;
using System.Collections;

public class WallJump : MonoBehaviour {
	public float distance = 1f;
	Controller movement;
	public float speed=2f;
	bool walljumping;

	// Use this for initialization
	void Start () {
		movement = GetComponent<Controller> ();
	}

	// Update is called once per frame
	void Update () {
		Physics2D.queriesStartInColliders = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);


		if (Input.GetKeyDown(KeyCode.Space) && !movement.isGrounded && hit.collider != null) {
						{
								GetComponent<Rigidbody2D>().velocity = new Vector2 (speed * hit.normal.x, speed);

								StartCoroutine ("TurnIt");

						}

				}
	}

		IEnumerator TurnIt()
		{
				yield return new WaitForFixedUpdate ();

				transform.localScale = transform.localScale.x == 1 ? new Vector2 (-1, 1) : Vector2.one;

		}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawLine (transform.position, transform.position + Vector3.right * transform.localScale.x * distance);

	}
}
