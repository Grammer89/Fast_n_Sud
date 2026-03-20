using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    #region Input variables
    private float _horizontalMovement;
    public float HorizontalMovement => _horizontalMovement;

    private bool _isJumping = false;
    public bool IsJumping { get { return _isJumping; } set { _isJumping = value; } }

    private bool _useBerserk;
    public bool UseBerserk => _useBerserk;

    private bool _useMagnet;
    public bool UseMagnet => _useMagnet;
    #endregion

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            _isJumping = true;

        _useBerserk = Input.GetKeyDown(KeyCode.Q);
        _useMagnet = Input.GetKeyDown(KeyCode.E);
    }

}
