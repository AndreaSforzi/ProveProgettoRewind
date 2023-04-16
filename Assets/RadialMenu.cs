using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    [SerializeField] GameObject entryPrefab;

    [SerializeField] float radius = 300f;

    [SerializeField] List<Image> icons;

    List<RadialMenuEntry> entries;

    private void Start()
    {
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
