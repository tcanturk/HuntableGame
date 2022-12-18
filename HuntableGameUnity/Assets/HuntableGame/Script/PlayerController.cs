using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    HuntableInputAction inputAction;

    float lookXVal = 0f;
    float lookYVal = 0f;

    float rotX = 0f;
    float rotY = 0f;

    Vector2 movement = Vector2.zero;
    Vector3 targetPos;
    

    void Awake()
    {
        inputAction = new HuntableInputAction();

        inputAction.Player.LookX.performed += context => lookXVal = context.ReadValue<float>();
        inputAction.Player.LookX.canceled += context => lookXVal = 0f;
        inputAction.Player.LookY.performed += context => lookYVal = context.ReadValue<float>();
        inputAction.Player.LookY.canceled += context => lookYVal = 0f;

        inputAction.Player.Move.performed += context => movement = context.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += context => movement = Vector2.zero;

        targetPos = transform.localPosition;

    }

    void Update()
    {
        rotX += lookXVal;
        rotY += lookYVal;
        targetPos += (transform.right * movement.x + transform.forward * movement.y) * Time.deltaTime * speed;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(-rotY, rotX, 0), Time.deltaTime * 10f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * 10f);
    }

    void OnEnable()
    {
        inputAction.Enable();
    }

    void OnDisable()
    {
        inputAction.Disable();
    }
}
