using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            Destroy(gameObject);
        }
    }
}
