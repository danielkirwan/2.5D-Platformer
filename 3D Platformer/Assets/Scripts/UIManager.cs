using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _coinsPickedUP;
    public void UpdateCoinDisplay(int coins)
    {
        _coinsPickedUP.text = "Coins: " + coins;
    }
}
