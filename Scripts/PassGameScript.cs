using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Object;

public class PassGameScript : MonoBehaviour
{
    public Text scoreText;
    public Text totalText;
    // Start is called before the first frame update
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " DIAMONDS";
        int total = SaveTreasure(score);
        totalText.text = "Your total diamonds: " + total.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public int SaveTreasure(int scoreCount)
    {
        // Load total treasure
        var jsonTextFile = Resources.Load<TextAsset>("Text/playerTreasure");
        Treasure treasure = JsonUtility.FromJson<Treasure>(jsonTextFile.text);
        // Calculate total treasure
        int currentTreasure = treasure.totalTreasure;
        int total = currentTreasure + scoreCount;
        treasure.TotalTreasure = total;
        // Save treasure
        var savedJson = JsonUtility.ToJson(treasure);
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