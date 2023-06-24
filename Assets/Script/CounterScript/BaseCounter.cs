using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour , IKitchenObjectPerent
{
    public static event EventHandler OnAnyObjectPlacedHere;

    [SerializeField] private Transform counterTopPoint;
    private KitchenObject kitchenObject;


    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter.Interact();");
    }

    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("BaseCounter.InteractAlternate();");
    }


    public Transform GetKitchenObjectFollowTranform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if(kitchenObject != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
