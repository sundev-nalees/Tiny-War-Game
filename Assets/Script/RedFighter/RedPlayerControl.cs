using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerControl : PlayerControler
{

    protected override GameObject FindClosestEnemyFighter(Vector3 position)
    {
        GameObject closestFighter = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject blueFighter in Spawner.Instance.blueFighterList)
        {
            if (blueFighter != null)
            {
                float distance = Vector3.Distance(position, blueFighter.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestFighter = blueFighter;
                }
            }
        }

        return closestFighter;
    }

    
    public override void OnAttackAnimation()
    {
        if (aiDestination.target != null)
        {
            BluePlayerControl bluePlayerControl = aiDestination.target.GetComponent<BluePlayerControl>();
            if (bluePlayerControl != null)
            {
                
                bluePlayerControl.PlayerHealth(damage);
            }
        }
    }
}
   

