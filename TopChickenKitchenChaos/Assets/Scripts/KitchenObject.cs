using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;
    
    public KitchenObjectSO GetKitchenObjectSO(){
        return kitchenObjectSO; 
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            // make empty
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;

        // check whether counter has kitchenObject or not
        // It can't be execute!! just for error checking
        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a KitchenObject!!");
        }

        // change kitchen object in clearCounter
        clearCounter.SetKitchenObject(this);

        
        // Setting for moving prefab to another counter and make empty for previous counter
        transform.parent = clearCounter.GetKitchenObjectFollowTransform(); 
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
