using UnityEngine;
namespace Solivagant.Objects
{
    public class OutlineObject : MonoBehaviour
    {

        [SerializeField] private Material outlineMaterial;
        private MeshRenderer meshRenderer;
        private Material[] originalMaterials;
        private bool isOutlined = false;

        void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                originalMaterials = meshRenderer.sharedMaterials;
            }
        }

        private void OnMouseEnter()
        {
            ActivateOutline();
        }

        private void OnMouseExit()
        {
            DeactivateOutline();
        }

        public void ActivateOutline()
        {
            if (!isOutlined && meshRenderer != null && outlineMaterial != null)
            {
                int length = originalMaterials.Length;
                Material[] newMaterials = new Material[length + 1];

                for (int i = 0; i < length; i++)
                {
                    newMaterials[i] = originalMaterials[i];
                }
                newMaterials[length] = outlineMaterial;

                meshRenderer.materials = newMaterials;
                isOutlined = true;
            }
        }

        public void DeactivateOutline()
        {
            if (isOutlined && meshRenderer != null)
            {
                meshRenderer.materials = originalMaterials; 
                isOutlined = false;
            }
        }


    }

}
