using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputController _input;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private bool rotateTowardsMouse;

    private void Awake()
    {
        _input = GetComponent<InputController>();
    }

    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        // Move in the direction we are aiming
        var  movementVector = MoveTowardTarget(targetVector);

        if (!rotateTowardsMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        else
        {
            RotateTowardsMouseVector();
        }

        // Rotate in the direction we are traveling
        //RotateTowardTarget(targetVector);
    }


    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition= transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0)
        {
            return;
        }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
    }

    private void RotateTowardsMouseVector()
    {
        Vector3 currentMousePosition = Input.mousePosition;

        Debug.Log(currentMousePosition.x);
        Debug.Log(currentMousePosition.y);
        Debug.Log(currentMousePosition.z);
    }
    //private void RotateTowardTarget(Vector3 targetVector)
    //{
    //    throw new NotImplementedException();
    //}
}
