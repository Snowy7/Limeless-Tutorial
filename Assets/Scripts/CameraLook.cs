using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;
    
    [Header("Camera Settings")]
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] Vector2 xRotationLimit = new Vector2(-90f, 90f);

    private float m_xRotation = 0f;
    private float m_mouseX;
    private float m_mouseY;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandlingInput();
        ApplyCameraRotate();
        ApplyPlayerRotate();
    }
    
    /// <summary>
    ///  Take the input from the mouse axis and multiply it by mouseSensitivity and deltaTime.
    /// </summary>
    void HandlingInput()
    {
        m_mouseX = Input.GetAxis("Mouse X");
        m_mouseY = Input.GetAxis("Mouse Y");
    }
    
    
    /// <summary>
    ///  Apply the rotation for the camera.
    /// </summary>
    void ApplyCameraRotate()
    {
        float x = m_mouseY * mouseSensitivity * Time.deltaTime;
        
        m_xRotation -= x;
        m_xRotation = Mathf.Clamp(m_xRotation, xRotationLimit.x, xRotationLimit.y);
        
        transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
    }
    
    /// <summary>
    ///  Apply the rotation for the player.
    /// </summary>
    void ApplyPlayerRotate()
    {
        float y = m_mouseX * mouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * y);
    }
}