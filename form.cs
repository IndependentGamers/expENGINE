using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace temacia_game
{
    public partial class Form1 : Form
    {
        Random nahoda = new Random();
        public double utok, sila, obratnost, postreh, sance_zasahu, kriticky_zasah, brneni, odolnost, uskok, sance_blokovani, level_hrace, zivoty_hrace, critical_chance, hrac_zivot;

        public double utok_nepritel, sila_nepritle, obratnost_nepritel, postreh_nepritel, sance_zasahu_nepritel, kriticky_zasah_nepritel, brneni_nepritel, odolnost_nepritel, uskok_nepritel,
            sance_blokovani_nepritel, level_nepritel, zivot_nepritel, zivot_nepritel_ne, critical_chance_nepritel;

        public double nahodnaGENERACEkritickehoutoku, kritickePOZKOZENI, nahodnaGENERACEkritickehoutoku_nepritele, kritickePOZKOZENI_nepritel;

        public double minHPhrac, maxHPhrac, minHPnepritel, maxHPnepritel, momentalniHPhrac, momentalniHPnepritel, minXPhrac,maxXPhrac;

        public double bonusHPhrac, bonusHPnepritel;

        public int utokAhrace, utokAnepritele;

        public double nahodnaGENERACEblokuHRACE, nahodnaGENERACEblokuNEPRITELE, nahodnaGENERACEuskokuHRACE, nahodnaGENERACEuskokuNEPRITELE;

        public double blokDMGhrace, blokDMGnepritele;

        public double utokHRACvsMOB, utokMOBvsHRAC;

        public double zivotyZustatek;

        public string zalohaTEXT;

        public Form1()
        {
            InitializeComponent();
            vstupHrac();
            vstupNepritel();
            statikyHRAC();
            statikyNEPRITEL();
            vstupHRACobrana();
            vstupMOBobrana();
            tlacitkoUTOK.Enabled = false;
        }

        #region utokVSTUPY
        public void vstupHrac()
        {
            level_hrace = double.Parse(udajLEVELhrace.Text);
            utok = double.Parse(udajUTOK.Text);
            sila = double.Parse(udajSILA.Text);
            obratnost = double.Parse(udajOBRATNOST.Text);
            postreh = double.Parse(udajPOSTREH.Text);
            sance_zasahu = double.Parse(udajSANCEZASAHU.Text);
            kriticky_zasah = double.Parse(udajKRITICKY.Text);
            critical_chance = double.Parse(udajCRITCHANCE.Text);
        }
        public void vstupNepritel()
        {
            level_nepritel = double.Parse(udajLEVELnepritel.Text);
            utok_nepritel = double.Parse(udajUTOKnepritel.Text);
            sila_nepritle = double.Parse(udajSILAnepritel.Text);
            obratnost_nepritel = double.Parse(udajOBRATNOSTnepritel.Text);
            postreh_nepritel = double.Parse(udajPOSTREHnepritel.Text);
            sance_zasahu_nepritel = double.Parse(udajSANCEZASAHUnepritel.Text);
            kriticky_zasah_nepritel = double.Parse(udajKRITICKYZASAHnepritel.Text);
            critical_chance_nepritel = double.Parse(udajCRITICnepritel.Text);
        }
        #endregion

        #region obrana
        public void vstupHRACobrana()
        {
            brneni = double.Parse(udajBRNENI.Text);
            odolnost = double.Parse(udajODOLNOST.Text);
            uskok = double.Parse(udajUSKOK.Text);
            sance_blokovani = double.Parse(udajBLOK.Text);
        }
        public void vstupMOBobrana()
        {
            brneni_nepritel = double.Parse(udajBRNENInepritel.Text);
            odolnost_nepritel = double.Parse(udajODOLNOSTnepritel.Text);
            uskok_nepritel = double.Parse(udajUSKOKnepritel.Text);
            sance_blokovani_nepritel = double.Parse(udajBLOKnepritel.Text);
        }
        #endregion

        #region HP
        public double HPhrace()
        {
            return Math.Round((120 * ((1.25 * level_hrace) / 1.34)) + (odolnost + (12 * (sila / 2))), 0);
        }
        public double HPnepritele()
        {
            return Math.Round((300 * ((1.25 * level_nepritel) / 1.34)) + (odolnost_nepritel + (20 * (sila_nepritle / 5))), 0);
        }
        #endregion

        #region XPperLEVELkill
        public void levelperKILL()
        {
            if (level_nepritel == 1)
            {
                xpBAR.Value += 120;
                if (xpBAR.Value >= xpBAR.Maximum)
                {
                    xpBAR.Minimum = 3800;
                    xpBAR.Maximum = 6000;
                    level_hrace += 1;
                }
                else
                {
                    xpBAR.Value += 120;
                }
            }
            if (level_nepritel == 2)
            {
                xpBAR.Value += 150;
                if (xpBAR.Value >= xpBAR.Maximum)
                {
                    xpBAR.Minimum = 6000;
                    xpBAR.Maximum = 12560;
                    level_hrace = 3;
                }
                else
                {
                    xpBAR.Value = 12560;
                }
            }
        }
        #endregion

        #region statistiky
        public void statikyHRAC()
        {
            if (level_hrace == 1)
            {
                minHPhrac = int.Parse(HPhrace().ToString());
                maxHPhrac = int.Parse(HPhrace().ToString());
                hpHRAC.Maximum = int.Parse(HPhrace().ToString());
                hpHRAC.Value = int.Parse(HPhrace().ToString());
                minXPhrac = 0;
                maxXPhrac = 3800;
                xpBAR.Minimum = int.Parse(minXPhrac.ToString());
                xpBAR.Maximum = int.Parse(maxXPhrac.ToString());
                utok = 2;
                sila = 4;
                obratnost = 3;
                postreh = 2;
                sance_zasahu = 8;
                critical_chance = 100;
                brneni = 4;
                odolnost = 5;
                uskok = 3;
                sance_blokovani = 5; 
            }
                #region statikyTOudajeHRACE
                udajUTOK.Text = utok.ToString();
                udajSILA.Text = sila.ToString();
                udajOBRATNOST.Text = obratnost.ToString();
                udajPOSTREH.Text = postreh.ToString();
                udajSANCEZASAHU.Text = sance_zasahu.ToString();
                udajCRITCHANCE.Text = critical_chance.ToString();
                udajBRNENI.Text = brneni.ToString();
                udajODOLNOST.Text = odolnost.ToString();
                udajUSKOK.Text = uskok.ToString();
                udajBLOK.Text = sance_blokovani.ToString();
                #endregion

                #region zobrazeniMomentalnichSTATIKUhrace
                udajZIVOTY.Text = "HP";
                udajZKUSENOSTI.Text = minXPhrac.ToString() + " / " + hpNepritel.Maximum.ToString() + " XP";
                #endregion
        }
        public void statikyNEPRITEL()
        {
            level_nepritel = level_hrace;
            udajLEVELnepritel.Text = level_nepritel.ToString();
            if (level_nepritel == 1)
            {

                minHPnepritel = int.Parse(HPnepritele().ToString());
                maxHPnepritel = int.Parse(HPnepritele().ToString());
                hpNepritel.Maximum = int.Parse(HPnepritele().ToString());
                hpNepritel.Value = int.Parse(HPnepritele().ToString());
                utok_nepritel = 3;
                sila_nepritle = 2;
                obratnost_nepritel = 1;
                postreh_nepritel = 4;
                sance_zasahu_nepritel = 3;
                critical_chance_nepritel = 7;
                brneni_nepritel = 5;
                odolnost_nepritel = 4;
                uskok_nepritel = 2;
                sance_blokovani_nepritel = 6;
            }
                #region statikyTOudajeNEPRITELE
                udajUTOKnepritel.Text = utok_nepritel.ToString();
                udajSILAnepritel.Text = sila_nepritle.ToString();
                udajOBRATNOSTnepritel.Text = obratnost_nepritel.ToString();
                udajPOSTREHnepritel.Text = postreh_nepritel.ToString();
                udajSANCEZASAHUnepritel.Text = sance_zasahu_nepritel.ToString();
                udajCRITICnepritel.Text = critical_chance_nepritel.ToString();
                udajBRNENInepritel.Text = brneni_nepritel.ToString();
                udajODOLNOSTnepritel.Text = odolnost_nepritel.ToString();
                udajUSKOKnepritel.Text = uskok_nepritel.ToString();
                udajBLOKnepritel.Text = sance_blokovani_nepritel.ToString();
                #endregion

                #region zobrazeniMomentalnichSTATIKUnepritele

                udajZIVOTYnepritel.Text =  "HP";
                #endregion

        }
        #endregion
        
        #region DAMAGE
        public double pozkozeni()
        {
            nahodnaGENERACEkritickehoutoku = nahoda.Next(0, 100);
            if (nahodnaGENERACEkritickehoutoku <= critical_chance)
            {
                kritickePOZKOZENI = nahoda.Next(1, 100) + ((kriticky_zasah * (level_hrace + nahodnyUTOKnepritele())) / 10);
            }
            else
            {
                kritickePOZKOZENI = 0;
            }
            return Math.Round(((nahodnyUTOKhrace() + utok + (sila / 6) + level_hrace) * (obratnost / 2)) + ((postreh + sance_zasahu) * (0.5 + level_hrace)) + kritickePOZKOZENI, 0);
        }
        public double pozkozeniNEPRITEL()
        {
            nahodnaGENERACEkritickehoutoku_nepritele = nahoda.Next(0, 100);
            if (nahodnaGENERACEkritickehoutoku_nepritele <= critical_chance_nepritel)
            {
                kritickePOZKOZENI_nepritel = nahoda.Next(1, 100) + ((kriticky_zasah_nepritel * (level_nepritel + nahodnyUTOKnepritele())) / 5);
            }
            else
            {
                kritickePOZKOZENI_nepritel = 0;
            }
            return Math.Round((((nahodnyUTOKnepritele() + utok_nepritel + (sila_nepritle / 2)) + level_nepritel) * (obratnost_nepritel / 2)) + ((postreh_nepritel + sance_zasahu_nepritel) * (2.85 + level_nepritel)) + kritickePOZKOZENI_nepritel, 0);
        }
        public void FIGHT()
        {
            
        }
        #endregion

        #region nahodnyUTOKY
        public int nahodnyUTOKhrace()
        {
            utokAhrace = int.Parse(level_hrace.ToString());
            return nahoda.Next(3 + utokAhrace, 19 + utokAhrace);
        }
        public int nahodnyUTOKnepritele()
        {
            utokAnepritele = int.Parse(level_nepritel.ToString());
            return nahoda.Next(2 + utokAnepritele, 29 + utokAnepritele);
        }
        #endregion

        #region OBRANA
        public double blokHRACE()
        {
            nahodnaGENERACEblokuHRACE = nahoda.Next(0, 100);
            if(nahodnaGENERACEblokuHRACE <= sance_blokovani)
            {
                blokDMGhrace = nahoda.Next(2,15);
            }
            else
            {
                blokDMGhrace = 0;
            }
            return Math.Round((((brneni + odolnost) * 1.75) + (level_hrace*3)) + (blokDMGhrace * 1.25 + (uskok + level_hrace)), 0);
        }
        public double blockNEPRITEL()
        {
            nahodnaGENERACEblokuNEPRITELE = nahoda.Next(0, 100);
            if (nahodnaGENERACEblokuNEPRITELE <= sance_blokovani_nepritel)
            {
                blokDMGnepritele = nahoda.Next(1, 10);
            }
            else
            {
                blokDMGnepritele = 0;   
            }
            return Math.Round((((brneni_nepritel + odolnost_nepritel) * 1.25) + (level_nepritel * 1.14)) + (blokDMGnepritele * 1.30 + (uskok_nepritel + level_nepritel)), 0);
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            utokHRACvsMOB = minHPnepritel - (pozkozeni() - blockNEPRITEL());
            minHPnepritel = utokHRACvsMOB;
            if (utokHRACvsMOB >= 0)
            {
                hpNepritel.Value = int.Parse(utokHRACvsMOB.ToString());
                zalohaTEXT = damagLOG.Text;
                damagLOG.Text = Environment.NewLine + "Zautocil jsi na nepritele za: " + pozkozeni().ToString() + Environment.NewLine + " Nepritel tvuj utok blokoval za: " + blockNEPRITEL().ToString() + Environment.NewLine;
                damagLOG.Text = zalohaTEXT;
            }
            else
            {
                utokHRACvsMOB = 0;
                hpNepritel.Value = 0;
                utokHRACvsNepritel.Enabled = false;
                utokNEPRITELvsHRAC.Enabled = false;
                hpVALUErealtime.Enabled = false;
                if (hpNepritel.Value == 0)
                {
                    hpNepritel.Value = hpNepritel.Maximum;
                    zalohaTEXT = damagLOG.Text;
                    damagLOG.Text = Environment.NewLine + "Zabil jsi nepritele";
                    damagLOG.Text += zalohaTEXT;
                    hpHRAC.Value = hpHRAC.Maximum;
                    levelperKILL();
                    hpNepritel.Value = hpNepritel.Maximum;
                    tlacitkoUTOK.Enabled = true;
                }
            }


        }

        private void utokNEPRITELvsHRAC_Tick(object sender, EventArgs e)
        {
            utokMOBvsHRAC = minHPhrac - (pozkozeniNEPRITEL() - blokHRACE());
            minHPhrac = utokMOBvsHRAC;
            if (utokMOBvsHRAC >= 0)
            {
                hpHRAC.Value = int.Parse(utokMOBvsHRAC.ToString());
                zalohaTEXT = damagLOG.Text;
                damagLOG.Text = Environment.NewLine + "Nepritel na tebe zautocil za: " + pozkozeniNEPRITEL().ToString() + Environment.NewLine + " Ty jsi blokoval jeho prichozi pozkozeni za: " + blokHRACE().ToString() + Environment.NewLine;
                damagLOG.Text += zalohaTEXT;
            }
            else
            {
                utokMOBvsHRAC = 0;
                hpHRAC.Value = 0;
                utokNEPRITELvsHRAC.Enabled = false;
                utokHRACvsNepritel.Enabled = false;
                hpVALUErealtime.Enabled = false;
                if (hpHRAC.Value == 0)
                {
                    hpHRAC.Value = hpHRAC.Maximum;
                    zalohaTEXT = damagLOG.Text;
                    damagLOG.Text = Environment.NewLine + "Nepritel te zabil";
                    damagLOG.Text += zalohaTEXT;
                    tlacitkoUTOK.Enabled = true;
                }
            }
        }

        private void tlacitkoUTOK_Click_1(object sender, EventArgs e)
        {
            utokNEPRITELvsHRAC.Enabled = true;
            utokHRACvsNepritel.Enabled = true;
            hpVALUErealtime.Enabled = true;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            udajZIVOTY.Text = hpHRAC.Value.ToString() + " / "+ maxHPhrac.ToString() + " HP";
            udajZIVOTYnepritel.Text = hpNepritel.Value.ToString() + " / " + maxHPnepritel.ToString() + " HP";
            udajZKUSENOSTI.Text = xpBAR.Value.ToString() + " / " + xpBAR.Maximum.ToString() + " XP";
        }
     }
}
