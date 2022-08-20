using UnityEngine;
using UnityEngine.UI;

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
    public void PlayerDeath()
    {
       if (FindObjectOfType<PlayerController>().Health <= 0 || HUD.instance.timeLeft <= 0)
        {
            FindObjectOfType<AudioManager>().Stop("MainTheme");
            FindObjectOfType<AudioManager>().Play("GameOver");
            Player.SetActive(false);
            HUD.instance.HUDIcon.SetActive(false);   
        }
    }
    public void Collect()
    {
        HUD.instance.CoinAmount += FindObjectOfType<CoinsCollect>().value;
    }
}
