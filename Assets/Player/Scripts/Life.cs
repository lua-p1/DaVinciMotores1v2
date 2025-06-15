using System;
using UnityEngine;
public class Life
{
    private float _life;
    private GameObject _gameObject;
    public Life(GameObject _gameObject, float _life)
    {
        this._gameObject = _gameObject;
        this._life = _life;
    }
    private void CheckLife()
    {
        if (_life <= 0)
        {
            GameObject.Destroy(_gameObject);
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

    public static implicit operator float(Life v)
    {
        throw new NotImplementedException();
    }
}