using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private UnitHealth _unitHealth;
    [SerializeField] private int _zoneDamageValue = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            Bullet bullet = collision.rigidbody.GetComponent<Bullet>();

            if (bullet)
            {
                _unitHealth.TakeDamage(_zoneDamageValue);
            }
        }
    }
}
