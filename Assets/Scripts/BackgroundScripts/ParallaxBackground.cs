using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
    public ParallaxCamera parallaxCamera;
    List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();
    List<Vector3> parallaxLayersPositions=new List<Vector3>();
  
    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;
        SetLayers();
    }
  
    void SetLayers()
    {
        parallaxLayers.Clear();
        parallaxLayersPositions.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();
    
            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayersPositions.Add(layer.transform.position);
                parallaxLayers.Add(layer);
            }
        }
    }
    void Move(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
    public void resetLayers(){
        for(int i=0;i<parallaxLayers.Count;i++){
            Vector3 position=parallaxLayers[i].transform.position;
            parallaxLayers[i].transform.position=new Vector3(0,position.y,position.z);
        }
    }
}
