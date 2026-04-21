using UnityEngine;
using UnityEngine.InputSystem;

public sealed class CoinFactory : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private Vector3 _initializePos;
    [SerializeField] private Vector3 _initializeScale;
    [SerializeField] private GameObject _coinPrefab;
    void Start()
    {
        Debug.Assert(_coinPrefab != null);

        for (int i = 0; i < _count; i++)
        {
            Vector3 pos;
            pos.x = Random.Range(-_initializeScale.x, _initializeScale.x);
            pos.y = Random.Range(-_initializeScale.y, _initializeScale.y);
            pos.z = Random.Range(-_initializeScale.z, _initializeScale.z);
            Instantiate(_coinPrefab, _initializePos + pos, Random.rotation);
        }
    }
    void Update()
    {
        if (CoinMessage.Counter.CurrentCoin <= 0)
        {
            return;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CoinMessage.Counter.ChangeCoin(-1);
            Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_initializePos, _initializeScale * 2f);
    }
}
