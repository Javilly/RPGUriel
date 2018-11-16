using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wea : MonoBehaviour {


    private Rigidbody2D rBody;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;



    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }


    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rBody.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rBody.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rBody.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    rBody.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    rBody.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
}

