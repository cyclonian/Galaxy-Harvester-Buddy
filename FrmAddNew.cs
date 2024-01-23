using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyclonian.GhBuddy
{
    public partial class FrmAddNew : Form
    {
        public ResourceEntry Entry { get; set; } = new ResourceEntry(Galaxies.Stardust21, GhBuddy.Planets.None);
        public List<string> Planets = new List<string>();
        public List<ResourceClass> ResourceClasses = new List<ResourceClass>();

        public FrmAddNew()
        {
            InitializeComponent();
        }

        public FrmAddNew(List<ResourceClass> resourceClasses) : this()
        {
            Array planets = Enum.GetValues(typeof(Planets));
            cbPlanet.DataSource = planets;
            //cbPlanet.ValueMember = "Value";
            //cbPlanet.DisplayMember = "Key";

            ResourceClasses = resourceClasses;

            cbResourceClass.ValueMember = "value";
            cbResourceClass.DisplayMember = "name";
            cbResourceClass.DataSource = ResourceClasses;

            cbResourceClass.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (cbResourceClass.Items.Count > 0)
                cbResourceClass.SelectedIndex = 0;
        }

        protected bool IsValidStat(string szValue)
        {
            int nValue = 0;
            if (!int.TryParse(szValue, out nValue))
                return false;
            if (nValue < 0)
                return false;
            if (nValue > 1000)
                return false;
            return true;
        }

        protected void CheckEnabled()
        {
            if (errorProvider.HasErrors())
            {
                btnOk.Enabled = false;
                return;
            }

            btnOk.Enabled =
                cbPlanet.SelectedIndex != 0 &&
                cbPlanet.SelectedIndex != -1 &&
                cbResourceClass.SelectedIndex != 0 &&
                cbResourceClass.SelectedIndex != -1 &&
                !string.IsNullOrWhiteSpace(tbName.Text) &&
                tbER.Text + tbCR.Text + tbCD.Text + tbDR.Text + tbFL.Text + tbHR.Text + tbMA.Text + tbPE.Text + tbOQ.Text + tbSR.Text + tbUT.Text != "00000000000";
        }

        private void cbResourceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResourceClass selectedResourceClass = cbResourceClass.SelectedItem as ResourceClass;
            Entry.Class = selectedResourceClass;
            if (selectedResourceClass != null)
            {
                string szMap = selectedResourceClass.title;

                SetStateEnabled(szMap[11], tbER);
                SetStateEnabled(szMap[1], tbCR);
                SetStateEnabled(szMap[2], tbCD);
                SetStateEnabled(szMap[3], tbDR);
                SetStateEnabled(szMap[4], tbFL);
                SetStateEnabled(szMap[5], tbHR);
                SetStateEnabled(szMap[6], tbMA);
                SetStateEnabled(szMap[7], tbPE);
                SetStateEnabled(szMap[8], tbOQ);
                SetStateEnabled(szMap[9], tbSR);
                SetStateEnabled(szMap[10], tbUT);
            }
            else
            {
                SetStateEnabled('0', tbER);
                SetStateEnabled('0', tbCR);
                SetStateEnabled('0', tbCD);
                SetStateEnabled('0', tbDR);
                SetStateEnabled('0', tbFL);
                SetStateEnabled('0', tbHR);
                SetStateEnabled('0', tbMA);
                SetStateEnabled('0', tbPE);
                SetStateEnabled('0', tbOQ);
                SetStateEnabled('0', tbSR);
                SetStateEnabled('0', tbUT);
            }

            CheckEnabled();
        }

        protected void SetStateEnabled(char cFlag, TextBox tb)
        {
            if (cFlag == '1')
            {
                tb.Enabled = true;
            }
            else
            {
                tb.Enabled = false;
                tb.Text = "0";
            }
        }

        private void cbPlanet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Planets selectedPlanet = (Planets)cbPlanet.SelectedItem;
            Entry.Planet = selectedPlanet;
            CheckEnabled();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            Entry.Name = tbName.Text;
            CheckEnabled();
        }

        private void tbStat_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (IsValidStat(tb.Text))
            {
                if (tb == tbER) Entry.ER = int.Parse(tb.Text);
                if (tb == tbCR) Entry.CR = int.Parse(tb.Text);
                if (tb == tbCD) Entry.CD = int.Parse(tb.Text);
                if (tb == tbDR) Entry.DR = int.Parse(tb.Text);
                if (tb == tbFL) Entry.FL = int.Parse(tb.Text);
                if (tb == tbHR) Entry.HR = int.Parse(tb.Text);
                if (tb == tbMA) Entry.MA = int.Parse(tb.Text);
                if (tb == tbPE) Entry.PE = int.Parse(tb.Text);
                if (tb == tbOQ) Entry.OQ = int.Parse(tb.Text);
                if (tb == tbSR) Entry.SR = int.Parse(tb.Text);
                if (tb == tbUT) Entry.UT = int.Parse(tb.Text);
                errorProvider.SetErrorWithCount(tb, "");
            }
            else
            {
                errorProvider.SetErrorWithCount(tb, "Value must be 0-1000");
            }

            CheckEnabled();
        }

        private void tbStat_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            tb.SelectionStart = 0;
            tb.SelectionLength = tb.Text.Length;
        }
    }
}
