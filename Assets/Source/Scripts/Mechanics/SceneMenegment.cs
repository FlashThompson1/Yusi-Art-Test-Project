using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenegment : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private TextMeshProUGUI _changeText;


    public static SceneMenegment Instance;


    private void Awake()
    {
        Instance = this;
    }

   

    private void Update()
    {
        if (_tutorialPanel.activeSelf)
        {
            Time.timeScale = 0;
        }
        if (_tutorialPanel.activeSelf == false)
        {
            Time.timeScale = 1;
        }
    }


    public void LoadNextScene(int ID) { 
        SceneManager.LoadScene(ID);
    }


    public void Pausing() { 
    
        Time.timeScale = 0;
        _pausePanel.SetActive(true);

    }

    public void LosingPanel() {
        Pausing();
        _changeText.text = "Game Over";
    }


 

    public void UnPausing()
    {

        Time.timeScale = 1;
        _pausePanel.SetActive(false);

    }


    public void Exit() { 
    
        Application.Quit();
        
    }
}
