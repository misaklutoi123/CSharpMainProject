using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    
    private float DistanceToOwnBase(GameObject target)
    {
       
        Vector3 basePosition = Vector3.zero; 
        Vector3 targetPosition = target.transform.position;
        return Vector3.Distance(targetPosition, basePosition);
    }

  
    private List<GameObject> SelectClosestTarget(List<GameObject> targets)
    {
        if (targets == null)
            throw new ArgumentNullException(nameof(targets));

        if (targets.Count == 0)
            return new List<GameObject>();

        GameObject closestTarget = null;
        float minDistance = float.MaxValue;

        foreach (GameObject target in targets)
        {
            float distance = DistanceToOwnBase(target);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestTarget = target;
            }
        }

        var result = new List<GameObject>();
        if (closestTarget != null)
        {
            result.Add(closestTarget);
        }
        else
        {
            Debug.LogWarning("No valid target found!");
        }

        return result;
    }
}
