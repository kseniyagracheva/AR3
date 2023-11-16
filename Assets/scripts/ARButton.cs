using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ARButton : MonoBehaviour
{
    /*public event Action OnButtonClicked;
    [SerializeField] private TextMeshPro name;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private Interactable interactable;
*/
    [SerializeField] private Transform spawn;
    [SerializeField] private GameLogic gameLogic;
    


    private void Start()
    {
        
        GetComponent<Interactable>().OnClick.AddListener(MakeMove); ///привязали метод MakeMove к событию нажатия кнопки
    }

    public void MakeMove()
    {
        Instantiate(gameLogic.GetPrefab(), spawn);
        gameLogic.SwitchTurn();

    }

}
