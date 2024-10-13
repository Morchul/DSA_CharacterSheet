using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

public class Localization : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable characterValueTable;

    private StringTable characterValueStringTable;

    public void LoadTables()
    {
        //Load Localization Table
        characterValueStringTable = characterValueTable.GetTable();
    }

    public string GetCharacterValueText(string key)
    {
        StringTableEntry tableEntry = characterValueStringTable[key];
        if(tableEntry == null)
        {
            Log.Warning($"Localization Key {key} not found!");
            return "-";
        }
        return tableEntry.LocalizedValue;
    }
}
