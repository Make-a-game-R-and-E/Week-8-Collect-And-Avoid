using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    float screenBottomY; // Down screen border

    void Start()
    {
        // Get the down screen border
        Camera mainCamera = Camera.main;
        screenBottomY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        // Check if the object is off the screen
        if (transform.position.y < screenBottomY)
        {
            Destroy(gameObject); // Destroy the object
        }
    }
}
