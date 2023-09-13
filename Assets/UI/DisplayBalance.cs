using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayBalance : MonoBehaviour
{
    TextMeshProUGUI balanceTextfield;

    void Start()
    {
        balanceTextfield = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // the UI text represents the current balance
        balanceTextfield.text = "Gold: " + FindObjectOfType<Bank>().GetCurrentBalance().ToString();
    }
}
