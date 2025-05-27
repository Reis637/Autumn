using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    private Vector3 cameraPosition;

    void Update()
    {                                  // posicion del jugador, mas la posicion del mouse
                                        // mientras que el jugador se mueve muy poco, unas dos unidades de movimiento por segundo,
                                        // la camara puede estar entre el 0 y el 1080, por ende, tengo que dividirlo por algun numero alto.
        cameraPosition = new Vector3(   target.position.x + (Input.mousePosition.x - 960) / 500,
                                        target.position.y + (Input.mousePosition.y - 540) / 500, 
                                        target.position.z - 10.0f);

        transform.position = cameraPosition;
    }
}