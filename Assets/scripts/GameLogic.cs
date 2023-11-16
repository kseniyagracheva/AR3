using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class GameLogic : MonoBehaviour
{
    public bool CrossesTurn;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject zero;
    [SerializeField] private ARMenu arMenu;
    


    private void Start()
    {
        CrossesTurn = Random.Range(0f, 1f)<0.5f; ///если меньше 0.5, тогда true, иначе false
        
    }

    private void Update()
    {
        if (!CrossesTurn)
        {
            if (arMenu.ButtonList.Count > 0)
            {
                arMenu.ButtonList[Random.Range(0, arMenu.ButtonList.Count)].GetComponent<Interactable>().OnClick?.Invoke();

            }
        }
    }
    /*private IEnumerator EnemyMove()
    {
        while (arMenu.ButtonList.Count > 0)
        {
            if (!CrossesTurn)
            {
                yield return new WaitForSeconds(Random.Range(1f, 4f));
                arMenu.ButtonList[Random.Range(0, arMenu.ButtonList.Count)].MakeMove();
            }
        }
    }*/


    public  void SwitchTurn()
    {
        CrossesTurn = !CrossesTurn;

    }

    public  GameObject GetPrefab()
    {
        if (CrossesTurn)
        {
            return cross;
        }
        else
        {
            return zero;
        }
    }

   
}
