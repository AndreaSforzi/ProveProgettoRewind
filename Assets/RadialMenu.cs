using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    public static RadialMenu Instance;
    [HideInInspector]public bool opened = false;

    [SerializeField] GameObject entryPrefab;

    [SerializeField] float radius = 300f;

    [SerializeField] List<Image> icons;

    List<RadialMenuEntry> entries;

    RadialMenuEntry selectedEntry;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        entries = new List<RadialMenuEntry>();
    }

    void AddEntry(string pLabel, Image pIcon)
    {
        GameObject entry = Instantiate(entryPrefab, transform);

        RadialMenuEntry rme = entry.GetComponent<RadialMenuEntry>();
        rme.SetLabel(pLabel);
        rme.SetIcon(pIcon);

        entries.Add(rme);
        
        
    }

    public void Open()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            AddEntry("Button" + i.ToString(), icons[i]);
        }
        Rearrange();
        opened = true;
    }

    public void Close()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            Destroy(entries[i].gameObject);
        }
        opened = false;
    }

    void Rearrange()
    {
        float radiansOfSeparations = (Mathf.PI * 2) / entries.Count;

        for (int i = 0; i < entries.Count; i++)
        {
            float x = Mathf.Sin(radiansOfSeparations * i) * radius;
            float y = Mathf.Cos(radiansOfSeparations * i) * radius;

            entries[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0);
        }
    }

    

    
}
