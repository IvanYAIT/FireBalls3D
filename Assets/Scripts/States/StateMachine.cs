using System;
using System.Collections.Generic;

namespace State
{
    public class StateMachine
    {
        private Dictionary<Type, AState> states;
        private AState currentState;

        public StateMachine(Menus menus, Bullet.BulletView bulletView)
        {
            states = new Dictionary<Type, AState>();
            states.Add(typeof(GameState), new GameState(this, menus, bulletView));
            states.Add(typeof(InitState), new InitState(this));
            states.Add(typeof(LoseState), new LoseState(this, menus));
            states.Add(typeof(WinState), new WinState(this, menus));
            currentState = new InitState(this);
            Core.Game.onGameStart += ChangeState;
            Core.Game.onGameEnd += ChangeState;
        }

        public void ChangeState(Type state)
        {
            currentState.Exit();
            states.TryGetValue(state, out currentState);
            currentState.Enter();
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}