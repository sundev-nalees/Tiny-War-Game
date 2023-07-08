using UnityEngine;

public class BluePlayerControl : PlayerControler
{
    protected override GameObject FindClosestEnemyFighter(Vector3 position)
    {
        GameObject closestFighter = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject redFighter in Spawner.Instance.redFighterList)
        {
            if (redFighter != null)
            {
                float distance = Vector3.Distance(position, redFighter.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestFighter = redFighter;
                }
            }
        }

        return closestFighter;
    }

    // Implement abstract method for blue player's attack animation
    public override void OnAttackAnimation()
    {
        if (aiDestination.target != null)
        {
            RedPlayerControl redPlayerControl = aiDestination.target.GetComponent<RedPlayerControl>();
            if (redPlayerControl != null)
            {
                redPlayerControl.health -= damage;
            }
        }
    }
}
