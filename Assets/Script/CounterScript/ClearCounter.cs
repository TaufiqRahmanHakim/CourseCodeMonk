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
            if (player.HasKitchenObject())//player membawa sesuatu
            {
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //player memegang object plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();

                    }
                }
                else
                {
                    //player membawa sesuatu tetapi bukan plate
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //ada plate di counter
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }

            }
            else//player tidak membawa sesuatu
            {
                GetKitchenObject().SetKitchenObjectPerent(player);
                //memindahkan perent ke player
            }
        }
    }

    
}
