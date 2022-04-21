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
        transform.Translate(Vector3.right * BulletSpeed * Time.deltaTime);
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        myAnim.SetBool("hasCollided", true);
    }

    public void BulletDestruction()
    {
        Destroy(gameObject);
    }
}

