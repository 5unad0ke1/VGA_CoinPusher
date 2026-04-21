using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Pusher : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;

    private Rigidbody _rigidbody;
    private Transform _parent;

    void Start()
    {
        TryGetComponent(out _rigidbody);
        _parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = _parent.position;
        _rigidbody.MovePosition(center + Vector3.Lerp(Vector3.zero, Vector3.forward * 2.5f, (Mathf.Sin(Time.time * Mathf.Deg2Rad * 360f / _duration) + 1f) * 0.5f));
    }
}
