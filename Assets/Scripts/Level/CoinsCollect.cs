using UnityEngine;

public class CoinsCollect : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.Collect();
            gameObject.SetActive(false);
        }
    }

}
