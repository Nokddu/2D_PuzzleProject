using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chap1Clear : BaseChapClear
{
    [SerializeField] GameObject secretObject;

    private void Start()
    {
        if(secretObject != null)
        {
            secretObject.SetActive(false);
        }       
    }

    public override void ClearEvent()
    {
        if(secretObject != null)
        {
            secretObject.SetActive(true);
        }        
    }
}
