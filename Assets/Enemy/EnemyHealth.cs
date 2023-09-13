using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyCash))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 5f;

    [Tooltip("Adds amount to maxHealth when enemy dies to increase game difficulty")]
    [SerializeField] float difficultyRamp = 0.5f;

    float currentHealth = 0f;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        --currentHealth;

        if (currentHealth <= 0)
        {
            FindObjectOfType<EnemyCash>().DepositEnemyRewardCash();
            maxHealth += difficultyRamp;
            GetComponent<EnemyMover>().enemySpeed += 0.3f;
            gameObject.SetActive(false);
        }
    }
}
