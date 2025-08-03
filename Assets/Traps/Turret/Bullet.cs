using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private float _speed;
    private bool _isDesactivate;
    private float _dmg;
    private float _timeToDesactivate;
    private void Awake()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
        _dmg = 0f;
        _speed = 0f;
        _timeToDesactivate = 5f;
    }
    private void OnEnable()
    {
        _isDesactivate = false;
        StartCoroutine(DesactivateBulletCourutine());
    }
    private void Update()
    {
        this.transform.localPosition += this.transform.forward * _speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ITakeDamage>(out var damagable))
        {
            damagable.TakeDamage(_dmg);
            DesactivateBullet();
        }
        if(other.gameObject.layer == 0)
        {
            DesactivateBullet();
        }
    }
    IEnumerator DesactivateBulletCourutine()
    {
        yield return new WaitForSeconds(_timeToDesactivate);
        if (!_isDesactivate)
        {
            DesactivateBullet();
        }
    }
    private void DesactivateBullet()
    {
        _isDesactivate = true;
        this.gameObject.SetActive(false);
    }
    public Color SetMaterial { set => this.GetComponent<Renderer>().material.color = value; }
    public float SetDamage { set => _dmg = value; }
    public float SetSpeed { set => _speed = value; }
}
