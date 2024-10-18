using UnityEngine;

public class ConfusedLook : MonoBehaviour
{
    public float speed = 1f;         // Speed of the movement
    public float amplitudeX = 10f;   // Maximum X (vertical) movement amplitude (size of 8)
    public float amplitudeY = 20f;   // Maximum Y (horizontal) movement amplitude (size of 8)
    public float shakeIntensity = 0.2f;   // Intensity of the shaky movement
    public float shakeSpeed = 3f;         // Speed of the shake (frequency)

    private Vector3 initialRotation;  // Starting rotation of the camera
    private float timePassed = 0f;    // Tracks time for the 8-shape calculation
    private float shakeOffsetX = 0f;  // Offset for shake on the X-axis (vertical)
    private float shakeOffsetY = 0f;  // Offset for shake on the Y-axis (horizontal)

    void Start()
    {
        // Store the initial rotation of the camera
        initialRotation = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        timePassed += Time.deltaTime * speed;
        PerformEightShapedMovement();
        AddShakyMovement();
    }

    // Moves the camera in an 8-shaped motion pattern
    void PerformEightShapedMovement()
    {
        // Use sine and cosine to create an 8-shaped movement
        float xMovement = Mathf.Sin(timePassed) * amplitudeX;  // X-axis movement (up and down)
        float yMovement = Mathf.Sin(timePassed * 2f) * amplitudeY;  // Y-axis movement (left and right)

        // Apply the movement relative to the initial rotation
        transform.localRotation = Quaternion.Euler(
            initialRotation.x + xMovement + shakeOffsetX,
            initialRotation.y + yMovement + shakeOffsetY,
            initialRotation.z
        );
    }

    // Adds subtle shaky movement for realism
    void AddShakyMovement()
    {
        // Use Perlin noise to generate smooth random shaking movement
        float shakeTime = Time.time * shakeSpeed;
        shakeOffsetX = (Mathf.PerlinNoise(shakeTime, 0f) - 0.5f) * shakeIntensity;
        shakeOffsetY = (Mathf.PerlinNoise(0f, shakeTime) - 0.5f) * shakeIntensity;
    }
}
