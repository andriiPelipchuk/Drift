using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CarMove _carMove;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private GameObject _loseText;
    [SerializeField] private GameObject _winText;

    public void Restart()
    {
        _carMove.Restart();
        _restartButton.SetActive(false);
        _nextLevelButton.SetActive(false);
        _loseText.SetActive(false);
        _winText.SetActive(false);
    }
}
