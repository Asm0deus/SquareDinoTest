using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GoalScore goal = other.attachedRigidbody.GetComponent<GoalScore>();

        GetComponent<BoxCollider>().enabled = false;
        if (goal)
        {
            SceneManager.LoadScene(0);
        }
    }
}
