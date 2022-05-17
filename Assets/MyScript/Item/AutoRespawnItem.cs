using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRespawnItem : MonoBehaviour
{
    [SerializeField]
    private float m_TimeToRespawnItem;
    private float m_Time;
    [SerializeField]
    private GameObject Item;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Time > 0)
        {
            m_Time -= Time.deltaTime;
            if (m_Time <= 0)
                SpawnNewItem();
        }
    }

    private void SpawnNewItem()
    {
        var go = Instantiate(Item, transform.position, Quaternion.identity);
        if (go.TryGetComponent<ICollecableItem>(out var collectable))
        {
            collectable.AsignOnCollectAction(OnItemCollected);
        }
    }

    private void OnItemCollected()
    {
        m_Time = m_TimeToRespawnItem;
    }
}
