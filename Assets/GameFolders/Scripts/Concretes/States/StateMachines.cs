using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstract.States;
using UdemyProject3.States;

public class StateMachines 
{
    List<StateTransformer> _stateTransformers = new List<StateTransformer>();
    List<StateTransformer> _anyStateTransformers = new List<StateTransformer>();

    IState _currentState;

    public void SetState(IState state)
    {
        if(_currentState == state) return;

        // if(_currentState != null) { _currentState.OnExit(); }  -> alttaki kodlamanın uzun yazılımı
        _currentState?.OnExit();

        _currentState = state;

        _currentState.OnEnter();

    }

    //TODO
    // Tick içerisinde state değişimleri kontrol edilecek metodu ya da algoritma yazılacak
    public void Tick()
    {
        StateTransformer stateTransformer = CheckForTransformer();

        if(stateTransformer != null)
        {
            SetState(stateTransformer.To);
        }

        _currentState.Tick();
    }

    private StateTransformer CheckForTransformer()
    {
        foreach (StateTransformer anyStateTransformer in _anyStateTransformers)
        {
            if(anyStateTransformer.Condition.Invoke()) return anyStateTransformer;
        }

        foreach (StateTransformer stateTransformer in _stateTransformers)
        {
            if(stateTransformer.Condition.Invoke() && _currentState == stateTransformer.From) return stateTransformer;
        }


        return null;
    }

    public void AddState(IState from, IState to, System.Func<bool> condition)
    {
        StateTransformer stateTransformer = new StateTransformer(from, to, condition);
        _stateTransformers.Add(stateTransformer);
    }

    public void AddAnyState(IState to, System.Func<bool> condition)
    {
        StateTransformer stateTransformer = new StateTransformer(null, to, condition);
        _stateTransformers.Add(stateTransformer);
    }
}
