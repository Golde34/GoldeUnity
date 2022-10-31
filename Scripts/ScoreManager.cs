using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
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
        if (scoreCount == gameController.GetTotalTreasure(totalTreasure))
        {
            Debug.Log("did we win?");
            //passGameController.Setup(scoreCount);

            //var jsonTextFile = Resources.Load<TextAsset>("Text/playerTreasure");
            //Debug.Log("score: " + jsonTextFile.text);
            //Treasure[] treasure = JsonHelper.FromJson<Treasure>(jsonTextFile.text);
            //treasure[0].total = (int)treasure[0].total + scoreCount;
            //var s = JsonHelper.ToJson<Treasure>(treasure);
            var jsonTextFile = Resources.Load<TextAsset>("Text/playerTreasure");
            Debug.Log("score: " + jsonTextFile.text);
            Treasure treasure = JsonUtility.FromJson<Treasure>(jsonTextFile.text);
            Debug.Log("onject: " + treasure.totalTreasure);
            int currentTreasure = treasure.totalTreasure;
            treasure.TotalTreasure = currentTreasure + scoreCount;
            Debug.Log("treasure: " + treasure.TotalTreasure);
            var savedJson = JsonUtility.ToJson(treasure);
            Debug.Log("saved json: " + savedJson);
            WriteToFile("Resources/Text/playerTreasure.json", savedJson);

            passGameController.Setup(scoreCount, currentTreasure + scoreCount);

        }
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.dataPath + "/" + fileName;
    }
}

public class Treasure
{
    public int totalTreasure;

    public int TotalTreasure
    {
        get { return totalTreasure; }
        set { totalTreasure = value; }
    }
}

