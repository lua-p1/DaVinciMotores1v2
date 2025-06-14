using UnityEngine;
public class Life
{
    private float _lifeclase;
    private GameObject _gameObject;
    public Life(GameObject gameObject, float startingLife)
    {
        _gameObject = gameObject;
        _lifeclase = startingLife;
    }
    private void CheckLife()
    {
        if (_lifeclase <= 0)
        {
            GameObject.Destroy(_gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        _lifeclase -= damage;
        CheckLife();
        Debug.Log($"Vida actual: {_lifeclase}");
    }
    public void RestoreLife(int life)
    {
        _lifeclase += life;
        CheckLife();
        Debug.Log($"Vida actual: {_lifeclase}");
    }
        public float LIFE { get => _lifeclase; }
}
