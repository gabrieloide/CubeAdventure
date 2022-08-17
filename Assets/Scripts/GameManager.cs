using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Level 1");
        }
    }
    public void PlayerDeath()
    {
       if (FindObjectOfType<PlayerController>().Health <= 0 || HUD.instance.timeLeft <= 0)
        {
            Player.SetActive(false);
            HUD.instance.HUDIcon.SetActive(false);   
        }
    }
    public void Collect()
    {
        HUD.instance.CoinAmount += FindObjectOfType<CoinsCollect>().value;
    }
}
