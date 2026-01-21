using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float sensitivity;
    [SerializeField] float sprintSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;


    private float moveFB;
    private float moveLR;
    private float rotX;
    private float rotY;
    private Vector3 jumpVelocity = Vector3.zero;

    private Camera playerCam;
    private CharacterController cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        playerCam = transform.GetChild(0).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float movementSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = speed;
        }

        moveFB = Input.GetAxis("Vertical") * movementSpeed;
        moveLR = Input.GetAxis("Horizontal") * movementSpeed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        rotY -= Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementSpeed;
        transform.Rotate(0, rotX, 0);

        playerCam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        movement = transform.rotation * movement;

        if (cc.isGrounded)
        {
            if (jumpVelocity.y < 0)
            {
                jumpVelocity.y = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jump");
                jumpVelocity.y = jumpForce;
            }
        }

        if (!cc.isGrounded)
        {
            jumpVelocity.y -= gravity * Time.deltaTime;
        }

        cc.Move((movement + jumpVelocity) * Time.deltaTime);
    }
}
