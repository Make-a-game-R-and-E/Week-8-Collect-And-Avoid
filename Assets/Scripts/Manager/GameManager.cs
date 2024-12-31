using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static GameManager Instance;
    [SerializeField] string loseSceneName; // Name of the lose scene

    [SerializeField] string winSceneName; // Name of the win scene

    [SerializeField] int score = 0; // Score
    [SerializeField] int lives = 3; // Lives

    [SerializeField] TextMeshProUGUI scoreText; // Text for score
    [SerializeField] TextMeshProUGUI livesText; // Text for lives

    [SerializeField] int winScore = 10; // Score to win

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;

        UpdateScoreText(); // Update the score text

        if (score >= winScore)
        {
            YouWin();
        }
    }

    public void ReduceLife()
    {
        lives--;
        UpdateLivesText(); // Update the lives text

        if (lives <= 0) // You cant live with less than 0 lives...
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + " / " + winScore;
        }
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(loseSceneName); // Load the lose scene
        Debug.Log("Game Over!");
    }

    void YouWin()
    {
        SceneManager.LoadScene(winSceneName); // Load the win scene
        Debug.Log("You Win!");
    }
}
