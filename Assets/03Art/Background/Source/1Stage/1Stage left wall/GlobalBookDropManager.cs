using UnityEngine;
using System.Collections.Generic;

public class GlobalBookDropManager : MonoBehaviour
{
    public int dropCountMin = 1;
    public int dropCountMax = 2;

    void Start()
    {
        BookDrop[] allBooks = FindObjectsOfType<BookDrop>();
        List<BookDrop> bookList = new List<BookDrop>(allBooks);

        if (bookList.Count == 0) return;

        // ·£´ý 1~2°³ ¼±ÅÃ
        int dropCount = Random.Range(dropCountMin, dropCountMax + 1);
        ShuffleList(bookList);

        for (int i = 0; i < dropCount && i < bookList.Count; i++)
        {
            bookList[i].Drop();
        }
    }

    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int rand = Random.Range(i, list.Count);
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}