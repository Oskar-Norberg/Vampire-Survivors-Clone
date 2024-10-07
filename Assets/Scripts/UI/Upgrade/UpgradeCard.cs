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
    
    public delegate void OnClickDelegate(Upgrade upgrade);
    public static event OnClickDelegate onClick;

    public void SetUpgrade(Upgrade newUpgrade)
    {
        this.upgrade = newUpgrade;
        nameText.text = newUpgrade.name;
        descriptionText.text = newUpgrade.description;
    }

    public void OnClick()
    {
        onClick?.Invoke(upgrade);
    }
}
