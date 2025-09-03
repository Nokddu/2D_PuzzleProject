using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chap3Clear : BaseChapClear
{
    [SerializeField] private GameObject openBook;
    [SerializeField] private float dropDistance = 0.5f;
    [SerializeField] private float dropSpeed = 2f;

    public override void ClearEvent()
    {
        if(openBook != null)
        {
            StartCoroutine(DropBook());
        }
    }

    private IEnumerator DropBook()
    {
        Vector3 startPos = openBook.transform.position;
        Vector3 endPos = startPos + Vector3.down * dropDistance;

        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime * dropSpeed;
            openBook.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}
