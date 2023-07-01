using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    private InputControlPlayer inputControlPlayer;
    private void Awake()
    {
        Instance = this;
        inputControlPlayer = new InputControlPlayer();
        inputControlPlayer.Player.Enable();
        inputControlPlayer.Player.Interact.performed += interact_performed;
        inputControlPlayer.Player.InteractAlternate.performed += InteractAlternate_performed;
        inputControlPlayer.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        inputControlPlayer.Player.Interact.performed -= interact_performed;
        inputControlPlayer.Player.InteractAlternate.performed -= InteractAlternate_performed;
        inputControlPlayer.Player.Pause.performed -= Pause_performed;

        inputControlPlayer.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        //throw new System.NotImplementedException();
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = inputControlPlayer.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

}
