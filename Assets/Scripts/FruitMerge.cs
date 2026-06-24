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

        switch (nextLevel)
        {
            case 1: ScoreManager.Instance.AddScore(2); break;
            case 2: ScoreManager.Instance.AddScore(4); break;
            case 3: ScoreManager.Instance.AddScore(8); break;
            case 4: ScoreManager.Instance.AddScore(12); break;
            case 5: ScoreManager.Instance.AddScore(18); break;
            case 6: ScoreManager.Instance.AddScore(25); break;
            case 7: ScoreManager.Instance.AddScore(40); break;
            case 8: ScoreManager.Instance.AddScore(60); break;
        }

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

