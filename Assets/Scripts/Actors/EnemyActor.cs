﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyType
{
    melee,
    ranged
}

abstract class EnemyActor : IActor
{

    protected void drop()
    {

    }
}