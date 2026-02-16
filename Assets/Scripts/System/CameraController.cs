using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public BoxCollider2D cameraBounds;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private float halfWidth = 8.888f;
    private float halfHeight = 5f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        cameraBounds = GameObject.FindWithTag("CameraBounds").GetComponent<BoxCollider2D>();

        minX = cameraBounds.bounds.min.x;
        maxX = cameraBounds.bounds.max.x;
        minY = cameraBounds.bounds.min.y;
        maxY = cameraBounds.bounds.max.y;
    }
    private void LateUpdate()
    {
        float clampedX = Mathf.Clamp(player.position.x, minX + halfWidth, maxX - halfWidth);
        float clampedY = Mathf.Clamp(player.position.y, minY + halfHeight, maxY - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}

