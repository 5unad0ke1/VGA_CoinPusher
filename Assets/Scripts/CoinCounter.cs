using UnityEngine;
using UnityEngine.UI;

public sealed class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private int _initCoin;
    [SerializeField] private int _currentCoin;

    public int CurrentCoin => _currentCoin;
    private void Awake()
    {
        _currentCoin = _initCoin;
        CoinMessage.Counter = this;

        UpdateText();
    }
    private void OnDestroy()
    {
        if (CoinMessage.Counter == this)
            CoinMessage.Counter = null;
    }
    public void ChangeCoin(int coin)
    {
        _currentCoin += coin;
        UpdateText();
    }
    private void UpdateText()
    {
        _text.text = _currentCoin.ToString();
    }
}
public static class CoinMessage
{
    public static CoinCounter Counter;
}
