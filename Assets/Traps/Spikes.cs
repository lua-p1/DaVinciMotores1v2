using UnityEngine;
public class Spikes : Traps
{
    private bool _canDamage = true;
    [SerializeField] private float _cooldown = 2f;
    private void OnTriggerStay(Collider other)
    {
        if (GameManager.instance.player == null) _life = null;
        if (_life != null && other.CompareTag("Player") && _canDamage)
        {
            Action();
            print("el player entro en el trigger");
            _canDamage = false;
            Invoke(nameof(ResetDamage), _cooldown);
        }
    }
    protected override void Action()
    {
        _damage = 10;
        if (_life != null && _life.GetLife > 0)
         {
           _life.TakeDamage(_damage);
           print($"recibiste " + _damage + " de danio");
        }
    }
    private void ResetDamage()
    {
        _canDamage = true;
    }
}

