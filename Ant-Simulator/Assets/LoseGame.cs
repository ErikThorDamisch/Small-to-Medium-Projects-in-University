using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseGame : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Ants_Arbeiter.Count == 80)
        {
            GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}