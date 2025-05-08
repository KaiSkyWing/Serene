using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : FishClass
{
    public float moveSpeed = 10f;
    public float turnSpeed = 1f;
    public float waveFrequency = 2f;
    public float waveAmplitude = 3f;

    private const float minDirChangeFreq = 6f;
    private const float maxDirChangeFreq = 8f;


    private Vector3 currentDirection;
    private Vector3 targetDirection;
    private Vector3 initialScale;

    void Start()
    {
        hp = 10;
        maxHp = hp;

        fishType = FishType.ClownFish;
        initialScale = transform.localScale;

        currentDirection = Random.insideUnitCircle;
        targetDirection = currentDirection;
        
        StartCoroutine(ChangeDirectionPeriodically());
    }

    void Update()
    {
        Move();
        FlipFish();
    }

    public override void Move()
    {
        currentDirection = Vector3.Slerp(currentDirection, targetDirection, turnSpeed * Time.deltaTime);
        Vector3 waveMovement = Vector3.up * Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;
        Vector3 newPosition = transform.position + (currentDirection * moveSpeed + waveMovement) * Time.deltaTime;
        newPosition.z = 0;

        transform.position = newPosition;

        float angle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FlipFish()
    {
        if (currentDirection.x < 0)
        {
            transform.localScale = new Vector3(initialScale.x, -initialScale.y, initialScale.z);
        }
        else if (currentDirection.x > 0)
        {
            transform.localScale = initialScale;
        }
    }

    IEnumerator ChangeDirectionPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDirChangeFreq, maxDirChangeFreq));

            targetDirection = Random.insideUnitCircle;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    public override void Capture()
    {
        possesion.CaptureFish(fishType);
    }
}
