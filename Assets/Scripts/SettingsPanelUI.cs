using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanelUI : MonoBehaviour
{
    public GameObject settingsPanel;

       
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

}