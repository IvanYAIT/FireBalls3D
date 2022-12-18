using UnityEngine;

namespace State
{
    public class InitState : AState
    {
        public InitState(StateMachine owner) : base(owner)
        {
        }

        public override void Enter()
        {
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            Time.timeScale = 1;
        }

        public override void Update()
        {
            Time.timeScale = 0;
        }
    }
}