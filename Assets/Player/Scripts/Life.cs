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
    public void TakeDamage(int damage)
    {
        _life -= damage;
        CheckLife();
        Debug.Log($"Vida actual: {_life}");
    }
    public void RestoreLife(int life)
    {
        _life += life;
        CheckLife();
        Debug.Log($"Vida actual: {_life}");
    }
    public float GetLife { get => _life; }
}