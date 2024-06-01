using UnityEngine;

public class fallObjects : MonoBehaviour
{
    public float startY = 0f;
    public float endY = 5f;
    public float moveSpeed = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        SetTargetPosition(endY);
    }

    void Update()
    {
        // Move towards the target position along the y-axis
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetPosition.y, moveSpeed * Time.deltaTime), transform.position.z);

        // Check if the object has reached the target position
        if (Mathf.Approximately(transform.position.y, targetPosition.y))
        {
            // Change the target position to the other point
            if (targetPosition.y == startY)
                SetTargetPosition(endY);
            else
                SetTargetPosition(startY);
        }
    }

    void SetTargetPosition(float positionY)
    {
        targetPosition = new Vector3(transform.position.x, positionY, transform.position.z);
    }
}
