using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    [Client]
    private void Update()
    {
        if (!hasAuthority) { return; }

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetFloat("walk", 1);
        }

        else
        {
            animator.SetFloat("walk", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    private void moveCharacter(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
