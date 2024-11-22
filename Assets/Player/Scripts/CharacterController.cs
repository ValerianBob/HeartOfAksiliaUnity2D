using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private BuildingController _buildingController;

    private float moveInputHorizontal;
    private float moveInputVertical;
    public float moveSpeed;

    private Vector3 movement;
    private Vector3 currentPosition;

    private void Start()
    {
        _buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();
    }

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
