using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Singleton

    public static PlayerController instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    #region PrivateSteeringVars
    Rigidbody2D rb2d;
    Animator animator;
    float jumpSpeed = 250;
    float maxMoveSpeed = 5;
    bool isGrounded = true;
    bool isClimbable;
    bool isLookingLeft;
    bool isLookingRight;
    bool isFireing;
    bool deathTrigger;
    float hor;
    int maxLife = 3;
    int maxHealth = 5;
    #endregion
    #region Current Stats
    public int currentLife;
    public int currentHealth;
    #endregion
    #region GroundDetection
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsDeath;
    public LayerMask whatIsClimbable;
    # endregion
    #region SpellSpecs
    public float spellSpeed;
    public GameObject spellPrefab;
    public Transform spellOrigin;
    #endregion
    #region UIStuff
    public GameObject[] lifeGui;
    public GameObject[] healthGui;
    #endregion

    void Start()
    {
        currentLife = maxLife;
        currentHealth = maxHealth;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lifeGui[lifeGui.Length-1].SetActive(true);
        healthGui[healthGui.Length-1].SetActive(true);
    }

    void Update()
    {
        for (int i = 0; i < healthGui.Length; i++)
        {
            if (i == currentHealth)
            {
                healthGui[i].SetActive(true);
            }
            else
            {
                healthGui[i].SetActive(false);
            }
        }
        for (int i = 0; i < lifeGui.Length; i++)
        {
            if (i == currentLife)
            {
                lifeGui[i].SetActive(true);
            }
            else
            {
                lifeGui[i].SetActive(false);
            }
        }
        deathTrigger = Physics2D.OverlapCircle(groundCheck.position, 0.15F, whatIsDeath);
        if (!deathTrigger)
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
                if (!GameController.instance.isMirrored)
                {
                    hor = -1;
                    isLookingRight = true;
                    isLookingLeft = false;
                }
                if (GameController.instance.isMirrored)
                {
                    hor = 1;
                    isLookingRight = false;
                    isLookingLeft = true;
                }
            }
            else if (Input.GetKey("a"))
            {
                if (!GameController.instance.isMirrored)
                {
                    hor = 1;
                    isLookingLeft = true;
                    isLookingRight = false;
                }
                if (GameController.instance.isMirrored)
                {
                    hor = -1;
                    isLookingLeft = false;
                    isLookingRight = true;
                }
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
        else
        {
            //Taking Damage is a bit weird till now. Swap Invoke with something really helpfull, that delays the taking of damage
            Invoke("TakeDamage", 2F);
        }
    }

    public void Fire()
    {
        float aim = Input.mousePosition.x - Screen.width;
        Vector3 adjustedOrigin = new Vector3();
        if (Input.mousePosition.x < Screen.width / 2)
            adjustedOrigin = spellOrigin.position + new Vector3(0.215F, 0);
        else
            adjustedOrigin = spellOrigin.position + new Vector3(-0.215F, 0);
        GameObject spell = (GameObject)Instantiate(spellPrefab, adjustedOrigin, Quaternion.identity);
        spell.GetComponent<Rigidbody2D>().AddForce(new Vector3(-(Input.mousePosition.x + aim * spellSpeed), Input.mousePosition.y));
    }

    void TakeDamage()
    {
        if (currentHealth >= 1)
        {
            currentHealth -= 1;
            Debug.Log("Health: " + currentHealth);
        }
        else
        {
            if (currentLife >= 1)
            {
                currentLife -= 1;
                lifeGui[currentLife + 1].SetActive(false);
                lifeGui[currentLife].SetActive(true);
                currentHealth += 5;
                Debug.Log("Life: " + currentLife);
            }
            else
            {
                //Do Something when the Player died
                Debug.Log("You are dead...are you?");
            }
        }
    }
}
