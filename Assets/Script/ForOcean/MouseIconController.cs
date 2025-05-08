using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIconController : MonoBehaviour
{
    [SerializeField] private GameObject targetIcon;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        ShowIcon();
    }

    private void ShowIcon()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        targetIcon.transform.position = worldPosition;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
