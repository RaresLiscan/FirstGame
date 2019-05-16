using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{

    public float timer;
    public GameObject particles;
    private bool hit = false;

    void Update()
    {
        if (hit == true) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (particles) Instantiate(particles, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyKnight")
        {
            if (particles) Instantiate(particles, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
            hit = true;
        }
    }
}
