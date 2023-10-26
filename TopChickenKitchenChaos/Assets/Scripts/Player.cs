using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7f;
<<<<<<< HEAD

    private bool isWalking;
=======
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private bool isWalking;
>>>>>>> JindoBranch
    private void Update()
    {
        Vector2 inputVectorTwo = _gameInput.GetMovementVectorNormalized();

        //transform.position += inputVector;

        //transform.position += (Vector3)inputVector;

        Vector3 moveDirection = new Vector3(inputVectorTwo.x, 0f, inputVectorTwo.y);

        float moveDistance = _moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);

        if (!canMove)
        {
            // Cannot move towards moveDirection

            // Attemp only X movement
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDirection = moveDirectionX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionZ, moveDistance);
                if (canMove)
                {
                    // Can move only on the Z
                    moveDirection = moveDirectionZ;
                }
                else
                {
                    // Cannot move in any direction
                }
            }

        }
        else if (canMove)
        {
            transform.position += moveDirection * moveDistance;

        }
        isWalking = moveDirection != Vector3.zero;

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

    public bool IsWalking()
    {
        return isWalking;
    }
}
