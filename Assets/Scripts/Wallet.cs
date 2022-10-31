using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Wallet : MonoBehaviour
{
    [SerializeField] private AudioClip _takeCoin;

    private AudioSource _audioSource;
    private int _coinsInWallet;

    private void Start()
    {
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
        Debug.Log($"Собрано {_coinsInWallet} монет");
    }
}
