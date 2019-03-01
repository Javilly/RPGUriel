using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour {

    public GameObject profileUI;
    public Player player;
    public QuestGiver questGiver;
    public Image gloveIcon;
    public Text damage;
    public Text atkSpeed;
    public Text jumps;

    private bool profileOpened = false;

    void OpenProfile()
    {
        profileUI.SetActive(true);
        gloveIcon.sprite = player.equippedGlove.itemIcon;
        damage.text = "Damage: " + player.damage.ToString();
        atkSpeed.text = "Atk Speed: " + player.attackSpeed.ToString();
        jumps.text = "Jumps: " + player.jumpQuantity.ToString();
    }

    void CloseProfile()
    {
        profileUI.SetActive(false);
    }


	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!profileOpened)
            {
                OpenProfile();
                profileOpened = true;
            }else{
                CloseProfile();
                profileOpened = false;
            }
        }
	}
}
