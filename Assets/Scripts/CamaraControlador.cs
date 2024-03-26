using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControlador : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player; // Transform del objeto del jugador
    public float offsetX; // Desplazamiento horizontal de la c�mara
    public float offsetY;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = transform.position;

        // Posici�n del jugador
        Vector3 playerPos = player.position;

        // Ajustar la posici�n de la c�mara con el offset
        camPos.x = playerPos.x + offsetX;
        camPos.y = playerPos.y + offsetY;

        // Actualizar la posici�n de la c�mara
        transform.position = camPos;
    }
}
