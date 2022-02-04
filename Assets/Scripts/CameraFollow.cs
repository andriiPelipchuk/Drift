using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z - 8);
    }
}
