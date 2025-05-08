using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidController : FishClass
{
    private float verticalSpeed = 2f;
    private float downTime;
    private float horizontalSpeed = 3f;
    private int horizontalDirection;

    private Vector3 startPosition;
    private float timer = 0f;
    
    void Start()
    {
        hp = 10;
        maxHp = hp;
        fishType = FishType.Squid;
        startPosition = transform.position;

        downTime = Random.Range(2, 4);
        horizontalDirection = Random.Range(0, 2) == 0 ? -1 : 1;
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
            transform.position += new Vector3(horizontalDirection * horizontalSpeed * Time.deltaTime, verticalSpeed * 5f * Time.deltaTime, 0);

            if (transform.position.y >= startPosition.y)
            {
                transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);

                timer = 0f;
                downTime = Random.Range(2, 4);
                
                horizontalDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            }
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
