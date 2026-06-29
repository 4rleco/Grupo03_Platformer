using UnityEngine;

public class BackGroundLogic : MonoBehaviour
{
    [SerializeField] private float speed;

    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Vector2 startPosition = new Vector2(camera.orthographicSize, 0);

        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (transform.position.x + transform.localScale.x < camera.orthographicSize)
            transform.position = startPosition;
    }
}
