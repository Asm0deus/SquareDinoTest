using UnityEngine;
using UnityEngine.UI;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] Slider _healthSlider;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _health = 100;
    private void Start()
    {
        UpdateHP();
    }

    public void TakeDamage(float damageValue)
    {
        _health -= damageValue;
        UpdateHP();
    }

    public void UpdateHP()
    {
        if (_health <= 0)
        {
            _health = 0;
            _enemy.SetState(EnemyState.Dead);
        }
        _healthSlider.value = _health / 100f;
    }
}
