using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlatformRotation : MonoBehaviour
{
    public Vector3 rotationOffset = new Vector3(0, 45, 0);
    public float rotationFrequency = 30;
    public float rotationDuration = 5;
    public PlayerInventory inventory;
    public Text timeText;
    public GameObject soundEffect;

    Quaternion _rotationOffset;
    Quaternion _nextRotation;
    Rigidbody _rigidbody;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        _rotationOffset = Quaternion.Euler(rotationOffset);
        _nextRotation = _rotationOffset;
        StartCoroutine(RotatePlatform());

        item = GetComponent<Item>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator RotatePlatform()
    {
        while (true)
        {
            float remainingTime = rotationFrequency;
            while(remainingTime > 0)
            {
                yield return new WaitForSeconds(1);
                remainingTime--;

                if(inventory.ContainsItem(item))
                {
                    timeText.text = remainingTime.ToString();
                    timeText.enabled = true;
                }
            }

            float time = 0;
            Quaternion startRot = transform.rotation;
            soundEffect.SetActive(true);
            while (time < 1)
            {
                time += Time.deltaTime / rotationDuration;

                _rigidbody.MoveRotation(Quaternion.Lerp(startRot, _nextRotation, time));

                yield return null;
            }
            soundEffect.SetActive(false);
            _nextRotation *= _rotationOffset;
        }
    }
}
