using UnityEngine;
using System.Collections;
using System.Timers;

namespace DH.ModifierSystem
{
    public class AliveModifier<ModifiableType> : DecoratedModifier<ModifiableType>, IAlive where ModifiableType : IModifiable
    {
        private ModifiableType modifiable;
        private float lifetime;
        private ITimerFactory timerFactory;
        private ITimer timer;

        public AliveModifier(Modifier<ModifiableType> originalModifier, ITimerFactory timerFactory, float lifetime) : base(originalModifier)
        {
            this.timerFactory = timerFactory;
            this.lifetime = lifetime;
        }

        void SetupTimer()
        {
            timer = timerFactory.GetTimer();
            
            timer.Start(lifetime);

            timer.Elapsed += Timer_Elapsed;
        }

        void Timer_Elapsed()
        {
            Die();
        }

        void KillTimer()
        {
            timer.Elapsed -= Timer_Elapsed;
            timer.Stop();
            timer.Dispose();
        }

        public override void Modify(ModifiableType modifiable)
        {
            originalModifier.Modify(modifiable);

            SetupTimer();

            this.modifiable = modifiable;
            
            modifiable.OnModificationApplied(this);
        }

        public float Lifetime { get { return lifetime; } }

        public void Born(){}
        public void Live(){}
        public void Die()
        {
            KillTimer();

            OnDead();
        }

        public void Reset()
        {
            KillTimer();

            SetupTimer();
        }

        public void OnDead()
        {
            Revert(modifiable);
        }
    }
}
