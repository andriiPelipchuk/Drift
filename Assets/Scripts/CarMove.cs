using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float rotationSpeed;
    public float turnSpeed;

    [SerializeField] private Score _score;

    [SerializeField] private float _speed;

    [SerializeField] private GameObject _indicator;
    [SerializeField] private Animator _indicatorAnim;

    private Vector3 _targetPos;
    private float _factor = 1;
    private float _timeLeft = 4;

    private void FixedUpdate()
    {
        Move();
    }
    public void SetTargetPosition(Vector3 target)
    {
        turnSpeed = -turnSpeed;
        _targetPos = target;
    }
    public void SetCar()
    {
        _speed = 0;
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }
    public void Restart()
    {
        transform.position = new Vector3(0, 0.5f, -1);
        _speed = 2;
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        _targetPos = Vector3.zero;
    }
    private void Move()
    {
        if(_targetPos == Vector3.zero)
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        else
        {
            var direction = (_targetPos - transform.position).normalized;
            if (Vector3.Distance(_targetPos, transform.position) < 1f)
            {
                CarSpining();
                transform.RotateAround(_targetPos, Vector3.up, turnSpeed * Time.fixedDeltaTime);
                _factor += 0.1f * Time.fixedDeltaTime;
            }
            else
            {
                TurnDirection(direction);

                if (Mathf.Abs(direction.x) > 0.5f || Mathf.Abs(direction.z) > 0.5f)
                    transform.position += transform.forward * _speed * Time.fixedDeltaTime;
                else
                    transform.position += direction * _speed * Time.fixedDeltaTime;

                _indicator.gameObject.SetActive(false);

                _timeLeft = 4;
                _indicatorAnim.speed = 1;

                _score.CockTimer();
            }
        }
    }

    private void TurnDirection(Vector3 direction)
    {
        float singleStep = rotationSpeed * Time.fixedDeltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void CarSpining()
    {
        _timeLeft -= Time.fixedDeltaTime;
        _indicatorAnim.speed += 2 * Time.fixedDeltaTime;
        if(_timeLeft <= 0)
        {
            _score.ResetScore();
            _indicator.gameObject.SetActive(false);
            return;
        }
        else
        {
            _indicator.gameObject.SetActive(true);
            _score.AddNewScore(_factor);
        }
    }
}
