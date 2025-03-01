using System;
using UnityEngine;

namespace Solivagant.Utility
{
    public class UtilityManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            UtilityRaycaster.Setup(mainCamera);
        }

    }

}
