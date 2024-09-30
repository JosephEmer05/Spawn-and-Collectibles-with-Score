using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public Text scoreText;              

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }
}
