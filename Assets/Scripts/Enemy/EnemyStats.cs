using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyData enemyData;
    public float attackDamage => enemyData.attackDamage;
    public float maxHp => enemyData.maxHp;
    public float currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeaponAttack"))
        {
            TakeDamage(collision.GetComponentInParent<WeaponDamage>().attackDamage);
        }
    }

    private void TakeDamage(float weaponDamage)
    {
        currentHp -= weaponDamage;
        if (currentHp <= 0)
            Destroy(gameObject);
    }
}
