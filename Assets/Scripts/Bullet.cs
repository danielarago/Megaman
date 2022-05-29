using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator myAnim;
    [SerializeField] float BulletSpeed;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = transform.right * BulletSpeed;
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        myAnim.SetTrigger("death");
        myBody.velocity = new Vector2 (0,0);
    }

    public void BulletDestruction()
    {
        Destroy(gameObject);
    }
}

