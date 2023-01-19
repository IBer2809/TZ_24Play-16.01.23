using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomEffect : MonoBehaviour
{
    public static BloomEffect Instance;
    [SerializeField] private float _offset;
    [SerializeField] private ParticleSystem _bloomEffect;
    [SerializeField] private Transform _targetToFollow;
    public bool _bloomIsActive = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _targetToFollow.position.z + _offset);
        if(GameManager.Instance.CurrentState == GameManager.GameState.Play)
        {
            if (_bloomIsActive == true)
                _bloomEffect.Play();
            else
                _bloomEffect.Stop();
        }
    }

    public IEnumerator StopBloomEffect(float delay)
    {
        _bloomIsActive = false;
        yield return new WaitForSeconds(delay);
        _bloomIsActive = true;
    }
}
