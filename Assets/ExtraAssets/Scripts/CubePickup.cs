using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePickup : MonoBehaviour
{
    public enum CubeState { NotPicked, Picked, Removed }
    [field: SerializeField] public CubeState CurrentCubeState { get; private set; }


    private void Start()
    {
        if (transform.parent.GetComponent<Stack>())
            CurrentCubeState = CubeState.Picked;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out CubePickup cubePickup))
        {
            if(this.CurrentCubeState == CubeState.Picked && cubePickup.CurrentCubeState == CubeState.NotPicked)
            {
                Stack.Instance.AddCubeToList(cubePickup);
                cubePickup.CurrentCubeState = CubeState.Picked;;
            }
        }
    }

    public void ChangeCubeOnRemoving() => CurrentCubeState = CubeState.Removed;
}
