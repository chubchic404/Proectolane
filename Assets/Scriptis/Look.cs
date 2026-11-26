using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensivity = 0.15f;

    private PlayerMoving input;//Без этого работать не будет!!!
    private float xRotation;

    private void Awake()
    {
        input = new PlayerMoving();//Без этого работать не будет!!!
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        input.PlayerMove.Enable();//Без этого работать не будет!!!
    }
    private void OnDisable()
    {
        input.PlayerMove.Disable();
    }
    private void OnDestroy()
    {
        input.Dispose();
    }
    private void Update()
    {
        Vector2 lookInput = input.PlayerMove.look.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensivity;
        float mouseY = lookInput.y * mouseSensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
