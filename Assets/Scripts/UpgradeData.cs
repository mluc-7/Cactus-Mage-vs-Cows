using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum UpgradeType
    {
        Upgrade
    }

    [CreateAssetMenu]
    public class UpgradeData : ScriptableObject
    {

        public UpgradeType upgradeType;
        public string Name;
        public Sprite icon;
        //public UpgradeEffect upgradeEffect;
    }


