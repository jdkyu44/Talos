using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float maxHp = 3f;
    public float currentHp;
    PlayerAttacked playerAttcked;

    private void Awake()
    {
        playerAttcked = GetComponent<PlayerAttacked>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerAttcked.isInvincible == true)
            return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyStats>().attackDamage);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHp -= damage;
        Debug.Log($"현재 체력: {currentHp}");
    }
}
