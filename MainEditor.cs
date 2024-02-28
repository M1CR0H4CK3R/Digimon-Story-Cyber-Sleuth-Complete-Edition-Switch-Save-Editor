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

namespace DigimonStorySaveEditor
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            pictureBoxCSDigimonPartySlot1Portrait.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCSDigimonPartySlot1Dot.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public string savegame;
        public string[] digimonIDs = Properties.Resources.ID_Alphabetized.Split('\n');
        public string[] supportSkills = Properties.Resources.Support_Skills.Split('\n');
        public string[] accessories = Properties.Resources.Accessories.Split('\n');
        public string[] equipment = Properties.Resources.Equipment.Split('\n');
        public string[] items = Properties.Resources.Items.Split('\n');
        public string[] skills = Properties.Resources.Skills.Split('\n');

        private void openFileDlg()
        {
            OpenFileDialog openFD = new OpenFileDialog
            {
                Filter = "Bin Files (*.bin)|*.bin"
            };
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                savegame = openFD.FileName;
            }
        }

        private void getDataCS()
        {
            FileStream savegameFs = new FileStream(savegame, FileMode.Open);
            BinaryReader savegameBr = new BinaryReader(savegameFs);

            //Read in first Digimon in party data
            #region DigimonPartySlot1
            #region Main1
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CA9C;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CAAC;
                byte[] CSDigimonPartySlot1ID = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1IDDec = BitConverter.ToInt16(CSDigimonPartySlot1ID, 0);
                comboBoxCSDigimonPartySlot1ID.Text = convertDigimonIDtoString(CSDigimonPartySlot1IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CABC;
                byte[] CSDigimonPartySlot1Nickname = savegameBr.ReadBytes(17);
                string CSDigimonPartySlot1NicknameDec = Encoding.ASCII.GetString(CSDigimonPartySlot1Nickname);
                textBoxCSDigimonPartySlot1Nickname.Text = CSDigimonPartySlot1NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CAB8;
                byte CSDigimonPartySlot1Digivolution = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Digivolution.Text = convertDigivolutionIDtoString(CSDigimonPartySlot1Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CAB4;
                byte CSDigimonPartySlot1Type = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Type.Text = convertTypeIDtoString(CSDigimonPartySlot1Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CAB0;
                byte CSDigimonPartySlot1Attribute = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Attribute.Text = convertAttributeIDtoString(CSDigimonPartySlot1Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CB20;
                byte CSDigimonPartySlot1Personality = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Personality.Text = convertPersonalityIDtoString(CSDigimonPartySlot1Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3CCC0;
                byte CSDigimonPartySlot1SupportSkill = savegameBr.ReadByte();
                comboBoxCSDigmonPartySlot1SupportSkill.Text = convertsupportSkillsIDtoString(CSDigimonPartySlot1SupportSkill);
                #endregion

                #region Stats1
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3CCC4;
                byte CSDigimonPartySlot1EquipSlots = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1EquipSlots.Value = CSDigimonPartySlot1EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CB04;
                byte CSDigimonPartySlot1Memory = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1Memory.Value = CSDigimonPartySlot1Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CB18;
                byte[] CSDigimonPartySlot1EXP = savegameBr.ReadBytes(4);
                int CSDigimonPartySlot1EXPDec = BitConverter.ToInt32(CSDigimonPartySlot1EXP, 0);
                numericUpDownCSDigimonPartySlot1EXP.Value = CSDigimonPartySlot1EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CB10;
                byte CSDigimonPartySlot1CurrentLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1CurrentLVL.Value = CSDigimonPartySlot1CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CB12;
                byte CSDigimonPartySlot1MaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1MaxLVL.Value = CSDigimonPartySlot1MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CB14;
                byte CSDigimonPartySlot1ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1ExtraMaxLVL.Value = CSDigimonPartySlot1ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CB24;
                byte[] CSDigimonPartySlot1CurrentHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1CurrentHPDec = BitConverter.ToInt16(CSDigimonPartySlot1CurrentHP, 0);
                numericUpDownCSDigimonPartySlot1CurrentHP.Value = CSDigimonPartySlot1CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CB28;
                byte[] CSDigimonPartySlot1MaxHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1MaxHPDec = BitConverter.ToInt16(CSDigimonPartySlot1MaxHP, 0);
                numericUpDownCSDigimonPartySlot1MaxHP.Value = CSDigimonPartySlot1MaxHPDec * 100;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CB2C;
                byte[] CSDigimonPartySlot1BonusHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1BonusHPDec = BitConverter.ToInt16(CSDigimonPartySlot1BonusHP, 0);
                numericUpDownCSDigimonPartySlot1BonusHP.Value = CSDigimonPartySlot1BonusHPDec / 100;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CB30;
                byte[] CSDigimonPartySlot1CurrentSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1CurrentSPDec = BitConverter.ToInt16(CSDigimonPartySlot1CurrentSP, 0);
                numericUpDownCSDigimonPartySlot1CurrentSP.Value = CSDigimonPartySlot1CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CB34;
                byte[] CSDigimonPartySlot1MaxSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1MaxSPDec = BitConverter.ToInt16(CSDigimonPartySlot1MaxSP, 0);
                numericUpDownCSDigimonPartySlot1MaxSP.Value = CSDigimonPartySlot1MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CB38;
                byte[] CSDigimonPartySlot1BonusSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1BonusSPDec = BitConverter.ToInt16(CSDigimonPartySlot1BonusSP, 0);
                numericUpDownCSDigimonPartySlot1BonusSP.Value = CSDigimonPartySlot1BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CB3A;
                byte[] CSDigimonPartySlot1Attack = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1AttackDec = BitConverter.ToInt16(CSDigimonPartySlot1Attack, 0);
                numericUpDownCSDigimonPartySlot1Attack.Value = CSDigimonPartySlot1AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CB3C;
                byte[] CSDigimonPartySlot1BonusAttack = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1BonusAttackDec = BitConverter.ToInt16(CSDigimonPartySlot1BonusAttack, 0);
                numericUpDownCSDigimonPartySlot1BonusAttack.Value = CSDigimonPartySlot1BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CB3E;
                byte[] CSDigimonPartySlot1Defense = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1DefenseDec = BitConverter.ToInt16(CSDigimonPartySlot1Defense, 0);
                numericUpDownCSDigimonPartySlot1Defense.Value = CSDigimonPartySlot1DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CB40;
                byte[] CSDigimonPartySlot1BonusDefense = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1BonusDefenseDec = BitConverter.ToInt16(CSDigimonPartySlot1BonusDefense, 0);
                numericUpDownCSDigimonPartySlot1BonusDefense.Value = CSDigimonPartySlot1BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CB42;
                byte[] CSDigimonPartySlot1Intelligence = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1IntelligenceDec = BitConverter.ToInt16(CSDigimonPartySlot1Intelligence, 0);
                numericUpDownCSDigimonPartySlot1Intelligence.Value = CSDigimonPartySlot1IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CB44;
                byte[] CSDigimonPartySlot1BonusIntelligence = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1BonusIntelligenceDec = BitConverter.ToInt16(CSDigimonPartySlot1BonusIntelligence, 0);
                numericUpDownCSDigimonPartySlot1BonusIntelligence.Value = CSDigimonPartySlot1BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CB46;
                byte[] CSDigimonPartySlot1Speed = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1SpeedDec = BitConverter.ToInt16(CSDigimonPartySlot1Speed, 0);
                numericUpDownCSDigimonPartySlot1Speed.Value = CSDigimonPartySlot1SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CB48;
                byte[] CSDigimonPartySlot1BonusSpeed = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1BonusSpeedDec = BitConverter.ToInt16(CSDigimonPartySlot1BonusSpeed, 0);
                numericUpDownCSDigimonPartySlot1BonusSpeed.Value = CSDigimonPartySlot1BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CB4C;
                byte[] CSDigimonPartySlot1CAM = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1CAMDec = BitConverter.ToInt16(CSDigimonPartySlot1CAM, 0);
                numericUpDownCSDigimonPartySlot1CAM.Value = (CSDigimonPartySlot1CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CB4A;
                byte[] CSDigimonPartySlot1ABI = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1ABIDec = BitConverter.ToInt16(CSDigimonPartySlot1ABI, 0);
                numericUpDownCSDigimonPartySlot1ABI.Value = CSDigimonPartySlot1ABIDec;
                #endregion

                #region Equipment1
                //Equip 1
                savegameBr.BaseStream.Position = 0x3CCC6;
                byte[] CSDigimonPartySlot1Equip1 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1Equip1Dec = BitConverter.ToInt16(CSDigimonPartySlot1Equip1, 0);
                comboBoxCSDigimonPartySlot1Equip1.Text = convertEquipIDtoString(CSDigimonPartySlot1Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3CCC8;
                byte[] CSDigimonPartySlot1Equip2 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1Equip2Dec = BitConverter.ToInt16(CSDigimonPartySlot1Equip2, 0);
                comboBoxCSDigimonPartySlot1Equip2.Text = convertEquipIDtoString(CSDigimonPartySlot1Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3CCCA;
                byte[] CSDigimonPartySlot1Equip3 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1Equip3Dec = BitConverter.ToInt16(CSDigimonPartySlot1Equip3, 0);
                comboBoxCSDigimonPartySlot1Equip3.Text = convertEquipIDtoString(CSDigimonPartySlot1Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3CCCC;
                byte[] CSDigimonPartySlot1Accessory = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot1AccessoryDec = BitConverter.ToInt16(CSDigimonPartySlot1Accessory, 0);
                comboBoxCSDigimonPartySlot1Accessory.Text = convertAccessoryIDtoString(CSDigimonPartySlot1AccessoryDec);
                #endregion

                #region CurrentSkills1
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CB50;
                byte CSDigimonPartySlot1CurrentSkill1Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1CurrentSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill1Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CB54;
                    comboBoxCSDigimonPartySlot1CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CB58;
                byte CSDigimonPartySlot1CurrentSkill2Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1CurrentSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill2Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CB5C;
                    comboBoxCSDigimonPartySlot1CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CB60;
                byte CSDigimonPartySlot1CurrentSkill3Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1CurrentSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill3Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CB64;
                    comboBoxCSDigimonPartySlot1CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CB68;
                byte CSDigimonPartySlot1CurrentSkill4Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1CurrentSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill4Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CB6C;
                    comboBoxCSDigimonPartySlot1CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CB70;
                byte CSDigimonPartySlot1CurrentSkill5Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1CurrentSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill5Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CB74;
                    comboBoxCSDigimonPartySlot1CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CB78;
                byte CSDigimonPartySlot1CurrentSkill6Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1CurrentSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill6Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CB7C;
                    comboBoxCSDigimonPartySlot1CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills1
                //Learned Skill 1
                savegameBr.BaseStream.Position = 0x3CB80;
                byte CSDigimonPartySlot1LearnedSkill1Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill1Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CB84;
                    comboBoxCSDigimonPartySlot1LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3CB88;
                byte CSDigimonPartySlot1LearnedSkill2Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill2Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CB8C;
                    comboBoxCSDigimonPartySlot1LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3CB90;
                byte CSDigimonPartySlot1LearnedSkill3Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill3Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CB94;
                    comboBoxCSDigimonPartySlot1LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3CB98;
                byte CSDigimonPartySlot1LearnedSkill4Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill4Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CB9C;
                    comboBoxCSDigimonPartySlot1LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3CBA0;
                byte CSDigimonPartySlot1LearnedSkill5Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill5Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CBA4;
                    comboBoxCSDigimonPartySlot1LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3CBA8;
                byte CSDigimonPartySlot1LearnedSkill6Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill6Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CBAC;
                    comboBoxCSDigimonPartySlot1LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3CBB0;
                byte CSDigimonPartySlot1LearnedSkill7Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill7Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill7Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3CBB4;
                    comboBoxCSDigimonPartySlot1LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3CBB8;
                byte CSDigimonPartySlot1LearnedSkill8Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill8Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill8Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3CBBC;
                    comboBoxCSDigimonPartySlot1LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3CBC0;
                byte CSDigimonPartySlot1LearnedSkill9Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill9Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill9Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3CBC4;
                    comboBoxCSDigimonPartySlot1LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3CBC8;
                byte CSDigimonPartySlot1LearnedSkill10Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill10Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill10Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3CBCC;
                    comboBoxCSDigimonPartySlot1LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3CBD0;
                byte CSDigimonPartySlot1LearnedSkill11Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill11Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill11Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3CBD4;
                    comboBoxCSDigimonPartySlot1LearnedSkill11.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3CBD8;
                byte CSDigimonPartySlot1LearnedSkill12Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill12Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill12Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3CBDC;
                    comboBoxCSDigimonPartySlot1LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3CBE0;
                byte CSDigimonPartySlot1LearnedSkill13Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill13Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill13Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3CBE4;
                    comboBoxCSDigimonPartySlot1LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3CBE8;
                byte CSDigimonPartySlot1LearnedSkill14Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill14Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill14Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3CBEC;
                    comboBoxCSDigimonPartySlot1LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3CBF0;
                byte CSDigimonPartySlot1LearnedSkill15Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill15Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill15Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3CBF4;
                    comboBoxCSDigimonPartySlot1LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3CBF8;
                byte CSDigimonPartySlot1LearnedSkill16Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill16Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill16Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3CBFC;
                    comboBoxCSDigimonPartySlot1LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3CC00;
                byte CSDigimonPartySlot1LearnedSkill17Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill17Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill17Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3CC04;
                    comboBoxCSDigimonPartySlot1LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3CC08;
                byte CSDigimonPartySlot1LearnedSkill18Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill18Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill18Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3CC0C;
                    comboBoxCSDigimonPartySlot1LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3CC10;
                byte CSDigimonPartySlot1LearnedSkill19Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill19Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill19Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3CC14;
                    comboBoxCSDigimonPartySlot1LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3CC18;
                byte CSDigimonPartySlot1LearnedSkill20Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot1LearnedSkill20Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill20Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot1LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3CC1C;
                    comboBoxCSDigimonPartySlot1LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraitsCS(1);
            }

            else
            {
                checkBoxCSDigimonPartySlot1None.Checked = true;
            }
            #endregion

            //Read in second Digimon in party data
            #region DigimonPartySlot2
            #region Main2
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CCDC;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CCEC;
                byte[] CSDigimonPartySlot2ID = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2IDDec = BitConverter.ToInt16(CSDigimonPartySlot2ID, 0);
                comboBoxCSDigimonPartySlot2ID.Text = convertDigimonIDtoString(CSDigimonPartySlot2IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CCFC;
                byte[] CSDigimonPartySlot2Nickname = savegameBr.ReadBytes(17);
                string CSDigimonPartySlot2NicknameDec = Encoding.ASCII.GetString(CSDigimonPartySlot2Nickname);
                textBoxCSDigimonPartySlot2Nickname.Text = CSDigimonPartySlot2NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CCF8;
                byte CSDigimonPartySlot2Digivolution = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Digivolution.Text = convertDigivolutionIDtoString(CSDigimonPartySlot2Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CCF4;
                byte CSDigimonPartySlot2Type = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Type.Text = convertTypeIDtoString(CSDigimonPartySlot2Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CCF0;
                byte CSDigimonPartySlot2Attribute = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Attribute.Text = convertAttributeIDtoString(CSDigimonPartySlot2Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CD60;
                byte CSDigimonPartySlot2Personality = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Personality.Text = convertPersonalityIDtoString(CSDigimonPartySlot2Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3CF00;
                byte CSDigimonPartySlot2SupportSkill = savegameBr.ReadByte();
                comboBoxCSDigmonPartySlot2SupportSkill.Text = convertsupportSkillsIDtoString(CSDigimonPartySlot2SupportSkill);
                #endregion

                #region Stats2
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3CF04;
                byte CSDigimonPartySlot2EquipSlots = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2EquipSlots.Value = CSDigimonPartySlot2EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CD44;
                byte CSDigimonPartySlot2Memory = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2Memory.Value = CSDigimonPartySlot2Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CD58;
                byte[] CSDigimonPartySlot2EXP = savegameBr.ReadBytes(4);
                int CSDigimonPartySlot2EXPDec = BitConverter.ToInt32(CSDigimonPartySlot2EXP, 0);
                numericUpDownCSDigimonPartySlot2EXP.Value = CSDigimonPartySlot2EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CD50;
                byte CSDigimonPartySlot2CurrentLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2CurrentLVL.Value = CSDigimonPartySlot2CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CD52;
                byte CSDigimonPartySlot2MaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2MaxLVL.Value = CSDigimonPartySlot2MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CD54;
                byte CSDigimonPartySlot2ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2ExtraMaxLVL.Value = CSDigimonPartySlot2ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CD64;
                byte[] CSDigimonPartySlot2CurrentHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2CurrentHPDec = BitConverter.ToInt16(CSDigimonPartySlot2CurrentHP, 0);
                numericUpDownCSDigimonPartySlot2CurrentHP.Value = CSDigimonPartySlot2CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CD68;
                byte[] CSDigimonPartySlot2MaxHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2MaxHPDec = BitConverter.ToInt16(CSDigimonPartySlot2MaxHP, 0);
                numericUpDownCSDigimonPartySlot2MaxHP.Value = CSDigimonPartySlot2MaxHPDec * 100;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CD6C;
                byte[] CSDigimonPartySlot2BonusHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2BonusHPDec = BitConverter.ToInt16(CSDigimonPartySlot2BonusHP, 0);
                numericUpDownCSDigimonPartySlot2BonusHP.Value = CSDigimonPartySlot2BonusHPDec / 100;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CD70;
                byte[] CSDigimonPartySlot2CurrentSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2CurrentSPDec = BitConverter.ToInt16(CSDigimonPartySlot2CurrentSP, 0);
                numericUpDownCSDigimonPartySlot2CurrentSP.Value = CSDigimonPartySlot2CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CD74;
                byte[] CSDigimonPartySlot2MaxSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2MaxSPDec = BitConverter.ToInt16(CSDigimonPartySlot2MaxSP, 0);
                numericUpDownCSDigimonPartySlot2MaxSP.Value = CSDigimonPartySlot2MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CD78;
                byte[] CSDigimonPartySlot2BonusSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2BonusSPDec = BitConverter.ToInt16(CSDigimonPartySlot2BonusSP, 0);
                numericUpDownCSDigimonPartySlot2BonusSP.Value = CSDigimonPartySlot2BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CD7A;
                byte[] CSDigimonPartySlot2Attack = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2AttackDec = BitConverter.ToInt16(CSDigimonPartySlot2Attack, 0);
                numericUpDownCSDigimonPartySlot2Attack.Value = CSDigimonPartySlot2AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CD7C;
                byte[] CSDigimonPartySlot2BonusAttack = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2BonusAttackDec = BitConverter.ToInt16(CSDigimonPartySlot2BonusAttack, 0);
                numericUpDownCSDigimonPartySlot2BonusAttack.Value = CSDigimonPartySlot2BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CD7E;
                byte[] CSDigimonPartySlot2Defense = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2DefenseDec = BitConverter.ToInt16(CSDigimonPartySlot2Defense, 0);
                numericUpDownCSDigimonPartySlot2Defense.Value = CSDigimonPartySlot2DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CD80;
                byte[] CSDigimonPartySlot2BonusDefense = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2BonusDefenseDec = BitConverter.ToInt16(CSDigimonPartySlot2BonusDefense, 0);
                numericUpDownCSDigimonPartySlot2BonusDefense.Value = CSDigimonPartySlot2BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CD82;
                byte[] CSDigimonPartySlot2Intelligence = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2IntelligenceDec = BitConverter.ToInt16(CSDigimonPartySlot2Intelligence, 0);
                numericUpDownCSDigimonPartySlot2Intelligence.Value = CSDigimonPartySlot2IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CD84;
                byte[] CSDigimonPartySlot2BonusIntelligence = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2BonusIntelligenceDec = BitConverter.ToInt16(CSDigimonPartySlot2BonusIntelligence, 0);
                numericUpDownCSDigimonPartySlot2BonusIntelligence.Value = CSDigimonPartySlot2BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CD86;
                byte[] CSDigimonPartySlot2Speed = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2SpeedDec = BitConverter.ToInt16(CSDigimonPartySlot2Speed, 0);
                numericUpDownCSDigimonPartySlot2Speed.Value = CSDigimonPartySlot2SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CD88;
                byte[] CSDigimonPartySlot2BonusSpeed = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2BonusSpeedDec = BitConverter.ToInt16(CSDigimonPartySlot2BonusSpeed, 0);
                numericUpDownCSDigimonPartySlot2BonusSpeed.Value = CSDigimonPartySlot2BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CD8C;
                byte[] CSDigimonPartySlot2CAM = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2CAMDec = BitConverter.ToInt16(CSDigimonPartySlot2CAM, 0);
                numericUpDownCSDigimonPartySlot2CAM.Value = (CSDigimonPartySlot2CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CD8A;
                byte[] CSDigimonPartySlot2ABI = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2ABIDec = BitConverter.ToInt16(CSDigimonPartySlot2ABI, 0);
                numericUpDownCSDigimonPartySlot2ABI.Value = CSDigimonPartySlot2ABIDec;
                #endregion

                #region Equipment2
                //Equip 1
                savegameBr.BaseStream.Position = 0x3CF06;
                byte[] CSDigimonPartySlot2Equip1 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2Equip1Dec = BitConverter.ToInt16(CSDigimonPartySlot2Equip1, 0);
                comboBoxCSDigimonPartySlot2Equip1.Text = convertEquipIDtoString(CSDigimonPartySlot2Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3CF08;
                byte[] CSDigimonPartySlot2Equip2 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2Equip2Dec = BitConverter.ToInt16(CSDigimonPartySlot2Equip2, 0);
                comboBoxCSDigimonPartySlot2Equip2.Text = convertEquipIDtoString(CSDigimonPartySlot2Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3CF0A;
                byte[] CSDigimonPartySlot2Equip3 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2Equip3Dec = BitConverter.ToInt16(CSDigimonPartySlot2Equip3, 0);
                comboBoxCSDigimonPartySlot2Equip3.Text = convertEquipIDtoString(CSDigimonPartySlot2Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3CF0C;
                byte[] CSDigimonPartySlot2Accessory = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot2AccessoryDec = BitConverter.ToInt16(CSDigimonPartySlot2Accessory, 0);
                comboBoxCSDigimonPartySlot2Accessory.Text = convertAccessoryIDtoString(CSDigimonPartySlot2AccessoryDec);
                #endregion

                #region CurrentSkills2
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CD90;
                byte CSDigimonPartySlot2CurrentSkill1Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2CurrentSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill1Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CD94;
                    comboBoxCSDigimonPartySlot2CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CD98;
                byte CSDigimonPartySlot2CurrentSkill2Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2CurrentSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill2Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CD9C;
                    comboBoxCSDigimonPartySlot2CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CDA0;
                byte CSDigimonPartySlot2CurrentSkill3Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2CurrentSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill3Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CDA4;
                    comboBoxCSDigimonPartySlot2CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CDA8;
                byte CSDigimonPartySlot2CurrentSkill4Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2CurrentSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill4Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CDAC;
                    comboBoxCSDigimonPartySlot2CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CDB0;
                byte CSDigimonPartySlot2CurrentSkill5Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2CurrentSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill5Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CDB4;
                    comboBoxCSDigimonPartySlot2CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CDB8;
                byte CSDigimonPartySlot2CurrentSkill6Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2CurrentSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CDBC;
                    comboBoxCSDigimonPartySlot2CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills2
                //Learned Skill 1

                savegameBr.BaseStream.Position = 0x3CDC0;
                byte CSDigimonPartySlot2LearnedSkill1Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill1Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CDC4;
                    comboBoxCSDigimonPartySlot2LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3CDC8;
                byte CSDigimonPartySlot2LearnedSkill2Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill2Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CDCC;
                    comboBoxCSDigimonPartySlot2LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3CDD0;
                byte CSDigimonPartySlot2LearnedSkill3Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill3Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CDD4;
                    comboBoxCSDigimonPartySlot2LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3CDD8;
                byte CSDigimonPartySlot2LearnedSkill4Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill4Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CDDC;
                    comboBoxCSDigimonPartySlot2LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3CDE0;
                byte CSDigimonPartySlot2LearnedSkill5Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill5Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CDE4;
                    comboBoxCSDigimonPartySlot2LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3CDE8;
                byte CSDigimonPartySlot2LearnedSkill6Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill6Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CDEC;
                    comboBoxCSDigimonPartySlot2LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3CDF0;
                byte CSDigimonPartySlot2LearnedSkill7Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill7Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill7Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3CDF4;
                    comboBoxCSDigimonPartySlot2LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3CDF8;
                byte CSDigimonPartySlot2LearnedSkill8Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill8Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill8Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3CDFC;
                    comboBoxCSDigimonPartySlot2LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3CE00;
                byte CSDigimonPartySlot2LearnedSkill9Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill9Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill9Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3CE04;
                    comboBoxCSDigimonPartySlot2LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3CE08;
                byte CSDigimonPartySlot2LearnedSkill10Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill10Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill10Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3CE0C;
                    comboBoxCSDigimonPartySlot2LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3CE10;
                byte CSDigimonPartySlot2LearnedSkill11Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill11Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill11Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3CE14;
                    comboBoxCSDigimonPartySlot2LearnedSkill11.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3CE18;
                byte CSDigimonPartySlot2LearnedSkill12Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill12Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill12Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3CE1C;
                    comboBoxCSDigimonPartySlot2LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3CE20;
                byte CSDigimonPartySlot2LearnedSkill13Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill13Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill13Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3CE24;
                    comboBoxCSDigimonPartySlot2LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3CE28;
                byte CSDigimonPartySlot2LearnedSkill14Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill14Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill14Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3CE2C;
                    comboBoxCSDigimonPartySlot2LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3CE30;
                byte CSDigimonPartySlot2LearnedSkill15Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill15Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill15Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3CE34;
                    comboBoxCSDigimonPartySlot2LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3CE38;
                byte CSDigimonPartySlot2LearnedSkill16Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill16Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill16Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3CE3C;
                    comboBoxCSDigimonPartySlot2LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3CE40;
                byte CSDigimonPartySlot2LearnedSkill17Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill17Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill17Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3CE44;
                    comboBoxCSDigimonPartySlot2LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3CE48;
                byte CSDigimonPartySlot2LearnedSkill18Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill18Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill18Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3CE4C;
                    comboBoxCSDigimonPartySlot2LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3CE50;
                byte CSDigimonPartySlot2LearnedSkill19Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill19Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill19Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3CE54;
                    comboBoxCSDigimonPartySlot2LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3CE58;
                byte CSDigimonPartySlot2LearnedSkill20Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot2LearnedSkill20Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill20Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot2LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3CE5C;
                    comboBoxCSDigimonPartySlot2LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraitsCS(2);
            }

            else
            {
                checkBoxCSDigimonPartySlot2None.Checked = true;
            }
            #endregion

            //Read in third Digimon in party data
            #region DigimonPartySlot3
            #region Main3
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CF1C;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CF2C;
                byte[] CSDigimonPartySlot3ID = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3IDDec = BitConverter.ToInt16(CSDigimonPartySlot3ID, 0);
                comboBoxCSDigimonPartySlot3ID.Text = convertDigimonIDtoString(CSDigimonPartySlot3IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CF3C;
                byte[] CSDigimonPartySlot3Nickname = savegameBr.ReadBytes(17);
                string CSDigimonPartySlot3NicknameDec = Encoding.ASCII.GetString(CSDigimonPartySlot3Nickname);
                textBoxCSDigimonPartySlot3Nickname.Text = CSDigimonPartySlot3NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CF38;
                byte CSDigimonPartySlot3Digivolution = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Digivolution.Text = convertDigivolutionIDtoString(CSDigimonPartySlot3Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CF34;
                byte CSDigimonPartySlot3Type = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Type.Text = convertTypeIDtoString(CSDigimonPartySlot3Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CF30;
                byte CSDigimonPartySlot3Attribute = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Attribute.Text = convertAttributeIDtoString(CSDigimonPartySlot3Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CFA0;
                byte CSDigimonPartySlot3Personality = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Personality.Text = convertPersonalityIDtoString(CSDigimonPartySlot3Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3D140;
                byte CSDigimonPartySlot3SupportSkill = savegameBr.ReadByte();
                comboBoxCSDigmonPartySlot3SupportSkill.Text = convertsupportSkillsIDtoString(CSDigimonPartySlot3SupportSkill);
                #endregion

                #region Stats3
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3D144;
                byte CSDigimonPartySlot3EquipSlots = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3EquipSlots.Value = CSDigimonPartySlot3EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CF84;
                byte CSDigimonPartySlot3Memory = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3Memory.Value = CSDigimonPartySlot3Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CF98;
                byte[] CSDigimonPartySlot3EXP = savegameBr.ReadBytes(4);
                int CSDigimonPartySlot3EXPDec = BitConverter.ToInt32(CSDigimonPartySlot3EXP, 0);
                numericUpDownCSDigimonPartySlot3EXP.Value = CSDigimonPartySlot3EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CF90;
                byte CSDigimonPartySlot3CurrentLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3CurrentLVL.Value = CSDigimonPartySlot3CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CF92;
                byte CSDigimonPartySlot3MaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3MaxLVL.Value = CSDigimonPartySlot3MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CF94;
                byte CSDigimonPartySlot3ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3ExtraMaxLVL.Value = CSDigimonPartySlot3ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CFA4;
                byte[] CSDigimonPartySlot3CurrentHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3CurrentHPDec = BitConverter.ToInt16(CSDigimonPartySlot3CurrentHP, 0);
                numericUpDownCSDigimonPartySlot3CurrentHP.Value = CSDigimonPartySlot3CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CFA8;
                byte[] CSDigimonPartySlot3MaxHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3MaxHPDec = BitConverter.ToInt16(CSDigimonPartySlot3MaxHP, 0);
                numericUpDownCSDigimonPartySlot3MaxHP.Value = CSDigimonPartySlot3MaxHPDec * 100;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CFAC;
                byte[] CSDigimonPartySlot3BonusHP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3BonusHPDec = BitConverter.ToInt16(CSDigimonPartySlot3BonusHP, 0);
                numericUpDownCSDigimonPartySlot3BonusHP.Value = CSDigimonPartySlot3BonusHPDec / 100;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CFB0;
                byte[] CSDigimonPartySlot3CurrentSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3CurrentSPDec = BitConverter.ToInt16(CSDigimonPartySlot3CurrentSP, 0);
                numericUpDownCSDigimonPartySlot3CurrentSP.Value = CSDigimonPartySlot3CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CFB4;
                byte[] CSDigimonPartySlot3MaxSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3MaxSPDec = BitConverter.ToInt16(CSDigimonPartySlot3MaxSP, 0);
                numericUpDownCSDigimonPartySlot3MaxSP.Value = CSDigimonPartySlot3MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CFB8;
                byte[] CSDigimonPartySlot3BonusSP = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3BonusSPDec = BitConverter.ToInt16(CSDigimonPartySlot3BonusSP, 0);
                numericUpDownCSDigimonPartySlot3BonusSP.Value = CSDigimonPartySlot3BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CFBA;
                byte[] CSDigimonPartySlot3Attack = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3AttackDec = BitConverter.ToInt16(CSDigimonPartySlot3Attack, 0);
                numericUpDownCSDigimonPartySlot3Attack.Value = CSDigimonPartySlot3AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CFBC;
                byte[] CSDigimonPartySlot3BonusAttack = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3BonusAttackDec = BitConverter.ToInt16(CSDigimonPartySlot3BonusAttack, 0);
                numericUpDownCSDigimonPartySlot3BonusAttack.Value = CSDigimonPartySlot3BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CFBE;
                byte[] CSDigimonPartySlot3Defense = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3DefenseDec = BitConverter.ToInt16(CSDigimonPartySlot3Defense, 0);
                numericUpDownCSDigimonPartySlot3Defense.Value = CSDigimonPartySlot3DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CFC0;
                byte[] CSDigimonPartySlot3BonusDefense = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3BonusDefenseDec = BitConverter.ToInt16(CSDigimonPartySlot3BonusDefense, 0);
                numericUpDownCSDigimonPartySlot3BonusDefense.Value = CSDigimonPartySlot3BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CFC2;
                byte[] CSDigimonPartySlot3Intelligence = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3IntelligenceDec = BitConverter.ToInt16(CSDigimonPartySlot3Intelligence, 0);
                numericUpDownCSDigimonPartySlot3Intelligence.Value = CSDigimonPartySlot3IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CFC4;
                byte[] CSDigimonPartySlot3BonusIntelligence = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3BonusIntelligenceDec = BitConverter.ToInt16(CSDigimonPartySlot3BonusIntelligence, 0);
                numericUpDownCSDigimonPartySlot3BonusIntelligence.Value = CSDigimonPartySlot3BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CFC6;
                byte[] CSDigimonPartySlot3Speed = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3SpeedDec = BitConverter.ToInt16(CSDigimonPartySlot3Speed, 0);
                numericUpDownCSDigimonPartySlot3Speed.Value = CSDigimonPartySlot3SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CFC8;
                byte[] CSDigimonPartySlot3BonusSpeed = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3BonusSpeedDec = BitConverter.ToInt16(CSDigimonPartySlot3BonusSpeed, 0);
                numericUpDownCSDigimonPartySlot3BonusSpeed.Value = CSDigimonPartySlot3BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CFCC;
                byte[] CSDigimonPartySlot3CAM = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3CAMDec = BitConverter.ToInt16(CSDigimonPartySlot3CAM, 0);
                numericUpDownCSDigimonPartySlot3CAM.Value = (CSDigimonPartySlot3CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CFCA;
                byte[] CSDigimonPartySlot3ABI = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3ABIDec = BitConverter.ToInt16(CSDigimonPartySlot3ABI, 0);
                numericUpDownCSDigimonPartySlot3ABI.Value = CSDigimonPartySlot3ABIDec;
                #endregion

                #region Equipment3
                //Equip 1
                savegameBr.BaseStream.Position = 0x3D146;
                byte[] CSDigimonPartySlot3Equip1 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3Equip1Dec = BitConverter.ToInt16(CSDigimonPartySlot3Equip1, 0);
                comboBoxCSDigimonPartySlot3Equip1.Text = convertEquipIDtoString(CSDigimonPartySlot3Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3D148;
                byte[] CSDigimonPartySlot3Equip2 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3Equip2Dec = BitConverter.ToInt16(CSDigimonPartySlot3Equip2, 0);
                comboBoxCSDigimonPartySlot3Equip2.Text = convertEquipIDtoString(CSDigimonPartySlot3Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3D14A;
                byte[] CSDigimonPartySlot3Equip3 = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3Equip3Dec = BitConverter.ToInt16(CSDigimonPartySlot3Equip3, 0);
                comboBoxCSDigimonPartySlot3Equip3.Text = convertEquipIDtoString(CSDigimonPartySlot3Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3D14C;
                byte[] CSDigimonPartySlot3Accessory = savegameBr.ReadBytes(2);
                short CSDigimonPartySlot3AccessoryDec = BitConverter.ToInt16(CSDigimonPartySlot3Accessory, 0);
                comboBoxCSDigimonPartySlot3Accessory.Text = convertAccessoryIDtoString(CSDigimonPartySlot3AccessoryDec);
                #endregion

                #region CurrentSkills3
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CFD0;
                byte CSDigimonPartySlot3CurrentSkill1Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3CurrentSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill1Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CFD4;
                    comboBoxCSDigimonPartySlot3CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CFD8;
                byte CSDigimonPartySlot3CurrentSkill2Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3CurrentSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill2Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CFDC;
                    comboBoxCSDigimonPartySlot3CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CFE0;
                byte CSDigimonPartySlot3CurrentSkill3Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3CurrentSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill3Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CFE4;
                    comboBoxCSDigimonPartySlot3CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CFE8;
                byte CSDigimonPartySlot3CurrentSkill4Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3CurrentSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill4Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CFEC;
                    comboBoxCSDigimonPartySlot3CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CFF0;
                byte CSDigimonPartySlot3CurrentSkill5Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3CurrentSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill5Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CFF4;
                    comboBoxCSDigimonPartySlot3CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CFF8;
                byte CSDigimonPartySlot3CurrentSkill6Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3CurrentSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill6Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CFFC;
                    comboBoxCSDigimonPartySlot3CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills3
                //Learned Skill 1

                savegameBr.BaseStream.Position = 0x3D000;
                byte CSDigimonPartySlot3LearnedSkill1Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill1Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3D004;
                    comboBoxCSDigimonPartySlot3LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3D008;
                byte CSDigimonPartySlot3LearnedSkill2Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill2Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3D00C;
                    comboBoxCSDigimonPartySlot3LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3D010;
                byte CSDigimonPartySlot3LearnedSkill3Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill3Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3D014;
                    comboBoxCSDigimonPartySlot3LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3D018;
                byte CSDigimonPartySlot3LearnedSkill4Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill4Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3D01C;
                    comboBoxCSDigimonPartySlot3LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3D020;
                byte CSDigimonPartySlot3LearnedSkill5Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill5Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3D024;
                    comboBoxCSDigimonPartySlot3LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3D028;
                byte CSDigimonPartySlot3LearnedSkill6Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill6Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3D02C;
                    comboBoxCSDigimonPartySlot3LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3D030;
                byte CSDigimonPartySlot3LearnedSkill7Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill7Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill7Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3D034;
                    comboBoxCSDigimonPartySlot3LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3D038;
                byte CSDigimonPartySlot3LearnedSkill8Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill8Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill8Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3D03C;
                    comboBoxCSDigimonPartySlot3LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3D040;
                byte CSDigimonPartySlot3LearnedSkill9Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill9Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill9Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3D044;
                    comboBoxCSDigimonPartySlot3LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3D048;
                byte CSDigimonPartySlot3LearnedSkill10Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill10Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill10Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3D04C;
                    comboBoxCSDigimonPartySlot3LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3D050;
                byte CSDigimonPartySlot3LearnedSkill11Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill11Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill11Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3D054;
                    comboBoxCSDigimonPartySlot3LearnedSkill11.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3D058;
                byte CSDigimonPartySlot3LearnedSkill12Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill12Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill12Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3D05C;
                    comboBoxCSDigimonPartySlot3LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3D060;
                byte CSDigimonPartySlot3LearnedSkill13Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill13Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill13Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3D064;
                    comboBoxCSDigimonPartySlot3LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3D068;
                byte CSDigimonPartySlot3LearnedSkill14Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill14Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill14Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3D06C;
                    comboBoxCSDigimonPartySlot3LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3D070;
                byte CSDigimonPartySlot3LearnedSkill15Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill15Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill15Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3D074;
                    comboBoxCSDigimonPartySlot3LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3D078;
                byte CSDigimonPartySlot3LearnedSkill16Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill16Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill16Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3D07C;
                    comboBoxCSDigimonPartySlot3LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3D080;
                byte CSDigimonPartySlot3LearnedSkill17Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill17Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill17Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3D084;
                    comboBoxCSDigimonPartySlot3LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3D088;
                byte CSDigimonPartySlot3LearnedSkill18Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill18Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill18Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3D08C;
                    comboBoxCSDigimonPartySlot3LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3D090;
                byte CSDigimonPartySlot3LearnedSkill19Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill19Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill19Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3D094;
                    comboBoxCSDigimonPartySlot3LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3D098;
                byte CSDigimonPartySlot3LearnedSkill20Inherited = savegameBr.ReadByte();
                if (CSDigimonPartySlot3LearnedSkill20Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill20Inherited.Checked = Convert.ToBoolean(CSDigimonPartySlot3LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3D09C;
                    comboBoxCSDigimonPartySlot3LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraitsCS(3);
            }

            else
            {
                checkBoxCSDigimonPartySlot3None.Checked = true;
            }
            #endregion


            savegameBr.Close();
        }

        private void setDataCS()
        {
            FileStream saveOpen = new FileStream(savegame, FileMode.Open);
            BinaryWriter saveWrite = new BinaryWriter(saveOpen);

            //Save first Digimon In Party data
            #region DigimonPartySlot1
            #region Main1
            //ID
            byte[] CSDigimonPartySlot1IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxCSDigimonPartySlot1ID.Text));
            saveOpen.Position = 0x3CAAC;
            saveWrite.Write(CSDigimonPartySlot1IDSet);

            //Nickname
            byte[] CSDigimonPartySlot1NicknameSet = Encoding.ASCII.GetBytes(textBoxCSDigimonPartySlot1Nickname.Text);
            saveOpen.Position = 0x3CABC;
            saveWrite.Write(CSDigimonPartySlot1NicknameSet);
            if (CSDigimonPartySlot1NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - CSDigimonPartySlot1NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] CSDigimonPartySlot1DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxCSDigimonPartySlot1Digivolution.Text));
            saveOpen.Position = 0x3CAB8;
            saveWrite.Write(CSDigimonPartySlot1DigivolutionSet);

            //Type
            byte[] CSDigimonPartySlot1TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxCSDigimonPartySlot1Type.Text));
            saveOpen.Position = 0x3CAB4;
            saveWrite.Write(CSDigimonPartySlot1TypeSet);

            //Attribute
            byte[] CSDigimonPartySlot1AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxCSDigimonPartySlot1Attribute.Text));
            saveOpen.Position = 0x3CAB0;
            saveWrite.Write(CSDigimonPartySlot1AttributeSet);

            //Personality
            byte[] CSDigimonPartySlot1PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxCSDigimonPartySlot1Personality.Text));
            saveOpen.Position = 0x3CB20;
            saveWrite.Write(CSDigimonPartySlot1PersonalitySet);

            //Support Skills
            byte[] CSDigimonPartySlot1SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxCSDigmonPartySlot1SupportSkill.Text));
            saveOpen.Position = 0x3CCC0;
            saveWrite.Write(CSDigimonPartySlot1SupportSkillSet);
            #endregion

            #region Stats1
            //Equip Slots
            byte[] CSDigimonPartySlot1EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1EquipSlots.Value);
            saveOpen.Position = 0x3CCC4;
            saveWrite.Write(CSDigimonPartySlot1EquipSlotsSet);

            //Memory Use
            byte[] CSDigimonPartySlot1MemorySet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Memory.Value);
            saveOpen.Position = 0x3CB04;
            saveWrite.Write(CSDigimonPartySlot1MemorySet);

            //EXP
            byte[] CSDigimonPartySlot1EXPSet = BitConverter.GetBytes((int)numericUpDownCSDigimonPartySlot1EXP.Value);
            saveOpen.Position = 0x3CB18;
            saveWrite.Write(CSDigimonPartySlot1EXPSet);

            //Current LVL
            byte[] CSDigimonPartySlot1CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CurrentLVL.Value);
            saveOpen.Position = 0x3CB10;
            saveWrite.Write(CSDigimonPartySlot1CurrentLVLSet);

            //Max Level
            byte[] CSDigimonPartySlot1MaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1MaxLVL.Value);
            saveOpen.Position = 0x3CB12;
            saveWrite.Write(CSDigimonPartySlot1MaxLVLSet);

            //Extra Max Level
            byte[] CSDigimonPartySlot1ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CB14;
            saveWrite.Write(CSDigimonPartySlot1ExtraMaxLVLSet);

            //Current HP
            byte[] CSDigimonPartySlot1CurrentHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CurrentHP.Value);
            saveOpen.Position = 0x3CB24;
            saveWrite.Write(CSDigimonPartySlot1CurrentHPSet);

            //Max HP
            byte[] CSDigimonPartySlot1MaxHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1MaxHP.Value / 10);
            saveOpen.Position = 0x3CB28;
            saveWrite.Write(CSDigimonPartySlot1MaxHPSet);

            //Bonus HP
            byte[] CSDigimonPartySlot1BonusHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusHP.Value);
            saveOpen.Position = 0x3CB2C;
            saveWrite.Write(CSDigimonPartySlot1BonusHPSet);

            //Current SP
            byte[] CSDigimonPartySlot1CurrentSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CurrentSP.Value);
            saveOpen.Position = 0x3CB30;
            saveWrite.Write(CSDigimonPartySlot1CurrentSPSet);

            //Max SP
            byte[] CSDigimonPartySlot1MaxSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1MaxSP.Value);
            saveOpen.Position = 0x3CB34;
            saveWrite.Write(CSDigimonPartySlot1MaxSPSet);

            //Bonus SP
            byte[] CSDigimonPartySlot1BonusSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusSP.Value);
            saveOpen.Position = 0x3CB38;
            saveWrite.Write(CSDigimonPartySlot1BonusSPSet);

            //Attack
            byte[] CSDigimonPartySlot1AttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Attack.Value);
            saveOpen.Position = 0x3CB3A;
            saveWrite.Write(CSDigimonPartySlot1AttackSet);

            //Bonus Attack
            byte[] CSDigimonPartySlot1BonusAttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusAttack.Value);
            saveOpen.Position = 0x3CB3C;
            saveWrite.Write(CSDigimonPartySlot1BonusAttackSet);

            //Defense
            byte[] CSDigimonPartySlot1DefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Defense.Value);
            saveOpen.Position = 0x3CB3E;
            saveWrite.Write(CSDigimonPartySlot1DefenseSet);

            //Bonus Defense
            byte[] CSDigimonPartySlot1BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusDefense.Value);
            saveOpen.Position = 0x3CB40;
            saveWrite.Write(CSDigimonPartySlot1BonusDefenseSet);

            //Intelligence
            byte[] CSDigimonPartySlot1IntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Intelligence.Value);
            saveOpen.Position = 0x3CB42;
            saveWrite.Write(CSDigimonPartySlot1IntelligenceSet);

            //Bonus Intelligence
            byte[] CSDigimonPartySlot1BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusIntelligence.Value);
            saveOpen.Position = 0x3CB44;
            saveWrite.Write(CSDigimonPartySlot1BonusIntelligenceSet);

            //Speed
            byte[] CSDigimonPartySlot1SpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Speed.Value);
            saveOpen.Position = 0x3CB46;
            saveWrite.Write(CSDigimonPartySlot1SpeedSet);

            //Bonus Speed
            byte[] CSDigimonPartySlot1BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusSpeed.Value);
            saveOpen.Position = 0x3CB48;
            saveWrite.Write(CSDigimonPartySlot1BonusSpeedSet);

            //CAM
            byte[] CSDigimonPartySlot1CAMSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CAM.Value);
            saveOpen.Position = 0x3CB4C;
            saveWrite.Write(CSDigimonPartySlot1CAMSet);

            //ABI
            byte[] CSDigimonPartySlot1ABISet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1ABI.Value);
            saveOpen.Position = 0x3CB4A;
            saveWrite.Write(CSDigimonPartySlot1ABISet);
            #endregion

            #region Equipment1
            //Equip 1
            byte[] CSDigimonPartySlot1Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot1Equip1.Text));
            saveOpen.Position = 0x3CCC6;
            saveWrite.Write(CSDigimonPartySlot1Equip1Set);

            //Equip 2
            byte[] CSDigimonPartySlot1Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot1Equip2.Text));
            saveOpen.Position = 0x3CCC8;
            saveWrite.Write(CSDigimonPartySlot1Equip2Set);

            //Equip 3
            byte[] CSDigimonPartySlot1Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot1Equip3.Text));
            saveOpen.Position = 0x3CCCA;
            saveWrite.Write(CSDigimonPartySlot1Equip3Set);

            //Accessory
            byte[] CSDigimonPartySlot1AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxCSDigimonPartySlot1Accessory.Text));
            saveOpen.Position = 0x3CCCC;
            saveWrite.Write(CSDigimonPartySlot1AccessorySet);
            #endregion

            #region CurrentSkills1
            //Current Skill 1
            saveOpen.Position = 0x3CB50;
            if (checkBoxCSDigimonPartySlot1CurrentSkill1None.Checked || comboBoxCSDigimonPartySlot1CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB54;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1CurrentSkill1Inherited.Checked);
                byte[] CSDigimonPartySlot1CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill1.Text));
                saveOpen.Position = 0x3CB54;
                saveWrite.Write(CSDigimonPartySlot1CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x3CB58;
            if (checkBoxCSDigimonPartySlot1CurrentSkill2None.Checked || comboBoxCSDigimonPartySlot1CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB5C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1CurrentSkill2Inherited.Checked);
                byte[] CSDigimonPartySlot1CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill2.Text));
                saveOpen.Position = 0x3CB5C;
                saveWrite.Write(CSDigimonPartySlot1CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x3CB60;
            if (checkBoxCSDigimonPartySlot1CurrentSkill3None.Checked || comboBoxCSDigimonPartySlot1CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB64;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1CurrentSkill3Inherited.Checked);
                byte[] CSDigimonPartySlot1CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill3.Text));
                saveOpen.Position = 0x3CB64;
                saveWrite.Write(CSDigimonPartySlot1CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x3CB68;
            if (checkBoxCSDigimonPartySlot1CurrentSkill4None.Checked || comboBoxCSDigimonPartySlot1CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB6C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1CurrentSkill4Inherited.Checked);
                byte[] CSDigimonPartySlot1CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill4.Text));
                saveOpen.Position = 0x3CB6C;
                saveWrite.Write(CSDigimonPartySlot1CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x3CB70;
            if (checkBoxCSDigimonPartySlot1CurrentSkill5None.Checked || comboBoxCSDigimonPartySlot1CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB74;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1CurrentSkill5Inherited.Checked);
                byte[] CSDigimonPartySlot1CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill5.Text));
                saveOpen.Position = 0x3CB74;
                saveWrite.Write(CSDigimonPartySlot1CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x3CB78;
            if (checkBoxCSDigimonPartySlot1CurrentSkill6None.Checked || comboBoxCSDigimonPartySlot1CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB7C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1CurrentSkill6Inherited.Checked);
                byte[] CSDigimonPartySlot1CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill6.Text));
                saveOpen.Position = 0x3CB7C;
                saveWrite.Write(CSDigimonPartySlot1CurrentSkill6Set);
            }

            #endregion

            #region LearnedSkills1
            //Learned Skill 1
            saveOpen.Position = 0x3CB80;
            if (checkBoxCSDigimonPartySlot1LearnedSkill1None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB84;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill1Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill1.Text));
                saveOpen.Position = 0x3CB84;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill1Set);
            }

            //Learned Skill 2
            saveOpen.Position = 0x3CB88;
            if (checkBoxCSDigimonPartySlot1LearnedSkill2None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB8C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill2Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill2.Text));
                saveOpen.Position = 0x3CB8C;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill2Set);
            }

            //Learned Skill 3
            saveOpen.Position = 0x3CB90;
            if (checkBoxCSDigimonPartySlot1LearnedSkill3None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB94;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill3Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill3.Text));
                saveOpen.Position = 0x3CB94;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill3Set);
            }

            //Learned Skill 4
            saveOpen.Position = 0x3CB98;
            if (checkBoxCSDigimonPartySlot1LearnedSkill4None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB9C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill4Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill4.Text));
                saveOpen.Position = 0x3CB9C;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill4Set);
            }

            //Learned Skill 5
            saveOpen.Position = 0x3CBA0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill5None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBA4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill5Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill5.Text));
                saveOpen.Position = 0x3CBA4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill5Set);
            }

            //Learned Skill 6
            saveOpen.Position = 0x3CBA8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill6None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBAC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill6Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill6.Text));
                saveOpen.Position = 0x3CBAC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill6Set);
            }

            //Learned Skill 7
            saveOpen.Position = 0x3CBB0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill7None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill7.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBB4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill7Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill7Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill7.Text));
                saveOpen.Position = 0x3CBB4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill7Set);
            }

            //Learned Skill 8
            saveOpen.Position = 0x3CBB8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill8None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill8.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBBC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill8Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill8Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill8.Text));
                saveOpen.Position = 0x3CBBC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill8Set);
            }

            //Learned Skill 9
            saveOpen.Position = 0x3CBC0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill9None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill9.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBC4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill9Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill9Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill9.Text));
                saveOpen.Position = 0x3CBC4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill9Set);
            }

            //Learned Skill 10
            saveOpen.Position = 0x3CBC8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill10None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill10.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBCC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill10Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill10Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill10.Text));
                saveOpen.Position = 0x3CBCC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill10Set);
            }

            //Learned Skill 11
            saveOpen.Position = 0x3CBD0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill11None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill11.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBD4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill11Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill11Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill11.Text));
                saveOpen.Position = 0x3CBD4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill11Set);
            }

            //Learned Skill 12
            saveOpen.Position = 0x3CBD8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill12None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill12.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBDC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill12Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill12Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill12.Text));
                saveOpen.Position = 0x3CBDC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill12Set);
            }

            //Learned Skill 13
            saveOpen.Position = 0x3CBE0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill13None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill13.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBE4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill13Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill13Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill13.Text));
                saveOpen.Position = 0x3CBE4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill13Set);
            }

            //Learned Skill 14
            saveOpen.Position = 0x3CBE8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill14None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill14.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBEC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill14Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill14Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill14.Text));
                saveOpen.Position = 0x3CBEC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill14Set);
            }

            //Learned Skill 15
            saveOpen.Position = 0x3CBF0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill15None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill15.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBE4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill15Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill15Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill15.Text));
                saveOpen.Position = 0x3CBE4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill15Set);
            }

            //Learned Skill 16
            saveOpen.Position = 0x3CBE8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill16None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill16.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBEC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill16Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill16Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill16.Text));
                saveOpen.Position = 0x3CBEC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill16Set);
            }

            //Learned Skill 17
            saveOpen.Position = 0x3CBF0;
            if (checkBoxCSDigimonPartySlot1LearnedSkill17None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill17.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBF4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill17Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill17Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill17.Text));
                saveOpen.Position = 0x3CBF4;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill17Set);
            }

            //Learned Skill 18
            saveOpen.Position = 0x3CBF8;
            if (checkBoxCSDigimonPartySlot1LearnedSkill18None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill18.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBFC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill18Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill18Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill18.Text));
                saveOpen.Position = 0x3CBFC;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill18Set);
            }

            //Learned Skill 19
            saveOpen.Position = 0x3CC00;
            if (checkBoxCSDigimonPartySlot1LearnedSkill19None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill19.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CC04;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill19Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill19Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill19.Text));
                saveOpen.Position = 0x3CC04;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill19Set);
            }

            //Learned Skill 20
            saveOpen.Position = 0x3CC08;
            if (checkBoxCSDigimonPartySlot1LearnedSkill20None.Checked || comboBoxCSDigimonPartySlot1LearnedSkill20.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CC0C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot1LearnedSkill20Inherited.Checked);
                byte[] CSDigimonPartySlot1LearnedSkill20Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1LearnedSkill20.Text));
                saveOpen.Position = 0x3CC0C;
                saveWrite.Write(CSDigimonPartySlot1LearnedSkill20Set);
            }

            #endregion
            #endregion
            //Save second Digimon In Party data
            #region DigimonPartySlot2
            #region Main2
            //ID
            byte[] CSDigimonPartySlot2IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxCSDigimonPartySlot2ID.Text));
            saveOpen.Position = 0x3CCEC;
            saveWrite.Write(CSDigimonPartySlot2IDSet);

            //Nickname
            byte[] CSDigimonPartySlot2NicknameSet = Encoding.ASCII.GetBytes(textBoxCSDigimonPartySlot2Nickname.Text);
            saveOpen.Position = 0x3CCFC;
            saveWrite.Write(CSDigimonPartySlot2NicknameSet);
            if (CSDigimonPartySlot2NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - CSDigimonPartySlot2NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] CSDigimonPartySlot2DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxCSDigimonPartySlot2Digivolution.Text));
            saveOpen.Position = 0x3CCF8;
            saveWrite.Write(CSDigimonPartySlot2DigivolutionSet);

            //Type
            byte[] CSDigimonPartySlot2TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxCSDigimonPartySlot2Type.Text));
            saveOpen.Position = 0x3CCF4;
            saveWrite.Write(CSDigimonPartySlot2TypeSet);

            //Attribute
            byte[] CSDigimonPartySlot2AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxCSDigimonPartySlot2Attribute.Text));
            saveOpen.Position = 0x3CCF0;
            saveWrite.Write(CSDigimonPartySlot2AttributeSet);

            //Personality
            byte[] CSDigimonPartySlot2PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxCSDigimonPartySlot2Personality.Text));
            saveOpen.Position = 0x3CD60;
            saveWrite.Write(CSDigimonPartySlot2PersonalitySet);

            //Support Skills
            byte[] CSDigimonPartySlot2SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxCSDigmonPartySlot2SupportSkill.Text));
            saveOpen.Position = 0x3CF00;
            saveWrite.Write(CSDigimonPartySlot2SupportSkillSet);
            #endregion

            #region Stats2
            //Equip Slots
            byte[] CSDigimonPartySlot2EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2EquipSlots.Value);
            saveOpen.Position = 0x3CF04;
            saveWrite.Write(CSDigimonPartySlot2EquipSlotsSet);

            //Memory Use
            byte[] CSDigimonPartySlot2MemorySet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Memory.Value);
            saveOpen.Position = 0x3CD44;
            saveWrite.Write(CSDigimonPartySlot2MemorySet);

            //EXP
            byte[] CSDigimonPartySlot2EXPSet = BitConverter.GetBytes((int)numericUpDownCSDigimonPartySlot2EXP.Value);
            saveOpen.Position = 0x3CD58;
            saveWrite.Write(CSDigimonPartySlot2EXPSet);

            //Current LVL
            byte[] CSDigimonPartySlot2CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CurrentLVL.Value);
            saveOpen.Position = 0x3CD50;
            saveWrite.Write(CSDigimonPartySlot2CurrentLVLSet);

            //Max Level
            byte[] CSDigimonPartySlot2MaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2MaxLVL.Value);
            saveOpen.Position = 0x3CD52;
            saveWrite.Write(CSDigimonPartySlot2MaxLVLSet);

            //Extra Max Level
            byte[] CSDigimonPartySlot2ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CD54;
            saveWrite.Write(CSDigimonPartySlot2ExtraMaxLVLSet);

            //Current HP
            byte[] CSDigimonPartySlot2CurrentHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CurrentHP.Value);
            saveOpen.Position = 0x3CD64;
            saveWrite.Write(CSDigimonPartySlot2CurrentHPSet);

            //Max HP
            byte[] CSDigimonPartySlot2MaxHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2MaxHP.Value / 10);
            saveOpen.Position = 0x3CD68;
            saveWrite.Write(CSDigimonPartySlot2MaxHPSet);

            //Bonus HP
            byte[] CSDigimonPartySlot2BonusHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusHP.Value);
            saveOpen.Position = 0x3CD6C;
            saveWrite.Write(CSDigimonPartySlot2BonusHPSet);

            //Current SP
            byte[] CSDigimonPartySlot2CurrentSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CurrentSP.Value);
            saveOpen.Position = 0x3CD70;
            saveWrite.Write(CSDigimonPartySlot2CurrentSPSet);

            //Max SP
            byte[] CSDigimonPartySlot2MaxSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2MaxSP.Value);
            saveOpen.Position = 0x3CD74;
            saveWrite.Write(CSDigimonPartySlot2MaxSPSet);

            //Bonus SP
            byte[] CSDigimonPartySlot2BonusSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusSP.Value);
            saveOpen.Position = 0x3CD78;
            saveWrite.Write(CSDigimonPartySlot2BonusSPSet);

            //Attack
            byte[] CSDigimonPartySlot2AttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Attack.Value);
            saveOpen.Position = 0x3CD7A;
            saveWrite.Write(CSDigimonPartySlot2AttackSet);

            //Bonus Attack
            byte[] CSDigimonPartySlot2BonusAttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusAttack.Value);
            saveOpen.Position = 0x3CD7C;
            saveWrite.Write(CSDigimonPartySlot2BonusAttackSet);

            //Defense
            byte[] CSDigimonPartySlot2DefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Defense.Value);
            saveOpen.Position = 0x3CD7E;
            saveWrite.Write(CSDigimonPartySlot2DefenseSet);

            //Bonus Defense
            byte[] CSDigimonPartySlot2BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusDefense.Value);
            saveOpen.Position = 0x3CD80;
            saveWrite.Write(CSDigimonPartySlot2BonusDefenseSet);

            //Intelligence
            byte[] CSDigimonPartySlot2IntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Intelligence.Value);
            saveOpen.Position = 0x3CD82;
            saveWrite.Write(CSDigimonPartySlot2IntelligenceSet);

            //Bonus Intelligence
            byte[] CSDigimonPartySlot2BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusIntelligence.Value);
            saveOpen.Position = 0x3CD84;
            saveWrite.Write(CSDigimonPartySlot2BonusIntelligenceSet);

            //Speed
            byte[] CSDigimonPartySlot2SpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Speed.Value);
            saveOpen.Position = 0x3CD86;
            saveWrite.Write(CSDigimonPartySlot2SpeedSet);

            //Bonus Speed
            byte[] CSDigimonPartySlot2BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusSpeed.Value);
            saveOpen.Position = 0x3CD88;
            saveWrite.Write(CSDigimonPartySlot2BonusSpeedSet);

            //CAM
            byte[] CSDigimonPartySlot2CAMSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CAM.Value);
            saveOpen.Position = 0x3CD8C;
            saveWrite.Write(CSDigimonPartySlot2CAMSet);

            //ABI
            byte[] CSDigimonPartySlot2ABISet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2ABI.Value);
            saveOpen.Position = 0x3CD8A;
            saveWrite.Write(CSDigimonPartySlot2ABISet);
            #endregion

            #region Equipment2
            //Equip 1
            byte[] CSDigimonPartySlot2Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot2Equip1.Text));
            saveOpen.Position = 0x3CF06;
            saveWrite.Write(CSDigimonPartySlot2Equip1Set);

            //Equip 2
            byte[] CSDigimonPartySlot2Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot2Equip2.Text));
            saveOpen.Position = 0x3CF08;
            saveWrite.Write(CSDigimonPartySlot2Equip2Set);

            //Equip 3
            byte[] CSDigimonPartySlot2Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot2Equip3.Text));
            saveOpen.Position = 0x3CF0A;
            saveWrite.Write(CSDigimonPartySlot2Equip3Set);

            //Accessory
            byte[] CSDigimonPartySlot2AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxCSDigimonPartySlot2Accessory.Text));
            saveOpen.Position = 0x3CF0C;
            saveWrite.Write(CSDigimonPartySlot2AccessorySet);
            #endregion

            #region CurrentSkills2
            //Current Skill 1
            saveOpen.Position = 0x3CD90;
            if (checkBoxCSDigimonPartySlot2CurrentSkill1None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CD94;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill1Inherited.Checked);
                byte[] CSDigimonPartySlot2CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill1.Text));
                saveOpen.Position = 0x3CD94;
                saveWrite.Write(CSDigimonPartySlot2CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x3CD98;
            if (checkBoxCSDigimonPartySlot2CurrentSkill2None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CD9C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill2Inherited.Checked);
                byte[] CSDigimonPartySlot2CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill2.Text));
                saveOpen.Position = 0x3CD9C;
                saveWrite.Write(CSDigimonPartySlot2CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x3CDA0;
            if (checkBoxCSDigimonPartySlot2CurrentSkill3None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDA4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill3Inherited.Checked);
                byte[] CSDigimonPartySlot2CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill3.Text));
                saveOpen.Position = 0x3CDA4;
                saveWrite.Write(CSDigimonPartySlot2CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x3CDA8;
            if (checkBoxCSDigimonPartySlot2CurrentSkill4None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDAC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill4Inherited.Checked);
                byte[] CSDigimonPartySlot2CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill4.Text));
                saveOpen.Position = 0x3CDAC;
                saveWrite.Write(CSDigimonPartySlot2CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x3CDB0;
            if (checkBoxCSDigimonPartySlot2CurrentSkill5None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDB4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill5Inherited.Checked);
                byte[] CSDigimonPartySlot2CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill5.Text));
                saveOpen.Position = 0x3CDB4;
                saveWrite.Write(CSDigimonPartySlot2CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x3CDB8;
            if (checkBoxCSDigimonPartySlot2CurrentSkill6None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDBC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Checked);
                byte[] CSDigimonPartySlot2CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill6.Text));
                saveOpen.Position = 0x3CDBC;
                saveWrite.Write(CSDigimonPartySlot2CurrentSkill6Set);
            }

            #endregion

            #region LearnedSkills2
            //Learned Skill 1
            saveOpen.Position = 0x3CDC0;
            if (checkBoxCSDigimonPartySlot2LearnedSkill1None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDC4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill1Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill1.Text));
                saveOpen.Position = 0x3CDC4;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill1Set);
            }

            //Learned Skill 2
            saveOpen.Position = 0x3CDC8;
            if (checkBoxCSDigimonPartySlot2LearnedSkill2None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDCC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill2Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill2.Text));
                saveOpen.Position = 0x3CDCC;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill2Set);
            }

            //Learned Skill 3
            saveOpen.Position = 0x3CDD0;
            if (checkBoxCSDigimonPartySlot2LearnedSkill3None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDD4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill3Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill3.Text));
                saveOpen.Position = 0x3CDD4;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill3Set);
            }

            //Learned Skill 4
            saveOpen.Position = 0x3CDD8;
            if (checkBoxCSDigimonPartySlot2LearnedSkill4None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDDC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill4Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill4.Text));
                saveOpen.Position = 0x3CDDC;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill4Set);
            }

            //Learned Skill 5
            saveOpen.Position = 0x3CDE0;
            if (checkBoxCSDigimonPartySlot2LearnedSkill5None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDE4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill5Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill5.Text));
                saveOpen.Position = 0x3CDE4;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill5Set);
            }

            //Learned Skill 6
            saveOpen.Position = 0x3CDE8;
            if (checkBoxCSDigimonPartySlot2LearnedSkill6None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDEC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill6Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill6.Text));
                saveOpen.Position = 0x3CDEC;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill6Set);
            }

            //Learned Skill 7
            saveOpen.Position = 0x3CDF0;
            if (checkBoxCSDigimonPartySlot2LearnedSkill7None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill7.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDF4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill7Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill7Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill7.Text));
                saveOpen.Position = 0x3CDF4;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill7Set);
            }

            //Learned Skill 8
            saveOpen.Position = 0x3CDF8;
            if (checkBoxCSDigimonPartySlot2LearnedSkill8None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill8.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDFC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill8Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill8Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill8.Text));
                saveOpen.Position = 0x3CDFC;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill8Set);
            }

            //Learned Skill 9
            saveOpen.Position = 0x3CE00;
            if (checkBoxCSDigimonPartySlot2LearnedSkill9None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill9.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE04;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill9Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill9Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill9.Text));
                saveOpen.Position = 0x3CE04;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill9Set);
            }

            //Learned Skill 10
            saveOpen.Position = 0x3CE08;
            if (checkBoxCSDigimonPartySlot2LearnedSkill10None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill10.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE0C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill10Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill10Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill10.Text));
                saveOpen.Position = 0x3CE0C;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill10Set);
            }

            //Learned Skill 11
            saveOpen.Position = 0x3CE10;
            if (checkBoxCSDigimonPartySlot2LearnedSkill11None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill11.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE14;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill11Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill11Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill11.Text));
                saveOpen.Position = 0x3CE14;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill11Set);
            }

            //Learned Skill 12
            saveOpen.Position = 0x3CE18;
            if (checkBoxCSDigimonPartySlot2LearnedSkill12None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill12.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE1C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill12Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill12Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill12.Text));
                saveOpen.Position = 0x3CE1C;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill12Set);
            }

            //Learned Skill 13
            saveOpen.Position = 0x3CE20;
            if (checkBoxCSDigimonPartySlot2LearnedSkill13None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill13.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE24;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill13Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill13Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill13.Text));
                saveOpen.Position = 0x3CE24;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill13Set);
            }

            //Learned Skill 14
            saveOpen.Position = 0x3CE28;
            if (checkBoxCSDigimonPartySlot2LearnedSkill14None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill14.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE2C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill14Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill14Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill14.Text));
                saveOpen.Position = 0x3CE2C;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill14Set);
            }

            //Learned Skill 15
            saveOpen.Position = 0x3CE30;
            if (checkBoxCSDigimonPartySlot2LearnedSkill15None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill15.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE34;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill15Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill15Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill15.Text));
                saveOpen.Position = 0x3CE34;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill15Set);
            }

            //Learned Skill 16
            saveOpen.Position = 0x3CE38;
            if (checkBoxCSDigimonPartySlot2LearnedSkill16None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill16.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE3C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill16Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill16Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill16.Text));
                saveOpen.Position = 0x3CE3C;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill16Set);
            }

            //Learned Skill 17
            saveOpen.Position = 0x3CE40;
            if (checkBoxCSDigimonPartySlot2LearnedSkill17None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill17.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE44;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill17Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill17Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill17.Text));
                saveOpen.Position = 0x3CE44;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill17Set);
            }

            //Learned Skill 18
            saveOpen.Position = 0x3CE48;
            if (checkBoxCSDigimonPartySlot2LearnedSkill18None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill18.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE4C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill18Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill18Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill18.Text));
                saveOpen.Position = 0x3CE4C;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill18Set);
            }

            //Learned Skill 19
            saveOpen.Position = 0x3CE50;
            if (checkBoxCSDigimonPartySlot2LearnedSkill19None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill19.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE54;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill19Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill19Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill19.Text));
                saveOpen.Position = 0x3CE54;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill19Set);
            }

            //Learned Skill 20
            saveOpen.Position = 0x3CE58;
            if (checkBoxCSDigimonPartySlot2LearnedSkill20None.Checked || comboBoxCSDigimonPartySlot2LearnedSkill20.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE5C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2LearnedSkill20Inherited.Checked);
                byte[] CSDigimonPartySlot2LearnedSkill20Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2LearnedSkill20.Text));
                saveOpen.Position = 0x3CE5C;
                saveWrite.Write(CSDigimonPartySlot2LearnedSkill20Set);
            }

            #endregion

            //Save third Digimon In Party data
            #region DigimonPartySlot3
            #region Main3
            //ID
            byte[] CSDigimonPartySlot3IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxCSDigimonPartySlot3ID.Text));
            saveOpen.Position = 0x3CF2C;
            saveWrite.Write(CSDigimonPartySlot3IDSet);

            //Nickname
            byte[] CSDigimonPartySlot3NicknameSet = Encoding.ASCII.GetBytes(textBoxCSDigimonPartySlot3Nickname.Text);
            saveOpen.Position = 0x3CF3C;
            saveWrite.Write(CSDigimonPartySlot3NicknameSet);
            if (CSDigimonPartySlot3NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - CSDigimonPartySlot3NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] CSDigimonPartySlot3DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxCSDigimonPartySlot3Digivolution.Text));
            saveOpen.Position = 0x3CF38;
            saveWrite.Write(CSDigimonPartySlot3DigivolutionSet);

            //Type
            byte[] CSDigimonPartySlot3TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxCSDigimonPartySlot3Type.Text));
            saveOpen.Position = 0x3CF34;
            saveWrite.Write(CSDigimonPartySlot3TypeSet);

            //Attribute
            byte[] CSDigimonPartySlot3AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxCSDigimonPartySlot3Attribute.Text));
            saveOpen.Position = 0x3CF30;
            saveWrite.Write(CSDigimonPartySlot3AttributeSet);

            //Personality
            byte[] CSDigimonPartySlot3PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxCSDigimonPartySlot3Personality.Text));
            saveOpen.Position = 0x3CFA0;
            saveWrite.Write(CSDigimonPartySlot3PersonalitySet);

            //Support Skills
            byte[] CSDigimonPartySlot3SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxCSDigmonPartySlot3SupportSkill.Text));
            saveOpen.Position = 0x3D140;
            saveWrite.Write(CSDigimonPartySlot3SupportSkillSet);
            #endregion

            #region Stats2
            //Equip Slots
            byte[] CSDigimonPartySlot3EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3EquipSlots.Value);
            saveOpen.Position = 0x3D144;
            saveWrite.Write(CSDigimonPartySlot3EquipSlotsSet);

            //Memory Use
            byte[] CSDigimonPartySlot3MemorySet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3Memory.Value);
            saveOpen.Position = 0x3CF84;
            saveWrite.Write(CSDigimonPartySlot3MemorySet);

            //EXP
            byte[] CSDigimonPartySlot3EXPSet = BitConverter.GetBytes((int)numericUpDownCSDigimonPartySlot3EXP.Value);
            saveOpen.Position = 0x3CF98;
            saveWrite.Write(CSDigimonPartySlot3EXPSet);

            //Current LVL
            byte[] CSDigimonPartySlot3CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3CurrentLVL.Value);
            saveOpen.Position = 0x3CF90;
            saveWrite.Write(CSDigimonPartySlot3CurrentLVLSet);

            //Max Level
            byte[] CSDigimonPartySlot3MaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3MaxLVL.Value);
            saveOpen.Position = 0x3CF92;
            saveWrite.Write(CSDigimonPartySlot3MaxLVLSet);

            //Extra Max Level
            byte[] CSDigimonPartySlot3ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CF94;
            saveWrite.Write(CSDigimonPartySlot3ExtraMaxLVLSet);

            //Current HP
            byte[] CSDigimonPartySlot3CurrentHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3CurrentHP.Value);
            saveOpen.Position = 0x3CFA4;
            saveWrite.Write(CSDigimonPartySlot3CurrentHPSet);

            //Max HP
            byte[] CSDigimonPartySlot3MaxHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3MaxHP.Value / 10);
            saveOpen.Position = 0x3CFA8;
            saveWrite.Write(CSDigimonPartySlot3MaxHPSet);

            //Bonus HP
            byte[] CSDigimonPartySlot3BonusHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3BonusHP.Value);
            saveOpen.Position = 0x3CFAC;
            saveWrite.Write(CSDigimonPartySlot3BonusHPSet);

            //Current SP
            byte[] CSDigimonPartySlot3CurrentSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3CurrentSP.Value);
            saveOpen.Position = 0x3CFB0;
            saveWrite.Write(CSDigimonPartySlot3CurrentSPSet);

            //Max SP
            byte[] CSDigimonPartySlot3MaxSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3MaxSP.Value);
            saveOpen.Position = 0x3CFB4;
            saveWrite.Write(CSDigimonPartySlot3MaxSPSet);

            //Bonus SP
            byte[] CSDigimonPartySlot3BonusSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3BonusSP.Value);
            saveOpen.Position = 0x3CFB8;
            saveWrite.Write(CSDigimonPartySlot3BonusSPSet);

            //Attack
            byte[] CSDigimonPartySlot3AttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3Attack.Value);
            saveOpen.Position = 0x3CFBA;
            saveWrite.Write(CSDigimonPartySlot3AttackSet);

            //Bonus Attack
            byte[] CSDigimonPartySlot3BonusAttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3BonusAttack.Value);
            saveOpen.Position = 0x3CFBC;
            saveWrite.Write(CSDigimonPartySlot3BonusAttackSet);

            //Defense
            byte[] CSDigimonPartySlot3DefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3Defense.Value);
            saveOpen.Position = 0x3CFBE;
            saveWrite.Write(CSDigimonPartySlot3DefenseSet);

            //Bonus Defense
            byte[] CSDigimonPartySlot3BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3BonusDefense.Value);
            saveOpen.Position = 0x3CFC0;
            saveWrite.Write(CSDigimonPartySlot3BonusDefenseSet);

            //Intelligence
            byte[] CSDigimonPartySlot3IntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3Intelligence.Value);
            saveOpen.Position = 0x3CFC2;
            saveWrite.Write(CSDigimonPartySlot3IntelligenceSet);

            //Bonus Intelligence
            byte[] CSDigimonPartySlot3BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3BonusIntelligence.Value);
            saveOpen.Position = 0x3CFC4;
            saveWrite.Write(CSDigimonPartySlot3BonusIntelligenceSet);

            //Speed
            byte[] CSDigimonPartySlot3SpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3Speed.Value);
            saveOpen.Position = 0x3CFC6;
            saveWrite.Write(CSDigimonPartySlot3SpeedSet);

            //Bonus Speed
            byte[] CSDigimonPartySlot3BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3BonusSpeed.Value);
            saveOpen.Position = 0x3CFC8;
            saveWrite.Write(CSDigimonPartySlot3BonusSpeedSet);

            //CAM
            byte[] CSDigimonPartySlot3CAMSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3CAM.Value);
            saveOpen.Position = 0x3CFCC;
            saveWrite.Write(CSDigimonPartySlot3CAMSet);

            //ABI
            byte[] CSDigimonPartySlot3ABISet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot3ABI.Value);
            saveOpen.Position = 0x3CFCA;
            saveWrite.Write(CSDigimonPartySlot3ABISet);
            #endregion

            #region Equipment2
            //Equip 1
            byte[] CSDigimonPartySlot3Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot3Equip1.Text));
            saveOpen.Position = 0x3D146;
            saveWrite.Write(CSDigimonPartySlot3Equip1Set);

            //Equip 2
            byte[] CSDigimonPartySlot3Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot3Equip2.Text));
            saveOpen.Position = 0x3D148;
            saveWrite.Write(CSDigimonPartySlot3Equip2Set);

            //Equip 3
            byte[] CSDigimonPartySlot3Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot3Equip3.Text));
            saveOpen.Position = 0x3D14A;
            saveWrite.Write(CSDigimonPartySlot3Equip3Set);

            //Accessory
            byte[] CSDigimonPartySlot3AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxCSDigimonPartySlot3Accessory.Text));
            saveOpen.Position = 0x3D14C;
            saveWrite.Write(CSDigimonPartySlot3AccessorySet);
            #endregion

            #region CurrentSkills2
            //Current Skill 1
            saveOpen.Position = 0x3CFD0;
            if (checkBoxCSDigimonPartySlot3CurrentSkill1None.Checked || comboBoxCSDigimonPartySlot3CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFD4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3CurrentSkill1Inherited.Checked);
                byte[] CSDigimonPartySlot3CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3CurrentSkill1.Text));
                saveOpen.Position = 0x3CFD4;
                saveWrite.Write(CSDigimonPartySlot3CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x3CFD8;
            if (checkBoxCSDigimonPartySlot3CurrentSkill2None.Checked || comboBoxCSDigimonPartySlot3CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFDC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3CurrentSkill2Inherited.Checked);
                byte[] CSDigimonPartySlot3CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3CurrentSkill2.Text));
                saveOpen.Position = 0x3CFDC;
                saveWrite.Write(CSDigimonPartySlot3CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x3CFE0;
            if (checkBoxCSDigimonPartySlot3CurrentSkill3None.Checked || comboBoxCSDigimonPartySlot3CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFE4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3CurrentSkill3Inherited.Checked);
                byte[] CSDigimonPartySlot3CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3CurrentSkill3.Text));
                saveOpen.Position = 0x3CFE4;
                saveWrite.Write(CSDigimonPartySlot3CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x3CFE8;
            if (checkBoxCSDigimonPartySlot3CurrentSkill4None.Checked || comboBoxCSDigimonPartySlot3CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFEC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3CurrentSkill4Inherited.Checked);
                byte[] CSDigimonPartySlot3CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3CurrentSkill4.Text));
                saveOpen.Position = 0x3CFEC;
                saveWrite.Write(CSDigimonPartySlot3CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x3CFF0;
            if (checkBoxCSDigimonPartySlot3CurrentSkill5None.Checked || comboBoxCSDigimonPartySlot3CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFF4;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3CurrentSkill5Inherited.Checked);
                byte[] CSDigimonPartySlot3CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3CurrentSkill5.Text));
                saveOpen.Position = 0x3CFF4;
                saveWrite.Write(CSDigimonPartySlot3CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x3CFF8;
            if (checkBoxCSDigimonPartySlot3CurrentSkill6None.Checked || comboBoxCSDigimonPartySlot3CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFFC;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3CurrentSkill6Inherited.Checked);
                byte[] CSDigimonPartySlot3CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3CurrentSkill6.Text));
                saveOpen.Position = 0x3CFFC;
                saveWrite.Write(CSDigimonPartySlot3CurrentSkill6Set);
            }

            #endregion

            #region LearnedSkills2
            //Learned Skill 1
            saveOpen.Position = 0x3D000;
            if (checkBoxCSDigimonPartySlot3LearnedSkill1None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D004;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill1Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill1.Text));
                saveOpen.Position = 0x3D004;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill1Set);
            }

            //Learned Skill 2
            saveOpen.Position = 0x3D008;
            if (checkBoxCSDigimonPartySlot3LearnedSkill2None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D00C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill2Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill2.Text));
                saveOpen.Position = 0x3D00C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill2Set);
            }

            //Learned Skill 3
            saveOpen.Position = 0x3D010;
            if (checkBoxCSDigimonPartySlot3LearnedSkill3None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D014;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill3Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill3.Text));
                saveOpen.Position = 0x3D014;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill3Set);
            }

            //Learned Skill 4
            saveOpen.Position = 0x3D018;
            if (checkBoxCSDigimonPartySlot3LearnedSkill4None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D01C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill4Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill4.Text));
                saveOpen.Position = 0x3D01C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill4Set);
            }

            //Learned Skill 5
            saveOpen.Position = 0x3D020;
            if (checkBoxCSDigimonPartySlot3LearnedSkill5None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D024;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill5Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill5.Text));
                saveOpen.Position = 0x3D024;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill5Set);
            }

            //Learned Skill 6
            saveOpen.Position = 0x3D028;
            if (checkBoxCSDigimonPartySlot3LearnedSkill6None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D02C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill6Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill6.Text));
                saveOpen.Position = 0x3D02C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill6Set);
            }

            //Learned Skill 7
            saveOpen.Position = 0x3D030;
            if (checkBoxCSDigimonPartySlot3LearnedSkill7None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill7.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D034;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill7Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill7Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill7.Text));
                saveOpen.Position = 0x3D034;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill7Set);
            }

            //Learned Skill 8
            saveOpen.Position = 0x3D038;
            if (checkBoxCSDigimonPartySlot3LearnedSkill8None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill8.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D03C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill8Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill8Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill8.Text));
                saveOpen.Position = 0x3D03C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill8Set);
            }

            //Learned Skill 9
            saveOpen.Position = 0x3D040;
            if (checkBoxCSDigimonPartySlot3LearnedSkill9None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill9.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D044;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill9Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill9Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill9.Text));
                saveOpen.Position = 0x3D044;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill9Set);
            }

            //Learned Skill 10
            saveOpen.Position = 0x3D048;
            if (checkBoxCSDigimonPartySlot3LearnedSkill10None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill10.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D04C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill10Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill10Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill10.Text));
                saveOpen.Position = 0x3D04C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill10Set);
            }

            //Learned Skill 11
            saveOpen.Position = 0x3D050;
            if (checkBoxCSDigimonPartySlot3LearnedSkill11None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill11.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D054;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill11Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill11Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill11.Text));
                saveOpen.Position = 0x3D054;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill11Set);
            }

            //Learned Skill 12
            saveOpen.Position = 0x3D058;
            if (checkBoxCSDigimonPartySlot3LearnedSkill12None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill12.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D05C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill12Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill12Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill12.Text));
                saveOpen.Position = 0x3D05C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill12Set);
            }

            //Learned Skill 13
            saveOpen.Position = 0x3D060;
            if (checkBoxCSDigimonPartySlot3LearnedSkill13None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill13.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D064;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill13Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill13Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill13.Text));
                saveOpen.Position = 0x3D064;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill13Set);
            }

            //Learned Skill 14
            saveOpen.Position = 0x3D068;
            if (checkBoxCSDigimonPartySlot3LearnedSkill14None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill14.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D06C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill14Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill14Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill14.Text));
                saveOpen.Position = 0x3D06C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill14Set);
            }

            //Learned Skill 15
            saveOpen.Position = 0x3D070;
            if (checkBoxCSDigimonPartySlot3LearnedSkill15None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill15.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D074;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill15Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill15Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill15.Text));
                saveOpen.Position = 0x3D074;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill15Set);
            }

            //Learned Skill 16
            saveOpen.Position = 0x3D078;
            if (checkBoxCSDigimonPartySlot3LearnedSkill16None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill16.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D07C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill16Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill16Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill16.Text));
                saveOpen.Position = 0x3D07C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill16Set);
            }

            //Learned Skill 17
            saveOpen.Position = 0x3D080;
            if (checkBoxCSDigimonPartySlot3LearnedSkill17None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill17.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D084;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill17Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill17Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill17.Text));
                saveOpen.Position = 0x3D084;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill17Set);
            }

            //Learned Skill 18
            saveOpen.Position = 0x3D088;
            if (checkBoxCSDigimonPartySlot3LearnedSkill18None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill18.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D08C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill18Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill18Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill18.Text));
                saveOpen.Position = 0x3D08C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill18Set);
            }

            //Learned Skill 19
            saveOpen.Position = 0x3D090;
            if (checkBoxCSDigimonPartySlot3LearnedSkill19None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill19.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D094;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill19Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill19Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill19.Text));
                saveOpen.Position = 0x3D094;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill19Set);
            }

            //Learned Skill 20
            saveOpen.Position = 0x3D098;
            if (checkBoxCSDigimonPartySlot3LearnedSkill20None.Checked || comboBoxCSDigimonPartySlot3LearnedSkill20.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D09C;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot3LearnedSkill20Inherited.Checked);
                byte[] CSDigimonPartySlot3LearnedSkill20Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot3LearnedSkill20.Text));
                saveOpen.Position = 0x3D09C;
                saveWrite.Write(CSDigimonPartySlot3LearnedSkill20Set);
            }

            #endregion
            #endregion
            saveOpen.Close();
        }
        #endregion
		        private void getDataHM()
        {
            FileStream savegameFs = new FileStream(savegame, FileMode.Open);
            BinaryReader savegameBr = new BinaryReader(savegameFs);

            //Read in first Digimon in party data
            #region DigimonPartySlot1
            #region Main1
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CA9C + 0x617A0;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CAAC + 0x617A0;
                byte[] HMDigimonPartySlot1ID = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1IDDec = BitConverter.ToInt16(HMDigimonPartySlot1ID, 0);
                comboBoxHMDigimonPartySlot1ID.Text = convertDigimonIDtoString(HMDigimonPartySlot1IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CABC + 0x617A0;
                byte[] HMDigimonPartySlot1Nickname = savegameBr.ReadBytes(17);
                string HMDigimonPartySlot1NicknameDec = Encoding.ASCII.GetString(HMDigimonPartySlot1Nickname);
                textBoxHMDigimonPartySlot1Nickname.Text = HMDigimonPartySlot1NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CAB8 + 0x617A0;
                byte HMDigimonPartySlot1Digivolution = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot1Digivolution.Text = convertDigivolutionIDtoString(HMDigimonPartySlot1Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CAB4 + 0x617A0;
                byte HMDigimonPartySlot1Type = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot1Type.Text = convertTypeIDtoString(HMDigimonPartySlot1Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CAB0 + 0x617A0;
                byte HMDigimonPartySlot1Attribute = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot1Attribute.Text = convertAttributeIDtoString(HMDigimonPartySlot1Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CB20 + 0x617A0;
                byte HMDigimonPartySlot1Personality = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot1Personality.Text = convertPersonalityIDtoString(HMDigimonPartySlot1Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3CCC0 + 0x617A0;
                byte HMDigimonPartySlot1SupportSkill = savegameBr.ReadByte();
                comboBoxHMDigmonPartySlot1SupportSkill.Text = convertsupportSkillsIDtoString(HMDigimonPartySlot1SupportSkill);
                #endregion

                #region Stats1
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3CCC4 + 0x617A0;
                byte HMDigimonPartySlot1EquipSlots = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot1EquipSlots.Value = HMDigimonPartySlot1EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CB04 + 0x617A0;
                byte HMDigimonPartySlot1Memory = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot1Memory.Value = HMDigimonPartySlot1Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CB18 + 0x617A0;
                byte[] HMDigimonPartySlot1EXP = savegameBr.ReadBytes(4);
                int HMDigimonPartySlot1EXPDec = BitConverter.ToInt32(HMDigimonPartySlot1EXP, 0);
                numericUpDownHMDigimonPartySlot1EXP.Value = HMDigimonPartySlot1EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CB10 + 0x617A0;
                byte HMDigimonPartySlot1CurrentLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot1CurrentLVL.Value = HMDigimonPartySlot1CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CB12 + 0x617A0;
                byte HMDigimonPartySlot1MaxLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot1MaxLVL.Value = HMDigimonPartySlot1MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CB14 + 0x617A0;
                byte HMDigimonPartySlot1ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot1ExtraMaxLVL.Value = HMDigimonPartySlot1ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CB24 + 0x617A0;
                byte[] HMDigimonPartySlot1CurrentHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1CurrentHPDec = BitConverter.ToInt16(HMDigimonPartySlot1CurrentHP, 0);
                numericUpDownHMDigimonPartySlot1CurrentHP.Value = HMDigimonPartySlot1CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CB28 + 0x617A0;
                byte[] HMDigimonPartySlot1MaxHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1MaxHPDec = BitConverter.ToInt16(HMDigimonPartySlot1MaxHP, 0);
                numericUpDownHMDigimonPartySlot1MaxHP.Value = HMDigimonPartySlot1MaxHPDec * 100;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CB2C + 0x617A0;
                byte[] HMDigimonPartySlot1BonusHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1BonusHPDec = BitConverter.ToInt16(HMDigimonPartySlot1BonusHP, 0);
                numericUpDownHMDigimonPartySlot1BonusHP.Value = HMDigimonPartySlot1BonusHPDec / 100;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CB30 + 0x617A0;
                byte[] HMDigimonPartySlot1CurrentSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1CurrentSPDec = BitConverter.ToInt16(HMDigimonPartySlot1CurrentSP, 0);
                numericUpDownHMDigimonPartySlot1CurrentSP.Value = HMDigimonPartySlot1CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CB34 + 0x617A0;
                byte[] HMDigimonPartySlot1MaxSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1MaxSPDec = BitConverter.ToInt16(HMDigimonPartySlot1MaxSP, 0);
                numericUpDownHMDigimonPartySlot1MaxSP.Value = HMDigimonPartySlot1MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CB38 + 0x617A0;
                byte[] HMDigimonPartySlot1BonusSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1BonusSPDec = BitConverter.ToInt16(HMDigimonPartySlot1BonusSP, 0);
                numericUpDownHMDigimonPartySlot1BonusSP.Value = HMDigimonPartySlot1BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CB3A + 0x617A0;
                byte[] HMDigimonPartySlot1Attack = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1AttackDec = BitConverter.ToInt16(HMDigimonPartySlot1Attack, 0);
                numericUpDownHMDigimonPartySlot1Attack.Value = HMDigimonPartySlot1AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CB3C + 0x617A0;
                byte[] HMDigimonPartySlot1BonusAttack = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1BonusAttackDec = BitConverter.ToInt16(HMDigimonPartySlot1BonusAttack, 0);
                numericUpDownHMDigimonPartySlot1BonusAttack.Value = HMDigimonPartySlot1BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CB3E + 0x617A0;
                byte[] HMDigimonPartySlot1Defense = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1DefenseDec = BitConverter.ToInt16(HMDigimonPartySlot1Defense, 0);
                numericUpDownHMDigimonPartySlot1Defense.Value = HMDigimonPartySlot1DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CB40 + 0x617A0;
                byte[] HMDigimonPartySlot1BonusDefense = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1BonusDefenseDec = BitConverter.ToInt16(HMDigimonPartySlot1BonusDefense, 0);
                numericUpDownHMDigimonPartySlot1BonusDefense.Value = HMDigimonPartySlot1BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CB42 + 0x617A0;
                byte[] HMDigimonPartySlot1Intelligence = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1IntelligenceDec = BitConverter.ToInt16(HMDigimonPartySlot1Intelligence, 0);
                numericUpDownHMDigimonPartySlot1Intelligence.Value = HMDigimonPartySlot1IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CB44 + 0x617A0;
                byte[] HMDigimonPartySlot1BonusIntelligence = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1BonusIntelligenceDec = BitConverter.ToInt16(HMDigimonPartySlot1BonusIntelligence, 0);
                numericUpDownHMDigimonPartySlot1BonusIntelligence.Value = HMDigimonPartySlot1BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CB46 + 0x617A0;
                byte[] HMDigimonPartySlot1Speed = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1SpeedDec = BitConverter.ToInt16(HMDigimonPartySlot1Speed, 0);
                numericUpDownHMDigimonPartySlot1Speed.Value = HMDigimonPartySlot1SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CB48 + 0x617A0;
                byte[] HMDigimonPartySlot1BonusSpeed = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1BonusSpeedDec = BitConverter.ToInt16(HMDigimonPartySlot1BonusSpeed, 0);
                numericUpDownHMDigimonPartySlot1BonusSpeed.Value = HMDigimonPartySlot1BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CB4C + 0x617A0;
                byte[] HMDigimonPartySlot1CAM = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1CAMDec = BitConverter.ToInt16(HMDigimonPartySlot1CAM, 0);
                numericUpDownHMDigimonPartySlot1CAM.Value = (HMDigimonPartySlot1CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CB4A + 0x617A0;
                byte[] HMDigimonPartySlot1ABI = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1ABIDec = BitConverter.ToInt16(HMDigimonPartySlot1ABI, 0);
                numericUpDownHMDigimonPartySlot1ABI.Value = HMDigimonPartySlot1ABIDec;
                #endregion

                #region Equipment1
                //Equip 1
                savegameBr.BaseStream.Position = 0x3CCC6 + 0x617A0;
                byte[] HMDigimonPartySlot1Equip1 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1Equip1Dec = BitConverter.ToInt16(HMDigimonPartySlot1Equip1, 0);
                comboBoxHMDigimonPartySlot1Equip1.Text = convertEquipIDtoString(HMDigimonPartySlot1Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3CCC8 + 0x617A0;
                byte[] HMDigimonPartySlot1Equip2 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1Equip2Dec = BitConverter.ToInt16(HMDigimonPartySlot1Equip2, 0);
                comboBoxHMDigimonPartySlot1Equip2.Text = convertEquipIDtoString(HMDigimonPartySlot1Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3CCCA + 0x617A0;
                byte[] HMDigimonPartySlot1Equip3 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1Equip3Dec = BitConverter.ToInt16(HMDigimonPartySlot1Equip3, 0);
                comboBoxHMDigimonPartySlot1Equip3.Text = convertEquipIDtoString(HMDigimonPartySlot1Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3CCCC + 0x617A0;
                byte[] HMDigimonPartySlot1Accessory = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot1AccessoryDec = BitConverter.ToInt16(HMDigimonPartySlot1Accessory, 0);
                comboBoxHMDigimonPartySlot1Accessory.Text = convertAccessoryIDtoString(HMDigimonPartySlot1AccessoryDec);
                #endregion

                #region CurrentSkills1
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CB50 + 0x617A0;
                byte HMDigimonPartySlot1CurrentSkill1Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1CurrentSkill1Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill1Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CB54 + 0x617A0;
                    comboBoxHMDigimonPartySlot1CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CB58 + 0x617A0;
                byte HMDigimonPartySlot1CurrentSkill2Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1CurrentSkill2Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill2Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CB5C + 0x617A0;
                    comboBoxHMDigimonPartySlot1CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CB60 + 0x617A0;
                byte HMDigimonPartySlot1CurrentSkill3Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1CurrentSkill3Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill3Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CB64 + 0x617A0;
                    comboBoxHMDigimonPartySlot1CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CB68 + 0x617A0;
                byte HMDigimonPartySlot1CurrentSkill4Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1CurrentSkill4Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill4Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CB6C + 0x617A0;
                    comboBoxHMDigimonPartySlot1CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CB70 + 0x617A0;
                byte HMDigimonPartySlot1CurrentSkill5Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1CurrentSkill5Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill5Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CB74 + 0x617A0;
                    comboBoxHMDigimonPartySlot1CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CB78 + 0x617A0;
                byte HMDigimonPartySlot1CurrentSkill6Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1CurrentSkill6Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1CurrentSkill6Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CB7C + 0x617A0;
                    comboBoxHMDigimonPartySlot1CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills1
                //Learned Skill 1
                savegameBr.BaseStream.Position = 0x3CB80 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill1Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill1Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill1Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CB84 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3CB88 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill2Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill2Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill2Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CB8C + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3CB90 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill3Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill3Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill3Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CB94 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3CB98 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill4Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill4Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill4Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CB9C + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3CBA0 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill5Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill5Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill5Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CBA4 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3CBA8 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill6Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill6Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill6Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CBAC + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3CBB0 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill7Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill7Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill7Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3CBB4 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3CBB8 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill8Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill8Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill8Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3CBBC + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3CBC0 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill9Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill9Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill9Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3CBC4 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3CBC8 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill10Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill10Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill10Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3CBCC + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3CBD0 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill11Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill11Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill11Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3CBD4 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill11.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3CBD8 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill12Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill12Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill12Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3CBDC + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3CBE0 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill13Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill13Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill13Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3CBE4 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3CBE8 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill14Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill14Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill14Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3CBEC + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3CBF0 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill15Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill15Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill15Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3CBF4 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3CBF8 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill16Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill16Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill16Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3CBFC + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3CC00 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill17Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill17Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill17Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3CC04 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3CC08 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill18Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill18Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill18Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3CC0C + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3CC10 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill19Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill19Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill19Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3CC14 + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3CC18 + 0x617A0;
                byte HMDigimonPartySlot1LearnedSkill20Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot1LearnedSkill20Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot1LearnedSkill20Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot1LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3CC1C + 0x617A0;
                    comboBoxHMDigimonPartySlot1LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraitsHM(1);
            }

            else
            {
                checkBoxHMDigimonPartySlot1None.Checked = true;
            }
            #endregion

            //Read in second Digimon in party data
            #region DigimonPartySlot2
            #region Main2
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CCDC + 0x617A0;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CCEC + 0x617A0;
                byte[] HMDigimonPartySlot2ID = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2IDDec = BitConverter.ToInt16(HMDigimonPartySlot2ID, 0);
                comboBoxHMDigimonPartySlot2ID.Text = convertDigimonIDtoString(HMDigimonPartySlot2IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CCFC + 0x617A0;
                byte[] HMDigimonPartySlot2Nickname = savegameBr.ReadBytes(17);
                string HMDigimonPartySlot2NicknameDec = Encoding.ASCII.GetString(HMDigimonPartySlot2Nickname);
                textBoxHMDigimonPartySlot2Nickname.Text = HMDigimonPartySlot2NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CCF8 + 0x617A0;
                byte HMDigimonPartySlot2Digivolution = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot2Digivolution.Text = convertDigivolutionIDtoString(HMDigimonPartySlot2Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CCF4 + 0x617A0;
                byte HMDigimonPartySlot2Type = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot2Type.Text = convertTypeIDtoString(HMDigimonPartySlot2Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CCF0 + 0x617A0;
                byte HMDigimonPartySlot2Attribute = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot2Attribute.Text = convertAttributeIDtoString(HMDigimonPartySlot2Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CD60 + 0x617A0;
                byte HMDigimonPartySlot2Personality = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot2Personality.Text = convertPersonalityIDtoString(HMDigimonPartySlot2Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3CF00 + 0x617A0;
                byte HMDigimonPartySlot2SupportSkill = savegameBr.ReadByte();
                comboBoxHMDigmonPartySlot2SupportSkill.Text = convertsupportSkillsIDtoString(HMDigimonPartySlot2SupportSkill);
                #endregion

                #region Stats2
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3CF04 + 0x617A0;
                byte HMDigimonPartySlot2EquipSlots = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot2EquipSlots.Value = HMDigimonPartySlot2EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CD44 + 0x617A0;
                byte HMDigimonPartySlot2Memory = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot2Memory.Value = HMDigimonPartySlot2Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CD58 + 0x617A0;
                byte[] HMDigimonPartySlot2EXP = savegameBr.ReadBytes(4);
                int HMDigimonPartySlot2EXPDec = BitConverter.ToInt32(HMDigimonPartySlot2EXP, 0);
                numericUpDownHMDigimonPartySlot2EXP.Value = HMDigimonPartySlot2EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CD50 + 0x617A0;
                byte HMDigimonPartySlot2CurrentLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot2CurrentLVL.Value = HMDigimonPartySlot2CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CD52 + 0x617A0;
                byte HMDigimonPartySlot2MaxLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot2MaxLVL.Value = HMDigimonPartySlot2MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CD54 + 0x617A0;
                byte HMDigimonPartySlot2ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot2ExtraMaxLVL.Value = HMDigimonPartySlot2ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CD64 + 0x617A0;
                byte[] HMDigimonPartySlot2CurrentHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2CurrentHPDec = BitConverter.ToInt16(HMDigimonPartySlot2CurrentHP, 0);
                numericUpDownHMDigimonPartySlot2CurrentHP.Value = HMDigimonPartySlot2CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CD68 + 0x617A0;
                byte[] HMDigimonPartySlot2MaxHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2MaxHPDec = BitConverter.ToInt16(HMDigimonPartySlot2MaxHP, 0);
                numericUpDownHMDigimonPartySlot2MaxHP.Value = HMDigimonPartySlot2MaxHPDec * 100;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CD6C + 0x617A0;
                byte[] HMDigimonPartySlot2BonusHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2BonusHPDec = BitConverter.ToInt16(HMDigimonPartySlot2BonusHP, 0);
                numericUpDownHMDigimonPartySlot2BonusHP.Value = HMDigimonPartySlot2BonusHPDec / 100;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CD70 + 0x617A0;
                byte[] HMDigimonPartySlot2CurrentSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2CurrentSPDec = BitConverter.ToInt16(HMDigimonPartySlot2CurrentSP, 0);
                numericUpDownHMDigimonPartySlot2CurrentSP.Value = HMDigimonPartySlot2CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CD74 + 0x617A0;
                byte[] HMDigimonPartySlot2MaxSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2MaxSPDec = BitConverter.ToInt16(HMDigimonPartySlot2MaxSP, 0);
                numericUpDownHMDigimonPartySlot2MaxSP.Value = HMDigimonPartySlot2MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CD78 + 0x617A0;
                byte[] HMDigimonPartySlot2BonusSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2BonusSPDec = BitConverter.ToInt16(HMDigimonPartySlot2BonusSP, 0);
                numericUpDownHMDigimonPartySlot2BonusSP.Value = HMDigimonPartySlot2BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CD7A + 0x617A0;
                byte[] HMDigimonPartySlot2Attack = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2AttackDec = BitConverter.ToInt16(HMDigimonPartySlot2Attack, 0);
                numericUpDownHMDigimonPartySlot2Attack.Value = HMDigimonPartySlot2AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CD7C + 0x617A0;
                byte[] HMDigimonPartySlot2BonusAttack = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2BonusAttackDec = BitConverter.ToInt16(HMDigimonPartySlot2BonusAttack, 0);
                numericUpDownHMDigimonPartySlot2BonusAttack.Value = HMDigimonPartySlot2BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CD7E + 0x617A0;
                byte[] HMDigimonPartySlot2Defense = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2DefenseDec = BitConverter.ToInt16(HMDigimonPartySlot2Defense, 0);
                numericUpDownHMDigimonPartySlot2Defense.Value = HMDigimonPartySlot2DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CD80 + 0x617A0;
                byte[] HMDigimonPartySlot2BonusDefense = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2BonusDefenseDec = BitConverter.ToInt16(HMDigimonPartySlot2BonusDefense, 0);
                numericUpDownHMDigimonPartySlot2BonusDefense.Value = HMDigimonPartySlot2BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CD82 + 0x617A0;
                byte[] HMDigimonPartySlot2Intelligence = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2IntelligenceDec = BitConverter.ToInt16(HMDigimonPartySlot2Intelligence, 0);
                numericUpDownHMDigimonPartySlot2Intelligence.Value = HMDigimonPartySlot2IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CD84 + 0x617A0;
                byte[] HMDigimonPartySlot2BonusIntelligence = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2BonusIntelligenceDec = BitConverter.ToInt16(HMDigimonPartySlot2BonusIntelligence, 0);
                numericUpDownHMDigimonPartySlot2BonusIntelligence.Value = HMDigimonPartySlot2BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CD86 + 0x617A0;
                byte[] HMDigimonPartySlot2Speed = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2SpeedDec = BitConverter.ToInt16(HMDigimonPartySlot2Speed, 0);
                numericUpDownHMDigimonPartySlot2Speed.Value = HMDigimonPartySlot2SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CD88 + 0x617A0;
                byte[] HMDigimonPartySlot2BonusSpeed = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2BonusSpeedDec = BitConverter.ToInt16(HMDigimonPartySlot2BonusSpeed, 0);
                numericUpDownHMDigimonPartySlot2BonusSpeed.Value = HMDigimonPartySlot2BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CD8C + 0x617A0;
                byte[] HMDigimonPartySlot2CAM = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2CAMDec = BitConverter.ToInt16(HMDigimonPartySlot2CAM, 0);
                numericUpDownHMDigimonPartySlot2CAM.Value = (HMDigimonPartySlot2CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CD8A + 0x617A0;
                byte[] HMDigimonPartySlot2ABI = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2ABIDec = BitConverter.ToInt16(HMDigimonPartySlot2ABI, 0);
                numericUpDownHMDigimonPartySlot2ABI.Value = HMDigimonPartySlot2ABIDec;
                #endregion

                #region Equipment2
                //Equip 1
                savegameBr.BaseStream.Position = 0x3CF06 + 0x617A0;
                byte[] HMDigimonPartySlot2Equip1 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2Equip1Dec = BitConverter.ToInt16(HMDigimonPartySlot2Equip1, 0);
                comboBoxHMDigimonPartySlot2Equip1.Text = convertEquipIDtoString(HMDigimonPartySlot2Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3CF08 + 0x617A0;
                byte[] HMDigimonPartySlot2Equip2 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2Equip2Dec = BitConverter.ToInt16(HMDigimonPartySlot2Equip2, 0);
                comboBoxHMDigimonPartySlot2Equip2.Text = convertEquipIDtoString(HMDigimonPartySlot2Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3CF0A + 0x617A0;
                byte[] HMDigimonPartySlot2Equip3 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2Equip3Dec = BitConverter.ToInt16(HMDigimonPartySlot2Equip3, 0);
                comboBoxHMDigimonPartySlot2Equip3.Text = convertEquipIDtoString(HMDigimonPartySlot2Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3CF0C + 0x617A0;
                byte[] HMDigimonPartySlot2Accessory = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot2AccessoryDec = BitConverter.ToInt16(HMDigimonPartySlot2Accessory, 0);
                comboBoxHMDigimonPartySlot2Accessory.Text = convertAccessoryIDtoString(HMDigimonPartySlot2AccessoryDec);
                #endregion

                #region CurrentSkills2
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CD90 + 0x617A0;
                byte HMDigimonPartySlot2CurrentSkill1Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2CurrentSkill1Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill1Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CD94 + 0x617A0;
                    comboBoxHMDigimonPartySlot2CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CD98 + 0x617A0;
                byte HMDigimonPartySlot2CurrentSkill2Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2CurrentSkill2Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill2Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CD9C + 0x617A0;
                    comboBoxHMDigimonPartySlot2CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CDA0 + 0x617A0;
                byte HMDigimonPartySlot2CurrentSkill3Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2CurrentSkill3Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill3Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CDA4 + 0x617A0;
                    comboBoxHMDigimonPartySlot2CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CDA8 + 0x617A0;
                byte HMDigimonPartySlot2CurrentSkill4Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2CurrentSkill4Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill4Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CDAC + 0x617A0;
                    comboBoxHMDigimonPartySlot2CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CDB0 + 0x617A0;
                byte HMDigimonPartySlot2CurrentSkill5Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2CurrentSkill5Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill5Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CDB4 + 0x617A0;
                    comboBoxHMDigimonPartySlot2CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CDB8 + 0x617A0;
                byte HMDigimonPartySlot2CurrentSkill6Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2CurrentSkill6Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2CurrentSkill6Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CDBC + 0x617A0;
                    comboBoxHMDigimonPartySlot2CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills2
                //Learned Skill 1

                savegameBr.BaseStream.Position = 0x3CDC0 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill1Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill1Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill1Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CDC4 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3CDC8 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill2Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill2Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill2Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CDCC + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3CDD0 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill3Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill3Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill3Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CDD4 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3CDD8 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill4Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill4Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill4Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CDDC + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3CDE0 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill5Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill5Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill5Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CDE4 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3CDE8 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill6Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill6Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill6Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CDEC + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3CDF0 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill7Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill7Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill7Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3CDF4 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3CDF8 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill8Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill8Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill8Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3CDFC + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3CE00 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill9Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill9Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill9Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3CE04 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3CE08 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill10Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill10Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill10Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3CE0C + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3CE10 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill11Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill11Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill11Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3CE14 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill11.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3CE18 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill12Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill12Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill12Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3CE1C + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3CE20 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill13Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill13Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill13Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3CE24 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3CE28 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill14Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill14Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill14Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3CE2C + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3CE30 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill15Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill15Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill15Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3CE34 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3CE38 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill16Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill16Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill16Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3CE3C + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3CE40 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill17Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill17Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill17Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3CE44 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3CE48 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill18Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill18Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill18Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3CE4C + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3CE50 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill19Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill19Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill19Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3CE54 + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3CE58 + 0x617A0;
                byte HMDigimonPartySlot2LearnedSkill20Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot2LearnedSkill20Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot2LearnedSkill20Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot2LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3CE5C + 0x617A0;
                    comboBoxHMDigimonPartySlot2LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraitsHM(2);
            }

            else
            {
                checkBoxHMDigimonPartySlot2None.Checked = true;
            }
            #endregion

            //Read in third Digimon in party data
            #region DigimonPartySlot3
            #region Main3
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CF1C + 0x617A0;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CF2C + 0x617A0;
                byte[] HMDigimonPartySlot3ID = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3IDDec = BitConverter.ToInt16(HMDigimonPartySlot3ID, 0);
                comboBoxHMDigimonPartySlot3ID.Text = convertDigimonIDtoString(HMDigimonPartySlot3IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CF3C + 0x617A0;
                byte[] HMDigimonPartySlot3Nickname = savegameBr.ReadBytes(17);
                string HMDigimonPartySlot3NicknameDec = Encoding.ASCII.GetString(HMDigimonPartySlot3Nickname);
                textBoxHMDigimonPartySlot3Nickname.Text = HMDigimonPartySlot3NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CF38 + 0x617A0;
                byte HMDigimonPartySlot3Digivolution = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot3Digivolution.Text = convertDigivolutionIDtoString(HMDigimonPartySlot3Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CF34 + 0x617A0;
                byte HMDigimonPartySlot3Type = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot3Type.Text = convertTypeIDtoString(HMDigimonPartySlot3Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CF30 + 0x617A0;
                byte HMDigimonPartySlot3Attribute = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot3Attribute.Text = convertAttributeIDtoString(HMDigimonPartySlot3Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CFA0 + 0x617A0;
                byte HMDigimonPartySlot3Personality = savegameBr.ReadByte();
                comboBoxHMDigimonPartySlot3Personality.Text = convertPersonalityIDtoString(HMDigimonPartySlot3Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3D140 + 0x617A0;
                byte HMDigimonPartySlot3SupportSkill = savegameBr.ReadByte();
                comboBoxHMDigmonPartySlot3SupportSkill.Text = convertsupportSkillsIDtoString(HMDigimonPartySlot3SupportSkill);
                #endregion

                #region Stats3
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3D144 + 0x617A0;
                byte HMDigimonPartySlot3EquipSlots = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot3EquipSlots.Value = HMDigimonPartySlot3EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CF84 + 0x617A0;
                byte HMDigimonPartySlot3Memory = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot3Memory.Value = HMDigimonPartySlot3Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CF98 + 0x617A0;
                byte[] HMDigimonPartySlot3EXP = savegameBr.ReadBytes(4);
                int HMDigimonPartySlot3EXPDec = BitConverter.ToInt32(HMDigimonPartySlot3EXP, 0);
                numericUpDownHMDigimonPartySlot3EXP.Value = HMDigimonPartySlot3EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CF90 + 0x617A0;
                byte HMDigimonPartySlot3CurrentLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot3CurrentLVL.Value = HMDigimonPartySlot3CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CF92 + 0x617A0;
                byte HMDigimonPartySlot3MaxLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot3MaxLVL.Value = HMDigimonPartySlot3MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CF94 + 0x617A0;
                byte HMDigimonPartySlot3ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownHMDigimonPartySlot3ExtraMaxLVL.Value = HMDigimonPartySlot3ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CFA4 + 0x617A0;
                byte[] HMDigimonPartySlot3CurrentHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3CurrentHPDec = BitConverter.ToInt16(HMDigimonPartySlot3CurrentHP, 0);
                numericUpDownHMDigimonPartySlot3CurrentHP.Value = HMDigimonPartySlot3CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CFA8 + 0x617A0;
                byte[] HMDigimonPartySlot3MaxHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3MaxHPDec = BitConverter.ToInt16(HMDigimonPartySlot3MaxHP, 0);
                numericUpDownHMDigimonPartySlot3MaxHP.Value = HMDigimonPartySlot3MaxHPDec * 100;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CFAC + 0x617A0;
                byte[] HMDigimonPartySlot3BonusHP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3BonusHPDec = BitConverter.ToInt16(HMDigimonPartySlot3BonusHP, 0);
                numericUpDownHMDigimonPartySlot3BonusHP.Value = HMDigimonPartySlot3BonusHPDec / 100;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CFB0 + 0x617A0;
                byte[] HMDigimonPartySlot3CurrentSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3CurrentSPDec = BitConverter.ToInt16(HMDigimonPartySlot3CurrentSP, 0);
                numericUpDownHMDigimonPartySlot3CurrentSP.Value = HMDigimonPartySlot3CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CFB4 + 0x617A0;
                byte[] HMDigimonPartySlot3MaxSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3MaxSPDec = BitConverter.ToInt16(HMDigimonPartySlot3MaxSP, 0);
                numericUpDownHMDigimonPartySlot3MaxSP.Value = HMDigimonPartySlot3MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CFB8 + 0x617A0;
                byte[] HMDigimonPartySlot3BonusSP = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3BonusSPDec = BitConverter.ToInt16(HMDigimonPartySlot3BonusSP, 0);
                numericUpDownHMDigimonPartySlot3BonusSP.Value = HMDigimonPartySlot3BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CFBA + 0x617A0;
                byte[] HMDigimonPartySlot3Attack = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3AttackDec = BitConverter.ToInt16(HMDigimonPartySlot3Attack, 0);
                numericUpDownHMDigimonPartySlot3Attack.Value = HMDigimonPartySlot3AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CFBC + 0x617A0;
                byte[] HMDigimonPartySlot3BonusAttack = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3BonusAttackDec = BitConverter.ToInt16(HMDigimonPartySlot3BonusAttack, 0);
                numericUpDownHMDigimonPartySlot3BonusAttack.Value = HMDigimonPartySlot3BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CFBE + 0x617A0;
                byte[] HMDigimonPartySlot3Defense = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3DefenseDec = BitConverter.ToInt16(HMDigimonPartySlot3Defense, 0);
                numericUpDownHMDigimonPartySlot3Defense.Value = HMDigimonPartySlot3DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CFC0 + 0x617A0;
                byte[] HMDigimonPartySlot3BonusDefense = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3BonusDefenseDec = BitConverter.ToInt16(HMDigimonPartySlot3BonusDefense, 0);
                numericUpDownHMDigimonPartySlot3BonusDefense.Value = HMDigimonPartySlot3BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CFC2 + 0x617A0;
                byte[] HMDigimonPartySlot3Intelligence = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3IntelligenceDec = BitConverter.ToInt16(HMDigimonPartySlot3Intelligence, 0);
                numericUpDownHMDigimonPartySlot3Intelligence.Value = HMDigimonPartySlot3IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CFC4 + 0x617A0;
                byte[] HMDigimonPartySlot3BonusIntelligence = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3BonusIntelligenceDec = BitConverter.ToInt16(HMDigimonPartySlot3BonusIntelligence, 0);
                numericUpDownHMDigimonPartySlot3BonusIntelligence.Value = HMDigimonPartySlot3BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CFC6 + 0x617A0;
                byte[] HMDigimonPartySlot3Speed = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3SpeedDec = BitConverter.ToInt16(HMDigimonPartySlot3Speed, 0);
                numericUpDownHMDigimonPartySlot3Speed.Value = HMDigimonPartySlot3SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CFC8 + 0x617A0;
                byte[] HMDigimonPartySlot3BonusSpeed = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3BonusSpeedDec = BitConverter.ToInt16(HMDigimonPartySlot3BonusSpeed, 0);
                numericUpDownHMDigimonPartySlot3BonusSpeed.Value = HMDigimonPartySlot3BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CFCC + 0x617A0;
                byte[] HMDigimonPartySlot3CAM = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3CAMDec = BitConverter.ToInt16(HMDigimonPartySlot3CAM, 0);
                numericUpDownHMDigimonPartySlot3CAM.Value = (HMDigimonPartySlot3CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CFCA + 0x617A0;
                byte[] HMDigimonPartySlot3ABI = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3ABIDec = BitConverter.ToInt16(HMDigimonPartySlot3ABI, 0);
                numericUpDownHMDigimonPartySlot3ABI.Value = HMDigimonPartySlot3ABIDec;
                #endregion

                #region Equipment3
                //Equip 1
                savegameBr.BaseStream.Position = 0x3D146 + 0x617A0;
                byte[] HMDigimonPartySlot3Equip1 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3Equip1Dec = BitConverter.ToInt16(HMDigimonPartySlot3Equip1, 0);
                comboBoxHMDigimonPartySlot3Equip1.Text = convertEquipIDtoString(HMDigimonPartySlot3Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3D148 + 0x617A0;
                byte[] HMDigimonPartySlot3Equip2 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3Equip2Dec = BitConverter.ToInt16(HMDigimonPartySlot3Equip2, 0);
                comboBoxHMDigimonPartySlot3Equip2.Text = convertEquipIDtoString(HMDigimonPartySlot3Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3D14A + 0x617A0;
                byte[] HMDigimonPartySlot3Equip3 = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3Equip3Dec = BitConverter.ToInt16(HMDigimonPartySlot3Equip3, 0);
                comboBoxHMDigimonPartySlot3Equip3.Text = convertEquipIDtoString(HMDigimonPartySlot3Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3D14C + 0x617A0;
                byte[] HMDigimonPartySlot3Accessory = savegameBr.ReadBytes(2);
                short HMDigimonPartySlot3AccessoryDec = BitConverter.ToInt16(HMDigimonPartySlot3Accessory, 0);
                comboBoxHMDigimonPartySlot3Accessory.Text = convertAccessoryIDtoString(HMDigimonPartySlot3AccessoryDec);
                #endregion

                #region CurrentSkills3
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CFD0 + 0x617A0;
                byte HMDigimonPartySlot3CurrentSkill1Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3CurrentSkill1Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill1Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CFD4 + 0x617A0;
                    comboBoxHMDigimonPartySlot3CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CFD8 + 0x617A0;
                byte HMDigimonPartySlot3CurrentSkill2Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3CurrentSkill2Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill2Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CFDC + 0x617A0;
                    comboBoxHMDigimonPartySlot3CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CFE0 + 0x617A0;
                byte HMDigimonPartySlot3CurrentSkill3Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3CurrentSkill3Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill3Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CFE4 + 0x617A0;
                    comboBoxHMDigimonPartySlot3CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CFE8 + 0x617A0;
                byte HMDigimonPartySlot3CurrentSkill4Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3CurrentSkill4Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill4Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CFEC + 0x617A0;
                    comboBoxHMDigimonPartySlot3CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CFF0 + 0x617A0;
                byte HMDigimonPartySlot3CurrentSkill5Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3CurrentSkill5Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill5Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CFF4 + 0x617A0;
                    comboBoxHMDigimonPartySlot3CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CFF8 + 0x617A0;
                byte HMDigimonPartySlot3CurrentSkill6Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3CurrentSkill6Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3CurrentSkill6Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CFFC + 0x617A0;
                    comboBoxHMDigimonPartySlot3CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills3
                //Learned Skill 1

                savegameBr.BaseStream.Position = 0x3D000 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill1Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill1Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill1Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3D004 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3D008 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill2Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill2Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill2Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3D00C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3D010 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill3Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill3Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill3Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3D014 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3D018 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill4Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill4Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill4Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3D01C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3D020 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill5Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill5Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill5Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3D024 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3D028 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill6Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill6Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill6Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3D02C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3D030 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill7Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill7Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill7Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3D034 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3D038 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill8Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill8Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill8Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3D03C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3D040 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill9Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill9Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill9Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3D044 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3D048 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill10Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill10Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill10Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3D04C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3D050 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill11Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill11Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill11Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3D054 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill11.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3D058 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill12Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill12Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill12Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3D05C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3D060 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill13Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill13Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill13Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3D064 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3D068 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill14Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill14Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill14Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3D06C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3D070 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill15Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill15Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill15Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3D074 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3D078 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill16Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill16Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill16Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3D07C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3D080 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill17Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill17Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill17Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3D084 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3D088 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill18Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill18Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill18Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3D08C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3D090 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill19Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill19Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill19Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3D094 + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3D098 + 0x617A0;
                byte HMDigimonPartySlot3LearnedSkill20Inherited = savegameBr.ReadByte();
                if (HMDigimonPartySlot3LearnedSkill20Inherited > 1)
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxHMDigimonPartySlot3LearnedSkill20Inherited.Checked = Convert.ToBoolean(HMDigimonPartySlot3LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3D09C + 0x617A0;
                    comboBoxHMDigimonPartySlot3LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraitsHM(3);
            }

            else
            {
                checkBoxHMDigimonPartySlot3None.Checked = true;
            }
            #endregion


            savegameBr.Close();
        }

        private void setDataHM()
        {
            FileStream saveOpen = new FileStream(savegame, FileMode.Open);
            BinaryWriter saveWrite = new BinaryWriter(saveOpen);

            //Save first Digimon In Party data
            #region DigimonPartySlot1
            #region Main1
            //ID
            byte[] HMDigimonPartySlot1IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxHMDigimonPartySlot1ID.Text));
            saveOpen.Position = 0x3CAAC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1IDSet);

            //Nickname
            byte[] HMDigimonPartySlot1NicknameSet = Encoding.ASCII.GetBytes(textBoxHMDigimonPartySlot1Nickname.Text);
            saveOpen.Position = 0x3CABC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1NicknameSet);
            if (HMDigimonPartySlot1NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - HMDigimonPartySlot1NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] HMDigimonPartySlot1DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxHMDigimonPartySlot1Digivolution.Text));
            saveOpen.Position = 0x3CAB8 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1DigivolutionSet);

            //Type
            byte[] HMDigimonPartySlot1TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxHMDigimonPartySlot1Type.Text));
            saveOpen.Position = 0x3CAB4 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1TypeSet);

            //Attribute
            byte[] HMDigimonPartySlot1AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxHMDigimonPartySlot1Attribute.Text));
            saveOpen.Position = 0x3CAB0 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1AttributeSet);

            //Personality
            byte[] HMDigimonPartySlot1PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxHMDigimonPartySlot1Personality.Text));
            saveOpen.Position = 0x3CB20 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1PersonalitySet);

            //Support Skills
            byte[] HMDigimonPartySlot1SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxHMDigmonPartySlot1SupportSkill.Text));
            saveOpen.Position = 0x3CCC0 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1SupportSkillSet);
            #endregion

            #region Stats1
            //Equip Slots
            byte[] HMDigimonPartySlot1EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1EquipSlots.Value);
            saveOpen.Position = 0x3CCC4 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1EquipSlotsSet);

            //Memory Use
            byte[] HMDigimonPartySlot1MemorySet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1Memory.Value);
            saveOpen.Position = 0x3CB04 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1MemorySet);

            //EXP
            byte[] HMDigimonPartySlot1EXPSet = BitConverter.GetBytes((int)numericUpDownHMDigimonPartySlot1EXP.Value);
            saveOpen.Position = 0x3CB18 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1EXPSet);

            //Current LVL
            byte[] HMDigimonPartySlot1CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1CurrentLVL.Value);
            saveOpen.Position = 0x3CB10 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1CurrentLVLSet);

            //Max Level
            byte[] HMDigimonPartySlot1MaxLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1MaxLVL.Value);
            saveOpen.Position = 0x3CB12 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1MaxLVLSet);

            //Extra Max Level
            byte[] HMDigimonPartySlot1ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CB14 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1ExtraMaxLVLSet);

            //Current HP
            byte[] HMDigimonPartySlot1CurrentHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1CurrentHP.Value);
            saveOpen.Position = 0x3CB24 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1CurrentHPSet);

            //Max HP
            byte[] HMDigimonPartySlot1MaxHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1MaxHP.Value / 10);
            saveOpen.Position = 0x3CB28 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1MaxHPSet);

            //Bonus HP
            byte[] HMDigimonPartySlot1BonusHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1BonusHP.Value);
            saveOpen.Position = 0x3CB2C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1BonusHPSet);

            //Current SP
            byte[] HMDigimonPartySlot1CurrentSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1CurrentSP.Value);
            saveOpen.Position = 0x3CB30 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1CurrentSPSet);

            //Max SP
            byte[] HMDigimonPartySlot1MaxSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1MaxSP.Value);
            saveOpen.Position = 0x3CB34 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1MaxSPSet);

            //Bonus SP
            byte[] HMDigimonPartySlot1BonusSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1BonusSP.Value);
            saveOpen.Position = 0x3CB38 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1BonusSPSet);

            //Attack
            byte[] HMDigimonPartySlot1AttackSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1Attack.Value);
            saveOpen.Position = 0x3CB3A + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1AttackSet);

            //Bonus Attack
            byte[] HMDigimonPartySlot1BonusAttackSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1BonusAttack.Value);
            saveOpen.Position = 0x3CB3C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1BonusAttackSet);

            //Defense
            byte[] HMDigimonPartySlot1DefenseSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1Defense.Value);
            saveOpen.Position = 0x3CB3E + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1DefenseSet);

            //Bonus Defense
            byte[] HMDigimonPartySlot1BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1BonusDefense.Value);
            saveOpen.Position = 0x3CB40 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1BonusDefenseSet);

            //Intelligence
            byte[] HMDigimonPartySlot1IntelligenceSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1Intelligence.Value);
            saveOpen.Position = 0x3CB42 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1IntelligenceSet);

            //Bonus Intelligence
            byte[] HMDigimonPartySlot1BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1BonusIntelligence.Value);
            saveOpen.Position = 0x3CB44 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1BonusIntelligenceSet);

            //Speed
            byte[] HMDigimonPartySlot1SpeedSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1Speed.Value);
            saveOpen.Position = 0x3CB46 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1SpeedSet);

            //Bonus Speed
            byte[] HMDigimonPartySlot1BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1BonusSpeed.Value);
            saveOpen.Position = 0x3CB48 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1BonusSpeedSet);

            //CAM
            byte[] HMDigimonPartySlot1CAMSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1CAM.Value);
            saveOpen.Position = 0x3CB4C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1CAMSet);

            //ABI
            byte[] HMDigimonPartySlot1ABISet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot1ABI.Value);
            saveOpen.Position = 0x3CB4A + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1ABISet);
            #endregion

            #region Equipment1
            //Equip 1
            byte[] HMDigimonPartySlot1Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot1Equip1.Text));
            saveOpen.Position = 0x3CCC6 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1Equip1Set);

            //Equip 2
            byte[] HMDigimonPartySlot1Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot1Equip2.Text));
            saveOpen.Position = 0x3CCC8 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1Equip2Set);

            //Equip 3
            byte[] HMDigimonPartySlot1Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot1Equip3.Text));
            saveOpen.Position = 0x3CCCA + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1Equip3Set);

            //Accessory
            byte[] HMDigimonPartySlot1AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxHMDigimonPartySlot1Accessory.Text));
            saveOpen.Position = 0x3CCCC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot1AccessorySet);
            #endregion

            #region CurrentSkills1
            //Current Skill 1
            saveOpen.Position = 0x3CB50 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1CurrentSkill1None.Checked || comboBoxHMDigimonPartySlot1CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB54 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1CurrentSkill1Inherited.Checked);
                byte[] HMDigimonPartySlot1CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1CurrentSkill1.Text));
                saveOpen.Position = 0x3CB54 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x3CB58 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1CurrentSkill2None.Checked || comboBoxHMDigimonPartySlot1CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB5C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1CurrentSkill2Inherited.Checked);
                byte[] HMDigimonPartySlot1CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1CurrentSkill2.Text));
                saveOpen.Position = 0x3CB5C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x3CB60 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1CurrentSkill3None.Checked || comboBoxHMDigimonPartySlot1CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB64 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1CurrentSkill3Inherited.Checked);
                byte[] HMDigimonPartySlot1CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1CurrentSkill3.Text));
                saveOpen.Position = 0x3CB64 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x3CB68 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1CurrentSkill4None.Checked || comboBoxHMDigimonPartySlot1CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB6C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1CurrentSkill4Inherited.Checked);
                byte[] HMDigimonPartySlot1CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1CurrentSkill4.Text));
                saveOpen.Position = 0x3CB6C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x3CB70 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1CurrentSkill5None.Checked || comboBoxHMDigimonPartySlot1CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB74 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1CurrentSkill5Inherited.Checked);
                byte[] HMDigimonPartySlot1CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1CurrentSkill5.Text));
                saveOpen.Position = 0x3CB74 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x3CB78 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1CurrentSkill6None.Checked || comboBoxHMDigimonPartySlot1CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB7C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1CurrentSkill6Inherited.Checked);
                byte[] HMDigimonPartySlot1CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1CurrentSkill6.Text));
                saveOpen.Position = 0x3CB7C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1CurrentSkill6Set);
            }

            #endregion

            #region LearnedSkills1
            //Learned Skill 1
            saveOpen.Position = 0x3CB80 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill1None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB84 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill1Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill1.Text));
                saveOpen.Position = 0x3CB84 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill1Set);
            }

            //Learned Skill 2
            saveOpen.Position = 0x3CB88 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill2None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB8C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill2Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill2.Text));
                saveOpen.Position = 0x3CB8C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill2Set);
            }

            //Learned Skill 3
            saveOpen.Position = 0x3CB90 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill3None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB94 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill3Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill3.Text));
                saveOpen.Position = 0x3CB94 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill3Set);
            }

            //Learned Skill 4
            saveOpen.Position = 0x3CB98 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill4None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CB9C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill4Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill4.Text));
                saveOpen.Position = 0x3CB9C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill4Set);
            }

            //Learned Skill 5
            saveOpen.Position = 0x3CBA0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill5None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBA4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill5Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill5.Text));
                saveOpen.Position = 0x3CBA4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill5Set);
            }

            //Learned Skill 6
            saveOpen.Position = 0x3CBA8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill6None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBAC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill6Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill6.Text));
                saveOpen.Position = 0x3CBAC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill6Set);
            }

            //Learned Skill 7
            saveOpen.Position = 0x3CBB0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill7None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill7.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBB4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill7Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill7Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill7.Text));
                saveOpen.Position = 0x3CBB4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill7Set);
            }

            //Learned Skill 8
            saveOpen.Position = 0x3CBB8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill8None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill8.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBBC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill8Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill8Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill8.Text));
                saveOpen.Position = 0x3CBBC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill8Set);
            }

            //Learned Skill 9
            saveOpen.Position = 0x3CBC0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill9None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill9.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBC4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill9Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill9Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill9.Text));
                saveOpen.Position = 0x3CBC4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill9Set);
            }

            //Learned Skill 10
            saveOpen.Position = 0x3CBC8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill10None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill10.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBCC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill10Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill10Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill10.Text));
                saveOpen.Position = 0x3CBCC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill10Set);
            }

            //Learned Skill 11
            saveOpen.Position = 0x3CBD0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill11None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill11.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBD4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill11Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill11Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill11.Text));
                saveOpen.Position = 0x3CBD4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill11Set);
            }

            //Learned Skill 12
            saveOpen.Position = 0x3CBD8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill12None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill12.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBDC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill12Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill12Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill12.Text));
                saveOpen.Position = 0x3CBDC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill12Set);
            }

            //Learned Skill 13
            saveOpen.Position = 0x3CBE0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill13None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill13.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBE4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill13Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill13Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill13.Text));
                saveOpen.Position = 0x3CBE4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill13Set);
            }

            //Learned Skill 14
            saveOpen.Position = 0x3CBE8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill14None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill14.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBEC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill14Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill14Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill14.Text));
                saveOpen.Position = 0x3CBEC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill14Set);
            }

            //Learned Skill 15
            saveOpen.Position = 0x3CBF0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill15None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill15.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBE4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill15Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill15Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill15.Text));
                saveOpen.Position = 0x3CBE4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill15Set);
            }

            //Learned Skill 16
            saveOpen.Position = 0x3CBE8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill16None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill16.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBEC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill16Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill16Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill16.Text));
                saveOpen.Position = 0x3CBEC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill16Set);
            }

            //Learned Skill 17
            saveOpen.Position = 0x3CBF0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill17None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill17.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBF4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill17Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill17Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill17.Text));
                saveOpen.Position = 0x3CBF4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill17Set);
            }

            //Learned Skill 18
            saveOpen.Position = 0x3CBF8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill18None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill18.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CBFC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill18Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill18Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill18.Text));
                saveOpen.Position = 0x3CBFC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill18Set);
            }

            //Learned Skill 19
            saveOpen.Position = 0x3CC00 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill19None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill19.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CC04 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill19Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill19Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill19.Text));
                saveOpen.Position = 0x3CC04 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill19Set);
            }

            //Learned Skill 20
            saveOpen.Position = 0x3CC08 + 0x617A0;
            if (checkBoxHMDigimonPartySlot1LearnedSkill20None.Checked || comboBoxHMDigimonPartySlot1LearnedSkill20.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CC0C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot1LearnedSkill20Inherited.Checked);
                byte[] HMDigimonPartySlot1LearnedSkill20Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot1LearnedSkill20.Text));
                saveOpen.Position = 0x3CC0C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot1LearnedSkill20Set);
            }

            #endregion
            #endregion
            //Save second Digimon In Party data
            #region DigimonPartySlot2
            #region Main2
            //ID
            byte[] HMDigimonPartySlot2IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxHMDigimonPartySlot2ID.Text));
            saveOpen.Position = 0x3CCEC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2IDSet);

            //Nickname
            byte[] HMDigimonPartySlot2NicknameSet = Encoding.ASCII.GetBytes(textBoxHMDigimonPartySlot2Nickname.Text);
            saveOpen.Position = 0x3CCFC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2NicknameSet);
            if (HMDigimonPartySlot2NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - HMDigimonPartySlot2NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] HMDigimonPartySlot2DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxHMDigimonPartySlot2Digivolution.Text));
            saveOpen.Position = 0x3CCF8 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2DigivolutionSet);

            //Type
            byte[] HMDigimonPartySlot2TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxHMDigimonPartySlot2Type.Text));
            saveOpen.Position = 0x3CCF4 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2TypeSet);

            //Attribute
            byte[] HMDigimonPartySlot2AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxHMDigimonPartySlot2Attribute.Text));
            saveOpen.Position = 0x3CCF0 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2AttributeSet);

            //Personality
            byte[] HMDigimonPartySlot2PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxHMDigimonPartySlot2Personality.Text));
            saveOpen.Position = 0x3CD60 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2PersonalitySet);

            //Support Skills
            byte[] HMDigimonPartySlot2SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxHMDigmonPartySlot2SupportSkill.Text));
            saveOpen.Position = 0x3CF00 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2SupportSkillSet);
            #endregion

            #region Stats2
            //Equip Slots
            byte[] HMDigimonPartySlot2EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2EquipSlots.Value);
            saveOpen.Position = 0x3CF04 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2EquipSlotsSet);

            //Memory Use
            byte[] HMDigimonPartySlot2MemorySet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2Memory.Value);
            saveOpen.Position = 0x3CD44 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2MemorySet);

            //EXP
            byte[] HMDigimonPartySlot2EXPSet = BitConverter.GetBytes((int)numericUpDownHMDigimonPartySlot2EXP.Value);
            saveOpen.Position = 0x3CD58 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2EXPSet);

            //Current LVL
            byte[] HMDigimonPartySlot2CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2CurrentLVL.Value);
            saveOpen.Position = 0x3CD50 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2CurrentLVLSet);

            //Max Level
            byte[] HMDigimonPartySlot2MaxLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2MaxLVL.Value);
            saveOpen.Position = 0x3CD52 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2MaxLVLSet);

            //Extra Max Level
            byte[] HMDigimonPartySlot2ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CD54 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2ExtraMaxLVLSet);

            //Current HP
            byte[] HMDigimonPartySlot2CurrentHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2CurrentHP.Value);
            saveOpen.Position = 0x3CD64 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2CurrentHPSet);

            //Max HP
            byte[] HMDigimonPartySlot2MaxHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2MaxHP.Value / 10);
            saveOpen.Position = 0x3CD68 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2MaxHPSet);

            //Bonus HP
            byte[] HMDigimonPartySlot2BonusHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2BonusHP.Value);
            saveOpen.Position = 0x3CD6C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2BonusHPSet);

            //Current SP
            byte[] HMDigimonPartySlot2CurrentSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2CurrentSP.Value);
            saveOpen.Position = 0x3CD70 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2CurrentSPSet);

            //Max SP
            byte[] HMDigimonPartySlot2MaxSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2MaxSP.Value);
            saveOpen.Position = 0x3CD74 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2MaxSPSet);

            //Bonus SP
            byte[] HMDigimonPartySlot2BonusSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2BonusSP.Value);
            saveOpen.Position = 0x3CD78 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2BonusSPSet);

            //Attack
            byte[] HMDigimonPartySlot2AttackSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2Attack.Value);
            saveOpen.Position = 0x3CD7A + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2AttackSet);

            //Bonus Attack
            byte[] HMDigimonPartySlot2BonusAttackSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2BonusAttack.Value);
            saveOpen.Position = 0x3CD7C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2BonusAttackSet);

            //Defense
            byte[] HMDigimonPartySlot2DefenseSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2Defense.Value);
            saveOpen.Position = 0x3CD7E + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2DefenseSet);

            //Bonus Defense
            byte[] HMDigimonPartySlot2BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2BonusDefense.Value);
            saveOpen.Position = 0x3CD80 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2BonusDefenseSet);

            //Intelligence
            byte[] HMDigimonPartySlot2IntelligenceSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2Intelligence.Value);
            saveOpen.Position = 0x3CD82 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2IntelligenceSet);

            //Bonus Intelligence
            byte[] HMDigimonPartySlot2BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2BonusIntelligence.Value);
            saveOpen.Position = 0x3CD84 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2BonusIntelligenceSet);

            //Speed
            byte[] HMDigimonPartySlot2SpeedSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2Speed.Value);
            saveOpen.Position = 0x3CD86 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2SpeedSet);

            //Bonus Speed
            byte[] HMDigimonPartySlot2BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2BonusSpeed.Value);
            saveOpen.Position = 0x3CD88 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2BonusSpeedSet);

            //CAM
            byte[] HMDigimonPartySlot2CAMSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2CAM.Value);
            saveOpen.Position = 0x3CD8C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2CAMSet);

            //ABI
            byte[] HMDigimonPartySlot2ABISet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot2ABI.Value);
            saveOpen.Position = 0x3CD8A + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2ABISet);
            #endregion

            #region Equipment2
            //Equip 1
            byte[] HMDigimonPartySlot2Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot2Equip1.Text));
            saveOpen.Position = 0x3CF06 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2Equip1Set);

            //Equip 2
            byte[] HMDigimonPartySlot2Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot2Equip2.Text));
            saveOpen.Position = 0x3CF08 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2Equip2Set);

            //Equip 3
            byte[] HMDigimonPartySlot2Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot2Equip3.Text));
            saveOpen.Position = 0x3CF0A + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2Equip3Set);

            //Accessory
            byte[] HMDigimonPartySlot2AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxHMDigimonPartySlot2Accessory.Text));
            saveOpen.Position = 0x3CF0C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot2AccessorySet);
            #endregion

            #region CurrentSkills2
            //Current Skill 1
            saveOpen.Position = 0x3CD90 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2CurrentSkill1None.Checked || comboBoxHMDigimonPartySlot2CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CD94 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2CurrentSkill1Inherited.Checked);
                byte[] HMDigimonPartySlot2CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2CurrentSkill1.Text));
                saveOpen.Position = 0x3CD94 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x3CD98 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2CurrentSkill2None.Checked || comboBoxHMDigimonPartySlot2CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CD9C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2CurrentSkill2Inherited.Checked);
                byte[] HMDigimonPartySlot2CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2CurrentSkill2.Text));
                saveOpen.Position = 0x3CD9C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x3CDA0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2CurrentSkill3None.Checked || comboBoxHMDigimonPartySlot2CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDA4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2CurrentSkill3Inherited.Checked);
                byte[] HMDigimonPartySlot2CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2CurrentSkill3.Text));
                saveOpen.Position = 0x3CDA4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x3CDA8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2CurrentSkill4None.Checked || comboBoxHMDigimonPartySlot2CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDAC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2CurrentSkill4Inherited.Checked);
                byte[] HMDigimonPartySlot2CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2CurrentSkill4.Text));
                saveOpen.Position = 0x3CDAC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x3CDB0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2CurrentSkill5None.Checked || comboBoxHMDigimonPartySlot2CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDB4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2CurrentSkill5Inherited.Checked);
                byte[] HMDigimonPartySlot2CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2CurrentSkill5.Text));
                saveOpen.Position = 0x3CDB4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x3CDB8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2CurrentSkill6None.Checked || comboBoxHMDigimonPartySlot2CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDBC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2CurrentSkill6Inherited.Checked);
                byte[] HMDigimonPartySlot2CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2CurrentSkill6.Text));
                saveOpen.Position = 0x3CDBC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2CurrentSkill6Set);
            }

            #endregion

            #region LearnedSkills2
            //Learned Skill 1
            saveOpen.Position = 0x3CDC0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill1None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDC4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill1Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill1.Text));
                saveOpen.Position = 0x3CDC4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill1Set);
            }

            //Learned Skill 2
            saveOpen.Position = 0x3CDC8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill2None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDCC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill2Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill2.Text));
                saveOpen.Position = 0x3CDCC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill2Set);
            }

            //Learned Skill 3
            saveOpen.Position = 0x3CDD0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill3None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDD4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill3Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill3.Text));
                saveOpen.Position = 0x3CDD4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill3Set);
            }

            //Learned Skill 4
            saveOpen.Position = 0x3CDD8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill4None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDDC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill4Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill4.Text));
                saveOpen.Position = 0x3CDDC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill4Set);
            }

            //Learned Skill 5
            saveOpen.Position = 0x3CDE0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill5None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDE4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill5Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill5.Text));
                saveOpen.Position = 0x3CDE4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill5Set);
            }

            //Learned Skill 6
            saveOpen.Position = 0x3CDE8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill6None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDEC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill6Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill6.Text));
                saveOpen.Position = 0x3CDEC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill6Set);
            }

            //Learned Skill 7
            saveOpen.Position = 0x3CDF0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill7None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill7.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDF4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill7Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill7Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill7.Text));
                saveOpen.Position = 0x3CDF4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill7Set);
            }

            //Learned Skill 8
            saveOpen.Position = 0x3CDF8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill8None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill8.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CDFC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill8Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill8Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill8.Text));
                saveOpen.Position = 0x3CDFC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill8Set);
            }

            //Learned Skill 9
            saveOpen.Position = 0x3CE00 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill9None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill9.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE04 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill9Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill9Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill9.Text));
                saveOpen.Position = 0x3CE04 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill9Set);
            }

            //Learned Skill 10
            saveOpen.Position = 0x3CE08 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill10None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill10.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE0C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill10Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill10Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill10.Text));
                saveOpen.Position = 0x3CE0C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill10Set);
            }

            //Learned Skill 11
            saveOpen.Position = 0x3CE10 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill11None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill11.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE14 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill11Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill11Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill11.Text));
                saveOpen.Position = 0x3CE14 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill11Set);
            }

            //Learned Skill 12
            saveOpen.Position = 0x3CE18 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill12None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill12.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE1C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill12Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill12Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill12.Text));
                saveOpen.Position = 0x3CE1C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill12Set);
            }

            //Learned Skill 13
            saveOpen.Position = 0x3CE20 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill13None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill13.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE24 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill13Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill13Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill13.Text));
                saveOpen.Position = 0x3CE24 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill13Set);
            }

            //Learned Skill 14
            saveOpen.Position = 0x3CE28 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill14None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill14.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE2C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill14Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill14Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill14.Text));
                saveOpen.Position = 0x3CE2C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill14Set);
            }

            //Learned Skill 15
            saveOpen.Position = 0x3CE30 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill15None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill15.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE34 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill15Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill15Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill15.Text));
                saveOpen.Position = 0x3CE34 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill15Set);
            }

            //Learned Skill 16
            saveOpen.Position = 0x3CE38 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill16None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill16.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE3C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill16Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill16Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill16.Text));
                saveOpen.Position = 0x3CE3C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill16Set);
            }

            //Learned Skill 17
            saveOpen.Position = 0x3CE40 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill17None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill17.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE44 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill17Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill17Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill17.Text));
                saveOpen.Position = 0x3CE44 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill17Set);
            }

            //Learned Skill 18
            saveOpen.Position = 0x3CE48 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill18None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill18.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE4C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill18Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill18Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill18.Text));
                saveOpen.Position = 0x3CE4C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill18Set);
            }

            //Learned Skill 19
            saveOpen.Position = 0x3CE50 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill19None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill19.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE54 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill19Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill19Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill19.Text));
                saveOpen.Position = 0x3CE54 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill19Set);
            }

            //Learned Skill 20
            saveOpen.Position = 0x3CE58 + 0x617A0;
            if (checkBoxHMDigimonPartySlot2LearnedSkill20None.Checked || comboBoxHMDigimonPartySlot2LearnedSkill20.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CE5C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot2LearnedSkill20Inherited.Checked);
                byte[] HMDigimonPartySlot2LearnedSkill20Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot2LearnedSkill20.Text));
                saveOpen.Position = 0x3CE5C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot2LearnedSkill20Set);
            }

            #endregion

            //Save third Digimon In Party data
            #region DigimonPartySlot3
            #region Main3
            //ID
            byte[] HMDigimonPartySlot3IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxHMDigimonPartySlot3ID.Text));
            saveOpen.Position = 0x3CF2C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3IDSet);

            //Nickname
            byte[] HMDigimonPartySlot3NicknameSet = Encoding.ASCII.GetBytes(textBoxHMDigimonPartySlot3Nickname.Text);
            saveOpen.Position = 0x3CF3C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3NicknameSet);
            if (HMDigimonPartySlot3NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - HMDigimonPartySlot3NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] HMDigimonPartySlot3DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxHMDigimonPartySlot3Digivolution.Text));
            saveOpen.Position = 0x3CF38 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3DigivolutionSet);

            //Type
            byte[] HMDigimonPartySlot3TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxHMDigimonPartySlot3Type.Text));
            saveOpen.Position = 0x3CF34 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3TypeSet);

            //Attribute
            byte[] HMDigimonPartySlot3AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxHMDigimonPartySlot3Attribute.Text));
            saveOpen.Position = 0x3CF30 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3AttributeSet);

            //Personality
            byte[] HMDigimonPartySlot3PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxHMDigimonPartySlot3Personality.Text));
            saveOpen.Position = 0x3CFA0 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3PersonalitySet);

            //Support Skills
            byte[] HMDigimonPartySlot3SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxHMDigmonPartySlot3SupportSkill.Text));
            saveOpen.Position = 0x3D140 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3SupportSkillSet);
            #endregion

            #region Stats2
            //Equip Slots
            byte[] HMDigimonPartySlot3EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3EquipSlots.Value);
            saveOpen.Position = 0x3D144 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3EquipSlotsSet);

            //Memory Use
            byte[] HMDigimonPartySlot3MemorySet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3Memory.Value);
            saveOpen.Position = 0x3CF84 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3MemorySet);

            //EXP
            byte[] HMDigimonPartySlot3EXPSet = BitConverter.GetBytes((int)numericUpDownHMDigimonPartySlot3EXP.Value);
            saveOpen.Position = 0x3CF98 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3EXPSet);

            //Current LVL
            byte[] HMDigimonPartySlot3CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3CurrentLVL.Value);
            saveOpen.Position = 0x3CF90 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3CurrentLVLSet);

            //Max Level
            byte[] HMDigimonPartySlot3MaxLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3MaxLVL.Value);
            saveOpen.Position = 0x3CF92 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3MaxLVLSet);

            //Extra Max Level
            byte[] HMDigimonPartySlot3ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CF94 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3ExtraMaxLVLSet);

            //Current HP
            byte[] HMDigimonPartySlot3CurrentHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3CurrentHP.Value);
            saveOpen.Position = 0x3CFA4 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3CurrentHPSet);

            //Max HP
            byte[] HMDigimonPartySlot3MaxHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3MaxHP.Value / 10);
            saveOpen.Position = 0x3CFA8 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3MaxHPSet);

            //Bonus HP
            byte[] HMDigimonPartySlot3BonusHPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3BonusHP.Value);
            saveOpen.Position = 0x3CFAC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3BonusHPSet);

            //Current SP
            byte[] HMDigimonPartySlot3CurrentSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3CurrentSP.Value);
            saveOpen.Position = 0x3CFB0 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3CurrentSPSet);

            //Max SP
            byte[] HMDigimonPartySlot3MaxSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3MaxSP.Value);
            saveOpen.Position = 0x3CFB4 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3MaxSPSet);

            //Bonus SP
            byte[] HMDigimonPartySlot3BonusSPSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3BonusSP.Value);
            saveOpen.Position = 0x3CFB8 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3BonusSPSet);

            //Attack
            byte[] HMDigimonPartySlot3AttackSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3Attack.Value);
            saveOpen.Position = 0x3CFBA + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3AttackSet);

            //Bonus Attack
            byte[] HMDigimonPartySlot3BonusAttackSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3BonusAttack.Value);
            saveOpen.Position = 0x3CFBC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3BonusAttackSet);

            //Defense
            byte[] HMDigimonPartySlot3DefenseSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3Defense.Value);
            saveOpen.Position = 0x3CFBE + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3DefenseSet);

            //Bonus Defense
            byte[] HMDigimonPartySlot3BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3BonusDefense.Value);
            saveOpen.Position = 0x3CFC0 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3BonusDefenseSet);

            //Intelligence
            byte[] HMDigimonPartySlot3IntelligenceSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3Intelligence.Value);
            saveOpen.Position = 0x3CFC2 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3IntelligenceSet);

            //Bonus Intelligence
            byte[] HMDigimonPartySlot3BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3BonusIntelligence.Value);
            saveOpen.Position = 0x3CFC4 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3BonusIntelligenceSet);

            //Speed
            byte[] HMDigimonPartySlot3SpeedSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3Speed.Value);
            saveOpen.Position = 0x3CFC6 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3SpeedSet);

            //Bonus Speed
            byte[] HMDigimonPartySlot3BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3BonusSpeed.Value);
            saveOpen.Position = 0x3CFC8 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3BonusSpeedSet);

            //CAM
            byte[] HMDigimonPartySlot3CAMSet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3CAM.Value);
            saveOpen.Position = 0x3CFCC + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3CAMSet);

            //ABI
            byte[] HMDigimonPartySlot3ABISet = BitConverter.GetBytes((short)numericUpDownHMDigimonPartySlot3ABI.Value);
            saveOpen.Position = 0x3CFCA + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3ABISet);
            #endregion

            #region Equipment2
            //Equip 1
            byte[] HMDigimonPartySlot3Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot3Equip1.Text));
            saveOpen.Position = 0x3D146 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3Equip1Set);

            //Equip 2
            byte[] HMDigimonPartySlot3Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot3Equip2.Text));
            saveOpen.Position = 0x3D148 + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3Equip2Set);

            //Equip 3
            byte[] HMDigimonPartySlot3Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxHMDigimonPartySlot3Equip3.Text));
            saveOpen.Position = 0x3D14A + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3Equip3Set);

            //Accessory
            byte[] HMDigimonPartySlot3AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxHMDigimonPartySlot3Accessory.Text));
            saveOpen.Position = 0x3D14C + 0x617A0;
            saveWrite.Write(HMDigimonPartySlot3AccessorySet);
            #endregion

            #region CurrentSkills2
            //Current Skill 1
            saveOpen.Position = 0x3CFD0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3CurrentSkill1None.Checked || comboBoxHMDigimonPartySlot3CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFD4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3CurrentSkill1Inherited.Checked);
                byte[] HMDigimonPartySlot3CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3CurrentSkill1.Text));
                saveOpen.Position = 0x3CFD4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x3CFD8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3CurrentSkill2None.Checked || comboBoxHMDigimonPartySlot3CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFDC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3CurrentSkill2Inherited.Checked);
                byte[] HMDigimonPartySlot3CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3CurrentSkill2.Text));
                saveOpen.Position = 0x3CFDC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x3CFE0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3CurrentSkill3None.Checked || comboBoxHMDigimonPartySlot3CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFE4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3CurrentSkill3Inherited.Checked);
                byte[] HMDigimonPartySlot3CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3CurrentSkill3.Text));
                saveOpen.Position = 0x3CFE4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x3CFE8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3CurrentSkill4None.Checked || comboBoxHMDigimonPartySlot3CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFEC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3CurrentSkill4Inherited.Checked);
                byte[] HMDigimonPartySlot3CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3CurrentSkill4.Text));
                saveOpen.Position = 0x3CFEC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x3CFF0 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3CurrentSkill5None.Checked || comboBoxHMDigimonPartySlot3CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFF4 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3CurrentSkill5Inherited.Checked);
                byte[] HMDigimonPartySlot3CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3CurrentSkill5.Text));
                saveOpen.Position = 0x3CFF4 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x3CFF8 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3CurrentSkill6None.Checked || comboBoxHMDigimonPartySlot3CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3CFFC + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3CurrentSkill6Inherited.Checked);
                byte[] HMDigimonPartySlot3CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3CurrentSkill6.Text));
                saveOpen.Position = 0x3CFFC + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3CurrentSkill6Set);
            }

            #endregion

            #region LearnedSkills2
            //Learned Skill 1
            saveOpen.Position = 0x3D000 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill1None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D004 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill1Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill1.Text));
                saveOpen.Position = 0x3D004 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill1Set);
            }

            //Learned Skill 2
            saveOpen.Position = 0x3D008 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill2None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D00C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill2Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill2.Text));
                saveOpen.Position = 0x3D00C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill2Set);
            }

            //Learned Skill 3
            saveOpen.Position = 0x3D010 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill3None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D014 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill3Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill3.Text));
                saveOpen.Position = 0x3D014 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill3Set);
            }

            //Learned Skill 4
            saveOpen.Position = 0x3D018 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill4None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D01C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill4Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill4.Text));
                saveOpen.Position = 0x3D01C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill4Set);
            }

            //Learned Skill 5
            saveOpen.Position = 0x3D020 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill5None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D024 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill5Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill5.Text));
                saveOpen.Position = 0x3D024 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill5Set);
            }

            //Learned Skill 6
            saveOpen.Position = 0x3D028 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill6None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D02C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill6Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill6.Text));
                saveOpen.Position = 0x3D02C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill6Set);
            }

            //Learned Skill 7
            saveOpen.Position = 0x3D030 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill7None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill7.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D034 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill7Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill7Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill7.Text));
                saveOpen.Position = 0x3D034 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill7Set);
            }

            //Learned Skill 8
            saveOpen.Position = 0x3D038 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill8None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill8.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D03C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill8Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill8Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill8.Text));
                saveOpen.Position = 0x3D03C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill8Set);
            }

            //Learned Skill 9
            saveOpen.Position = 0x3D040 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill9None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill9.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D044 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill9Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill9Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill9.Text));
                saveOpen.Position = 0x3D044 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill9Set);
            }

            //Learned Skill 10
            saveOpen.Position = 0x3D048 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill10None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill10.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D04C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill10Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill10Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill10.Text));
                saveOpen.Position = 0x3D04C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill10Set);
            }

            //Learned Skill 11
            saveOpen.Position = 0x3D050 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill11None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill11.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D054 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill11Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill11Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill11.Text));
                saveOpen.Position = 0x3D054 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill11Set);
            }

            //Learned Skill 12
            saveOpen.Position = 0x3D058 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill12None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill12.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D05C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill12Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill12Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill12.Text));
                saveOpen.Position = 0x3D05C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill12Set);
            }

            //Learned Skill 13
            saveOpen.Position = 0x3D060 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill13None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill13.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D064 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill13Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill13Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill13.Text));
                saveOpen.Position = 0x3D064 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill13Set);
            }

            //Learned Skill 14
            saveOpen.Position = 0x3D068 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill14None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill14.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D06C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill14Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill14Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill14.Text));
                saveOpen.Position = 0x3D06C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill14Set);
            }

            //Learned Skill 15
            saveOpen.Position = 0x3D070 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill15None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill15.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D074 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill15Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill15Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill15.Text));
                saveOpen.Position = 0x3D074 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill15Set);
            }

            //Learned Skill 16
            saveOpen.Position = 0x3D078 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill16None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill16.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D07C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill16Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill16Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill16.Text));
                saveOpen.Position = 0x3D07C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill16Set);
            }

            //Learned Skill 17
            saveOpen.Position = 0x3D080 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill17None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill17.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D084 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill17Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill17Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill17.Text));
                saveOpen.Position = 0x3D084 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill17Set);
            }

            //Learned Skill 18
            saveOpen.Position = 0x3D088 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill18None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill18.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D08C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill18Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill18Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill18.Text));
                saveOpen.Position = 0x3D08C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill18Set);
            }

            //Learned Skill 19
            saveOpen.Position = 0x3D090 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill19None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill19.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D094 + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill19Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill19Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill19.Text));
                saveOpen.Position = 0x3D094 + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill19Set);
            }

            //Learned Skill 20
            saveOpen.Position = 0x3D098 + 0x617A0;
            if (checkBoxHMDigimonPartySlot3LearnedSkill20None.Checked || comboBoxHMDigimonPartySlot3LearnedSkill20.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x3D09C + 0x617A0;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxHMDigimonPartySlot3LearnedSkill20Inherited.Checked);
                byte[] HMDigimonPartySlot3LearnedSkill20Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxHMDigimonPartySlot3LearnedSkill20.Text));
                saveOpen.Position = 0x3D09C + 0x617A0;
                saveWrite.Write(HMDigimonPartySlot3LearnedSkill20Set);
            }

            #endregion
            #endregion
            saveOpen.Close();
        }
        #endregion
        string convertDigimonIDtoString(short ID)
        {
            int index = 0;
            string stringID;
            if (ID < 10)
                stringID = "00" + ID.ToString();
            else if (ID > 9 && ID < 100)
                stringID = "0" + ID.ToString();
            else
                stringID = ID.ToString();

            while (digimonIDs[index].IndexOf(stringID) == -1)
            {
                index++;
            }

            return digimonIDs[index].Substring(stringID.Length + 1);
        }

        short convertStringtoDigimonID(string name)
        {
            int index = 0;

            while(digimonIDs[index].IndexOf(":" + name) == -1)
            {
                index++;
            }
            
            return short.Parse(digimonIDs[index].Substring(0, digimonIDs[index].IndexOf(name) - 1));
        }

        string convertDigivolutionIDtoString(short ID)
        {
            string digivolution;

            switch (ID)
            {
                case 0:
                    digivolution = "Egg?";
                    break;
                case 1:
                    digivolution = "Training I";
                    break;
                case 2:
                    digivolution = "Training II";
                    break;
                case 3:
                    digivolution = "Rookie";
                    break;
                case 4:
                    digivolution = "Champion";
                    break;
                case 5:
                    digivolution = "Ultimate";
                    break;
                case 6:
                    digivolution = "Mega";
                    break;
                case 7:
                    digivolution = "Ultra";
                    break;
                case 8:
                    digivolution = "Armor";
                    break;
                case 9:
                    digivolution = "Boss";
                    break;
                default:
                    digivolution = "";
                    break;
            }

            return digivolution;
        }

        short convertStringtoDigivolutionID(string digivolution)
        {
            short digivolutionID;

            switch (digivolution)
            {
                case "Egg?":
                    digivolutionID = 0;
                    break;
                case "Training I":
                    digivolutionID = 1;
                    break;
                case "Training II":
                    digivolutionID = 2;
                    break;
                case "Rookie":
                    digivolutionID = 3;
                    break;
                case "Champion":
                    digivolutionID = 4;
                    break;
                case "Ultimate":
                    digivolutionID = 5;
                    break;
                case "Mega":
                    digivolutionID = 6;
                    break;
                case "Ultra":
                    digivolutionID = 7;
                    break;
                case "Armor":
                    digivolutionID = 8;
                    break;
                case "Boss":
                    digivolutionID = 9;
                    break;
                default:
                    digivolutionID = 4;
                    break;
            }

            return digivolutionID;
        }

        string convertTypeIDtoString(short ID)
        {
            string type;

            switch (ID)
            {
                case 0:
                    type = "Free";
                    break;
                case 1:
                    type = "Virus";
                    break;
                case 2:
                    type = "Vaccine";
                    break;
                case 3:
                    type = "Data";
                    break;
                default:
                    type = "";
                    break;
            }

            return type;
        }

        short convertStringtoTypeID(string type)
        {
            short typeID;

            switch (type)
            {
                case "Free":
                    typeID = 0;
                    break;
                case "Virus":
                    typeID = 1;
                    break;
                case "Vaccine":
                    typeID = 2;
                    break;
                case "Data":
                    typeID = 3;
                    break;
                default:
                    typeID = 3;
                    break;
            }

            return typeID;
        }

        string convertAttributeIDtoString(short ID)
        {
            string attribute;

            switch (ID)
            {
                case 0:
                    attribute = "Neutral";
                    break;
                case 1:
                    attribute = "Fire";
                    break;
                case 2:
                    attribute = "Water";
                    break;
                case 3:
                    attribute = "Plant";
                    break;
                case 4:
                    attribute = "Electric";
                    break;
                case 5:
                    attribute = "Earth";
                    break;
                case 6:
                    attribute = "Wind";
                    break;
                case 7:
                    attribute = "Light";
                    break;
                case 8:
                    attribute = "Dark";
                    break;
                default:
                    attribute = "";
                    break;
            }

            return attribute;
        }

        short convertStringtoAttributeID(string attribute)
        {
            short attributeID;

            switch (attribute)
            {
                case "Neutral":
                    attributeID = 0;
                    break;
                case "Fire":
                    attributeID = 1;
                    break;
                case "Water":
                    attributeID = 2;
                    break;
                case "Plant":
                    attributeID = 3;
                    break;
                case "Electric":
                    attributeID = 4;
                    break;
                case "Earth":
                    attributeID = 5;
                    break;
                case "Wind":
                    attributeID = 6;
                    break;
                case "Light":
                    attributeID = 7;
                    break;
                case "Dark":
                    attributeID = 8;
                    break;
                default:
                    attributeID = 0;
                    break;
            }

            return attributeID;
        }

        string convertPersonalityIDtoString(short personalityID)
        {
            string personality;

            switch (personalityID)
            {
                case 1:
                    personality = "Durable (HP)";
                    break;
                case 2:
                    personality = "Lively (SP)";
                    break;
                case 3:
                    personality = "Fighter (ATK)";
                    break;
                case 4:
                    personality = "Defender (DEF)";
                    break;
                case 5:
                    personality = "Brainy (INT)";
                    break;
                case 6:
                    personality = "Nimble (SPD)";
                    break;
                case 7:
                    personality = "Builder (Development)";
                    break;
                case 8:
                    personality = "Searcher (Investigation)";
                    break;
                default:
                    personality = "";
                    break;
            }

            return personality;
        }

        short convertStringtoPersonalityID(string personality)
        {
            short personalityID;

            switch (personality)
            {
                case "Durable HP":
                    personalityID = 1;
                    break;
                case "Lively (SP)":
                    personalityID = 2;
                    break;
                case "Fighter (ATK)":
                    personalityID = 3;
                    break;
                case "Defender (DEF)":
                    personalityID = 4;
                    break;
                case "Brainy (INT)":
                    personalityID = 5;
                    break;
                case "Nimble (SPD)":
                    personalityID = 6;
                    break;
                case "Builder (Development)":
                    personalityID = 7;
                    break;
                case "Searcher (Investigation)":
                    personalityID = 8;
                    break;
                default:
                    personalityID = 1;
                    break;
            }

            return personalityID;
        }

        string convertsupportSkillsIDtoString(short ID)
        {
            int index = 0;

            while(supportSkills[index].IndexOf(ID.ToString()) == -1)
            {
                index++;
            }

            return supportSkills[index].Substring(ID.ToString().Length + 1);
        }

        short convertStringtoSupportSkillID (string supportSkill)
        {
            int index = 0;

            while(supportSkills[index].IndexOf(supportSkill) == -1)
            {
                index++;
            }
            
            return short.Parse(supportSkills[index].Substring(0, supportSkills[index].IndexOf(supportSkill) - 1));
        }

        string convertEquipIDtoString(short ID)
        {
            int index = 0;

            while(equipment[index].IndexOf(ID.ToString()) == -1)
            {
                index++;
            }

            return equipment[index].Substring(ID.ToString().Length + 1);
        }

        short convertStringtoEquipID(string equip)
        {
            int index = 0;

            while(equipment[index].IndexOf(equip) == -1)
            {
                index++;
            }

            return short.Parse(equipment[index].Substring(0, equipment[index].IndexOf(equip) - 1));
        }

        string convertAccessoryIDtoString(short ID)
        {
            int index = 0;

            while (accessories[index].IndexOf(ID.ToString()) == -1)
            {
                index++;
            }

            return accessories[index].Substring(ID.ToString().Length + 1);
        }

        short convertStringtoAccessoryID(string accessory)
        {
            int index = 0;

            while (accessories[index].IndexOf(accessory) == -1)
            {
                index++;
            }

            return short.Parse(accessories[index].Substring(0, accessories[index].IndexOf(accessory) - 1));
        }

        string convertSkillIDtoString(short ID)
        {
            int index = 0;

            while (skills[index].IndexOf(ID.ToString()) == -1)
            {
                index++;
            }

            return skills[index].Substring(ID.ToString().Length + 1);
        }

        short convertStringtoSkillID(string skill)
        {
            int index = 0;

            while(skills[index].IndexOf(skill) == -1)
            {
                index++;
            }

            return short.Parse(skills[index].Substring(0, skills[index].IndexOf(skill) - 1));
        }

        void getDigimonPortraitsCS(int slot)
        {
            short ID = 0;

            if (slot == 1)
            {
                try
                {
                    ID = convertStringtoDigimonID(comboBoxCSDigimonPartySlot1ID.Text);
                }
                catch (System.FormatException)
                {
                    ID = 0;
                }


                if (ID < 10)
                {
                    pictureBoxCSDigimonPartySlot1Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field00" + ID);
                    pictureBoxCSDigimonPartySlot1Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot00" + ID);
                }

                else if(ID > 9 && ID < 100)
                {
                    pictureBoxCSDigimonPartySlot1Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field0" + ID);
                    pictureBoxCSDigimonPartySlot1Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot0" + ID);
                }

                else
                {
                    pictureBoxCSDigimonPartySlot1Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field" + ID);
                    pictureBoxCSDigimonPartySlot1Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot" + ID);
                }

                pictureBoxCSDigimonPartySlot1Portrait.Refresh();
                pictureBoxCSDigimonPartySlot1Portrait.Visible = true;
            }

            else if (slot == 2)
            {
                try
                {
                    ID = convertStringtoDigimonID(comboBoxCSDigimonPartySlot2ID.Text);
                }
                catch (System.FormatException)
                {
                    ID = 0;
                }


                if (ID < 100)
                {
                    pictureBoxCSDigimonPartySlot2Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field0" + ID);
                    pictureBoxCSDigimonPartySlot2Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot0" + ID);
                }
                else
                {
                    pictureBoxCSDigimonPartySlot2Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field" + ID);
                    pictureBoxCSDigimonPartySlot2Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot" + ID);
                }

                pictureBoxCSDigimonPartySlot2Portrait.Refresh();
                pictureBoxCSDigimonPartySlot2Portrait.Visible = true;
            }

            else if (slot == 3)
            {
                try
                {
                    ID = convertStringtoDigimonID(comboBoxCSDigimonPartySlot3ID.Text);
                }
                catch (System.FormatException)
                {
                    ID = 0;
                }


                if (ID < 100)
                {
                    pictureBoxCSDigimonPartySlot3Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field0" + ID);
                    pictureBoxCSDigimonPartySlot3Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot0" + ID);
                }
                else
                {
                    pictureBoxCSDigimonPartySlot3Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field" + ID);
                    pictureBoxCSDigimonPartySlot3Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot" + ID);
                }

                pictureBoxCSDigimonPartySlot3Portrait.Refresh();
                pictureBoxCSDigimonPartySlot3Portrait.Visible = true;
            }
        }

        void getDigimonPortraitsHM(int slot)
        {
            short ID = 0;

            if (slot == 1)
            {
                try
                {
                    ID = convertStringtoDigimonID(comboBoxHMDigimonPartySlot1ID.Text);
                }
                catch (System.FormatException)
                {
                    ID = 0;
                }


                if (ID < 10)
                {
                    pictureBoxHMDigimonPartySlot1Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field00" + ID);
                    pictureBoxHMDigimonPartySlot1Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot00" + ID);
                }

                else if(ID > 9 && ID < 100)
                {
                    pictureBoxHMDigimonPartySlot1Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field0" + ID);
                    pictureBoxHMDigimonPartySlot1Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot0" + ID);
                }

                else
                {
                    pictureBoxHMDigimonPartySlot1Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field" + ID);
                    pictureBoxHMDigimonPartySlot1Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot" + ID);
                }

                pictureBoxHMDigimonPartySlot1Portrait.Refresh();
                pictureBoxHMDigimonPartySlot1Portrait.Visible = true;
            }

            else if (slot == 2)
            {
                try
                {
                    ID = convertStringtoDigimonID(comboBoxHMDigimonPartySlot2ID.Text);
                }
                catch (System.FormatException)
                {
                    ID = 0;
                }


                if (ID < 100)
                {
                    pictureBoxHMDigimonPartySlot2Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field0" + ID);
                    pictureBoxHMDigimonPartySlot2Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot0" + ID);
                }
                else
                {
                    pictureBoxHMDigimonPartySlot2Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field" + ID);
                    pictureBoxHMDigimonPartySlot2Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot" + ID);
                }

                pictureBoxHMDigimonPartySlot2Portrait.Refresh();
                pictureBoxHMDigimonPartySlot2Portrait.Visible = true;
            }

            else if (slot == 3)
            {
                try
                {
                    ID = convertStringtoDigimonID(comboBoxHMDigimonPartySlot3ID.Text);
                }
                catch (System.FormatException)
                {
                    ID = 0;
                }


                if (ID < 100)
                {
                    pictureBoxHMDigimonPartySlot3Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field0" + ID);
                    pictureBoxHMDigimonPartySlot3Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot0" + ID);
                }
                else
                {
                    pictureBoxHMDigimonPartySlot3Portrait.Image = (Image)Properties.Resources.ResourceManager.GetObject("field" + ID);
                    pictureBoxHMDigimonPartySlot3Dot.Image = (Image)Properties.Resources.ResourceManager.GetObject("dot" + ID);
                }

                pictureBoxHMDigimonPartySlot3Portrait.Refresh();
                pictureBoxHMDigimonPartySlot3Portrait.Visible = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDlg();

            if (string.IsNullOrEmpty(savegame))
            {
                MessageBox.Show("No savegame selected!");
            }

            else
            {
                getDataCS();
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setDataCS();
            MessageBox.Show("Data saved!");
        }

        private void numericUpDownCSDigimonPartySlot1CurrentSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownCSDigimonPartySlot1LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageCSDigimonPartySlot1CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCSDigimonPartySlot1ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraits(1);
        }

        private void comboBoxCSDigimonPartySlot2ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraitsCS(2);
        }

        private void comboBoxCSDigimonPartySlot3ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraitsCS(3);
        }

        private void comboBoxHMDigimonPartySlot1ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraitsHM(1);
        }

        private void comboBoxHMDigimonPartySlot2ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraitsHM(2);
        }

        private void comboBoxHMDigimonPartySlot3ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraitsHM(3);
        }

        private void checkBoxCSDigimonPartySlot1CurrentSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1CurrentSkill1None.Checked)
            {
                comboBoxCSDigimonPartySlot1CurrentSkill1.Text = "(None)";
                comboBoxCSDigimonPartySlot1CurrentSkill1.Enabled = false;
                checkBoxCSDigimonPartySlot1CurrentSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1CurrentSkill1.Enabled = true;
                checkBoxCSDigimonPartySlot1CurrentSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1CurrentSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1CurrentSkill2None.Checked)
            {
                comboBoxCSDigimonPartySlot1CurrentSkill2.Text = "(None)";
                comboBoxCSDigimonPartySlot1CurrentSkill2.Enabled = false;
                checkBoxCSDigimonPartySlot1CurrentSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1CurrentSkill2.Enabled = true;
                checkBoxCSDigimonPartySlot1CurrentSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1CurrentSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1CurrentSkill3None.Checked)
            {
                comboBoxCSDigimonPartySlot1CurrentSkill3.Text = "(None)";
                comboBoxCSDigimonPartySlot1CurrentSkill3.Enabled = false;
                checkBoxCSDigimonPartySlot1CurrentSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1CurrentSkill3.Enabled = true;
                checkBoxCSDigimonPartySlot1CurrentSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1CurrentSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1CurrentSkill4None.Checked)
            {
                comboBoxCSDigimonPartySlot1CurrentSkill4.Text = "(None)";
                comboBoxCSDigimonPartySlot1CurrentSkill4.Enabled = false;
                checkBoxCSDigimonPartySlot1CurrentSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1CurrentSkill4.Enabled = true;
                checkBoxCSDigimonPartySlot1CurrentSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1CurrentSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1CurrentSkill5None.Checked)
            {
                comboBoxCSDigimonPartySlot1CurrentSkill5.Text = "(None)";
                comboBoxCSDigimonPartySlot1CurrentSkill5.Enabled = false;
                checkBoxCSDigimonPartySlot1CurrentSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1CurrentSkill5.Enabled = true;
                checkBoxCSDigimonPartySlot1CurrentSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1CurrentSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1CurrentSkill6None.Checked)
            {
                comboBoxCSDigimonPartySlot1CurrentSkill6.Text = "(None)";
                comboBoxCSDigimonPartySlot1CurrentSkill6.Enabled = false;
                checkBoxCSDigimonPartySlot1CurrentSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1CurrentSkill6.Enabled = true;
                checkBoxCSDigimonPartySlot1CurrentSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill1None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill1.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill1.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill1.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill2None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill2.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill2.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill2.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill3None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill3.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill3.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill3.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill4None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill4.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill4.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill4.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill5None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill5.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill5.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill5.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill6None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill6.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill6.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill6.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill7None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill7None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill7.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill7.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill7Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill7.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill7Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill8None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill8None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill8.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill8.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill8Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill8.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill8Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill9None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill9None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill9.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill9.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill9Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill9.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill9Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill10None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill10None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill10.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill10.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill10Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill10.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill10Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill11None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill11None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill11.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill11.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill11Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill11.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill11Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill12None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill12None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill12.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill12.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill12Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill12.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill12Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill13None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill13None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill13.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill13.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill13Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill13.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill13Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill14None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill14None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill14.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill14.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill14Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill14.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill14Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill15None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill15None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill15.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill15.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill15Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill15.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill15Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill16None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill16None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill16.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill16.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill16Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill16.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill16Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill17None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill17None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill17.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill17.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill17Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill17.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill17Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill18None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill18None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill18.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill18.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill18Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill18.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill18Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill19None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill19None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill19.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill19.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill19Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill19.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill19Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1LearnedSkill20None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1LearnedSkill20None.Checked)
            {
                comboBoxCSDigimonPartySlot1LearnedSkill20.Text = "(None)";
                comboBoxCSDigimonPartySlot1LearnedSkill20.Enabled = false;
                checkBoxCSDigimonPartySlot1LearnedSkill20Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1LearnedSkill20.Enabled = true;
                checkBoxCSDigimonPartySlot1LearnedSkill20Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot1None.Checked)
            {
                comboBoxCSDigimonPartySlot1ID.Enabled = false;
                tabControlCSDigimonPartySlot1Skills.Enabled = false;
                textBoxCSDigimonPartySlot1Nickname.Enabled = false;
                comboBoxCSDigimonPartySlot1Digivolution.Enabled = false;
                comboBoxCSDigimonPartySlot1Type.Enabled = false;
                comboBoxCSDigimonPartySlot1Attribute.Enabled = false;
                comboBoxCSDigimonPartySlot1Personality.Enabled = false;
                comboBoxCSDigmonPartySlot1SupportSkill.Enabled = false;
                numericUpDownCSDigimonPartySlot1EquipSlots.Enabled = false;
                numericUpDownCSDigimonPartySlot1Memory.Enabled = false;
                numericUpDownCSDigimonPartySlot1EXP.Enabled = false;
                numericUpDownCSDigimonPartySlot1CurrentLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot1MaxLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot1ExtraMaxLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot1CurrentHP.Enabled = false;
                numericUpDownCSDigimonPartySlot1MaxHP.Enabled = false;
                numericUpDownCSDigimonPartySlot1BonusHP.Enabled = false;
                numericUpDownCSDigimonPartySlot1CurrentSP.Enabled = false;
                numericUpDownCSDigimonPartySlot1MaxSP.Enabled = false;
                numericUpDownCSDigimonPartySlot1BonusSP.Enabled = false;
                numericUpDownCSDigimonPartySlot1Attack.Enabled = false;
                numericUpDownCSDigimonPartySlot1BonusAttack.Enabled = false;
                numericUpDownCSDigimonPartySlot1Defense.Enabled = false;
                numericUpDownCSDigimonPartySlot1BonusDefense.Enabled = false;
                numericUpDownCSDigimonPartySlot1Intelligence.Enabled = false;
                numericUpDownCSDigimonPartySlot1BonusIntelligence.Enabled = false;
                numericUpDownCSDigimonPartySlot1Speed.Enabled = false;
                numericUpDownCSDigimonPartySlot1BonusSpeed.Enabled = false;
                numericUpDownCSDigimonPartySlot1CAM.Enabled = false;
                numericUpDownCSDigimonPartySlot1ABI.Enabled = false;
                comboBoxCSDigimonPartySlot1Accessory.Enabled = false;
                comboBoxCSDigimonPartySlot1Equip1.Enabled = false;
                comboBoxCSDigimonPartySlot1Equip2.Enabled = false;
                comboBoxCSDigimonPartySlot1Equip3.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot1ID.Enabled = true;
                tabControlCSDigimonPartySlot1Skills.Enabled = true;
                textBoxCSDigimonPartySlot1Nickname.Enabled = true;
                comboBoxCSDigimonPartySlot1Digivolution.Enabled = true;
                comboBoxCSDigimonPartySlot1Type.Enabled = true;
                comboBoxCSDigimonPartySlot1Attribute.Enabled = true;
                comboBoxCSDigimonPartySlot1Personality.Enabled = true;
                comboBoxCSDigmonPartySlot1SupportSkill.Enabled = true;
                numericUpDownCSDigimonPartySlot1EquipSlots.Enabled = true;
                numericUpDownCSDigimonPartySlot1Memory.Enabled = true;
                numericUpDownCSDigimonPartySlot1EXP.Enabled = true;
                numericUpDownCSDigimonPartySlot1CurrentLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot1MaxLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot1ExtraMaxLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot1CurrentHP.Enabled = true;
                numericUpDownCSDigimonPartySlot1MaxHP.Enabled = true;
                numericUpDownCSDigimonPartySlot1BonusHP.Enabled = true;
                numericUpDownCSDigimonPartySlot1CurrentSP.Enabled = true;
                numericUpDownCSDigimonPartySlot1MaxSP.Enabled = true;
                numericUpDownCSDigimonPartySlot1BonusSP.Enabled = true;
                numericUpDownCSDigimonPartySlot1Attack.Enabled = true;
                numericUpDownCSDigimonPartySlot1BonusAttack.Enabled = true;
                numericUpDownCSDigimonPartySlot1Defense.Enabled = true;
                numericUpDownCSDigimonPartySlot1BonusDefense.Enabled = true;
                numericUpDownCSDigimonPartySlot1Intelligence.Enabled = true;
                numericUpDownCSDigimonPartySlot1BonusIntelligence.Enabled = true;
                numericUpDownCSDigimonPartySlot1Speed.Enabled = true;
                numericUpDownCSDigimonPartySlot1BonusSpeed.Enabled = true;
                numericUpDownCSDigimonPartySlot1CAM.Enabled = true;
                numericUpDownCSDigimonPartySlot1ABI.Enabled = true;
                comboBoxCSDigimonPartySlot1Accessory.Enabled = true;
                comboBoxCSDigimonPartySlot1Equip1.Enabled = true;
                comboBoxCSDigimonPartySlot1Equip2.Enabled = true;
                comboBoxCSDigimonPartySlot1Equip3.Enabled = true;
            }
        }

        private void numericUpDownCSDigimonPartySlot2CurrentSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownCSDigimonPartySlot2LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageCSDigimonPartySlot2CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxCSDigimonPartySlot2CurrentSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2CurrentSkill1None.Checked)
            {
                comboBoxCSDigimonPartySlot2CurrentSkill1.Text = "(None)";
                comboBoxCSDigimonPartySlot2CurrentSkill1.Enabled = false;
                checkBoxCSDigimonPartySlot2CurrentSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2CurrentSkill1.Enabled = true;
                checkBoxCSDigimonPartySlot2CurrentSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2CurrentSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2CurrentSkill2None.Checked)
            {
                comboBoxCSDigimonPartySlot2CurrentSkill2.Text = "(None)";
                comboBoxCSDigimonPartySlot2CurrentSkill2.Enabled = false;
                checkBoxCSDigimonPartySlot2CurrentSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2CurrentSkill2.Enabled = true;
                checkBoxCSDigimonPartySlot2CurrentSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2CurrentSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2CurrentSkill3None.Checked)
            {
                comboBoxCSDigimonPartySlot2CurrentSkill3.Text = "(None)";
                comboBoxCSDigimonPartySlot2CurrentSkill3.Enabled = false;
                checkBoxCSDigimonPartySlot2CurrentSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2CurrentSkill3.Enabled = true;
                checkBoxCSDigimonPartySlot2CurrentSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2CurrentSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2CurrentSkill4None.Checked)
            {
                comboBoxCSDigimonPartySlot2CurrentSkill4.Text = "(None)";
                comboBoxCSDigimonPartySlot2CurrentSkill4.Enabled = false;
                checkBoxCSDigimonPartySlot2CurrentSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2CurrentSkill4.Enabled = true;
                checkBoxCSDigimonPartySlot2CurrentSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2CurrentSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2CurrentSkill5None.Checked)
            {
                comboBoxCSDigimonPartySlot2CurrentSkill5.Text = "(None)";
                comboBoxCSDigimonPartySlot2CurrentSkill5.Enabled = false;
                checkBoxCSDigimonPartySlot2CurrentSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2CurrentSkill5.Enabled = true;
                checkBoxCSDigimonPartySlot2CurrentSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2CurrentSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2CurrentSkill6None.Checked)
            {
                comboBoxCSDigimonPartySlot2CurrentSkill6.Text = "(None)";
                comboBoxCSDigimonPartySlot2CurrentSkill6.Enabled = false;
                checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2CurrentSkill6.Enabled = true;
                checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill1None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill1.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill1.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill1.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill2None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill2.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill2.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill2.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill3None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill3.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill3.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill3.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill4None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill4.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill4.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill4.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill5None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill5.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill5.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill5.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill6None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill6.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill6.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill6.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill7None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill7None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill7.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill7.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill7Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill7.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill7Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill8None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill8None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill8.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill8.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill8Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill8.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill8Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill9None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill9None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill9.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill9.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill9Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill9.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill9Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill10None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill10None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill10.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill10.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill10Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill10.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill10Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill11None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill11None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill11.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill11.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill11Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill11.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill11Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill12None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill12None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill12.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill12.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill12Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill12.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill12Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill13None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill13None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill13.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill13.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill13Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill13.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill13Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill14None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill14None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill14.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill14.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill14Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill14.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill14Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill15None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill15None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill15.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill15.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill15Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill15.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill15Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill16None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill16None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill16.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill16.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill16Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill16.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill16Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill17None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill17None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill17.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill17.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill17Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill17.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill17Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill18None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill18None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill18.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill18.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill18Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill18.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill18Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill19None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill19None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill19.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill19.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill19Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill19.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill19Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2LearnedSkill20None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2LearnedSkill20None.Checked)
            {
                comboBoxCSDigimonPartySlot2LearnedSkill20.Text = "(None)";
                comboBoxCSDigimonPartySlot2LearnedSkill20.Enabled = false;
                checkBoxCSDigimonPartySlot2LearnedSkill20Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2LearnedSkill20.Enabled = true;
                checkBoxCSDigimonPartySlot2LearnedSkill20Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot2None.Checked)
            {
                comboBoxCSDigimonPartySlot2ID.Enabled = false;
                tabControlCSDigimonPartySlot2Skills.Enabled = false;
                textBoxCSDigimonPartySlot2Nickname.Enabled = false;
                comboBoxCSDigimonPartySlot2Digivolution.Enabled = false;
                comboBoxCSDigimonPartySlot2Type.Enabled = false;
                comboBoxCSDigimonPartySlot2Attribute.Enabled = false;
                comboBoxCSDigimonPartySlot2Personality.Enabled = false;
                comboBoxCSDigmonPartySlot2SupportSkill.Enabled = false;
                numericUpDownCSDigimonPartySlot2EquipSlots.Enabled = false;
                numericUpDownCSDigimonPartySlot2Memory.Enabled = false;
                numericUpDownCSDigimonPartySlot2EXP.Enabled = false;
                numericUpDownCSDigimonPartySlot2CurrentLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot2MaxLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot2ExtraMaxLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot2CurrentHP.Enabled = false;
                numericUpDownCSDigimonPartySlot2MaxHP.Enabled = false;
                numericUpDownCSDigimonPartySlot2BonusHP.Enabled = false;
                numericUpDownCSDigimonPartySlot2CurrentSP.Enabled = false;
                numericUpDownCSDigimonPartySlot2MaxSP.Enabled = false;
                numericUpDownCSDigimonPartySlot2BonusSP.Enabled = false;
                numericUpDownCSDigimonPartySlot2Attack.Enabled = false;
                numericUpDownCSDigimonPartySlot2BonusAttack.Enabled = false;
                numericUpDownCSDigimonPartySlot2Defense.Enabled = false;
                numericUpDownCSDigimonPartySlot2BonusDefense.Enabled = false;
                numericUpDownCSDigimonPartySlot2Intelligence.Enabled = false;
                numericUpDownCSDigimonPartySlot2BonusIntelligence.Enabled = false;
                numericUpDownCSDigimonPartySlot2Speed.Enabled = false;
                numericUpDownCSDigimonPartySlot2BonusSpeed.Enabled = false;
                numericUpDownCSDigimonPartySlot2CAM.Enabled = false;
                numericUpDownCSDigimonPartySlot2ABI.Enabled = false;
                comboBoxCSDigimonPartySlot2Accessory.Enabled = false;
                comboBoxCSDigimonPartySlot2Equip1.Enabled = false;
                comboBoxCSDigimonPartySlot2Equip2.Enabled = false;
                comboBoxCSDigimonPartySlot2Equip3.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot2ID.Enabled = true;
                tabControlCSDigimonPartySlot2Skills.Enabled = true;
                textBoxCSDigimonPartySlot2Nickname.Enabled = true;
                comboBoxCSDigimonPartySlot2Digivolution.Enabled = true;
                comboBoxCSDigimonPartySlot2Type.Enabled = true;
                comboBoxCSDigimonPartySlot2Attribute.Enabled = true;
                comboBoxCSDigimonPartySlot2Personality.Enabled = true;
                comboBoxCSDigmonPartySlot2SupportSkill.Enabled = true;
                numericUpDownCSDigimonPartySlot2EquipSlots.Enabled = true;
                numericUpDownCSDigimonPartySlot2Memory.Enabled = true;
                numericUpDownCSDigimonPartySlot2EXP.Enabled = true;
                numericUpDownCSDigimonPartySlot2CurrentLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot2MaxLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot2ExtraMaxLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot2CurrentHP.Enabled = true;
                numericUpDownCSDigimonPartySlot2MaxHP.Enabled = true;
                numericUpDownCSDigimonPartySlot2BonusHP.Enabled = true;
                numericUpDownCSDigimonPartySlot2CurrentSP.Enabled = true;
                numericUpDownCSDigimonPartySlot2MaxSP.Enabled = true;
                numericUpDownCSDigimonPartySlot2BonusSP.Enabled = true;
                numericUpDownCSDigimonPartySlot2Attack.Enabled = true;
                numericUpDownCSDigimonPartySlot2BonusAttack.Enabled = true;
                numericUpDownCSDigimonPartySlot2Defense.Enabled = true;
                numericUpDownCSDigimonPartySlot2BonusDefense.Enabled = true;
                numericUpDownCSDigimonPartySlot2Intelligence.Enabled = true;
                numericUpDownCSDigimonPartySlot2BonusIntelligence.Enabled = true;
                numericUpDownCSDigimonPartySlot2Speed.Enabled = true;
                numericUpDownCSDigimonPartySlot2BonusSpeed.Enabled = true;
                numericUpDownCSDigimonPartySlot2CAM.Enabled = true;
                numericUpDownCSDigimonPartySlot2ABI.Enabled = true;
                comboBoxCSDigimonPartySlot2Accessory.Enabled = true;
                comboBoxCSDigimonPartySlot2Equip1.Enabled = true;
                comboBoxCSDigimonPartySlot2Equip2.Enabled = true;
                comboBoxCSDigimonPartySlot2Equip3.Enabled = true;
            }
        }

        private void numericUpDownCSDigimonPartySlot3CurrentSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownCSDigimonPartySlot3LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageCSDigimonPartySlot3CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxCSDigimonPartySlot3CurrentSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3CurrentSkill1None.Checked)
            {
                comboBoxCSDigimonPartySlot3CurrentSkill1.Text = "(None)";
                comboBoxCSDigimonPartySlot3CurrentSkill1.Enabled = false;
                checkBoxCSDigimonPartySlot3CurrentSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3CurrentSkill1.Enabled = true;
                checkBoxCSDigimonPartySlot3CurrentSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3CurrentSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3CurrentSkill2None.Checked)
            {
                comboBoxCSDigimonPartySlot3CurrentSkill2.Text = "(None)";
                comboBoxCSDigimonPartySlot3CurrentSkill2.Enabled = false;
                checkBoxCSDigimonPartySlot3CurrentSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3CurrentSkill2.Enabled = true;
                checkBoxCSDigimonPartySlot3CurrentSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3CurrentSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3CurrentSkill3None.Checked)
            {
                comboBoxCSDigimonPartySlot3CurrentSkill3.Text = "(None)";
                comboBoxCSDigimonPartySlot3CurrentSkill3.Enabled = false;
                checkBoxCSDigimonPartySlot3CurrentSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3CurrentSkill3.Enabled = true;
                checkBoxCSDigimonPartySlot3CurrentSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3CurrentSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3CurrentSkill4None.Checked)
            {
                comboBoxCSDigimonPartySlot3CurrentSkill4.Text = "(None)";
                comboBoxCSDigimonPartySlot3CurrentSkill4.Enabled = false;
                checkBoxCSDigimonPartySlot3CurrentSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3CurrentSkill4.Enabled = true;
                checkBoxCSDigimonPartySlot3CurrentSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3CurrentSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3CurrentSkill5None.Checked)
            {
                comboBoxCSDigimonPartySlot3CurrentSkill5.Text = "(None)";
                comboBoxCSDigimonPartySlot3CurrentSkill5.Enabled = false;
                checkBoxCSDigimonPartySlot3CurrentSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3CurrentSkill5.Enabled = true;
                checkBoxCSDigimonPartySlot3CurrentSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3CurrentSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3CurrentSkill6None.Checked)
            {
                comboBoxCSDigimonPartySlot3CurrentSkill6.Text = "(None)";
                comboBoxCSDigimonPartySlot3CurrentSkill6.Enabled = false;
                checkBoxCSDigimonPartySlot3CurrentSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3CurrentSkill6.Enabled = true;
                checkBoxCSDigimonPartySlot3CurrentSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill1None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill1.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill1.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill1.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill2None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill2.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill2.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill2.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill3None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill3.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill3.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill3.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill4None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill4.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill4.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill4.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill5None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill5.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill5.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill5.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill6None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill6.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill6.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill6.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill7None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill7None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill7.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill7.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill7Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill7.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill7Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill8None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill8None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill8.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill8.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill8Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill8.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill8Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill9None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill9None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill9.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill9.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill9Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill9.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill9Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill10None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill10None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill10.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill10.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill10Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill10.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill10Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill11None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill11None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill11.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill11.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill11Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill11.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill11Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill12None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill12None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill12.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill12.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill12Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill12.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill12Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill13None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill13None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill13.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill13.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill13Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill13.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill13Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill14None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill14None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill14.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill14.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill14Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill14.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill14Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill15None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill15None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill15.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill15.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill15Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill15.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill15Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill16None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill16None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill16.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill16.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill16Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill16.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill16Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill17None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill17None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill17.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill17.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill17Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill17.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill17Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill18None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill18None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill18.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill18.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill18Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill18.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill18Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill19None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill19None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill19.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill19.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill19Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill19.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill19Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3LearnedSkill20None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3LearnedSkill20None.Checked)
            {
                comboBoxCSDigimonPartySlot3LearnedSkill20.Text = "(None)";
                comboBoxCSDigimonPartySlot3LearnedSkill20.Enabled = false;
                checkBoxCSDigimonPartySlot3LearnedSkill20Inherited.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3LearnedSkill20.Enabled = true;
                checkBoxCSDigimonPartySlot3LearnedSkill20Inherited.Enabled = true;
            }
        }

        private void checkBoxCSDigimonPartySlot3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCSDigimonPartySlot3None.Checked)
            {
                comboBoxCSDigimonPartySlot3ID.Enabled = false;
                tabControlCSDigimonPartySlot3Skills.Enabled = false;
                textBoxCSDigimonPartySlot3Nickname.Enabled = false;
                comboBoxCSDigimonPartySlot3Digivolution.Enabled = false;
                comboBoxCSDigimonPartySlot3Type.Enabled = false;
                comboBoxCSDigimonPartySlot3Attribute.Enabled = false;
                comboBoxCSDigimonPartySlot3Personality.Enabled = false;
                comboBoxCSDigmonPartySlot3SupportSkill.Enabled = false;
                numericUpDownCSDigimonPartySlot3EquipSlots.Enabled = false;
                numericUpDownCSDigimonPartySlot3Memory.Enabled = false;
                numericUpDownCSDigimonPartySlot3EXP.Enabled = false;
                numericUpDownCSDigimonPartySlot3CurrentLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot3MaxLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot3ExtraMaxLVL.Enabled = false;
                numericUpDownCSDigimonPartySlot3CurrentHP.Enabled = false;
                numericUpDownCSDigimonPartySlot3MaxHP.Enabled = false;
                numericUpDownCSDigimonPartySlot3BonusHP.Enabled = false;
                numericUpDownCSDigimonPartySlot3CurrentSP.Enabled = false;
                numericUpDownCSDigimonPartySlot3MaxSP.Enabled = false;
                numericUpDownCSDigimonPartySlot3BonusSP.Enabled = false;
                numericUpDownCSDigimonPartySlot3Attack.Enabled = false;
                numericUpDownCSDigimonPartySlot3BonusAttack.Enabled = false;
                numericUpDownCSDigimonPartySlot3Defense.Enabled = false;
                numericUpDownCSDigimonPartySlot3BonusDefense.Enabled = false;
                numericUpDownCSDigimonPartySlot3Intelligence.Enabled = false;
                numericUpDownCSDigimonPartySlot3BonusIntelligence.Enabled = false;
                numericUpDownCSDigimonPartySlot3Speed.Enabled = false;
                numericUpDownCSDigimonPartySlot3BonusSpeed.Enabled = false;
                numericUpDownCSDigimonPartySlot3CAM.Enabled = false;
                numericUpDownCSDigimonPartySlot3ABI.Enabled = false;
                comboBoxCSDigimonPartySlot3Accessory.Enabled = false;
                comboBoxCSDigimonPartySlot3Equip1.Enabled = false;
                comboBoxCSDigimonPartySlot3Equip2.Enabled = false;
                comboBoxCSDigimonPartySlot3Equip3.Enabled = false;
            }
            else
            {
                comboBoxCSDigimonPartySlot3ID.Enabled = true;
                tabControlCSDigimonPartySlot3Skills.Enabled = true;
                textBoxCSDigimonPartySlot3Nickname.Enabled = true;
                comboBoxCSDigimonPartySlot3Digivolution.Enabled = true;
                comboBoxCSDigimonPartySlot3Type.Enabled = true;
                comboBoxCSDigimonPartySlot3Attribute.Enabled = true;
                comboBoxCSDigimonPartySlot3Personality.Enabled = true;
                comboBoxCSDigmonPartySlot3SupportSkill.Enabled = true;
                numericUpDownCSDigimonPartySlot3EquipSlots.Enabled = true;
                numericUpDownCSDigimonPartySlot3Memory.Enabled = true;
                numericUpDownCSDigimonPartySlot3EXP.Enabled = true;
                numericUpDownCSDigimonPartySlot3CurrentLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot3MaxLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot3ExtraMaxLVL.Enabled = true;
                numericUpDownCSDigimonPartySlot3CurrentHP.Enabled = true;
                numericUpDownCSDigimonPartySlot3MaxHP.Enabled = true;
                numericUpDownCSDigimonPartySlot3BonusHP.Enabled = true;
                numericUpDownCSDigimonPartySlot3CurrentSP.Enabled = true;
                numericUpDownCSDigimonPartySlot3MaxSP.Enabled = true;
                numericUpDownCSDigimonPartySlot3BonusSP.Enabled = true;
                numericUpDownCSDigimonPartySlot3Attack.Enabled = true;
                numericUpDownCSDigimonPartySlot3BonusAttack.Enabled = true;
                numericUpDownCSDigimonPartySlot3Defense.Enabled = true;
                numericUpDownCSDigimonPartySlot3BonusDefense.Enabled = true;
                numericUpDownCSDigimonPartySlot3Intelligence.Enabled = true;
                numericUpDownCSDigimonPartySlot3BonusIntelligence.Enabled = true;
                numericUpDownCSDigimonPartySlot3Speed.Enabled = true;
                numericUpDownCSDigimonPartySlot3BonusSpeed.Enabled = true;
                numericUpDownCSDigimonPartySlot3CAM.Enabled = true;
                numericUpDownCSDigimonPartySlot3ABI.Enabled = true;
                comboBoxCSDigimonPartySlot3Accessory.Enabled = true;
                comboBoxCSDigimonPartySlot3Equip1.Enabled = true;
                comboBoxCSDigimonPartySlot3Equip2.Enabled = true;
                comboBoxCSDigimonPartySlot3Equip3.Enabled = true;
            }
        }

        private void tabCSDigimonPartySlot2_Click(object sender, EventArgs e)
        {

        }
		        private void checkBoxHMDigimonPartySlot1CurrentSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1CurrentSkill1None.Checked)
            {
                comboBoxHMDigimonPartySlot1CurrentSkill1.Text = "(None)";
                comboBoxHMDigimonPartySlot1CurrentSkill1.Enabled = false;
                checkBoxHMDigimonPartySlot1CurrentSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1CurrentSkill1.Enabled = true;
                checkBoxHMDigimonPartySlot1CurrentSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1CurrentSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1CurrentSkill2None.Checked)
            {
                comboBoxHMDigimonPartySlot1CurrentSkill2.Text = "(None)";
                comboBoxHMDigimonPartySlot1CurrentSkill2.Enabled = false;
                checkBoxHMDigimonPartySlot1CurrentSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1CurrentSkill2.Enabled = true;
                checkBoxHMDigimonPartySlot1CurrentSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1CurrentSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1CurrentSkill3None.Checked)
            {
                comboBoxHMDigimonPartySlot1CurrentSkill3.Text = "(None)";
                comboBoxHMDigimonPartySlot1CurrentSkill3.Enabled = false;
                checkBoxHMDigimonPartySlot1CurrentSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1CurrentSkill3.Enabled = true;
                checkBoxHMDigimonPartySlot1CurrentSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1CurrentSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1CurrentSkill4None.Checked)
            {
                comboBoxHMDigimonPartySlot1CurrentSkill4.Text = "(None)";
                comboBoxHMDigimonPartySlot1CurrentSkill4.Enabled = false;
                checkBoxHMDigimonPartySlot1CurrentSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1CurrentSkill4.Enabled = true;
                checkBoxHMDigimonPartySlot1CurrentSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1CurrentSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1CurrentSkill5None.Checked)
            {
                comboBoxHMDigimonPartySlot1CurrentSkill5.Text = "(None)";
                comboBoxHMDigimonPartySlot1CurrentSkill5.Enabled = false;
                checkBoxHMDigimonPartySlot1CurrentSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1CurrentSkill5.Enabled = true;
                checkBoxHMDigimonPartySlot1CurrentSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1CurrentSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1CurrentSkill6None.Checked)
            {
                comboBoxHMDigimonPartySlot1CurrentSkill6.Text = "(None)";
                comboBoxHMDigimonPartySlot1CurrentSkill6.Enabled = false;
                checkBoxHMDigimonPartySlot1CurrentSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1CurrentSkill6.Enabled = true;
                checkBoxHMDigimonPartySlot1CurrentSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill1None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill1.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill1.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill1.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill2None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill2.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill2.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill2.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill3None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill3.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill3.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill3.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill4None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill4.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill4.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill4.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill5None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill5.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill5.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill5.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill6None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill6.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill6.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill6.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill7None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill7None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill7.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill7.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill7Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill7.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill7Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill8None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill8None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill8.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill8.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill8Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill8.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill8Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill9None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill9None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill9.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill9.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill9Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill9.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill9Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill10None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill10None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill10.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill10.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill10Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill10.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill10Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill11None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill11None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill11.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill11.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill11Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill11.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill11Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill12None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill12None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill12.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill12.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill12Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill12.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill12Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill13None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill13None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill13.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill13.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill13Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill13.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill13Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill14None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill14None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill14.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill14.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill14Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill14.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill14Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill15None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill15None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill15.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill15.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill15Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill15.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill15Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill16None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill16None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill16.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill16.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill16Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill16.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill16Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill17None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill17None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill17.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill17.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill17Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill17.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill17Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill18None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill18None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill18.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill18.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill18Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill18.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill18Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill19None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill19None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill19.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill19.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill19Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill19.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill19Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1LearnedSkill20None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1LearnedSkill20None.Checked)
            {
                comboBoxHMDigimonPartySlot1LearnedSkill20.Text = "(None)";
                comboBoxHMDigimonPartySlot1LearnedSkill20.Enabled = false;
                checkBoxHMDigimonPartySlot1LearnedSkill20Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1LearnedSkill20.Enabled = true;
                checkBoxHMDigimonPartySlot1LearnedSkill20Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot1None.Checked)
            {
                comboBoxHMDigimonPartySlot1ID.Enabled = false;
                tabControlHMDigimonPartySlot1Skills.Enabled = false;
                textBoxHMDigimonPartySlot1Nickname.Enabled = false;
                comboBoxHMDigimonPartySlot1Digivolution.Enabled = false;
                comboBoxHMDigimonPartySlot1Type.Enabled = false;
                comboBoxHMDigimonPartySlot1Attribute.Enabled = false;
                comboBoxHMDigimonPartySlot1Personality.Enabled = false;
                comboBoxHMDigmonPartySlot1SupportSkill.Enabled = false;
                numericUpDownHMDigimonPartySlot1EquipSlots.Enabled = false;
                numericUpDownHMDigimonPartySlot1Memory.Enabled = false;
                numericUpDownHMDigimonPartySlot1EXP.Enabled = false;
                numericUpDownHMDigimonPartySlot1CurrentLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot1MaxLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot1ExtraMaxLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot1CurrentHP.Enabled = false;
                numericUpDownHMDigimonPartySlot1MaxHP.Enabled = false;
                numericUpDownHMDigimonPartySlot1BonusHP.Enabled = false;
                numericUpDownHMDigimonPartySlot1CurrentSP.Enabled = false;
                numericUpDownHMDigimonPartySlot1MaxSP.Enabled = false;
                numericUpDownHMDigimonPartySlot1BonusSP.Enabled = false;
                numericUpDownHMDigimonPartySlot1Attack.Enabled = false;
                numericUpDownHMDigimonPartySlot1BonusAttack.Enabled = false;
                numericUpDownHMDigimonPartySlot1Defense.Enabled = false;
                numericUpDownHMDigimonPartySlot1BonusDefense.Enabled = false;
                numericUpDownHMDigimonPartySlot1Intelligence.Enabled = false;
                numericUpDownHMDigimonPartySlot1BonusIntelligence.Enabled = false;
                numericUpDownHMDigimonPartySlot1Speed.Enabled = false;
                numericUpDownHMDigimonPartySlot1BonusSpeed.Enabled = false;
                numericUpDownHMDigimonPartySlot1CAM.Enabled = false;
                numericUpDownHMDigimonPartySlot1ABI.Enabled = false;
                comboBoxHMDigimonPartySlot1Accessory.Enabled = false;
                comboBoxHMDigimonPartySlot1Equip1.Enabled = false;
                comboBoxHMDigimonPartySlot1Equip2.Enabled = false;
                comboBoxHMDigimonPartySlot1Equip3.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot1ID.Enabled = true;
                tabControlHMDigimonPartySlot1Skills.Enabled = true;
                textBoxHMDigimonPartySlot1Nickname.Enabled = true;
                comboBoxHMDigimonPartySlot1Digivolution.Enabled = true;
                comboBoxHMDigimonPartySlot1Type.Enabled = true;
                comboBoxHMDigimonPartySlot1Attribute.Enabled = true;
                comboBoxHMDigimonPartySlot1Personality.Enabled = true;
                comboBoxHMDigmonPartySlot1SupportSkill.Enabled = true;
                numericUpDownHMDigimonPartySlot1EquipSlots.Enabled = true;
                numericUpDownHMDigimonPartySlot1Memory.Enabled = true;
                numericUpDownHMDigimonPartySlot1EXP.Enabled = true;
                numericUpDownHMDigimonPartySlot1CurrentLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot1MaxLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot1ExtraMaxLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot1CurrentHP.Enabled = true;
                numericUpDownHMDigimonPartySlot1MaxHP.Enabled = true;
                numericUpDownHMDigimonPartySlot1BonusHP.Enabled = true;
                numericUpDownHMDigimonPartySlot1CurrentSP.Enabled = true;
                numericUpDownHMDigimonPartySlot1MaxSP.Enabled = true;
                numericUpDownHMDigimonPartySlot1BonusSP.Enabled = true;
                numericUpDownHMDigimonPartySlot1Attack.Enabled = true;
                numericUpDownHMDigimonPartySlot1BonusAttack.Enabled = true;
                numericUpDownHMDigimonPartySlot1Defense.Enabled = true;
                numericUpDownHMDigimonPartySlot1BonusDefense.Enabled = true;
                numericUpDownHMDigimonPartySlot1Intelligence.Enabled = true;
                numericUpDownHMDigimonPartySlot1BonusIntelligence.Enabled = true;
                numericUpDownHMDigimonPartySlot1Speed.Enabled = true;
                numericUpDownHMDigimonPartySlot1BonusSpeed.Enabled = true;
                numericUpDownHMDigimonPartySlot1CAM.Enabled = true;
                numericUpDownHMDigimonPartySlot1ABI.Enabled = true;
                comboBoxHMDigimonPartySlot1Accessory.Enabled = true;
                comboBoxHMDigimonPartySlot1Equip1.Enabled = true;
                comboBoxHMDigimonPartySlot1Equip2.Enabled = true;
                comboBoxHMDigimonPartySlot1Equip3.Enabled = true;
            }
        }

        private void numericUpDownHMDigimonPartySlot2CurrentSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownHMDigimonPartySlot2LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageHMDigimonPartySlot2CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxHMDigimonPartySlot2CurrentSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2CurrentSkill1None.Checked)
            {
                comboBoxHMDigimonPartySlot2CurrentSkill1.Text = "(None)";
                comboBoxHMDigimonPartySlot2CurrentSkill1.Enabled = false;
                checkBoxHMDigimonPartySlot2CurrentSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2CurrentSkill1.Enabled = true;
                checkBoxHMDigimonPartySlot2CurrentSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2CurrentSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2CurrentSkill2None.Checked)
            {
                comboBoxHMDigimonPartySlot2CurrentSkill2.Text = "(None)";
                comboBoxHMDigimonPartySlot2CurrentSkill2.Enabled = false;
                checkBoxHMDigimonPartySlot2CurrentSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2CurrentSkill2.Enabled = true;
                checkBoxHMDigimonPartySlot2CurrentSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2CurrentSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2CurrentSkill3None.Checked)
            {
                comboBoxHMDigimonPartySlot2CurrentSkill3.Text = "(None)";
                comboBoxHMDigimonPartySlot2CurrentSkill3.Enabled = false;
                checkBoxHMDigimonPartySlot2CurrentSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2CurrentSkill3.Enabled = true;
                checkBoxHMDigimonPartySlot2CurrentSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2CurrentSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2CurrentSkill4None.Checked)
            {
                comboBoxHMDigimonPartySlot2CurrentSkill4.Text = "(None)";
                comboBoxHMDigimonPartySlot2CurrentSkill4.Enabled = false;
                checkBoxHMDigimonPartySlot2CurrentSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2CurrentSkill4.Enabled = true;
                checkBoxHMDigimonPartySlot2CurrentSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2CurrentSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2CurrentSkill5None.Checked)
            {
                comboBoxHMDigimonPartySlot2CurrentSkill5.Text = "(None)";
                comboBoxHMDigimonPartySlot2CurrentSkill5.Enabled = false;
                checkBoxHMDigimonPartySlot2CurrentSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2CurrentSkill5.Enabled = true;
                checkBoxHMDigimonPartySlot2CurrentSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2CurrentSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2CurrentSkill6None.Checked)
            {
                comboBoxHMDigimonPartySlot2CurrentSkill6.Text = "(None)";
                comboBoxHMDigimonPartySlot2CurrentSkill6.Enabled = false;
                checkBoxHMDigimonPartySlot2CurrentSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2CurrentSkill6.Enabled = true;
                checkBoxHMDigimonPartySlot2CurrentSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill1None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill1.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill1.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill1.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill2None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill2.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill2.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill2.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill3None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill3.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill3.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill3.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill4None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill4.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill4.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill4.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill5None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill5.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill5.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill5.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill6None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill6.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill6.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill6.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill7None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill7None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill7.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill7.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill7Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill7.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill7Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill8None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill8None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill8.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill8.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill8Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill8.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill8Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill9None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill9None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill9.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill9.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill9Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill9.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill9Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill10None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill10None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill10.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill10.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill10Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill10.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill10Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill11None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill11None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill11.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill11.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill11Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill11.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill11Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill12None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill12None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill12.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill12.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill12Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill12.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill12Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill13None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill13None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill13.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill13.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill13Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill13.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill13Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill14None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill14None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill14.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill14.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill14Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill14.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill14Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill15None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill15None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill15.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill15.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill15Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill15.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill15Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill16None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill16None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill16.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill16.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill16Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill16.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill16Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill17None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill17None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill17.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill17.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill17Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill17.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill17Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill18None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill18None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill18.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill18.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill18Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill18.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill18Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill19None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill19None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill19.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill19.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill19Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill19.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill19Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2LearnedSkill20None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2LearnedSkill20None.Checked)
            {
                comboBoxHMDigimonPartySlot2LearnedSkill20.Text = "(None)";
                comboBoxHMDigimonPartySlot2LearnedSkill20.Enabled = false;
                checkBoxHMDigimonPartySlot2LearnedSkill20Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2LearnedSkill20.Enabled = true;
                checkBoxHMDigimonPartySlot2LearnedSkill20Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot2None.Checked)
            {
                comboBoxHMDigimonPartySlot2ID.Enabled = false;
                tabControlHMDigimonPartySlot2Skills.Enabled = false;
                textBoxHMDigimonPartySlot2Nickname.Enabled = false;
                comboBoxHMDigimonPartySlot2Digivolution.Enabled = false;
                comboBoxHMDigimonPartySlot2Type.Enabled = false;
                comboBoxHMDigimonPartySlot2Attribute.Enabled = false;
                comboBoxHMDigimonPartySlot2Personality.Enabled = false;
                comboBoxHMDigmonPartySlot2SupportSkill.Enabled = false;
                numericUpDownHMDigimonPartySlot2EquipSlots.Enabled = false;
                numericUpDownHMDigimonPartySlot2Memory.Enabled = false;
                numericUpDownHMDigimonPartySlot2EXP.Enabled = false;
                numericUpDownHMDigimonPartySlot2CurrentLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot2MaxLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot2ExtraMaxLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot2CurrentHP.Enabled = false;
                numericUpDownHMDigimonPartySlot2MaxHP.Enabled = false;
                numericUpDownHMDigimonPartySlot2BonusHP.Enabled = false;
                numericUpDownHMDigimonPartySlot2CurrentSP.Enabled = false;
                numericUpDownHMDigimonPartySlot2MaxSP.Enabled = false;
                numericUpDownHMDigimonPartySlot2BonusSP.Enabled = false;
                numericUpDownHMDigimonPartySlot2Attack.Enabled = false;
                numericUpDownHMDigimonPartySlot2BonusAttack.Enabled = false;
                numericUpDownHMDigimonPartySlot2Defense.Enabled = false;
                numericUpDownHMDigimonPartySlot2BonusDefense.Enabled = false;
                numericUpDownHMDigimonPartySlot2Intelligence.Enabled = false;
                numericUpDownHMDigimonPartySlot2BonusIntelligence.Enabled = false;
                numericUpDownHMDigimonPartySlot2Speed.Enabled = false;
                numericUpDownHMDigimonPartySlot2BonusSpeed.Enabled = false;
                numericUpDownHMDigimonPartySlot2CAM.Enabled = false;
                numericUpDownHMDigimonPartySlot2ABI.Enabled = false;
                comboBoxHMDigimonPartySlot2Accessory.Enabled = false;
                comboBoxHMDigimonPartySlot2Equip1.Enabled = false;
                comboBoxHMDigimonPartySlot2Equip2.Enabled = false;
                comboBoxHMDigimonPartySlot2Equip3.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot2ID.Enabled = true;
                tabControlHMDigimonPartySlot2Skills.Enabled = true;
                textBoxHMDigimonPartySlot2Nickname.Enabled = true;
                comboBoxHMDigimonPartySlot2Digivolution.Enabled = true;
                comboBoxHMDigimonPartySlot2Type.Enabled = true;
                comboBoxHMDigimonPartySlot2Attribute.Enabled = true;
                comboBoxHMDigimonPartySlot2Personality.Enabled = true;
                comboBoxHMDigmonPartySlot2SupportSkill.Enabled = true;
                numericUpDownHMDigimonPartySlot2EquipSlots.Enabled = true;
                numericUpDownHMDigimonPartySlot2Memory.Enabled = true;
                numericUpDownHMDigimonPartySlot2EXP.Enabled = true;
                numericUpDownHMDigimonPartySlot2CurrentLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot2MaxLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot2ExtraMaxLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot2CurrentHP.Enabled = true;
                numericUpDownHMDigimonPartySlot2MaxHP.Enabled = true;
                numericUpDownHMDigimonPartySlot2BonusHP.Enabled = true;
                numericUpDownHMDigimonPartySlot2CurrentSP.Enabled = true;
                numericUpDownHMDigimonPartySlot2MaxSP.Enabled = true;
                numericUpDownHMDigimonPartySlot2BonusSP.Enabled = true;
                numericUpDownHMDigimonPartySlot2Attack.Enabled = true;
                numericUpDownHMDigimonPartySlot2BonusAttack.Enabled = true;
                numericUpDownHMDigimonPartySlot2Defense.Enabled = true;
                numericUpDownHMDigimonPartySlot2BonusDefense.Enabled = true;
                numericUpDownHMDigimonPartySlot2Intelligence.Enabled = true;
                numericUpDownHMDigimonPartySlot2BonusIntelligence.Enabled = true;
                numericUpDownHMDigimonPartySlot2Speed.Enabled = true;
                numericUpDownHMDigimonPartySlot2BonusSpeed.Enabled = true;
                numericUpDownHMDigimonPartySlot2CAM.Enabled = true;
                numericUpDownHMDigimonPartySlot2ABI.Enabled = true;
                comboBoxHMDigimonPartySlot2Accessory.Enabled = true;
                comboBoxHMDigimonPartySlot2Equip1.Enabled = true;
                comboBoxHMDigimonPartySlot2Equip2.Enabled = true;
                comboBoxHMDigimonPartySlot2Equip3.Enabled = true;
            }
        }

        private void numericUpDownHMDigimonPartySlot3CurrentSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownHMDigimonPartySlot3LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageHMDigimonPartySlot3CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxHMDigimonPartySlot3CurrentSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3CurrentSkill1None.Checked)
            {
                comboBoxHMDigimonPartySlot3CurrentSkill1.Text = "(None)";
                comboBoxHMDigimonPartySlot3CurrentSkill1.Enabled = false;
                checkBoxHMDigimonPartySlot3CurrentSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3CurrentSkill1.Enabled = true;
                checkBoxHMDigimonPartySlot3CurrentSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3CurrentSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3CurrentSkill2None.Checked)
            {
                comboBoxHMDigimonPartySlot3CurrentSkill2.Text = "(None)";
                comboBoxHMDigimonPartySlot3CurrentSkill2.Enabled = false;
                checkBoxHMDigimonPartySlot3CurrentSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3CurrentSkill2.Enabled = true;
                checkBoxHMDigimonPartySlot3CurrentSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3CurrentSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3CurrentSkill3None.Checked)
            {
                comboBoxHMDigimonPartySlot3CurrentSkill3.Text = "(None)";
                comboBoxHMDigimonPartySlot3CurrentSkill3.Enabled = false;
                checkBoxHMDigimonPartySlot3CurrentSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3CurrentSkill3.Enabled = true;
                checkBoxHMDigimonPartySlot3CurrentSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3CurrentSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3CurrentSkill4None.Checked)
            {
                comboBoxHMDigimonPartySlot3CurrentSkill4.Text = "(None)";
                comboBoxHMDigimonPartySlot3CurrentSkill4.Enabled = false;
                checkBoxHMDigimonPartySlot3CurrentSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3CurrentSkill4.Enabled = true;
                checkBoxHMDigimonPartySlot3CurrentSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3CurrentSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3CurrentSkill5None.Checked)
            {
                comboBoxHMDigimonPartySlot3CurrentSkill5.Text = "(None)";
                comboBoxHMDigimonPartySlot3CurrentSkill5.Enabled = false;
                checkBoxHMDigimonPartySlot3CurrentSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3CurrentSkill5.Enabled = true;
                checkBoxHMDigimonPartySlot3CurrentSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3CurrentSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3CurrentSkill6None.Checked)
            {
                comboBoxHMDigimonPartySlot3CurrentSkill6.Text = "(None)";
                comboBoxHMDigimonPartySlot3CurrentSkill6.Enabled = false;
                checkBoxHMDigimonPartySlot3CurrentSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3CurrentSkill6.Enabled = true;
                checkBoxHMDigimonPartySlot3CurrentSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill1None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill1None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill1.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill1.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill1Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill1.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill1Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill2None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill2None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill2.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill2.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill2Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill2.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill2Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill3None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill3.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill3.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill3Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill3.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill3Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill4None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill4None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill4.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill4.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill4Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill4.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill4Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill5None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill5None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill5.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill5.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill5Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill5.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill5Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill6None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill6None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill6.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill6.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill6Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill6.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill6Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill7None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill7None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill7.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill7.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill7Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill7.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill7Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill8None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill8None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill8.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill8.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill8Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill8.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill8Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill9None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill9None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill9.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill9.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill9Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill9.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill9Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill10None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill10None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill10.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill10.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill10Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill10.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill10Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill11None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill11None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill11.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill11.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill11Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill11.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill11Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill12None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill12None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill12.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill12.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill12Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill12.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill12Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill13None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill13None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill13.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill13.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill13Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill13.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill13Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill14None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill14None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill14.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill14.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill14Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill14.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill14Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill15None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill15None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill15.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill15.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill15Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill15.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill15Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill16None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill16None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill16.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill16.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill16Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill16.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill16Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill17None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill17None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill17.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill17.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill17Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill17.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill17Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill18None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill18None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill18.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill18.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill18Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill18.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill18Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill19None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill19None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill19.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill19.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill19Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill19.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill19Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3LearnedSkill20None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3LearnedSkill20None.Checked)
            {
                comboBoxHMDigimonPartySlot3LearnedSkill20.Text = "(None)";
                comboBoxHMDigimonPartySlot3LearnedSkill20.Enabled = false;
                checkBoxHMDigimonPartySlot3LearnedSkill20Inherited.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3LearnedSkill20.Enabled = true;
                checkBoxHMDigimonPartySlot3LearnedSkill20Inherited.Enabled = true;
            }
        }

        private void checkBoxHMDigimonPartySlot3None_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHMDigimonPartySlot3None.Checked)
            {
                comboBoxHMDigimonPartySlot3ID.Enabled = false;
                tabControlHMDigimonPartySlot3Skills.Enabled = false;
                textBoxHMDigimonPartySlot3Nickname.Enabled = false;
                comboBoxHMDigimonPartySlot3Digivolution.Enabled = false;
                comboBoxHMDigimonPartySlot3Type.Enabled = false;
                comboBoxHMDigimonPartySlot3Attribute.Enabled = false;
                comboBoxHMDigimonPartySlot3Personality.Enabled = false;
                comboBoxHMDigmonPartySlot3SupportSkill.Enabled = false;
                numericUpDownHMDigimonPartySlot3EquipSlots.Enabled = false;
                numericUpDownHMDigimonPartySlot3Memory.Enabled = false;
                numericUpDownHMDigimonPartySlot3EXP.Enabled = false;
                numericUpDownHMDigimonPartySlot3CurrentLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot3MaxLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot3ExtraMaxLVL.Enabled = false;
                numericUpDownHMDigimonPartySlot3CurrentHP.Enabled = false;
                numericUpDownHMDigimonPartySlot3MaxHP.Enabled = false;
                numericUpDownHMDigimonPartySlot3BonusHP.Enabled = false;
                numericUpDownHMDigimonPartySlot3CurrentSP.Enabled = false;
                numericUpDownHMDigimonPartySlot3MaxSP.Enabled = false;
                numericUpDownHMDigimonPartySlot3BonusSP.Enabled = false;
                numericUpDownHMDigimonPartySlot3Attack.Enabled = false;
                numericUpDownHMDigimonPartySlot3BonusAttack.Enabled = false;
                numericUpDownHMDigimonPartySlot3Defense.Enabled = false;
                numericUpDownHMDigimonPartySlot3BonusDefense.Enabled = false;
                numericUpDownHMDigimonPartySlot3Intelligence.Enabled = false;
                numericUpDownHMDigimonPartySlot3BonusIntelligence.Enabled = false;
                numericUpDownHMDigimonPartySlot3Speed.Enabled = false;
                numericUpDownHMDigimonPartySlot3BonusSpeed.Enabled = false;
                numericUpDownHMDigimonPartySlot3CAM.Enabled = false;
                numericUpDownHMDigimonPartySlot3ABI.Enabled = false;
                comboBoxHMDigimonPartySlot3Accessory.Enabled = false;
                comboBoxHMDigimonPartySlot3Equip1.Enabled = false;
                comboBoxHMDigimonPartySlot3Equip2.Enabled = false;
                comboBoxHMDigimonPartySlot3Equip3.Enabled = false;
            }
            else
            {
                comboBoxHMDigimonPartySlot3ID.Enabled = true;
                tabControlHMDigimonPartySlot3Skills.Enabled = true;
                textBoxHMDigimonPartySlot3Nickname.Enabled = true;
                comboBoxHMDigimonPartySlot3Digivolution.Enabled = true;
                comboBoxHMDigimonPartySlot3Type.Enabled = true;
                comboBoxHMDigimonPartySlot3Attribute.Enabled = true;
                comboBoxHMDigimonPartySlot3Personality.Enabled = true;
                comboBoxHMDigmonPartySlot3SupportSkill.Enabled = true;
                numericUpDownHMDigimonPartySlot3EquipSlots.Enabled = true;
                numericUpDownHMDigimonPartySlot3Memory.Enabled = true;
                numericUpDownHMDigimonPartySlot3EXP.Enabled = true;
                numericUpDownHMDigimonPartySlot3CurrentLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot3MaxLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot3ExtraMaxLVL.Enabled = true;
                numericUpDownHMDigimonPartySlot3CurrentHP.Enabled = true;
                numericUpDownHMDigimonPartySlot3MaxHP.Enabled = true;
                numericUpDownHMDigimonPartySlot3BonusHP.Enabled = true;
                numericUpDownHMDigimonPartySlot3CurrentSP.Enabled = true;
                numericUpDownHMDigimonPartySlot3MaxSP.Enabled = true;
                numericUpDownHMDigimonPartySlot3BonusSP.Enabled = true;
                numericUpDownHMDigimonPartySlot3Attack.Enabled = true;
                numericUpDownHMDigimonPartySlot3BonusAttack.Enabled = true;
                numericUpDownHMDigimonPartySlot3Defense.Enabled = true;
                numericUpDownHMDigimonPartySlot3BonusDefense.Enabled = true;
                numericUpDownHMDigimonPartySlot3Intelligence.Enabled = true;
                numericUpDownHMDigimonPartySlot3BonusIntelligence.Enabled = true;
                numericUpDownHMDigimonPartySlot3Speed.Enabled = true;
                numericUpDownHMDigimonPartySlot3BonusSpeed.Enabled = true;
                numericUpDownHMDigimonPartySlot3CAM.Enabled = true;
                numericUpDownHMDigimonPartySlot3ABI.Enabled = true;
                comboBoxHMDigimonPartySlot3Accessory.Enabled = true;
                comboBoxHMDigimonPartySlot3Equip1.Enabled = true;
                comboBoxHMDigimonPartySlot3Equip2.Enabled = true;
                comboBoxHMDigimonPartySlot3Equip3.Enabled = true;
            }
        }

        private void tabHMDigimonPartySlot2_Click(object sender, EventArgs e)
        {

        }
    }
}
