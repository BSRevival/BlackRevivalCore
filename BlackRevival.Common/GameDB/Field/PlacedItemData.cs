namespace BlackRevival.Common.GameDB.Field;

public class PlacedItemData
{
    public PlacedItemData()
    {
        this.isSorted = false;
        this.entries = new List<PlacedItemData.Entry>();
    }

    public void Add(FieldTypeData fieldTypeData, int count)
    {
        this.entries.Add(new PlacedItemData.Entry(fieldTypeData, count));
    }

    private void Sort()
    {
        if (!this.isSorted)
        {
            this.entries.Sort((PlacedItemData.Entry v1, PlacedItemData.Entry v2) => v2.count - v1.count);
            this.isSorted = true;
        }
    }

    public PlacedItemData.Entry AtIndex(int index)
    {
        this.Sort();
        if (index >= this.entries.Count)
        {
            return null;
        }
        return this.entries[index];
    }

    public PlacedItemData.Entry AtIndexExclude(int index, List<int> excludeFields)
    {
        this.Sort();
        if (index >= this.entries.Count)
        {
            return null;
        }
        int num = 0;
        for (int i = 0; i < this.entries.Count; i++)
        {
            if (!excludeFields.Contains(this.entries[i].fieldTypeCode))
            {
                if (num == index)
                {
                    return this.entries[i];
                }
                num++;
            }
        }
        return null;
    }

    public List<PlacedItemData.Entry> GetExclude(List<int> excludeFields)
    {
        this.Sort();
        List<PlacedItemData.Entry> list = new List<PlacedItemData.Entry>();
        foreach (PlacedItemData.Entry entry in this.entries)
        {
            if (!excludeFields.Contains(entry.fieldTypeCode))
            {
                list.Add(entry);
            }
        }
        return list;
    }

    public int Count
    {
        get
        {
            return this.entries.Count;
        }
    }

    private bool isSorted;

    public List<PlacedItemData.Entry> entries { get; set; } = new List<PlacedItemData.Entry>();

    public class Entry
    {
        public string GetFieldName()
        {
            return LocalizationDB.Instance.FieldName(this.fieldTypeCode);
        }

        public Entry(FieldTypeData fieldTypeData, int count)
        {
            this.fieldTypeData = fieldTypeData;
            this.fieldTypeCode = fieldTypeData.code;
            this.count = count;
        }

        public FieldTypeData fieldTypeData { get; set; }

        public int fieldTypeCode { get; set; }

        public int count { get; set; }
    }
}