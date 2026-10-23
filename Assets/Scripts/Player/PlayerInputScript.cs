using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    InputSystem_Actions playerInputs;

    public event Action ReversePressed;
    public event Action PausePressed;

    void Awake()
    {
        playerInputs= new InputSystem_Actions();
    }

    void OnEnable()
    {
        playerInputs.Enable();

        playerInputs.Player.Reverse.performed += OnReverse;
        playerInputs.Player.Pause.performed += OnPause;

    }

    void OnDisable()
    {
        playerInputs.Player.Reverse.performed -=OnReverse;
        playerInputs.Player.Pause.performed -= OnPause;
        playerInputs.Disable();
    }

    void OnReverse(InputAction.CallbackContext ctx)
    {
        //Debug.Log("INPUT: Reverse Performed");
        ReversePressed?.Invoke();
    }

    void OnPause(InputAction.CallbackContext ctx)
    {
        PausePressed?.Invoke();
    }

}
