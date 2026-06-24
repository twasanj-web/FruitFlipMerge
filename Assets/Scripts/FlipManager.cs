using UnityEngine;
using UnityEngine.UI;

public class FlipManager : MonoBehaviour
{
    public Button flipButton;

    private bool usedFlip = false;

    public void FlipFruits()
    {
        if (usedFlip) return;

        usedFlip = true;

        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

        float centerY = 3.5f;

        foreach (GameObject fruit in fruits)
        {
            Rigidbody2D rb = fruit.GetComponent<Rigidbody2D>();

            if (rb != null && rb.bodyType == RigidbodyType2D.Dynamic)
            {
                Vector3 pos = fruit.transform.position;

                float newY = centerY - (pos.y - centerY);

                fruit.transform.position = new Vector3(
                    pos.x,
                    newY,
                    pos.z
                );

                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }

        flipButton.interactable = false;

        Debug.Log("Flip Used!");
    }
}