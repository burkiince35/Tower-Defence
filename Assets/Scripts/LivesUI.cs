using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " Lives ";
    }
}
