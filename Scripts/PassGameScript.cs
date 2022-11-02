using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassGameScript : MonoBehaviour
{
    public Text scoreText;
    public Text totalText;
    // Start is called before the first frame update
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " DIAMONDS";
        int total = SaveJson(score);
        totalText.text = "Your total diamonds: " + total.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public int SaveJson(int scoreCount)
    {
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
        int total = currentTreasure + scoreCount;
        treasure.TotalTreasure = total;
        Debug.Log("treasure: " + treasure.TotalTreasure);
        var savedJson = JsonUtility.ToJson(treasure);
        Debug.Log("saved json: " + savedJson);
        WriteToFile("Resources/Text/playerTreasure.json", savedJson);
        return total;
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
