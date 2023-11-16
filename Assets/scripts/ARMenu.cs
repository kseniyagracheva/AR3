using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ARMenu : MonoBehaviour
{
    [SerializeField] public List<ARButton> ButtonList= new();
    [SerializeField] private GridObjectCollection gridObjectCollection;
    private int[] Moves = new int[9];
    [SerializeField] private GameLogic gameLogic;
    [SerializeField] private TextMeshPro Text;



    private void Start()
    {
        foreach (var button in ButtonList)
        {
            button.GetComponent<Interactable>().OnClick.AddListener(() => StartCoroutine(DestroyButton(button))); /// на событие клика мы вызываем метод Destroy и передаем туда кнопку
        }
    }
    private IEnumerator DestroyButton(ARButton arbutton)
    {
        int index = ButtonList.IndexOf(arbutton);
        bool turn = gameLogic.CrossesTurn;
        if (turn)
        {
            Moves[index] = 1;
        }
        else
        {
            Moves[index] = 2;
        }


        ButtonList[index]=null;
        Destroy(arbutton.gameObject);
        yield return new WaitForEndOfFrame();
        GameOver();
        gridObjectCollection.UpdateCollection();
    }
    
    public void GameOver()
    {
        for (int i=1; i<3; i++)
        {
            if (Moves[0]==i && Moves[1]==i && Moves[2] == i)
            {
                UpdateText(i==1);
            }
            if (Moves[3] == i && Moves[4] == i && Moves[5] == i)
            {
                UpdateText(i == 1);
            }
            if (Moves[6] == i && Moves[7] == i && Moves[8] == i)
            {
                UpdateText(i == 1);
            }
            if (Moves[0] == i && Moves[4] == i && Moves[8] == i)
            {
                UpdateText(i == 1);
            }
            if (Moves[2] == i && Moves[4] == i && Moves[6] == i)
            {
                UpdateText(i == 1);
            }
            if (Moves[0] == i && Moves[3] == i && Moves[6] == i)
            {
                UpdateText(i == 1);
            }
            if (Moves[1] == i && Moves[4] == i && Moves[7] == i)
            {
                UpdateText(i == 1);
            }
            if (Moves[2] == i && Moves[5] == i && Moves[8] == i)
            {
                UpdateText(i == 1);
            }
        }
    }

    private void UpdateText(bool isPlayer)
    {
        if (!isPlayer)
        { 
            Text.text = "Вы победили!"; 
        }
        else
        {
            Text.text = "Вы проиграли:(";
        }
        Destroy(gridObjectCollection.gameObject);
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

}
