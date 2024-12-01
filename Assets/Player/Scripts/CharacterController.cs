using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private BuildingController _buildingController;
    public HealthBarController healthBarUI;

    private Animator animator;

    private Vector3 movement;
    private Vector3 currentPosition;

    private float moveInputHorizontal;
    private float moveInputVertical;
    public float moveSpeed;

    public int MaxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        _buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();

        animator = GetComponent<Animator>();

        currentHealth = MaxHealth;
        healthBarUI.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        CharacterMovement();

        currentPosition = transform.position;
        currentPosition.z = -1;
        transform.position = currentPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 5;
            healthBarUI.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            GameOver.Instance.gameOver = true;
        }
    }

    private void CharacterMovement()
    {
        moveInputHorizontal = Input.GetAxis("Horizontal");
        moveInputVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveInputHorizontal, moveInputVertical, -1).normalized * moveSpeed * Time.deltaTime;

        if (moveInputHorizontal > 0 || moveInputHorizontal < 0)
        {
            animator.SetFloat("Running", Mathf.Abs(moveInputHorizontal));
        }
        else if (moveInputVertical > 0 || moveInputVertical < 0)
        {
            animator.SetFloat("Running", Mathf.Abs(moveInputVertical));
        }

        transform.Translate(movement);
    }
}
