using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class MinimapItem : MonoBehaviour
{
    public bool shouldCross;
    public GameObject crossObject;
    public bool shouldChangeColour;
    public Color changedColour = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Manage() {
        if(shouldCross && crossObject != null) {
            crossObject.SetActive(true);
        }

        if(shouldChangeColour) {
            GetComponent<SpriteRenderer>().color = changedColour;
        }
    }
}
