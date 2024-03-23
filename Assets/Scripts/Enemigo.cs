using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;

    public bool atacando;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("PJ");
    }

    public void Comportamientos()
    {
        anim.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                anim.SetBool("walk", false);
                break;
            case 1:
                direccion = Random.Range(0, 2);
                break;
            case 2:
                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                }
                anim.SetBool("walk", true);
                break;
        }
    }
    void Update()
    {
        Comportamientos();
    }
}
