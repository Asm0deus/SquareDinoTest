using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public enum UnitState
{
    Idle,
    Run
}
public class Player : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] public UnitState _currentState;

    [SerializeField] protected Animator _animator;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private WayPoint[] _wayPoint;
    [SerializeField] private Transform _currentWayPoint;

    [SerializeField] private bool _letsGo;
    [SerializeField] private Weapon _weapon;
    private int _numWP;

    public void Start()
    {
        SetState(UnitState.Idle); 
        transform.position = _startPoint.position;
        //_wayPoint = FindObjectsOfType<WayPoint>(); //Можно раскомментить, чтобы точки добавлялись автоматом, но тогда надо учитывать, что добавляются с конца.
    }
    public void SetState(UnitState state)
    {
        _currentState = state;
        switch (_currentState)
        {
            case UnitState.Idle:
                _animator.SetTrigger("idle");
                break;
            case UnitState.Run:
                _agent.SetDestination(_currentWayPoint.position);
                //if(Vector3.Distance(transform.position, _wayPoint.position) < 0.2f) SetState(UnitState.Idle);
                _animator.SetTrigger("run");
                break;
            default:
                break;
        }
    }

    public void GoToNextWP()
    {
        _letsGo = true;
        FindClosestWayPoint();
    }

    public void FindClosestWayPoint()
    {

        float minDistance = Mathf.Infinity;
        WayPoint closestWayPoint = null;

        float distance = Vector3.Distance(transform.position, _wayPoint[_numWP++].transform.position);

        if (_letsGo)
        {
            if (distance < minDistance)
            {
                minDistance = distance;
                closestWayPoint = _wayPoint[_numWP];
                _currentWayPoint = closestWayPoint.transform;
                SetState(UnitState.Run);
                _letsGo = false;
                
            }
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        //FindClosestWayPoint();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case UnitState.Idle:
                break;
            case UnitState.Run:
                _agent.SetDestination(_currentWayPoint.position);
                if (Vector3.Distance(transform.position, _currentWayPoint.position) < 0.2f)
                {
                    SetState(UnitState.Idle);
                    _letsGo = false;
                    //_weapon._isCanShoot = true;
                }
                break;
            default: 
                break;
        }
    }
}
