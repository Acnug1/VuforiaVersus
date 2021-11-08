using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _secondsBetweenShoot; // время между выстрелами

    private float _lastShootTime; // время последнего выстрела
    private Animator _animator;

    public int Health => _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction PlayerDied;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastShootTime <= 0 && _health > 0)
        {
            _animator.Play("Shoot");
            _weapon.Shoot();
            _lastShootTime = _secondsBetweenShoot;
        }

        _lastShootTime -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health); // передаем количество здоровья при уроне игрока

        if (_health <= 0)
        {
            _animator.Play("Die");
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            StartCoroutine(DeathPlayer());
        }
    }

    private IEnumerator DeathPlayer()
    {
        var waitForSeconds = new WaitForSeconds(2f);
        yield return waitForSeconds;

        PlayerDied?.Invoke(); // вызывается при смерти игрока
    }
}
