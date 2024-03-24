using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarSuelo : MonoBehaviour
{
    public static bool isGround;
    private void OnTriggerEnter2D(Collider2D other)
    {
        isGround = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isGround = false;
    }
}
