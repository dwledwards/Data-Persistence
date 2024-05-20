using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private InputField nameInput;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        MenuDataManager.Instance.LoadData();
        if(MenuDataManager.Instance != null )
        {
            scoreText.text = "Best Score: " + MenuDataManager.Instance.HighScoreName + " " + MenuDataManager.Instance.Score;
        }
        
    }

    public void StartGame()
    {
        if(nameInput.text != null)
        {
            MenuDataManager.Instance.CurrentPlayerName = nameInput.text;
        }
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
