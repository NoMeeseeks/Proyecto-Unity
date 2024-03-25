using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nivel : MonoBehaviour
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

            }
        }
        else if (nivelDos)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelBonusVeridico");
            }
        }
        else if (nivelTres)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelInicial");
            }
        }
        else if (nivelCuatro)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("NivelInicial");
            }
        }
    }
}
