using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float towerRange = 30f;
    [SerializeField] ParticleSystem towerProjectiles;
    Transform finalEnemyPos;

    void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    void FindClosestEnemy()
    {
        EnemyMover[] enemies = FindObjectsOfType<EnemyMover>();
        Transform enemyPos = null;
        float matchingDistance = Mathf.Infinity;

        foreach (EnemyMover enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < matchingDistance)
            {
                matchingDistance = enemyDistance;
                enemyPos = enemy.transform;
            }
        }
        finalEnemyPos = enemyPos;
    }

    void AimWeapon()
    {
        // enemyDistance is defined again because the first one is out of scope
        float enemyDistance = Vector3.Distance(transform.position, finalEnemyPos.transform.position);
        if (enemyDistance <= towerRange)
        {
            AttackEnemy(true);
        }
        else
        {
            AttackEnemy(false);
        }

        weapon.LookAt(finalEnemyPos);
    }

    void AttackEnemy(bool isActive)
    {
        // could have used var but whatever
        ParticleSystem.EmissionModule towerProjectilesEmission = towerProjectiles.emission;
        if (isActive) 
        {
            towerProjectilesEmission.enabled = true;
        }
        else if (!isActive)
        {
            towerProjectilesEmission.enabled = false;
        }
    }
}
