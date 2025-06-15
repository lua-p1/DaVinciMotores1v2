using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField]private float _initSpeed;
    [SerializeField]private float _initLife;
    [SerializeField]private float _initJumpForce;
    [SerializeField]private Rigidbody _rb;
    [SerializeField]private Controller _controller;
    [SerializeField]private Movement _movement;
    [SerializeField]private RaycastPj _rayCastPj;
    [SerializeField]private Life _life;
    [SerializeField]private Transform _groundChecker;
    public LayerMask layerMaskGround;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _initSpeed = 10f;
        _initLife = 100f;
        _initJumpForce = 5f;
    }
    private void OnEnable()
    {
        _movement = new Movement(this.transform, _initSpeed, _rb, _initJumpForce);
        _life = new Life(this.gameObject, _initLife);
        _rayCastPj = new RaycastPj(transform, 50f);
        _controller = new Controller(_movement, this, _rayCastPj, _groundChecker, layerMaskGround);
    }
    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        //DelegatesManager.instance.AddAction(KeysDelegatesEnum.PLAYERSPEED, (Action<float, float, float>)StartSpeedBuff);
        //DelegatesManager.instance.AddAction(KeysDelegatesEnum.PLAYERMASS, (Action<float, float, int>)StartMassBuff);
    }
    private void Update()
    {
        _controller.OnUpdate();
    }
    private void FixedUpdate()
    {
        _controller.OnFixedUpdate();
    }
    private IEnumerator ChangeSpeed(float buff, float notBuff, float time)
    {
        _movement.GetAndSetSpeed = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetSpeed = notBuff;
    }
    private IEnumerator ChangeMass(float buff, float notBuff, int time)
    {
        _movement.GetAndSetMass = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetMass = notBuff;
    }
    private IEnumerator ChangeJump(float buff, float notBuff, float time)
    {
        _movement.GetAndSetJump = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetJump = notBuff;
    }
    private void StartSpeedBuff(float buff,float notBuff,float time)
    {
        StartCoroutine(ChangeSpeed(buff, notBuff,time));
    }
    private void StartMassBuff(float buff,float notBuff,int time)
    {
        StartCoroutine(ChangeMass(buff,notBuff,time));
    }
    private void StartJumpBuff(float buff,float notBuff,float time)
    {
        StartCoroutine(ChangeJump(buff,notBuff,time));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundChecker.position, 0.5f);
    }
    private void OnDisable()
    {
        _movement = null;
        _controller = null;
        _life = null;
        _rayCastPj = null;
    }
    public Life GetLife { get => _life; }
}
