using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : Enemy
{
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Creep;
    }

 
}
