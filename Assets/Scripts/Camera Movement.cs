using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
