using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public bool isDestroy;
    // Start is called before the first frame update
    void Start()
    {
        isDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroy)
        {
            Debug.Log("Boom!");
            Destroy(gameObject);
        }
    }
}
