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

    
    public override void OnAttackAnimation()
    {
        Debug.Log("BlueUMbii");
        if (aiDestination.target != null)
        {
            RedPlayerControl redPlayerControl = aiDestination.target.GetComponent<RedPlayerControl>();
            if (redPlayerControl != null)
            {
                
                redPlayerControl.PlayerHealth(damage);
            }
        }
    }
}
