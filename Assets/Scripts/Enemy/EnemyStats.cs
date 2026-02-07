using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyData enemyData;
    public float attackDamage => enemyData.attackDamage;
}
