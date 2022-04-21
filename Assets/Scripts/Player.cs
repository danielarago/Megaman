using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D myBody;
    Animator myAnim;
    bool IsGrounded = true;
    [SerializeField] float JumpForce;
    [SerializeField] GameObject bullet;
    [SerializeField] float FireRate;
    private float AllowFire;
    AudioSource myAudio;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip bulletSound;
    public GameObject bulletSource;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
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
                transform.localScale = new Vector2(1, 1);
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
                transform.eulerAngles = new Vector3(0,0,0);
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
                GameObject instanceBullet = Instantiate(bullet, bulletSource.transform.position, bulletSource.transform.rotation);
                AllowFire = Time.time + FireRate;
                myAudio.PlayOneShot(bulletSound);
            }
        } 
        else
        {
            new WaitForSeconds(5);
            myAnim.SetLayerWeight(1, 0);
        }
    }

    IEnumerator Corutina()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            myAnim.SetBool("isDying", true);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        new WaitForSeconds(1);
        myAudio.PlayOneShot(deathSound);
        new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }


}
