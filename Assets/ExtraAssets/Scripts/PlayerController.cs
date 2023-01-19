using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private Rigidbody[] _ragdolls;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _playerAnimator;

    private Vector3 _posMouseOne;
    private Vector3 _posMouseTwo;
    private Vector3 _delta, _currentDelta;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _ragdolls.Length; i++)
        {
            _ragdolls[i].isKinematic = true;
        }
    }

    private void Update()
    {
        if(GameManager.Instance.CurrentState == GameManager.GameState.Play )
            PlayerMovement();
    }
    private void PlayerMovement()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            _posMouseOne = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            _posMouseTwo = Input.mousePosition;
            _delta = -(_posMouseOne - _posMouseTwo).normalized;
            _currentDelta = Vector3.Lerp(_currentDelta, _delta, 5f * Time.deltaTime);
            transform.position += new Vector3(_currentDelta.x * 0.3f, 0, 0);
            _posMouseOne = Input.mousePosition;
        }

        ClampPersonMovementX(transform, -2f, 2f);
    }

    private void ClampPersonMovementX(Transform target, float clampXMIN, float clampXMAX)
    {
        var pos = target.position;
        pos.x = Mathf.Clamp(target.position.x, clampXMIN, clampXMAX);
        target.position = pos;
    }

    public void PlayerChangePositionY(Vector3 posValue)
    {
        transform.position = posValue;
    }

    public void PlayerChangePositionDown(int value)
    {
        Vector3 nextPlayerPos = new Vector3(transform.position.x, transform.position.y - value, transform.position.z);
        transform.DOMoveY(nextPlayerPos.y, 0.2f);
    }

    public void PlayerDeath()
    {
        for (int i = 0; i < _ragdolls.Length; i++)
        {
            _playerAnimator.transform.parent = null;
            _playerAnimator.enabled = false;
            _ragdolls[i].isKinematic = false;
        }
        GameManager.Instance.ChangeGameState(GameManager.GameState.GameOver);
        UIManager.Instance.ActivateGameOverPanel();
    }



    public void PlayerJump()
    {
        _playerAnimator.SetTrigger("Jump");
    }


}
