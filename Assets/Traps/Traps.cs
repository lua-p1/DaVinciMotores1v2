using UnityEngine;
public abstract class Traps : MonoBehaviour
{
    protected float _damage;
    protected abstract void Start();
    protected abstract void Action();
}

