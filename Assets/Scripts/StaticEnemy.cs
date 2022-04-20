using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    float allowFire;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.left, 4f, LayerMask.GetMask("Player"));
        
        if ((ray.collider != null) && (Time.time > allowFire))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            allowFire = Time.time + fireRate;
            Debug.Log("Jugador en mira turret");
        }

        if (life == 0)
        {
            myAnim.SetBool("hasDied", true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión con Turret");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.left);
    }
}
