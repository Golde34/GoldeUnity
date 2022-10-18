using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public GameObject boxPrefab;
    public List<GameObject> boxPrefabs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Create random box");
        GameObject box = Instantiate(boxPrefab, new Vector2(42.89f, -1.35f), Quaternion.identity);
        boxPrefabs.Add(box);
        GameObject box1 = Instantiate(boxPrefab, new Vector2(52.89f, -1.35f), Quaternion.identity);
        boxPrefabs.Add(box1);
        Debug.Log("-----------------");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
