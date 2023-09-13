using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPlayerHealth : MonoBehaviour
{
    TextMeshProUGUI playerHealthTextfield;

    void Start()
    {
        playerHealthTextfield = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // the UI text represents the current playerHealth
        playerHealthTextfield.text = "Health: " + FindObjectOfType<PlayerHealth>().GetPlayerHealth().ToString();
    }
}
