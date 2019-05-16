using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayCharacter2D : MonoBehaviour
{
    public int speed;
    public SpriteRenderer sr;
    public Animator anim;
    public Rigidbody2D rig;
    public float jumpForce;
    public Transform leftPosition;
    public Transform rightPosition;
    public Transform runningShootingLeft, runningShootingRight;
    public GameObject bullet;
    public Transform spawnTransform;
    public GameObject player;
    public float bulletSpeed;
    private bool isGrounded;
    private float shootTimer = .2f;
    public Text resetGameText;
    private float timer = 5;
    private bool isShooting;
    public GameObject enemyKnight;
    public float enemyDamage;
    public float HP;
    public float pushForce;
    private bool side;
    public Slider slider;
    void Start()
    {
        side = false;
        isGrounded = true;
        anim.SetBool("isGrounded", true);
        resetGameText.text = "Press Esc to return to Main Menu";
    }

    void Timer()
    {
        if (timer <= 0)
        {
            if (side == false)
            {
                Instantiate(enemyKnight, new Vector3(transform.position.x - 25.0F, 1F, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(enemyKnight, new Vector3(transform.position.x + 25.0F, 1F, 0), Quaternion.identity);
            }
            timer = 5;
            side = !side;
        }
        else timer -= Time.deltaTime;
    }

    void Update()
    {
        if (HP <= 0)
        {
            SceneManager.LoadScene("Dead");
        }
        if (transform.position.x >= 1000 || transform.position.x <= -1000)
        {
            SceneManager.LoadScene("Victory");
        }
        Timer();
        Movement();
        TextTimer();
        ReturnToMainMenu();
        if (rig.velocity.y < 0)
        {
            rig.velocity += Vector2.up * Physics2D.gravity * 2 * Time.deltaTime;
        }
        if (isShooting == true && isGrounded == true)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                isShooting = false;
                if (!sr.flipX)
                {
                    if (anim.GetBool("isWalking") == false)
                    {
                        GameObject newBullet = Instantiate(bullet, leftPosition.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -bulletSpeed;
                    } 
                    else
                    {
                        GameObject newBullet = Instantiate(bullet, runningShootingLeft.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -bulletSpeed;
                    }
                }
                else
                {
                    if (anim.GetBool("isWalking") == false)
                    {
                        GameObject newBullet = Instantiate(bullet, rightPosition.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
                    }
                    else
                    {
                        GameObject newBullet = Instantiate(bullet, runningShootingRight.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
                    }
                }
                anim.SetBool("isShooting", false);
                shootTimer = .2f;
            }
        }
    }

    private void ReturnToMainMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void TextTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            resetGameText.text = "";
        }
    }

    void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isShooting", true);
            isShooting = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                anim.SetBool("isShooting", false);
                rig.AddForce(new Vector2(0, jumpForce));
                isGrounded = false;
                anim.SetBool("isGrounded", false);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isShooting", false);
            anim.SetBool("isWalking", true);
            sr.flipX = true;
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isShooting", false);
            anim.SetBool("isWalking", true);
            sr.flipX = false;
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        else anim.SetBool("isWalking", false);
    }

    private void Hit()
    {
        HP -= enemyDamage;
        slider.value = HP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
        if (collision.gameObject.tag == "EnemyKnight")
        {
            Collider2D collider = collision.collider;
            Hit();
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            bool right = contactPoint.x > center.x;
            if (right)
            {
                rig.AddForce(new Vector2(pushForce, 1));
            }
            else
            {
                rig.AddForce(new Vector2(-pushForce, 1));
            }
        }
    }

}
