using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _nextLevelButton;
    private void OnTriggerEnter(Collider other)
    {
        _winText.SetActive(true);
        _restartButton.SetActive(true);
        _nextLevelButton.SetActive(true);
        var carMove = other.gameObject.GetComponent<CarMove>();
        carMove.SetCar();
    }
}
