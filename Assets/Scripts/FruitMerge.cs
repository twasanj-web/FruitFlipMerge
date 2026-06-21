using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    private Fruit myFruit;
    private bool hasMerged = false;

    private void Awake()
    {
        myFruit = GetComponent<Fruit>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged) return;

        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit == null) return;

        if (myFruit.fruitLevel != otherFruit.fruitLevel) return;

        FruitMerge otherMerge = otherFruit.GetComponent<FruitMerge>();

        if (otherMerge == null) return;
        if (otherMerge.hasMerged) return;

        hasMerged = true;
        otherMerge.hasMerged = true;

        int nextLevel = myFruit.fruitLevel + 1;

        FruitSpawner spawner = FindFirstObjectByType<FruitSpawner>();

        if (nextLevel >= spawner.FruitPrefabs.Length)
        {
            Destroy(otherFruit.gameObject);
            Destroy(gameObject);
            return;
        }

        Vector3 spawnPosition =
            (transform.position + otherFruit.transform.position) / 2f;

        Instantiate(
            spawner.FruitPrefabs[nextLevel],
            spawnPosition,
            Quaternion.identity
        );

        Destroy(otherFruit.gameObject);
        Destroy(gameObject);
    }
}