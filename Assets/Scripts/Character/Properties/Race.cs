using DSA.Character.Value;
using UnityEngine;
using UnityEngine.Localization;

namespace DSA.Character
{
    [CreateAssetMenu(fileName = "Race", menuName = "Character/Race")]
    public class Race : ScriptableObject
    {
        public LocalizedString Name;

        public RaceID ID;

        public int LifePointBase;
        public int SpiritBase;
        public int ToughnessBase;
        public int MovementBase;

        //All have to be true
        public RaceAttributeCreationModifier[] AndModification;

        //At least one has to be true
        public RaceAttributeCreationModifier[] OrModification;

        [System.Serializable]
        public struct RaceAttributeCreationModifier
        {
            public MainAttributeType AttributeType;
            public int Modifier;
        }
    }
}

