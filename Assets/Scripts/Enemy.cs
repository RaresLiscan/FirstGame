using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer sr;
    public float speed;
    public Animator anim;
    public Rigidbody2D rig;
    public float jumpForce;
    public float hp;
    public float bulletDamage;
    public GameObject enemyKnight;
    private bool isGrounded;
    private Transform characterPosition;
    private float timer = 1F;

    void Update()
    {
        characterPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Movement();
        if (hp <= 0)
        {
            GameObject.Destroy(enemyKnight);
            //GameObject go = GameObject.Find("KillCounter").GetComponent<KillCounter>.counter++;
            GameObject.Find("KillCounter").GetComponent<KillCounter>().counter ++;
        }
    }

    private void Movement()
    {
        if (rig.velocity.y < 0 && isGrounded == false)
        {
            rig.velocity += Vector2.up * Physics2D.gravity * 2 * Time.deltaTime;
        }
        if (characterPosition.position.x < transform.position.x)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            sr.flipX = true;
            anim.SetBool("isWalking", true);
        }
        else if (characterPosition.position.x > transform.position.x)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            sr.flipX = false;
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        //{
        //    anim.SetBool("isGrounded", false);
        //    rig.AddForce(new Vector2(0, jumpForce));
        //    isGrounded = false;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //    sr.flipX = true;
        //    anim.SetBool("isWalking", true);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //    sr.flipX = false;
        //    anim.SetBool("isWalking", true);
        //}
        //else anim.SetBool("isWalking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("isGrounded", true);
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            rig.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= bulletDamage;
        }
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Hitting", true);
            //while (timer > 0) timer -= Time.deltaTime;
            //anim.SetBool("Hitting", false);
        }
        else
        {
            anim.SetBool("Hitting", false);
        }
    }
}
