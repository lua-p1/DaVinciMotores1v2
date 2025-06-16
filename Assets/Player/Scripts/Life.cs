using UnityEngine;
public class Life
{
    private float _currentLife;
    public Life(float _currentLife)
    {
        this._currentLife = _currentLife;
    }
    private void CheckLife()
    {
        if (_currentLife <= 0)
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerDeath);
        }
    }
    public void TakeDamage(float damage)
    {
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
}