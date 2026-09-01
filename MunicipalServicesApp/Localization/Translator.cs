using System.Collections.Generic;

namespace MunicipalServicesApp.Localization
{
    public enum AppLanguage
    {
        English,
        isiZulu,
        Afrikaans
    }

    /// <summary>
    /// A small, dependency-free multilingual text provider for the app's
    /// static UI strings (labels, buttons, headers). This exists to make
    /// the application more accessible to South African users who are more
    /// comfortable in isiZulu or Afrikaans than English, in line with the
    /// "inclusive, low-cost innovation" theme discussed in the Task 1
    /// research (Hart, Booyens & Sinyolo, 2020).
    ///
    /// NOTE: translations below are a best-effort, common-usage rendering
    /// of short UI phrases, not a professional/verified translation. For a
    /// real production deployment these should be reviewed by a fluent
    /// isiZulu/Afrikaans speaker before going live.
    ///
    /// Dynamic message-box text (validation errors, confirmations, the
    /// duplicate-issue prompt) is intentionally left in English for this
    /// version to keep the scope manageable — only persistent on-screen UI
    /// text is translated.
    /// </summary>
    public static class Translator
    {
        public static AppLanguage CurrentLanguage { get; set; } = AppLanguage.English;

        private static readonly Dictionary<string, Dictionary<AppLanguage, string>> Map =
            new Dictionary<string, Dictionary<AppLanguage, string>>
        {
            // --- Main Menu ---
            ["brand"] = Lang("MUNICIPAL SERVICES", "IZINSIZA ZIKAMASIPALA", "MUNISIPALE DIENSTE"),
            ["welcome"] = Lang("Welcome!", "Wamukelekile!", "Welkom!"),
            ["welcomeSub"] = Lang(
                "Report issues, stay informed, and help improve services in your community.",
                "Bika izinkinga, uhlale wazi, futhi usize ukuthuthukisa izinsiza emphakathini wakho.",
                "Rapporteer probleme, bly ingelig, en help om dienste in u gemeenskap te verbeter."),
            ["mainMenuTitle"] = Lang("Main Menu", "Imenyu Enkulu", "Hoofkieslys"),
            ["mainMenuSubtitle"] = Lang(
                "What would you like to do today?",
                "Yini ongathanda ukuyenza namuhla?",
                "Wat wil u vandag doen?"),
            ["btnReportIssues"] = Lang("🛠  Report Issues", "🛠  Bika Izinkinga", "🛠  Rapporteer Kwessies"),
            ["btnLocalEvents"] = Lang(
                "📅  Local Events and Announcements   (coming soon)",
                "📅  Imicimbi Yendawo Nezaziso   (kuzofika maduze)",
                "📅  Plaaslike Gebeure en Aankondigings   (kom binnekort)"),
            ["btnServiceStatus"] = Lang(
                "📄  Service Request Status   (coming soon)",
                "📄  Isimo Sezicelo Zesevisi   (kuzofika maduze)",
                "📄  Diensversoekstatus   (kom binnekort)"),
            ["footer"] = Lang(
                "Only \"Report Issues\" is available in this release. The other services will be enabled in a future update.",
                "\"Bika Izinkinga\" kuphela okutholakalayo kulolu hlelo. Ezinye izinsiza zizovulwa esibuyekezweni esizayo.",
                "Slegs \"Rapporteer Kwessies\" is in hierdie weergawe beskikbaar. Die ander dienste sal in 'n toekomstige opdatering geaktiveer word."),

            // --- Report Issues form ---
            ["reportHeaderTitle"] = Lang("📋  Report an Issue", "📋  Bika Inkinga", "📋  Rapporteer 'n Probleem"),
            ["reportHeaderSubtitle"] = Lang(
                "Tell us what's wrong — we'll take it from here.",
                "Sitshele ukuthi yini engahambi kahle — sizoyithatha kusukela lapho.",
                "Vertel ons wat verkeerd is — ons neem dit van daar oor."),
            ["btnMyReports"] = Lang("📄 My Reports", "📄 Imibiko Yami", "📄 My Verslae"),
            ["lblLocation"] = Lang("Location of the issue *", "Indawo yenkinga *", "Ligging van die probleem *"),
            ["lblCategory"] = Lang("Category *", "Isigaba *", "Kategorie *"),
            ["lblDescription"] = Lang("Describe the issue *", "Chaza inkinga *", "Beskryf die probleem *"),
            ["btnAttach"] = Lang("📎 Attach Image / Document", "📎 Faka Isithombe / Idokhumenti", "📎 Heg Beeld / Dokument Aan"),
            ["noFileAttached"] = Lang("No file attached", "Alikho ifayela elifakiwe", "Geen lêer aangeheg nie"),
            ["btnSubmit"] = Lang("Submit Report", "Thumela Umbiko", "Dien Verslag In"),
            ["btnBackToMain"] = Lang("← Back to Main Menu", "← Buyela Kumenyu Enkulu", "← Terug na Hoofkieslys"),
            ["engagement0"] = Lang(
                "Let's get started — fill in the details below.",
                "Asiqale — gcwalisa imininingwane engezansi.",
                "Kom ons begin — vul die besonderhede hieronder in."),
            ["engagement25"] = Lang("Nice start! Keep going.", "Isiqalo esihle! Qhubeka.", "Mooi begin! Gaan voort."),
            ["engagement50"] = Lang(
                "Halfway there — you're doing great!",
                "Usuhambele phakathi — wenza kahle!",
                "Halfpad daar — jy vaar goed!"),
            ["engagement75"] = Lang(
                "Almost done — add a photo if you have one.",
                "Sekuseduze — engeza isithombe uma unaso.",
                "Amper klaar — voeg 'n foto by as jy een het."),
            ["engagement100"] = Lang(
                "All set! You're ready to submit your report.",
                "Konke kulungile! Usukulungele ukuthumela umbiko wakho.",
                "Alles gereed! Jy is reg om jou verslag in te dien."),

            // --- My Reported Issues (history) form ---
            ["myIssuesTitle"] = Lang("📄  My Reported Issues", "📄  Imibiko Yami Yezinkinga", "📄  My Aangemelde Kwessies"),
            ["myIssuesSubtitle"] = Lang(
                "Every issue reported this session, with its live status.",
                "Zonke izinkinga ezibikiwe kuleli sikhathi, nesimo sazo samanje.",
                "Elke kwessie wat hierdie sessie aangemeld is, met sy huidige status."),
            ["colReference"] = Lang("Reference", "Inombolo Yereferensi", "Verwysing"),
            ["colCategory"] = Lang("Category", "Isigaba", "Kategorie"),
            ["colLocation"] = Lang("Location", "Indawo", "Ligging"),
            ["colDate"] = Lang("Date Reported", "Usuku Lokubikwa", "Datum Aangemeld"),
            ["colSupporters"] = Lang("Supporters", "Abasekeli", "Ondersteuners"),
            ["colStatus"] = Lang("Status", "Isimo", "Status"),
            ["emptyState"] = Lang(
                "You haven't reported any issues yet. Once you submit a report, it will appear here.",
                "Awukabiki noma yiziphi izinkinga. Uma usuthumele umbiko, uzovela lapha.",
                "U het nog geen kwessies aangemeld nie. Sodra u 'n verslag indien, sal dit hier verskyn."),
            ["statusSubmitted"] = Lang("Submitted", "Kuthunyelwe", "Ingedien"),
            ["statusUnderReview"] = Lang("Under Review", "Kuyabuyekezwa", "Onder Hersiening"),

            // --- Report categories ---
            ["catSanitation"] = Lang("Sanitation", "Ezokuhlanzeka", "Sanitasie"),
            ["catRoads"] = Lang("Roads and Potholes", "Imigwaqo Nezimbotshane", "Paaie en Slaggate"),
            ["catWater"] = Lang("Water and Utilities", "Amanzi Nezinsiza", "Water en Nutsdienste"),
            ["catElectricity"] = Lang("Electricity and Street Lighting", "Ugesi Nokukhanyisa Kwemigwaqo", "Elektrisiteit en Straatverligting"),
            ["catWaste"] = Lang("Waste Management", "Ukuphathwa Kwemfucuza", "Afvalbestuur"),
            ["catSafety"] = Lang("Public Safety", "Ukuphepha Komphakathi", "Openbare Veiligheid"),
            ["catParks"] = Lang("Parks and Recreation", "Amapaki Nezokungcebeleka", "Parke en Ontspanning"),
            ["catOther"] = Lang("Other", "Okunye", "Ander"),
        };

        private static Dictionary<AppLanguage, string> Lang(string en, string zu, string af)
        {
            return new Dictionary<AppLanguage, string>
            {
                [AppLanguage.English] = en,
                [AppLanguage.isiZulu] = zu,
                [AppLanguage.Afrikaans] = af
            };
        }

        /// <summary>Returns the translated text for <paramref name="key"/> in the current language.</summary>
        public static string T(string key)
        {
            if (Map.TryGetValue(key, out var translations))
            {
                if (translations.TryGetValue(CurrentLanguage, out var text))
                {
                    return text;
                }
                return translations[AppLanguage.English];
            }
            return key; // fall back to the raw key so a missing translation is still visible/debuggable
        }

        /// <summary>The eight report categories, translated, in a fixed display order.</summary>
        public static string[] GetCategories()
        {
            return new[]
            {
                T("catSanitation"),
                T("catRoads"),
                T("catWater"),
                T("catElectricity"),
                T("catWaste"),
                T("catSafety"),
                T("catParks"),
                T("catOther")
            };
        }
    }
}
