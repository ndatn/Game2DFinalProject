using System.Collections;
using UnityEngine;

public class SpawnSlimeChildren : MonoBehaviour
{
    [SerializeField] private GameObject slimePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int requiredSlimes = 5;

    private Coroutine spawnRoutine;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return null;

            // Check if the transform is not null
            if (spawnPoint != null)
            {
                int currentSlimes = CountSlimeChildren();

                if (currentSlimes < requiredSlimes)
                {
                    int slimesToSpawn = requiredSlimes - currentSlimes;
                    for (int i = 0; i < slimesToSpawn; i++)
                    {
                        Instantiate(slimePrefab, spawnPoint.position, Quaternion.identity, transform);
                    }
                }
            }

            yield return new WaitForSeconds(2f);
        }
    }

    int CountSlimeChildren()
    {
        int slimeCount = 0;
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Slime"))
            {
                slimeCount++;
            }
        }
        return slimeCount;
    }

    private void OnDisable()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
    }

    private void OnDestroy()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
    }
}
