using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float maxHp = 3f;
    public float currentHp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.GetComponent<EnemyStats>().attackDamage);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHp -= damage;
        Debug.Log($"현재 체력: {currentHp}");
    }
}
