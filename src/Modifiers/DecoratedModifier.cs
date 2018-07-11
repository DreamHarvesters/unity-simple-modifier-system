using UnityEngine;
using System.Collections;

namespace DH.ModifierSystem
{
    public class DecoratedModifier<ModifiableType> : Modifier<ModifiableType> where ModifiableType : IModifiable
    {
        protected Modifier<ModifiableType> originalModifier;
        public Modifier<ModifiableType> OrginalModifier
        {
            get { return originalModifier; }
        }

        public DecoratedModifier(Modifier<ModifiableType> originalModifier)
        {
            this.originalModifier = originalModifier;
        }

        public override void Modify(ModifiableType modifiable)
        {
            originalModifier.Modify(modifiable);
        }

        public override void Revert(ModifiableType modifiable)
        {
            originalModifier.Revert(modifiable);
            
            modifiable.OnModificationReverted(this);
        }
    }
}
