using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHieght;

    public Transform groundCheck1;
	public Transform groundCheck2;
    public Transform wallCheck1;
    public Transform wallCheck2;
    public LayerMask ground;
    private bool grounded;
    private bool walled;

    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		grounded = Physics2D.OverlapArea(groundCheck1.position, groundCheck2.position, ground);
        walled = Physics2D.OverlapArea(wallCheck1.position, wallCheck2.position, ground);
    }

    void Update()
    {
        var jump = Input.GetAxisRaw("Jump");
        var hor = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpHieght * jump);
        }
        if (!walled)
            rbody.velocity = new Vector2(speed * hor, rbody.velocity.y);
        if (hor > 0)
        {
            gameObject.transform.localScale = new Vector3(-20f, 20f, 1f);
        }
        else if (hor < 0)
        {
            gameObject.transform.localScale = new Vector3(20f, 20f, 1f);
        }
    }
}