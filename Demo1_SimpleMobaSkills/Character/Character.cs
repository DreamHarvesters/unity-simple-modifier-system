using UnityEngine;
using System.Collections;
using DH.ModifierSystem;

namespace DH.ModifierSystem.Demo1_MobalSkills
{
    public class Character : IModifiable
    {
        private CharacterData data;

        public Character(CharacterData data)
        {
            this.data = data;
        }

        public void SetRotationSpeed(float rotation)
        {
            data.RotationSpeed = rotation;
        }

        public void SetColor(Color newColor)
        {
            data.CharacterColor = newColor;
        }

        public void OnModificationApplied(IModifier modifier)
        {
            Debug.Log(string.Format("Character modification applied: {0} ", modifier.ModifierType.FullName));
        }

        public void OnModificationReverted(IModifier modifier)
        {
            Debug.Log(string.Format("Character modification reverted: {0} ", modifier.ModifierType.FullName));
        }
    }
}
