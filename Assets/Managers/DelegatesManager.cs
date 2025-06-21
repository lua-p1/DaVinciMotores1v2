using System;
using System.Collections.Generic;
using UnityEngine;
public enum KeysDelegatesEnumEvents
{
    PlayerDeath,
}
public enum KeysDelegatesEnumWoutFirm
{
}
public class DelegatesManager : MonoBehaviour
{
    private Dictionary<KeysDelegatesEnumEvents, Action> _actions;
    private Dictionary<KeysDelegatesEnumWoutFirm, Delegate> _generalActions;
    public static DelegatesManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        _actions = new Dictionary<KeysDelegatesEnumEvents,Action>();
        _generalActions = new Dictionary<KeysDelegatesEnumWoutFirm, Delegate>();
    }
    public void AddAction(KeysDelegatesEnumEvents key, Action value)
    {
        if (_actions.ContainsKey(key))
            _actions[key] += value;
        else
            _actions[key] = value;
    }
    public void RemoveAction(KeysDelegatesEnumEvents key, Action value)
    {
        if (!_actions.ContainsKey(key)) return;
        _actions[key] -= value;
        if (_actions[key] != null) return;
        _actions.Remove(key);
    }
    public void TriggerAction(KeysDelegatesEnumEvents key)
    {
        if (_actions.TryGetValue(key, out var value))
        {
            value?.Invoke();
        }
    }
    #region // Delegates Sin Firma
    public void AddAction(KeysDelegatesEnumWoutFirm key, Delegate value)
    {
        if (_generalActions.ContainsKey(key)) return;
        _generalActions.Add(key, value);
    }
    public void RemoveAction(KeysDelegatesEnumWoutFirm key)
    {
        if (!_generalActions.ContainsKey(key)) return;
        _generalActions.Remove(key);
    }
    public object TriggerAction(KeysDelegatesEnumWoutFirm key, params object[] ars)
    {
        if (_generalActions.TryGetValue(key, out var value))
        {
            return value?.DynamicInvoke(ars);
        }
        else
        {
            return null;
        }
    }
    #endregion
}