using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlatformRotation : MonoBehaviour
{
    public Vector3 rotationOffset = new Vector3(0, 45, 0);
    public float startRotation = 90;
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
        yield return new WaitForSeconds(startRotation);

        while (true)
        {
            float remainingTime = rotationFrequency;
            while(remainingTime > 0)
            {
                yield return new WaitForSeconds(1);
                remainingTime--;

                if(inventory.ContainsItem(item))
                {
                    TimeSpan t = TimeSpan.FromSeconds(remainingTime);
                    
                    timeText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
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
