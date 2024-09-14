using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Runtime
    PlayerControls pControls;

    [Header("Input Containers")]
    [SerializeField] private float horizontalMovement;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;


    private void Awake() {
        pControls = new PlayerControls();

        // Set up input.
        pControls.Keyboard.Horizontal.performed += ctx => horizontalMovement = ctx.ReadValue<float>();
        pControls.Keyboard.Horizontal.canceled += ctx => horizontalMovement = 0;
    }

    private void Update() {
        transform.Translate(new Vector3(horizontalMovement, 0, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnEnable() {
        pControls.Enable();
    }

    private void OnDisable() {
        pControls.Disable();
    }
}
