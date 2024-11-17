using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float moveInputHorizontal;
    private float moveInputVertical;
    public float moveSpeed;

    private Vector3 movement;
    private Vector3 currentPosition;

    private void Update()
    {
        CharacterMovement();

        currentPosition = transform.position;
        currentPosition.z = -1;
        transform.position = currentPosition;
    }

    private void CharacterMovement()
    {
        moveInputHorizontal = Input.GetAxis("Horizontal");
        moveInputVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveInputHorizontal, moveInputVertical, -1).normalized * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
