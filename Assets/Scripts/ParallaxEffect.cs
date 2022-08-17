using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Transform cameraTransform;
    Vector3 previousCameraPosition;
    float spriteWidth,startposition;

    [Range(0f, 1f)]
    public float parallaxMultuplier;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startposition = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * parallaxMultuplier;
        float moveAmount = cameraTransform.position.x * (1 - parallaxMultuplier);
        //El fondo se mueve un % de lo que se mueve la camara
        /// los valores cercanos a 0 se mueven poco con respecto a la camara, es util para los objetos cercanos como el suelo plantas etc
        /// los valores cercanos a 1 se mueven a una velocidad cercana a la de la camara, es util para objetos como las nubes montanas etc
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;

        if (moveAmount > startposition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startposition += spriteWidth;
        }
        else if (moveAmount < startposition - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startposition -= spriteWidth;
        }
    }
}
