using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _bulletSpeed = 10f;
    private PoolObject _poolObject;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _poolObject = GetComponent<PoolObject>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * _bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _poolObject.ReturnToPool();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        _poolObject.ReturnToPool();
    }
}
