using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCash : MonoBehaviour
{
    [SerializeField] int towerPriceCash = 75;

    public bool PlaceTower(Vector3 position)
    {
        if (FindObjectOfType<Bank>().GetCurrentBalance() >= towerPriceCash)
        {
            FindObjectOfType<Bank>().WithdrawCash(towerPriceCash);
            Instantiate(this.gameObject, position, Quaternion.identity);
            return true;
        }
        else
        {
            return false;
        }
    }
}
