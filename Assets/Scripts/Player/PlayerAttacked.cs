using System.Collections;
using UnityEngine;

public class PlayerAttacked : MonoBehaviour
{
    public bool isKnockedback = false;
    public bool isInvincible = false;
    Rigidbody2D rb;

    private float knockbackForce = 7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Invincible());

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.transform.position.x < transform.position.x)
                StartCoroutine(Knockback(knockbackForce));

            else
                StartCoroutine(Knockback(-knockbackForce));
        }
    }

    IEnumerator Knockback(float knockbackForce)
    {
        isKnockedback = true;
        rb.linearVelocity = new Vector2(knockbackForce, rb.linearVelocity.y);
        yield return new WaitForSeconds(0.1f);

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        isKnockedback = false;
    }

    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
