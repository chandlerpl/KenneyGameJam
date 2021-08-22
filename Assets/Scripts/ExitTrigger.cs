using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Item))]
public class ExitTrigger : MonoBehaviour, IInteractable
{
    public void OnInteract(GameObject interactingObj, PlayerInventory inventory)
    {
        Item item = GetComponent<Item>();

        if(inventory.ContainsItem(item))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(2);
        }
    }
}
