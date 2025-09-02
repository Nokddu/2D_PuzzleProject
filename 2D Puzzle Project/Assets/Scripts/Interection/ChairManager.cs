using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    [SerializeField] private ItemPlaceSpot[] targetSpts;
    [SerializeField] private Chair[] chairs;

    private Vector2[] initialPositions;


    void Start()
    {
        initialPositions = new Vector2[chairs.Length];
        for (int i = 0; i < chairs.Length; i++)
        {
            initialPositions[i] = chairs[i].transform.position;
        }
    }
    public bool CheckChairs()
    {
        for(int i = 0; i < targetSpts.Length; i++)
        {
            if (!targetSpts[i].IsPlaced) return false;
        }
        return true;
    }
    public void ResetChairs()
    {
        for(int i =0; i < chairs.Length; i++)
        {
            chairs[i].transform.position = initialPositions[i];
            chairs[i].ResetState();
        }
    }

    
    void Update()
    {
        
    }
}
