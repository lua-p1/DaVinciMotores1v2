using System.Collections;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    private Player _playerRef;
    void Start()
    {
        StartCoroutine(FindPJ());
    }
    private void LateUpdate()
    {
        if (_playerRef != null)
        {
            transform.position = _playerRef.transform.position + _offset;
        }
    }
    IEnumerator FindPJ()
    {
        while (GameManager.instance == null || GameManager.instance.player == null)
        {
            yield return null;
        }
        _playerRef = GameManager.instance.player;
        _offset = this.transform.position - _playerRef.transform.position;
    }
}