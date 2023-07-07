using UnityEngine;

[System.Serializable]
public class ItemModel
{
    public ItemModelSO itemModelSO;
    public float itemState;
    public ItemView itemView;

    public ItemModel(ItemModelSO itemModelSO)
    {
        this.itemModelSO = itemModelSO;
    }
    
    public string Serialize()
    {
        return JsonUtility.ToJson(this);
    }

    public static ItemModel Deserialize(string json)
    {
        return JsonUtility.FromJson<ItemModel>(json);
    }

}

[CreateAssetMenu]
public class ItemModelSO : ScriptableObject
{
    public string itemName;
    public Vector2Int itemSize;
    public GameObject prefab;
}
