using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace DSA.Character.Effect
{
    public class EffectInfo : MonoBehaviour
    {
        public readonly LocalizedString Name;
        public readonly LocalizedString Description;
        public readonly int ValueChange;

        public EffectInfo(LocalizedString name, LocalizedString description, int valueChange)
        {
            this.Name = name;
            this.Description = description;
            this.ValueChange = valueChange;
        }
    }
}

