using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{


    protected float speed;
    protected float dame;
    protected float heal;
    protected int Diamond;

    public enum EnemyType
    {
        Boss, Creep
    }

    public abstract EnemyType GetEnemyType();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
