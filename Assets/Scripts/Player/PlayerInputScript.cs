using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    InputSystem_Actions playerInputs;

    public event Action ReversePressed;
    public event Action PausePressed;
    //public event Action MutePressed;
    // public static Action YesPressed;
    // public static Action NoPressed;
    // public static Vector2 Volume;

    void Awake()
    {
        playerInputs= new InputSystem_Actions();
    }

    void OnEnable()
    {
        playerInputs.Enable();

        playerInputs.Player.Reverse.performed += OnReverse;
        playerInputs.Player.Pause.performed += OnPause;
        //playerInputs.Player.Mute.performed += OnMute;
        // playerInputs.Player.Volume.performed += OnVolume;
        // playerInputs.Player.Yes.performed += OnYes;
        // playerInputs.Player.No.performed += OnNo;

    }

    void OnDisable()
    {
        playerInputs.Player.Reverse.performed -=OnReverse;
        playerInputs.Player.Pause.performed -= OnPause;
        //playerInputs.Player.Mute.performed -= OnMute;
        // playerInputs.Player.Volume.performed -= OnVolume;
        // playerInputs.Player.Yes.performed -= OnYes;
        // playerInputs.Player.No.performed -= OnNo;

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

    // void OnMute(InputAction.CallbackContext ctx)
    // {
    //     MutePressed?.Invoke();
    // }

    // void OnVolume(InputAction.CallbackContext ctx)
    // {
    //     Volume = ctx.ReadValue<Vector2>();
    // }

    // void OnYes(InputAction.CallbackContext ctx)
    // {
    //     YesPressed?.Invoke();
    // }

    // void OnNo(InputAction.CallbackContext ctx)
    // {
    //     NoPressed?.Invoke();
    // }
}
