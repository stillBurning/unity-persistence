using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField playerNameInputField;

    
    private void Start()
    {
        PlayerSettings.Instance.Load();
        playerNameInputField.text = PlayerSettings.Instance.CurrentPlayer.Name;
    }

    public void LoadGameScene(string sceneName)
    {
        PlayerSettings.Instance.CurrentPlayer.Name = playerNameInputField.text;
        SceneManager.LoadScene(sceneName);
    }
}
