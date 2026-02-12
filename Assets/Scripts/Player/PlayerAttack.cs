using System.Collections;
using UnityEngine;

public enum AttackType
{
    Right,
    Left,
    Up,
    Down
}

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject rightHitBox;
    public GameObject leftHitBox;
    public GameObject upHitBox;
    public GameObject downHitBox;

    public float attackSpeed = 0.5f;

    public bool isAttacking = false;
    public bool canAttack = true;

    private AttackType attackType;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.R))
        {
            GetAttackType();

            switch (attackType)
            {
                case AttackType.Right:
                    StartCoroutine(Attack(rightHitBox));
                    Debug.Log("우측 공격");
                    break;

                case AttackType.Left:
                    StartCoroutine(Attack(leftHitBox));
                    Debug.Log("좌측 공격");
                    break;

                case AttackType.Up:
                    StartCoroutine(Attack(upHitBox));
                    Debug.Log("상단 공격");
                    break;

                case AttackType.Down:
                    StartCoroutine(Attack(downHitBox));
                    Debug.Log("하단 공격");
                    break;
            }
        }
    }

    IEnumerator Attack(GameObject hitBox)
    {
        isAttacking = true;
        canAttack = false;

        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitBox.SetActive(false);
        isAttacking = false;

        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    private AttackType GetAttackType()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            return AttackType.Up;

        if (Input.GetKey(KeyCode.DownArrow) && !playerController.isGrounded)
            return AttackType.Down;

        return playerController.isFacingRight ? AttackType.Right : AttackType.Left;
    }
}
