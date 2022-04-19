using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D myBody;
    Animator myAnim;
    bool IsGrounded = true;
    [SerializeField] float JumpForce;
    [SerializeField] GameObject bullet;
    [SerializeField] float FireRate;
    public GameObject instanceBullet;
    private float AllowFire;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        StartCoroutine(Corutina());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, LayerMask.GetMask("Ground"));
        IsGrounded = (ray.collider != null);

        Jump();
        Fire();
    }

    private void FixedUpdate()
    {
        float dirH = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector2(dirH * speed, myBody.velocity.y);

        if (dirH != 0)
        {
            myAnim.SetBool("isRunning", true);
            if (dirH < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        if (IsGrounded && !myAnim.GetBool("isJumping"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                myAnim.SetBool("isJumping", true);
            }
        }

        if (myBody.velocity.y != 0 && !IsGrounded)
        {
            myAnim.SetBool("isJumping", true);
        } else
        {
            myAnim.SetBool("isJumping", false);
        }
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            myAnim.SetLayerWeight(1, 1);
            if (Time.time > AllowFire)
            {
                instanceBullet = Instantiate(bullet, transform.position, transform.rotation);
                AllowFire = Time.time + FireRate;
            }
        } 
        else
        {
            myAnim.SetLayerWeight(1, 0);
        }
    }

    public void FinishingRun()
    {
        Debug.Log("Termina de correr :3");
    }

    IEnumerator Corutina()
    {
        while (true)
        {
            Debug.Log("Esperando 4 segundos");
            yield return new WaitForSeconds(4);
            Debug.Log("Pasaron 4 segundos");
        }
    }

    /*public GameObject GetInstanceBullet()
    {
            return instanceBullet; 
    }

    public void DestroyInstanceBullet()
    {
        GameObject BulletToDestroy = GetInstanceBullet();
        if (BulletToDestroy != null)
        {
            Destroy(BulletToDestroy);
        }
    }*/
}
