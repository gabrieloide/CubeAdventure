using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] movementSpot;
    public float speed;
    int RandomSpot;

    private void Start()
    {
        RandomSpot = Random.Range(0, movementSpot.Length);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movementSpot[RandomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movementSpot[RandomSpot].position) < 0.2f)
        {
            RandomSpot = Random.Range(0, movementSpot.Length);
        }
    }
}