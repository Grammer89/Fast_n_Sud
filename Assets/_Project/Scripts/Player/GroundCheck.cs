using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private LayerMask _whatIsGround;

    private bool _isGrounded;
    public bool IsGrounded { get { return _isGrounded; } }

    private void Update()
    {
        _isGrounded = CheckGround();
    }

    private bool CheckGround()
    {
        return Physics.Raycast(_raycastOrigin.position, -Vector3.up, 0.1f, _whatIsGround);
    }

}
