using System;

namespace DH.ModifierSystem
{
    public interface ITimer : IDisposable
    {
        Action Elapsed { get; set; }

        void Start(float duration);
        void Stop();
    }
}