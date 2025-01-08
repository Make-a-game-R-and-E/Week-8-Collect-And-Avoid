using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // Speed of the player
    Rigidbody2D rb;
    float minBoundaryX = -5f; // Minimum x boundary
    float maxBoundaryX = 5f;  // Maximum x boundary

    float minBoundaryY = -5f; // Minimum y boundary
    float maxBoundaryY = 5f;  // Maximum y boundary

    // Direction vectors for movement
    Vector3 rightDirection = new Vector3(1, 0, 0);
    Vector3 leftDirection = new Vector3(-1, 0, 0);
    Vector3 upDirection = new Vector3(0, 1, 0);
    Vector3 downDirection = new Vector3(0, -1, 0);

    [SerializeField]
    [Tooltip("Input action for moving right")]
    InputAction moveRight = new InputAction("moveRight", type: InputActionType.Button, "<Keyboard>/d");

    [SerializeField]
    [Tooltip("Input action for moving left")]
    InputAction moveLeft = new InputAction("moveLeft", type: InputActionType.Button, "<Keyboard>/a");

    [SerializeField]
    [Tooltip("Input action for moving up")]
    InputAction moveUp = new InputAction("moveUp", type: InputActionType.Button, "<Keyboard>/w");

    [SerializeField]
    [Tooltip("Input action for moving down")]
    InputAction moveDown = new InputAction("moveDown", type: InputActionType.Button, "<Keyboard>/s");


    private void OnEnable()
    {
        moveRight.Enable();
        moveLeft.Enable();
        moveUp.Enable();
        moveDown.Enable();
    }

    private void OnDisable()
    {
        moveRight.Disable();
        moveLeft.Disable();
        moveUp.Disable();
        moveDown.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Update the screen bounds
        UpdateScreenBounds();
    }

    void Update()
    {
        Vector3 newPosition = transform.position; // Get the current position

        if (moveRight.IsPressed() && newPosition.x < maxBoundaryX)
        {
            newPosition += rightDirection * speed * Time.deltaTime;
        }
        if (moveLeft.IsPressed() && newPosition.x > minBoundaryX)
        {
            newPosition += leftDirection * speed * Time.deltaTime;
        }
        if (moveUp.IsPressed() && newPosition.y < maxBoundaryY)
        {
            newPosition += upDirection * speed * Time.deltaTime;
        }
        if (moveDown.IsPressed() && newPosition.y > minBoundaryY)
        {
            newPosition += downDirection * speed * Time.deltaTime;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, minBoundaryX, maxBoundaryX); // Clamp x position
        newPosition.y = Mathf.Clamp(newPosition.y, minBoundaryY, maxBoundaryY); // Clamp y position

        transform.position = newPosition; // Update the position
    }

    void UpdateScreenBounds()
    {
        Camera mainCamera = Camera.main;

        // Get the orthographic size of the camera 
        float verticalExtent = mainCamera.orthographicSize;
        float horizontalExtent = verticalExtent * Screen.width / Screen.height;

        // Calculate screen boundaries
        minBoundaryX = mainCamera.transform.position.x - horizontalExtent;
        maxBoundaryX = mainCamera.transform.position.x + horizontalExtent;
        minBoundaryY = mainCamera.transform.position.y - verticalExtent;
        maxBoundaryY = mainCamera.transform.position.y + verticalExtent;
    }

}