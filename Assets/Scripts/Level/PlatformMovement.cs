using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed;
    public int startPos;
    public Transform[] Points;

    int i;
    
    private void Start()
    {
        transform.position = Points[startPos].position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, Points[i].position) < 0.02f)
        {
            i++;
            if (i == Points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -13), Points[i].position, movementSpeed * Time.deltaTime);
    }
}
