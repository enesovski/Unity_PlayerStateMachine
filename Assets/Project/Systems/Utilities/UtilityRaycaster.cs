using UnityEngine;

namespace Solivagant.Utility
{
    public class UtilityRaycaster : MonoBehaviour
    {
        private const float RAYCAST_RANGE = 50;
        private static Camera cam;

        public static void Setup(Camera _cam)
        {
            cam = _cam;
        }

        public static bool GetMouseWorldHit(out RaycastHit hitInfo, LayerMask mask)
        {
            if (cam == null)
            {
                Debug.LogWarning("UtilityRaycaster: Camera is not set. Call Setup() first.");
                hitInfo = default;
                return false;
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, RAYCAST_RANGE, mask))
            {
                return true;
            }

            hitInfo = default;
            return false;
        }


    }


}
