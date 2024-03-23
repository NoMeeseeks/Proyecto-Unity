using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor;
    // public Text textScore; // Objeto Text para mostrar la puntuación en la interfaz de usuario
    // Detectar colisiones con el jugador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si el objeto con el que colisiona tiene la etiqueta "Player"
        {
            //ScoreManager.AddScore(10); // Aumentar la puntuación del jugador al recoger la moneda (por ejemplo, 10 puntos)
            Destroy(this.gameObject); // Destruir la moneda
        }
    }
}
