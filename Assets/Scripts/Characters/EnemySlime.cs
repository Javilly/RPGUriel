using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour {

    public float idleSpeed = 30;
    public float agroSpeed = 30;
    public float jumpSpeed = 30;

    private Coroutine slimeUpdate;
    private Rigidbody2D body;

    public bool chasingPlayer;

    public Player player;

    private float distSlimePlayer;

    public int damage = 10;

    private bool dmgCD = false;

    public int xpGiven;


    void Awake()
    {
        // Get a reference to our physics component
        body = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        // Start the idle coroutine
        slimeUpdate = StartCoroutine(Idle());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //print("the player is in range!");
            chasingPlayer = true;
            // Stop Idle
            StopCoroutine(slimeUpdate);
            // Start Agro
            slimeUpdate = StartCoroutine(Agro(other.transform));
        }
        else if (transform.position.y == other.transform.position.y && !chasingPlayer)
        {
            print("another object is in range!");
            int direction = (this.transform.position.x > other.transform.position.x) ? 1 : -1;
            body.velocity = (new Vector2(idleSpeed * direction, 0));
        }
    }

    IEnumerator Agro(Transform player)
    {
        while (true)
        {
            // 1 if player is to the right of us, -1 if player is to the left of us
            int direction = (this.transform.position.x < player.position.x) ? 1 : -1;

            // Jump towards the player
            body.velocity = (new Vector2(agroSpeed * direction, jumpSpeed));

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(player.invulnerabilitySecs);
        dmgCD = false;
    }

    IEnumerator Idle()
    {
        int direction = 1;

        while (true)
        {

            // Move in a direction
            body.velocity = (new Vector2(idleSpeed * direction, 0));

            // Change the direction we move in
            direction *= -1;

            // Wait
            yield return new WaitForSeconds(2);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //print("The player has escaped.");
            chasingPlayer = false;
            // Stop Agro
            StopCoroutine(slimeUpdate);
            // Start Idle
            slimeUpdate = StartCoroutine(Idle());
        }
    }

    private void FixedUpdate()
    {
        distSlimePlayer = Vector2.Distance(player.transform.position, transform.position);
        if(distSlimePlayer < 1.4 && !dmgCD)
        {
            player.currentHealth -= damage;
            dmgCD = true;
            StartCoroutine(AttackCD());
        }
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
