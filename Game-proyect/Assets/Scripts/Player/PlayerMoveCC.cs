using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCC : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 3f;

    private float cameraAxisX = 0f;


    [SerializeField] Animator playerAnimator;

    private Vector3 playerDirection;

    private CharacterController playerCC;

    void Start()
    {
        playerCC = GetComponent<CharacterController>();
    }


    void Update()
    {
        RotatePlayer();
        bool forward = Input.GetKeyDown(KeyCode.W);
        bool back = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool right = Input.GetKeyDown(KeyCode.D);
        if (forward) playerAnimator.SetTrigger("FORWARD");
        if (back) playerAnimator.SetTrigger("BACK");
        if (left) playerAnimator.SetTrigger("LEFT");
        if (right) playerAnimator.SetTrigger("RIGHT");
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (!IsAnimation("IDLE")) playerAnimator.SetTrigger("IDLE");
        }

        if (Input.GetKey(KeyCode.W)) MovePlayer(Vector3.forward);
        if (Input.GetKey(KeyCode.S)) MovePlayer(Vector3.back);
        if (Input.GetKey(KeyCode.D)) MovePlayer(Vector3.right);
        if (Input.GetKey(KeyCode.A)) MovePlayer(Vector3.left);

        if (playerCC.isGrounded)
        {
            playerDirection.y = 0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {

            Debug.Log("JUMP");
            playerCC.Move(Vector3.up * 10f * Time.deltaTime);
        }


        playerDirection.y += -9.81f * Time.deltaTime;
        playerCC.Move(playerDirection * Time.deltaTime);

        if (playerDirection != Vector3.zero) MovePlayer(playerDirection);

    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
        
    }


    private void MovePlayer(Vector3 direction)
    {
        playerCC.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);
    }

    public void RotatePlayer()
    {

        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }
}
