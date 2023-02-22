using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{

    public Transform portalTransform;

    public abstract void CreateCreepDanhGan();
    public abstract void CreateCreepDanhXa();
    public abstract void CreateCreepThaBoom();
    public abstract void CreateCreepGiap();
    public abstract void CreateCreepKing();

    public abstract void CreateBoss();
    // Start is called before the first frame update

}
