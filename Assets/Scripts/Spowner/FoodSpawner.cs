using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefabs; // Fruit
    [SerializeField] GameObject[] bombPrefabs; // Bomb
    [SerializeField] float spawnInterval = 1f; // Interval between spawns
    [SerializeField] float xRange = 5f; // Range of x
    [SerializeField] int fruitWeight = 7; // Weight of fruit
    [SerializeField] int bombWeight = 7; // Weight of bomb
    [SerializeField] float aboveScreenOffset = 2f; // Hight above the screen

    GameObject[] weightedPrefabs; // List of weighted prefabs
    float screenTopY; // Top screen border

    void Start()
    {
        CalculateScreenTop();
        CreateWeightedPrefabList();
        StartCoroutine(SpawnFood());
    }

    void CalculateScreenTop()
    {
        // Calculate the top screen border
        Camera mainCamera = Camera.main;
        screenTopY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + aboveScreenOffset;
    }

    void CreateWeightedPrefabList()
{
    // Calculate the total weight
    int totalWeight = (fruitWeight * fruitPrefabs.Length) + (bombWeight * bombPrefabs.Length);
    weightedPrefabs = new GameObject[totalWeight];

    int index = 0;

    // Add fruits to the weighted list
    foreach (var fruit in fruitPrefabs)
    {
        for (int i = 0; i < fruitWeight; i++)
        {
            weightedPrefabs[index++] = fruit;
        }
    }

    // Add bombs to the weighted list
    foreach (var bomb in bombPrefabs)
    {
        for (int i = 0; i < bombWeight; i++)
        {
            weightedPrefabs[index++] = bomb;
        }
    }
}


    IEnumerator SpawnFood()
    {
        while (true)
        {
            // Choose a random prefab
            int randomIndex = Random.Range(0, weightedPrefabs.Length);

            // Place the object above the screen
            Vector3 spawnPosition = new Vector3(Random.Range(-xRange, xRange), screenTopY, 0);

            // Create the object
            Instantiate(weightedPrefabs[randomIndex], spawnPosition, Quaternion.identity);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
