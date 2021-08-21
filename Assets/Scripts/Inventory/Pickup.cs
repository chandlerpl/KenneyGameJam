using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Pickup : MonoBehaviour, IInteractable
{
    public void OnInteract(GameObject interactingObj, PlayerInventory inventory)
    {
        Item item = GetComponent<Item>();

        inventory.AddItem(item);

        gameObject.SetActive(false);
    }
}
