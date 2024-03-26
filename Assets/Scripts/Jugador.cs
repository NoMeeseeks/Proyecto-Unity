using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private float movimientoHorizontal = 0f; // entrada de los controles
    public float velocidadDeMovimiento;
    public float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;

    public float fuerzaDeSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;
    public bool salto = false;
    private bool moviendoDerecha = true;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

    }

    private void FixedUpdate()
    {
        //Mover
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        if (movimientoHorizontal != 0f)
        {
            animator.SetBool("corriendo", true);
        }
        else
        {
            animator.SetBool("corriendo", false);
        }
        salto = false;

    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }

        if (mover > 0 && !moviendoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && moviendoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }
}