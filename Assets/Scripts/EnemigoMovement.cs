using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovement : MonoBehaviour
{
    public GameObject ObjetoAmover;
    public Transform StartPoint;
    public Transform EndPoint;
    public float velocidad;
    private Vector3 MoverHacia;

    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = EndPoint.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (ObjetoAmover == null) return;

        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, velocidad * Time.deltaTime);

        if (ObjetoAmover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;

        }

        if (ObjetoAmover.transform.position == StartPoint.position)
        {
            MoverHacia = EndPoint.position;

        }

    }
}
