using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f; // Speed of the player
    Rigidbody2D rb;
    float minX = -5f; // Minimum x boundary
    float maxX = 5f;  // Maximum x boundary

    float minY = -5f; // Minimum y boundary
    float maxY = 5f;  // Maximum y boundary

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


        if (moveRight.IsPressed() && newPosition.x < maxX) 
        {
            newPosition += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (moveLeft.IsPressed() && newPosition.x > minX)
        {
            newPosition += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (moveUp.IsPressed() && newPosition.y < maxY)
        {
            newPosition += new Vector3(0, speed, 0) * Time.deltaTime;
        }
        if (moveDown.IsPressed() && newPosition.y > minY)
        {
            newPosition += new Vector3(0, -speed, 0) * Time.deltaTime;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); // Update the x position
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY); // Update the y position

        transform.position = newPosition; // Update the position
    }

     void UpdateScreenBounds()
    {
        // Calculate the screen boundaries
        Camera mainCamera = Camera.main;
        Vector3 screenBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minX = screenBottomLeft.x;
        maxX = screenTopRight.x;
        minY = screenBottomLeft.y;
        maxY = screenTopRight.y;
    }

}