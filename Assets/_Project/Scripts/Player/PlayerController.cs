using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;
    private PlayerInput _input;
    private GroundCheck _groundCheck;

    private Vector3 _direction;
    private bool _isDoubleJumping;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
        _groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        _direction = new Vector3(_input.HorizontalMovement, 0f, 0f) * _speed;

        if (_groundCheck.IsGrounded && _isDoubleJumping)
            _isDoubleJumping = false;
    }

    private void FixedUpdate()
    {
        if (_direction != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _direction * Time.fixedDeltaTime);
        }

        if (_input.IsJumping && _groundCheck.IsGrounded)
        {
            Jump();
        }
        else if (_input.IsJumping && !_isDoubleJumping /*&& GameState.Instance.CanDoubleJump*/)
        {
            _isDoubleJumping = true;
            Jump();
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _input.IsJumping = false;
    }

}
