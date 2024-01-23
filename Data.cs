using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Cyclonian.GhBuddy
{
    public enum Galaxies : int
    {
        None = 0,
        Stardust21 = 127
    }

    public enum Planets : int
    {
        None = 0,
        Corellia = 1,
        Dantooine = 2,
        Dathomir = 3,
        Endor = 4,
        Lok = 5,
        Naboo = 6,
        Rori = 7,
        Talus = 8,
        Tatooine = 9,
        Yavin4 = 10,
        DromundKaas = 12,
        Lothal = 17,
        Chandrila = 19,
        Hutta = 20,
        Moraband = 27,
        Florrum = 28
    }

    public enum ResourceStats
    {
        res_cold_resist,
        res_conductivity,
        res_decay_resist,
        res_flavor,
        res_heat_resist,
        res_malleability,
        res_potential_energy,
        res_quality,
        res_shock_resistance,
        res_toughness,
        entangle_resistance
    }

    public enum ResourceStatAbbreviations
    {
        CR,
        CD,
        DR,
        FL,
        HR,
        MA,
        PE,
        OQ,
        SR,
        UT,
        ER
    }

    public class StatItem
    {
        public string Class { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;

        public StatItem(string szClass, string szAbbreviation)
        {
            Class = szClass;
            Abbreviation = szAbbreviation;
        }
    }

    public class ResourceClass
    {
        public string value { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
    }

    public class ResourceEntry
    {
        public Galaxies Galaxy { get; set; } = Galaxies.None;
        public string GalaxyName { get { return Galaxy.ToString(); } }
        public Planets Planet { get; set; } = Planets.None;
        public string PlanetName { get { return Planet.ToString(); } }
        public string Name { get; set; } = string.Empty;
        public ResourceClass Class { get; set; } = new();
        public string ClassName { get { return Class.name; } }
        public int ER { get; set; } = 0;
        public int CR { get; set; } = 0;
        public int CD { get; set; } = 0;
        public int DR { get; set; } = 0;
        public int FL { get; set; } = 0;
        public int HR { get; set; } = 0;
        public int MA { get; set; } = 0;
        public int PE { get; set; } = 0;
        public int OQ { get; set; } = 0;
        public int SR { get; set; } = 0;
        public int UT { get; set; } = 0;
        public bool ExistsOnGh { get; set; } = false;
        public bool RecoveredFromGh { get; set; } = false;
        public int GH_ER { get; set; } = 0;
        public int GH_CR { get; set; } = 0;
        public int GH_CD { get; set; } = 0;
        public int GH_DR { get; set; } = 0;
        public int GH_FL { get; set; } = 0;
        public int GH_HR { get; set; } = 0;
        public int GH_MA { get; set; } = 0;
        public int GH_PE { get; set; } = 0;
        public int GH_OQ { get; set; } = 0;
        public int GH_SR { get; set; } = 0;
        public int GH_UT { get; set; } = 0;

        public bool IsEmpty()
        {
            // check for empty resource (ISD likely returned no data for this one)
            if (ER + CR + CD + DR + FL + HR + MA + PE + OQ + SR + UT == 0)
                return true;
            return false;
        }

        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsError()
        {
            // pre-existing error - send it
            if (!string.IsNullOrWhiteSpace(ErrorMessage))
                return true;

            // check for empty resource (ISD likely returned no data for this one)
            // if GH has it... use those stats!
            if (IsEmpty())
            {
                if (ExistsOnGh)
                {
                    RecoveredFromGh = true;
                    ER = GH_ER;
                    CR = GH_CR;
                    CD = GH_CD;
                    DR = GH_DR;
                    FL = GH_FL;
                    HR = GH_HR;
                    MA = GH_MA;
                    PE = GH_PE;
                    OQ = GH_OQ;
                    SR = GH_SR;
                    UT = GH_UT;

                    if (IsEmpty())
                    {
                        ErrorMessage = string.Format("{0}: Resource has no stats!", Name);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = string.Format("{0}: Resource has no stats!", Name);
                    return true;
                }
            }

            // check for GH mismatches
            if(ExistsOnGh && ER != GH_ER)
                ErrorMessage = string.Format("{0}: Mismatch! Local ER: {1} | GH ER: {2}", Name, ER, GH_ER);
            if (ExistsOnGh && CR != GH_CR)
                ErrorMessage = string.Format("{0}: Mismatch! Local CR: {1} | GH CR: {2}", Name, CR, GH_CR);
            if (ExistsOnGh && CD != GH_CD)
                ErrorMessage = string.Format("{0}: Mismatch! Local CD: {1} | GH CD: {2}", Name, CD, GH_CD);
            if (ExistsOnGh && DR != GH_DR)
                ErrorMessage = string.Format("{0}: Mismatch! Local DR: {1} | GH DR: {2}", Name, DR, GH_DR);
            if (ExistsOnGh && FL != GH_FL)
                ErrorMessage = string.Format("{0}: Mismatch! Local FL: {1} | GH FL: {2}", Name, FL, GH_FL);
            if (ExistsOnGh && HR != GH_HR)
                ErrorMessage = string.Format("{0}: Mismatch! Local HR: {1} | GH CR: {2}", Name, HR, GH_HR);
            if (ExistsOnGh && MA != GH_MA)
                ErrorMessage = string.Format("{0}: Mismatch! Local MA: {1} | GH MA: {2}", Name, MA, GH_MA);
            if (ExistsOnGh && PE != GH_PE)
                ErrorMessage = string.Format("{0}: Mismatch! Local PE: {1} | GH PE: {2}", Name, PE, GH_PE);
            if (ExistsOnGh && OQ != GH_OQ)
                ErrorMessage = string.Format("{0}: Mismatch! Local OQ: {1} | GH OQ: {2}", Name, OQ, GH_OQ);
            if (ExistsOnGh && SR != GH_SR)
                ErrorMessage = string.Format("{0}: Mismatch! Local SR: {1} | GH SR: {2}", Name, SR, GH_SR);
            if (ExistsOnGh && UT != GH_UT)
                ErrorMessage = string.Format("{0}: Mismatch! Local UT: {1} | GH UT: 2}", Name, UT, GH_UT);

            return false;
        }

        public string GetResourceByNameResponse { get; set; } = string.Empty;
        public string OldSpawnName { get; set; } = string.Empty;
        public string MarkUnavailableResponse { get; set; } = string.Empty;

        public ResourceEntry(Galaxies galaxy, Planets planet)
        {
            Galaxy = galaxy;
            Planet = planet;
        }

        public string GetPostRaw(List<StatItem> mapStats)
        {
            int nGalaxy = (int)Galaxy;
            int nPlanet = (int)Planet;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("galaxy={0}&planet={1}&resName={2}&resType={3}&ER={4}&CR={5}&CD={6}&DR={7}&FL={8}&HR={9}&MA={10}&PE={11}&OQ={12}&SR={13}&UT={14}",
                nGalaxy.ToString(),
                nPlanet.ToString(),
                Name,
                Class.value,
                ER == 0 ? "" : ER,
                CR == 0 ? "" : CR,
                CD == 0 ? "" : CD,
                DR == 0 ? "" : DR,
                FL == 0 ? "" : FL,
                HR == 0 ? "" : HR,
                MA == 0 ? "" : MA,
                PE == 0 ? "" : PE,
                OQ == 0 ? "" : OQ,
                SR == 0 ? "" : SR,
                UT == 0 ? "" : UT);

            return sb.ToString();
        }

        public async Task CheckForAndRemoveOldResource(Galaxies galaxy, HttpClient client, string szSessionToken)
        {
            string szUrl = string.Format("https://galaxyharvester.net/checkOldResource.py?galaxy={0}&spawn={1}", (int)Galaxy, Name);

            HttpRequestMessage requestMessageGet = new HttpRequestMessage(HttpMethod.Get, szUrl);

            var responseGet = await client.SendAsync(requestMessageGet);

            string szResult = await responseGet.Content.ReadAsStringAsync();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(szResult);

            XmlNode nodeResultText = doc.DocumentElement.SelectSingleNode("/result/resultText");

            if (nodeResultText.InnerText == "found")
            {
                XmlNode nodeOldSpawnName = doc.DocumentElement.SelectSingleNode("/result/oldSpawnName");
                OldSpawnName = nodeOldSpawnName.InnerText;
                if (!string.IsNullOrWhiteSpace(OldSpawnName))
                {
                    int nGalaxy = (int)galaxy;
                    string szUrlMarkUnavailable = string.Format("https://galaxyharvester.net/markUnavailable.py?spawn={0}&galaxy={1}&planets=all", OldSpawnName, nGalaxy.ToString());

                    HttpRequestMessage requestMessageMark = new HttpRequestMessage(HttpMethod.Get, szUrlMarkUnavailable);
                    requestMessageMark.Headers.Add("cookie", "gh_sid=" + szSessionToken + ";");

                    var responseMark = await client.SendAsync(requestMessageMark);

                    MarkUnavailableResponse = await responseMark.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task GetResourceByName(HttpClient client)
        {
            string szUrl = string.Format("https://galaxyharvester.net/getResourceByName.py?name={0}&galaxy={1}", Name, (int)Galaxy);

            HttpRequestMessage requestMessageGet = new HttpRequestMessage(HttpMethod.Get, szUrl);

            var responseGet = await client.SendAsync(requestMessageGet);

            GetResourceByNameResponse = await responseGet.Content.ReadAsStringAsync();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetResourceByNameResponse);

            XmlNode nodeResultText = doc.DocumentElement.SelectSingleNode("/result/resultText");

            if(nodeResultText.InnerText == "found")
            {
                ExistsOnGh = true;

                GH_ER = Tools.GetValue(doc, "ER");
                GH_CR = Tools.GetValue(doc, "CR");
                GH_CD = Tools.GetValue(doc, "CD");
                GH_DR = Tools.GetValue(doc, "DR");
                GH_FL = Tools.GetValue(doc, "FL");
                GH_HR = Tools.GetValue(doc, "HR");
                GH_MA = Tools.GetValue(doc, "MA");
                GH_PE = Tools.GetValue(doc, "PE");
                GH_OQ = Tools.GetValue(doc, "OQ");
                GH_SR = Tools.GetValue(doc, "SR");
                GH_UT = Tools.GetValue(doc, "UT");
            }
            else if(nodeResultText.InnerText == "new")
            {
                ExistsOnGh = false;
            }
        }

        public string Friendly(StringBuilder sb)
        {
            sb.Clear();

            sb.AppendFormat("Galaxy: {0} | Planet: {1} | Name: {2} ({3})", Galaxy.ToString(), Planet.ToString(), Name, Class.name);

            return sb.ToString();
        }

        public string FriendlyStats(StringBuilder sb, List<StatItem> mapStats)
        {
            sb.Clear();

            string szLine = string.Format("Name: {0} ({1})",
                Name,
                Class.name);
            szLine = szLine.PadRight(50);
            sb.Append(szLine);
            sb.AppendFormat("ER: {0} | CR: {1} | CD: {2} | DR: {3} | FL: {4} | HR: {5} | MA: {6} | PE: {7} | OQ: {8} | SR: {9} | UT: {10}",
                ER.ToString().PadLeft(3),
                CR.ToString().PadLeft(3),
                CD.ToString().PadLeft(3),
                DR.ToString().PadLeft(3),
                FL.ToString().PadLeft(3),
                HR.ToString().PadLeft(3),
                MA.ToString().PadLeft(3),
                PE.ToString().PadLeft(3),
                OQ.ToString().PadLeft(3),
                SR.ToString().PadLeft(3),
                UT.ToString().PadLeft(3));

            return sb.ToString();
        }
    }
}

