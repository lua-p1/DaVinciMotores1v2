using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour ,IBoostedJump ,IBoostedMass, IBoostedSpeed , ITakeDamage
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
    [SerializeField]private Transform _interactPos;
    [SerializeField]private LayerMask layerMaskGround;
    [SerializeField] private LayerMask layerMaskWall;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _initSpeed = 10f;
        _initLife = 100f;
        _initJumpForce = 3f;
    }
    private void Start()
    {
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _movement = new Movement(this.transform, _initSpeed, _rb, _initJumpForce);
        _life = new Life(_initLife);
        _rayCastPj = new RaycastPj(_interactPos, 5f);
        _controller = new Controller(_movement,_rayCastPj,_groundChecker,layerMaskGround, layerMaskWall);
        DelegatesManager.instance.AddAction(KeysDelegatesEnumEvents.PlayerDeath, PlayerDeath);
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
    public IEnumerator ChangeJump(float buff, float notBuff, float time)
    {
        _movement.GetAndSetJump = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetJump = notBuff;
    }
    public IEnumerator ChangeMass(float buff, float notBuff, float time)
    {
        _movement.GetAndSetMass = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetMass = notBuff;
    }
    public IEnumerator ChangeSpeed(float buff, float notBuff, float time)
    {
        _movement.GetAndSetSpeed = buff;
        yield return new WaitForSeconds(time);
        _movement.GetAndSetSpeed = notBuff;
    }
    public void StartJumpBuff(float buff, float notBuff, float time)
    {
        StartCoroutine(ChangeJump(buff, notBuff, time));
    }
    public void StartMassBuff(float buff, float notBuff, float time)
    {
        StartCoroutine(ChangeMass(buff, notBuff, time));
    }
    public void StartSpeedBuff(float buff, float notBuff, float time)
    {
        StartCoroutine(ChangeSpeed(buff, notBuff, time));
    }
    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundChecker.position, 0.5f);
    }
    private void PlayerDeath()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        _movement = null;
        _controller = null;
        _life = null;
        _rayCastPj = null;
        DelegatesManager.instance.RemoveAction(KeysDelegatesEnumEvents.PlayerDeath, PlayerDeath);
    }
    public void TakeDamage(float damage)
    {
        _life.TakeDamage(damage);
    }
    public Life GetLife { get => _life; }
    public Movement GetMovement { get => _movement; }
    public float GetInitJump { get => _initJumpForce; }
    public float GetInitSpeed { get => _initSpeed; }
}
