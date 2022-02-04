using UnityEngine;
using TMPro;
using System.Collections;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private float _minScore = 1;
    private float _scoreLap;
    private float _timeLeft = 1.5f;
    public void AddNewScore(float factor)
    {
        if (_timeLeft != 1.5f)
            _timeLeft = 1.5f;
        _scoreLap += _minScore * factor;
        _scoreLap = (int)_scoreLap;
        _text.text = "Score " + _scoreLap.ToString();

    }
    public void CockTimer()
    {
        if (_timeLeft <= 0)
            ResetScore();
        _timeLeft -= Time.fixedDeltaTime;
    }
    public void ResetScore()
    {
        _scoreLap = 0;
        _text.text = "Score " + _scoreLap.ToString();
    }
}
