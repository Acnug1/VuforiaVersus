using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _trackablePlayer;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _trackablePlayer.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _trackablePlayer.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.maxValue = _trackablePlayer.Health; // делаем максимальное значение слайдера равным количеству жизней у игрока
        _slider.value = _slider.maxValue; // при старте передаем максимальное количество жизней игрока в наш HealthBar
    }

    private void OnHealthChanged(int health)
    {
        _slider.value = health;
    }
}
