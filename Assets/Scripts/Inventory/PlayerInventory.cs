using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public float interactRange = 5f;
    public GameObject cam;
    public Text tooltipText;

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
    }
}
