using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyData enemyData;

    [SerializeField] private Transform patrolRoot;
    private Transform startPoint;
    private Transform endPoint;
    private Transform player;

    private Transform currentTarget;

    private void Start()
    {
        startPoint = patrolRoot.Find("StartPoint");
        endPoint = patrolRoot.Find("EndPoint");

        player = GameObject.FindWithTag("Player").transform;
        currentTarget = endPoint;
    }

    private void Update()
    {
        if (Mathf.Abs(Vector3.Distance(player.position, transform.position)) <= enemyData.detectRange)
        {
            ChasePlayer();
        }

        else
        {
            PatrolMovement();
        }
    }

    private void PatrolMovement()
    {
        if (currentTarget == player)
        {
            currentTarget = startPoint;
        }

        float distance = Vector3.Distance(transform.position, currentTarget.position);

        if(distance < 0.01f)
        {
            currentTarget = currentTarget == startPoint ? endPoint : startPoint;
        }

        Move(currentTarget);
    }

    private void ChasePlayer()
    {
        currentTarget = player;
        Move(currentTarget);
    }

    private void Move(Transform target)
    {
        switch (enemyData.enemyType)
        {
            case EnemyData.EnemyType.Ground:
                Vector3 pos = transform.position;
                pos.x += Mathf.Sign((target.position.x - transform.position.x)) * enemyData.moveSpeed * Time.deltaTime;
                transform.position = pos;
                break;

            case EnemyData.EnemyType.Flying:
                transform.position += (target.position - transform.position).normalized * enemyData.moveSpeed * Time.deltaTime;
                break;
        }
    }
}
