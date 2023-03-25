using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Item))]
public class Pickup : MonoBehaviour, IInteractable
{
    public AudioSource source;
    public GameObject renderItem;
    public MinimapItem minimapReference;

    public void OnInteract(GameObject interactingObj, PlayerInventory inventory)
    {
        Item item = GetComponent<Item>();

        inventory.AddItem(item);

        if(minimapReference != null) {
            minimapReference.Manage();
        }
        if (renderItem != null) {
            renderItem.SetActive(false);
            GetComponent<Collider>().enabled = false;
        } else {
            gameObject.SetActive(false);
        }

        if (source != null)
        {
            source.Play();
        }
    }
}
