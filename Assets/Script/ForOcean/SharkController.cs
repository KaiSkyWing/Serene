using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : FishClass
{
    [SerializeField] private OxygenController oxygenController;
    [SerializeField] private Sprite openShark;
    [SerializeField] private Sprite closeShark;
    [SerializeField] private GameObject sharkSprite;
    [SerializeField]private SpriteRenderer sr;
    [SerializeField] private GameObject damagePanel;

    public Transform player;
    private const float detectionRadius = 20f;
    private const float followSpeedMultiplier = 0.9f;
    private const float ShowDuration = 0.3f;
    private PlayerController playerController;
    private bool isPlayerDetected = false;
    private bool isChasing = false;

    private float chaseTime = 4f;
    private float waitTime = 8f;
    private float chaseTimer = 0f;
    private float waitTimer = 0f;

    private Vector3 originalScale;

    void Start()
    {
        hp = 20;
        maxHp = hp;

        fishType = FishType.Shark;

        playerController = player.GetComponent<PlayerController>();
        originalScale = transform.localScale;

        sr = sharkSprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius && waitTimer <= 0f)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }

        if (isPlayerDetected && playerController != null && !isChasing)
        {
            isChasing = true;
            chaseTimer = chaseTime;
        }

        if (isChasing)
        {
            FollowPlayer();
            sr.sprite = openShark;
        }
        else if (waitTimer > 0f)
        {
            sr.sprite = closeShark;
            waitTimer -= Time.deltaTime;
        }
    }

    public override void Capture()
    {
        possesion.CaptureFish(fishType);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            oxygenController.currentOxygen -= 20f;

            damagePanel.SetActive(true);
            StartCoroutine(DeactivateDamagePanel());
        }
    }

    private IEnumerator DeactivateDamagePanel()
    {
        yield return new WaitForSeconds(ShowDuration);

        damagePanel.SetActive(false);
    }

    void FollowPlayer()
    {
        if (chaseTimer > 0f)
        {
            float playerSpeed = playerController.moveSpeed;

            Vector3 direction = (player.position - transform.position).normalized;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }

            transform.position += direction * playerSpeed * followSpeedMultiplier * Time.deltaTime;

            chaseTimer -= Time.deltaTime;
        }
        else
        {
            isChasing = false;

            waitTimer = waitTime;
        }
    }
}
