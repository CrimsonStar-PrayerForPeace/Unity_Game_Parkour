using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(int.MinValue)]
public class GameManager : SingletonForManager<GameManager>
{
    public GameObject PlayerGameObject{get;private set;}
    public Rigidbody PlayerRigidbody{get;private set;}

    protected override void ManagerAwake()
    {
        if(PlayerGameObject == null)
        {
            PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        }

        if(PlayerGameObject != null && PlayerRigidbody == null)
        {
            PlayerRigidbody = PlayerGameObject.GetComponent<Rigidbody>();
        }
    }
}
