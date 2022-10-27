using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    public event Action CoinCollect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<GoldCoin>(out GoldCoin goldCoin))
        {
            CoinCollect?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
