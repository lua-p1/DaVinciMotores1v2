using System;
using System.Collections.Generic;
using UnityEngine;
public enum KeysDelegatesEnum
{
    PlayerSpeed,
    PlayerMass,
    PlayerJump
}
public class DelegatesManager : MonoBehaviour
{
    private Dictionary<KeysDelegatesEnum,Delegate> _actions;
    public static DelegatesManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        _actions = new Dictionary<KeysDelegatesEnum,Delegate>();
    }
    public void AddAction(KeysDelegatesEnum key, Delegate value)
    {
        _actions.Add(key, value);
    }
    public object TriggerAction(KeysDelegatesEnum key,params object[] ars)
    {
        if (_actions.TryGetValue(key, out var value))
        {
            return value?.DynamicInvoke(ars);
        }
        else
        {
            return null;
        }
    }
}