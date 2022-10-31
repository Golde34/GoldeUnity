using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PassGameScript : MonoBehaviour
{
    public Text scoreText;
    public Text totalText;
    // Start is called before the first frame update
    public void Setup(int score, int total)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " DIAMONDS";
        totalText.text = "Your total diamonds: " + total.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
