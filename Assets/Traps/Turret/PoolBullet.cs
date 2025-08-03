using System;
using System.Collections.Generic;
using UnityEngine;
public class PoolBullet : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    [SerializeField]private int initialSize;
    [SerializeField]private List<GameObject> _bullets;
    public List<ConfigBullet> BulletsConfig;
    public static PoolBullet instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        _bullets = new List<GameObject>();
    }
    private void Start()
    {
        CompleteList(initialSize);
    }
    public void CompleteList(int number)
    {
        for (int i = 0; i < number; i++)
        {
            var _cloneBullet = GameObject.Instantiate(prefab);
            _cloneBullet.SetActive(false);
            _bullets.Add(_cloneBullet);
            _cloneBullet.transform.parent = this.transform;
        }
    }
    public GameObject GetBullet()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].activeSelf)
            {
                _bullets[i].SetActive(true);
                return _bullets[i];
            }
        }
        CompleteList(1);
        GameObject _auxBullet = _bullets[_bullets.Count - 1];
        _auxBullet.SetActive(true);
        return _auxBullet;
    }
}
[Serializable]
public struct ConfigBullet
{
    public Material material;
    public float damage;
}