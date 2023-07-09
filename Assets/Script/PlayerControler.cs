using Pathfinding;
using UnityEngine;

public abstract class PlayerControler : MonoBehaviour
{
    [SerializeField] protected AIDestinationSetter aiDestination;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float stopDistance = 2f;
    [SerializeField] protected float attackDistance = 2f;
    [SerializeField] protected int damage;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected SliderControl sliderControl;

    protected int currentHealth;

    

    protected abstract GameObject FindClosestEnemyFighter(Vector3 position);

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
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
        if (currentHealth<= 0)
        {
            DestroyPlayer();
        }
    }

    public virtual void PlayerHealth(int damage)
    {
        currentHealth -= damage;
        sliderControl.UpdateHealthBar(currentHealth, maxHealth);
    }
    protected virtual void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public abstract void OnAttackAnimation();
}

