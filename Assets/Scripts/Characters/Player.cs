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



    public BQuest quest;

    //UI
    public GameObject PlayerWindow;
    public Text UIHealth;

    //STATS
    public int invulnerabilitySecs = 2;
    public int maxHealth = 100;
    public int currentHealth;
    public int experience = 0;
    public int level = 1;
    public int damage;
    public int maxJumpQuantity = 1;
    public int jumpQuantity;
    public bool canDash = false;


    void Start()
    {
        playerVelocity = Vector3.zero;
        rBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        jumpQuantity = maxJumpQuantity;
}



    public void EnemyKill()
    {
        if (quest.active)
        {
            quest.goal.EnemyKill();
            if (quest.goal.Isreached())
            {
                experience += quest.xpReward;
                quest.Complete();
            }
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


    void FixedUpdate()
    {
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rBody.AddForce(movement * maxWalkSpeed);
        */

        UIHealth.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        PlayerGrounded();


        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;


        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerInventory.PickupItem(new Gem("Rubi", 1, "Fire Itself", spritePrueba, 1, 2, 2, Item.ItemType.Gem));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            playerInventory.PickupItem(new Gem("Diamond", 2, "Ice Itself", spritePrueba2, 1, 0, 0, Item.ItemType.Gem));
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
