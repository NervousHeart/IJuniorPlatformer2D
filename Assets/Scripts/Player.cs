using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public int Money { get; private set; }

    private void Start()
    {
        _text.text = Money.ToString();
    }

    public void AddMoney(int money)
    {
        Money += money;
        _text.text = Money.ToString();
    }
}
