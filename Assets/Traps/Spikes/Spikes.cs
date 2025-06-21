using System.Collections;
using UnityEngine;
public class Spikes : Traps
{
    [SerializeField]private bool _canDamage;
    [SerializeField]private float _cooldown;
    [SerializeField]private Coroutine _coroutine;
    protected override void Start()
    {
        _canDamage = true;
        _cooldown = 2f;
        _damage = 10f;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<ITakeDamage>(out var damagableObject) && _canDamage)
        {
            damagableObject.TakeDamage(_damage);
            _canDamage = false;
            Action();
        }
    }
    protected override void Action()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(CooldownCourutine());
    }
    IEnumerator CooldownCourutine()
    {
        yield return new WaitForSeconds(_cooldown);
        _canDamage = true;
        _coroutine = null;
    }
}

