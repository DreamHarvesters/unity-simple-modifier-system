using System;
using DH.ModifierSystem;
using UnityEngine;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "Demo2/Create Character Data", order = 1)]
    public class CharacterData : ScriptableObject
    {
        [Serializable]
        public struct SkillData
        {
            [SerializeField] private string name;
            [SerializeField] private float cooldown;
            [SerializeField] private ModifierData[] modifiers;

            public string Name
            {
                get { return name; }
            }

            public float Cooldown
            {
                get { return cooldown; }
            }

            public ModifierData[] Modifiers
            {
                get { return modifiers; }
            }
        }

        [SerializeField] private SkillData[] skills;

        public SkillData[] Skills
        {
            get { return skills; }
        }
        
        private Color characterColor;
        private float rotationSpeed;
    
        public Action<Color> OnColorChanged;
        public Action<float> OnRotationSpeedChanged;
    
        public Color CharacterColor
        {
            get
            {
                return characterColor;
            }
    
            set
            {
                characterColor = value;
    
                if (OnColorChanged != null)
                    OnColorChanged(characterColor);
            }
        }
    
        public float RotationSpeed
        {
            get
            {
                return rotationSpeed;
            }
    
            set
            {
                rotationSpeed = value;
    
                if (OnRotationSpeedChanged != null)
                    OnRotationSpeedChanged(rotationSpeed);
            }
        }
    }
}