using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JellyfishMovement : FishClass
{
    private float verticalSpeed = 0.5f;
    private float downTime = 4f;

    private Vector3 startPosition;
    private float timer = 0f;

    private const float ShowDuration = 0.3f;

    [SerializeField] private OxygenController oxygenController;
    [SerializeField] private GameObject damagePanel;

    void Start()
    {
        hp = 15;
        maxHp = hp;

        fishType = FishType.JerryFish;

        startPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        timer += Time.deltaTime;

        if (timer < downTime)
        {
            transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(0, verticalSpeed * 5f * Time.deltaTime, 0);

            if (transform.position.y >= startPosition.y)
            {
                transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);

                timer = 0f;
            }
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
            oxygenController.currentOxygen -= 5f;
            damagePanel.SetActive(true);
            StartCoroutine(DeactivateDamagePanel());
        }
    }

    private IEnumerator DeactivateDamagePanel()
    {
        yield return new WaitForSeconds(ShowDuration);

        damagePanel.SetActive(false);
    }
}


