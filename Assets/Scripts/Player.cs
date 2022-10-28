using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    public event Action CoinCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GoldCoin>(out GoldCoin goldCoin))
        {
            CoinCollect?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
