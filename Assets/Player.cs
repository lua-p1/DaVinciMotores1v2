using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]private float _initSpeed;
    [SerializeField]private float _initLife;
    [SerializeField]private Rigidbody _rb;
    [SerializeField]private Controller _controller;
    [SerializeField]private Movement _movement;
    [SerializeField]private RaycastPj _rbPj;
    // public Life _life;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _initSpeed = 10;
        _initLife = 100;
    }
    private void OnEnable()
    {
        _movement = new Movement(this.transform, _initSpeed, _rb);
       // _life = new Life(this.gameObject, _initLife);
        _rbPj = new RaycastPj(transform, 50);
        _controller = new Controller(_movement, this, _rbPj);
    }
}
