using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Pusher : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;

    private Rigidbody _rigidbody;
    private Transform _parent;

    private readonly float PUSH_RANGE = 2.5f;
    void Start()
    {
        TryGetComponent(out _rigidbody);
        _parent = transform.parent;
    }

    void Update()
    {
        Vector3 center = _parent.position;
        float t = (Mathf.Sin(Time.time * Mathf.Deg2Rad * 360f / _duration) + 1f) * 0.5f;
        _rigidbody.MovePosition(center + Vector3.Lerp(Vector3.zero, Vector3.forward * PUSH_RANGE, t));
    }
}
