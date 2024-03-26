using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectorFrutas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject,0.5f);
        }
    }
}
