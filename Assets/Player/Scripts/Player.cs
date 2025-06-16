using System;
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
    [SerializeField] private Transform _interactPos;
    public LayerMask layerMaskGround;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _initSpeed = 10f;
        _initLife = 100f;
        _initJumpForce = 5f;
    }
    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _movement = new Movement(this.transform, _initSpeed, _rb, _initJumpForce);
        _life = new Life(_initLife);
        _rayCastPj = new RaycastPj(_interactPos, 50f);
        _controller = new Controller(_movement, this, _rayCastPj, _groundChecker, layerMaskGround);
        DelegatesManager.instance.AddAction(KeysDelegatesEnum.PlayerSpeed, (Action<float, float, float>)StartSpeedBuff);
        DelegatesManager.instance.AddAction(KeysDelegatesEnum.PlayerMass, (Action<float, float, float>)StartMassBuff);
        DelegatesManager.instance.AddAction(KeysDelegatesEnum.PlayerJump, (Action<float, float, float>)StartJumpBuff);
        DelegatesManager.instance.AddAction(KeysDelegatesEnum.PlayerDeath,(Action)PlayerDeath);
    }
    private void Update()
    {
        _controller.OnUpdate();
    }
    private void FixedUpdate()
    {
        _controller.OnFixedUpdate();
    }
    #region//Buffos
    private IEnumerator ChangeSpeed(float buff, float notBuff, float time)
    {
        _movement.GetAndSetSpeed = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetSpeed = notBuff;
    }
    private IEnumerator ChangeMass(float buff, float notBuff, float time)
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
    private void StartMassBuff(float buff,float notBuff,float time)
    {
        StartCoroutine(ChangeMass(buff,notBuff,time));
    }
    private void StartJumpBuff(float buff,float notBuff,float time)
    {
        StartCoroutine(ChangeJump(buff,notBuff,time));
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundChecker.position, 0.5f);
    }
    private void PlayerDeath()
    {
        Debug.Log("Me mori");
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        _movement = null;
        _controller = null;
        _life = null;
        _rayCastPj = null;
        DelegatesManager.instance.RemoveAction(KeysDelegatesEnum.PlayerSpeed);
        DelegatesManager.instance.RemoveAction(KeysDelegatesEnum.PlayerMass);
        DelegatesManager.instance.RemoveAction(KeysDelegatesEnum.PlayerJump);
        DelegatesManager.instance.RemoveAction(KeysDelegatesEnum.PlayerDeath);
    }
    public Life GetLife { get => _life; }
    public Movement GetMovement { get => _movement; }
    public float GetInitJump { get => _initJumpForce; }
    public float GetInitSpeed { get => _initSpeed; }
}
