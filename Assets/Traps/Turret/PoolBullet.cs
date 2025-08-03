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
                int random = UnityEngine.Random.Range(0, BulletsConfig.Count);
                var currentConfig = BulletsConfig[random];
                _bullets[i].SetActive(true);
                _bullets[i].GetComponent<Bullet>().SetMaterial = currentConfig.materialColor;
                _bullets[i].GetComponent<Bullet>().SetDamage = currentConfig.damage;
                _bullets[i].GetComponent<Bullet>().SetSpeed = currentConfig.speed;
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
    public Color materialColor;
    public float damage;
    public float speed;
}