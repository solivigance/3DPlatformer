using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float gravity = 1;

    [SerializeField] Transform myCamera;
    [SerializeField] Animator myAnimator;

    CharacterController controller;
    Vector3 movement;
    bool grounded;

    [SerializeField] PlayerStats myStats;

    public GameObject goalObject;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        myStats.InitializeHealth();
    }

    void Update()
    {
        speed = myStats.moveSpeed;
        jumpForce = myStats.jumpForce;
        gravity = myStats.gravity;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (xInput != 0 || yInput != 0)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }

        Vector3 camForward = myCamera.forward;
        Vector3 camRight = myCamera.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelativeMovementVector = yInput * camForward;
        Vector3 rightRelativeMovementVector = xInput * camRight;

        var relativeMovement = (forwardRelativeMovementVector + rightRelativeMovementVector) * speed;

        if (xInput != 0 && yInput != 0)
            transform.forward = relativeMovement;

        relativeMovement.y = movement.y;
        movement = relativeMovement;

        movement.y += gravity * Time.deltaTime;

        if (controller.isGrounded)
            movement.y = 0;

        grounded = Physics.Raycast(transform.position + Vector3.down, Vector3.down, 1);

        myAnimator.SetBool("onGround", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            movement.y = jumpForce;
            myAnimator.SetTrigger("jump");
        }

        controller.Move(movement * Time.deltaTime);

        if (myStats.currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        myStats.currentHealth -= damageAmount;
        Debug.Log("Player Health: " + myStats.currentHealth);

        if (myStats.currentHealth <= 0)
        {
            GameOver();
        }
    }

    [SerializeField]
    void GameOver()
    {
        Debug.Log("Game Over!");
        GameManager.Instance.GameOver();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == goalObject)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("You Win!");
        GameManager.Instance.Victory();
    }
}
