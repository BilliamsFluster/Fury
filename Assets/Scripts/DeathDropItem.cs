using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathDropItem : MonoBehaviour
{
    public DropTable dropTable;
    private List<float> denistyArray;
    private float totalWeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        BuildCDA();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildCDA()
    {
        foreach(DropEntry entry in dropTable.drops)
        {
            totalWeight += entry.weight;
            denistyArray.Add(totalWeight);
        }
    }

    public void DropRandomItem()
    {
        GameObject drop = GetRandomItem();
        if(drop != null)
        {
            Instantiate<GameObject>(drop, transform.position, Quaternion.identity);

        }
    }

    public GameObject GetRandomItem()
    {
        float randomNumber = Random.Range(0.0f, totalWeight);
        for(int i = 0; i < denistyArray.Count; i++)
        {
            float weightMarker = denistyArray[i];
            if(randomNumber < weightMarker)
            {
                return dropTable.drops[i].itemToDrop;
            }
        }
        return dropTable.drops[dropTable.drops.Count - 1].itemToDrop; // went through everything then drop the last item
    }
}

[System.Serializable]
public class DropTable 
{
    public List<DropEntry> drops;
}

[System.Serializable]
public class DropEntry
{
    public GameObject itemToDrop;
    public int weight;
}