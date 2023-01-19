using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorWall : MonoBehaviour
{
    [SerializeField] private int _levelIndexToGenerate;
    private bool _isHit = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubePickup cubePickup))
        {
            if (!_isHit)
            {
                StartCoroutine(HitDeactivate());
                LevelGenerator.Instance.Generate(_levelIndexToGenerate);
            }
        }
    }

    private IEnumerator HitDeactivate()
    {
        _isHit = true;
        yield return new WaitForSeconds(3f);
        _isHit = false;
    }
}
