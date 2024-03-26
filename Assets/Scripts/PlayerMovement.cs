using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    public GameObject BulletPrefab;
    public LayerMask capaSuelo;
    public int saltosMaximos;
    private Rigidbody2D myrigidbody2D;
    private BoxCollider2D boxcollider;
    private SpriteRenderer myspriterenderer;
    private Boolean mirandoderecha = true;
    private int index;
    private int saltosRestantes;


    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        myspriterenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPlayer();
        SaltoPlayer();

        if (BulletPrefab == null) return;

        if (Input.GetKeyDown(KeyCode.T))

        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);

        }


    }


    void MovimientoPlayer()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        myrigidbody2D.velocity = new Vector2(moveInput * playerSpeed, myrigidbody2D.velocity.y);
        GestionarMovimiento(moveInput);
    }
    void GestionarMovimiento(float moveInput)
    {
        if ((mirandoderecha == true && moveInput < 0) || (mirandoderecha == false && moveInput > 0))
        {
            mirandoderecha = !mirandoderecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }



    }
    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, new Vector2(boxcollider.bounds.size.x, boxcollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void SaltoPlayer()
    {
        if (EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;

        }
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.07f);
        myspriterenderer.sprite = mySprites[index];
        index++;
        if (index == 5)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRoutine());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = collision.transform;
        }
        else if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = null;
        }

    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("EscenaMel");
    }

}
