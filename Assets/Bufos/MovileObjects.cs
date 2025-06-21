using UnityEngine;
public class MovileObjects : MonoBehaviour
{
    [SerializeField]private int _defaultLayer;
    [SerializeField]private int _movileLayer;
    [SerializeField]private bool _isMovile;
    void Start()
    {
        _defaultLayer = 0;
        _isMovile = false;
        _movileLayer = 10;
        DelegatesManager.instance.AddAction(KeysDelegatesEnumEvents.ChangeMovile,ChangeLayerToMovile);
    }
    private void ChangeLayerToMovile()
    {
        if (!_isMovile)
        {
            this.gameObject.layer = _movileLayer;
            _isMovile = true;
        }
        else
        {
            this.gameObject.layer = _defaultLayer;
            _isMovile = false;
        }
    }
}
