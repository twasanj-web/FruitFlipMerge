using UnityEngine;
using UnityEngine.UI;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minX = -2.2f;
    [SerializeField] private float maxX = 2.2f;

    [SerializeField] private Image nextFruitImage;

    public GameObject[] FruitPrefabs => fruitPrefabs;

    private GameObject currentFruit;
    private bool isReadyToDrop = false;

    private int nextFruitIndex;

    private void Start()
    {
        nextFruitIndex = Random.Range(0, 3);
        UpdateNextFruitImage();
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
        int currentIndex = nextFruitIndex;

        nextFruitIndex = Random.Range(0, 3);

        currentFruit = Instantiate(
            fruitPrefabs[currentIndex],
            spawnPoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        isReadyToDrop = true;

        UpdateNextFruitImage();
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

    private void UpdateNextFruitImage()
    {
        if (nextFruitImage == null) return;

        SpriteRenderer spriteRenderer =
            fruitPrefabs[nextFruitIndex].GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            nextFruitImage.sprite = spriteRenderer.sprite;
        }
    }
}