using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{


    public Sprite spritePrueba;
    public Sprite spritePrueba2;

    private Rigidbody2D rBody;
    Animator animator;

    public GameObject ground;

    public Equipement playerEquipment;

    public Inventory playerInventory;

    public Glove equippedGlove;

    //Movement
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float maxWalkSpeed;
    public float jumpSpeed;
    private Vector3 playerVelocity;
    public bool isGrounded;
    private float hitDistance;
    public LayerMask groundLayer;

    //Second Movement
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 100f;


    //Shoot
    public Transform firePoint;
    public LineRenderer lineRenderer;
    private float lastTimeShot;

    public BQuest quest;

    //UI
    public GameObject PlayerWindow;
    public Text UIHealth;

    //STATS
    public int invulnerabilitySecs = 2;
    public int initialMaxHealth = 100;
    public int maxHealth;
    public int currentHealth;
    public int experience = 0;
    public int level = 1;
    public int initialDamage;
    public int damage;
    public int initialAtkSpeed;
    public int attackSpeed;
    public int maxJumpQuantity = 1;
    public int jumpQuantity;
    public bool canDash = false;


    void Start()
    {
        equippedGlove = JsonUtility.FromJson<Glove>(Resources.Load<TextAsset>("JsonItems/Glove/BrokenGlove").text);
        initialDamage = equippedGlove.itemAtk;
        initialAtkSpeed = equippedGlove.itemSpeed;
        playerVelocity = Vector3.zero;
        rBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        animator = GetComponent<Animator>();
        maxHealth = initialMaxHealth;
        currentHealth = maxHealth;
        jumpQuantity = maxJumpQuantity;
        damage = initialDamage;
        attackSpeed = initialAtkSpeed;
    }


    public void EquipNewGlove(int posMage)
    {
        equippedGlove = JsonUtility.FromJson<Glove>(Resources.Load<TextAsset>("JsonItems/Glove/" + posMage).text);
        damage = equippedGlove.itemAtk;
        attackSpeed = equippedGlove.itemSpeed;
    }


    IEnumerator Shoot()
    {
        if (Time.time - lastTimeShot > 1/attackSpeed)
        {
            animator.SetBool("Attacking", true);

            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, transform.right);
            Debug.DrawRay(firePoint.position, transform.right, Color.red);

            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            lineRenderer.enabled = true;

            yield return 0;

            lineRenderer.enabled = false;

            animator.SetBool("Attacking", false);

            lastTimeShot = Time.time;
        }
    }



    private void PlayerGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.6f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
            jumpQuantity = maxJumpQuantity;
        }
        else
        {
            isGrounded = false;
        }
    }


    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }

    void Update()
    {

        UIHealth.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        PlayerGrounded();


        //playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerInventory.PickupItem(new Gem("Rubi", 1, "Fire Itself", spritePrueba, 1, 2, 2, Item.ItemType.Gem, false));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            playerInventory.PickupItem(new Mineral("Gold", 2, "Greed", spritePrueba2, 1, 0, Item.ItemType.Mineral, false));
        }

        
        if (Input.GetKeyDown(KeyCode.M) && rBody.velocity == Vector2.zero)
        {
            StartCoroutine(Shoot());
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);

        }else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }

        

        if (Input.GetKeyDown(KeyCode.Space) && jumpQuantity > 0)
        {
            jumpQuantity--;
            playerVelocity.y = jumpSpeed;
            animator.SetBool("Jumping", true);
        }
        else
        {
            playerVelocity.y = rBody.velocity.y;
            animator.SetBool("Jumping", false);
        }
        


        rBody.velocity = playerVelocity;

        if (direction == 0)
        {
            animator.SetBool("Dashing", false);


            if (Input.GetKeyDown(KeyCode.Q) && canDash)
            {
                animator.SetBool("Dashing", true);
                direction = 1;
            }else if (Input.GetKeyDown(KeyCode.E) && canDash)
            {
                animator.SetBool("Dashing", true);
                direction = 2;
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rBody.velocity = Vector2.left * dashSpeed;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                    
                }
                else if(direction == 2)
                {
                    rBody.velocity = Vector2.right * dashSpeed;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                    
                }
            }
        }
    }
}
