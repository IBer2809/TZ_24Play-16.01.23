using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroup : MonoBehaviour
{
    private int _firstCubesCount;
    private int _secondCubesCount;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubePickup cubePickup))
        {
            CameraController.Instance.ShakeCamera();
            _firstCubesCount = cubePickup.transform.parent.GetComponent<Stack>().GetCubesCount();
            StartCoroutine(BloomEffect.Instance.StopBloomEffect(0.5f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CubePickup cubePickup))
        {
            _secondCubesCount = cubePickup.transform.parent.GetComponent<Stack>().GetCubesCount();
            int value = _firstCubesCount - _secondCubesCount;
            PlayerController.Instance.PlayerChangePositionDown(value);

        }
    }




}
