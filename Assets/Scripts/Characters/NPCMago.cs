using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMago : MonoBehaviour {

    private bool playerNear;


    void Start () {
        Invoke("RandomRotate", 0.5f);
    }

    void RandomRotate()
    {
        float randomTime = Random.Range(3, 7);

        bool reverse = false;

        if (reverse)
        {
            transform.Rotate(Vector3.up * 180);
        }
        else
        {
            transform.Rotate(Vector3.up * 180);
        }
        

        Invoke("RandomRotate", randomTime);

    }

    /*
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            playerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        playerNear = false;
        canvasQuest.SetActive(false);
    }

    void Update () {
        if (playerNear && Input.GetKeyDown(KeyCode.F))
        {
            questBook.StartQuest(Application.dataPath + "/Resources/Quests/Quest2.xml");
        }
	}
    */
}
