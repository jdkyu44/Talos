using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHp = 3f;
    public float currentHp;
    public float attackDamage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(other.GetComponent<EnemyStats>().attackDamage);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHp -= damage;
        Debug.Log($"현재 체력: {currentHp}");
    }
}
