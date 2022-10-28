using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Wallet : MonoBehaviour
{
    [SerializeField] private AudioClip _takeCoin;
    [SerializeField] private Player _coinCollect;

    private AudioSource _audioSource;
    private int _coinsInWallet;

    public static int CoinCount;

    private void Awake()
    {
        CoinCount = 0;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GoldCoin>(out GoldCoin goldCoin))
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        _audioSource.PlayOneShot(_takeCoin);
        _coinsInWallet++;
        Debug.Log($"Собрано {_coinsInWallet} из {CoinCount}");
    }
}
