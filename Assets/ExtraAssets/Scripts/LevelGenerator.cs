using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    [SerializeField] private List<GameObject> _levelsToGenerate = new List<GameObject>();
    [SerializeField] private List<GameObject> _activeLevels = new List<GameObject>();
    [SerializeField] private Transform _platformsTransform;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (_activeLevels.Count >= 5)
        {
            Destroy(_activeLevels[0]);
            _activeLevels.Remove(_activeLevels[0]);
        }
    }

    public void Generate(int index)
    {
        transform.position = _activeLevels[_activeLevels.Count - 1].transform.position + new Vector3(0,transform.position.y, _activeLevels[_activeLevels.Count -1].transform.localScale.z);
        GameObject levelObj = Instantiate(_levelsToGenerate[index], transform.position, transform.rotation, _platformsTransform);
        levelObj.transform.DOMoveY(_activeLevels[_activeLevels.Count - 1].transform.position.y, 1f);
        _activeLevels.Add(levelObj);
    }
}
