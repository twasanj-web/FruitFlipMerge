using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minX = -2.2f;
    [SerializeField] private float maxX = 2.2f;
    
    public GameObject[] FruitPrefabs => fruitPrefabs;

    private GameObject currentFruit;
    private bool isReadyToDrop = false;

    private void Start()
    {
        SpawnFruit();
    }

    private void Update()
    {
        if (currentFruit == null) return;

        if (isReadyToDrop)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float clampedX = Mathf.Clamp(mousePos.x, minX, maxX);

            currentFruit.transform.position = new Vector3(
                clampedX,
                spawnPoint.position.y,
                0
            );

            if (Input.GetMouseButtonDown(0))
            {
                DropFruit();
            }
        }
    }

    private void SpawnFruit()
    {
        int randomIndex = Random.Range(0, 3);

        currentFruit = Instantiate(
            fruitPrefabs[randomIndex],
            spawnPoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        isReadyToDrop = true;
    }

    private void DropFruit()
    {
        Debug.Log("Drop!");
        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;

        currentFruit = null;
        isReadyToDrop = false;

        Invoke(nameof(SpawnFruit), 1f);
    }
}