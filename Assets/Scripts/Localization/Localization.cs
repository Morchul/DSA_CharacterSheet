using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

public class Localization : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable localizedStringTable;

    private StringTable currentStringTable;

    public static Localization Instance => instance;
    private static Localization instance;

    public static LocalizedString BaseCalculationName;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            LoadTable();
            SetupStaticLocalizedStrings();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void SetupStaticLocalizedStrings()
    {
        BaseCalculationName = GetLocalizedString("base_calculation_name");
    }

    private void LoadTable()
    {
        currentStringTable = localizedStringTable.GetTable();
    }

    public string GetText(string key)
    {
        return currentStringTable[key].LocalizedValue;
    }

    public LocalizedString GetLocalizedString(string key)
    {
        return new LocalizedString(localizedStringTable.TableReference, key);
    }
}
