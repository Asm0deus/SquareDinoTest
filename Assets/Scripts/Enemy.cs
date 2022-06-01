using UnityEngine;

public enum EnemyState
{
    Idle,
    Dead
}
public class Enemy : MonoBehaviour
{
    [Space(10)] [Header("EnemyKnife")] 

    [SerializeField] private EnemyState _currentEnemyState;

    [SerializeField] private GoalScore _goalScore;
    [SerializeField] private RagdollControl _ragdollControl;

    [SerializeField] private UnitHealth _enemyHealth;

    private void Start()
    {
        SetState(EnemyState.Idle);
        _goalScore = FindObjectOfType<GoalScore>();
        _ragdollControl = GetComponent<RagdollControl>();
    }

    public void SetState(EnemyState state)
    {
        _currentEnemyState = state;
        switch (_currentEnemyState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Dead:
                _ragdollControl.MakePhysical();
                _goalScore.UpdateGoal();
                Destroy(gameObject,3f);
                break;
            default:
                break;
        }
    }
}
