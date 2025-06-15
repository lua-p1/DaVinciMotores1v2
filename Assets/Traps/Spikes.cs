using UnityEngine;
public class Spikes : Traps
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            Action();
            print("el player entro en el trigger");
        }
    }
    protected override void Action()
    {
            _damage = 10;
            
            _life.TakeDamage(_damage);
            print($"recibiste " + _damage + " de danio");
    }

}

