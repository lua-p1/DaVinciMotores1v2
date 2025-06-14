using UnityEngine;
public class Controller
{
    private Movement _movement;
    private Player _player;
    private RaycastPj _raycastPj;
    private float _horizontal;
    private float _vertical;
    public Controller(Movement m, Player player, RaycastPj raycastPj)
    {
        _movement = m;
        _player = player;
        _raycastPj = raycastPj;
    }
    public void OnFixedUpdate()
    {
        _movement.Move(_horizontal, _vertical);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movement.Jump();
        }
    }
    public void OnUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
         if (Input.GetKeyDown(KeyCode.V))
        {
            _raycastPj.Interact();
        }
    }
}
