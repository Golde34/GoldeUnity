using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI score;

    int scoreCount = 0;
    int totalTreasure;
    public GameControllerScript gameController;
    public PassGameScript passGameController;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Treasure Box found: " + scoreCount;
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        scoreCount++;
        int t = gameController.GetTotalTreasure(totalTreasure);
        score.text = "Treasure Box found: " + scoreCount.ToString() + "/" + t;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject KingHuman = GameObject.Find("KingHuman");

        NavMeshAgent agent = KingHuman.GetComponent<NavMeshAgent>();
        
        if (scoreCount == gameController.GetTotalTreasure(totalTreasure))
        {
            Debug.Log("did we win?");
            passGameController.Setup(scoreCount);
            agent.isStopped = true;
            scoreCount = 0;
        }
            
    }

    
}



