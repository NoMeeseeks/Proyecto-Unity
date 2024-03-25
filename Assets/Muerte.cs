using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    public bool nivelUno;
    public bool nivelDos;
    public bool nivelTres;
    public bool nivelCuatro;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (nivelUno)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelInicial");
                Destroy(other.gameObject);
            }
        }
        else if (nivelDos)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelBonusVeridico");
                Destroy(other.gameObject);
            }
        }
        else if (nivelTres)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelInicial");
                Destroy(other.gameObject);
            }
        }
        else if (nivelCuatro)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelInicial");
                Destroy(other.gameObject);
            }
        }
    }
}
