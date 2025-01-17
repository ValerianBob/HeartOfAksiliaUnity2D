using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private BuildingController _buildingController;
    public HealthBarController healthBarUI;

    private Animator animator;

    public GameObject deadBackground;

    public TextMeshProUGUI respawnInText;
    public TextMeshProUGUI buyBackCoastText;

    public Button buyBackButton;

    public GameObject bloodPrefab;
    private GameObject blood;

    private Vector3 movement;
    private Vector3 currentPosition;

    private float moveInputHorizontal;
    private float moveInputVertical;
    private float moveSpeed = 15;

    private int MaxHealth = 100;
    public int currentHealth;

    private int secondsToRespawn = 1;
    private int buyBackCoast = 0;

    private int seconds = 0;

    public bool isPlayerDead = false;

    private void Start()
    {
        _buildingController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<BuildingController>();

        animator = GetComponent<Animator>();

        currentHealth = MaxHealth;
        healthBarUI.SetMaxHealth(MaxHealth);

        buyBackButton.onClick.AddListener(BuyBack);
    }

    private void Update()
    {
        if (!isPlayerDead)
        {
            CharacterMovement();
        }

        currentPosition = transform.position;
        currentPosition.z = -1;
        transform.position = currentPosition;

        if (currentHealth <= 0 && !isPlayerDead && GameOver.Instance.gameOver == false)
        {
            isPlayerDead = true;
            PlayerResult.Instance.CountOfPlayerDead += 1;

            deadBackground.SetActive(true);

            secondsToRespawn += 2;
            buyBackCoast += 50;

            respawnInText.text = "Respawn in : " + secondsToRespawn.ToString();
            buyBackCoastText.text = "Buy Back  : " + buyBackCoast.ToString();

            HideOrShowCharacter();
            blood = Instantiate(bloodPrefab, new Vector3(transform.position.x,transform.position.y, 0), bloodPrefab.transform.rotation);
            SoundsController.Instance.PlayEnemyDeathSound(0);

            StartCoroutine("SecondsCounter");

            NotificationsController.Instance.AddNewMessage("Player dead", "red");
        }

        if (seconds == 0 && isPlayerDead)
        {
            isPlayerDead = false;
            deadBackground.SetActive(false);

            currentHealth = MaxHealth;
            healthBarUI.SetHealth(currentHealth);

            Destroy(blood);
            HideOrShowCharacter();

            StopCoroutine("SecondsCounter");

            NotificationsController.Instance.AddNewMessage("Player Respawned", "green");
            SoundsController.Instance.PlayOtherSounds(2);
        }

        if (GameOver.Instance.gameOver == true)
        {
            deadBackground.SetActive(false);
        }

        CheckOnBuyBack();
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

    public void TakingDamage(int damage)
    {
        currentHealth -= damage;
        healthBarUI.SetHealth(currentHealth);
        SoundsController.Instance.PlayHit(0);
    }

    public void Healing(int hp)
    {
        if (currentHealth < MaxHealth)
        {
            currentHealth += hp;
            healthBarUI.SetHealth(currentHealth);
        }
    }

    private IEnumerator SecondsCounter()
    {
        seconds = secondsToRespawn;

        while (true)
        {
            yield return new WaitForSeconds(1f);
            respawnInText.text = "Respawn in : " + (seconds -= 1).ToString();
        }
    }

    private void HideOrShowCharacter()
    {
        if (isPlayerDead)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void BuyBack()
    {
        if (CrystalsController.Instance.orangeCrystals >= buyBackCoast)
        {
            CrystalsController.Instance.orangeCrystals -= buyBackCoast;

            isPlayerDead = false;
            deadBackground.SetActive(false);

            currentHealth = MaxHealth;
            healthBarUI.SetHealth(currentHealth);

            Destroy(blood);
            HideOrShowCharacter();

            StopCoroutine("SecondsCounter");

            NotificationsController.Instance.AddNewMessage("Player Respawned", "green");
            SoundsController.Instance.PlayOtherSounds(2);
        }
    }

    private void CheckOnBuyBack()
    {
        if (CrystalsController.Instance.orangeCrystals >= buyBackCoast)
        {
            buyBackButton.interactable = true;
        }
        else
        {
            buyBackButton.interactable = false;
        }
    }
}
