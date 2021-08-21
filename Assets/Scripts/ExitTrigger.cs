using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class ExitTrigger : MonoBehaviour, IInteractable
{
    public void OnInteract(GameObject interactingObj, PlayerInventory inventory)
    {
        Item item = GetComponent<Item>();

        if(inventory.ContainsItem(item))
        {
            // End game? For now despawning ship to test it's working
            gameObject.SetActive(false);
        }
    }
}
