using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _offsetTransform;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Play)
            transform.DOMove(new Vector3(0, _target.position.y, _target.position.z), 0.5f);
    }

    public void ShakeCamera()
    {
        Tween _shakeTween = _offsetTransform.DOShakePosition(0.4f, 1f);
        _shakeTween.Restart();

    }

}
