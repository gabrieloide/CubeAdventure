using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public GameObject MenuPause;
    public bool IsPaused;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }
    public void Resume()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

}
