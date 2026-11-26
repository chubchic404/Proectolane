using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jampHeight = 1.5f;
    [SerializeField] private float gravity = 9f;

    private CharacterController cc;
    private PlayerMoving input;
    private float verticalVelocity;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        input = new PlayerMoving();

    }
    private void OnDestrose()
    {
        input.Dispose();
    }
    private void OnEnable()
    {
        input.PlayerMove.Enable();
        input.PlayerMove.Jamp.performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (cc.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(2f * gravity* jampHeight);
        }
    }

    private void OnDisable()
    {
        input.PlayerMove.Disable();
        input.PlayerMove.Jamp.performed -= OnJump;
    }
    private void Update()
    {
        if (cc.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }
        Vector2 moveInput = input.PlayerMove.Move.ReadValue<Vector2>();
        Vector3 horizontalMove = transform.right * moveInput.x + transform.forward * moveInput.y;
        horizontalMove = Vector3.ClampMagnitude(horizontalMove, 1f) * speed;

        verticalVelocity -= gravity * Time.deltaTime;

        Vector3 finalVelocite = horizontalMove + Vector3.up * verticalVelocity;

        cc.Move(finalVelocite * Time.deltaTime);

    }
}
