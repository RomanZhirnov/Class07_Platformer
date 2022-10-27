using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Wallet : MonoBehaviour
{
    [SerializeField] private AudioClip _takeCoin;
    [SerializeField] private Player _coinCollect;

    private AudioSource _audioSource;
    private int _totalCoinInLevel;
    private int _coinsInWallet;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        GoldCoin[] _coins = GameObject.FindObjectsOfType<GoldCoin>();
        _totalCoinInLevel = _coins.Length;
    }
    private void OnEnable()
    {
        _coinCollect.CoinCollect += CollectCoin;
    }

    private void OnDisable()
    {
        _coinCollect.CoinCollect -= CollectCoin;
    }

    private void CollectCoin()
    {
        _audioSource.PlayOneShot(_takeCoin);
        _coinsInWallet++;
        Debug.Log($"Собрано {_coinsInWallet} из {_totalCoinInLevel}");
    }
}
