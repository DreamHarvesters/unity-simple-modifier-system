using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Renderer renderer;

        [SerializeField]
        private CharacterData data;
        private Character character;

        private Skill[] skills;

        void Start()
        {
            //AliveModifier uses System.Timer which creates a different thread
            //Unity functions can only be accessed/modified in main thread
            //This is why a dispatcher must be used in observable approach
            //data.OnColorChanged += (Color obj) => renderer.material.color = obj;
            
            character = new Character(data);
        }

        void Update()
        {
            transform.Rotate(Vector3.up * data.RotationSpeed, Space.World);
            renderer.material.color = data.CharacterColor;
        }

        public void ActivateSkill(int skillId)
        {
            character.ActivateSkill(skillId, character);
        }
    }
}
