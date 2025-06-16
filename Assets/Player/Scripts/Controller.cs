using UnityEngine;
public class Controller
{
    private Movement _movement;
    private Player _player;
    private RaycastPj _raycastPj;
    private Transform _groundChecker;
    private LayerMask _layerMask;
    private Vector2 _movInputs;
    private bool _jumpPressed;
    private bool _isGrounded;
    private float _radiusCheckSpehere;
    public Controller(Movement _movement, Player _player, RaycastPj _raycastPj, Transform _groundChecker, LayerMask _layerMask)
    {
        this._movement = _movement;
        this._player = _player;
        this._raycastPj = _raycastPj;
        this._groundChecker = _groundChecker;
        this._layerMask = _layerMask;
        _jumpPressed = false;
        _isGrounded = true;
        _radiusCheckSpehere = 0.5f;
    }
    public void OnFixedUpdate()
    {
        _movement.Move(_movInputs);
        if (_jumpPressed && _isGrounded)
        {
            _movement.Jump();
            _jumpPressed = false;
            _isGrounded = false;
        }
    }
    public void OnUpdate()
    {
        CheckJumpKey();
        GetMovementInputs();
        CheckGround();
        PlayerInteract();
    }
    private void CheckJumpKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpPressed = true;
        }
    }
    private void GetMovementInputs()
    {
        _movInputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void CheckGround()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _radiusCheckSpehere, _layerMask);
    }
    private void PlayerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _raycastPj.Interact();
        }
    }
}
