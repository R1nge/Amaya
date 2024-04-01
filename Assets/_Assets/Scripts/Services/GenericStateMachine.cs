using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public abstract class GenericStateMachine<T, T1> where T : Enum where T1 : IState
    {
        protected Dictionary<T, T1> States;
        protected T CurrentStateType;
        protected T1 CurrentState;

        public virtual void SwitchState(T stateType)
        {
            if (Equals(CurrentStateType, stateType))
            {
                Debug.LogError($"Trying to switch to the same state {stateType}");
                return;
            }
            
            CurrentState?.Exit();
            CurrentState = States[stateType];
            CurrentStateType = stateType;
            CurrentState.Enter();
        }
    }
}