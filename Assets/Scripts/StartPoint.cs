using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        GoalScore goal = other.attachedRigidbody.GetComponent<GoalScore>();
        Weapon weapon = goal.gameObject.GetComponentInChildren<Weapon>();

        if (weapon)
        {
            weapon.CanShoot(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GoalScore goal = other.attachedRigidbody.GetComponent<GoalScore>();
        Weapon weapon = goal.gameObject.GetComponentInChildren<Weapon>();

        if (weapon)
        {
            weapon.CanShoot(true);
        }
    }
}
