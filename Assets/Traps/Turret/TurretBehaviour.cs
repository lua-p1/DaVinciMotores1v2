using UnityEngine;
public class TurretBehaviour : Traps
{
    private RayCastTurret _rayTurret;
    private float _shootCooldown;
    private float _distance;
    private bool _isActivate;
    [SerializeField]private float _fireRate;
    [SerializeField]private Animation _anim;
    [SerializeField]private Transform _child;
    [SerializeField]private Transform _GunSight;
    [SerializeField]private Material lineRendererMaterial;
    [SerializeField]private LayerMask mask;
    protected override void Start()
    {
        _distance = 50f;
        _isActivate = true;
        _anim = GetComponent<Animation>();
        _rayTurret = new RayCastTurret(_GunSight, mask, _distance, lineRendererMaterial,this);
    }
    private void Update()
    {
        if (!_isActivate) return;
        Action();
    }
    protected override void Action()
    {
        if (_child == null || GameManager.instance.player == null) return;
        Vector3 _dirRotVector = GameManager.instance.player.transform.position - this.transform.position;
        Quaternion _dirRotQuaternion = Quaternion.LookRotation(_dirRotVector);
        _child.transform.rotation = Quaternion.Slerp(_child.transform.rotation, _dirRotQuaternion, 5 * Time.deltaTime);
        _rayTurret.OnUpdate();
        _shootCooldown -= Time.deltaTime;
        if (_rayTurret.IsEnabled && _shootCooldown <= 0f)
        {
            Shoot();
            _shootCooldown = _fireRate;
        }
    }
    private void Shoot()
    {
        var bullet = PoolBullet.instance.GetBullet();
        if (bullet == null) return;
        bullet.transform.position = _GunSight.position;
        bullet.transform.rotation = _GunSight.rotation;
    }
    public void OnDead()
    {
        _isActivate = false;
        _anim.Play("TurretDead");
        _rayTurret.GetLineRenderer.enabled = false;
    }
    public bool SetActivate { set => _isActivate = value; }
}
