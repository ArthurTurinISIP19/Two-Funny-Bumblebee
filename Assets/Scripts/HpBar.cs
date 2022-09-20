using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Player _player;

    private int _currentHp;

    private void OnEnable()
    {
        _player.OnHpChange += ChangeHpBar;
    }
    private void OnDisable()
    {
        _player.OnHpChange -= ChangeHpBar;
    }
    private void Start()
    {
        _currentHp = _player._hp;
        for (int i = 0; i < _currentHp; i++)
        {
            _hearts[i].enabled = true;
        }
    }
    private void ChangeHpBar()
    {
        _currentHp--;
        ShowHpBar();
    }
    private void ShowHpBar()
    {
        _hearts[_currentHp].enabled = false;
    }
}
