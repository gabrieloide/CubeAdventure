using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float ToBlack;
    public Image CortinaNegra;
    private void Update()
    {
        if (PlayerController.instance.Health <= 0 || HUD.instance.timeLeft <= 0)
        {
            CortinaNegra.transform.position = Vector2.MoveTowards(CortinaNegra.transform.position, new Vector2(transform.position.x, transform.position.y), ToBlack);
        }
    }
}