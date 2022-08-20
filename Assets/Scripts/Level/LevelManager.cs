using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
            FindObjectOfType<AudioManager>().Play("MainTheme");
    }
    void Update()
    {
        
    }
    public void loadLevelOne()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
    public void loadLevelTwo()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene("Level 2");
    }
    public void loadLevelThree()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 3");
    }
    public void ApplicationQuit()
    {
        Application.Quit();   
    }
    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
        
    }
}
