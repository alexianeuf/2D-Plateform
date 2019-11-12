using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // updateCoinDisplay()

    [SerializeField] private Text _coinText;
    [SerializeField] private Text _livesText;

    public void UpdateCoinDisplay(int coinValue)
    {
        _coinText.text = "Coins : " + coinValue;
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives : " + lives;
    }
}
