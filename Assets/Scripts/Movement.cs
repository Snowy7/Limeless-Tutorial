using UnityEngine;

/// <summary>
/// Handles player movement including walking, jumping, and gravity.
/// </summary>
public class Movement : MonoBehaviour
{
    #region Serialized Fields

    [Header("References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.81f;
    
    #endregion
    
    #region Private Fields

    private Vector3 m_velocity;
    private bool m_isGrounded;
    
    float m_x;
    float m_z;
    bool m_jump;

    #endregion

    #region Monobehaviour Methods

    private void Start()
    {
        Validate();
    }

    void Update()
    {
        // Handle input, ground check, movement, jump, gravity, and velocity
        HandleInput();
        // Check if the player is grounded
        GroundCheck();
        // Adds to the m_velocity vector based on input
        ApplyMovement();
        // Adds to the m_velocity vector based on jump
        TryJump();
        // Apply gravity to the m_velocity vector
        ApplyGravity();
        // Move the character controller based on the m_velocity vector
        ApplyVelocity();
    }

    #endregion

    # region Private Methods
    /// <summary>
    /// Validates the required components and settings for the movement script.
    /// </summary>
    private void Validate()
    {
        string error = "";
        if (controller == null)
        { 
            error += "[Movement] CharacterController is not assigned in the inspector!\n";
        }
        
        if (groundCheck == null)
        {
            error += "[Movement] GroundCheck Transform is not assigned in the inspector!\n";
        }
        
        if (groundMask == 0)
        {
            error += "[Movement] GroundMask LayerMask is not assigned in the inspector!\n";
        }

        if (!string.IsNullOrEmpty(error))
        {
            Debug.LogError(error);
            enabled = false; // Disable the script if validation fails
        }
    }
    
    /// <summary>
    /// Handles player input for movement and jumping.
    /// </summary>
    private void HandleInput()
    {
        m_x = Input.GetAxis("Horizontal");
        m_z = Input.GetAxis("Vertical");
        m_jump = Input.GetButtonDown("Jump");
    }
    
    /// <summary>
    /// Checks if the player is grounded by using a sphere check.
    /// </summary>
    private void GroundCheck()
    {
        m_isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        if (m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }
    }
    
    /// <summary>
    /// Applies movement into the m_velocity vector based on input.
    /// </summary>
    private void ApplyMovement()
    {
        Vector3 move = transform.right * m_x + transform.forward * m_z;
        
        m_velocity.x = move.x * speed;
        m_velocity.z = move.z * speed;
    }
    
    /// <summary>
    /// Attempts to jump by adding a vertical velocity to the m_velocity vector.
    /// </summary>
    private void TryJump()
    {
        if (m_isGrounded && m_jump)
        {
            m_velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    
    /// <summary>
    /// Applies gravity to the m_velocity vector.
    /// </summary>
    private void ApplyGravity()
    {
        m_velocity.y += gravity * Time.deltaTime;
    }
    
    /// <summary>
    /// Moves the character controller based on the m_velocity vector.
    /// </summary>
    private void ApplyVelocity()
    {
        controller.Move(m_velocity * Time.deltaTime);
    }
    #endregion
}