using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public bool isDestroy;
    public string type;
    public bool first = true;
    Animator animator;
    // Start is called before the first frame update
    void Start()    
    {
        isDestroy = false;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy)
        {
            if (type == "money")
            {
                if(first == true)
                {
                    ScoreManager.instance.AddPoint();
                    first = false;
                }
                
                animator.SetBool("isBreak", true);
                Destroy(gameObject, 1);
                return;
            }
            Destroy(gameObject);
        }
    }
}
