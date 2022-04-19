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
        myBody.velocity = new Vector2(BulletSpeed, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión de Bullet");
        myAnim.SetBool("hasCollided", true);
    }

    public void BulletDestruction()
    {
        Debug.Log("Destrucción de bala");
        GameObject instance = player.GetComponent<Player>().GetInstanceBullet();
        if (instance != null)
        {
            GetComponent<Player>().DestroyInstanceBullet();
        }

    }
}

