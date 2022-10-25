using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public bool isDestroy;
    public string type;
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
            if (type == "money")
            {
                ScoreManager.instance.AddPoint();
            }
            Destroy(gameObject);
        }
    }
}
