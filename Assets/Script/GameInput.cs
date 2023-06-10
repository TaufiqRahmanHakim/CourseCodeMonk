using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;

    private InputControlPlayer inputControlPlayer;
    private void Awake()
    {
        inputControlPlayer = new InputControlPlayer();
        inputControlPlayer.Player.Enable();
        inputControlPlayer.Player.Interact.performed += interact_performed;
        inputControlPlayer.Player.InteractAlternate.performed += InteractAlternate_performed;
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
