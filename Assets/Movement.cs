using UnityEngine;
public class Movement
{
    public float _speed;
    Transform _transform;
    public Rigidbody _rb;
    //ctor
    public Movement(Transform transform, float speed, Rigidbody rb)
    {
        _transform = transform;
        _speed = speed;
        _rb = rb;
    }
    public void Move(float horizontal, float vertical)
    {
        var dir = _transform.forward * vertical + _transform.right * horizontal;
        _rb.MovePosition(_rb.position += dir * _speed * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log("Salto");
    }
}
