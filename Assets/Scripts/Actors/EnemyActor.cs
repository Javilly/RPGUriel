using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyTipe
{
    melee,
    ranged
}

abstract class EnemyActor : IActor
{

    //protected FSMState myFsm;


    protected void drop()
    {

    }
}