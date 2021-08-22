using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public float interactRange = 5f;
    public GameObject cam;
    public Text tooltipText;
    public Text collectibleText;
    public GameObject map;
    public AudioSource mapSound;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(cam.transform.position, 0.25f, cam.transform.forward, out RaycastHit hit, interactRange, LayerMask.GetMask("Interactable")))
        {
            Tooltip tooltip = hit.collider.GetComponent<Tooltip>();
            if (tooltip != null)
                tooltipText.text = tooltip.tooltip;

            if (Input.GetButtonDown("Interact"))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnInteract(gameObject, this);
                }
            }
        } else
        {
            tooltipText.text = "";
        }

        if(Input.GetButtonDown("Map") && inventory.ContainsKey("map"))
        {
            map.SetActive(!map.activeSelf);
            mapSound.Play();
        }
    }

    public void AddItem(Item item)
    {
        if(inventory.ContainsKey(item.itemIdentifier))
        {
            inventory[item.itemIdentifier] = inventory[item.itemIdentifier] + item.quantity;
        } else
        {
            inventory.Add(item.itemIdentifier, item.quantity);
        }

        if (item.itemIdentifier.Equals("collectible"))
        {
            collectibleText.text = inventory[item.itemIdentifier].ToString();
        }
    }

    public bool ContainsItem(Item item)
    {
        if (!inventory.ContainsKey(item.itemIdentifier))
        {
            return false;
        }
            
        return inventory[item.itemIdentifier] == item.quantity;
    }
}
