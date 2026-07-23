using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs de Items")]
    public GameObject[] goodItems;
    public GameObject[] badItems; 
    
    [Header("Probabilidad (0 a 100)")]
    [Range(0, 100)]
    public float goodItemChance = 70f; 

    [Header("Tiempos de Aparición")]
    public float minTime = 1f;
    public float maxTime = 2f;

    void Start()
    {
        StartCoroutine(SpawnCoRutine(0));    
    }

    IEnumerator SpawnCoRutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        float randomRoll = Random.Range(0f, 100f);

        if (randomRoll <= goodItemChance)
        {
            SpawnFromList(goodItems);
        }
        else
        {
            SpawnFromList(badItems);
        }

        StartCoroutine(SpawnCoRutine(Random.Range(minTime, maxTime)));
    }

    void SpawnFromList(GameObject[] list)
    {
        if (list != null && list.Length > 0)
        {
            int randomIndex = Random.Range(0, list.Length);
            Instantiate(list[randomIndex], transform.position, Quaternion.identity);
        }
    }
}