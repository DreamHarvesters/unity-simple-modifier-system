using UnityEngine;
using System.Collections;
using System;

namespace DH.ModifierSystem.Demo1_MobalSkills
{
    public class CharacterData
    {
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
