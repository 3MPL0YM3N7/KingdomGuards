using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0.1f, 30f)] float instantiationTime = 2f;

    GameObject[] pool;
    [SerializeField] [Range(0, 50)] int poolSize = 5;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(InstantiateEndless());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int count = 0; count < pool.Length; ++count)
        {
            pool[count] = Instantiate(enemy, transform);
            pool[count].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        foreach (GameObject enemy in pool)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }

    IEnumerator InstantiateEndless()
    {
        // infinite loop, could have used Update() instead but I decided that today I am a genius
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(instantiationTime);
        }
    }
}
