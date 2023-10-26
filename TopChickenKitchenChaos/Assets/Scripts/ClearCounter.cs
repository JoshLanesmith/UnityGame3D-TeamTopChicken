using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    // Reference
    [SerializeField] private KitchenObjectSO kitchenObjectSO; 
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    // REMOVE WHEN PUSHING PLAYER PICKUP LESSON
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    // REMOVE WHEN PUSHING PLAYER PICKUP LESSON
    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }

        }
    }

    // SET PLAYER TO IMPLEMENT IKitchenObjectParent and pass player as perameter
    public void Interact(Player player)
    {
        //Debug.Log("Interact!");
        //Transform and locate in the top of the table
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
        else
        {
            //UNCOMMENT BELOW AFTER MAKING PLAYER A CHILD OF INTERFACE
            //kitchenObject.SetKitchenObjectParent();
        }
       

        // Show interacted and respond kitchenObject
        //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
        //the type we resopond accoring to prefabs
    }

    public Transform GetKitchenObjectFollowTransform() 
    {
        return counterTopPoint;
    }
    // Modifying position
    // To set changing SO into changed table and previous table make empty 
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() 
    { 
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    // method for checking whether counter has no kitchenObject
    public bool HasKitchenObject() {
        return kitchenObject != null;
    }

}
