using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    [SerializeField] Key forwardKey;
    [SerializeField] Key backwardKey; 
    [SerializeField] Key leftKey; 
    [SerializeField] Key rightKey;

    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveDirection;

        moveDirection = CalculateMoveDirection();

        transform.position = transform.position + moveDirection * movementSpeed * Time.deltaTime;


        if (moveDirection.sqrMagnitude != 0)
        {
           LookAt(moveDirection);
        }
    }
    void LookAt(Vector3 lookDirection)
    {
        Quaternion targetRotation;
        Quaternion newRotation;

        targetRotation = Quaternion.LookRotation(lookDirection);

        newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = newRotation;
    }
    Vector3 CalculateMoveDirection()
    {
        Vector3 moveVector;
        Vector3 moveNormalized;
        moveVector = new Vector3(0,0,0);

        Vector3 rotationVector;
        rotationVector = new Vector3(0, 0, 0);


        if (Keyboard.current[forwardKey].isPressed)
        {
            moveVector.z = moveVector.z + 1;
        }
        if (Keyboard.current[backwardKey].isPressed)
        {
            moveVector.z = moveVector.z - 1;
        }
        if (Keyboard.current[leftKey].isPressed)
        {
            moveVector.x = moveVector.z - 1;
            rotationVector.y = rotationVector.y + 1;
        }
        if (Keyboard.current[rightKey].isPressed)
        {
            moveVector.x = moveVector.z + 1;
            rotationVector.y = rotationVector.y - 1;
        }


        moveNormalized = moveVector.normalized;

        return moveNormalized;
    }
}
