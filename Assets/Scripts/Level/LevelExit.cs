using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public Image BlackScreen;
    public float ToBlack;
    public bool levelFinished = true;
    public float WaitUntilEnd;
    private void Update()
    {  
        if (levelFinished)
        {
            StartCoroutine(ExitLevel());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelFinished = true;
        }
    }
    public IEnumerator ExitLevel()
    {
        BlackScreen.transform.position = Vector2.MoveTowards(BlackScreen.transform.position, 
            new Vector2(202f, 114.5f), ToBlack);
        yield return new WaitForSeconds(WaitUntilEnd);
        SceneManager.LoadScene("Level Selector");
    }
}
