using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidbodys;

    private void Awake()
    {
        for (int i = 0; i < _allRigidbodys.Length; i++)
        {
            _allRigidbodys[i].isKinematic = true;
        }
    }

    public void MakePhysical()
    {
        _animator.enabled = false;
        for (int i = 0; i < _allRigidbodys.Length; i++)
        {
            _allRigidbodys[i].isKinematic = false;
        }
    }
}
