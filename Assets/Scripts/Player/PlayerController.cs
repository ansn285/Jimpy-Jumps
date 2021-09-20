using UnityEngine;
using TMPro;
//using Mirror;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float minSpeed = 0.0f, maxSpeed = 100.0f, acceleration = 1.0f;
    public AudioClip[] jumpSounds;

    [SerializeField] private TextMeshProUGUI up, down, left, right;

    private Rigidbody2D rb;
    private Animator animator;
    private CustomPlayer player;
    private Vector2 movement;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<CustomPlayer>();
        audioSource = GetComponent<AudioSource>();

        UpdateControls();
    }


    private void UpdateControls()
    {
        if (player.up.ToString().Contains("Arrow"))
        {
            up.text = player.up.ToString().Replace("Arrow", "");
        }
        else
        {
            up.text = player.up.ToString();
        }

        if (player.down.ToString().Contains("Arrow"))
        {
            down.text = player.down.ToString().Replace("Arrow", "");
        }
        else
        {
            down.text = player.down.ToString();
        }

        if (player.left.ToString().Contains("Arrow"))
        {
            left.text = player.left.ToString().Replace("Arrow", "");
        }
        else
        {
            left.text = player.left.ToString();
        }

        if (player.right.ToString().Contains("Arrow"))
        {
            right.text = player.right.ToString().Replace("Arrow", "");
        }
        else
        {
            right.text = player.right.ToString();
        }
    }



    //public override void OnStartAuthority()
    //{
    //    enabled = true;


    //}

    //[ClientCallback]
    private void Update()
    {
        //if (!hasAuthority) { return; }

        movement = new Vector2(player.GetAxis("Horizontal", Input.GetKey(player.left), Input.GetKey(player.right)),
                                player.GetAxis("Vertical", Input.GetKey(player.up), Input.GetKey(player.down)));

        if (player.GetAxis("Horizontal", Input.GetKey(player.left), Input.GetKey(player.right)) != 0 || 
            player.GetAxis("Vertical", Input.GetKey(player.up), Input.GetKey(player.down)) != 0)
        {
            animator.SetFloat("walk", 1);
        }

        else
        {
            animator.SetFloat("walk", 0);
            //InvokeRepeating("Decelerate", 0, 3);
        }
        
    }

    //[ClientCallback]
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    public void MoveCharacter(Vector2 direction)
    {
        //if (speed < maxSpeed)
        //{
        //    speed += acceleration;
        //}

        movement = direction * speed * Time.deltaTime;
        rb.AddForce(direction * speed);
        
        //transform.Translate(movement);
    }

    public void Decelerate()
    {
        if (speed > minSpeed)
        {
            speed -= acceleration;
        }

        else
        {
            CancelInvoke("Decelerate");
        }
    }


    public void PlayJumpSound()
    {
        if (GameController.sfx)
        {
            audioSource.clip = jumpSounds[Random.Range(0, jumpSounds.Length)];
            audioSource.Play();
        }
    }
}
