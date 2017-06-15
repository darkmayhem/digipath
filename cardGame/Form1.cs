using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace cardGame
{
    public partial class Form1 : Form
    {
        Sheet sh = new Sheet();
        Sheet sh1 = new Sheet();
        public Form1()
        {
            
            InitializeComponent();

                 }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
            if (dlg.FileName == "")
            {
                return;
            }
            XElement sheet = new XElement("sheet");             
                {
                    sheet.Add(new XElement("name", sh.name));
                    sheet.Add(new XElement("alignment", sh.alignment));
                    sheet.Add(new XElement("class", sh.klasa));
                    sheet.Add(new XElement("race", sh.race));
                    sheet.Add(new XElement("size", sh.size));
                    sheet.Add(new XElement("description", sh.description));
                    sheet.Add(new XElement("speed", sh.speed));
                    sheet.Add(new XElement("strength", sh.str));
                    sheet.Add(new XElement("dexterity", sh.dex));
                    sheet.Add(new XElement("constitution", sh.con));
                    sheet.Add(new XElement("inteligence", sh.intelligence));
                    sheet.Add(new XElement("wisdom", sh.wis));
                    sheet.Add(new XElement("charisma", sh.charisma));
                    sheet.Add(new XElement("hp", sh.hp));
                    sheet.Add(new XElement("armor_bonus", sh.ac_armor));
                    sheet.Add(new XElement("shield_bonus", sh.ac_shield));
                    sheet.Add(new XElement("natural_armor", sh.ac_natural));
                    sheet.Add(new XElement("fortitude", sh.fortitude));
                    sheet.Add(new XElement("reflex", sh.reflex));
                    sheet.Add(new XElement("will", sh.will));
                    sheet.Add(new XElement("base_attack_bonus", sh.bab));
                    sheet.Add(new XElement("acrobatics", sh.acrobatics));
                    sheet.Add(new XElement("appraise", sh.appraise));
                    sheet.Add(new XElement("bluff", sh.bluff));
                    sheet.Add(new XElement("climb", sh.climb));
                    sheet.Add(new XElement("diplomacy", sh.diplomacy));
                }

            XDocument xdoc = new XDocument(sheet);
            xdoc.Save(dlg.FileName+".xml");

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            save.Enabled = false;
            save_tab2.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            bool nula = false; 
            if (STR.Text != "") sh.str = Int32.Parse(STR.Text);
            else nula = true;
            if (DEX.Text !="")  sh.dex = Int32.Parse(DEX.Text);
            else nula = true;
            if (CON.Text !="")  sh.con = Int32.Parse(CON.Text);
            else nula = true;
            if (INT.Text !="") sh.intelligence = Int32.Parse(INT.Text);
            else nula = true;
            if (WIS.Text !="") sh.wis = Int32.Parse(WIS.Text);
            else nula = true;
            if (CHA.Text !="") sh.charisma = Int32.Parse(CHA.Text);
            else nula = true;
            sh.name = name_box.Text;
            sh.klasa = class_box.Text;
            sh.race = race_box.Text;
            sh.size = size_box.Text;
            sh.alignment = alignment_box.Text;
            if (speed_box.Text!="") sh.speed = Int32.Parse(speed_box.Text);
            else nula = true;
            if (hp_box.Text!="") sh.hp = Int32.Parse(hp_box.Text);
            else nula = true;
            sh.description = description_box.Text;
            if (ac_armor.Text!="") sh.ac_armor = Int32.Parse(ac_armor.Text);
            else nula = true;
            if (ac_shield.Text!="")sh.ac_shield = Int32.Parse(ac_shield.Text);
            else nula = true;
            if (ac_natural.Text!="") sh.ac_natural = Int32.Parse(ac_natural.Text);
            else nula = true;
            if (fort_box.Text != "") sh.fortitude = Int32.Parse(fort_box.Text);
            else nula = true;
            if (reflex_box.Text != "") sh.reflex = Int32.Parse(reflex_box.Text);
            else nula = true;
            if (will_box.Text != "") sh.will = Int32.Parse(will_box.Text);
            else nula = true;
            if (bab_box.Text != "") sh.bab = Int32.Parse(bab_box.Text);
            else nula = true;
            if (acrobatics_box.Text != "") sh.acrobatics = Int32.Parse(acrobatics_box.Text);
            else nula = true;
            if (appraise_box.Text != "") sh.appraise = Int32.Parse(appraise_box.Text);
            else nula = true;
            if (bluff_box.Text != "") sh.bluff = Int32.Parse(bluff_box.Text);
            else nula = true;
            if (climb_box.Text != "") sh.climb = Int32.Parse(climb_box.Text);
            else nula = true;
            if (diplomacy_box.Text != "") sh.diplomacy = Int32.Parse(diplomacy_box.Text);
            else nula = true;
            if (nula) MessageBox.Show("Jedno ili više brojčanih polja nije uneseno. Njihova vrijednost će se računati kao 0.", "Upozorenje", MessageBoxButtons.OK);
            sh.modifiersCalculation();
            //ispunjavanje forme
            str_mod.Text = sh.str_mod.ToString();
            dex_mod.Text = sh.dex_mod.ToString();
            con_mod.Text = sh.con_mod.ToString();
            int_mod.Text = sh.int_mod.ToString();
            wis_mod.Text = sh.wis_mod.ToString();
            cha_mod.Text = sh.cha_mod.ToString();
            ac_ability.Text = dex_mod.Text;
            fort_ability.Text = con_mod.Text;
            reflex_ability.Text = dex_mod.Text;
            will_ability.Text = wis_mod.Text;
            mab.Text = (sh.bab + sh.str_mod).ToString();
            rab.Text = (sh.bab + sh.dex_mod).ToString();
            acrobatics_ability.Text = dex_mod.Text;
            appraise_ability.Text = int_mod.Text;
            bluff_ability.Text = cha_mod.Text;
            climb_ability.Text = str_mod.Text;
            diplomacy_ability.Text = cha_mod.Text;

            ac_total.Text = (sh.ac_armor+sh.ac_natural+sh.ac_shield+10+sh.dex_mod).ToString();
            fort_total.Text = (sh.fortitude + sh.con_mod).ToString();
            reflex_total.Text = (sh.reflex + sh.dex_mod).ToString();
            will_total.Text = (sh.will + sh.wis_mod).ToString();
            acrobatics_total.Text = (sh.acrobatics + sh.dex_mod).ToString();
            appraise_total.Text = (sh.appraise + sh.int_mod).ToString();
            bluff_total.Text = (sh.bluff + sh.cha_mod).ToString();
            climb_total.Text = (sh.climb + sh.str_mod).ToString();
            diplomacy_total.Text = (sh.diplomacy + sh.cha_mod).ToString();
            
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ldg = new OpenFileDialog();

            XmlDocument doc = new XmlDocument();
            
            ldg.RestoreDirectory = true;


            if (ldg.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ldg.FileName);
                string filepath = ldg.FileName;


                if (extension == ".xml")
                {
                    doc.Load(filepath);
                    XmlElement element = doc["sheet"];
                        foreach (XmlElement x in element.ChildNodes)
                        {
                            switch (x.Name)
                            {
                                case "name":
                                    sh.name = x.InnerText;
                                    break;
                                case "alignment":
                                    sh.alignment = x.InnerText;
                                    break;
                                case "class":
                                    sh.klasa = x.InnerText;
                                    break;
                                case "race":
                                    sh.race = x.InnerText;
                                    break;
                                case "size":
                                    sh.size = x.InnerText;
                                    break;
                                case "description":
                                    sh.description = x.InnerText;
                                    break;
                                case "speed":
                                    sh.speed = Int32.Parse(x.InnerText);
                                    break;
                                case "strength":
                                    sh.str = Int32.Parse(x.InnerText);
                                    break;
                                case "dexterity":
                                    sh.dex = Int32.Parse(x.InnerText);
                                    break;
                                case "constitution":
                                    sh.con = Int32.Parse(x.InnerText);
                                    break;
                                case "inteligence":
                                    sh.intelligence = Int32.Parse(x.InnerText);
                                    break;
                                case "wisdom":
                                    sh.wis = Int32.Parse(x.InnerText);
                                    break;
                                case "charisma":
                                    sh.charisma = Int32.Parse(x.InnerText);
                                    break;
                                case "hp":
                                    sh.hp = Int32.Parse(x.InnerText);
                                    break;
                                case "armor_bonus":
                                    sh.ac_armor = Int32.Parse(x.InnerText);
                                    break;
                                case "shield_bonus":
                                    sh.ac_shield = Int32.Parse(x.InnerText);
                                    break;
                                case "natural_armor":
                                    sh.ac_natural = Int32.Parse(x.InnerText);
                                    break;
                                case "fortitude":
                                    sh.fortitude = Int32.Parse(x.InnerText);
                                    break;
                                case "reflex":
                                    sh.reflex = Int32.Parse(x.InnerText);
                                    break;
                                case "will":
                                    sh.will = Int32.Parse(x.InnerText);
                                    break;
                                case "base_attack_bonus":
                                    sh.bab = Int32.Parse(x.InnerText);
                                    break;
                                case "acrobatics":
                                    sh.acrobatics = Int32.Parse(x.InnerText);
                                    break;
                                case "bluff":
                                    sh.bluff = Int32.Parse(x.InnerText);
                                    break;
                                case "climb":
                                    sh.climb = Int32.Parse(x.InnerText);
                                    break;
                                case "diplomacy":
                                    sh.diplomacy = Int32.Parse(x.InnerText);
                                    break;
                                default:
                                    break;
                            }
                        }
                    //upisivanje u formu
                    sh.modifiersCalculation();
                        name_box.Text = sh.name;
                        alignment_box.Text = sh.alignment;
                        race_box.Text = sh.race;
                        size_box.Text = sh.size;
                        description_box.Text = sh.description;
                        speed_box.Text = sh.speed.ToString();
                        STR.Text = sh.str.ToString();
                        DEX.Text = sh.dex.ToString();
                        CON.Text = sh.con.ToString();
                        INT.Text = sh.intelligence.ToString();
                        WIS.Text = sh.wis.ToString();
                        CHA.Text = sh.charisma.ToString();
                        hp_box.Text = sh.hp.ToString();
                        ac_armor.Text = sh.ac_armor.ToString();
                        ac_shield.Text = sh.ac_shield.ToString();
                        ac_natural.Text = sh.ac_natural.ToString();
                        fort_box.Text = sh.fortitude.ToString();
                        reflex_box.Text = sh.reflex.ToString();
                        will_box.Text = sh.will.ToString();
                        bab_box.Text = sh.bab.ToString();
                        acrobatics_box.Text = sh.acrobatics.ToString();
                        appraise_box.Text = sh.appraise.ToString();
                        bluff_box.Text = sh.bluff.ToString();
                        climb_box.Text = sh.climb.ToString();
                        diplomacy_box.Text = sh.diplomacy.ToString();

                        str_mod.Text = sh.str_mod.ToString();
                        dex_mod.Text = sh.dex_mod.ToString();
                        con_mod.Text = sh.con_mod.ToString();
                        int_mod.Text = sh.int_mod.ToString();
                        wis_mod.Text = sh.wis_mod.ToString();
                        cha_mod.Text = sh.cha_mod.ToString();
                        ac_ability.Text = dex_mod.Text;
                        fort_ability.Text = con_mod.Text;
                        reflex_ability.Text = dex_mod.Text;
                        will_ability.Text = wis_mod.Text;
                        mab.Text = (sh.bab + sh.str_mod).ToString();
                        rab.Text = (sh.bab + sh.dex_mod).ToString();
                        acrobatics_ability.Text = dex_mod.Text;
                        appraise_ability.Text = int_mod.Text;
                        bluff_ability.Text = cha_mod.Text;
                        climb_ability.Text = str_mod.Text;
                        diplomacy_ability.Text = cha_mod.Text;

                        ac_total.Text = (sh.ac_armor + sh.ac_natural + sh.ac_shield + 10 + sh.dex_mod).ToString();
                        fort_total.Text = (sh.fortitude + sh.con_mod).ToString();
                        reflex_total.Text = (sh.reflex + sh.dex_mod).ToString();
                        will_total.Text = (sh.will + sh.wis_mod).ToString();
                        acrobatics_total.Text = (sh.acrobatics + sh.dex_mod).ToString();
                        appraise_total.Text = (sh.appraise + sh.int_mod).ToString();
                        bluff_total.Text = (sh.bluff + sh.cha_mod).ToString();
                        climb_total.Text = (sh.climb + sh.str_mod).ToString();
                        diplomacy_total.Text = (sh.diplomacy + sh.cha_mod).ToString();
                        //nakon upisa
                        save.Enabled = true;
                }
                else MessageBox.Show("Datoteka nije XML.", "Greska", MessageBoxButtons.OK);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            string title = "Lik " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            save_tab2.Enabled = true;
            bool nula = false;
            if (STR1.Text != "") sh1.str = Int32.Parse(STR1.Text);
            else nula = true;
            if (DEX1.Text != "") sh1.dex = Int32.Parse(DEX1.Text);
            else nula = true;
            if (CON1.Text != "") sh1.con = Int32.Parse(CON1.Text);
            else nula = true;
            if (INT1.Text != "") sh1.intelligence = Int32.Parse(INT1.Text);
            else nula = true;
            if (WIS1.Text != "") sh1.wis = Int32.Parse(WIS1.Text);
            else nula = true;
            if (CHA1.Text != "") sh1.charisma = Int32.Parse(CHA1.Text);
            else nula = true;
            sh1.name = name_box1.Text;
            sh1.klasa = class_box1.Text;
            sh1.race = race_box1.Text;
            sh1.size = size_box1.Text;
            sh1.alignment = alignment_box1.Text;
            if (speed_box1.Text != "") sh1.speed = Int32.Parse(speed_box1.Text);
            else nula = true;
            if (hp_box1.Text != "") sh1.hp = Int32.Parse(hp_box1.Text);
            else nula = true;
            sh1.description = description_box1.Text;
            if (ac_armor1.Text != "") sh1.ac_armor = Int32.Parse(ac_armor1.Text);
            else nula = true;
            if (ac_shield1.Text != "") sh1.ac_shield = Int32.Parse(ac_shield1.Text);
            else nula = true;
            if (ac_natural1.Text != "") sh1.ac_natural = Int32.Parse(ac_natural1.Text);
            else nula = true;
            if (fort_box1.Text != "") sh1.fortitude = Int32.Parse(fort_box1.Text);
            else nula = true;
            if (reflex_box1.Text != "") sh1.reflex = Int32.Parse(reflex_box1.Text);
            else nula = true;
            if (will_box1.Text != "") sh1.will = Int32.Parse(will_box1.Text);
            else nula = true;
            if (bab_box1.Text != "") sh1.bab = Int32.Parse(bab_box1.Text);
            else nula = true;
            if (acrobatics_box1.Text != "") sh1.acrobatics = Int32.Parse(acrobatics_box1.Text);
            else nula = true;
            if (appraise_box1.Text != "") sh1.appraise = Int32.Parse(appraise_box1.Text);
            else nula = true;
            if (bluff_box1.Text != "") sh1.bluff = Int32.Parse(bluff_box1.Text);
            else nula = true;
            if (climb_box1.Text != "") sh1.climb = Int32.Parse(climb_box1.Text);
            else nula = true;
            if (diplomacy_box1.Text != "") sh1.diplomacy = Int32.Parse(diplomacy_box1.Text);
            else nula = true;
            if (nula) MessageBox.Show("Jedno ili više brojčanih polja nije uneseno. Njihova vrijednost će se računati kao 0.", "Upozorenje", MessageBoxButtons.OK);
            sh1.modifiersCalculation();
            //ispunjavanje forme
            str_mod1.Text = sh1.str_mod.ToString();
            dex_mod1.Text = sh1.dex_mod.ToString();
            con_mod1.Text = sh1.con_mod.ToString();
            int_mod1.Text = sh1.int_mod.ToString();
            wis_mod1.Text = sh1.wis_mod.ToString();
            cha_mod1.Text = sh1.cha_mod.ToString();
            ac_ability1.Text = dex_mod1.Text;
            fort_ability1.Text = con_mod1.Text;
            reflex_ability1.Text = dex_mod1.Text;
            will_ability1.Text = wis_mod1.Text;
            mab1.Text = (sh1.bab + sh1.str_mod).ToString();
            rab1.Text = (sh1.bab + sh1.dex_mod).ToString();
            acrobatics_ability1.Text = dex_mod1.Text;
            appraise_ability1.Text = int_mod1.Text;
            bluff_ability1.Text = cha_mod1.Text;
            climb_ability1.Text = str_mod1.Text;
            diplomacy_ability1.Text = cha_mod1.Text;

            ac_total1.Text = (sh1.ac_armor + sh1.ac_natural + sh1.ac_shield + 10 + sh1.dex_mod).ToString();
            fort_total1.Text = (sh1.fortitude + sh1.con_mod).ToString();
            reflex_total1.Text = (sh1.reflex + sh1.dex_mod).ToString();
            will_total1.Text = (sh1.will + sh1.wis_mod).ToString();
            acrobatics_total1.Text = (sh1.acrobatics + sh1.dex_mod).ToString();
            appraise_total1.Text = (sh1.appraise + sh1.int_mod).ToString();
            bluff_total1.Text = (sh1.bluff + sh1.cha_mod).ToString();
            climb_total1.Text = (sh1.climb + sh1.str_mod).ToString();
            diplomacy_total1.Text = (sh1.diplomacy + sh1.cha_mod).ToString();
        }

        private void save_tab2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
            if (dlg.FileName == "")
            {
                return;
            }
            XElement sheet = new XElement("sheet");
            {
                sheet.Add(new XElement("name", sh1.name));
                sheet.Add(new XElement("alignment", sh1.alignment));
                sheet.Add(new XElement("class", sh1.klasa));
                sheet.Add(new XElement("race", sh1.race));
                sheet.Add(new XElement("size", sh1.size));
                sheet.Add(new XElement("description", sh1.description));
                sheet.Add(new XElement("speed", sh1.speed));
                sheet.Add(new XElement("strength", sh1.str));
                sheet.Add(new XElement("dexterity", sh1.dex));
                sheet.Add(new XElement("constitution", sh1.con));
                sheet.Add(new XElement("inteligence", sh1.intelligence));
                sheet.Add(new XElement("wisdom", sh1.wis));
                sheet.Add(new XElement("charisma", sh1.charisma));
                sheet.Add(new XElement("hp", sh1.hp));
                sheet.Add(new XElement("armor_bonus", sh1.ac_armor));
                sheet.Add(new XElement("shield_bonus", sh1.ac_shield));
                sheet.Add(new XElement("natural_armor", sh1.ac_natural));
                sheet.Add(new XElement("fortitude", sh1.fortitude));
                sheet.Add(new XElement("reflex", sh1.reflex));
                sheet.Add(new XElement("will", sh1.will));
                sheet.Add(new XElement("base_attack_bonus", sh1.bab));
                sheet.Add(new XElement("acrobatics", sh1.acrobatics));
                sheet.Add(new XElement("appraise", sh1.appraise));
                sheet.Add(new XElement("bluff", sh1.bluff));
                sheet.Add(new XElement("climb", sh1.climb));
                sheet.Add(new XElement("diplomacy", sh1.diplomacy));
            }

            XDocument xdoc = new XDocument(sheet);
            xdoc.Save(dlg.FileName + ".xml");


            {
                
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog ldg = new OpenFileDialog();

            XmlDocument doc = new XmlDocument();

            ldg.RestoreDirectory = true;


            if (ldg.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ldg.FileName);
                string filepath = ldg.FileName;


                if (extension == ".xml")
                {
                    doc.Load(filepath);
                    XmlElement element = doc["sheet"];
                    foreach (XmlElement x in element.ChildNodes)
                    {
                        switch (x.Name)
                        {
                            case "name":
                                sh1.name = x.InnerText;
                                break;
                            case "alignment":
                                sh1.alignment = x.InnerText;
                                break;
                            case "class":
                                sh1.klasa = x.InnerText;
                                break;
                            case "race":
                                sh1.race = x.InnerText;
                                break;
                            case "size":
                                sh1.size = x.InnerText;
                                break;
                            case "description":
                                sh1.description = x.InnerText;
                                break;
                            case "speed":
                                sh1.speed = Int32.Parse(x.InnerText);
                                break;
                            case "strength":
                                sh1.str = Int32.Parse(x.InnerText);
                                break;
                            case "dexterity":
                                sh1.dex = Int32.Parse(x.InnerText);
                                break;
                            case "constitution":
                                sh1.con = Int32.Parse(x.InnerText);
                                break;
                            case "inteligence":
                                sh1.intelligence = Int32.Parse(x.InnerText);
                                break;
                            case "wisdom":
                                sh1.wis = Int32.Parse(x.InnerText);
                                break;
                            case "charisma":
                                sh1.charisma = Int32.Parse(x.InnerText);
                                break;
                            case "hp":
                                sh1.hp = Int32.Parse(x.InnerText);
                                break;
                            case "armor_bonus":
                                sh1.ac_armor = Int32.Parse(x.InnerText);
                                break;
                            case "shield_bonus":
                                sh1.ac_shield = Int32.Parse(x.InnerText);
                                break;
                            case "natural_armor":
                                sh1.ac_natural = Int32.Parse(x.InnerText);
                                break;
                            case "fortitude":
                                sh1.fortitude = Int32.Parse(x.InnerText);
                                break;
                            case "reflex":
                                sh1.reflex = Int32.Parse(x.InnerText);
                                break;
                            case "will":
                                sh1.will = Int32.Parse(x.InnerText);
                                break;
                            case "base_attack_bonus":
                                sh1.bab = Int32.Parse(x.InnerText);
                                break;
                            case "acrobatics":
                                sh1.acrobatics = Int32.Parse(x.InnerText);
                                break;
                            case "bluff":
                                sh1.bluff = Int32.Parse(x.InnerText);
                                break;
                            case "climb":
                                sh1.climb = Int32.Parse(x.InnerText);
                                break;
                            case "diplomacy":
                                sh1.diplomacy = Int32.Parse(x.InnerText);
                                break;
                            default:
                                break;
                        }
                    }
                    //upisivanje u formu
                    sh1.modifiersCalculation();
                    name_box1.Text = sh1.name;
                    alignment_box1.Text = sh1.alignment;
                    race_box1.Text = sh1.race;
                    size_box1.Text = sh1.size;
                    description_box1.Text = sh1.description;
                    speed_box1.Text = sh1.speed.ToString();
                    STR1.Text = sh1.str.ToString();
                    DEX1.Text = sh1.dex.ToString();
                    CON1.Text = sh1.con.ToString();
                    INT1.Text = sh1.intelligence.ToString();
                    WIS1.Text = sh1.wis.ToString();
                    CHA1.Text = sh1.charisma.ToString();
                    hp_box1.Text = sh1.hp.ToString();
                    ac_armor1.Text = sh1.ac_armor.ToString();
                    ac_shield1.Text = sh1.ac_shield.ToString();
                    ac_natural1.Text = sh1.ac_natural.ToString();
                    fort_box1.Text = sh1.fortitude.ToString();
                    reflex_box1.Text = sh1.reflex.ToString();
                    will_box1.Text = sh1.will.ToString();
                    bab_box1.Text = sh1.bab.ToString();
                    acrobatics_box1.Text = sh1.acrobatics.ToString();
                    appraise_box1.Text = sh1.appraise.ToString();
                    bluff_box1.Text = sh1.bluff.ToString();
                    climb_box1.Text = sh1.climb.ToString();
                    diplomacy_box1.Text = sh1.diplomacy.ToString();

                    str_mod1.Text = sh1.str_mod.ToString();
                    dex_mod1.Text = sh1.dex_mod.ToString();
                    con_mod1.Text = sh1.con_mod.ToString();
                    int_mod1.Text = sh1.int_mod.ToString();
                    wis_mod1.Text = sh1.wis_mod.ToString();
                    cha_mod1.Text = sh1.cha_mod.ToString();
                    ac_ability1.Text = dex_mod1.Text;
                    fort_ability1.Text = con_mod1.Text;
                    reflex_ability1.Text = dex_mod1.Text;
                    will_ability1.Text = wis_mod1.Text;
                    mab1.Text = (sh1.bab + sh1.str_mod).ToString();
                    rab1.Text = (sh1.bab + sh1.dex_mod).ToString();
                    acrobatics_ability1.Text = dex_mod1.Text;
                    appraise_ability1.Text = int_mod1.Text;
                    bluff_ability1.Text = cha_mod1.Text;
                    climb_ability1.Text = str_mod1.Text;
                    diplomacy_ability1.Text = cha_mod1.Text;

                    ac_total1.Text = (sh1.ac_armor + sh1.ac_natural + sh1.ac_shield + 10 + sh1.dex_mod).ToString();
                    fort_total1.Text = (sh1.fortitude + sh1.con_mod).ToString();
                    reflex_total1.Text = (sh1.reflex + sh1.dex_mod).ToString();
                    will_total1.Text = (sh1.will + sh1.wis_mod).ToString();
                    acrobatics_total1.Text = (sh1.acrobatics + sh1.dex_mod).ToString();
                    appraise_total1.Text = (sh1.appraise + sh1.int_mod).ToString();
                    bluff_total1.Text = (sh1.bluff + sh1.cha_mod).ToString();
                    climb_total1.Text = (sh1.climb + sh1.str_mod).ToString();
                    diplomacy_total1.Text = (sh1.diplomacy + sh1.cha_mod).ToString();
                    //nakon upisa
                    save_tab2.Enabled = true;
                }
                else MessageBox.Show("Datoteka nije XML.", "Greska", MessageBoxButtons.OK);
            }
        }
    }
    public class Sheet
        {

            public double str;
            public double dex;
            public double con;
            public double intelligence;
            public double wis;
            public double charisma;
            public string name;
            public string klasa;
            public string race;
            public string size;
            public string alignment;
            public int speed;
            public int hp;
            public string description;
            public int ac_armor;
            public int ac_shield;
            public int ac_natural;
            public int fortitude;
            public int reflex;
            public int will;
            public int bab;
            public int acrobatics;
            public int appraise;
            public int bluff;
            public int climb;
            public int diplomacy;
            public double str_mod;
            public double dex_mod;
            public double con_mod;
            public double int_mod;
            public double wis_mod;
            public double cha_mod;

            public void modifiersCalculation()
            {
                str_mod = Math.Floor((str - 10) / 2);
                dex_mod = Math.Floor((dex - 10) / 2);
                con_mod = Math.Floor((con - 10) / 2);
                int_mod = Math.Floor((intelligence - 10) / 2);
                wis_mod = Math.Floor((wis - 10) / 2);
                cha_mod = Math.Floor((charisma - 10) / 2);
            }
            
        }
  

 
}
