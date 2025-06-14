using System;
using System.Collections.Generic;
using UnityEngine;
public enum ActionEnum
{
    PlayerSpeed,
    PlayerMass,
    PlayerJump
}
public class DelegatesManager : MonoBehaviour
{
    public Dictionary<ActionEnum,Delegate> actions;
    public static DelegatesManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        actions = new Dictionary<ActionEnum, Delegate>();
    }
    public void AddAction(ActionEnum key, Delegate value)
    {
        actions.Add(key, value);
    }
    public object TriggerAction(ActionEnum key, params object[] ars)
    {
        if (actions.TryGetValue(key, out var value))
        {
            return value?.DynamicInvoke(ars);
        }
        else
        {
            return null;
        }
    }
}