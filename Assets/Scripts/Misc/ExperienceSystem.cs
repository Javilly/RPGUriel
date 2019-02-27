using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour {

    public Player player;

    private int currentLvl;
    private int nextLvl;

    private int currentXP;
    private int neededXP;


    private int ExperienceNeededNextLvl(int currentLvl)
    {
        return Mathf.RoundToInt(100 * Mathf.Pow(Mathf.PI, currentLvl / 5));
    }

    private void Start()
    {
        currentLvl = player.level;
        nextLvl = currentLvl + 1;
        currentXP = player.experience;
        neededXP = ExperienceNeededNextLvl(currentLvl);
    }


    public void GainExp(int xpGained)
    {
        currentXP += xpGained;
        if(currentXP >= neededXP)
        {
            currentXP = neededXP - currentXP;
            currentLvl = nextLvl;
            nextLvl++;
            neededXP = ExperienceNeededNextLvl(currentLvl);
            player.level = currentLvl;
        }
    }

    public void LoseExp()
    {
        currentXP = (currentXP / 4) * 3;
    }
}
