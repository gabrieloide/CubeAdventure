using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float WaitTimer;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    IEnumerator ExclamationAlert()
    {
        int t = 1;
        while (t > 0)
        {
            spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
            yield return new WaitForSeconds(WaitTimer);
            spriteRenderer.color = new Color(255f, 255f, 255f, 0f);
            yield return new WaitForSeconds(WaitTimer);
            spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
            yield return new WaitForSeconds(WaitTimer);
            spriteRenderer.color = new Color(255f, 255f, 255f, 0f);
            t--;
            Destroy(gameObject);
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
                StartCoroutine(ExclamationAlert());
            
        }
    }
}
