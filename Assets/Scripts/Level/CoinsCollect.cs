using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    public int value = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.Collect();
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}
