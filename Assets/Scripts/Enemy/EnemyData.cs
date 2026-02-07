using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public enum EnemyType
    {
        Ground,
        Flying
    }

    [Header("Name")]
    public string enemyName;

    [Header("Type")]
    public EnemyType enemyType;

    [Header("Basic Stats")]
    public float maxHp;
    public float attackDamage;
    public float moveSpeed;

    [Header("Movement Pattern")]
    public float detectRange;
}
