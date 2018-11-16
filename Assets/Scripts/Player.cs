using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float maxWalkSpeed;
    public float jumpSpeed;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private Vector3 playerVelocity;
    private Rigidbody2D rBody;

    void Start()
    {
        playerVelocity = Vector3.zero;
        rBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y = jumpSpeed;
        }
        else
        {
            playerVelocity.y = rBody.velocity.y;
        }

        rBody.velocity = playerVelocity;
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                direction = 1;
            }else if (Input.GetKeyDown(KeyCode.E))
            {
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
                }
                else if(direction == 2)
                {
                    rBody.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }
}
