using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;

    void Update()
    {
        CheckPlayerHealth();
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void DecreasePlayerHealth()
    {
        --playerHealth;
    }

    void CheckPlayerHealth()
    {
        if (playerHealth <= 0)
        {
            // reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
