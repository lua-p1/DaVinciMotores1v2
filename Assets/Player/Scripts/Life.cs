using UnityEngine;
public class Life
{
    private float _life;
    public Life(float _life)
    {
        this._life = _life;
    }
    private void CheckLife()
    {
        if (_life <= 0)
        {
            DelegatesManager.instance.TriggerAction(KeysDelegatesEnum.PlayerDeath);
        }
    }
    public void TakeDamage(float damage)
    {
        _life -= damage;
        CheckLife();
        Debug.Log($"Vida actual: {_life}");
    }
    public void RestoreLife(float life)
    {
        if (_life >= 100f) return;
        _life += life;
        _life = Mathf.Clamp( _life,0f,100f);
        CheckLife();
        Debug.Log($"Vida actual: {_life}");
    }
    public float GetLife { get => _life; }
}