using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour

{
    public float bulletSpeed = 10f;

    //private  Vector3 mouseWorldPosition;
    private Vector3 targetDirection;


    void Start()
    {
        GetMousePosition();
    }

    void Update()
    {
        Move();
    }

    public void GetMousePosition()
    { 
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        targetDirection = (targetPosition - transform.position).normalized;
        
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Move()
    {
        transform.position += targetDirection * bulletSpeed * Time.deltaTime;
    }
}
