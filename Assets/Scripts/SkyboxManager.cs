using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public void SetSkybox(Material skyboxMaterial)
    {
        RenderSettings.skybox = skyboxMaterial;
    }
}
