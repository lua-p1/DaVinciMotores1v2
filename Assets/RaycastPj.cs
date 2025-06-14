using UnityEngine;
public class RaycastPj : MonoBehaviour
{
    private float distance_ray;
    Ray ray;
    Transform _transform;
    public RaycastPj(Transform transform, float distance)
    {
        _transform = transform;
        distance_ray = distance;
    }
    public void Interact()
    {
        ray = new Ray(_transform.position, _transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * distance_ray, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, distance_ray))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.TryGetComponent<InteractiveObj>(out var InteractuableObject))
            {
                InteractuableObject.InteractAction();
            }
        }
    }
}