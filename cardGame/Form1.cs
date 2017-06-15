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
            
            sh.str = Int32.Parse(STR.Text);
            sh.dex = Int32.Parse(DEX.Text);
            sh.con = Int32.Parse(CON.Text);
            sh.intelligence = Int32.Parse(INT.Text);
            sh.wis = Int32.Parse(WIS.Text);
            sh.charisma = Int32.Parse(CHA.Text);
            sh.name = name_box.Text;
            sh.klasa = class_box.Text;
            sh.race = race_box.Text;
            sh.size = size_box.Text;
            sh.alignment = alignment_box.Text;
            sh.speed = Int32.Parse(speed_box.Text);
            sh.hp = Int32.Parse(hp_box.Text);
            sh.description = description_box.Text;
            sh.ac_armor = Int32.Parse(ac_armor.Text);
            sh.ac_shield = Int32.Parse(ac_shield.Text);
            sh.ac_natural = Int32.Parse(ac_natural.Text);
            sh.fortitude = Int32.Parse(fort_box.Text);
            sh.reflex = Int32.Parse(reflex_box.Text);
            sh.will = Int32.Parse(will_box.Text);
            sh.bab = Int32.Parse(bab_box.Text);
            sh.acrobatics = Int32.Parse(acrobatics_box.Text);
            sh.appraise = Int32.Parse(appraise_box.Text);
            sh.bluff = Int32.Parse(bluff_box.Text);
            sh.climb = Int32.Parse(climb_box.Text);
            sh.diplomacy = Int32.Parse(diplomacy_box.Text);

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
                                sh.name = x.Value;
                                break;
                            case "alignment":
                                sh.alignment = x.Value;
                                break;
                            case "class":
                                sh.klasa = x.Value;
                                break;
                            case "race":
                                sh.race = x.Value;
                                break;
                            case "size":
                                sh.size = x.Value;
                                break;
                            case "description":
                                sh.description = x.Value;
                                break;
                            case "speed":
                                sh.speed = Int32.Parse(x.Value);
                                break;
                            case "strength":
                                sh.str = Int32.Parse(x.Value);
                                break;
                            case "dexterity":
                                sh.dex = Int32.Parse(x.Value);
                                break;
                            case "constitution":
                                sh.con = Int32.Parse(x.Value);
                                break;
                            case "inteligence":
                                sh.intelligence=Int32.Parse(x.Value);
                                break;
                            case "wisdom":
                                sh.wis= Int32.Parse(x.Value);
                                break;
                            case "charisma":
                                sh.charisma=Int32.Parse(x.Value);
                                break;
                            case "hp":
                                sh.hp= Int32.Parse(x.Value);
                                break;
                            case "armor_bonus":
                                sh.ac_armor= Int32.Parse(x.Value);
                                break;
                            case "shield_bonus":
                                sh.ac_shield=Int32.Parse(x.Value);
                                break;
                            case "natural_armor":
                                sh.ac_natural= Int32.Parse(x.Value);
                                break;
                            case "fortitude":
                                sh.fortitude= Int32.Parse(x.Value);
                                break;
                            case "reflex":
                                sh.reflex= Int32.Parse(x.Value);
                                break;
                            case "will":
                                sh.will= Int32.Parse(x.Value);
                                break;
                            case "base_attack_bonus":
                                sh.bab= Int32.Parse(x.Value);
                                break;
                            case "acrobatics":
                                sh.acrobatics= Int32.Parse(x.Value);
                                break;
                            case "bluff":
                                sh.bluff= Int32.Parse(x.Value);
                                break;
                            case "climb":
                                sh.climb= Int32.Parse(x.Value);
                                break;
                            case "diplomacy":
                                sh.diplomacy= Int32.Parse(x.Value);
                                break;
                            default:
                                break;
                        }
                    }
                    //upisivanje u formu
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
            
            public void fillBlanks()
            {
                
            }
            
        }
  

 
}
