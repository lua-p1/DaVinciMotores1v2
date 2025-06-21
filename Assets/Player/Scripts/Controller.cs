using UnityEngine;
public class Controller
{
    private Movement _movement;
    private RaycastPj _raycastPj;
    private Transform _groundChecker;
    private LayerMask _layerMask;
    private LayerMask _walls;
    private Vector2 _movInputs;
    private bool _jumpPressed;
    private bool _isGrounded;
    private float _radiusCheckSpehere;
    public Controller(Movement _movement, RaycastPj _raycastPj, Transform _groundChecker, LayerMask _layerMask,LayerMask _walls)
    {
        this._movement = _movement;
        this._raycastPj = _raycastPj;
        this._groundChecker = _groundChecker;
        this._layerMask = _layerMask;
        this._walls = _walls;
        _jumpPressed = false;
        _isGrounded = true;
        _radiusCheckSpehere = 0.5f;
    }
    public void OnFixedUpdate()
    {
        Vector3 moveDir = new Vector3(_movInputs.x, 0, _movInputs.y).normalized;
        if (moveDir != Vector3.zero)
        {
            bool blocked = _raycastPj.IsObstacleInDirection(moveDir, _walls);
            if (!blocked)
            {
                _movement.Move(_movInputs);
            }
            else
            {
                _movement.RotateOnly(_movInputs);
            }
        }
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
