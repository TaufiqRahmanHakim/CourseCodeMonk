using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    private IKitchenObjectPerent kitchenObjectPerent;



    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetKitchenObjectPerent(IKitchenObjectPerent kitchenObjectPerent)
    {
        if(this.kitchenObjectPerent != null)
        {
            this.kitchenObjectPerent.ClearKitchenObject();
        }
        if (kitchenObjectPerent.HasKitchenObject())
        {
            Debug.Log("IkitchenObjectPerent Already has a KitchenObject!");
        }

        this.kitchenObjectPerent = kitchenObjectPerent;
        kitchenObjectPerent.SetKitchenObject(this);

        transform.parent = kitchenObjectPerent.GetKitchenObjectFollowTranform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectPerent GetKitchenObjectPerent()
    {
        return kitchenObjectPerent;
    }

    public void DestroySelf()
    {
        kitchenObjectPerent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectPerent kitchenObjectPerent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectPerent(kitchenObjectPerent);
        return kitchenObject;
    }
    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if(this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject = null;
            return false;
        }
    }
}
