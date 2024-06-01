using UnityEngine;

public class personMove : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float moveSpeed = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        SetTargetPosition(endPoint);
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the object has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Change the target position to the other point
            if (targetPosition == startPoint)
                SetTargetPosition(endPoint);
            else
                SetTargetPosition(startPoint);
        }
    }

    void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
}
