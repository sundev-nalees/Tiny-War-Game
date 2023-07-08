using Pathfinding;
using UnityEngine;

public abstract class PlayerControler : MonoBehaviour
{
    [SerializeField] protected AIDestinationSetter aiDestination;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float stopDistance = 2f;
    [SerializeField] protected float attackDistance = 2f;
    [SerializeField] protected int damage;

    public int health;

    protected abstract GameObject FindClosestEnemyFighter(Vector3 position);

    protected virtual void Update()
    {
        GameObject closestEnemyFighter = FindClosestEnemyFighter(transform.position);
        if (closestEnemyFighter != null)
        {
            aiDestination.target = closestEnemyFighter.transform;
            bool isMoving = aiDestination.target != null;
            if (isMoving)
            {
                float distanceToTarget = Vector3.Distance(transform.position, aiDestination.target.position);
                if (distanceToTarget <= attackDistance)
                {
                    animator.SetTrigger("isAttacking");
                }
                else if (distanceToTarget>stopDistance)
                {
                    isMoving = true;
                }
            }
            animator.SetBool("isWalking", isMoving);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        PlayerDeath();
    }

    protected virtual void PlayerDeath()
    {
        if (health <= 0)
        {
            DestroyPlayer();
        }
    }

    protected virtual void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public abstract void OnAttackAnimation();
}

