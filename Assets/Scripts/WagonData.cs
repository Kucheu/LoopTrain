using UnityEngine;

[CreateAssetMenu(fileName = "WagonData", menuName = "Kucheu/WagonData")]
public class WagonData : ScriptableObject
{
    [SerializeField]
    private WagonController wagonPrefab;
    [SerializeField]
    private Sprite wagonSprite;
    [SerializeField]
    private string wagonName;

    public WagonController WagonPrefab => wagonPrefab;
    public Sprite WagonSprite => wagonSprite;
    public string WagonName => wagonName;
}
