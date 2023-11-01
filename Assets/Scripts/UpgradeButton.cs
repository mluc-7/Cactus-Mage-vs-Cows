using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image icon;

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
