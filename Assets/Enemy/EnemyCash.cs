using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCash : MonoBehaviour
{
    [SerializeField] int enemyCashReward = 25;

    public void DepositEnemyRewardCash()
    {
        FindObjectOfType<Bank>().DepositCash(enemyCashReward);
    }
}
