using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public static HUD instance;
    public Text Timer, coins;
    public GameObject HUDIcon;
    public float timeLeft;
    public int CoinAmount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Timer.text = timeLeft.ToString("f0");
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        Timer.text = timeLeft.ToString("f0");
        coins.text = CoinAmount.ToString();
    }
}
