using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _coinsPickedUP;
    [SerializeField] Text _lives;
    public void UpdateCoinDisplay(int coins)
    {
        _coinsPickedUP.text = "Coins: " + coins.ToString();
    }

    public void UpdateLivesDisplay( int lives)
    {
        _lives.text = "Lives: " + lives.ToString();
    }
}
