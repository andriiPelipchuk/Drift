using UnityEngine;
using System.Collections;

public class TargetPosition : MonoBehaviour
{
    [SerializeField] private GameObject _driftPoint;
    [SerializeField] private CarMove _carMove;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MousePosition();
    }
    private void MousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Lose")
                return;
            _carMove.SetTargetPosition(hit.point);
            Instantiate(_driftPoint, hit.point, Quaternion.identity);
        }
    }
}
