using Newtonsoft.Json;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Cyclonian.GhBuddy
{
    public partial class FrmMain : Form
    {
        StringBuilder _sb = new StringBuilder();
        private static readonly HttpClient _client = new HttpClient();

        public Galaxies _galaxy = Galaxies.Stardust21;

        protected string _szResourceClassesPath = "resource_classes.json";
        public List<ResourceClass> ResourceClasses = new List<ResourceClass>();

        public List<StatItem> mapStats = new List<StatItem>();

        BindingList<ResourceEntry> _resourceEntries = new BindingList<ResourceEntry>();
        BindingSource _source = null;


        public string _sessionToken = string.Empty;

        string regexResponse = @"<resultText>([\s\S]*?)</resultText>";

        string settingsKey_Username = "username";
        string settingsKey_MailSaveLocation = "mailsave_location";
        string settingsKey_MailSaveSubfolders = "mailsave_subfolders";

        public FrmMain()
        {
            InitializeComponent();

            mapStats.Add(new StatItem("res_cold_resist", "CR"));
            mapStats.Add(new StatItem("res_conductivity", "CD"));
            mapStats.Add(new StatItem("res_decay_resist", "DR"));
            mapStats.Add(new StatItem("res_flavor", "FL"));
            mapStats.Add(new StatItem("res_heat_resist", "HR"));
            mapStats.Add(new StatItem("res_malleability", "MA"));
            mapStats.Add(new StatItem("res_potential_energy", "PE"));
            mapStats.Add(new StatItem("res_quality", "OQ"));
            mapStats.Add(new StatItem("res_shock_resistance", "SR"));
            mapStats.Add(new StatItem("res_toughness", "UT"));
            mapStats.Add(new StatItem("entangle_resistance", "ER"));

            PerformReadResourceClasses();

            PerformLoadSettings();

            dgv.AutoGenerateColumns = false;
            chGalaxy.DataPropertyName = "GalaxyName";
            chPlanet.DataPropertyName = "PlanetName";
            chName.DataPropertyName = "Name";
            chClass.DataPropertyName = "ClassName";
            chER.DataPropertyName = "ER";
            chCR.DataPropertyName = "CR";
            chCD.DataPropertyName = "CD";
            chDR.DataPropertyName = "DR";
            chFL.DataPropertyName = "FL";
            chHR.DataPropertyName = "HR";
            chMA.DataPropertyName = "MA";
            chPE.DataPropertyName = "PE";
            chOQ.DataPropertyName = "OQ";
            chSR.DataPropertyName = "SR";
            chUT.DataPropertyName = "UT";
            chExistsOnGh.DataPropertyName = "ExistsOnGh";
            _source = new BindingSource(_resourceEntries, null);
            dgv.DataSource = _source;
        }

        public void WriteOut(params string[] messages)
        {
            Tools.WriteOut(rtb, _sb, Color.Black, messages);
        }

        public void WriteOut(Color c, params string[] messages)
        {
            Tools.WriteOut(rtb, _sb, c, messages);
        }

        public void WriteError(Exception ex)
        {
            Tools.WriteError(rtb, _sb, ex);
        }

        protected void PerformClearData()
        {
            rtb.Clear();
            _resourceEntries.Clear();
            SetPostEnabled();
        }

        protected void SetPostEnabled()
        {
            btnPost.Enabled = _resourceEntries.Count > 0;
        }

        public void PerformLoadSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            if (settings[settingsKey_Username] != null)
                tbUsername.Text = settings[settingsKey_Username].Value;
            if (settings[settingsKey_MailSaveLocation] != null)
                tbMailSaveLocation.Text = settings[settingsKey_MailSaveLocation].Value;
            if (settings[settingsKey_MailSaveSubfolders] != null)
                checkMailSaveLocationSubfolders.Checked = settings[settingsKey_MailSaveSubfolders].Value == "true";
        }

        public async void PerformLogin()
        {
            try
            {
                int nGalaxy = (int)_galaxy;
                string szUrl = "https://galaxyharvester.net/authUser.py";
                var values = new Dictionary<string, string>
            {
                { "loginu", tbUsername.Text },
                { "passu", tbPassword.Text },
                { "galaxySel", nGalaxy.ToString() }
            };

                var content = new FormUrlEncodedContent(values);

                WriteOut("Connecting to GalaxyHarvester...");

                var response = await _client.PostAsync(szUrl, content);

                var responseString = await response.Content.ReadAsStringAsync();

                _sessionToken = responseString.Contains("success") ? responseString.Substring(responseString.IndexOf("-") + 1).Trim() : string.Empty;

                if (string.IsNullOrWhiteSpace(_sessionToken))
                    WriteOut(Color.DarkRed, responseString);
                else
                    WriteOut(Color.Green, "success");

                lblConnection.Visible = _sessionToken != string.Empty;
            }
            catch (Exception ex)
            {
                WriteError(ex);
                _resourceEntries.Clear();
                SetPostEnabled();
            }
        }

        public void PerformReadResourceClasses()
        {
            try
            {
                using (StreamReader r = new StreamReader(_szResourceClassesPath))
                {
                    string json = r.ReadToEnd();
                    ResourceClasses = JsonConvert.DeserializeObject<List<ResourceClass>>(json);
                }
            }
            catch (Exception ex)
            {
                WriteError(ex);
                _resourceEntries.Clear();
                SetPostEnabled();
            }
        }

        public async Task PerformReadMailSaveFiles()
        {
            try
            {
                _resourceEntries.Clear();
                DirectoryInfo di = new DirectoryInfo(tbMailSaveLocation.Text);
                if (di.Exists)
                {
                    List<FileInfo> files = di.EnumerateFiles("*.mail", checkMailSaveLocationSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();

                    if (files.Count > 0)
                    {
                        foreach (FileInfo fi in files)
                        {
                            await PerformReadMailSaveFile(fi);
                        }
                    }
                    else
                    {
                        WriteOut("No mailsave files found.");
                    }
                }

                SetPostEnabled();
            }
            catch (Exception ex)
            {
                WriteError(ex);
                _resourceEntries.Clear();
                SetPostEnabled();
            }
        }

        public async Task PerformReadMailSaveFile(FileInfo fi)
        {
            try
            {
                List<ResourceEntry> resourceEntries = new List<ResourceEntry>();

                WriteOut("");
                WriteOut("File: " + fi.FullName);

                List<string> lines = System.IO.File.ReadAllLines(fi.FullName).ToList();
                ResourceEntry currentEntry = null;
                Planets currentPlanet = Planets.None;
                string szCurrentResourceClass = string.Empty;
                for (int i = 0; i < lines.Count; i++)
                {
                    try
                    {
                        string szLine = lines[i];
                        string szTrimmedLine = szLine.Trim();
                        if (lines[i].Contains("Planet: "))
                        {
                            string szPlanet = szLine.Substring(szLine.LastIndexOf(" ") + 1);
                            currentPlanet = Enum.Parse<Planets>(szPlanet);
                            WriteOut("Planet: " + szPlanet);
                        }
                        else if (lines[i].Contains("Resource Class: "))
                        {
                            szCurrentResourceClass = szLine.Substring(szLine.LastIndexOf(" ") + 1);
                            WriteOut("Resource Class: " + szCurrentResourceClass);
                        }
                        else if (lines[i].StartsWith("\t\t\t")) // stat entry
                        {
                            string[] split = szTrimmedLine.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                            StatItem stat = mapStats.Find(x => x.Class == split[0]);
                            int nStatValue = int.Parse(split[1]);
                            switch (stat.Abbreviation)
                            {
                                case "ER": currentEntry.ER = nStatValue; break;
                                case "CR": currentEntry.CR = nStatValue; break;
                                case "CD": currentEntry.CD = nStatValue; break;
                                case "DR": currentEntry.DR = nStatValue; break;
                                case "FL": currentEntry.FL = nStatValue; break;
                                case "HR": currentEntry.HR = nStatValue; break;
                                case "MA": currentEntry.MA = nStatValue; break;
                                case "PE": currentEntry.PE = nStatValue; break;
                                case "OQ": currentEntry.OQ = nStatValue; break;
                                case "SR": currentEntry.SR = nStatValue; break;
                                case "UT": currentEntry.UT = nStatValue; break;
                                default: break;
                            }
                        }
                        else if (lines[i].StartsWith("\t\t")) // name
                        {
                            string szName = szTrimmedLine.Substring(szTrimmedLine.IndexOf(" ") + 1);
                            szName = szName.Substring(0, szName.Length - 3);
                            currentEntry.Name = szName.ToLower();

                            await currentEntry.GetResourceByName(_client);
                        }
                        else if (lines[i].StartsWith("\t")) // class
                        {
                            ResourceClass resourceClass = ResourceClasses.Find(x => x.name == szTrimmedLine);
                            currentEntry = new ResourceEntry(_galaxy, currentPlanet);
                            currentEntry.Class = resourceClass;
                            resourceEntries.Add(currentEntry);
                        }
                        else // skip, not needed line
                        {
                            // TODO: error handle here
                            int stop = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteError(ex);
                        continue;
                    }
                }

                foreach (ResourceEntry entry in resourceEntries)
                {
                    string szStats = entry.FriendlyStats(_sb, mapStats);
                    WriteOut(szStats);
                    _resourceEntries.Add(entry);
                }

                dgv.Update();
                dgv.Refresh();
            }
            catch (Exception ex)
            {
                WriteError(ex);
                _resourceEntries.Clear();
                SetPostEnabled();
            }
        }

        public async void PerformUpdateToGalaxyHarvester()
        {
            try
            {
                foreach (ResourceEntry entry in _resourceEntries)
                {
                    WriteOut(entry.Friendly(_sb));

                    string szUrlPost = "http://galaxyharvester.net/postResource.py";
                    string szRawContent = entry.GetPostRaw(mapStats);
                    WriteOut("POST: " + szUrlPost + "?" + szRawContent);

                    HttpRequestMessage requestMessagePost = new HttpRequestMessage(HttpMethod.Post, szUrlPost);
                    requestMessagePost.Headers.Add("cookie", "gh_sid=" + _sessionToken + ";");
                    requestMessagePost.Content = new StringContent(szRawContent, Encoding.UTF8, "application/x-www-form-urlencoded");

                    var responsePost = await _client.SendAsync(requestMessagePost);

                    var responseStringPost = await responsePost.Content.ReadAsStringAsync();

                    var matchesPost = Regex.Matches(responseStringPost, regexResponse);
                    if (matchesPost.Count > 0 && matchesPost[0].Groups.Count > 1)
                        WriteOut(matchesPost[0].Groups[1].Value.Trim());
                    else
                        WriteOut(responseStringPost.Trim());

                    await entry.CheckForAndRemoveOldResource(_galaxy, _client, _sessionToken);
                    if (!string.IsNullOrWhiteSpace(entry.OldSpawnName))
                    {
                        WriteOut("Found Old Spawn: " + entry.OldSpawnName);
                        WriteOut(entry.MarkUnavailableResponse);
                    }
                    else
                    {
                        WriteOut("No Old Spawn Found!");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex);
                _resourceEntries.Clear();
                SetPostEnabled();
            }
        }

        private void btnMailSaveLocation_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbMailSaveLocation.Text = fbd.SelectedPath;
                Tools.AddOrUpdateAppSettings("mailsave_location", tbMailSaveLocation.Text);
            }
        }

        private void btnReadMailSaveFiles_Click(object sender, EventArgs e)
        {
            PerformReadMailSaveFiles();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            PerformUpdateToGalaxyHarvester();
        }

        private void tbMailSaveLocation_Leave(object sender, EventArgs e)
        {
            Tools.AddOrUpdateAppSettings(settingsKey_MailSaveLocation, tbMailSaveLocation.Text);
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            Tools.AddOrUpdateAppSettings(settingsKey_Username, tbUsername.Text);
        }

        private void checkMailSaveLocationSubfolders_Leave(object sender, EventArgs e)
        {
            Tools.AddOrUpdateAppSettings(settingsKey_MailSaveSubfolders, checkMailSaveLocationSubfolders.Checked.ToString().ToLower());
        }

        private void checkMailSaveLocationSubfolders_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            PerformClearData();
        }
    }
}