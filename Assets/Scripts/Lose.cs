using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject _loseText;
    [SerializeField] private GameObject _restartButton;
    private void OnTriggerEnter(Collider other)
    {
        _loseText.SetActive(true);
        _restartButton.SetActive(true);
        var carMove = other.gameObject.GetComponent<CarMove>();
        carMove.SetCar();
    }
}
