using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropCheck : MonoBehaviour
{
    [Header("玩家掉落深度")]public float Playerdepth = 5;
    private Transform _playerTransform;

    void Awake()
    {
        if(_playerTransform == null)
        {
            _playerTransform = GameManager.Instance.PlayerGameObject.transform;
        }
    }
    void Update()
    {
        if(_playerTransform == null) return;

        if (_playerTransform.position.y < -Playerdepth)
        {
            
        }
    }
}
