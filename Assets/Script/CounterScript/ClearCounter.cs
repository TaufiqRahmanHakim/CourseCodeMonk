using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter 
{

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //tidak memiliki object dapur
            if (player.HasKitchenObject())
            {
                //memiliki object dapur
                player.GetKitchenObject().SetKitchenObjectPerent(this);
                //memindahkan perent ke benda ini
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if(player.GetKitchenObject() is PlateKitchenObject)
                {
                    //player memegang object plate
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();

                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectPerent(player);
                //memindahkan perent ke player
            }
        }
    }

    
}
