using UnityEngine;

public sealed class CoinPhysics : MonoBehaviour
{

    private static readonly string TAG_PUSHER = "Pusher";
    private static readonly string TAG_FINISH = "Finish";
    private static readonly int COIN_INCREMENT = 1;

    private bool _isTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_PUSHER) && _isTrigger)
        {
            transform.SetParent(collision.transform, true);
        }
        if (collision.gameObject.CompareTag(TAG_FINISH))
        {
            CoinMessage.Counter.ChangeCoin(COIN_INCREMENT);
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAG_PUSHER))
        {
            transform.SetParent(null, true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PUSHER))
        {
            _isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TAG_PUSHER))
        {
            _isTrigger = false;
        }
    }
}
