
using UnityEngine;

public class CrystalAnimation : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float floatHeight = 0.2f;
    public float floatSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the crystal
        transform.Rotate(
            Vector3.up * rotationSpeed * Time.deltaTime
        );

        // Make the crystal float up and down
        float newY = startPosition.y +
            Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(
            startPosition.x,
            newY,
            startPosition.z
        );
    }
}
