using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private Transform _stickManTransform;
    [SerializeField] private CapsuleCollider _capsuleCollider;

    private void Update()
    {
        if(GameManager.Instance.CurrentState == GameManager.GameState.Play)
        {
            _capsuleCollider.enabled = true;
            transform.position = _stickManTransform.position;
        }
        else
            _capsuleCollider.enabled = false;
    }
}
