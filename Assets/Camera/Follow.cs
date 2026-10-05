using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float Speed = 5f;
    private GameObject _playerGameObject;
    private Vector3 offest;
    private void Awake()
    {
        _playerGameObject = GameManager.Instance.PlayerGameObject;
        if(_playerGameObject == null)
        {
            return;
        }
    }
    private void Start()
    {
        offest = transform.position - _playerGameObject.transform.position;
    }
    private void LateUpdate()
    {
        Vector3 newdirection = _playerGameObject.transform.position + offest;
        transform.position = Vector3.Lerp(transform.position,newdirection,Speed*Time.deltaTime);
    }
}
