using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack Instance;
    [SerializeField] private List<CubePickup> _cubes;
    [SerializeField] private PlayerController _player;
    [SerializeField] private Transform _trail;
    [SerializeField] private ParticleSystem _stackParticle;
    [SerializeField] private GameObject _collectCubeText;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if(_cubes.Count != 0)
        {
            _trail.transform.position = new Vector3(_cubes[_cubes.Count - 1].transform.position.x, _cubes[_cubes.Count - 1].transform.position.y - 0.49f, _cubes[_cubes.Count - 1].transform.position.z);
            _stackParticle.transform.position = _cubes[0].transform.position;
        }
    }

    public void AddCubeToList(CubePickup nextCube)
    {
        _player.PlayerJump();
        nextCube.transform.parent = transform;
        Vector3 lastParent = _cubes[_cubes.Count - 1].transform.localPosition;
        nextCube.transform.localPosition = lastParent - new Vector3(0, _cubes[_cubes.Count - 1].transform.localScale.y, 0);
        Vector3 nextPlayerPos = _player.transform.position + new Vector3(0, 1, 0);
        _player.PlayerChangePositionY(nextPlayerPos);
        _cubes.Add(nextCube);
        _stackParticle.Play();
        Instantiate(_collectCubeText, _cubes[0].transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
    }

    public void RemoveCubFromList(CubePickup removingCube)
    {
        removingCube.transform.parent = null;
        _cubes.Remove(removingCube);
        if (_cubes.Count == 0)
        {
            _player.PlayerDeath();
        }
    }

    public void ChangeCubesConstaints(CubePickup cube) {
        cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

    }


    public void ChangeCubesConstaints()
    {
        for (int i = 0; i < _cubes.Count; i++)
        {
            _cubes[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

    }

    public CubePickup GetCubeForRemoving(int index)
    {
        CubePickup currentCube = null;
        for (int i = 0; i < _cubes.Count; i++)
        {
            if (i == index)
            {
                currentCube = _cubes[i];
                break;
            }
        }
        return currentCube;
    }

    public int GetCubesCount()
    {
        return _cubes.Count;
    }

}
