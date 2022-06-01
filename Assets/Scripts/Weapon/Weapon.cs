using UnityEngine;

[RequireComponent(typeof(Pool))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] private float _shootPeriod;
    [SerializeField] private bool _isCanShoot;

    [SerializeField] private Player _player;

    [SerializeField] protected AudioSource _shootSound;

    private float _timer;
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }
    public void CanShoot(bool isCan)
    {
        _isCanShoot = isCan;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (Input.GetMouseButtonUp(0))
        {
            if (!_isCanShoot)
            {
                _player.GoToNextWP();
                return;
            }

            if (_timer > _shootPeriod)
            {
                _timer = 0;
                Shoot();
            }
        }
    }
    public virtual void Shoot()
    {
        _pool.GetFreeElement(_spawnPoint.position, _spawnPoint.rotation);
        _shootSound.Play();
    }
}
