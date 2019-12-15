using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float max = 0.5f;
    public float min = -2.5f;

    private void Update()
    {
        //moves the saw object back and fourth if it reaches its min or max point
        if (transform.position.x == max)
        {
            StartCoroutine(Move(min, 3, -1));
        }
        if (transform.position.x == min)
        {
            StartCoroutine(Move(max, 3, 1));
        }
    }

    private IEnumerator Move(float target, float time, float RotationDir)
    {
        //coroutine to rotate and translate the saw
        float startRotation = transform.eulerAngles.z;
        float endRotation;
        if (RotationDir > 0)
        {
            endRotation = startRotation + 360.0f;
        }
        else
        {
            endRotation = startRotation - 360.0f;
        }
        
        Vector3 _startPos = transform.position;
        Vector3 _endPos = new Vector3(target, transform.position.y);
        Vector3 _newPos;
        float elapsedTime = 0;
        float anglePerSecond = (10 * RotationDir) / time;

        //loops until time is up, rotating and translating the saw object
        while (elapsedTime / time < 1)
        {
            _newPos = Vector3.Lerp(_startPos, _endPos, (elapsedTime / time));
            transform.position = _newPos;

            float zRotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / time) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);

            yield return new WaitForEndOfFrame();

            elapsedTime += Time.deltaTime;
        }
        transform.position = new Vector3(target, transform.position.y);
    }
}
