using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
    }
}
