using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeCard : MonoBehaviour
{
    private Upgrade upgrade;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void SetUpgrade(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        nameText.text = upgrade.name;
        descriptionText.text = upgrade.description;
    }

    public void OnClick()
    {
        print("Card clicked");
    }
}
