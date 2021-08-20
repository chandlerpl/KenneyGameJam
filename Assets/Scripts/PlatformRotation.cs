using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformRotation : MonoBehaviour
{
    public Vector3 rotationOffset = new Vector3(0, 45, 0);
    public float rotationFrequency = 30;
    public float rotationDuration = 5;

    Quaternion _rotationOffset;
    Quaternion _nextRotation;
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rotationOffset = Quaternion.Euler(rotationOffset);
        _nextRotation = _rotationOffset;
        StartCoroutine(RotatePlatform());

        _rigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator RotatePlatform()
    {
        while (true)
        {
            yield return new WaitForSeconds(rotationFrequency);

            float time = 0;
            Quaternion startRot = transform.rotation;
            while (time < 1)
            {
                time += Time.deltaTime / rotationDuration;

                _rigidbody.MoveRotation(Quaternion.Lerp(startRot, _nextRotation, time));

                yield return null;
            }
            _nextRotation *= _rotationOffset;
        }
    }
}
