using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour {

    public GameObject background;
    private SpriteRenderer bkSprite;
    public Sprite spriteValey;
    public Sprite spriteForrest;
    private int state = 1;

	void Start () {
        bkSprite = background.GetComponent<SpriteRenderer>();
	}
	
	void Update () {

	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Entré al bkChanger");

        if (collision.gameObject.name == "Player")
        {


            switch (state)
            {
                case 1:
                    bkSprite.sprite = spriteValey;
                    state = 2;
                    break;
                case 2:
                    bkSprite.sprite = spriteForrest;
                    state = 1;
                    break;
                default:
                    bkSprite.sprite = spriteValey;
                    break;
            }
        }
    }
}
