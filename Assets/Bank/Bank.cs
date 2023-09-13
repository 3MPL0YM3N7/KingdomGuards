using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    // till i have a proper UI
    [SerializeField] int currentBalance;

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public int GetCurrentBalance()
    {
        return currentBalance;
    }

    public void DepositCash(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void WithdrawCash(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
