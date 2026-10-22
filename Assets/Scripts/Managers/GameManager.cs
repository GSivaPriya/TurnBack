using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerInputScript playerinputScript;
    [SerializeField] public float gameTime=120f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;
    float score;
    public bool gameOver = false;

    private void OnEnable() 
    {
        playerinputScript.PausePressed+= DisplayPausePanel;  
    }
    private void OnDisable() 
    {
        playerinputScript.PausePressed-=DisplayPausePanel;    
    }
    
    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState=CursorLockMode.Locked;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime-=Time.deltaTime;
        timeDisplay.text= "Time: " + Mathf.RoundToInt(gameTime).ToString();
        if(gameTime<=0f)
        {
            gameOver=true;
            gameTime=0f;
            gameOverPanel.SetActive(gameOver);
            scoreDisplay.text = "Score: "+score.ToString();
            Cursor.lockState=CursorLockMode.None;
            Time.timeScale=0f;
        }        
    }
    public void UpdateScore(float m_score)
    {
        score+=m_score;
        scoreText.text = "Score: " + score.ToString();
    }

    void DisplayPausePanel()
    {
        pausePanel.SetActive(true);
        Cursor.lockState=CursorLockMode.None;
        Time.timeScale=0f;
    }

    public void OnResumeGame()
    {
        Debug.Log("Resume button clicked!");
        pausePanel.SetActive(false);
        Cursor.lockState=CursorLockMode.Locked;
        Time.timeScale=1f;
    }
}
