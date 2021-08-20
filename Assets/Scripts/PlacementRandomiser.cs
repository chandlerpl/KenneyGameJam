using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementRandomiser : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberToPlace = 1;

    public List<GameObject> availablePlaces;

    // Start is called before the first frame update
    void Start()
    {
        if(availablePlaces.Count >= numberToPlace)
        {
            for(int i = 0; i < numberToPlace; ++i)
            {
                int pos = Random.Range(0, availablePlaces.Count);
                GameObject place = availablePlaces[pos];

                Instantiate(objectPrefab, place.transform);
                availablePlaces.RemoveAt(pos);
            }
        }
    }
}
