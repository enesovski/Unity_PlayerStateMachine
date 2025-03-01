using System.Collections.Generic;
using UnityEngine;

namespace Solivagant.Objects
{

    public class OutlineMaterialManager : MonoBehaviour
    {
        [SerializeField] private List<OutlineMaterial> outlineMaterials;

        public static OutlineMaterialManager instance;
        private void Awake()
        {
            instance = this;
        }

        public void GetOutlineType()
        {

        }
    }

    public enum OutlineType
    {
        Normal,
        Important
    }

    [System.Serializable]
    public struct OutlineMaterial
    {
        public OutlineType outlineType;
        public Material material;
    }

}
