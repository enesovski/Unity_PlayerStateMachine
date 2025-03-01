using Solivagant.Audio;
using UnityEngine;

public class SurfaceObject : MonoBehaviour
{

    [SerializeField] private SurfaceData surfaceData;
    [SerializeField] private FootstepAudioData footstepAudioData;
    
    public void PlayEffectOnPos(Vector3 pos)
    {
        AudioManager.Instance.PlaySound(surfaceData.AudioEffectHash);


    }
}
