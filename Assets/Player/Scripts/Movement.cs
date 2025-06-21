using UnityEngine;
public class Movement
{
    private float _speed;
    private Transform _transform;
    private Rigidbody _rb;
    private float _jumpForce;
    public Movement(Transform _transform, float _speed, Rigidbody _rb, float _jumpForce)
    {
        this._transform = _transform;
        this._speed = _speed;
        this._rb = _rb;
        this._jumpForce = _jumpForce;
    }
    public void Move(Vector2 inputs)
    {
        var _dir = new Vector3(inputs.x, 0, inputs.y);
        _dir.Normalize();
        if (_dir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(_dir);
            _rb.MoveRotation(Quaternion.Slerp(_rb.rotation,rot,5f * Time.fixedDeltaTime));
        }
        Vector3 _newPos = _rb.position + _dir * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(_newPos);
    }
    public void RotateOnly(Vector3 _dir)
    {
        if (_dir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(_dir);
            _rb.MoveRotation(Quaternion.Slerp(_rb.rotation, rot, 5f * Time.fixedDeltaTime));
        }
    }
    public void Jump()
    {
        _rb.AddForce(_transform.up * _jumpForce, ForceMode.Impulse);
    }
    public float GetAndSetSpeed { get => _speed; set => _speed = value; }
    public float GetAndSetJump { get => _jumpForce; set => _jumpForce = value; }
    public float GetAndSetMass { get => _rb.mass; set => _rb.mass = value;}
}