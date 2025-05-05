using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        InitDataManager();
    }

    [SerializeField] private SchoolRunner dataTable;
    private bool loadData = false;

    private Dictionary<int, EndingData_Entity> endingDataDictionary = new Dictionary<int, EndingData_Entity>();
    public bool GetEndingData(int id, out EndingData_Entity endingData)
    {
        return endingDataDictionary.TryGetValue(id, out endingData);
    }
    public void InitDataManager()
    {
        if (!loadData)
        {
            loadData = true;

            for (int i = 0; i < dataTable.EndingData.Count; i++)
            {
                endingDataDictionary.Add(dataTable.EndingData[i].EndingID, dataTable.EndingData[i]);
            }
        }
    }
    public Dictionary<int, EndingData_Entity> GetAllEndingData()
    {
        return endingDataDictionary;
    }
} 
