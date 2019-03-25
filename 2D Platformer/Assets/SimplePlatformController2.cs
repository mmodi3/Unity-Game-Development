using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SimplePlatformController2 : MonoBehaviour
{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 365f;
    public float regularSpeed = 8f;
    public float Speed = 8f;
    public float jumpForce = 1000f;
    public float sprintSpeed = 12f;
    public Transform groundCheck;
    public float FallingTimeToLose = 60f;


    private float falling = 0f;
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private bool airJump = true;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded){
            jump = true;
        }
        if (Input.GetButtonDown("Jump") && !grounded && airJump){
            jump = true;
            airJump = false;
        }
        if (!grounded){
          falling += 1f;
          if(falling > FallingTimeToLose){
            SceneManager.LoadScene("Lose");
          }
        } else {
          falling = 0;
          airJump = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = sprintSpeed;
        } else {
            Speed = regularSpeed;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < Speed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > Speed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * Speed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump && airJump) {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        else if (jump && !airJump){
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
