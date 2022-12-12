using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IAttributeController
{
    public event Action<int> onValueChange;

    private int _maxHealth;
    private int _currentHealth;

    private IMutable _healthUI;

    #region IAttributeController

    public void Initialize(int health) {
        _healthUI = GetComponentInChildren<HealthUI>();
        onValueChange += _healthUI.SetValue;

        Increase(health);
    }

    public void Increase(int value) {
        _currentHealth += value;
        onValueChange?.Invoke(_currentHealth);
    }

    public void Decrease(int value) {

        if (_currentHealth - value <= 0) {
            Destroy(gameObject);
            return;
        }

        _currentHealth -= value;
        onValueChange?.Invoke(_currentHealth);
    }

    #endregion

    private void OnDestroy() {
        onValueChange -= _healthUI.SetValue;
    }

}
