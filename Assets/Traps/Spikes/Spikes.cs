using System.Collections;
using UnityEngine;
public class Spikes : Traps
{
    [SerializeField]private bool _canDamage;
    [SerializeField]private float _cooldown;
    [SerializeField]private Coroutine _coroutine;
    protected override void Start()
    {
        base.Start();
        _canDamage = true;
        _cooldown = 2f;
        _damage = 10;
    }
    private void OnTriggerStay(Collider other)
    {
        if (_life == null) return;
        if (!other.CompareTag("Player") || !_canDamage) return;
        _canDamage = false;
        Action();
        if (_coroutine == null)
            _coroutine = StartCoroutine(CooldownCourutine());
    }
    protected override void Action()
    {
        if (_life == null || _life.GetLife <= 0) return;
        _life.TakeDamage(_damage);
    }
    IEnumerator CooldownCourutine()
    {
        yield return new WaitForSeconds(_cooldown);
        _canDamage = true;
        _coroutine = null;
    }
}

