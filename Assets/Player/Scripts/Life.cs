using UnityEngine;
public class Life
{
    private float _currentLife;
    private bool _canDamage;
    public Life(float _currentLife)
    {
        this._currentLife = _currentLife;
        _canDamage = true;
    }
    private void CheckLife()
    {
        if (_currentLife <= 0)
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnumEvents.PlayerDeath);
        }
    }
    public void TakeDamage(float damage)
    {
        if(!_canDamage)return;
        _currentLife -= damage;
        CheckLife();
        Debug.Log($"Vida actual: {_currentLife}");
    }
    public void RestoreLife(float restoreLife)
    {
        _currentLife += restoreLife;
        _currentLife = Mathf.Clamp( _currentLife,0f,100f);
        CheckLife();
        Debug.Log($"Vida actual: {_currentLife}");
    }
    public float GetLife { get => _currentLife; }
    public bool SetCanDamage { get => _canDamage;set => _canDamage = value; }
}