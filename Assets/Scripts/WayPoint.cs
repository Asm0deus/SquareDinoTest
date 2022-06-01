using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private int _needKillEnemiesToGoal;

    private void Start()
    {
        _needKillEnemiesToGoal = transform.childCount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GoalScore goal = other.attachedRigidbody.GetComponent<GoalScore>();

        GetComponent<BoxCollider>().enabled = false;
        if (goal)
        {
            goal.UpdateCurrentGoal(_needKillEnemiesToGoal);
        }
    }
}
