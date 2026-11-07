using UnityEngine;
[CreateAssetMenu(fileName = "ParallaxLayer", menuName = "Data/ParallaxLayer")]
public class ParallaxLayerSo : ScriptableObject
{
    [SerializeField] private Vector2 factor;
    public Vector2 Factor => factor;

}
