using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("交互移动速度")]public float Speed = 13;
    [Header("恒定移动速度")]public float ConstantSpeed = 10;
    [Header("跳跃速度")]public float JumpSpeed = 5;
    [Header("射线检测层")]public LayerMask layerMask;
    [Header("射线检测长度")]public int Distance = 2;

    private Rigidbody _playerRigidbody;
    private Transform _playerTransform;
    private PlayerStatus playerStatus = PlayerStatus.isRoad;
    private bool isGround;
    private bool isJump;

    enum PlayerStatus
    {
        isRoad,
        isAir
    }

    void Awake()
    {
        if (_playerTransform == null)
        {
            _playerTransform = GameManager.Instance.PlayerGameObject.transform;
        }
        if(_playerRigidbody == null)
        {
            _playerRigidbody = GameManager.Instance.PlayerRigidbody;
        }
    }

    void Update()
    {
        if(_playerTransform == null) return;
        if(_playerRigidbody == null) return;

        GroundInspection();

        if (Input.GetKeyDown(KeyCode.Space) && isGround && playerStatus == PlayerStatus.isRoad)
        {
            playerStatus = PlayerStatus.isAir;
            isJump = true;
        }
    }

    void FixedUpdate()
    {
        if(_playerRigidbody == null) return;
        if(_playerTransform == null) return;

        float playerMoveX = Input.GetAxis("Horizontal"); 

        switch (playerStatus)
        {
            case PlayerStatus.isRoad:
            _playerRigidbody.velocity = new Vector3(playerMoveX *Speed, _playerRigidbody.velocity.y, ConstantSpeed);
            break;
            case PlayerStatus.isAir:
                _playerRigidbody.velocity = new Vector3(playerMoveX *Speed, JumpSpeed, _playerRigidbody.velocity.z);
                if (!isGround)
                {
                    _playerRigidbody.velocity = new Vector3(playerMoveX *Speed, _playerRigidbody.velocity.y, _playerRigidbody.velocity.z);
                    playerStatus = PlayerStatus.isRoad;
                }
            break;
        }
    }
    private bool GroundInspection()
    {
        if (Physics.Raycast(_playerTransform.position,Vector3.down,out RaycastHit hit,Distance,layerMask))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        return isGround;
    }
}