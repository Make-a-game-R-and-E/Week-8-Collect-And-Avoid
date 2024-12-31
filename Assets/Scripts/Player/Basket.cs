using UnityEngine;

public class Basket : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit"))
        {
            // Add 1 to the score
            GameManager.Instance.AddScore(1);

            // Destroy the fruit
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomb"))
        {
            // Remove 1 from the lives
            GameManager.Instance.ReduceLife();

            // Destroy the bomb
            Destroy(other.gameObject);
        }
    }
}
