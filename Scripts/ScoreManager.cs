using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int totalTreasure;

    public TextMeshProUGUI score;

    int scoreCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Treasure Box found: "+scoreCount+"/"+ totalTreasure;
    }

    private void Awake()
    {
        instance = this;
        totalTreasure = 0;
    }

    public void AddPoint()
    {
        scoreCount++;
        score.text = "Treasure Box found: " + scoreCount + "/" + totalTreasure;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
