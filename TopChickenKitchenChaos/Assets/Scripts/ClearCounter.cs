using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    // Reference
    [SerializeField] private KitchenObjectSO kitchenObjectSO; 
    [SerializeField] private Transform counterTopPoint; 
    public void Interact()
    {
        Debug.Log("Interact!");
        //Transform and locate in the top of the table
        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint );
        kitchenObjectTransform.localPosition = Vector3.zero;

        // Show interacted and respond kitchenObject
        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
        //the type we resopond accoring to prefabs
    }
}
