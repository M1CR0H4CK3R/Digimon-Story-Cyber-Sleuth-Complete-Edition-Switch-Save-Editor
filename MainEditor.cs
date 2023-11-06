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
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "Bin Files (*.bin)|*.bin";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                savegame = openFD.FileName;
            }
        }

        private void getData()
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
                byte[] digimonPartySlot1ID = savegameBr.ReadBytes(2);

                //Not sure if this is needed
                //if (BitConverter.IsLittleEndian != true)
                //{                            
                //    Array.Reverse(digimonSlot1ID);
                //}

                short digimonPartySlot1IDDec = BitConverter.ToInt16(digimonPartySlot1ID, 0);
                comboBoxCSDigimonPartySlot1ID.Text = convertDigimonIDtoString(digimonPartySlot1IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CABC;
                byte[] digimonPartySlot1Nickname = savegameBr.ReadBytes(17);
                string digimonPartySlot1NicknameDec = Encoding.ASCII.GetString(digimonPartySlot1Nickname);
                textBoxCSDigimonPartySlot1Nickname.Text = digimonPartySlot1NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CAB8;
                byte digimonPartySlot1Digivolution = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Digivolution.Text = convertDigivolutionIDtoString(digimonPartySlot1Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CAB4;
                byte digimonPartySlot1Type = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Type.Text = convertTypeIDtoString(digimonPartySlot1Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CAB0;
                byte digimonPartySlot1Attribute = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Attribute.Text = convertAttributeIDtoString(digimonPartySlot1Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CB20;
                byte digimonPartySlot1Personality = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot1Personality.Text = convertPersonalityIDtoString(digimonPartySlot1Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3CCC0;
                byte digimonPartySlot1SupportSkill = savegameBr.ReadByte();
                comboBoxCSDigmonPartySlot1SupportSkill.Text = convertsupportSkillsIDtoString(digimonPartySlot1SupportSkill);
                #endregion

                #region Stats1
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3CCC4;
                byte digimonPartySlot1EquipSlots = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1EquipSlots.Value = digimonPartySlot1EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CB04;
                byte digimonPartySlot1Memory = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1Memory.Value = digimonPartySlot1Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CB18;
                byte[] digimonPartySlot1EXP = savegameBr.ReadBytes(4);
                int digimonPartySlot1EXPDec = BitConverter.ToInt32(digimonPartySlot1EXP, 0);
                numericUpDownCSDigimonPartySlot1EXP.Value = digimonPartySlot1EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CB10;
                byte digimonPartySlot1CurrentLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1CurrentLVL.Value = digimonPartySlot1CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CB12;
                byte digimonPartySlot1MaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1MaxLVL.Value = digimonPartySlot1MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CB14;
                byte digimonPartySlot1ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot1ExtraMaxLVL.Value = digimonPartySlot1ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CB24;
                byte[] digimonPartySlot1CurrentHP = savegameBr.ReadBytes(2);
                short digimonPartySlot1CurrentHPDec = BitConverter.ToInt16(digimonPartySlot1CurrentHP, 0);
                numericUpDownCSDigimonPartySlot1CurrentHP.Value = digimonPartySlot1CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CB28;
                byte[] digimonPartySlot1MaxHP = savegameBr.ReadBytes(2);
                short digimonPartySlot1MaxHPDec = BitConverter.ToInt16(digimonPartySlot1MaxHP, 0);
                numericUpDownCSDigimonPartySlot1MaxHP.Value = digimonPartySlot1MaxHPDec * 10;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CB2C;
                byte[] digimonPartySlot1BonusHP = savegameBr.ReadBytes(2);
                short digimonPartySlot1BonusHPDec = BitConverter.ToInt16(digimonPartySlot1BonusHP, 0);
                numericUpDownCSDigimonPartySlot1BonusHP.Value = digimonPartySlot1BonusHPDec;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CB30;
                byte[] digimonPartySlot1CurrentSP = savegameBr.ReadBytes(2);
                short digimonPartySlot1CurrentSPDec = BitConverter.ToInt16(digimonPartySlot1CurrentSP, 0);
                numericUpDownCSDigimonPartySlot1CurrentSP.Value = digimonPartySlot1CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CB34;
                byte[] digimonPartySlot1MaxSP = savegameBr.ReadBytes(2);
                short digimonPartySlot1MaxSPDec = BitConverter.ToInt16(digimonPartySlot1MaxSP, 0);
                numericUpDownCSDigimonPartySlot1MaxSP.Value = digimonPartySlot1MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CB38;
                byte[] digimonPartySlot1BonusSP = savegameBr.ReadBytes(2);
                short digimonPartySlot1BonusSPDec = BitConverter.ToInt16(digimonPartySlot1BonusSP, 0);
                numericUpDownCSDigimonPartySlot1BonusSP.Value = digimonPartySlot1BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CB3A;
                byte[] digimonPartySlot1Attack = savegameBr.ReadBytes(2);
                short digimonPartySlot1AttackDec = BitConverter.ToInt16(digimonPartySlot1Attack, 0);
                numericUpDownCSDigimonPartySlot1Attack.Value = digimonPartySlot1AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CB3C;
                byte[] digimonPartySlot1BonusAttack = savegameBr.ReadBytes(2);
                short digimonPartySlot1BonusAttackDec = BitConverter.ToInt16(digimonPartySlot1BonusAttack, 0);
                numericUpDownCSDigimonPartySlot1BonusAttack.Value = digimonPartySlot1BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CB3E;
                byte[] digimonPartySlot1Defense = savegameBr.ReadBytes(2);
                short digimonPartySlot1DefenseDec = BitConverter.ToInt16(digimonPartySlot1Defense, 0);
                numericUpDownCSDigimonPartySlot1Defense.Value = digimonPartySlot1DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CB40;
                byte[] digimonPartySlot1BonusDefense = savegameBr.ReadBytes(2);
                short digimonPartySlot1BonusDefenseDec = BitConverter.ToInt16(digimonPartySlot1BonusDefense, 0);
                numericUpDownCSDigimonPartySlot1BonusDefense.Value = digimonPartySlot1BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CB42;
                byte[] digimonPartySlot1Intelligence = savegameBr.ReadBytes(2);
                short digimonPartySlot1IntelligenceDec = BitConverter.ToInt16(digimonPartySlot1Intelligence, 0);
                numericUpDownCSDigimonPartySlot1Intelligence.Value = digimonPartySlot1IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CB44;
                byte[] digimonPartySlot1BonusIntelligence = savegameBr.ReadBytes(2);
                short digimonPartySlot1BonusIntelligenceDec = BitConverter.ToInt16(digimonPartySlot1BonusIntelligence, 0);
                numericUpDownCSDigimonPartySlot1BonusIntelligence.Value = digimonPartySlot1BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CB46;
                byte[] digimonPartySlot1Speed = savegameBr.ReadBytes(2);
                short digimonPartySlot1SpeedDec = BitConverter.ToInt16(digimonPartySlot1Speed, 0);
                numericUpDownCSDigimonPartySlot1Speed.Value = digimonPartySlot1SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CB48;
                byte[] digimonPartySlot1BonusSpeed = savegameBr.ReadBytes(2);
                short digimonPartySlot1BonusSpeedDec = BitConverter.ToInt16(digimonPartySlot1BonusSpeed, 0);
                numericUpDownCSDigimonPartySlot1BonusSpeed.Value = digimonPartySlot1BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CB4C;
                byte[] digimonPartySlot1CAM = savegameBr.ReadBytes(2);
                short digimonPartySlot1CAMDec = BitConverter.ToInt16(digimonPartySlot1CAM, 0);
                numericUpDownCSDigimonPartySlot1CAM.Value = (digimonPartySlot1CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CB4A;
                byte[] digimonPartySlot1ABI = savegameBr.ReadBytes(2);
                short digimonPartySlot1ABIDec = BitConverter.ToInt16(digimonPartySlot1ABI, 0);
                numericUpDownCSDigimonPartySlot1ABI.Value = digimonPartySlot1ABIDec;
                #endregion

                #region Equipment1
                //Equip 1
                savegameBr.BaseStream.Position = 0x3CCC6;
                byte[] digimonPartySlot1Equip1 = savegameBr.ReadBytes(2);
                short digimonPartySlot1Equip1Dec = BitConverter.ToInt16(digimonPartySlot1Equip1, 0);
                comboBoxCSDigimonPartySlot1Equip1.Text = convertEquipIDtoString(digimonPartySlot1Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3CCC8;
                byte[] digimonPartySlot1Equip2 = savegameBr.ReadBytes(2);
                short digimonPartySlot1Equip2Dec = BitConverter.ToInt16(digimonPartySlot1Equip2, 0);
                comboBoxCSDigimonPartySlot1Equip2.Text = convertEquipIDtoString(digimonPartySlot1Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3CCCA;
                byte[] digimonPartySlot1Equip3 = savegameBr.ReadBytes(2);
                short digimonPartySlot1Equip3Dec = BitConverter.ToInt16(digimonPartySlot1Equip3, 0);
                comboBoxCSDigimonPartySlot1Equip3.Text = convertEquipIDtoString(digimonPartySlot1Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3CCCC;
                byte[] digimonPartySlot1Accessory = savegameBr.ReadBytes(2);
                short digimonPartySlot1AccessoryDec = BitConverter.ToInt16(digimonPartySlot1Accessory, 0);
                comboBoxCSDigimonPartySlot1Accessory.Text = convertAccessoryIDtoString(digimonPartySlot1AccessoryDec);
                #endregion

                #region CurrentSkills1
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CB50;
                byte digimonPartySlot1CurrentSkill1Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1CurrentSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill1Inherited.Checked = Convert.ToBoolean(digimonPartySlot1CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CB54;
                    comboBoxCSDigimonPartySlot1CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CB58;
                byte digimonPartySlot1CurrentSkill2Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1CurrentSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill2Inherited.Checked = Convert.ToBoolean(digimonPartySlot1CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CB5C;
                    comboBoxCSDigimonPartySlot1CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CB60;
                byte digimonPartySlot1CurrentSkill3Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1CurrentSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill3Inherited.Checked = Convert.ToBoolean(digimonPartySlot1CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CB64;
                    comboBoxCSDigimonPartySlot1CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CB68;
                byte digimonPartySlot1CurrentSkill4Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1CurrentSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill4Inherited.Checked = Convert.ToBoolean(digimonPartySlot1CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CB6C;
                    comboBoxCSDigimonPartySlot1CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CB70;
                byte digimonPartySlot1CurrentSkill5Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1CurrentSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill5Inherited.Checked = Convert.ToBoolean(digimonPartySlot1CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CB74;
                    comboBoxCSDigimonPartySlot1CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CB78;
                byte digimonPartySlot1CurrentSkill6Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1CurrentSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1CurrentSkill6Inherited.Checked = Convert.ToBoolean(digimonPartySlot1CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CB7C;
                    comboBoxCSDigimonPartySlot1CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills1
                //Learned Skill 1
                savegameBr.BaseStream.Position = 0x3CB80;
                byte digimonPartySlot1LearnedSkill1Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill1Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CB84;
                    comboBoxCSDigimonPartySlot1LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3CB88;
                byte digimonPartySlot1LearnedSkill2Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill2Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CB8C;
                    comboBoxCSDigimonPartySlot1LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3CB90;
                byte digimonPartySlot1LearnedSkill3Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill3Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CB94;
                    comboBoxCSDigimonPartySlot1LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3CB98;
                byte digimonPartySlot1LearnedSkill4Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill4Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CB9C;
                    comboBoxCSDigimonPartySlot1LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3CBA0;
                byte digimonPartySlot1LearnedSkill5Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill5Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CBA4;
                    comboBoxCSDigimonPartySlot1LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3CBA8;
                byte digimonPartySlot1LearnedSkill6Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill6Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CBAC;
                    comboBoxCSDigimonPartySlot1LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3CBB0;
                byte digimonPartySlot1LearnedSkill7Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill7Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill7Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3CBB4;
                    comboBoxCSDigimonPartySlot1LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3CBB8;
                byte digimonPartySlot1LearnedSkill8Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill8Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill8Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3CBBC;
                    comboBoxCSDigimonPartySlot1LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3CBC0;
                byte digimonPartySlot1LearnedSkill9Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill9Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill9Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3CBC4;
                    comboBoxCSDigimonPartySlot1LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3CBC8;
                byte digimonPartySlot1LearnedSkill10Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill10Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill10Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3CBCC;
                    comboBoxCSDigimonPartySlot1LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3CBD0;
                byte digimonPartySlot1LearnedSkill11Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill11Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill11Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3CBD4;
                    comboBoxCSDigimonPartySlot1LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3CBD8;
                byte digimonPartySlot1LearnedSkill12Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill12Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill12Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3CBDC;
                    comboBoxCSDigimonPartySlot1LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3CBE0;
                byte digimonPartySlot1LearnedSkill13Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill13Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill13Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3CBE4;
                    comboBoxCSDigimonPartySlot1LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3CBE8;
                byte digimonPartySlot1LearnedSkill14Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill14Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill14Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3CBEC;
                    comboBoxCSDigimonPartySlot1LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3CBF0;
                byte digimonPartySlot1LearnedSkill15Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill15Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill15Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3CBF4;
                    comboBoxCSDigimonPartySlot1LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3CBF8;
                byte digimonPartySlot1LearnedSkill16Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill16Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill16Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3CBFC;
                    comboBoxCSDigimonPartySlot1LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3CC00;
                byte digimonPartySlot1LearnedSkill17Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill17Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill17Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3CC04;
                    comboBoxCSDigimonPartySlot1LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3CC08;
                byte digimonPartySlot1LearnedSkill18Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill18Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill18Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3CC0C;
                    comboBoxCSDigimonPartySlot1LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3CC10;
                byte digimonPartySlot1LearnedSkill19Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill19Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill19Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3CC14;
                    comboBoxCSDigimonPartySlot1LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3CC18;
                byte digimonPartySlot1LearnedSkill20Inherited = savegameBr.ReadByte();
                if (digimonPartySlot1LearnedSkill20Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot1LearnedSkill20Inherited.Checked = Convert.ToBoolean(digimonPartySlot1LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3CC1C;
                    comboBoxCSDigimonPartySlot1LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraits(1);
            }

            else
            {
                checkBoxCSDigimonPartySlot1None.Checked = true;
            }
            #endregion
            #endregion

            #region DigimonPartySlot2
            #region Main2
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CCDC;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3CCEC;
                byte[] digimonPartySlot2ID = savegameBr.ReadBytes(2);

                //Not sure if this is needed
                //if (BitConverter.IsLittleEndian != true)
                //{                            
                //    Array.Reverse(digimonSlot2ID);
                //}

                short digimonPartySlot2IDDec = BitConverter.ToInt16(digimonPartySlot2ID, 0);
                comboBoxCSDigimonPartySlot2ID.Text = convertDigimonIDtoString(digimonPartySlot2IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3CCFC;
                byte[] digimonPartySlot2Nickname = savegameBr.ReadBytes(17);
                string digimonPartySlot2NicknameDec = Encoding.ASCII.GetString(digimonPartySlot2Nickname);
                textBoxCSDigimonPartySlot2Nickname.Text = digimonPartySlot2NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3CCF8;
                byte digimonPartySlot2Digivolution = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Digivolution.Text = convertDigivolutionIDtoString(digimonPartySlot2Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3CCF4;
                byte digimonPartySlot2Type = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Type.Text = convertTypeIDtoString(digimonPartySlot2Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3CCF0;
                byte digimonPartySlot2Attribute = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Attribute.Text = convertAttributeIDtoString(digimonPartySlot2Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3CD60;
                byte digimonPartySlot2Personality = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot2Personality.Text = convertPersonalityIDtoString(digimonPartySlot2Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3CF00;
                byte digimonPartySlot2SupportSkill = savegameBr.ReadByte();
                comboBoxCSDigmonPartySlot2SupportSkill.Text = convertsupportSkillsIDtoString(digimonPartySlot2SupportSkill);
                #endregion

                #region Stats2
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3CF04;
                byte digimonPartySlot2EquipSlots = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2EquipSlots.Value = digimonPartySlot2EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3CD44;
                byte digimonPartySlot2Memory = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2Memory.Value = digimonPartySlot2Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3CD58;
                byte[] digimonPartySlot2EXP = savegameBr.ReadBytes(4);
                int digimonPartySlot2EXPDec = BitConverter.ToInt32(digimonPartySlot2EXP, 0);
                numericUpDownCSDigimonPartySlot2EXP.Value = digimonPartySlot2EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3CD50;
                byte digimonPartySlot2CurrentLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2CurrentLVL.Value = digimonPartySlot2CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3CD52;
                byte digimonPartySlot2MaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2MaxLVL.Value = digimonPartySlot2MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3CD54;
                byte digimonPartySlot2ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot2ExtraMaxLVL.Value = digimonPartySlot2ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3CD64;
                byte[] digimonPartySlot2CurrentHP = savegameBr.ReadBytes(2);
                short digimonPartySlot2CurrentHPDec = BitConverter.ToInt16(digimonPartySlot2CurrentHP, 0);
                numericUpDownCSDigimonPartySlot2CurrentHP.Value = digimonPartySlot2CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3CD68;
                byte[] digimonPartySlot2MaxHP = savegameBr.ReadBytes(2);
                short digimonPartySlot2MaxHPDec = BitConverter.ToInt16(digimonPartySlot2MaxHP, 0);
                numericUpDownCSDigimonPartySlot2MaxHP.Value = digimonPartySlot2MaxHPDec * 10;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3CD6C;
                byte[] digimonPartySlot2BonusHP = savegameBr.ReadBytes(2);
                short digimonPartySlot2BonusHPDec = BitConverter.ToInt16(digimonPartySlot2BonusHP, 0);
                numericUpDownCSDigimonPartySlot2BonusHP.Value = digimonPartySlot2BonusHPDec;

                //Current SP
                savegameBr.BaseStream.Position = 0x3CD70;
                byte[] digimonPartySlot2CurrentSP = savegameBr.ReadBytes(2);
                short digimonPartySlot2CurrentSPDec = BitConverter.ToInt16(digimonPartySlot2CurrentSP, 0);
                numericUpDownCSDigimonPartySlot2CurrentSP.Value = digimonPartySlot2CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3CD74;
                byte[] digimonPartySlot2MaxSP = savegameBr.ReadBytes(2);
                short digimonPartySlot2MaxSPDec = BitConverter.ToInt16(digimonPartySlot2MaxSP, 0);
                numericUpDownCSDigimonPartySlot2MaxSP.Value = digimonPartySlot2MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3CD78;
                byte[] digimonPartySlot2BonusSP = savegameBr.ReadBytes(2);
                short digimonPartySlot2BonusSPDec = BitConverter.ToInt16(digimonPartySlot2BonusSP, 0);
                numericUpDownCSDigimonPartySlot2BonusSP.Value = digimonPartySlot2BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3CD7A;
                byte[] digimonPartySlot2Attack = savegameBr.ReadBytes(2);
                short digimonPartySlot2AttackDec = BitConverter.ToInt16(digimonPartySlot2Attack, 0);
                numericUpDownCSDigimonPartySlot2Attack.Value = digimonPartySlot2AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3CD7C;
                byte[] digimonPartySlot2BonusAttack = savegameBr.ReadBytes(2);
                short digimonPartySlot2BonusAttackDec = BitConverter.ToInt16(digimonPartySlot2BonusAttack, 0);
                numericUpDownCSDigimonPartySlot2BonusAttack.Value = digimonPartySlot2BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3CD7E;
                byte[] digimonPartySlot2Defense = savegameBr.ReadBytes(2);
                short digimonPartySlot2DefenseDec = BitConverter.ToInt16(digimonPartySlot2Defense, 0);
                numericUpDownCSDigimonPartySlot2Defense.Value = digimonPartySlot2DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3CD80;
                byte[] digimonPartySlot2BonusDefense = savegameBr.ReadBytes(2);
                short digimonPartySlot2BonusDefenseDec = BitConverter.ToInt16(digimonPartySlot2BonusDefense, 0);
                numericUpDownCSDigimonPartySlot2BonusDefense.Value = digimonPartySlot2BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3CD82;
                byte[] digimonPartySlot2Intelligence = savegameBr.ReadBytes(2);
                short digimonPartySlot2IntelligenceDec = BitConverter.ToInt16(digimonPartySlot2Intelligence, 0);
                numericUpDownCSDigimonPartySlot2Intelligence.Value = digimonPartySlot2IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3CD84;
                byte[] digimonPartySlot2BonusIntelligence = savegameBr.ReadBytes(2);
                short digimonPartySlot2BonusIntelligenceDec = BitConverter.ToInt16(digimonPartySlot2BonusIntelligence, 0);
                numericUpDownCSDigimonPartySlot2BonusIntelligence.Value = digimonPartySlot2BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3CD86;
                byte[] digimonPartySlot2Speed = savegameBr.ReadBytes(2);
                short digimonPartySlot2SpeedDec = BitConverter.ToInt16(digimonPartySlot2Speed, 0);
                numericUpDownCSDigimonPartySlot2Speed.Value = digimonPartySlot2SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3CD88;
                byte[] digimonPartySlot2BonusSpeed = savegameBr.ReadBytes(2);
                short digimonPartySlot2BonusSpeedDec = BitConverter.ToInt16(digimonPartySlot2BonusSpeed, 0);
                numericUpDownCSDigimonPartySlot2BonusSpeed.Value = digimonPartySlot2BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3CD8C;
                byte[] digimonPartySlot2CAM = savegameBr.ReadBytes(2);
                short digimonPartySlot2CAMDec = BitConverter.ToInt16(digimonPartySlot2CAM, 0);
                numericUpDownCSDigimonPartySlot2CAM.Value = (digimonPartySlot2CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3CD8A;
                byte[] digimonPartySlot2ABI = savegameBr.ReadBytes(2);
                short digimonPartySlot2ABIDec = BitConverter.ToInt16(digimonPartySlot2ABI, 0);
                numericUpDownCSDigimonPartySlot2ABI.Value = digimonPartySlot2ABIDec;
                #endregion

                #region Equipment
                //Equip 1
                savegameBr.BaseStream.Position = 0x3CF06;
                byte[] digimonPartySlot2Equip1 = savegameBr.ReadBytes(2);
                short digimonPartySlot2Equip1Dec = BitConverter.ToInt16(digimonPartySlot2Equip1, 0);
                comboBoxCSDigimonPartySlot2Equip1.Text = convertEquipIDtoString(digimonPartySlot2Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3CF08;
                byte[] digimonPartySlot2Equip2 = savegameBr.ReadBytes(2);
                short digimonPartySlot2Equip2Dec = BitConverter.ToInt16(digimonPartySlot2Equip2, 0);
                comboBoxCSDigimonPartySlot2Equip2.Text = convertEquipIDtoString(digimonPartySlot2Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3CF0A;
                byte[] digimonPartySlot2Equip3 = savegameBr.ReadBytes(2);
                short digimonPartySlot2Equip3Dec = BitConverter.ToInt16(digimonPartySlot2Equip3, 0);
                comboBoxCSDigimonPartySlot2Equip3.Text = convertEquipIDtoString(digimonPartySlot2Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3CF0C;
                byte[] digimonPartySlot2Accessory = savegameBr.ReadBytes(2);
                short digimonPartySlot2AccessoryDec = BitConverter.ToInt16(digimonPartySlot2Accessory, 0);
                comboBoxCSDigimonPartySlot2Accessory.Text = convertAccessoryIDtoString(digimonPartySlot2AccessoryDec);
                #endregion

                #region CurrentSkills2
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3CD90;
                byte digimonPartySlot2CurrentSkill1Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2CurrentSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill1Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CD94;
                    comboBoxCSDigimonPartySlot2CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3CD98;
                byte digimonPartySlot2CurrentSkill2Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2CurrentSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill2Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CD9C;
                    comboBoxCSDigimonPartySlot2CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3CDA0;
                byte digimonPartySlot2CurrentSkill3Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2CurrentSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill3Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CDA4;
                    comboBoxCSDigimonPartySlot2CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3CDA8;
                byte digimonPartySlot2CurrentSkill4Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2CurrentSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill4Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CDAC;
                    comboBoxCSDigimonPartySlot2CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3CDB0;
                byte digimonPartySlot2CurrentSkill5Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2CurrentSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill5Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CDB4;
                    comboBoxCSDigimonPartySlot2CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3CDB8;
                byte digimonPartySlot2CurrentSkill6Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2CurrentSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CDBC;
                    comboBoxCSDigimonPartySlot2CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills2
                //Learned Skill 1

                savegameBr.BaseStream.Position = 0x3CDC0;
                byte digimonPartySlot2LearnedSkill1Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill1Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3CDC4;
                    comboBoxCSDigimonPartySlot2LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3CDC8;
                byte digimonPartySlot2LearnedSkill2Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill2Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3CDCC;
                    comboBoxCSDigimonPartySlot2LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3CDD0;
                byte digimonPartySlot2LearnedSkill3Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill3Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3CDD4;
                    comboBoxCSDigimonPartySlot2LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3CDD8;
                byte digimonPartySlot2LearnedSkill4Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill4Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3CDDC;
                    comboBoxCSDigimonPartySlot2LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3CDE0;
                byte digimonPartySlot2LearnedSkill5Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill5Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3CDE4;
                    comboBoxCSDigimonPartySlot2LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3CDE8;
                byte digimonPartySlot2LearnedSkill6Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill6Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3CDEC;
                    comboBoxCSDigimonPartySlot2LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3CDF0;
                byte digimonPartySlot2LearnedSkill7Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill7Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill7Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3CDF4;
                    comboBoxCSDigimonPartySlot2LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3CDF8;
                byte digimonPartySlot2LearnedSkill8Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill8Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill8Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3CDFC;
                    comboBoxCSDigimonPartySlot2LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3CE00;
                byte digimonPartySlot2LearnedSkill9Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill9Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill9Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3CE04;
                    comboBoxCSDigimonPartySlot2LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3CE08;
                byte digimonPartySlot2LearnedSkill10Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill10Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill10Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3CE0C;
                    comboBoxCSDigimonPartySlot2LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3CE10;
                byte digimonPartySlot2LearnedSkill11Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill11Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill11Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3CE14;
                    comboBoxCSDigimonPartySlot2LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3CE18;
                byte digimonPartySlot2LearnedSkill12Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill12Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill12Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3CE1C;
                    comboBoxCSDigimonPartySlot2LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3CE20;
                byte digimonPartySlot2LearnedSkill13Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill13Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill13Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3CE24;
                    comboBoxCSDigimonPartySlot2LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3CE28;
                byte digimonPartySlot2LearnedSkill14Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill14Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill14Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3CE2C;
                    comboBoxCSDigimonPartySlot2LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3CE30;
                byte digimonPartySlot2LearnedSkill15Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill15Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill15Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3CE34;
                    comboBoxCSDigimonPartySlot2LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3CE38;
                byte digimonPartySlot2LearnedSkill16Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill16Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill16Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3CE3C;
                    comboBoxCSDigimonPartySlot2LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3CE40;
                byte digimonPartySlot2LearnedSkill17Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill17Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill17Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3CE44;
                    comboBoxCSDigimonPartySlot2LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3CE48;
                byte digimonPartySlot2LearnedSkill18Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill18Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill18Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3CE4C;
                    comboBoxCSDigimonPartySlot2LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3CE50;
                byte digimonPartySlot2LearnedSkill19Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill19Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill19Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3CE54;
                    comboBoxCSDigimonPartySlot2LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3CE58;
                byte digimonPartySlot2LearnedSkill20Inherited = savegameBr.ReadByte();
                if (digimonPartySlot2LearnedSkill20Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2LearnedSkill20Inherited.Checked = Convert.ToBoolean(digimonPartySlot2LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3CE5C;
                    comboBoxCSDigimonPartySlot2LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraits(1);
            }

            else
            {
                checkBoxCSDigimonPartySlot2None.Checked = true;
            }
            #endregion
            #endregion

            #region DigimonPartySlot3
            #region Main2
            //Check to see if it exists
            savegameBr.BaseStream.Position = 0x3CF1C;
            if (savegameBr.ReadByte() != 0)
            {
                //ID
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3ID = savegameBr.ReadBytes(2);

                //Not sure if this is needed
                //if (BitConverter.IsLittleEndian != true)
                //{                            
                //    Array.Reverse(digimonSlot3ID);
                //}

                short digimonPartySlot3IDDec = BitConverter.ToInt16(digimonPartySlot3ID, 0);
                comboBoxCSDigimonPartySlot3ID.Text = convertDigimonIDtoString(digimonPartySlot3IDDec);

                //Nickname
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3Nickname = savegameBr.ReadBytes(17);
                string digimonPartySlot3NicknameDec = Encoding.ASCII.GetString(digimonPartySlot3Nickname);
                textBoxCSDigimonPartySlot3Nickname.Text = digimonPartySlot3NicknameDec;

                //Digivolution
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3Digivolution = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Digivolution.Text = convertDigivolutionIDtoString(digimonPartySlot3Digivolution);

                //Type
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3Type = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Type.Text = convertTypeIDtoString(digimonPartySlot3Type);

                //Attribute
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3Attribute = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Attribute.Text = convertAttributeIDtoString(digimonPartySlot3Attribute);

                //Personality
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3Personality = savegameBr.ReadByte();
                comboBoxCSDigimonPartySlot3Personality.Text = convertPersonalityIDtoString(digimonPartySlot3Personality);

                //Support Skills
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3SupportSkill = savegameBr.ReadByte();
                comboBoxCSDigmonPartySlot3SupportSkill.Text = convertsupportSkillsIDtoString(digimonPartySlot3SupportSkill);
                #endregion

                #region Stats2
                //Equip Slots
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3EquipSlots = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3EquipSlots.Value = digimonPartySlot3EquipSlots;

                //Memory Use
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3Memory = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3Memory.Value = digimonPartySlot3Memory;

                //EXP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3EXP = savegameBr.ReadBytes(4);
                int digimonPartySlot3EXPDec = BitConverter.ToInt32(digimonPartySlot3EXP, 0);
                numericUpDownCSDigimonPartySlot3EXP.Value = digimonPartySlot3EXPDec;

                //Current Level
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3CurrentLVL.Value = digimonPartySlot3CurrentLVL;

                //Max Level
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3MaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3MaxLVL.Value = digimonPartySlot3MaxLVL;

                //Extra Max Level
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3ExtraMaxLVL = savegameBr.ReadByte();
                numericUpDownCSDigimonPartySlot3ExtraMaxLVL.Value = digimonPartySlot3ExtraMaxLVL;

                //Current HP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3CurrentHP = savegameBr.ReadBytes(2);
                short digimonPartySlot3CurrentHPDec = BitConverter.ToInt16(digimonPartySlot3CurrentHP, 0);
                numericUpDownCSDigimonPartySlot3CurrentHP.Value = digimonPartySlot3CurrentHPDec;

                //Max HP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3MaxHP = savegameBr.ReadBytes(2);
                short digimonPartySlot3MaxHPDec = BitConverter.ToInt16(digimonPartySlot3MaxHP, 0);
                numericUpDownCSDigimonPartySlot3MaxHP.Value = digimonPartySlot3MaxHPDec * 10;

                //Bonus HP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3BonusHP = savegameBr.ReadBytes(2);
                short digimonPartySlot3BonusHPDec = BitConverter.ToInt16(digimonPartySlot3BonusHP, 0);
                numericUpDownCSDigimonPartySlot3BonusHP.Value = digimonPartySlot3BonusHPDec;

                //Current SP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3CurrentSP = savegameBr.ReadBytes(2);
                short digimonPartySlot3CurrentSPDec = BitConverter.ToInt16(digimonPartySlot3CurrentSP, 0);
                numericUpDownCSDigimonPartySlot3CurrentSP.Value = digimonPartySlot3CurrentSPDec;

                //Max SP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3MaxSP = savegameBr.ReadBytes(2);
                short digimonPartySlot3MaxSPDec = BitConverter.ToInt16(digimonPartySlot3MaxSP, 0);
                numericUpDownCSDigimonPartySlot3MaxSP.Value = digimonPartySlot3MaxSPDec;

                //Bonus SP
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3BonusSP = savegameBr.ReadBytes(2);
                short digimonPartySlot3BonusSPDec = BitConverter.ToInt16(digimonPartySlot3BonusSP, 0);
                numericUpDownCSDigimonPartySlot3BonusSP.Value = digimonPartySlot3BonusSPDec;

                //Attack
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3Attack = savegameBr.ReadBytes(2);
                short digimonPartySlot3AttackDec = BitConverter.ToInt16(digimonPartySlot3Attack, 0);
                numericUpDownCSDigimonPartySlot3Attack.Value = digimonPartySlot3AttackDec;

                //Bonus Attack
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3BonusAttack = savegameBr.ReadBytes(2);
                short digimonPartySlot3BonusAttackDec = BitConverter.ToInt16(digimonPartySlot3BonusAttack, 0);
                numericUpDownCSDigimonPartySlot3BonusAttack.Value = digimonPartySlot3BonusAttackDec;

                //Defense
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3Defense = savegameBr.ReadBytes(2);
                short digimonPartySlot3DefenseDec = BitConverter.ToInt16(digimonPartySlot3Defense, 0);
                numericUpDownCSDigimonPartySlot3Defense.Value = digimonPartySlot3DefenseDec;

                //Bonus Defense
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3BonusDefense = savegameBr.ReadBytes(2);
                short digimonPartySlot3BonusDefenseDec = BitConverter.ToInt16(digimonPartySlot3BonusDefense, 0);
                numericUpDownCSDigimonPartySlot3BonusDefense.Value = digimonPartySlot3BonusDefenseDec;

                //Intelligence
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3Intelligence = savegameBr.ReadBytes(2);
                short digimonPartySlot3IntelligenceDec = BitConverter.ToInt16(digimonPartySlot3Intelligence, 0);
                numericUpDownCSDigimonPartySlot3Intelligence.Value = digimonPartySlot3IntelligenceDec;

                //Bonus Intelligence
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3BonusIntelligence = savegameBr.ReadBytes(2);
                short digimonPartySlot3BonusIntelligenceDec = BitConverter.ToInt16(digimonPartySlot3BonusIntelligence, 0);
                numericUpDownCSDigimonPartySlot3BonusIntelligence.Value = digimonPartySlot3BonusIntelligenceDec;

                //Speed
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3Speed = savegameBr.ReadBytes(2);
                short digimonPartySlot3SpeedDec = BitConverter.ToInt16(digimonPartySlot3Speed, 0);
                numericUpDownCSDigimonPartySlot3Speed.Value = digimonPartySlot3SpeedDec;

                //Bonus Speed
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3BonusSpeed = savegameBr.ReadBytes(2);
                short digimonPartySlot3BonusSpeedDec = BitConverter.ToInt16(digimonPartySlot3BonusSpeed, 0);
                numericUpDownCSDigimonPartySlot3BonusSpeed.Value = digimonPartySlot3BonusSpeedDec;

                //CAM
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3CAM = savegameBr.ReadBytes(2);
                short digimonPartySlot3CAMDec = BitConverter.ToInt16(digimonPartySlot3CAM, 0);
                numericUpDownCSDigimonPartySlot3CAM.Value = (digimonPartySlot3CAMDec);

                //ABI
                savegameBr.BaseStream.Position = 0x3C;
                byte[] digimonPartySlot3ABI = savegameBr.ReadBytes(2);
                short digimonPartySlot3ABIDec = BitConverter.ToInt16(digimonPartySlot3ABI, 0);
                numericUpDownCSDigimonPartySlot3ABI.Value = digimonPartySlot3ABIDec;
                #endregion

                #region Equipment
                //Equip 1
                savegameBr.BaseStream.Position = 0x3D;
                byte[] digimonPartySlot3Equip1 = savegameBr.ReadBytes(2);
                short digimonPartySlot3Equip1Dec = BitConverter.ToInt16(digimonPartySlot3Equip1, 0);
                comboBoxCSDigimonPartySlot3Equip1.Text = convertEquipIDtoString(digimonPartySlot3Equip1Dec);

                //Equip 2
                savegameBr.BaseStream.Position = 0x3D;
                byte[] digimonPartySlot3Equip2 = savegameBr.ReadBytes(2);
                short digimonPartySlot3Equip2Dec = BitConverter.ToInt16(digimonPartySlot3Equip2, 0);
                comboBoxCSDigimonPartySlot3Equip2.Text = convertEquipIDtoString(digimonPartySlot3Equip2Dec);

                //Equip 3
                savegameBr.BaseStream.Position = 0x3D;
                byte[] digimonPartySlot3Equip3 = savegameBr.ReadBytes(2);
                short digimonPartySlot3Equip3Dec = BitConverter.ToInt16(digimonPartySlot3Equip3, 0);
                comboBoxCSDigimonPartySlot3Equip3.Text = convertEquipIDtoString(digimonPartySlot3Equip3Dec);

                //Accessory
                savegameBr.BaseStream.Position = 0x3D;
                byte[] digimonPartySlot3Accessory = savegameBr.ReadBytes(2);
                short digimonPartySlot3AccessoryDec = BitConverter.ToInt16(digimonPartySlot3Accessory, 0);
                comboBoxCSDigimonPartySlot3Accessory.Text = convertAccessoryIDtoString(digimonPartySlot3AccessoryDec);
                #endregion

                #region CurrentSkills2
                //Current Skill 1
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentSkill1Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3CurrentSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill1Inherited.Checked = Convert.ToBoolean(digimonPartySlot3CurrentSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3C;
                    comboBoxCSDigimonPartySlot3CurrentSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 2
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentSkill2Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3CurrentSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill2Inherited.Checked = Convert.ToBoolean(digimonPartySlot3CurrentSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3C;
                    comboBoxCSDigimonPartySlot3CurrentSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 3
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentSkill3Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3CurrentSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill3Inherited.Checked = Convert.ToBoolean(digimonPartySlot3CurrentSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3C;
                    comboBoxCSDigimonPartySlot3CurrentSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 4
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentSkill4Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3CurrentSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill4Inherited.Checked = Convert.ToBoolean(digimonPartySlot3CurrentSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3C;
                    comboBoxCSDigimonPartySlot3CurrentSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 5
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentSkill5Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3CurrentSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill5Inherited.Checked = Convert.ToBoolean(digimonPartySlot3CurrentSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3C;
                    comboBoxCSDigimonPartySlot3CurrentSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Current Skill 6
                savegameBr.BaseStream.Position = 0x3C;
                byte digimonPartySlot3CurrentSkill6Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3CurrentSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3CurrentSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Checked = Convert.ToBoolean(digimonPartySlot2CurrentSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3C;
                    comboBoxCSDigimonPartySlot2CurrentSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }
                #endregion

                #region LearnedSkills2
                //Learned Skill 1

                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill1Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill1Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill1None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill1Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill1Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill1.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 2
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill2Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill2Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill2None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill2Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill2Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill2.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 3
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill3Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill3Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill3None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill3Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill3Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill3.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 4
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill4Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill4Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill4None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill4Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill4Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill4.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 5
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill5Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill5Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill5None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill5Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill5Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill5.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 6
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill6Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill6Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill6None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill6Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill6Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 7
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill7Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill7Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill7None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill7Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill7Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill7.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 8
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill8Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill8Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill8None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill8Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill8Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill8.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 9
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill9Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill9Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill9None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill9Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill9Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill9.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 10
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill10Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill10Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill10None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill10Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill10Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill10.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 11
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill11Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill11Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill11None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill11Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill11Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill6.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 12
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill12Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill12Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill12None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill12Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill12Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill12.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 13
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill13Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill13Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill13None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill13Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill13Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill13.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 14
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill14Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill14Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill14None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill14Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill14Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill14.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 15
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill15Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill15Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill15None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill15Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill15Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill15.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 16
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill16Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill16Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill16None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill16Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill16Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill16.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 17
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill17Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill17Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill17None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill17Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill17Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill17.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 18
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill18Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill18Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill18None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill18Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill18Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill18.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 19
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill19Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill19Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill19None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill19Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill19Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill19.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                //Learned Skill 20
                savegameBr.BaseStream.Position = 0x3D;
                byte digimonPartySlot3LearnedSkill20Inherited = savegameBr.ReadByte();
                if (digimonPartySlot3LearnedSkill20Inherited > 1)
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill20None.Checked = true;
                }
                else
                {
                    checkBoxCSDigimonPartySlot3LearnedSkill20Inherited.Checked = Convert.ToBoolean(digimonPartySlot3LearnedSkill20Inherited);
                    savegameBr.BaseStream.Position = 0x3D;
                    comboBoxCSDigimonPartySlot3LearnedSkill20.Text = convertSkillIDtoString(savegameBr.ReadInt16());
                }

                #endregion
                getDigimonPortraits(1);
            }

            else
            {
                checkBoxCSDigimonPartySlot2None.Checked = true;
            }
            #endregion
            #endregion


            savegameBr.Close();
        }

        private void setData()
        {
            FileStream saveOpen = new FileStream(savegame, FileMode.Open);
            BinaryWriter saveWrite = new BinaryWriter(saveOpen);

            //Save first Digimon In Party data
            #region DigimonPartySlot1
            #region Main1
            //ID
            byte[] digimonPartySlot1IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxCSDigimonPartySlot1ID.Text));
            saveOpen.Position = 0x3CAAC;
            saveWrite.Write(digimonPartySlot1IDSet);

            //Nickname
            byte[] digimonPartySlot1NicknameSet = Encoding.ASCII.GetBytes(textBoxCSDigimonPartySlot1Nickname.Text);
            saveOpen.Position = 0x3CABC;
            saveWrite.Write(digimonPartySlot1NicknameSet);
            if (digimonPartySlot1NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - digimonPartySlot1NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] digimonPartySlot1DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxCSDigimonPartySlot1Digivolution.Text));
            saveOpen.Position = 0x3CAB8;
            saveWrite.Write(digimonPartySlot1DigivolutionSet);

            //Type
            byte[] digimonPartySlot1TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxCSDigimonPartySlot1Type.Text));
            saveOpen.Position = 0x3CAB4;
            saveWrite.Write(digimonPartySlot1TypeSet);

            //Attribute
            byte[] digimonPartySlot1AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxCSDigimonPartySlot1Attribute.Text));
            saveOpen.Position = 0x3CAB0;
            saveWrite.Write(digimonPartySlot1AttributeSet);

            //Personality
            byte[] digimonPartySlot1PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxCSDigimonPartySlot1Personality.Text));
            saveOpen.Position = 0x3CB20;
            saveWrite.Write(digimonPartySlot1PersonalitySet);

            //Support Skills
            byte[] digimonPartySlot1SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxCSDigmonPartySlot1SupportSkill.Text));
            saveOpen.Position = 0x3CCC0;
            saveWrite.Write(digimonPartySlot1SupportSkillSet);
            #endregion

            #region Stats1
            //Equip Slots
            byte[] digimonPartySlot1EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1EquipSlots.Value);
            saveOpen.Position = 0x3CCC4;
            saveWrite.Write(digimonPartySlot1EquipSlotsSet);

            //Memory Use
            byte[] digimonPartySlot1MemorySet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Memory.Value);
            saveOpen.Position = 0x3CB04;
            saveWrite.Write(digimonPartySlot1MemorySet);

            //EXP
            byte[] digimonPartySlot1EXPSet = BitConverter.GetBytes((int)numericUpDownCSDigimonPartySlot1EXP.Value);
            saveOpen.Position = 0x3CB18;
            saveWrite.Write(digimonPartySlot1EXPSet);

            //Current LVL
            byte[] digimonPartySlot1CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CurrentLVL.Value);
            saveOpen.Position = 0x3CB10;
            saveWrite.Write(digimonPartySlot1CurrentLVLSet);

            //Max Level
            byte[] digimonPartySlot1MaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1MaxLVL.Value);
            saveOpen.Position = 0x3CB12;
            saveWrite.Write(digimonPartySlot1MaxLVLSet);

            //Extra Max Level
            byte[] digimonPartySlot1ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1ExtraMaxLVL.Value);
            saveOpen.Position = 0x3CB14;
            saveWrite.Write(digimonPartySlot1ExtraMaxLVLSet);

            //Current HP
            byte[] digimonPartySlot1CurrentHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CurrentHP.Value);
            saveOpen.Position = 0x3CB24;
            saveWrite.Write(digimonPartySlot1CurrentHPSet);

            //Max HP
            byte[] digimonPartySlot1MaxHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1MaxHP.Value / 10);
            saveOpen.Position = 0x3CB28;
            saveWrite.Write(digimonPartySlot1MaxHPSet);

            //Bonus HP
            byte[] digimonPartySlot1BonusHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusHP.Value);
            saveOpen.Position = 0x3CB2C;
            saveWrite.Write(digimonPartySlot1BonusHPSet);

            //Current SP
            byte[] digimonPartySlot1CurrentSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CurrentSP.Value);
            saveOpen.Position = 0x3CB30;
            saveWrite.Write(digimonPartySlot1CurrentSPSet);

            //Max SP
            byte[] digimonPartySlot1MaxSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1MaxSP.Value);
            saveOpen.Position = 0x3CB34;
            saveWrite.Write(digimonPartySlot1MaxSPSet);

            //Bonus SP
            byte[] digimonPartySlot1BonusSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusSP.Value);
            saveOpen.Position = 0x3CB38;
            saveWrite.Write(digimonPartySlot1BonusSPSet);

            //Attack
            byte[] digimonPartySlot1AttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Attack.Value);
            saveOpen.Position = 0x3CB3A;
            saveWrite.Write(digimonPartySlot1AttackSet);

            //Bonus Attack
            byte[] digimonPartySlot1BonusAttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusAttack.Value);
            saveOpen.Position = 0x3CB3C;
            saveWrite.Write(digimonPartySlot1BonusAttackSet);

            //Defense
            byte[] digimonPartySlot1DefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Defense.Value);
            saveOpen.Position = 0x3CB3E;
            saveWrite.Write(digimonPartySlot1DefenseSet);

            //Bonus Defense
            byte[] digimonPartySlot1BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusDefense.Value);
            saveOpen.Position = 0x3CB40;
            saveWrite.Write(digimonPartySlot1BonusDefenseSet);

            //Intelligence
            byte[] digimonPartySlot1IntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Intelligence.Value);
            saveOpen.Position = 0x3CB42;
            saveWrite.Write(digimonPartySlot1IntelligenceSet);

            //Bonus Intelligence
            byte[] digimonPartySlot1BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusIntelligence.Value);
            saveOpen.Position = 0x3CB44;
            saveWrite.Write(digimonPartySlot1BonusIntelligenceSet);

            //Speed
            byte[] digimonPartySlot1SpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1Speed.Value);
            saveOpen.Position = 0x3CB46;
            saveWrite.Write(digimonPartySlot1SpeedSet);

            //Bonus Speed
            byte[] digimonPartySlot1BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1BonusSpeed.Value);
            saveOpen.Position = 0x3CB48;
            saveWrite.Write(digimonPartySlot1BonusSpeedSet);

            //CAM
            byte[] digimonPartySlot1CAMSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1CAM.Value);
            saveOpen.Position = 0x3CB4C;
            saveWrite.Write(digimonPartySlot1CAMSet);

            //ABI
            byte[] digimonPartySlot1ABISet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot1ABI.Value);
            saveOpen.Position = 0x3CB4A;
            saveWrite.Write(digimonPartySlot1ABISet);
            #endregion

            #region Equipment1
            //Equip 1
            byte[] digimonPartySlot1Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot1Equip1.Text));
            saveOpen.Position = 0x3CCC6;
            saveWrite.Write(digimonPartySlot1Equip1Set);

            //Equip 2
            byte[] digimonPartySlot1Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot1Equip2.Text));
            saveOpen.Position = 0x3CCC8;
            saveWrite.Write(digimonPartySlot1Equip2Set);

            //Equip 3
            byte[] digimonPartySlot1Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot1Equip3.Text));
            saveOpen.Position = 0x3CCCA;
            saveWrite.Write(digimonPartySlot1Equip3Set);

            //Accessory
            byte[] digimonPartySlot1AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxCSDigimonPartySlot1Accessory.Text));
            saveOpen.Position = 0x3CCCC;
            saveWrite.Write(digimonPartySlot1AccessorySet);
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
                byte[] digimonPartySlot1CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill1.Text));
                saveOpen.Position = 0x3CB54;
                saveWrite.Write(digimonPartySlot1CurrentSkill1Set);
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
                byte[] digimonPartySlot1CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill2.Text));
                saveOpen.Position = 0x3CB5C;
                saveWrite.Write(digimonPartySlot1CurrentSkill2Set);
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
                byte[] digimonPartySlot1CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill3.Text));
                saveOpen.Position = 0x3CB64;
                saveWrite.Write(digimonPartySlot1CurrentSkill3Set);
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
                byte[] digimonPartySlot1CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill4.Text));
                saveOpen.Position = 0x3CB6C;
                saveWrite.Write(digimonPartySlot1CurrentSkill4Set);
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
                byte[] digimonPartySlot1CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill5.Text));
                saveOpen.Position = 0x3CB74;
                saveWrite.Write(digimonPartySlot1CurrentSkill5Set);
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
                byte[] digimonPartySlot1CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot1CurrentSkill6.Text));
                saveOpen.Position = 0x3CB7C;
                saveWrite.Write(digimonPartySlot1CurrentSkill6Set);
            }

            #endregion

            //Save second Digimon In Party data
            #region DigimonPartySlot2
            #region Main2
            //ID
            byte[] digimonPartySlot2IDSet = BitConverter.GetBytes(convertStringtoDigimonID(comboBoxCSDigimonPartySlot2ID.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2IDSet);

            //Nickname
            byte[] digimonPartySlot2NicknameSet = Encoding.ASCII.GetBytes(textBoxCSDigimonPartySlot2Nickname.Text);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2NicknameSet);
            if (digimonPartySlot2NicknameSet.Length < 17)
            {
                int bytesToAdd = 17 - digimonPartySlot2NicknameSet.Length;
                byte[] extra1 = new byte[bytesToAdd];
                saveWrite.Write(extra1);
            }

            //Digivolution
            byte[] digimonPartySlot2DigivolutionSet = BitConverter.GetBytes(convertStringtoDigivolutionID(comboBoxCSDigimonPartySlot2Digivolution.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2DigivolutionSet);

            //Type
            byte[] digimonPartySlot2TypeSet = BitConverter.GetBytes(convertStringtoTypeID(comboBoxCSDigimonPartySlot2Type.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2TypeSet);

            //Attribute
            byte[] digimonPartySlot2AttributeSet = BitConverter.GetBytes(convertStringtoAttributeID(comboBoxCSDigimonPartySlot2Attribute.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2AttributeSet);

            //Personality
            byte[] digimonPartySlot2PersonalitySet = BitConverter.GetBytes(convertStringtoPersonalityID(comboBoxCSDigimonPartySlot2Personality.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2PersonalitySet);

            //Support Skills
            byte[] digimonPartySlot2SupportSkillSet = BitConverter.GetBytes(convertStringtoSupportSkillID(comboBoxCSDigmonPartySlot2SupportSkill.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2SupportSkillSet);
            #endregion

            #region Stats2
            //Equip Slots
            byte[] digimonPartySlot2EquipSlotsSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2EquipSlots.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2EquipSlotsSet);

            //Memory Use
            byte[] digimonPartySlot2MemorySet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Memory.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2MemorySet);

            //EXP
            byte[] digimonPartySlot2EXPSet = BitConverter.GetBytes((int)numericUpDownCSDigimonPartySlot2EXP.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2EXPSet);

            //Current LVL
            byte[] digimonPartySlot2CurrentLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CurrentLVL.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2CurrentLVLSet);

            //Max Level
            byte[] digimonPartySlot2MaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2MaxLVL.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2MaxLVLSet);

            //Extra Max Level
            byte[] digimonPartySlot2ExtraMaxLVLSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2ExtraMaxLVL.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2ExtraMaxLVLSet);

            //Current HP
            byte[] digimonPartySlot2CurrentHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CurrentHP.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2CurrentHPSet);

            //Max HP
            byte[] digimonPartySlot2MaxHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2MaxHP.Value / 10);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2MaxHPSet);

            //Bonus HP
            byte[] digimonPartySlot2BonusHPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusHP.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2BonusHPSet);

            //Current SP
            byte[] digimonPartySlot2CurrentSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CurrentSP.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2CurrentSPSet);

            //Max SP
            byte[] digimonPartySlot2MaxSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2MaxSP.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2MaxSPSet);

            //Bonus SP
            byte[] digimonPartySlot2BonusSPSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusSP.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2BonusSPSet);

            //Attack
            byte[] digimonPartySlot2AttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Attack.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2AttackSet);

            //Bonus Attack
            byte[] digimonPartySlot2BonusAttackSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusAttack.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2BonusAttackSet);

            //Defense
            byte[] digimonPartySlot2DefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Defense.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2DefenseSet);

            //Bonus Defense
            byte[] digimonPartySlot2BonusDefenseSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusDefense.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2BonusDefenseSet);

            //Intelligence
            byte[] digimonPartySlot2IntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Intelligence.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2IntelligenceSet);

            //Bonus Intelligence
            byte[] digimonPartySlot2BonusIntelligenceSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusIntelligence.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2BonusIntelligenceSet);

            //Speed
            byte[] digimonPartySlot2SpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2Speed.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2SpeedSet);

            //Bonus Speed
            byte[] digimonPartySlot2BonusSpeedSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2BonusSpeed.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2BonusSpeedSet);

            //CAM
            byte[] digimonPartySlot2CAMSet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2CAM.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2CAMSet);

            //ABI
            byte[] digimonPartySlot2ABISet = BitConverter.GetBytes((short)numericUpDownCSDigimonPartySlot2ABI.Value);
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2ABISet);
            #endregion

            #region Equipment2
            //Equip 1
            byte[] digimonPartySlot2Equip1Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot2Equip1.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2Equip1Set);

            //Equip 2
            byte[] digimonPartySlot2Equip2Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot2Equip2.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2Equip2Set);

            //Equip 3
            byte[] digimonPartySlot2Equip3Set = BitConverter.GetBytes(convertStringtoEquipID(comboBoxCSDigimonPartySlot2Equip3.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2Equip3Set);

            //Accessory
            byte[] digimonPartySlot2AccessorySet = BitConverter.GetBytes(convertStringtoAccessoryID(comboBoxCSDigimonPartySlot2Accessory.Text));
            saveOpen.Position = 0x;
            saveWrite.Write(digimonPartySlot2AccessorySet);
            #endregion

            #region CurrentSkills2
            //Current Skill 1
            saveOpen.Position = 0x;
            if (checkBoxCSDigimonPartySlot2CurrentSkill1None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill1.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill1Inherited.Checked);
                byte[] digimonPartySlot2CurrentSkill1Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill1.Text));
                saveOpen.Position = 0x;
                saveWrite.Write(digimonPartySlot2CurrentSkill1Set);
            }

            //Current Skill 2
            saveOpen.Position = 0x;
            if (checkBoxCSDigimonPartySlot2CurrentSkill2None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill2.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill2Inherited.Checked);
                byte[] digimonPartySlot2CurrentSkill2Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill2.Text));
                saveOpen.Position = 0x;
                saveWrite.Write(digimonPartySlot2CurrentSkill2Set);
            }

            //Current Skill 3
            saveOpen.Position = 0x;
            if (checkBoxCSDigimonPartySlot2CurrentSkill3None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill3.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill3Inherited.Checked);
                byte[] digimonPartySlot2CurrentSkill3Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill3.Text));
                saveOpen.Position = 0x;
                saveWrite.Write(digimonPartySlot2CurrentSkill3Set);
            }

            //Current Skill 4
            saveOpen.Position = 0x;
            if (checkBoxCSDigimonPartySlot2CurrentSkill4None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill4.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill4Inherited.Checked);
                byte[] digimonPartySlot2CurrentSkill4Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill4.Text));
                saveOpen.Position = 0x;
                saveWrite.Write(digimonPartySlot2CurrentSkill4Set);
            }

            //Current Skill 5
            saveOpen.Position = 0x;
            if (checkBoxCSDigimonPartySlot2CurrentSkill5None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill5.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill5Inherited.Checked);
                byte[] digimonPartySlot2CurrentSkill5Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill5.Text));
                saveOpen.Position = 0x;
                saveWrite.Write(digimonPartySlot2CurrentSkill5Set);
            }

            //Current Skill 6
            saveOpen.Position = 0x;
            if (checkBoxCSDigimonPartySlot2CurrentSkill6None.Checked || comboBoxCSDigimonPartySlot2CurrentSkill6.Text == "(None)")
            {
                byte[] empty = BitConverter.GetBytes(-1);
                byte[] zero = BitConverter.GetBytes(0);
                saveWrite.Write(empty);
                saveOpen.Position = 0x;
                saveWrite.Write(zero);
            }
            else
            {
                saveWrite.Write(checkBoxCSDigimonPartySlot2CurrentSkill6Inherited.Checked);
                byte[] digimonPartySlot2CurrentSkill6Set = BitConverter.GetBytes(convertStringtoSkillID(comboBoxCSDigimonPartySlot2CurrentSkill6.Text));
                saveOpen.Position = 0x;
                saveWrite.Write(digimonPartySlot2CurrentSkill6Set);
            }

            #endregion
            #endregion
            saveOpen.Close();
        }

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

        void getDigimonPortraits(int slot)
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDlg();

            if (string.IsNullOrEmpty(savegame))
            {
                MessageBox.Show("No savegame selected!");
            }

            else
            {
                getData();
                saveToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setData();
            MessageBox.Show("Data saved!");
        }

        private void numericUpDownCSDigimonPartySlot1CurrentSkillSlot_ValueChanged(object sender, EventArgs e)
        {
            /*
            //reread data to set skill name according to new skill slot
            //also inherited skill check
            //NOT GONNA WORK
            //How are skills supposed to be saved if they change each time??
            FileStream savegameFs = new FileStream(savegame, FileMode.Open);
            BinaryReader savegameBr = new BinaryReader(savegameFs);

            switch (numericUpDownCSDigimonPartySlot1CurrentSkillSlot.Value)
            {
                case 1:
                    savegameBr.BaseStream.Position = 0x3CB50;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB54;
                    short digimonPartySlot1CurrentSkill1 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill1);
                    break;
                case 2:
                    savegameBr.BaseStream.Position = 0x3CB58;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB5C;
                    short digimonPartySlot1CurrentSkill2 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill2);
                    break;
                case 3:
                    savegameBr.BaseStream.Position = 0x3CB60;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB64;
                    short digimonPartySlot1CurrentSkill3 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill3);
                    break;
                case 4:
                    savegameBr.BaseStream.Position = 0x3CB68;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB6C;
                    short digimonPartySlot1CurrentSkill4 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill4);
                    break;
                case 5:
                    savegameBr.BaseStream.Position = 0x3CB70;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB74;
                    short digimonPartySlot1CurrentSkill5 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill5);
                    break;
                case 6:
                    savegameBr.BaseStream.Position = 0x3CB78;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB7C;
                    short digimonPartySlot1CurrentSkill6 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill6);
                    break;
                default:
                    savegameBr.BaseStream.Position = 0x3CB50;
                    checkBoxCSDigimonPartySlot1CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x3CB54;
                    short digimonPartySlot1CurrentSkill = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot1CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot1CurrentSkill);
                    break;
            }
            savegameBr.Close();
            */
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
            /*
            //reread data to set skill name according to new skill slot
            //also inherited skill check
            //NOT GONNA WORK
            //How are skills supposed to be saved if they change each time??
            FileStream savegameFs = new FileStream(savegame, FileMode.Open);
            BinaryReader savegameBr = new BinaryReader(savegameFs);

            switch (numericUpDownCSDigimonPartySlot1CurrentSkillSlot.Value)
            {
                case 1:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill1 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill1);
                    break;
                case 2:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill2 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill2);
                    break;
                case 3:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill3 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill3);
                    break;
                case 4:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill4 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill4);
                    break;
                case 5:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill5 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill5);
                    break;
                case 6:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill6 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill6);
                    break;
                default:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot2CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot2CurrentSkill = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot2CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot2CurrentSkill);
                    break;
            }
            savegameBr.Close();
            */
        }

        private void numericUpDownCSDigimonPartySlot2LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageCSDigimonPartySlot2CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCSDigimonPartySlot2ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraits(1);
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
            /*
            //reread data to set skill name according to new skill slot
            //also inherited skill check
            //NOT GONNA WORK
            //How are skills supposed to be saved if they change each time??
            FileStream savegameFs = new FileStream(savegame, FileMode.Open);
            BinaryReader savegameBr = new BinaryReader(savegameFs);

            switch (numericUpDownCSDigimonPartySlot3CurrentSkillSlot.Value)
            {
                case 1:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill1 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill1);
                    break;
                case 2:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill2 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill2);
                    break;
                case 3:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill3 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill3);
                    break;
                case 4:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill4 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill4);
                    break;
                case 5:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill5 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill5);
                    break;
                case 6:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill6 = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill6);
                    break;
                default:
                    savegameBr.BaseStream.Position = 0x;
                    checkBoxCSDigimonPartySlot3CurrentSkillInherited.Checked = Convert.ToBoolean(savegameBr.ReadByte());
                    savegameBr.BaseStream.Position = 0x;
                    short digimonPartySlot3CurrentSkill = savegameBr.ReadInt16();
                    comboBoxCSDigimonPartySlot3CurrentSkillName.Text = convertSkillIDtoString(digimonPartySlot3CurrentSkill);
                    break;
            }
            savegameBr.Close();
            */
        }

        private void numericUpDownCSDigimonPartySlot3LearnedSkillSlot_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPageCSDigimonPartySlot3CurrentSkills_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCSDigimonPartySlot3ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDigimonPortraits(1);
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
    }
}
