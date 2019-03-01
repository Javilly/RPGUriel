using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;
	public GameObject deathEffect;
    public QuestManager questManager;

	public void TakeDamage (int damage)
	{
		health -= damage;
        questManager.questGiver.quest.active = true;
		if (health <= 0)
		{
            questManager.SlimeKill();
			Die();
		}
	}

	void Die ()
	{
		Destroy(gameObject);
	}

}
