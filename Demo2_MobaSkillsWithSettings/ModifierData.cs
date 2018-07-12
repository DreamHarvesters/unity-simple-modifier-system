using System;
using UnityEngine;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    [CreateAssetMenu(fileName = "Modifier", menuName = "Demo2/Create Modifier", order = 0)]
    public class ModifierData : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private float duration;

        private Modifier<Character> modifierInstance;

        public string Name
        {
            get { return name; }
        }

        public float Duration
        {
            get { return duration; }
        }

        public bool IsAlive
        {
            get { return duration > 0; }
        }

        public Modifier<Character> ModifierInstance
        {
            get
            {
                if (modifierInstance == null)
                {
                    Modifier<Character> simpleModifier = Activator.CreateInstance(Type.GetType(Name)) as Modifier<Character>;

                    if (!IsAlive)
                        modifierInstance = simpleModifier;
                    else
                    {
                        modifierInstance = new AliveModifier<Character>(simpleModifier, duration);
                    }
                }

                return modifierInstance;
            }
        }
    }
}