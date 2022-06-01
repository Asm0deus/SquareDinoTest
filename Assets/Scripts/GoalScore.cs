using TMPro;
using System.Collections;
using UnityEngine;

public class GoalScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private int _goalToNextWayPoint;
 
    [SerializeField] private TMP_Text _startText;

    private void Start()
    {
        _weapon = FindObjectOfType<Weapon>();
        UpdateCurrentGoal(0);
        StartCoroutine(Destroy());
    }
    public void UpdateCurrentGoal(int goal)
    {
        _goalToNextWayPoint += goal;

        /*if (_goalToNextWayPoint != 0) _weapon.CanShoot(true);
        else _weapon.CanShoot(false);*/
    }

    public void UpdateGoal()
    {
        _goalToNextWayPoint--;
        if (_goalToNextWayPoint <= 0)
        {
            _player.GoToNextWP();
            UpdateCurrentGoal(0);
        }
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        _startText.gameObject.SetActive(false);
    }
}
