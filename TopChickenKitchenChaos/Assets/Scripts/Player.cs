using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private bool isWalking;
    private void Update()
    {
        Vector2 inputVectorTwo = _gameInput.GetMovementVectorNormalized();

        //transform.position += inputVector;

        //transform.position += (Vector3)inputVector;

        Vector3 moveDirection = new Vector3(inputVectorTwo.x, 0f, inputVectorTwo.y);
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;

        isWalking = moveDirection != Vector3.zero;

        //transform.rotation
        //transform.eulerAngles
        //transform.LookAt
        //transform.up
        //transform.right useful for 2D Game
        //transform.forward = moveDirection;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
