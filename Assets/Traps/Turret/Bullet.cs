using System.Collections;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private float _speed;
    private bool _isDesactivate;
    private float _dmgPlayer;
    private float _timeToDesactivate;
    private void Awake()
    {
        _dmgPlayer = 50f;
        _speed = 5f;
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
        if(other.TryGetComponent<Player>(out var player))
        {
            player.GetLife.TakeDamage(_dmgPlayer);
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
}
