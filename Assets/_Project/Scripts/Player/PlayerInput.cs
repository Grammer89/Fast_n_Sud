using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    #region Input variables
    private float _horizontalMovement;
    public float HorizontalMovement => _horizontalMovement;

    private bool _isJumping = false;
    public bool IsJumping { get { return _isJumping; } set { _isJumping = value; } }

    private bool _useItem1;
    public bool UseItem1 => _useItem1;

    private bool _useItem2;
    public bool UseItem2 => _useItem2;

    private bool _useItem3;
    public bool UseItem3 => _useItem3;

    private bool _useItem4;
    public bool UseItem4 => _useItem4;

    private bool _useItem5;
    public bool UseItem5 => _useItem5;

    private bool _useItem6;
    public bool UseItem6 => _useItem6;

    private bool _useItem7;
    public bool UseItem7 => _useItem7;

    private bool _useItem8;
    public bool UseItem8 => _useItem8;

    private bool _useItem9;
    public bool UseItem9 => _useItem9;
    #endregion

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            _isJumping = true;

        _useItem1 = Input.GetKeyDown(KeyCode.Alpha1);
        _useItem2 = Input.GetKeyDown(KeyCode.Alpha2);
        _useItem3 = Input.GetKeyDown(KeyCode.Alpha3);
        _useItem4 = Input.GetKeyDown(KeyCode.Alpha4);
        _useItem5 = Input.GetKeyDown(KeyCode.Alpha5);
        _useItem6 = Input.GetKeyDown(KeyCode.Alpha6);
        _useItem7 = Input.GetKeyDown(KeyCode.Alpha7);
        _useItem8 = Input.GetKeyDown(KeyCode.Alpha8);
        _useItem9 = Input.GetKeyDown(KeyCode.Alpha9);
    }

}
