using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; 

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private GameObject gameClearText;

    private float bulletDuration = 2f;

    public bool isAlive = true;
    public bool isDead = false;
    public bool isClear = false;

    [SerializeField] private GameObject bulletPrefab;

    private Vector3 moveDirection;

    private const float dashMultiplier = 2;

    public bool isDash = false;

    private RectTransform rectTransform;


    private void Start() 
{
    rectTransform = gameClearText.GetComponent<RectTransform>();

    rectTransform.DOLocalMoveY(20f, 0.4f)
    .SetRelative(true)
    .SetEase(Ease.OutQuad)
    .SetLoops(-1, LoopType.Yoyo)
    .SetUpdate(true); 
}


    void Update()
    {
        if (isAlive)
        {
            PlayerMove();
            CheckIfDash();
            OnAttack();
        }
        else
        {
            OnDead();
            OnClear();
            Time.timeScale = 0;
        }
    }

    void PlayerMove()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

    if (horizontalInput > 0)
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }
    else if (horizontalInput < 0)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    float currentSpeed = isDash ? moveSpeed * dashMultiplier : moveSpeed;

    transform.position += moveDirection * currentSpeed * Time.deltaTime;
}


    private void OnDead()
    {
        if(isDead)
        {
            gameOverUI.SetActive(true);
        }
    }

    private void OnClear()
    {
        if(isClear)
        {
            gameClearUI.SetActive(true);
        }
    }

    void CheckIfDash()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isDash = true;
        }
        else
        {
            isDash = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "ClearSurface")
        {
            isAlive = false;
            isClear = true;
        }
    }

    private void OnAttack()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject genBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Destroy(genBullet, bulletDuration);
        }
    }
}

