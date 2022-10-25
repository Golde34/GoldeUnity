using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI score;

    int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Treasure Box found: "+scoreCount.ToString();
    }

    private void Awake()
    {
        instance = this; 
    }

    public void AddPoint()
    {
        scoreCount++;
        score.text = "Treasure Box found: " + scoreCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
