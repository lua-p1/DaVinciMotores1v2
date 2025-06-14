using UnityEngine;
public class Movement
{
    private float _speed;
    private Transform _transform;
    private Rigidbody _rb;
    private float _jumpForce;

    public Movement(Transform transform, float speed, Rigidbody rb, float jumpForce)
    {
        _transform = transform;
        _speed = speed;
        _rb = rb;
        _jumpForce = jumpForce;
    }
    public void Move(Vector2 inputs)
    {
        var dir = _transform.forward * inputs.y + _transform.right * inputs.x;
        dir = dir.normalized;
        var _movPosVector = _rb.position + dir * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(_movPosVector);
    }
    public void Jump()
    {
        _rb.AddForce(_transform.up * _jumpForce, ForceMode.Impulse);
    }
    public float GetAndSetSpeed { get => _speed; set => _speed = value; }
    public float GetAndSetJump { get => _jumpForce; set => _jumpForce = value; }
    public float GetAndSetMass { get => _rb.mass; set => _rb.mass = value;}
}