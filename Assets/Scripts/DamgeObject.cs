using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DamgeObject : MonoBehaviour
{
 private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            SceneManager.LoadScene("NivelFacil");

        }
    }
}
