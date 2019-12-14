using System.Collections;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float max = 0.5f;
    public float min = -2.5f;

    private void Update()
    {
        if (transform.position.y == max)
        {
            StartCoroutine(Move(min, 3));
        }
        if (transform.position.y == min)
        {
            StartCoroutine(Move(max, 3));
        }
    }

    private IEnumerator Move(float target, float time)
    {
        Vector3 _startPos = transform.position;
        Vector3 _endPos = new Vector3(transform.position.x, target);
        Vector3 _newPos;
        float elapsedTime = 0;

        while (elapsedTime / time < 1)
        {
            _newPos = Vector3.Lerp(_startPos, _endPos, (elapsedTime / time));
            transform.position = _newPos;

            yield return new WaitForEndOfFrame();

            elapsedTime += Time.deltaTime;
        }
        transform.position = new Vector3(transform.position.x, target);
    }

}