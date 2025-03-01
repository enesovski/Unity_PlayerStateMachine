using UnityEngine;
using Solivagant.Utility;
using Solivagant.Player;
using UnityEngine.InputSystem;
using Solivagant.Interaction;

namespace Solivagant.Actions
{
    public class MouseClickHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask raycastableMasks;

        [Header("Action Initialization")]
        private PlayerStateMachine playerStateMachine;

        private void Start()
        {
            playerStateMachine = FindFirstObjectByType<PlayerStateMachine>();

        }

        private void Update() 
        {
            RaycastHit hit;
            if(UtilityRaycaster.GetMouseWorldHit(out hit, raycastableMasks))
            {
                if(hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {

                }
            }
        }

        public void OnLeftMouseClicked(InputAction.CallbackContext ctx)
        {
            if (ctx.performed && UtilityRaycaster.GetMouseWorldHit(out RaycastHit hit, raycastableMasks))
            {
                playerStateMachine.EnqueueAction(new SurfaceEffectAction(playerStateMachine), hit);
                playerStateMachine.EnqueueAction(new MoveAction(playerStateMachine), hit);
            }
        }

        public void OnRightMouseClicked(InputAction.CallbackContext ctx)
        {
            if (ctx.performed && UtilityRaycaster.GetMouseWorldHit(out RaycastHit hit, raycastableMasks))
            {
                GameObject targetObj = hit.collider.gameObject;
                if(targetObj.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    playerStateMachine.EnqueueAction(new SurfaceEffectAction(playerStateMachine), hit);
                    playerStateMachine.EnqueueAction(new MoveAction(playerStateMachine), hit);
                    playerStateMachine.EnqueueAction(new InteractableAction(playerStateMachine, interactable), hit);
                }
            }
        }
    }

}
