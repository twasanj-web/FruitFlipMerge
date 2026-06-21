using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        SpawnFruit();
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, 3);
        Instantiate(fruitPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}