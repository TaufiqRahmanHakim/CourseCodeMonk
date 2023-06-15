using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) { 
                //hanya menerima object yang ada di plate saja
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
