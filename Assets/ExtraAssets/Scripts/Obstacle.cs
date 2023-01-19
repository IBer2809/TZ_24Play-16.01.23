using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool _isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubePickup cubePickUp))
        {
            if (!_isHit && cubePickUp.CurrentCubeState != CubePickup.CubeState.Removed)
            {
                StartCoroutine(HitDeactivate());
                cubePickUp.ChangeCubeOnRemoving();
                int indexNum = cubePickUp.transform.GetSiblingIndex();
                CubePickup removingCube = Stack.Instance.GetCubeForRemoving(indexNum);
                Stack.Instance.RemoveCubFromList(removingCube);
                Stack.Instance.ChangeCubesConstaints(cubePickUp);
            }
        }

        else if (other.TryGetComponent(out CollisionChecker collisionChecker))
        {
            PlayerController.Instance.PlayerDeath();
        }




    }

    private IEnumerator HitDeactivate()
    {
        _isHit = true;
        yield return new WaitForSeconds(1f);
        _isHit = false;
    }
}

