using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override EnemyType GetEnemyType()
    {
        return EnemyType.Boss;
    }


}
