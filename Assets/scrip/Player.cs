using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("References")]
    public Transform groundCheck;

    private Rigidbody rb;
    private bool isGrounded;
    private float horizontalInput;
    private bool shouldJump;

    [Header("Delegates Creo")]

    public Action RecoletMoney;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            HandleJump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundCheckRadius,groundLayer);

        MoveCharacter();
    }

    void MoveCharacter()
    {
        Vector3 targetVelocity = new Vector3(horizontalInput * moveSpeed,rb.linearVelocity.y,0f);

        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity,targetVelocity,Time.fixedDeltaTime * 10f);
    }

    void HandleJump()
    {
        shouldJump = true;
        if (shouldJump)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x,jumpForce,rb.linearVelocity.z);
            shouldJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "moneda")
        {
            print("dibu");
            RecoletMoney?.Invoke();

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}