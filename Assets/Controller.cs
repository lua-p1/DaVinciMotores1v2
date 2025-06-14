using UnityEngine;
public class Controller
{
    private Movement _movement;
    private Player _player;
    private RaycastPj _raycastPj;
    private float _horizontal;
    private float _vertical;
    private Vector2 _movInputs;
    private bool _jumpPressed;
    private bool _canJump;
    private Transform _groundChecker;
    private LayerMask _layerMask;
    private float _radiusCheckSpehere;
    public Controller(Movement movement, Player player, RaycastPj raycastPj, Transform groundChecker, LayerMask layerMask)
    {
        _movement = movement;
        _player = player;
        _raycastPj = raycastPj;
        _groundChecker = groundChecker;
        _layerMask = layerMask;
        _jumpPressed = false;
        _canJump = true;
        _radiusCheckSpehere = 0.5f;
    }
    public void OnFixedUpdate()
    {
        _movement.Move(_movInputs);
        if (_jumpPressed && _canJump)
        {
            _movement.Jump();
            _jumpPressed = false;
            _canJump = false;
        }
    }
    public void OnUpdate()
    {
        CheckJumpKey();
        Movement();
        CheckGround();
    }
    private void CheckJumpKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpPressed = true;
        }
    }
    private void Movement()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _movInputs = new Vector2(_horizontal, _vertical);
    }
    private void CheckGround()
    {
        _canJump = Physics.CheckSphere(_groundChecker.position, _radiusCheckSpehere, _layerMask);
        Debug.Log(_canJump);
    }
}
