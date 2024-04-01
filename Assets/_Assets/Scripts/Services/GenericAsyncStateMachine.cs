using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public abstract class GenericAsyncStateMachine<T, T1> where T : Enum where T1 : IAsyncState
    {
        protected Dictionary<T, T1> States;
        protected T CurrentStateType;
        protected T1 CurrentState;

        public virtual async UniTask SwitchState(T stateType)
        {
            if (Equals(CurrentStateType, stateType))
            {
                Debug.LogError($"Trying to switch to the same state {stateType}");
                return;
            }

            await CurrentState.Exit();
            CurrentState = States[stateType];
            CurrentStateType = stateType;
            await CurrentState.Enter();
        }
    }
}