using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
