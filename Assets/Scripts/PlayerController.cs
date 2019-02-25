using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float jumpSpeed = 250;
    float maxMoveSpeed = 5;
    bool isGrounded = true;
    bool isClimbable;
    bool isLookingLeft;
    bool isLookingRight;
    bool isFireing;
    float hor;

    public float spellSpeed;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsClimbable;
    public GameObject spellPrefab;
    public Transform spellOrigin;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15F, whatIsGround);
        isClimbable = Physics2D.OverlapCircle(groundCheck.position, 0.15F, whatIsClimbable);
        animator.SetBool("isGrounded", isGrounded);
        if (Input.GetKeyDown("w") && isGrounded && !isClimbable)
            rb2d.AddForce(new Vector2(0, jumpSpeed));
        else if (Input.GetKey("w") && isClimbable)
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxMoveSpeed);
        if (Input.GetKey("d"))
        {
            hor = -1;
            isLookingRight = true;
            isLookingLeft = false;
        }
        else if (Input.GetKey("a"))
        {
            hor = 1;
            isLookingLeft = true;
            isLookingRight = false;
        }
        else
        {
            animator.SetFloat("speed", 0);
            isLookingLeft = false;
            isLookingRight = false;
            isFireing = false;
        }
        if (Input.GetMouseButtonDown(0) && !isFireing)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                isLookingLeft = true;
                isLookingRight = false;
                isFireing = true;
            }
            else
            {
                isLookingLeft = false;
                isLookingRight = true;
                isFireing = true;
            }
        }
        animator.SetFloat("speed", Mathf.Abs(hor));
        animator.SetBool("isLookingLeft", isLookingLeft);
        animator.SetBool("isLookingRight", isLookingRight);
        animator.SetBool("isFireing", isFireing);
        rb2d.velocity = new Vector2(hor * maxMoveSpeed, rb2d.velocity.y);
        hor = 0;
    }

    public void Fire()
    {
        //Shoot somehow
        float aim = Input.mousePosition.x - Screen.width;
        Vector3 adjustedOrigin = new Vector3();
        if (Input.mousePosition.x < Screen.width / 2)
            adjustedOrigin = spellOrigin.position + new Vector3(0.215F, 0);
        else
            adjustedOrigin = spellOrigin.position + new Vector3(-0.215F, 0);
        GameObject spell = (GameObject)Instantiate(spellPrefab, adjustedOrigin, Quaternion.identity);
        spell.GetComponent<Rigidbody2D>().AddForce(new Vector3(-(Input.mousePosition.x + aim * spellSpeed), Input.mousePosition.y));
        Debug.Log(adjustedOrigin);
    }
}
