using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IAP
{
	public class IAP_Form : Form
	{
		private const byte is_OLD_COM = 1;

		private const byte is_NEW_COM = 2;

		private const uint MAX_IAPSW_SIZE = 385024;

		private const string File_Config = "Config_NCIAP.inf";

		private const byte Max_NoDataCount = 15;

		private const byte Max_SNActTryCount = 5;

		private byte m_COM_LEN;

		private byte m_COM_ID = 1;

		private byte m_COM_ME = 2;

		private byte m_COM_CMD = 3;

		private byte m_COM_INDEX = 4;

		private byte m_COM_DATA = 5;

		private byte m_COM_TYPE = 2;

		private byte m_b_IAPObject;

		private byte m_b_IAPResult;

		private bool m_bol_IAPAnswer;

		private bool m_bol_IAPing;

		private byte[][] m_b_IAPFileBin = new byte[9][];

		private string[] m_str_IAPFileName = new string[9];

		private int[] m_i_IAPFileLen = new int[9];

		private int[] m_i_IAPFileCrc = new int[9];

		private ushort m_us_IAPTimer;

		public int m_i_Password;

		private short[] m_s_CmdMap = new short[NinebotCmd.NB_CMDMAP_LEN];

		private short[] m_s_BMS_1_CmdMap = new short[MiniBatteryCmdMap.BMS_CMDMAP_LEN];

		private short[] m_s_BMS_2_CmdMap = new short[MiniBatteryCmdMap.BMS_CMDMAP_LEN];

		private short[] m_s_BMS_3_CmdMap = new short[MiniBatteryCmdMap.BMS_CMDMAP_LEN];

		private bool m_bol_ReadBack;

		private byte m_b_NoDataCount;

		private byte m_b_SendCount;

		private uint m_ui_RecvCount;

		private byte m_b_BufTxLen = 128;

		private byte m_MyID = CmdDefine.V_PC_ID;

		private byte m_DriverID = CmdDefine.V_Plus_ID;

		private byte m_BMSID_1 = CmdDefine.V_Plus_BMS_ID;

		private byte m_BMSID_2;

		private byte m_BMSID_3;

		private byte m_BLEID = CmdDefine.V_Plus_DIS_ID;

		private byte m_UPCID = CmdDefine.V_UPC_ID;

		private byte m_ANCID = CmdDefine.V_ANC_ID;

		private byte m_TAGID = CmdDefine.V_TAG_ID;

		private byte m_FEIMIID = CmdDefine.V_FEIMI_ID;

		private bool m_bol_FristInput = true;

		private bool m_bol_SetSNOK;

		private bool m_bol_SNing;

		private bool m_bol_Acting;

		private bool m_bol_UnActing;

		private byte m_b_SNActTryCount;

		private byte s_b_PWClick;

		private byte[] s_b_RevData = new byte[4096];

		private int s_i_RevLen;

		private bool s_bol_FrameHead;

		private bool s_bol_BeginFrame;

		private int s_i_GetCrc;

		private int s_i_CheckSum;

		private int s_i_RxPos;

		private int s_i_RxLen;

		private byte[] s_b_RxBuf = new byte[4096];

		private IContainer components;

		private SerialPort Serialport_Used;

		private ComboBox IDC_COMBO_COM;

		private Button IDC_BTN_OPENCOM;

		private PictureBox IDC_STATIC_ICON;

		private Button IDC_BTN_BLESWAN;

		private ListBox IDC_LIST_BLELIST;

		private System.Windows.Forms.Timer Timer_SendData;

		private GroupBox groupBox1;

		private Button IDC_BTN_LOCK;

		private Button IDC_BTN_AUTH;

		private TextBox IDC_EDIT_PASSWORD;

		private Label label3;

		private GroupBox IDC_GB_SERIAL;

		private ComboBox IDC_COMBO_BAUDRATE;

		private GroupBox IDC_GB_BLE;

		private Button IDC_BTN_UNLOCK;

		private GroupBox groupBox4;

		private Label IDC_LABEL_BLEVER;

		private Label IDC_LABEL_BMSVER_1;

		private Label IDC_LABEL_DRIVERVER;

		private Label label8;

		private Label label6;

		private Label label4;

		private System.Windows.Forms.Timer Timer_FreshData;

		private Button IDC_BTN_UNACT;

		private Button IDC_BTN_ACT;

		private ProgressBar IDC_PROGRESSBAR;

		private TextBox IDC_EDIT_INFO;

		private GroupBox groupBox5;

		private Label IDC_LABEL_BLEVER_SEL;

		private Label label5;

		private Label IDC_LABEL_BMSVER_SEL_1;

		private Label label7;

		private Label IDC_LABEL_DRIVERVER_SEL;

		private Label label9;

		private GroupBox IDC_GB_DRIVERIAP;

		private GroupBox IDC_GB_BMS1IAP;

		private GroupBox IDC_GB_BLEIAP;

		private GroupBox IDC_GB_UPCIAP;

		private GroupBox IDC_GB_ANCIAP;

		private GroupBox IDC_GB_TAGIAP;

		private TextBox IDC_EDIT_DRIVERFILE;

		private Button IDC_BTN_DNLDRIVERFILE;

		private Button IDC_BTN_SELDRIVERFILE;

		private Button IDC_BTN_SELBMSFILE_1;

		private Button IDC_BTN_SELBLEFILE;

		private Button IDC_BTN_SELUPCFILE;

		private Button IDC_BTN_SELANCHORFILE;

		private Button IDC_BTN_SELTAGFILE;

		private TextBox IDC_EDIT_BMSFILE_1;

		private TextBox IDC_EDIT_BLEFILE;

		private TextBox IDC_EDIT_UPCFILE;

		private TextBox IDC_EDIT_ANCHORFILE;

		private TextBox IDC_EDIT_TAGFILE;

		private Button IDC_BTN_DNLBMSFILE_1;

		private Button IDC_BTN_DNLBLEFILE;

		private Button IDC_BTN_DNLUPCFILE;

		private Button IDC_BTN_DNLANCHORFILE;

		private Button IDC_BTN_DNLTAGFILE;

		private Label IDC_LABEL_COUNT;

		private Label label1;

		private ComboBox IDC_COMBO_CAR;

		private Label IDC_LABEL_TAGVER;

		private Label IDC_LABEL_ANCVER;

		private Label IDC_LABEL_UPCVER;

		private Label label13;

		private Label label11;

		private Label label2;

		private Label IDC_LABEL_TAGVER_SEL;

		private Label IDC_LABEL_ANCVER_SEL;

		private Label IDC_LABEL_UPCVER_SEL;

		private Label label16;

		private Label label14;

		private Label label10;

		private RadioButton IDC_RB_CAN;

		private RadioButton IDC_RB_BLE;

		private RadioButton IDC_RB_PC;

		private Label IDC_LABEL_CONNMODE;

		private TabControl IDC_TC_ITEM;

		private TabPage tabPage1;

		private System.Windows.Forms.Timer Timer_Update_SN_ACT;

		private System.Windows.Forms.Timer Timer_IAP;

		private GroupBox IDC_GB_FEIMIIAP;

		private Button IDC_BTN_DNLFEIMIFILE;

		private Button IDC_BTN_SELFEIMIFILE;

		private TextBox IDC_EDIT_FEIMIFILE;

		private Label IDC_LABEL_FEIMIVER;

		private Label label24;

		private Label IDC_LABEL_FEIMIVER_SEL;

		private Label label27;

		private System.Windows.Forms.Timer Timer_BLEConnect;

		private System.Windows.Forms.Timer Timer_BLEScan;

		private GroupBox IDC_GB_BMS2IAP;

		private Button IDC_BTN_SELBMSFILE_2;

		private TextBox IDC_EDIT_BMSFILE_2;

		private Button IDC_BTN_DNLBMSFILE_2;

		private Label IDC_LABEL_BMSVER_2;

		private Label IDC_LABEL_BMSVER_SEL_2;

		private Label label30;

		private Label label28;

		private Label IDC_LABEL_BLECONNECTSTATUE;

		private GroupBox IDC_GB_BMS3IAP;

		private Button IDC_BTN_SELBMSFILE_3;

		private TextBox IDC_EDIT_BMSFILE_3;

		private Button IDC_BTN_DNLBMSFILE_3;

		private Label IDC_LABEL_BMSVER_3;

		private Label label15;

		private Label label17;

		private Label IDC_LABEL_BMSVER_SEL_3;

		public IAP_Form()
		{
			this.InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			this.Serialport_Init();
			this.Password_Init();
		}

		private void BLE_Connect()
		{
			this.Timer_BLEConnect.Start();
		}

		private void BLE_Connect_Finish()
		{
			this.Timer_BLEConnect.Stop();
		}

		private void BLE_List_DoubleClick(object sender, EventArgs e)
		{
			this.Timer_SendData.Stop();
			this.Timer_BLEScan.Stop();
			this.BLE_Connect();
		}

		private void BLE_Swan_Click(object sender, EventArgs e)
		{
			this.Timer_SendData.Stop();
			this.BLE_Connect_Finish();
			this.IDC_LIST_BLELIST.Items.Clear();
			this.Timer_BLEScan.Start();
		}

		private void CleanSig()
		{
			this.m_b_IAPResult = 9;
			this.m_bol_IAPAnswer = false;
		}

		private void DisableItems()
		{
			this.IDC_GB_BLE.Enabled = false;
			this.IDC_TC_ITEM.Enabled = false;
		}

		private void DisableSerialItems()
		{
			this.IDC_GB_SERIAL.Enabled = false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Download()
		{
			byte[] bytes;
			int j;
			try
			{
				byte[] numArray = File.ReadAllBytes(this.m_str_IAPFileName[this.m_b_IAPObject]);
				if ((long)((int)numArray.Length) <= (long)385024)
				{
					this.m_i_IAPFileLen[this.m_b_IAPObject] = (int)numArray.Length;
					this.m_b_IAPFileBin[this.m_b_IAPObject] = new byte[(int)numArray.Length];
					numArray.CopyTo(this.m_b_IAPFileBin[this.m_b_IAPObject], 0);
					int num = 0;
					for (int i = 0; i < (int)numArray.Length; i++)
					{
						num += numArray[i];
					}
					num = ~num;
					this.m_i_IAPFileCrc[this.m_b_IAPObject] = num;
					byte mDriverID = 0;
					ushort num1 = 0;
					this.IDC_EDIT_INFO.Clear();
					switch (this.m_b_IAPObject)
					{
						case 0:
						{
							num1 = 300;
							mDriverID = this.m_DriverID;
							bytes = new byte[] { 1, 0 };
							this.PushFrame(this.m_DriverID, (byte)((int)bytes.Length), CmdDefine.CMD_WR, CmdDefine.NB_CTL_LOCK, ref bytes);
							Thread.Sleep(200);
							this.PushFrame(this.m_DriverID, (byte)((int)bytes.Length), CmdDefine.CMD_WR, CmdDefine.NB_CTL_LOCK, ref bytes);
							Thread.Sleep(200);
							this.PushFrame(this.m_DriverID, (byte)((int)bytes.Length), CmdDefine.CMD_WR, CmdDefine.NB_CTL_LOCK, ref bytes);
							Thread.Sleep(200);
							this.IDC_EDIT_INFO.AppendText("...Update master firmware...\r\n");
							break;
						}
						case 1:
						{
							num1 = 300;
							mDriverID = this.m_BMSID_1;
							this.IDC_EDIT_INFO.AppendText("...Update BMS_1_ firmware...\r\n");
							break;
						}
						case 2:
						{
							num1 = 300;
							mDriverID = this.m_BMSID_2;
							this.IDC_EDIT_INFO.AppendText("...Update BMS_2_firmware...\r\n");
							break;
						}
						case 3:
						{
							num1 = 300;
							mDriverID = this.m_BMSID_3;
							this.IDC_EDIT_INFO.AppendText("...Update BMS_3_ firmware...\r\n");
							break;
						}
						case 4:
						{
							num1 = 300;
							mDriverID = this.m_BLEID;
							this.IDC_EDIT_INFO.AppendText("...Update BLE firmware...\r\n");
							break;
						}
						case 5:
						{
							mDriverID = this.m_UPCID;
							this.IDC_EDIT_INFO.AppendText("...Update UPC firmware...\r\n");
							break;
						}
						case 6:
						{
							mDriverID = this.m_ANCID;
							this.IDC_EDIT_INFO.AppendText("...Update ANC firmware...\r\n");
							break;
						}
						case 7:
						{
							bytes = new byte[1];
							this.PushFrame(this.m_ANCID, 0, CmdDefine.CMD_IAP_RESET, 0, ref bytes);
							Thread.Sleep(1000);
							mDriverID = this.m_TAGID;
							this.IDC_EDIT_INFO.AppendText("...Update TAG firmware...\r\n");
							break;
						}
						case 8:
						{
							num1 = 4000;
							mDriverID = this.m_FEIMIID;
							this.IDC_EDIT_INFO.AppendText("...Update the Femto firmware...\r\n");
							break;
						}
					}
					this.IDC_EDIT_INFO.AppendText("...Try to enter IAP mode...\r\n");
					bytes = BitConverter.GetBytes(this.m_i_IAPFileLen[this.m_b_IAPObject]);
					this.CleanSig();
					for (j = 1; j > 0; j--)
					{
						this.PushFrame(mDriverID, (byte)((int)bytes.Length), CmdDefine.CMD_IAP_BEGIN, 0, ref bytes);
						if (!this.SleepUntil(5000 + num1))
						{
							break;
						}
					}
					if (j <= 0)
					{
						this.IDC_EDIT_INFO.AppendText("Connection timed out!\r\n");
					}
					else if (!this.Serialport_Used.IsOpen)
					{
						this.IDC_EDIT_INFO.AppendText("Serial port is closed.\r\n");
					}
					else if (this.m_b_IAPResult == 0)
					{
						this.IDC_EDIT_INFO.AppendText("Successful entry IAP mode!\r\n");
						this.IDC_EDIT_INFO.AppendText("Start writing FLASH...");
						string text = this.IDC_EDIT_INFO.Text;
						byte num2 = 0;
						int mIIAPFileLen = 0;
						int num3 = 0;
						this.m_us_IAPTimer = 0;
						while (num3 < this.m_i_IAPFileLen[this.m_b_IAPObject])
						{
							this.IDC_PROGRESSBAR.Value = num3 * 100 / this.m_i_IAPFileLen[this.m_b_IAPObject];
							this.IDC_EDIT_INFO.Clear();
							TextBox dCEDITINFO = this.IDC_EDIT_INFO;
							string[] str = new string[] { text, null, null, null, null };
							str[1] = this.IDC_PROGRESSBAR.Value.ToString();
							str[2] = "%...";
							str[3] = this.m_us_IAPTimer.ToString();
							str[4] = "second";
							dCEDITINFO.AppendText(string.Concat(str));
							mIIAPFileLen = this.m_i_IAPFileLen[this.m_b_IAPObject] - num3;
							mIIAPFileLen = (mIIAPFileLen > this.m_b_BufTxLen ? (int)this.m_b_BufTxLen : mIIAPFileLen);
							bytes = new byte[this.m_b_BufTxLen];
							Buffer.BlockCopy(this.m_b_IAPFileBin[this.m_b_IAPObject], num3, bytes, 0, mIIAPFileLen);
							this.CleanSig();
							j = 5;
							while (j > 0)
							{
								this.PushFrame(mDriverID, this.m_b_BufTxLen, CmdDefine.CMD_IAP_WR, num2, ref bytes);
								if (!this.SleepUntil((this.m_b_BufTxLen == 8 ? 100 : 500) + (5 - j) * 100 + num1))
								{
									break;
								}
								j--;
							}
							if (j <= 0)
							{
								this.IDC_EDIT_INFO.AppendText("Connection timed out!\r\n");
								return;
							}
							else if (!this.Serialport_Used.IsOpen)
							{
								this.IDC_EDIT_INFO.AppendText("Serial port is closed!\r\n");
								return;
							}
							else if (this.m_b_IAPResult == 0)
							{
								num3 += mIIAPFileLen;
								num2 = (byte)(num2 + 1);
							}
							else
							{
								this.ShowIAPError(this.m_b_IAPResult);
								return;
							}
						}
						this.IDC_EDIT_INFO.AppendText("\r\nFLASH Write completion...100%\r\n");
						this.IDC_EDIT_INFO.AppendText("CRC check...\r\n");
						bytes = BitConverter.GetBytes(this.m_i_IAPFileCrc[this.m_b_IAPObject]);
						this.CleanSig();
						for (j = 5; j > 0; j--)
						{
							this.PushFrame(mDriverID, (byte)((int)bytes.Length), CmdDefine.CMD_IAP_CRC, 0, ref bytes);
							if (!this.SleepUntil(1000 + num1))
							{
								break;
							}
						}
						if (j <= 0)
						{
							this.IDC_EDIT_INFO.AppendText("Connection timed out!\r\n");
						}
						else if (!this.Serialport_Used.IsOpen)
						{
							this.IDC_EDIT_INFO.AppendText("Serial port is closed!\r\n");
						}
						else if (this.m_b_IAPResult == 0)
						{
							this.IDC_EDIT_INFO.AppendText("CRC Verify successful\r\n");
							Thread.Sleep(100);
							this.IDC_EDIT_INFO.AppendText("Reboot the device\r\n");
							bytes = new byte[] { 1 };
							this.PushFrame(mDriverID, 0, CmdDefine.CMD_IAP_RESET, 0, ref bytes);
							this.IDC_EDIT_INFO.AppendText("Firmware download completed\r\n");
							this.IDC_PROGRESSBAR.Value = 100;
						}
						else
						{
							this.ShowIAPError(this.m_b_IAPResult);
						}
					}
					else
					{
						this.ShowIAPError(this.m_b_IAPResult);
					}
				}
				else
				{
					MessageBox.Show("Bin File size out of range!");
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void Download_Thread()
		{
			this.m_bol_IAPing = true;
			this.Timer_SendData.Stop();
			this.DisableItems();
			this.Download();
			this.m_ui_RecvCount = 0;
			this.m_s_CmdMap[NinebotCmd.NB_INF_FW_VERSION] = 0;
			this.m_s_BMS_1_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] = 0;
			this.m_s_BMS_2_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] = 0;
			this.m_s_BMS_3_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] = 0;
			this.m_s_CmdMap[NinebotCmd.NB_INF_VER_BLE] = 0;
			this.m_s_CmdMap[NinebotCmd.NB_INF_UPC_VER] = 0;
			this.m_s_CmdMap[NinebotCmd.NB_INF_ANC_VER] = 0;
			this.m_s_CmdMap[NinebotCmd.NB_INF_TAG_VER] = 0;
			this.EnableItems();
			base.Invoke(new Action(() => this.Timer_SendData.Start()));
			this.m_bol_IAPing = false;
		}

		private void DownloadFile()
		{
			(new Thread(new ThreadStart(this.Download_Thread))).Start();
		}

		private void Enable_IAPItems()
		{
			this.IDC_GB_DRIVERIAP.Enabled = true;
			this.IDC_GB_BMS1IAP.Enabled = true;
			this.IDC_GB_BMS2IAP.Enabled = true;
			this.IDC_GB_BMS3IAP.Enabled = true;
			this.IDC_GB_BLEIAP.Enabled = true;
			this.IDC_GB_UPCIAP.Enabled = true;
			this.IDC_GB_ANCIAP.Enabled = true;
			this.IDC_GB_TAGIAP.Enabled = true;
			this.IDC_GB_FEIMIIAP.Enabled = true;
		}

		private void EnableItems()
		{
			this.IDC_GB_BLE.Enabled = true;
			this.IDC_TC_ITEM.Enabled = true;
		}

		private void EnableSerialItems()
		{
			this.IDC_GB_SERIAL.Enabled = true;
		}

		private bool GetMacAddress(ref string str_MacAddress)
		{
			bool flag;
			try
			{
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				int num = 0;
				while (num < (int)allNetworkInterfaces.Length)
				{
					string str = allNetworkInterfaces[num].GetPhysicalAddress().ToString();
					if (string.IsNullOrEmpty(str))
					{
						num++;
					}
					else
					{
						str_MacAddress = str;
						break;
					}
				}
				flag = true;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		private void IAP_Form_DragDrop(object sender, DragEventArgs e)
		{
			string str = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
			byte[] numArray = File.ReadAllBytes(str);
			if ((long)((int)numArray.Length) > (long)385024)
			{
				MessageBox.Show("Bin File size out of range!");
				return;
			}
			int num = 0;
			for (int i = 0; i < (int)numArray.Length; i++)
			{
				num += numArray[i];
			}
			num = ~num;
			object[] length = new object[] { str, " ", (int)numArray.Length, "Bytes Opened.\r\nCRC:", num, "\r\n" };
			string str1 = string.Concat(length);
			this.IDC_EDIT_INFO.AppendText(str1);
		}

		private void IAP_Form_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		private void IAP_Form_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Serialport_Used.Close();
			Environment.Exit(0);
			Application.Exit();
		}

		private void IDC_BTN_ACT_Click(object sender, EventArgs e)
		{
			byte[] numArray = new byte[10];
			uint mSCmdMap = 0;
			DateTime now = new DateTime();
			now = DateTime.Now;
			mSCmdMap = (uint)((this.m_s_CmdMap[NinebotCmd.NB_CPUID_A] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_B] & 65535) << 16) + (this.m_s_CmdMap[NinebotCmd.NB_CPUID_C] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_D] & 65535) << 16) + (this.m_s_CmdMap[NinebotCmd.NB_CPUID_E] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_F] & 65535) << 16));
			mSCmdMap = ~mSCmdMap;
			if (this.IDC_COMBO_CAR.Text == "Mijia Pro")
			{
				mSCmdMap += 191;
			}
			byte[] bytes = BitConverter.GetBytes(mSCmdMap);
			for (int i = 0; i < 4; i++)
			{
				numArray[i] = bytes[i];
			}
			mSCmdMap = (uint)(((this.m_s_CmdMap[NinebotCmd.NB_CPUID_A] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_B] & 65535) << 16)) * ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_C] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_D] & 65535) << 16)) * ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_E] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_F] & 65535) << 16)));
			mSCmdMap = ~mSCmdMap;
			if (this.IDC_COMBO_CAR.Text == "Mijia Pro")
			{
				mSCmdMap += 191;
			}
			bytes = BitConverter.GetBytes(mSCmdMap);
			for (int j = 0; j < 4; j++)
			{
				numArray[4 + j] = bytes[j];
			}
			mSCmdMap = (uint)(now.Year - 2000 << 9 | (now.Month & 15) << 5 | now.Day & 31);
			bytes = BitConverter.GetBytes(mSCmdMap);
			for (int k = 0; k < 2; k++)
			{
				numArray[8 + k] = bytes[k];
			}
			this.PushFrame(this.m_DriverID, 10, CmdDefine.CMD_MINI_ACTALL, 0, ref numArray);
			this.m_bol_Acting = true;
		}

		private void IDC_BTN_AUTH_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_PASSWORD.Text == "scooterhacking.org")
			{
				this.IDC_BTN_AUTH.Text = "Authorize";
				this.SaveConfigData();
				this.EnableSerialItems();
				return;
			}
			this.IDC_BTN_AUTH.Text = "Authorization";
			this.DisableSerialItems();
			MessageBox.Show("Authorization code is incorrect");
		}

		private void IDC_BTN_DNLANCHORFILE_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_ANCHORFILE.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 6;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLBLEFILE_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_BLEFILE.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 4;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLBMSFILE_1_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_BMSFILE_1.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 1;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLBMSFILE_2_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_BMSFILE_2.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 2;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLBMSFILE_3_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_BMSFILE_3.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 3;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLDRIVERFILE_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_DRIVERFILE.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 0;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLFEIMIFILE_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_FEIMIFILE.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 8;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLTAGFILE_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_TAGFILE.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 7;
			this.DownloadFile();
		}

		private void IDC_BTN_DNLUPCFILE_Click(object sender, EventArgs e)
		{
			if (this.IDC_EDIT_UPCFILE.TextLength == 0)
			{
				MessageBox.Show("Please select firmware！");
				return;
			}
			this.m_b_IAPObject = 5;
			this.DownloadFile();
		}

		private void IDC_BTN_LOCK_Click(object sender, EventArgs e)
		{
			byte[] numArray = new byte[] { 1, 0 };
			this.PushFrame(this.m_DriverID, 2, CmdDefine.CMD_WR, NinebotCmd.NB_CTL_LOCK, ref numArray);
		}

		private void IDC_BTN_SELANCHORFILE_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 6;
			this.SelectFile();
		}

		private void IDC_BTN_SELBLEFILE_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 4;
			this.SelectFile();
		}

		private void IDC_BTN_SELBMSFILE_1_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 1;
			this.SelectFile();
		}

		private void IDC_BTN_SELBMSFILE_2_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 2;
			this.SelectFile();
		}

		private void IDC_BTN_SELBMSFILE_3_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 3;
			this.SelectFile();
		}

		private void IDC_BTN_SELDRIVERFILE_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 0;
			this.SelectFile();
		}

		private void IDC_BTN_SELFEIMIFILE_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 8;
			this.SelectFile();
		}

		private void IDC_BTN_SELTAGFILE_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 7;
			this.SelectFile();
		}

		private void IDC_BTN_SELUPCFILE_Click(object sender, EventArgs e)
		{
			this.m_b_IAPObject = 5;
			this.SelectFile();
		}

		private void IDC_BTN_UNACT_Click(object sender, EventArgs e)
		{
			byte[] numArray = new byte[8];
			uint mSCmdMap = 0;
			DateTime now = DateTime.Now;
			mSCmdMap = (uint)((this.m_s_CmdMap[NinebotCmd.NB_CPUID_A] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_B] & 65535) << 16) + (this.m_s_CmdMap[NinebotCmd.NB_CPUID_C] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_D] & 65535) << 16) + (this.m_s_CmdMap[NinebotCmd.NB_CPUID_E] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_F] & 65535) << 16));
			mSCmdMap = ~mSCmdMap;
			if (this.IDC_COMBO_CAR.Text == "Mijia Pro")
			{
				mSCmdMap += 191;
			}
			byte[] bytes = BitConverter.GetBytes(mSCmdMap);
			for (int i = 0; i < 4; i++)
			{
				numArray[i] = bytes[i];
			}
			mSCmdMap = (uint)(((this.m_s_CmdMap[NinebotCmd.NB_CPUID_A] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_B] & 65535) << 16)) * ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_C] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_D] & 65535) << 16)) * ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_E] & 65535) + ((this.m_s_CmdMap[NinebotCmd.NB_CPUID_F] & 65535) << 16)));
			mSCmdMap = ~mSCmdMap;
			if (this.IDC_COMBO_CAR.Text == "Mijia Pro")
			{
				mSCmdMap += 191;
			}
			bytes = BitConverter.GetBytes(mSCmdMap);
			for (int j = 0; j < 4; j++)
			{
				numArray[4 + j] = bytes[j];
			}
			this.PushFrame(this.m_DriverID, 8, CmdDefine.CMD_MINI_UNACT, 0, ref numArray);
			this.m_bol_UnActing = true;
		}

		private void IDC_BTN_UNLOCK_Click(object sender, EventArgs e)
		{
			byte[] numArray = new byte[] { 1, 0 };
			this.PushFrame(this.m_DriverID, 2, CmdDefine.CMD_WR, NinebotCmd.NB_CTL_UNLOCK, ref numArray);
		}

		private void IDC_COMBO_CAR_TextChanged(object sender, EventArgs e)
		{
			this.SaveConfigData();
			if (this.IDC_COMBO_CAR.Text == "Plus")
			{
				this.Enable_IAPItems();
				this.IDC_GB_BMS2IAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_Plus_ID;
				this.m_BMSID_1 = CmdDefine.V_Plus_BMS_ID;
				this.m_BLEID = CmdDefine.V_Plus_DIS_ID;
				this.m_UPCID = CmdDefine.V_UPC_ID;
				this.m_ANCID = CmdDefine.V_ANC_ID;
				this.m_TAGID = CmdDefine.V_TAG_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 3;
				this.m_COM_INDEX = 4;
				this.m_COM_DATA = 5;
				this.m_COM_TYPE = 2;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "Kart")
			{
				this.Enable_IAPItems();
				this.IDC_GB_BMS1IAP.Enabled = false;
				this.IDC_GB_BMS2IAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.IDC_GB_BLEIAP.Enabled = false;
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_KART_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 3;
				this.m_COM_INDEX = 4;
				this.m_COM_DATA = 5;
				this.m_COM_TYPE = 2;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "Kickscooter")
			{
				this.Enable_IAPItems();
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_SCOOTER_ID;
				this.m_BMSID_1 = CmdDefine.V_SCOOTER_BMS_ID1;
				this.m_BMSID_2 = CmdDefine.V_SCOOTER_BMS_ID2;
				this.m_BLEID = CmdDefine.V_SCOOTER_DIS_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 3;
				this.m_COM_INDEX = 4;
				this.m_COM_DATA = 5;
				this.m_COM_TYPE = 2;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "Lite")
			{
				this.Enable_IAPItems();
				this.IDC_GB_BMS2IAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_Nano_ID;
				this.m_BMSID_1 = CmdDefine.V_Nano_BMS_ID;
				this.m_BLEID = CmdDefine.V_Nano_DIS_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 3;
				this.m_COM_INDEX = 4;
				this.m_COM_DATA = 5;
				this.m_COM_TYPE = 2;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "MK3")
			{
				this.Enable_IAPItems();
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_MK3_ID;
				this.m_BMSID_1 = CmdDefine.V_MK3_BMS_ID1;
				this.m_BMSID_2 = CmdDefine.V_MK3_BMS_ID2;
				this.m_BLEID = CmdDefine.V_MK3_DIS_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 3;
				this.m_COM_INDEX = 4;
				this.m_COM_DATA = 5;
				this.m_COM_TYPE = 2;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "Steeldust")
			{
				this.Enable_IAPItems();
				this.IDC_GB_BLEIAP.Enabled = false;
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_STEELDUST_ECU_ID;
				this.m_BMSID_1 = CmdDefine.V_STEELDUST_BMS1_ID;
				this.m_BMSID_2 = CmdDefine.V_STEELDUST_BMS2_ID;
				this.m_BMSID_3 = CmdDefine.V_STEELDUST_BMS3_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 3;
				this.m_COM_INDEX = 4;
				this.m_COM_DATA = 5;
				this.m_COM_TYPE = 2;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "mini")
			{
				this.Enable_IAPItems();
				this.IDC_GB_BMS2IAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_MINI_ID;
				this.m_BMSID_1 = CmdDefine.V_MINI_BMS_ID;
				this.m_BLEID = CmdDefine.V_MINI_DIS_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 2;
				this.m_COM_INDEX = 3;
				this.m_COM_DATA = 4;
				this.m_COM_TYPE = 1;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "Mijia Pro" || this.IDC_COMBO_CAR.Text == "Home meter skateboard")
			{
				this.Enable_IAPItems();
				this.IDC_GB_BMS2IAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_ESC_ID;
				this.m_BMSID_1 = CmdDefine.V_ESC_BMS_ID;
				this.m_BLEID = CmdDefine.V_ESC_DIS_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 2;
				this.m_COM_INDEX = 3;
				this.m_COM_DATA = 4;
				this.m_COM_TYPE = 1;
				return;
			}
			if (this.IDC_COMBO_CAR.Text == "MK2")
			{
				this.Enable_IAPItems();
				this.IDC_GB_UPCIAP.Enabled = false;
				this.IDC_GB_ANCIAP.Enabled = false;
				this.IDC_GB_TAGIAP.Enabled = false;
				this.IDC_GB_FEIMIIAP.Enabled = false;
				this.IDC_GB_BMS3IAP.Enabled = false;
				this.m_DriverID = CmdDefine.V_MK2_ID;
				this.m_BMSID_1 = CmdDefine.V_MK2_BMS1_ID;
				this.m_BMSID_2 = CmdDefine.V_MK2_BMS2_ID;
				this.m_BLEID = CmdDefine.V_MK2_DIS_ID;
				this.m_COM_LEN = 0;
				this.m_COM_ID = 1;
				this.m_COM_CMD = 2;
				this.m_COM_INDEX = 3;
				this.m_COM_DATA = 4;
				this.m_COM_TYPE = 1;
			}
		}

		private void IDC_COMBO_COM_Click(object sender, EventArgs e)
		{
			this.Serialport_Init();
		}

		private void IDC_RB_CheckedChanged(object sender, EventArgs e)
		{
			if (this.IDC_RB_PC.Checked)
			{
				this.m_b_BufTxLen = 128;
				this.m_MyID = CmdDefine.V_PC_ID;
				this.IDC_LABEL_CONNMODE.Text = "Link type:PC";
				return;
			}
			if (this.IDC_RB_BLE.Checked)
			{
				this.m_b_BufTxLen = 128;
				this.m_MyID = CmdDefine.V_BLE_ID;
				this.IDC_LABEL_CONNMODE.Text = "Link type:BLE";
				return;
			}
			if (this.IDC_RB_CAN.Checked)
			{
				this.m_b_BufTxLen = 8;
				this.m_MyID = CmdDefine.V_CAN_ID;
				this.IDC_LABEL_CONNMODE.Text = "Link type:CAN";
			}
		}

		private void InitConfigData()
		{
			try
			{
				File.Open("Config_NCIAP.inf", FileMode.Append).Close();
				string str = File.ReadAllText("Config_NCIAP.inf");
				if (str != "")
				{
					str = str.Remove(0, str.IndexOf(':') + 1);
					this.IDC_EDIT_PASSWORD.Text = str.Substring(0, str.IndexOf('\r'));
					str = str.Remove(0, str.IndexOf(':') + 1);
					this.IDC_COMBO_CAR.SelectedIndex = int.Parse(str.Substring(0, str.IndexOf('\r')));
				}
			}
			catch
			{
				this.SaveConfigData();
				this.InitConfigData();
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(IAP_Form));
			this.Serialport_Used = new SerialPort(this.components);
			this.IDC_COMBO_COM = new ComboBox();
			this.IDC_BTN_OPENCOM = new Button();
			this.IDC_STATIC_ICON = new PictureBox();
			this.IDC_BTN_BLESWAN = new Button();
			this.IDC_LIST_BLELIST = new ListBox();
			this.Timer_SendData = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new GroupBox();
			this.IDC_BTN_AUTH = new Button();
			this.IDC_EDIT_PASSWORD = new TextBox();
			this.label3 = new Label();
			this.IDC_BTN_LOCK = new Button();
			this.IDC_GB_SERIAL = new GroupBox();
			this.IDC_RB_CAN = new RadioButton();
			this.IDC_RB_BLE = new RadioButton();
			this.IDC_RB_PC = new RadioButton();
			this.IDC_LABEL_CONNMODE = new Label();
			this.IDC_COMBO_CAR = new ComboBox();
			this.label1 = new Label();
			this.IDC_LABEL_COUNT = new Label();
			this.IDC_COMBO_BAUDRATE = new ComboBox();
			this.IDC_GB_BLE = new GroupBox();
			this.IDC_LABEL_BLECONNECTSTATUE = new Label();
			this.IDC_BTN_UNACT = new Button();
			this.IDC_BTN_ACT = new Button();
			this.IDC_BTN_UNLOCK = new Button();
			this.groupBox4 = new GroupBox();
			this.IDC_LABEL_FEIMIVER = new Label();
			this.IDC_LABEL_TAGVER = new Label();
			this.IDC_LABEL_ANCVER = new Label();
			this.IDC_LABEL_UPCVER = new Label();
			this.IDC_LABEL_BLEVER = new Label();
			this.label24 = new Label();
			this.IDC_LABEL_DRIVERVER = new Label();
			this.label13 = new Label();
			this.label11 = new Label();
			this.label2 = new Label();
			this.label8 = new Label();
			this.IDC_LABEL_BMSVER_3 = new Label();
			this.label4 = new Label();
			this.IDC_LABEL_BMSVER_2 = new Label();
			this.IDC_LABEL_BMSVER_1 = new Label();
			this.label6 = new Label();
			this.label30 = new Label();
			this.label15 = new Label();
			this.Timer_FreshData = new System.Windows.Forms.Timer(this.components);
			this.IDC_PROGRESSBAR = new ProgressBar();
			this.IDC_EDIT_INFO = new TextBox();
			this.groupBox5 = new GroupBox();
			this.label17 = new Label();
			this.label28 = new Label();
			this.IDC_LABEL_FEIMIVER_SEL = new Label();
			this.IDC_LABEL_DRIVERVER_SEL = new Label();
			this.IDC_LABEL_TAGVER_SEL = new Label();
			this.IDC_LABEL_ANCVER_SEL = new Label();
			this.IDC_LABEL_UPCVER_SEL = new Label();
			this.IDC_LABEL_BLEVER_SEL = new Label();
			this.label5 = new Label();
			this.label27 = new Label();
			this.label16 = new Label();
			this.label14 = new Label();
			this.label10 = new Label();
			this.label9 = new Label();
			this.IDC_LABEL_BMSVER_SEL_3 = new Label();
			this.IDC_LABEL_BMSVER_SEL_2 = new Label();
			this.IDC_LABEL_BMSVER_SEL_1 = new Label();
			this.label7 = new Label();
			this.IDC_GB_DRIVERIAP = new GroupBox();
			this.IDC_BTN_DNLDRIVERFILE = new Button();
			this.IDC_BTN_SELDRIVERFILE = new Button();
			this.IDC_EDIT_DRIVERFILE = new TextBox();
			this.IDC_GB_BMS1IAP = new GroupBox();
			this.IDC_BTN_SELBMSFILE_1 = new Button();
			this.IDC_EDIT_BMSFILE_1 = new TextBox();
			this.IDC_BTN_DNLBMSFILE_1 = new Button();
			this.IDC_GB_BLEIAP = new GroupBox();
			this.IDC_BTN_SELBLEFILE = new Button();
			this.IDC_EDIT_BLEFILE = new TextBox();
			this.IDC_BTN_DNLBLEFILE = new Button();
			this.IDC_GB_UPCIAP = new GroupBox();
			this.IDC_BTN_SELUPCFILE = new Button();
			this.IDC_EDIT_UPCFILE = new TextBox();
			this.IDC_BTN_DNLUPCFILE = new Button();
			this.IDC_GB_ANCIAP = new GroupBox();
			this.IDC_BTN_SELANCHORFILE = new Button();
			this.IDC_BTN_DNLANCHORFILE = new Button();
			this.IDC_EDIT_ANCHORFILE = new TextBox();
			this.IDC_GB_TAGIAP = new GroupBox();
			this.IDC_BTN_DNLTAGFILE = new Button();
			this.IDC_BTN_SELTAGFILE = new Button();
			this.IDC_EDIT_TAGFILE = new TextBox();
			this.IDC_TC_ITEM = new TabControl();
			this.tabPage1 = new TabPage();
			this.IDC_GB_BMS3IAP = new GroupBox();
			this.IDC_BTN_SELBMSFILE_3 = new Button();
			this.IDC_EDIT_BMSFILE_3 = new TextBox();
			this.IDC_BTN_DNLBMSFILE_3 = new Button();
			this.IDC_GB_BMS2IAP = new GroupBox();
			this.IDC_BTN_SELBMSFILE_2 = new Button();
			this.IDC_EDIT_BMSFILE_2 = new TextBox();
			this.IDC_BTN_DNLBMSFILE_2 = new Button();
			this.IDC_GB_FEIMIIAP = new GroupBox();
			this.IDC_BTN_DNLFEIMIFILE = new Button();
			this.IDC_BTN_SELFEIMIFILE = new Button();
			this.IDC_EDIT_FEIMIFILE = new TextBox();
			this.Timer_Update_SN_ACT = new System.Windows.Forms.Timer(this.components);
			this.Timer_IAP = new System.Windows.Forms.Timer(this.components);
			this.Timer_BLEConnect = new System.Windows.Forms.Timer(this.components);
			this.Timer_BLEScan = new System.Windows.Forms.Timer(this.components);
			((ISupportInitialize)this.IDC_STATIC_ICON).BeginInit();
			this.groupBox1.SuspendLayout();
			this.IDC_GB_SERIAL.SuspendLayout();
			this.IDC_GB_BLE.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.IDC_GB_DRIVERIAP.SuspendLayout();
			this.IDC_GB_BMS1IAP.SuspendLayout();
			this.IDC_GB_BLEIAP.SuspendLayout();
			this.IDC_GB_UPCIAP.SuspendLayout();
			this.IDC_GB_ANCIAP.SuspendLayout();
			this.IDC_GB_TAGIAP.SuspendLayout();
			this.IDC_TC_ITEM.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.IDC_GB_BMS3IAP.SuspendLayout();
			this.IDC_GB_BMS2IAP.SuspendLayout();
			this.IDC_GB_FEIMIIAP.SuspendLayout();
			base.SuspendLayout();
			this.Serialport_Used.BaudRate = 115200;
			this.Serialport_Used.DataReceived += new SerialDataReceivedEventHandler(this.m_SerialPort_DataReceived);
			this.IDC_COMBO_COM.DropDownStyle = ComboBoxStyle.DropDownList;
			this.IDC_COMBO_COM.FormattingEnabled = true;
			this.IDC_COMBO_COM.Location = new Point(6, 20);
			this.IDC_COMBO_COM.Name = "IDC_COMBO_COM";
			this.IDC_COMBO_COM.Size = new System.Drawing.Size(65, 20);
			this.IDC_COMBO_COM.TabIndex = 4;
			this.IDC_COMBO_COM.Click += new EventHandler(this.IDC_COMBO_COM_Click);
			this.IDC_BTN_OPENCOM.Location = new Point(152, 19);
			this.IDC_BTN_OPENCOM.Name = "IDC_BTN_OPENCOM";
			this.IDC_BTN_OPENCOM.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_OPENCOM.TabIndex = 5;
			this.IDC_BTN_OPENCOM.Text = "Open";
			this.IDC_BTN_OPENCOM.UseVisualStyleBackColor = true;
			this.IDC_BTN_OPENCOM.Click += new EventHandler(this.Serial_Open_Click);
			this.IDC_STATIC_ICON.BackColor = Color.Black;
			this.IDC_STATIC_ICON.BorderStyle = BorderStyle.Fixed3D;
			this.IDC_STATIC_ICON.Location = new Point(223, 20);
			this.IDC_STATIC_ICON.Name = "IDC_STATIC_ICON";
			this.IDC_STATIC_ICON.Size = new System.Drawing.Size(22, 20);
			this.IDC_STATIC_ICON.TabIndex = 6;
			this.IDC_STATIC_ICON.TabStop = true; //false;
			this.IDC_BTN_BLESWAN.Location = new Point(6, 20);
			this.IDC_BTN_BLESWAN.Name = "IDC_BTN_BLESWAN";
			this.IDC_BTN_BLESWAN.Size = new System.Drawing.Size(113, 47);
			this.IDC_BTN_BLESWAN.TabIndex = 7;
			this.IDC_BTN_BLESWAN.Text = "Scan Bluetooth";
			this.IDC_BTN_BLESWAN.UseVisualStyleBackColor = true;
			this.IDC_BTN_BLESWAN.Click += new EventHandler(this.BLE_Swan_Click);
			this.IDC_LIST_BLELIST.FormattingEnabled = true;
			this.IDC_LIST_BLELIST.ItemHeight = 12;
			this.IDC_LIST_BLELIST.Location = new Point(125, 44);
			this.IDC_LIST_BLELIST.Name = "IDC_LIST_BLELIST";
			this.IDC_LIST_BLELIST.Size = new System.Drawing.Size(119, 76);
			this.IDC_LIST_BLELIST.TabIndex = 8;
			this.IDC_LIST_BLELIST.DoubleClick += new EventHandler(this.BLE_List_DoubleClick);
			this.Timer_SendData.Interval = 50;
			this.Timer_SendData.Tick += new EventHandler(this.Timer_SendData_Tick);
			this.groupBox1.Controls.Add(this.IDC_BTN_AUTH);
			this.groupBox1.Controls.Add(this.IDC_EDIT_PASSWORD);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(252, 52);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = true; //false;
            this.groupBox1.Text = "Authorization settings";
			this.groupBox1.Visible = true; //false;
            this.IDC_BTN_AUTH.Location = new Point(152, 20);
			this.IDC_BTN_AUTH.Name = "IDC_BTN_AUTH";
			this.IDC_BTN_AUTH.Size = new System.Drawing.Size(79, 21);
			this.IDC_BTN_AUTH.TabIndex = 2;
			this.IDC_BTN_AUTH.Text = "Authorize";
			this.IDC_BTN_AUTH.UseVisualStyleBackColor = true;
			this.IDC_BTN_AUTH.Click += new EventHandler(this.IDC_BTN_AUTH_Click);
			this.IDC_EDIT_PASSWORD.Location = new Point(79, 20);
			this.IDC_EDIT_PASSWORD.Name = "IDC_EDIT_PASSWORD";
			this.IDC_EDIT_PASSWORD.Size = new System.Drawing.Size(65, 21);
			this.IDC_EDIT_PASSWORD.TabIndex = 1;
			this.IDC_EDIT_PASSWORD.TextAlign = HorizontalAlignment.Center;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(6, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "Insert code";
			this.IDC_BTN_LOCK.Location = new Point(6, 73);
			this.IDC_BTN_LOCK.Name = "IDC_BTN_LOCK";
			this.IDC_BTN_LOCK.Size = new System.Drawing.Size(50, 21);
			this.IDC_BTN_LOCK.TabIndex = 3;
			this.IDC_BTN_LOCK.Text = "Lock car";
			this.IDC_BTN_LOCK.UseVisualStyleBackColor = true;
			this.IDC_BTN_LOCK.Click += new EventHandler(this.IDC_BTN_LOCK_Click);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_RB_CAN);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_RB_BLE);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_RB_PC);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_LABEL_CONNMODE);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_COMBO_CAR);
			this.IDC_GB_SERIAL.Controls.Add(this.label1);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_LABEL_COUNT);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_COMBO_BAUDRATE);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_COMBO_COM);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_BTN_OPENCOM);
			this.IDC_GB_SERIAL.Controls.Add(this.IDC_STATIC_ICON);
			this.IDC_GB_SERIAL.Enabled = true; //false;
            this.IDC_GB_SERIAL.Location = new Point(12, 71);
			this.IDC_GB_SERIAL.Name = "IDC_GB_SERIAL";
			this.IDC_GB_SERIAL.Size = new System.Drawing.Size(252, 95);
			this.IDC_GB_SERIAL.TabIndex = 11;
			this.IDC_GB_SERIAL.TabStop = true; //false;
			this.IDC_GB_SERIAL.Text = "Serialport";
			this.IDC_RB_CAN.AutoSize = true;
			this.IDC_RB_CAN.Location = new Point(172, 68);
			this.IDC_RB_CAN.Name = "IDC_RB_CAN";
			this.IDC_RB_CAN.Size = new System.Drawing.Size(41, 16);
			this.IDC_RB_CAN.TabIndex = 11;
			this.IDC_RB_CAN.Text = "CAN";
			this.IDC_RB_CAN.UseVisualStyleBackColor = true;
			this.IDC_RB_CAN.Visible = true; //false;
			this.IDC_RB_CAN.CheckedChanged += new EventHandler(this.IDC_RB_CheckedChanged);
			this.IDC_RB_BLE.AutoSize = true;
			this.IDC_RB_BLE.Location = new Point(127, 68);
			this.IDC_RB_BLE.Name = "IDC_RB_BLE";
			this.IDC_RB_BLE.Size = new System.Drawing.Size(41, 16);
			this.IDC_RB_BLE.TabIndex = 11;
			this.IDC_RB_BLE.Text = "BLE";
			this.IDC_RB_BLE.UseVisualStyleBackColor = true;
			this.IDC_RB_BLE.Visible = true; //false;
			this.IDC_RB_BLE.CheckedChanged += new EventHandler(this.IDC_RB_CheckedChanged);
			this.IDC_RB_PC.AutoSize = true;
			this.IDC_RB_PC.Checked = true;
			this.IDC_RB_PC.Location = new Point(88, 68);
			this.IDC_RB_PC.Name = "IDC_RB_PC";
			this.IDC_RB_PC.Size = new System.Drawing.Size(35, 16);
			this.IDC_RB_PC.TabIndex = 11;
			this.IDC_RB_PC.TabStop = true;
			this.IDC_RB_PC.Text = "PC";
			this.IDC_RB_PC.UseVisualStyleBackColor = true;
			this.IDC_RB_PC.Visible = true; //false;
			this.IDC_RB_PC.CheckedChanged += new EventHandler(this.IDC_RB_CheckedChanged);
			this.IDC_LABEL_CONNMODE.AutoSize = true;
			this.IDC_LABEL_CONNMODE.Location = new Point(6, 70);
			this.IDC_LABEL_CONNMODE.Name = "IDC_LABEL_CONNMODE";
			this.IDC_LABEL_CONNMODE.Size = new System.Drawing.Size(77, 12);
			this.IDC_LABEL_CONNMODE.TabIndex = 10;
			this.IDC_LABEL_CONNMODE.Text = "Link type:BLE";
			this.IDC_LABEL_CONNMODE.Visible = true; //false;
			this.IDC_COMBO_CAR.DropDownStyle = ComboBoxStyle.DropDownList;
			this.IDC_COMBO_CAR.FormattingEnabled = true;
			this.IDC_COMBO_CAR.Items.AddRange(new object[] { "Kickscooter" });
			this.IDC_COMBO_CAR.Location = new Point(6, 43);
			this.IDC_COMBO_CAR.Name = "IDC_COMBO_CAR";
			this.IDC_COMBO_CAR.Size = new System.Drawing.Size(79, 25);
			this.IDC_COMBO_CAR.TabIndex = 9;
			this.IDC_COMBO_CAR.TextChanged += new EventHandler(this.IDC_COMBO_CAR_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(94, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = "Count";
			this.IDC_LABEL_COUNT.Location = new Point(158, 47);
			this.IDC_LABEL_COUNT.Name = "IDC_LABEL_COUNT";
			this.IDC_LABEL_COUNT.Size = new System.Drawing.Size(53, 12);
			this.IDC_LABEL_COUNT.TabIndex = 2;
			this.IDC_LABEL_COUNT.Text = "00000000";
			this.IDC_LABEL_COUNT.TextAlign = ContentAlignment.MiddleCenter;
			this.IDC_COMBO_BAUDRATE.DropDownStyle = ComboBoxStyle.DropDownList;
			this.IDC_COMBO_BAUDRATE.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.IDC_COMBO_BAUDRATE.Items;
			object[] objArray = new object[] { "9600", "19200", "38400", "115200", "500000", "1000000" };
			items.AddRange(objArray);
			this.IDC_COMBO_BAUDRATE.Location = new Point(79, 20);
			this.IDC_COMBO_BAUDRATE.Name = "IDC_COMBO_BAUDRATE";
			this.IDC_COMBO_BAUDRATE.Size = new System.Drawing.Size(65, 20);
			this.IDC_COMBO_BAUDRATE.TabIndex = 7;
			this.IDC_GB_BLE.Controls.Add(this.IDC_LABEL_BLECONNECTSTATUE);
			this.IDC_GB_BLE.Controls.Add(this.IDC_BTN_UNACT);
			this.IDC_GB_BLE.Controls.Add(this.IDC_BTN_ACT);
			this.IDC_GB_BLE.Controls.Add(this.IDC_LIST_BLELIST);
			this.IDC_GB_BLE.Controls.Add(this.IDC_BTN_UNLOCK);
			this.IDC_GB_BLE.Controls.Add(this.IDC_BTN_LOCK);
			this.IDC_GB_BLE.Controls.Add(this.IDC_BTN_BLESWAN);
			this.IDC_GB_BLE.Enabled = true; //false;
            this.IDC_GB_BLE.Location = new Point(13, 172);
			this.IDC_GB_BLE.Name = "IDC_GB_BLE";
			this.IDC_GB_BLE.Size = new System.Drawing.Size(252, 128);
			this.IDC_GB_BLE.TabIndex = 12;
			this.IDC_GB_BLE.TabStop = true; //false;
            this.IDC_GB_BLE.Text = "Bluetooth settings";
			this.IDC_GB_BLE.Visible = true; //false;
            this.IDC_LABEL_BLECONNECTSTATUE.Location = new Point(142, 20);
			this.IDC_LABEL_BLECONNECTSTATUE.Name = "IDC_LABEL_BLECONNECTSTATUE";
			this.IDC_LABEL_BLECONNECTSTATUE.Size = new System.Drawing.Size(85, 15);
			this.IDC_LABEL_BLECONNECTSTATUE.TabIndex = 11;
			this.IDC_LABEL_BLECONNECTSTATUE.Text = "Bluetooth is not connected";
			this.IDC_LABEL_BLECONNECTSTATUE.TextAlign = ContentAlignment.MiddleCenter;
			this.IDC_BTN_UNACT.Location = new Point(69, 99);
			this.IDC_BTN_UNACT.Name = "IDC_BTN_UNACT";
			this.IDC_BTN_UNACT.Size = new System.Drawing.Size(50, 21);
			this.IDC_BTN_UNACT.TabIndex = 10;
			this.IDC_BTN_UNACT.Text = "Default";
			this.IDC_BTN_UNACT.UseVisualStyleBackColor = true;
			this.IDC_BTN_UNACT.Click += new EventHandler(this.IDC_BTN_UNACT_Click);
			this.IDC_BTN_ACT.Location = new Point(69, 73);
			this.IDC_BTN_ACT.Name = "IDC_BTN_ACT";
			this.IDC_BTN_ACT.Size = new System.Drawing.Size(56, 21);
			this.IDC_BTN_ACT.TabIndex = 10;
			this.IDC_BTN_ACT.Text = "Activate";
			this.IDC_BTN_ACT.UseVisualStyleBackColor = true;
			this.IDC_BTN_ACT.Click += new EventHandler(this.IDC_BTN_ACT_Click);
			this.IDC_BTN_UNLOCK.Location = new Point(6, 99);
			this.IDC_BTN_UNLOCK.Name = "IDC_BTN_UNLOCK";
			this.IDC_BTN_UNLOCK.Size = new System.Drawing.Size(50, 21);
			this.IDC_BTN_UNLOCK.TabIndex = 10;
			this.IDC_BTN_UNLOCK.Text = "Unlock";
			this.IDC_BTN_UNLOCK.UseVisualStyleBackColor = true;
			this.IDC_BTN_UNLOCK.Click += new EventHandler(this.IDC_BTN_UNLOCK_Click);
			this.groupBox4.Controls.Add(this.IDC_LABEL_FEIMIVER);
			this.groupBox4.Controls.Add(this.IDC_LABEL_TAGVER);
			this.groupBox4.Controls.Add(this.IDC_LABEL_ANCVER);
			this.groupBox4.Controls.Add(this.IDC_LABEL_UPCVER);
			this.groupBox4.Controls.Add(this.IDC_LABEL_BLEVER);
			this.groupBox4.Controls.Add(this.label24);
			this.groupBox4.Controls.Add(this.IDC_LABEL_DRIVERVER);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.IDC_LABEL_BMSVER_3);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.IDC_LABEL_BMSVER_2);
			this.groupBox4.Controls.Add(this.IDC_LABEL_BMSVER_1);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label30);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Location = new Point(6, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(646, 51);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = true; //false;
            this.groupBox4.Text = "Framework Version";
			this.IDC_LABEL_FEIMIVER.AutoSize = true;
			this.IDC_LABEL_FEIMIVER.Location = new Point(594, 24);
			this.IDC_LABEL_FEIMIVER.Name = "IDC_LABEL_FEIMIVER";
			this.IDC_LABEL_FEIMIVER.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_FEIMIVER.TabIndex = 1;
			this.IDC_LABEL_FEIMIVER.Text = "V0.0.0";
			this.IDC_LABEL_FEIMIVER.Visible = true; //false;
            this.IDC_LABEL_TAGVER.AutoSize = true;
			this.IDC_LABEL_TAGVER.Location = new Point(508, 24);
			this.IDC_LABEL_TAGVER.Name = "IDC_LABEL_TAGVER";
			this.IDC_LABEL_TAGVER.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_TAGVER.TabIndex = 1;
			this.IDC_LABEL_TAGVER.Text = "V0.0.0";
			this.IDC_LABEL_TAGVER.Visible = true; //false;
            this.IDC_LABEL_ANCVER.AutoSize = true;
			this.IDC_LABEL_ANCVER.Location = new Point(433, 24);
			this.IDC_LABEL_ANCVER.Name = "IDC_LABEL_ANCVER";
			this.IDC_LABEL_ANCVER.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_ANCVER.TabIndex = 1;
			this.IDC_LABEL_ANCVER.Text = "V0.0.0";
			this.IDC_LABEL_ANCVER.Visible = true; //false;
            this.IDC_LABEL_UPCVER.AutoSize = true;
			this.IDC_LABEL_UPCVER.Location = new Point(358, 24);
			this.IDC_LABEL_UPCVER.Name = "IDC_LABEL_UPCVER";
			this.IDC_LABEL_UPCVER.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_UPCVER.TabIndex = 1;
			this.IDC_LABEL_UPCVER.Text = "V0.0.0";
			this.IDC_LABEL_UPCVER.Visible = true; //false;
            this.IDC_LABEL_BLEVER.AutoSize = true;
			this.IDC_LABEL_BLEVER.Location = new Point(283, 24);
			this.IDC_LABEL_BLEVER.Name = "IDC_LABEL_BLEVER";
			this.IDC_LABEL_BLEVER.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BLEVER.TabIndex = 1;
			this.IDC_LABEL_BLEVER.Text = "V0.0.0";
			this.label24.AutoSize = true;
			this.label24.Location = new Point(555, 24);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(47, 12);
			this.label24.TabIndex = 0;
			this.label24.Text = "FEIMI：";
			this.label24.Visible = true; //false;
            this.IDC_LABEL_DRIVERVER.AutoSize = true;
			this.IDC_LABEL_DRIVERVER.Location = new Point(49, 24);
			this.IDC_LABEL_DRIVERVER.Name = "IDC_LABEL_DRIVERVER";
			this.IDC_LABEL_DRIVERVER.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_DRIVERVER.TabIndex = 1;
			this.IDC_LABEL_DRIVERVER.Text = "V0.0.0";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(481, 24);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(35, 12);
			this.label13.TabIndex = 0;
			this.label13.Text = "TAG：";
			this.label13.Visible = true; //false;
            this.label11.AutoSize = true;
			this.label11.Location = new Point(406, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 12);
			this.label11.TabIndex = 0;
			this.label11.Text = "ANC：";
			this.label11.Visible = true; //false;
            this.label2.AutoSize = true;
			this.label2.Location = new Point(331, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "UPC：";
			this.label2.Visible = true; //false;
            this.label8.AutoSize = true;
			this.label8.Location = new Point(256, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 12);
			this.label8.TabIndex = 0;
			this.label8.Text = "BLE：";
			this.IDC_LABEL_BMSVER_3.AutoSize = true;
			this.IDC_LABEL_BMSVER_3.Location = new Point(209, 24);
			this.IDC_LABEL_BMSVER_3.Name = "IDC_LABEL_BMSVER_3";
			this.IDC_LABEL_BMSVER_3.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BMSVER_3.TabIndex = 1;
			this.IDC_LABEL_BMSVER_3.Text = "V0.0.0";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(7, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "Driver：";
			this.IDC_LABEL_BMSVER_2.AutoSize = true;
			this.IDC_LABEL_BMSVER_2.Location = new Point(162, 24);
			this.IDC_LABEL_BMSVER_2.Name = "IDC_LABEL_BMSVER_2";
			this.IDC_LABEL_BMSVER_2.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BMSVER_2.TabIndex = 1;
			this.IDC_LABEL_BMSVER_2.Text = "V0.0.0";
			this.IDC_LABEL_BMSVER_1.AutoSize = true;
			this.IDC_LABEL_BMSVER_1.Location = new Point(115, 24);
			this.IDC_LABEL_BMSVER_1.Name = "IDC_LABEL_BMSVER_1";
			this.IDC_LABEL_BMSVER_1.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BMSVER_1.TabIndex = 1;
			this.IDC_LABEL_BMSVER_1.Text = "V0.0.0";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(88, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 12);
			this.label6.TabIndex = 0;
			this.label6.Text = "BMS：";
			this.label30.AutoSize = true;
			this.label30.Location = new Point(154, 24);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(11, 12);
			this.label30.TabIndex = 2;
			this.label30.Text = "/";
			this.label15.AutoSize = true;
			this.label15.Location = new Point(201, 24);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(11, 12);
			this.label15.TabIndex = 2;
			this.label15.Text = "/";
			this.Timer_FreshData.Enabled = true;
			this.Timer_FreshData.Interval = 50;
			this.Timer_FreshData.Tick += new EventHandler(this.Timer_FreshData_Tick);
			this.IDC_PROGRESSBAR.Location = new Point(12, 305);
			this.IDC_PROGRESSBAR.Name = "IDC_PROGRESSBAR";
			this.IDC_PROGRESSBAR.Size = new System.Drawing.Size(251, 23);
			this.IDC_PROGRESSBAR.TabIndex = 14;
			this.IDC_EDIT_INFO.Location = new Point(12, 334);
			this.IDC_EDIT_INFO.Multiline = true;
			this.IDC_EDIT_INFO.Name = "IDC_EDIT_INFO";
			this.IDC_EDIT_INFO.Size = new System.Drawing.Size(252, 337);
			this.IDC_EDIT_INFO.TabIndex = 15;
			this.groupBox5.Controls.Add(this.label17);
			this.groupBox5.Controls.Add(this.label28);
			this.groupBox5.Controls.Add(this.IDC_LABEL_FEIMIVER_SEL);
			this.groupBox5.Controls.Add(this.IDC_LABEL_DRIVERVER_SEL);
			this.groupBox5.Controls.Add(this.IDC_LABEL_TAGVER_SEL);
			this.groupBox5.Controls.Add(this.IDC_LABEL_ANCVER_SEL);
			this.groupBox5.Controls.Add(this.IDC_LABEL_UPCVER_SEL);
			this.groupBox5.Controls.Add(this.IDC_LABEL_BLEVER_SEL);
			this.groupBox5.Controls.Add(this.label5);
			this.groupBox5.Controls.Add(this.label27);
			this.groupBox5.Controls.Add(this.label16);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.IDC_LABEL_BMSVER_SEL_3);
			this.groupBox5.Controls.Add(this.IDC_LABEL_BMSVER_SEL_2);
			this.groupBox5.Controls.Add(this.IDC_LABEL_BMSVER_SEL_1);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Location = new Point(6, 64);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(646, 51);
			this.groupBox5.TabIndex = 16;
			this.groupBox5.TabStop = true; //false;
            this.groupBox5.Text = "Selected Framework";
			this.label17.AutoSize = true;
			this.label17.Location = new Point(201, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(11, 12);
			this.label17.TabIndex = 2;
			this.label17.Text = "/";
			this.label28.AutoSize = true;
			this.label28.Location = new Point(154, 24);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(11, 12);
			this.label28.TabIndex = 2;
			this.label28.Text = "/";
			this.IDC_LABEL_FEIMIVER_SEL.AutoSize = true;
			this.IDC_LABEL_FEIMIVER_SEL.Location = new Point(594, 24);
			this.IDC_LABEL_FEIMIVER_SEL.Name = "IDC_LABEL_FEIMIVER_SEL";
			this.IDC_LABEL_FEIMIVER_SEL.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_FEIMIVER_SEL.TabIndex = 1;
			this.IDC_LABEL_FEIMIVER_SEL.Text = "V0.0.0";
			this.IDC_LABEL_FEIMIVER_SEL.Visible = true; //false;
            this.IDC_LABEL_DRIVERVER_SEL.AutoSize = true;
			this.IDC_LABEL_DRIVERVER_SEL.Location = new Point(49, 24);
			this.IDC_LABEL_DRIVERVER_SEL.Name = "IDC_LABEL_DRIVERVER_SEL";
			this.IDC_LABEL_DRIVERVER_SEL.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_DRIVERVER_SEL.TabIndex = 1;
			this.IDC_LABEL_DRIVERVER_SEL.Text = "V0.0.0";
			this.IDC_LABEL_TAGVER_SEL.AutoSize = true;
			this.IDC_LABEL_TAGVER_SEL.Location = new Point(508, 24);
			this.IDC_LABEL_TAGVER_SEL.Name = "IDC_LABEL_TAGVER_SEL";
			this.IDC_LABEL_TAGVER_SEL.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_TAGVER_SEL.TabIndex = 1;
			this.IDC_LABEL_TAGVER_SEL.Text = "V0.0.0";
			this.IDC_LABEL_TAGVER_SEL.Visible = true; //false;
            this.IDC_LABEL_ANCVER_SEL.AutoSize = true;
			this.IDC_LABEL_ANCVER_SEL.Location = new Point(433, 24);
			this.IDC_LABEL_ANCVER_SEL.Name = "IDC_LABEL_ANCVER_SEL";
			this.IDC_LABEL_ANCVER_SEL.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_ANCVER_SEL.TabIndex = 1;
			this.IDC_LABEL_ANCVER_SEL.Text = "V0.0.0";
			this.IDC_LABEL_ANCVER_SEL.Visible = true; //false;
            this.IDC_LABEL_UPCVER_SEL.AutoSize = true;
			this.IDC_LABEL_UPCVER_SEL.Location = new Point(358, 24);
			this.IDC_LABEL_UPCVER_SEL.Name = "IDC_LABEL_UPCVER_SEL";
			this.IDC_LABEL_UPCVER_SEL.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_UPCVER_SEL.TabIndex = 1;
			this.IDC_LABEL_UPCVER_SEL.Text = "V0.0.0";
			this.IDC_LABEL_UPCVER_SEL.Visible = true; //false;
            this.IDC_LABEL_BLEVER_SEL.AutoSize = true;
			this.IDC_LABEL_BLEVER_SEL.Location = new Point(283, 24);
			this.IDC_LABEL_BLEVER_SEL.Name = "IDC_LABEL_BLEVER_SEL";
			this.IDC_LABEL_BLEVER_SEL.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BLEVER_SEL.TabIndex = 1;
			this.IDC_LABEL_BLEVER_SEL.Text = "V0.0.0";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(7, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 0;
			this.label5.Text = "Driver：";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(555, 24);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(47, 12);
			this.label27.TabIndex = 0;
			this.label27.Text = "FEIMI：";
			this.label27.Visible = true; //false;
            this.label16.AutoSize = true;
			this.label16.Location = new Point(481, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 12);
			this.label16.TabIndex = 0;
			this.label16.Text = "TAG：";
			this.label16.Visible = true; //false;
            this.label14.AutoSize = true;
			this.label14.Location = new Point(406, 24);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(35, 12);
			this.label14.TabIndex = 0;
			this.label14.Text = "ANC：";
			this.label14.Visible = true; //false;
            this.label10.AutoSize = true;
			this.label10.Location = new Point(331, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 12);
			this.label10.TabIndex = 0;
			this.label10.Text = "UPC：";
			this.label10.Visible = true; //false;
            this.label9.AutoSize = true;
			this.label9.Location = new Point(256, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 12);
			this.label9.TabIndex = 0;
			this.label9.Text = "BLE：";
			this.IDC_LABEL_BMSVER_SEL_3.AutoSize = true;
			this.IDC_LABEL_BMSVER_SEL_3.Location = new Point(209, 24);
			this.IDC_LABEL_BMSVER_SEL_3.Name = "IDC_LABEL_BMSVER_SEL_3";
			this.IDC_LABEL_BMSVER_SEL_3.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BMSVER_SEL_3.TabIndex = 1;
			this.IDC_LABEL_BMSVER_SEL_3.Text = "V0.0.0";
			this.IDC_LABEL_BMSVER_SEL_2.AutoSize = true;
			this.IDC_LABEL_BMSVER_SEL_2.Location = new Point(162, 24);
			this.IDC_LABEL_BMSVER_SEL_2.Name = "IDC_LABEL_BMSVER_SEL_2";
			this.IDC_LABEL_BMSVER_SEL_2.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BMSVER_SEL_2.TabIndex = 1;
			this.IDC_LABEL_BMSVER_SEL_2.Text = "V0.0.0";
			this.IDC_LABEL_BMSVER_SEL_1.AutoSize = true;
			this.IDC_LABEL_BMSVER_SEL_1.Location = new Point(115, 24);
			this.IDC_LABEL_BMSVER_SEL_1.Name = "IDC_LABEL_BMSVER_SEL_1";
			this.IDC_LABEL_BMSVER_SEL_1.Size = new System.Drawing.Size(41, 12);
			this.IDC_LABEL_BMSVER_SEL_1.TabIndex = 1;
			this.IDC_LABEL_BMSVER_SEL_1.Text = "V0.0.0";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(88, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 12);
			this.label7.TabIndex = 0;
			this.label7.Text = "BMS：";
			this.IDC_GB_DRIVERIAP.Controls.Add(this.IDC_BTN_DNLDRIVERFILE);
			this.IDC_GB_DRIVERIAP.Controls.Add(this.IDC_BTN_SELDRIVERFILE);
			this.IDC_GB_DRIVERIAP.Controls.Add(this.IDC_EDIT_DRIVERFILE);
			this.IDC_GB_DRIVERIAP.Location = new Point(6, 122);
			this.IDC_GB_DRIVERIAP.Name = "IDC_GB_DRIVERIAP";
			this.IDC_GB_DRIVERIAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_DRIVERIAP.TabIndex = 17;
			this.IDC_GB_DRIVERIAP.TabStop = true; //false;
            this.IDC_GB_DRIVERIAP.Text = "Driver bin File";
			this.IDC_BTN_DNLDRIVERFILE.Location = new Point(575, 20);
			this.IDC_BTN_DNLDRIVERFILE.Name = "IDC_BTN_DNLDRIVERFILE";
			this.IDC_BTN_DNLDRIVERFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLDRIVERFILE.TabIndex = 2;
			this.IDC_BTN_DNLDRIVERFILE.Text = "Download";
			this.IDC_BTN_DNLDRIVERFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLDRIVERFILE.Click += new EventHandler(this.IDC_BTN_DNLDRIVERFILE_Click);
			this.IDC_BTN_SELDRIVERFILE.Location = new Point(504, 20);
			this.IDC_BTN_SELDRIVERFILE.Name = "IDC_BTN_SELDRIVERFILE";
			this.IDC_BTN_SELDRIVERFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELDRIVERFILE.TabIndex = 1;
			this.IDC_BTN_SELDRIVERFILE.Text = "Select";
			this.IDC_BTN_SELDRIVERFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELDRIVERFILE.Click += new EventHandler(this.IDC_BTN_SELDRIVERFILE_Click);
			this.IDC_EDIT_DRIVERFILE.Location = new Point(9, 21);
			this.IDC_EDIT_DRIVERFILE.Name = "IDC_EDIT_DRIVERFILE";
			this.IDC_EDIT_DRIVERFILE.ReadOnly = true;
			this.IDC_EDIT_DRIVERFILE.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_DRIVERFILE.TabIndex = 0;
			this.IDC_GB_BMS1IAP.Controls.Add(this.IDC_BTN_SELBMSFILE_1);
			this.IDC_GB_BMS1IAP.Controls.Add(this.IDC_EDIT_BMSFILE_1);
			this.IDC_GB_BMS1IAP.Controls.Add(this.IDC_BTN_DNLBMSFILE_1);
			this.IDC_GB_BMS1IAP.Location = new Point(6, 179);
			this.IDC_GB_BMS1IAP.Name = "IDC_GB_BMS1IAP";
			this.IDC_GB_BMS1IAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_BMS1IAP.TabIndex = 17;
			this.IDC_GB_BMS1IAP.TabStop = true; //false;
            this.IDC_GB_BMS1IAP.Text = "BMS_1 bin File";
			this.IDC_BTN_SELBMSFILE_1.Location = new Point(504, 17);
			this.IDC_BTN_SELBMSFILE_1.Name = "IDC_BTN_SELBMSFILE_1";
			this.IDC_BTN_SELBMSFILE_1.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELBMSFILE_1.TabIndex = 1;
			this.IDC_BTN_SELBMSFILE_1.Text = "Select";
			this.IDC_BTN_SELBMSFILE_1.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELBMSFILE_1.Click += new EventHandler(this.IDC_BTN_SELBMSFILE_1_Click);
			this.IDC_EDIT_BMSFILE_1.Location = new Point(9, 20);
			this.IDC_EDIT_BMSFILE_1.Name = "IDC_EDIT_BMSFILE_1";
			this.IDC_EDIT_BMSFILE_1.ReadOnly = true;
			this.IDC_EDIT_BMSFILE_1.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_BMSFILE_1.TabIndex = 0;
			this.IDC_BTN_DNLBMSFILE_1.Location = new Point(575, 17);
			this.IDC_BTN_DNLBMSFILE_1.Name = "IDC_BTN_DNLBMSFILE_1";
			this.IDC_BTN_DNLBMSFILE_1.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLBMSFILE_1.TabIndex = 2;
			this.IDC_BTN_DNLBMSFILE_1.Text = "Download";
			this.IDC_BTN_DNLBMSFILE_1.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLBMSFILE_1.Click += new EventHandler(this.IDC_BTN_DNLBMSFILE_1_Click);
			this.IDC_GB_BLEIAP.Controls.Add(this.IDC_BTN_SELBLEFILE);
			this.IDC_GB_BLEIAP.Controls.Add(this.IDC_EDIT_BLEFILE);
			this.IDC_GB_BLEIAP.Controls.Add(this.IDC_BTN_DNLBLEFILE);
			this.IDC_GB_BLEIAP.Location = new Point(6, 236);
			this.IDC_GB_BLEIAP.Name = "IDC_GB_BLEIAP";
			this.IDC_GB_BLEIAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_BLEIAP.TabIndex = 17;
			this.IDC_GB_BLEIAP.TabStop = true; //false;
            this.IDC_GB_BLEIAP.Text = "BLE bin File";
			this.IDC_BTN_SELBLEFILE.Location = new Point(504, 19);
			this.IDC_BTN_SELBLEFILE.Name = "IDC_BTN_SELBLEFILE";
			this.IDC_BTN_SELBLEFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELBLEFILE.TabIndex = 1;
			this.IDC_BTN_SELBLEFILE.Text = "Select";
			this.IDC_BTN_SELBLEFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELBLEFILE.Click += new EventHandler(this.IDC_BTN_SELBLEFILE_Click);
			this.IDC_EDIT_BLEFILE.Location = new Point(9, 20);
			this.IDC_EDIT_BLEFILE.Name = "IDC_EDIT_BLEFILE";
			this.IDC_EDIT_BLEFILE.ReadOnly = true;
			this.IDC_EDIT_BLEFILE.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_BLEFILE.TabIndex = 0;
			this.IDC_BTN_DNLBLEFILE.Location = new Point(575, 19);
			this.IDC_BTN_DNLBLEFILE.Name = "IDC_BTN_DNLBLEFILE";
			this.IDC_BTN_DNLBLEFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLBLEFILE.TabIndex = 2;
			this.IDC_BTN_DNLBLEFILE.Text = "Download";
			this.IDC_BTN_DNLBLEFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLBLEFILE.Click += new EventHandler(this.IDC_BTN_DNLBLEFILE_Click);
			this.IDC_GB_UPCIAP.Controls.Add(this.IDC_BTN_SELUPCFILE);
			this.IDC_GB_UPCIAP.Controls.Add(this.IDC_EDIT_UPCFILE);
			this.IDC_GB_UPCIAP.Controls.Add(this.IDC_BTN_DNLUPCFILE);
			this.IDC_GB_UPCIAP.Location = new Point(6, 407);
			this.IDC_GB_UPCIAP.Name = "IDC_GB_UPCIAP";
			this.IDC_GB_UPCIAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_UPCIAP.TabIndex = 17;
			this.IDC_GB_UPCIAP.TabStop = true; //false;
            this.IDC_GB_UPCIAP.Text = "UPC Firmware download";
			this.IDC_GB_UPCIAP.Visible = true; //false;
            this.IDC_BTN_SELUPCFILE.Location = new Point(504, 20);
			this.IDC_BTN_SELUPCFILE.Name = "IDC_BTN_SELUPCFILE";
			this.IDC_BTN_SELUPCFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELUPCFILE.TabIndex = 1;
			this.IDC_BTN_SELUPCFILE.Text = "Select firmware";
			this.IDC_BTN_SELUPCFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELUPCFILE.Click += new EventHandler(this.IDC_BTN_SELUPCFILE_Click);
			this.IDC_EDIT_UPCFILE.Location = new Point(9, 21);
			this.IDC_EDIT_UPCFILE.Name = "IDC_EDIT_UPCFILE";
			this.IDC_EDIT_UPCFILE.ReadOnly = true;
			this.IDC_EDIT_UPCFILE.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_UPCFILE.TabIndex = 0;
			this.IDC_BTN_DNLUPCFILE.Location = new Point(575, 20);
			this.IDC_BTN_DNLUPCFILE.Name = "IDC_BTN_DNLUPCFILE";
			this.IDC_BTN_DNLUPCFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLUPCFILE.TabIndex = 2;
			this.IDC_BTN_DNLUPCFILE.Text = "Download firmware";
			this.IDC_BTN_DNLUPCFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLUPCFILE.Click += new EventHandler(this.IDC_BTN_DNLUPCFILE_Click);
			this.IDC_GB_ANCIAP.Controls.Add(this.IDC_BTN_SELANCHORFILE);
			this.IDC_GB_ANCIAP.Controls.Add(this.IDC_BTN_DNLANCHORFILE);
			this.IDC_GB_ANCIAP.Controls.Add(this.IDC_EDIT_ANCHORFILE);
			this.IDC_GB_ANCIAP.Location = new Point(6, 464);
			this.IDC_GB_ANCIAP.Name = "IDC_GB_ANCIAP";
			this.IDC_GB_ANCIAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_ANCIAP.TabIndex = 17;
			this.IDC_GB_ANCIAP.TabStop = true; //false;
            this.IDC_GB_ANCIAP.Text = "Anchor Firmware download";
			this.IDC_GB_ANCIAP.Visible = true; //false;
            this.IDC_BTN_SELANCHORFILE.Location = new Point(504, 20);
			this.IDC_BTN_SELANCHORFILE.Name = "IDC_BTN_SELANCHORFILE";
			this.IDC_BTN_SELANCHORFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELANCHORFILE.TabIndex = 1;
			this.IDC_BTN_SELANCHORFILE.Text = "Select firmware";
			this.IDC_BTN_SELANCHORFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELANCHORFILE.Click += new EventHandler(this.IDC_BTN_SELANCHORFILE_Click);
			this.IDC_BTN_DNLANCHORFILE.Location = new Point(575, 20);
			this.IDC_BTN_DNLANCHORFILE.Name = "IDC_BTN_DNLANCHORFILE";
			this.IDC_BTN_DNLANCHORFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLANCHORFILE.TabIndex = 2;
			this.IDC_BTN_DNLANCHORFILE.Text = "Download firmware";
			this.IDC_BTN_DNLANCHORFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLANCHORFILE.Click += new EventHandler(this.IDC_BTN_DNLANCHORFILE_Click);
			this.IDC_EDIT_ANCHORFILE.Location = new Point(9, 21);
			this.IDC_EDIT_ANCHORFILE.Name = "IDC_EDIT_ANCHORFILE";
			this.IDC_EDIT_ANCHORFILE.ReadOnly = true;
			this.IDC_EDIT_ANCHORFILE.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_ANCHORFILE.TabIndex = 0;
			this.IDC_GB_TAGIAP.Controls.Add(this.IDC_BTN_DNLTAGFILE);
			this.IDC_GB_TAGIAP.Controls.Add(this.IDC_BTN_SELTAGFILE);
			this.IDC_GB_TAGIAP.Controls.Add(this.IDC_EDIT_TAGFILE);
			this.IDC_GB_TAGIAP.Location = new Point(6, 521);
			this.IDC_GB_TAGIAP.Name = "IDC_GB_TAGIAP";
			this.IDC_GB_TAGIAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_TAGIAP.TabIndex = 17;
			this.IDC_GB_TAGIAP.TabStop = true; //false;
            this.IDC_GB_TAGIAP.Text = "TAG Firmware download";
			this.IDC_GB_TAGIAP.Visible = true; //false;
            this.IDC_BTN_DNLTAGFILE.Location = new Point(575, 20);
			this.IDC_BTN_DNLTAGFILE.Name = "IDC_BTN_DNLTAGFILE";
			this.IDC_BTN_DNLTAGFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLTAGFILE.TabIndex = 2;
			this.IDC_BTN_DNLTAGFILE.Text = "Download firmware";
			this.IDC_BTN_DNLTAGFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLTAGFILE.Click += new EventHandler(this.IDC_BTN_DNLTAGFILE_Click);
			this.IDC_BTN_SELTAGFILE.Location = new Point(504, 21);
			this.IDC_BTN_SELTAGFILE.Name = "IDC_BTN_SELTAGFILE";
			this.IDC_BTN_SELTAGFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELTAGFILE.TabIndex = 1;
			this.IDC_BTN_SELTAGFILE.Text = "Select firmware";
			this.IDC_BTN_SELTAGFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELTAGFILE.Click += new EventHandler(this.IDC_BTN_SELTAGFILE_Click);
			this.IDC_EDIT_TAGFILE.Location = new Point(9, 22);
			this.IDC_EDIT_TAGFILE.Name = "IDC_EDIT_TAGFILE";
			this.IDC_EDIT_TAGFILE.ReadOnly = true;
			this.IDC_EDIT_TAGFILE.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_TAGFILE.TabIndex = 0;
			this.IDC_TC_ITEM.Controls.Add(this.tabPage1);
			this.IDC_TC_ITEM.Enabled = true; //false;
            this.IDC_TC_ITEM.Location = new Point(271, 12);
			this.IDC_TC_ITEM.Name = "IDC_TC_ITEM";
			this.IDC_TC_ITEM.SelectedIndex = 0;
			this.IDC_TC_ITEM.Size = new System.Drawing.Size(668, 663);
			this.IDC_TC_ITEM.TabIndex = 31;
			this.tabPage1.BackColor = SystemColors.Control;
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.IDC_GB_DRIVERIAP);
			this.tabPage1.Controls.Add(this.IDC_GB_BMS3IAP);
			this.tabPage1.Controls.Add(this.IDC_GB_BMS2IAP);
			this.tabPage1.Controls.Add(this.IDC_GB_BMS1IAP);
			this.tabPage1.Controls.Add(this.IDC_GB_BLEIAP);
			this.tabPage1.Controls.Add(this.IDC_GB_UPCIAP);
			this.tabPage1.Controls.Add(this.IDC_GB_ANCIAP);
			this.tabPage1.Controls.Add(this.IDC_GB_FEIMIIAP);
			this.tabPage1.Controls.Add(this.IDC_GB_TAGIAP);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(660, 637);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "IAP_Config";
			this.IDC_GB_BMS3IAP.Controls.Add(this.IDC_BTN_SELBMSFILE_3);
			this.IDC_GB_BMS3IAP.Controls.Add(this.IDC_EDIT_BMSFILE_3);
			this.IDC_GB_BMS3IAP.Controls.Add(this.IDC_BTN_DNLBMSFILE_3);
			this.IDC_GB_BMS3IAP.Location = new Point(6, 350);
			this.IDC_GB_BMS3IAP.Name = "IDC_GB_BMS3IAP";
			this.IDC_GB_BMS3IAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_BMS3IAP.TabIndex = 17;
			this.IDC_GB_BMS3IAP.TabStop = true; //false;
            this.IDC_GB_BMS3IAP.Text = "BMS_3_Firmware download";
			this.IDC_GB_BMS3IAP.Visible = true; //false;
            this.IDC_BTN_SELBMSFILE_3.Location = new Point(504, 17);
			this.IDC_BTN_SELBMSFILE_3.Name = "IDC_BTN_SELBMSFILE_3";
			this.IDC_BTN_SELBMSFILE_3.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELBMSFILE_3.TabIndex = 1;
			this.IDC_BTN_SELBMSFILE_3.Text = "Select firmware";
			this.IDC_BTN_SELBMSFILE_3.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELBMSFILE_3.Click += new EventHandler(this.IDC_BTN_SELBMSFILE_3_Click);
			this.IDC_EDIT_BMSFILE_3.Location = new Point(9, 20);
			this.IDC_EDIT_BMSFILE_3.Name = "IDC_EDIT_BMSFILE_3";
			this.IDC_EDIT_BMSFILE_3.ReadOnly = true;
			this.IDC_EDIT_BMSFILE_3.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_BMSFILE_3.TabIndex = 0;
			this.IDC_BTN_DNLBMSFILE_3.Location = new Point(575, 17);
			this.IDC_BTN_DNLBMSFILE_3.Name = "IDC_BTN_DNLBMSFILE_3";
			this.IDC_BTN_DNLBMSFILE_3.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLBMSFILE_3.TabIndex = 2;
			this.IDC_BTN_DNLBMSFILE_3.Text = "Download firmware";
			this.IDC_BTN_DNLBMSFILE_3.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLBMSFILE_3.Click += new EventHandler(this.IDC_BTN_DNLBMSFILE_3_Click);
			this.IDC_GB_BMS2IAP.Controls.Add(this.IDC_BTN_SELBMSFILE_2);
			this.IDC_GB_BMS2IAP.Controls.Add(this.IDC_EDIT_BMSFILE_2);
			this.IDC_GB_BMS2IAP.Controls.Add(this.IDC_BTN_DNLBMSFILE_2);
			this.IDC_GB_BMS2IAP.Location = new Point(6, 293);
			this.IDC_GB_BMS2IAP.Name = "IDC_GB_BMS2IAP";
			this.IDC_GB_BMS2IAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_BMS2IAP.TabIndex = 17;
			this.IDC_GB_BMS2IAP.TabStop = true; //false;
            this.IDC_GB_BMS2IAP.Text = "BMS_2 bin File";
			this.IDC_BTN_SELBMSFILE_2.Location = new Point(504, 17);
			this.IDC_BTN_SELBMSFILE_2.Name = "IDC_BTN_SELBMSFILE_2";
			this.IDC_BTN_SELBMSFILE_2.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELBMSFILE_2.TabIndex = 1;
			this.IDC_BTN_SELBMSFILE_2.Text = "Select";
			this.IDC_BTN_SELBMSFILE_2.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELBMSFILE_2.Click += new EventHandler(this.IDC_BTN_SELBMSFILE_2_Click);
			this.IDC_EDIT_BMSFILE_2.Location = new Point(9, 20);
			this.IDC_EDIT_BMSFILE_2.Name = "IDC_EDIT_BMSFILE_2";
			this.IDC_EDIT_BMSFILE_2.ReadOnly = true;
			this.IDC_EDIT_BMSFILE_2.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_BMSFILE_2.TabIndex = 0;
			this.IDC_BTN_DNLBMSFILE_2.Location = new Point(575, 17);
			this.IDC_BTN_DNLBMSFILE_2.Name = "IDC_BTN_DNLBMSFILE_2";
			this.IDC_BTN_DNLBMSFILE_2.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLBMSFILE_2.TabIndex = 2;
			this.IDC_BTN_DNLBMSFILE_2.Text = "Download";
			this.IDC_BTN_DNLBMSFILE_2.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLBMSFILE_2.Click += new EventHandler(this.IDC_BTN_DNLBMSFILE_2_Click);
			this.IDC_GB_FEIMIIAP.Controls.Add(this.IDC_BTN_DNLFEIMIFILE);
			this.IDC_GB_FEIMIIAP.Controls.Add(this.IDC_BTN_SELFEIMIFILE);
			this.IDC_GB_FEIMIIAP.Controls.Add(this.IDC_EDIT_FEIMIFILE);
			this.IDC_GB_FEIMIIAP.Location = new Point(6, 578);
			this.IDC_GB_FEIMIIAP.Name = "IDC_GB_FEIMIIAP";
			this.IDC_GB_FEIMIIAP.Size = new System.Drawing.Size(646, 51);
			this.IDC_GB_FEIMIIAP.TabIndex = 17;
			this.IDC_GB_FEIMIIAP.TabStop = false;
			this.IDC_GB_FEIMIIAP.Text = "Flying rice firmware download";
			this.IDC_GB_FEIMIIAP.Visible = true; //false;
            this.IDC_BTN_DNLFEIMIFILE.Location = new Point(575, 20);
			this.IDC_BTN_DNLFEIMIFILE.Name = "IDC_BTN_DNLFEIMIFILE";
			this.IDC_BTN_DNLFEIMIFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_DNLFEIMIFILE.TabIndex = 2;
			this.IDC_BTN_DNLFEIMIFILE.Text = "Download firmware";
			this.IDC_BTN_DNLFEIMIFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_DNLFEIMIFILE.Click += new EventHandler(this.IDC_BTN_DNLFEIMIFILE_Click);
			this.IDC_BTN_SELFEIMIFILE.Location = new Point(504, 21);
			this.IDC_BTN_SELFEIMIFILE.Name = "IDC_BTN_SELFEIMIFILE";
			this.IDC_BTN_SELFEIMIFILE.Size = new System.Drawing.Size(65, 21);
			this.IDC_BTN_SELFEIMIFILE.TabIndex = 1;
			this.IDC_BTN_SELFEIMIFILE.Text = "Select firmware";
			this.IDC_BTN_SELFEIMIFILE.UseVisualStyleBackColor = true;
			this.IDC_BTN_SELFEIMIFILE.Click += new EventHandler(this.IDC_BTN_SELFEIMIFILE_Click);
			this.IDC_EDIT_FEIMIFILE.Location = new Point(9, 22);
			this.IDC_EDIT_FEIMIFILE.Name = "IDC_EDIT_FEIMIFILE";
			this.IDC_EDIT_FEIMIFILE.ReadOnly = true;
			this.IDC_EDIT_FEIMIFILE.Size = new System.Drawing.Size(489, 21);
			this.IDC_EDIT_FEIMIFILE.TabIndex = 0;
			this.Timer_Update_SN_ACT.Enabled = true;
			this.Timer_Update_SN_ACT.Interval = 500;
			this.Timer_Update_SN_ACT.Tick += new EventHandler(this.Timer_Update_SN_ACT_Tick);
			this.Timer_IAP.Enabled = true;
			this.Timer_IAP.Interval = 1000;
			this.Timer_IAP.Tick += new EventHandler(this.Timer_IAP_Tick);
			this.Timer_BLEConnect.Interval = 200;
			this.Timer_BLEConnect.Tick += new EventHandler(this.Timer_BLEConnect_Tick);
			this.Timer_BLEScan.Interval = 1000;
			this.Timer_BLEScan.Tick += new EventHandler(this.Timer_BLEScan_Tick);
			this.AllowDrop = true;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(946, 683);
			base.Controls.Add(this.IDC_EDIT_INFO);
			base.Controls.Add(this.IDC_PROGRESSBAR);
			base.Controls.Add(this.IDC_GB_BLE);
			base.Controls.Add(this.IDC_GB_SERIAL);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.IDC_TC_ITEM);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "9BOT";
			this.Text = "9BOT_ENG_V1";
			base.FormClosing += new FormClosingEventHandler(this.IAP_Form_FormClosing);
			base.DragDrop += new DragEventHandler(this.IAP_Form_DragDrop);
			base.DragEnter += new DragEventHandler(this.IAP_Form_DragEnter);
			((ISupportInitialize)this.IDC_STATIC_ICON).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.IDC_GB_SERIAL.ResumeLayout(false);
			this.IDC_GB_SERIAL.PerformLayout();
			this.IDC_GB_BLE.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.IDC_GB_DRIVERIAP.ResumeLayout(false);
			this.IDC_GB_DRIVERIAP.PerformLayout();
			this.IDC_GB_BMS1IAP.ResumeLayout(false);
			this.IDC_GB_BMS1IAP.PerformLayout();
			this.IDC_GB_BLEIAP.ResumeLayout(false);
			this.IDC_GB_BLEIAP.PerformLayout();
			this.IDC_GB_UPCIAP.ResumeLayout(false);
			this.IDC_GB_UPCIAP.PerformLayout();
			this.IDC_GB_ANCIAP.ResumeLayout(false);
			this.IDC_GB_ANCIAP.PerformLayout();
			this.IDC_GB_TAGIAP.ResumeLayout(false);
			this.IDC_GB_TAGIAP.PerformLayout();
			this.IDC_TC_ITEM.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.IDC_GB_BMS3IAP.ResumeLayout(false);
			this.IDC_GB_BMS3IAP.PerformLayout();
			this.IDC_GB_BMS2IAP.ResumeLayout(false);
			this.IDC_GB_BMS2IAP.PerformLayout();
			this.IDC_GB_FEIMIIAP.ResumeLayout(false);
			this.IDC_GB_FEIMIIAP.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			this.ParseData();
		}

		private void ParseData()
		{
			if (this.m_COM_TYPE != 1)
			{
				try
				{
					this.s_i_RevLen = this.Serialport_Used.BytesToRead;
					if (this.s_i_RevLen != 0)
					{
						this.Serialport_Used.Read(this.s_b_RevData, 0, this.s_i_RevLen);
						for (int i = 0; i < this.s_i_RevLen; i++)
						{
							if (this.s_b_RevData[i] == 90 && !this.s_bol_FrameHead)
							{
								this.s_bol_FrameHead = true;
							}
							else if (this.s_b_RevData[i] == 165 && this.s_bol_FrameHead && !this.s_bol_BeginFrame)
							{
								this.s_bol_BeginFrame = true;
								this.s_i_CheckSum = 0;
							}
							else if (this.s_bol_BeginFrame)
							{
								this.s_b_RxBuf[this.s_i_RxPos] = this.s_b_RevData[i];
								if (this.s_i_RxPos == 0)
								{
									this.s_i_RxLen = this.s_b_RevData[i] + 7;
								}
								this.s_i_RxPos++;
								if (this.s_i_RxPos != this.s_i_RxLen)
								{
									this.s_i_CheckSum += this.s_b_RevData[i];
								}
								else
								{
									this.s_i_CheckSum = (short)(~(this.s_i_CheckSum - this.s_b_RxBuf[this.s_i_RxPos - 2]));
									this.s_i_GetCrc = (short)(this.s_b_RxBuf[this.s_i_RxPos - 2] + this.s_b_RxBuf[this.s_i_RxPos - 1] * 256);
									if (this.s_i_CheckSum == this.s_i_GetCrc)
									{
										this.ParseFrame(ref this.s_b_RxBuf);
									}
									int num = 0;
									bool flag = Convert.ToBoolean(num); //(bool)num;
									this.s_bol_FrameHead = Convert.ToBoolean(num); //(bool)num;
                                    this.s_bol_BeginFrame = flag;
									int num1 = 0;
									int num2 = num1;
									this.s_i_RxPos = num1;
									this.s_i_CheckSum = num2;
								}
							}
						}
					}
				}
				catch
				{
				}
			}
			else
			{
				try
				{
					this.s_i_RevLen = this.Serialport_Used.BytesToRead;
					if (this.s_i_RevLen != 0)
					{
						this.Serialport_Used.Read(this.s_b_RevData, 0, this.s_i_RevLen);
						for (int j = 0; j < this.s_i_RevLen; j++)
						{
							if (this.s_b_RevData[j] == 85 && !this.s_bol_FrameHead)
							{
								this.s_bol_FrameHead = true;
							}
							else if (this.s_b_RevData[j] == 170 && this.s_bol_FrameHead && !this.s_bol_BeginFrame)
							{
								this.s_bol_BeginFrame = true;
								this.s_i_CheckSum = 0;
							}
							else if (this.s_bol_BeginFrame)
							{
								this.s_b_RxBuf[this.s_i_RxPos] = this.s_b_RevData[j];
								if (this.s_i_RxPos == 0)
								{
									this.s_i_RxLen = this.s_b_RevData[j] + 4;
								}
								this.s_i_RxPos++;
								if (this.s_i_RxPos != this.s_i_RxLen)
								{
									this.s_i_CheckSum += this.s_b_RevData[j];
								}
								else
								{
									this.s_i_CheckSum = (short)(~(this.s_i_CheckSum - this.s_b_RxBuf[this.s_i_RxPos - 2]));
									this.s_i_GetCrc = (short)(this.s_b_RxBuf[this.s_i_RxPos - 2] + this.s_b_RxBuf[this.s_i_RxPos - 1] * 256);
									if (this.s_i_CheckSum == this.s_i_GetCrc)
									{
										this.ParseFrame(ref this.s_b_RxBuf);
									}
									int num3 = 0;
									bool flag1 = Convert.ToBoolean(num3); //(bool)num3;
									this.s_bol_FrameHead = Convert.ToBoolean(num3); //(bool)num3;
									this.s_bol_BeginFrame = flag1;
									int num4 = 0;
									int num5 = num4;
									this.s_i_RxPos = num4;
									this.s_i_CheckSum = num5;
								}
							}
						}
					}
				}
				catch
				{
				}
			}
		}

		private void ParseFrame(ref byte[] b_RxBuf)
		{
			byte mDriverID = 0;
			switch (this.m_b_IAPObject)
			{
				case 0:
				{
					mDriverID = this.m_DriverID;
					break;
				}
				case 1:
				{
					mDriverID = this.m_BMSID_1;
					break;
				}
				case 2:
				{
					mDriverID = this.m_BMSID_2;
					break;
				}
				case 3:
				{
					mDriverID = this.m_BMSID_3;
					break;
				}
				case 4:
				{
					mDriverID = this.m_BLEID;
					break;
				}
				case 5:
				{
					mDriverID = this.m_UPCID;
					break;
				}
				case 6:
				{
					mDriverID = this.m_ANCID;
					break;
				}
				case 7:
				{
					mDriverID = this.m_TAGID;
					break;
				}
				case 8:
				{
					mDriverID = this.m_FEIMIID;
					break;
				}
			}
			if (this.m_COM_TYPE != 1)
			{
				if (b_RxBuf[this.m_COM_ID] == mDriverID && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == CmdDefine.CMD_IAP_ACK || b_RxBuf[this.m_COM_ID] == this.m_UPCID && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == 22)
				{
					this.m_ui_RecvCount++;
					this.m_b_IAPResult = b_RxBuf[this.m_COM_INDEX];
					this.m_bol_IAPAnswer = true;
				}
				if (b_RxBuf[this.m_COM_ID] == this.m_DriverID && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == CmdDefine.CMD_CTL_WR_SN)
				{
					this.m_bol_SetSNOK = (b_RxBuf[this.m_COM_INDEX] == 1 ? true : false);
				}
				if (b_RxBuf[this.m_COM_ID] == this.m_DriverID && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_ACK_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] < NinebotCmd.NB_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, (int)b_RxBuf[this.m_COM_LEN]);
				}
				else if (b_RxBuf[this.m_COM_ID] == this.m_BMSID_1 && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_ACK_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] < MiniBatteryCmdMap.BMS_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_BMS_1_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, (int)b_RxBuf[this.m_COM_LEN]);
				}
				else if (b_RxBuf[this.m_COM_ID] == this.m_BMSID_2 && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_ACK_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] < MiniBatteryCmdMap.BMS_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_BMS_2_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, (int)b_RxBuf[this.m_COM_LEN]);
				}
				else if (b_RxBuf[this.m_COM_ID] == this.m_BMSID_3 && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_ACK_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] < MiniBatteryCmdMap.BMS_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_BMS_3_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, (int)b_RxBuf[this.m_COM_LEN]);
				}
				else if (b_RxBuf[this.m_COM_ID] == this.m_BLEID && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_ACK_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] < NinebotCmd.NB_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_CmdMap, NinebotCmd.NB_INF_VER_BLE * 2, (int)b_RxBuf[this.m_COM_LEN]);
				}
				else if ((b_RxBuf[this.m_COM_ID] == this.m_UPCID || b_RxBuf[this.m_COM_ID] == this.m_ANCID || b_RxBuf[this.m_COM_ID] == this.m_TAGID || b_RxBuf[this.m_COM_ID] == this.m_FEIMIID) && b_RxBuf[this.m_COM_ME] == this.m_MyID && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_ACK_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] < NinebotCmd.NB_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, (int)b_RxBuf[this.m_COM_LEN]);
				}
			}
			else
			{
				byte num = (byte)(mDriverID + 3);
				byte mDriverID1 = this.m_DriverID;
				byte num1 = (byte)(this.m_DriverID + 3);
				byte mBMSID1 = this.m_BMSID_1;
				byte mBMSID11 = (byte)(this.m_BMSID_1 + 3);
				byte mBMSID2 = this.m_BMSID_2;
				byte mBMSID21 = (byte)(this.m_BMSID_2 + 3);
				byte mBMSID3 = this.m_BMSID_3;
				byte mBMSID31 = (byte)(this.m_BMSID_3 + 3);
				byte mBLEID = this.m_BLEID;
				byte mBLEID1 = (byte)(this.m_BLEID + 3);
				if ((b_RxBuf[this.m_COM_ID] == mDriverID || b_RxBuf[this.m_COM_ID] == num) && b_RxBuf[this.m_COM_CMD] >= CmdDefine.CMD_IAP_BEGIN && b_RxBuf[this.m_COM_CMD] <= CmdDefine.CMD_IAP_RESET && b_RxBuf[this.m_COM_LEN] <= 3)
				{
					this.m_ui_RecvCount++;
					this.m_b_IAPResult = b_RxBuf[this.m_COM_INDEX];
					this.m_bol_IAPAnswer = true;
				}
				if ((b_RxBuf[this.m_COM_ID] == mDriverID1 || b_RxBuf[this.m_COM_ID] == num1) && b_RxBuf[this.m_COM_CMD] == CmdDefine.CMD_CTL_WR_SN)
				{
					this.m_bol_SetSNOK = (b_RxBuf[this.m_COM_INDEX] == 1 ? true : false);
				}
				if ((b_RxBuf[this.m_COM_ID] == mDriverID1 || b_RxBuf[this.m_COM_ID] == num1) && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] - 2 < NinebotCmd.NB_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, b_RxBuf[this.m_COM_LEN] - 2);
				}
				else if ((b_RxBuf[this.m_COM_ID] == mBMSID1 || b_RxBuf[this.m_COM_ID] == mBMSID11) && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] - 2 < MiniBatteryCmdMap.BMS_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_BMS_1_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, b_RxBuf[this.m_COM_LEN] - 2);
				}
				else if ((b_RxBuf[this.m_COM_ID] == mBMSID2 || b_RxBuf[this.m_COM_ID] == mBMSID21) && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] - 2 < MiniBatteryCmdMap.BMS_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_BMS_2_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, b_RxBuf[this.m_COM_LEN] - 2);
				}
				else if ((b_RxBuf[this.m_COM_ID] == mBMSID3 || b_RxBuf[this.m_COM_ID] == mBMSID31) && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] - 2 < MiniBatteryCmdMap.BMS_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_BMS_3_CmdMap, b_RxBuf[this.m_COM_INDEX] * 2, b_RxBuf[this.m_COM_LEN] - 2);
				}
				else if ((b_RxBuf[this.m_COM_ID] == mBLEID || b_RxBuf[this.m_COM_ID] == mBLEID1) && b_RxBuf[this.m_COM_CMD] == NinebotCmd.CMD_CMAP_RD && b_RxBuf[this.m_COM_INDEX] + b_RxBuf[this.m_COM_LEN] - 2 < NinebotCmd.NB_CMDMAP_LEN)
				{
					this.m_ui_RecvCount++;
					this.m_bol_ReadBack = true;
					Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, this.m_s_CmdMap, NinebotCmd.NB_INF_VER_BLE * 2, b_RxBuf[this.m_COM_LEN] - 2);
				}
			}
			if (b_RxBuf[this.m_COM_ID] == CmdDefine.BLE_MASTER_ID)
			{
				if (b_RxBuf[this.m_COM_CMD] == CmdDefine.CMD_BLE_MST_SEND_NAME)
				{
					byte[] numArray = new byte[b_RxBuf[this.m_COM_LEN]];
					if (this.m_COM_TYPE != 1)
					{
						Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, numArray, 0, (int)b_RxBuf[this.m_COM_LEN]);
					}
					else
					{
						Buffer.BlockCopy(b_RxBuf, (int)this.m_COM_DATA, numArray, 0, b_RxBuf[this.m_COM_LEN] - 2);
					}
					string str = Encoding.UTF8.GetString(numArray);
					int count = this.IDC_LIST_BLELIST.Items.Count;
					int num2 = 0;
					num2 = 0;
					while (num2 < count && !(this.IDC_LIST_BLELIST.Items[num2].ToString() == str))
					{
						num2++;
					}
					if (num2 == count)
					{
						this.IDC_LIST_BLELIST.Items.Add(str);
						return;
					}
				}
				else if (b_RxBuf[this.m_COM_CMD] == CmdDefine.CMD_BLE_MST_CONN_OK)
				{
					if (b_RxBuf[this.m_COM_INDEX] == 1 && !this.m_bol_IAPing)
					{
						base.Invoke(new Action(() => {
							this.Timer_SendData.Start();
							this.BLE_Connect_Finish();
							this.IDC_LABEL_BLECONNECTSTATUE.Text = "Bluetooth is connected";
						}));
						return;
					}
					if (b_RxBuf[this.m_COM_INDEX] == 0)
					{
						this.IDC_LABEL_BLECONNECTSTATUE.Text = "Bluetooth is not connected";
					}
				}
			}
		}

		private void Password_Init()
		{
			string str = "";
			if (this.GetMacAddress(ref str))
			{
				char[] charArray = new char[20];
				charArray = str.ToCharArray();
				this.m_i_Password = 1;
				for (int i = 0; i < 12; i++)
				{
					if (charArray[i] != ':')
					{
						this.m_i_Password *= charArray[i];
					}
				}
				this.m_i_Password = Math.Abs(this.m_i_Password) % 1000000;
			}
			else
			{
				MessageBox.Show("Software authorization code init failed！");
			}
			this.InitConfigData();
			this.IDC_BTN_AUTH.Text = "Authorize";
			this.SaveConfigData();
			this.EnableSerialItems();
		}

		private void PushFrame(byte ID, byte Datelen, byte Cmd, byte Index, ref byte[] p)
		{
			if (this.m_COM_TYPE != 1)
			{
				try
				{
					byte datelen = (byte)(Datelen / this.m_b_BufTxLen);
					byte num = (byte)(Datelen % this.m_b_BufTxLen);
					for (int i = 0; i < datelen; i++)
					{
						byte[] numArray = p;
						short num1 = 0;
						byte[] mBBufTxLen = new byte[500];
						int j = 0;
						short num2 = num1;
						num1 = (short)(num2 + 1);
						mBBufTxLen[num2] = 90;
						short num3 = num1;
						num1 = (short)(num3 + 1);
						mBBufTxLen[num3] = 165;
						short num4 = num1;
						num1 = (short)(num4 + 1);
						mBBufTxLen[num4] = this.m_b_BufTxLen;
						short num5 = num1;
						num1 = (short)(num5 + 1);
						mBBufTxLen[num5] = this.m_MyID;
						short num6 = num1;
						num1 = (short)(num6 + 1);
						mBBufTxLen[num6] = ID;
						short num7 = num1;
						num1 = (short)(num7 + 1);
						mBBufTxLen[num7] = Cmd;
						short num8 = num1;
						num1 = (short)(num8 + 1);
						mBBufTxLen[num8] = (byte)(Index + this.m_b_BufTxLen * i);
						for (j = 0; j < this.m_b_BufTxLen; j++)
						{
							short num9 = num1;
							num1 = (short)(num9 + 1);
							mBBufTxLen[num9] = numArray[this.m_b_BufTxLen * i + j];
						}
						int num10 = 0;
						for (j = 0; j < num1 - 2; j++)
						{
							num10 += mBBufTxLen[2 + j];
						}
						num10 = ~num10;
						short num11 = num1;
						num1 = (short)(num11 + 1);
						mBBufTxLen[num11] = BitConverter.GetBytes(num10)[0];
						short num12 = num1;
						num1 = (short)(num12 + 1);
						mBBufTxLen[num12] = BitConverter.GetBytes(num10 >> 8)[0];
						this.Serialport_Used.DiscardInBuffer();
						this.Serialport_Used.Write(mBBufTxLen, 0, num1);
					}
					if (num != 0 || Datelen == 0)
					{
						byte[] numArray1 = p;
						short num13 = 0;
						byte[] mMyID = new byte[500];
						int k = 0;
						short num14 = num13;
						num13 = (short)(num14 + 1);
						mMyID[num14] = 90;
						short num15 = num13;
						num13 = (short)(num15 + 1);
						mMyID[num15] = 165;
						short num16 = num13;
						num13 = (short)(num16 + 1);
						mMyID[num16] = num;
						short num17 = num13;
						num13 = (short)(num17 + 1);
						mMyID[num17] = this.m_MyID;
						short num18 = num13;
						num13 = (short)(num18 + 1);
						mMyID[num18] = ID;
						short num19 = num13;
						num13 = (short)(num19 + 1);
						mMyID[num19] = Cmd;
						short num20 = num13;
						num13 = (short)(num20 + 1);
						mMyID[num20] = (byte)(Index + this.m_b_BufTxLen * datelen);
						for (k = 0; k < num; k++)
						{
							short num21 = num13;
							num13 = (short)(num21 + 1);
							mMyID[num21] = numArray1[this.m_b_BufTxLen * datelen + k];
						}
						int num22 = 0;
						for (k = 0; k < num13 - 2; k++)
						{
							num22 += mMyID[2 + k];
						}
						num22 = ~num22;
						short num23 = num13;
						num13 = (short)(num23 + 1);
						mMyID[num23] = BitConverter.GetBytes(num22)[0];
						short num24 = num13;
						num13 = (short)(num24 + 1);
						mMyID[num24] = BitConverter.GetBytes(num22 >> 8)[0];
						this.Serialport_Used.DiscardInBuffer();
						this.Serialport_Used.Write(mMyID, 0, num13);
					}
				}
				catch
				{
				}
			}
			else
			{
				try
				{
					byte datelen1 = (byte)(Datelen / this.m_b_BufTxLen);
					byte datelen2 = (byte)(Datelen % this.m_b_BufTxLen);
					for (int l = 0; l < datelen1; l++)
					{
						byte[] numArray2 = p;
						short num25 = 0;
						byte[] d = new byte[500];
						int m = 0;
						short num26 = num25;
						num25 = (short)(num26 + 1);
						d[num26] = 85;
						short num27 = num25;
						num25 = (short)(num27 + 1);
						d[num27] = 170;
						short num28 = num25;
						num25 = (short)(num28 + 1);
						d[num28] = (byte)(this.m_b_BufTxLen + 2);
						short num29 = num25;
						num25 = (short)(num29 + 1);
						d[num29] = ID;
						short num30 = num25;
						num25 = (short)(num30 + 1);
						d[num30] = Cmd;
						short num31 = num25;
						num25 = (short)(num31 + 1);
						d[num31] = (byte)(Index + this.m_b_BufTxLen * l);
						for (m = 0; m < this.m_b_BufTxLen; m++)
						{
							short num32 = num25;
							num25 = (short)(num32 + 1);
							d[num32] = numArray2[this.m_b_BufTxLen * l + m];
						}
						int num33 = 0;
						for (m = 0; m < num25 - 2; m++)
						{
							num33 += d[2 + m];
						}
						num33 = ~num33;
						short num34 = num25;
						num25 = (short)(num34 + 1);
						d[num34] = BitConverter.GetBytes(num33)[0];
						short num35 = num25;
						num25 = (short)(num35 + 1);
						d[num35] = BitConverter.GetBytes(num33 >> 8)[0];
						this.Serialport_Used.DiscardInBuffer();
						this.Serialport_Used.Write(d, 0, num25);
					}
					if (datelen2 != 0 || Datelen == 0)
					{
						byte[] numArray3 = p;
						short num36 = 0;
						byte[] cmd = new byte[500];
						int n = 0;
						short num37 = num36;
						num36 = (short)(num37 + 1);
						cmd[num37] = 85;
						short num38 = num36;
						num36 = (short)(num38 + 1);
						cmd[num38] = 170;
						short num39 = num36;
						num36 = (short)(num39 + 1);
						cmd[num39] = (byte)(datelen2 + 2);
						short num40 = num36;
						num36 = (short)(num40 + 1);
						cmd[num40] = ID;
						short num41 = num36;
						num36 = (short)(num41 + 1);
						cmd[num41] = Cmd;
						short num42 = num36;
						num36 = (short)(num42 + 1);
						cmd[num42] = (byte)(Index + this.m_b_BufTxLen * datelen1);
						for (n = 0; n < datelen2; n++)
						{
							short num43 = num36;
							num36 = (short)(num43 + 1);
							cmd[num43] = numArray3[this.m_b_BufTxLen * datelen1 + n];
						}
						int num44 = 0;
						for (n = 0; n < num36 - 2; n++)
						{
							num44 += cmd[2 + n];
						}
						num44 = ~num44;
						short num45 = num36;
						num36 = (short)(num45 + 1);
						cmd[num45] = BitConverter.GetBytes(num44)[0];
						short num46 = num36;
						num36 = (short)(num46 + 1);
						cmd[num46] = BitConverter.GetBytes(num44 >> 8)[0];
						this.Serialport_Used.DiscardInBuffer();
						this.Serialport_Used.Write(cmd, 0, num36);
					}
				}
				catch
				{
				}
			}
		}

		private void ReadWords(byte Index, byte Wordsnum, byte ID)
		{
			byte[] wordsnum = new byte[] { (byte)(Wordsnum * 2) };
			this.PushFrame(ID, (byte)((int)wordsnum.Length), NinebotCmd.CMD_CMAP_RD, Index, ref wordsnum);
		}

		private void SaveConfigData()
		{
			string[] text = new string[] { "PassWord:", this.IDC_EDIT_PASSWORD.Text, "\r\nCar:", null, null };
			text[3] = ((this.IDC_COMBO_CAR.SelectedIndex == -1 ? 0 : this.IDC_COMBO_CAR.SelectedIndex)).ToString();
			text[4] = "\r\n";
			File.WriteAllText("Config_NCIAP.inf", string.Concat(text));
		}

		private void SelectFile()
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog()
				{
					Title = "open a file",
					Filter = "Bin file(*.bin)|*.bin"
                };
				if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					bool flag = true;
					string text = this.IDC_COMBO_CAR.Text;
					string str = text;
					if (text != null)
					{
						switch (str)
						{
							case "mini":
							{
								flag = openFileDialog.SafeFileName.Contains("Mini_");
								break;
							}
							case "MK2":
							{
								flag = openFileDialog.SafeFileName.Contains("MK2_");
								break;
							}
							case "Home meter skateboard":
							{
								flag = openFileDialog.SafeFileName.Contains("ESC_");
								break;
							}
							case "Mijia Pro":
							{
								flag = openFileDialog.SafeFileName.Contains("ESC_");
								break;
							}
							case "Plus":
							{
								flag = openFileDialog.SafeFileName.Contains("Plus_");
								break;
							}
							case "Kickscooter":
							{
								flag = openFileDialog.SafeFileName.Contains("ESC2_");
								break;
							}
							case "Lite":
							{
								flag = openFileDialog.SafeFileName.Contains("Lite_");
								break;
							}
							case "MK3":
							{
								flag = openFileDialog.SafeFileName.Contains("MK3_");
								break;
							}
							case "Kart":
							{
								flag = openFileDialog.SafeFileName.Contains("Kart_");
								break;
							}
							case "Steeldust":
							{
								flag = openFileDialog.SafeFileName.Contains("Steeldust_");
								break;
							}
						}
					}
					switch (this.m_b_IAPObject)
					{
						case 0:
						{
							if (openFileDialog.SafeFileName.Contains("_Driver"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 1:
						{
							if (openFileDialog.SafeFileName.Contains("_BMS"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 2:
						{
							if (openFileDialog.SafeFileName.Contains("_BMS"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 3:
						{
							if (openFileDialog.SafeFileName.Contains("_BMS"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 4:
						{
							if (openFileDialog.SafeFileName.Contains("_BLE"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 5:
						{
							if (openFileDialog.SafeFileName.Contains("_UpCtrller"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 6:
						{
							if (openFileDialog.SafeFileName.Contains("_Anchor"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 7:
						{
							if (openFileDialog.SafeFileName.Contains("_Tag"))
							{
								break;
							}
							flag = false;
							break;
						}
						case 8:
						{
							if (openFileDialog.SafeFileName.Contains("_FEIMI"))
							{
								break;
							}
							flag = false;
							break;
						}
						default:
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						byte[] numArray = File.ReadAllBytes(openFileDialog.FileName);
						if ((long)((int)numArray.Length) <= (long)385024)
						{
							this.m_str_IAPFileName[this.m_b_IAPObject] = openFileDialog.FileName;
							this.m_i_IAPFileLen[this.m_b_IAPObject] = (int)numArray.Length;
							this.m_b_IAPFileBin[this.m_b_IAPObject] = new byte[(int)numArray.Length];
							numArray.CopyTo(this.m_b_IAPFileBin[this.m_b_IAPObject], 0);
							int num = 0;
							for (int i = 0; i < (int)numArray.Length; i++)
							{
								num += numArray[i];
							}
							num = ~num;
							this.m_i_IAPFileCrc[this.m_b_IAPObject] = num;
							object[] safeFileName = new object[] { openFileDialog.SafeFileName, " ", (int)numArray.Length, "Bytes Opened.\r\nCRC:", num, "\r\n" };
							string str1 = string.Concat(safeFileName);
							this.IDC_EDIT_INFO.AppendText(str1);
							string str2 = openFileDialog.SafeFileName.Substring(openFileDialog.SafeFileName.LastIndexOf("_V") + 1, 6);
							switch (this.m_b_IAPObject)
							{
								case 0:
								{
									this.IDC_EDIT_DRIVERFILE.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_DRIVERVER_SEL.Text = str2;
									break;
								}
								case 1:
								{
									this.IDC_EDIT_BMSFILE_1.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_BMSVER_SEL_1.Text = str2;
									break;
								}
								case 2:
								{
									this.IDC_EDIT_BMSFILE_2.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_BMSVER_SEL_2.Text = str2;
									break;
								}
								case 3:
								{
									this.IDC_EDIT_BMSFILE_3.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_BMSVER_SEL_3.Text = str2;
									break;
								}
								case 4:
								{
									this.IDC_EDIT_BLEFILE.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_BLEVER_SEL.Text = str2;
									break;
								}
								case 5:
								{
									this.IDC_EDIT_UPCFILE.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_UPCVER_SEL.Text = str2;
									break;
								}
								case 6:
								{
									this.IDC_EDIT_ANCHORFILE.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_ANCVER_SEL.Text = str2;
									break;
								}
								case 7:
								{
									this.IDC_EDIT_TAGFILE.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_TAGVER_SEL.Text = str2;
									break;
								}
								case 8:
								{
									this.IDC_EDIT_FEIMIFILE.Text = this.m_str_IAPFileName[this.m_b_IAPObject];
									this.IDC_LABEL_FEIMIVER_SEL.Text = str2;
									break;
								}
							}
						}
						else
						{
							MessageBox.Show("Bin file size out of range!");
							return;
						}
					}
					else
					{
						MessageBox.Show("Bin File does not match the model!");
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void Serial_Open_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.IDC_BTN_OPENCOM.Text != "Open")
				{
					this.Timer_SendData.Stop();
					this.Timer_BLEScan.Stop();
					this.Timer_BLEConnect.Stop();
					this.Serialport_Used.Close();
					if (this.Serialport_Used.IsOpen)
					{
						MessageBox.Show("Close Failed！");
					}
					else
					{
						this.IDC_BTN_OPENCOM.Text = "Open";
						this.IDC_STATIC_ICON.BackColor = Color.Black;
						this.DisableItems();
						this.IDC_RB_PC.Enabled = true;
						this.IDC_RB_BLE.Enabled = true;
						this.IDC_RB_CAN.Enabled = true;
						this.IDC_COMBO_COM.Enabled = true;
						this.IDC_COMBO_BAUDRATE.Enabled = true;
						this.IDC_COMBO_CAR.Enabled = true;
					}
				}
				else
				{
					this.Serialport_Used.PortName = this.IDC_COMBO_COM.Text;
					this.Serialport_Used.BaudRate = int.Parse(this.IDC_COMBO_BAUDRATE.Text);
					this.Serialport_Used.Open();
					if (!this.Serialport_Used.IsOpen)
					{
						MessageBox.Show("Open Failed！");
					}
					else
					{
						this.IDC_BTN_OPENCOM.Text = "Close";
						this.IDC_STATIC_ICON.BackColor = Color.LawnGreen;
						this.EnableItems();
						this.Timer_SendData.Start();
						if (!this.IDC_RB_BLE.Checked)
						{
							this.IDC_BTN_BLESWAN.Enabled = true; //false;
							this.IDC_LIST_BLELIST.Enabled = true; //false;
						}
						else
						{
							this.IDC_BTN_BLESWAN.Enabled = true;
							this.IDC_LIST_BLELIST.Enabled = true;
						}
						this.IDC_RB_PC.Enabled = true; //false;
						this.IDC_RB_BLE.Enabled = true; //false;
						this.IDC_RB_CAN.Enabled = true; //false;
						this.IDC_COMBO_COM.Enabled = true; //false;
						this.IDC_COMBO_BAUDRATE.Enabled = true; //false;
						this.IDC_COMBO_CAR.Enabled = true; //false;
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void Serialport_Init()
		{
			try
			{
				this.IDC_COMBO_BAUDRATE.SelectedIndex = 3;
				string[] portNames = SerialPort.GetPortNames();
				this.IDC_COMBO_COM.Items.Clear();
				for (int i = 0; i < (int)portNames.Length; i++)
				{
					this.IDC_COMBO_COM.Items.Add(portNames[i]);
				}
				this.IDC_COMBO_COM.SelectedIndex = 0;
			}
			catch
			{
				MessageBox.Show("There is no available serial port！");
			}
		}

		private void ShowIAPError(byte result)
		{
			string str;
			switch (result)
			{
				case 1:
				{
					str = "Write length out of range! \r\n";
					break;
				}
				case 2:
				{
					str = "Wiping Flash failed! \r\n";
					break;
				}
				case 3:
				{
					str = "Writing to Flash failed! \r\n";
					break;
				}
				case 4:
				{
					str = "The vehicle is not in the locked state! \r\n";
					break;
				}
				case 5:
				{
					str = "Index check error! \r\n";
					break;
				}
				case 6:
				{
					str = "IAP busy! \r\n";
					break;
				}
				case 7:
				{
					str = "Frame format error! \r\n";
					break;
				}
				case 8:
				{
					str = "CRC Verification failed! \r\n";
					break;
				}
				default:
				{
					str = "unknown error! \r\n";
					break;
				}
			}
			this.IDC_EDIT_INFO.AppendText(str);
		}

		private bool SleepUntil(int time)
		{
			while (time > 0)
			{
				if (this.m_bol_IAPAnswer || !this.Serialport_Used.IsOpen)
				{
					return false;
				}
				time--;
				Thread.Sleep(1);
			}
			return true;
		}

		private void Timer_BLEConnect_Tick(object sender, EventArgs e)
		{
			byte[] bytes = new byte[1];
			bytes = new byte[1];
			this.PushFrame(CmdDefine.BLE_MASTER_ID, 0, CmdDefine.CMD_BLE_MST_SCAN, 0, ref bytes);
			Thread.Sleep(50);
			string text = this.IDC_LIST_BLELIST.Text;
			bytes = Encoding.UTF8.GetBytes(text);
			this.PushFrame(CmdDefine.BLE_MASTER_ID, (byte)((int)bytes.Length), CmdDefine.CMD_BLE_MST_CONN_NAME, 0, ref bytes);
		}

		private void Timer_BLEScan_Tick(object sender, EventArgs e)
		{
			byte[] numArray = new byte[1];
			this.PushFrame(CmdDefine.BLE_MASTER_ID, 0, CmdDefine.CMD_BLE_MST_SCAN, 0, ref numArray);
			this.IDC_LABEL_BLECONNECTSTATUE.Text = "Bluetooth is not connected";
		}

		private void Timer_FreshData_Tick(object sender, EventArgs e)
		{
			if (!this.Serialport_Used.IsOpen || this.m_bol_IAPing || this.m_b_NoDataCount == 15)
			{
				this.m_s_CmdMap[NinebotCmd.NB_INF_FW_VERSION] = 0;
				this.IDC_LABEL_DRIVERVER.Text = "V0.0.0";
				this.m_s_BMS_1_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] = 0;
				this.IDC_LABEL_BMSVER_1.Text = "V0.0.0";
				this.m_s_BMS_2_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] = 0;
				this.IDC_LABEL_BMSVER_2.Text = "V0.0.0";
				this.m_s_BMS_3_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] = 0;
				this.IDC_LABEL_BMSVER_3.Text = "V0.0.0";
				this.m_s_CmdMap[NinebotCmd.NB_INF_VER_BLE] = 0;
				this.IDC_LABEL_BLEVER.Text = "V0.0.0";
				this.m_s_CmdMap[NinebotCmd.NB_INF_UPC_VER] = 0;
				this.IDC_LABEL_UPCVER.Text = "V0.0.0";
				this.m_s_CmdMap[NinebotCmd.NB_INF_ANC_VER] = 0;
				this.IDC_LABEL_ANCVER.Text = "V0.0.0";
				this.m_s_CmdMap[NinebotCmd.NB_INF_TAG_VER] = 0;
				this.IDC_LABEL_TAGVER.Text = "V0.0.0";
				this.m_s_CmdMap[NinebotCmd.NB_INF_FEIMI_VER] = 0;
				this.IDC_LABEL_FEIMIVER.Text = "V0.0.0";
				this.m_s_CmdMap[NinebotCmd.NB_INF_BOOL] = 0;
			}
			else
			{
				Label dCLABELDRIVERVER = this.IDC_LABEL_DRIVERVER;
				string[] str = new string[] { "V", null, null, null, null, null };
				int mSCmdMap = this.m_s_CmdMap[NinebotCmd.NB_INF_FW_VERSION] >> 8 & 15;
				str[1] = mSCmdMap.ToString();
				str[2] = ".";
				int num = this.m_s_CmdMap[NinebotCmd.NB_INF_FW_VERSION] >> 4 & 15;
				str[3] = num.ToString();
				str[4] = ".";
				int mSCmdMap1 = this.m_s_CmdMap[NinebotCmd.NB_INF_FW_VERSION] & 15;
				str[5] = mSCmdMap1.ToString();
				dCLABELDRIVERVER.Text = string.Concat(str);
				if (!(this.IDC_LABEL_DRIVERVER.Text != this.IDC_LABEL_DRIVERVER_SEL.Text) || !(this.IDC_LABEL_DRIVERVER.Text != "V0.0.0") || !(this.IDC_LABEL_DRIVERVER_SEL.Text != "V0.0.0"))
				{
					this.IDC_LABEL_DRIVERVER.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_DRIVERVER.ForeColor = Color.Red;
				}
				Label dCLABELBMSVER1 = this.IDC_LABEL_BMSVER_1;
				string[] strArrays = new string[] { "V", null, null, null, null, null };
				int mSBMS1CmdMap = this.m_s_BMS_1_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] >> 8 & 15;
				strArrays[1] = mSBMS1CmdMap.ToString();
				strArrays[2] = ".";
				int mSBMS1CmdMap1 = this.m_s_BMS_1_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] >> 4 & 15;
				strArrays[3] = mSBMS1CmdMap1.ToString();
				strArrays[4] = ".";
				int num1 = this.m_s_BMS_1_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] & 15;
				strArrays[5] = num1.ToString();
				dCLABELBMSVER1.Text = string.Concat(strArrays);
				if (!(this.IDC_LABEL_BMSVER_1.Text != this.IDC_LABEL_BMSVER_SEL_1.Text) || !(this.IDC_LABEL_BMSVER_1.Text != "V0.0.0") || !(this.IDC_LABEL_BMSVER_SEL_1.Text != "V0.0.0"))
				{
					this.IDC_LABEL_BMSVER_1.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_BMSVER_1.ForeColor = Color.Red;
				}
				Label dCLABELBMSVER2 = this.IDC_LABEL_BMSVER_2;
				string[] str1 = new string[] { "V", null, null, null, null, null };
				int mSBMS2CmdMap = this.m_s_BMS_2_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] >> 8 & 15;
				str1[1] = mSBMS2CmdMap.ToString();
				str1[2] = ".";
				int mSBMS2CmdMap1 = this.m_s_BMS_2_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] >> 4 & 15;
				str1[3] = mSBMS2CmdMap1.ToString();
				str1[4] = ".";
				int mSBMS2CmdMap2 = this.m_s_BMS_2_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] & 15;
				str1[5] = mSBMS2CmdMap2.ToString();
				dCLABELBMSVER2.Text = string.Concat(str1);
				if (!(this.IDC_LABEL_BMSVER_2.Text != this.IDC_LABEL_BMSVER_SEL_2.Text) || !(this.IDC_LABEL_BMSVER_2.Text != "V0.0.0") || !(this.IDC_LABEL_BMSVER_SEL_2.Text != "V0.0.0"))
				{
					this.IDC_LABEL_BMSVER_2.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_BMSVER_2.ForeColor = Color.Red;
				}
				Label dCLABELBMSVERSEL3 = this.IDC_LABEL_BMSVER_SEL_3;
				string[] strArrays1 = new string[] { "V", null, null, null, null, null };
				int mSBMS3CmdMap = this.m_s_BMS_3_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] >> 8 & 15;
				strArrays1[1] = mSBMS3CmdMap.ToString();
				strArrays1[2] = ".";
				int mSBMS3CmdMap1 = this.m_s_BMS_3_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] >> 4 & 15;
				strArrays1[3] = mSBMS3CmdMap1.ToString();
				strArrays1[4] = ".";
				int mSBMS3CmdMap2 = this.m_s_BMS_3_CmdMap[MiniBatteryCmdMap.BMS_INF_FW_VERSION] & 15;
				strArrays1[5] = mSBMS3CmdMap2.ToString();
				dCLABELBMSVERSEL3.Text = string.Concat(strArrays1);
				if (!(this.IDC_LABEL_BMSVER_SEL_3.Text != this.IDC_LABEL_BMSVER_SEL_3.Text) || !(this.IDC_LABEL_BMSVER_SEL_3.Text != "V0.0.0") || !(this.IDC_LABEL_BMSVER_SEL_3.Text != "V0.0.0"))
				{
					this.IDC_LABEL_BMSVER_SEL_3.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_BMSVER_SEL_3.ForeColor = Color.Red;
				}
				Label dCLABELBLEVER = this.IDC_LABEL_BLEVER;
				string[] str2 = new string[] { "V", null, null, null, null, null };
				int mSCmdMap2 = this.m_s_CmdMap[NinebotCmd.NB_INF_VER_BLE] >> 8 & 15;
				str2[1] = mSCmdMap2.ToString();
				str2[2] = ".";
				int num2 = this.m_s_CmdMap[NinebotCmd.NB_INF_VER_BLE] >> 4 & 15;
				str2[3] = num2.ToString();
				str2[4] = ".";
				int mSCmdMap3 = this.m_s_CmdMap[NinebotCmd.NB_INF_VER_BLE] & 15;
				str2[5] = mSCmdMap3.ToString();
				dCLABELBLEVER.Text = string.Concat(str2);
				if (!(this.IDC_LABEL_BLEVER.Text != this.IDC_LABEL_BLEVER_SEL.Text) || !(this.IDC_LABEL_BLEVER.Text != "V0.0.0") || !(this.IDC_LABEL_BLEVER_SEL.Text != "V0.0.0"))
				{
					this.IDC_LABEL_BLEVER.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_BLEVER.ForeColor = Color.Red;
				}
				Label dCLABELUPCVER = this.IDC_LABEL_UPCVER;
				string[] strArrays2 = new string[] { "V", null, null, null, null, null };
				int num3 = this.m_s_CmdMap[NinebotCmd.NB_INF_UPC_VER] >> 8 & 15;
				strArrays2[1] = num3.ToString();
				strArrays2[2] = ".";
				int mSCmdMap4 = this.m_s_CmdMap[NinebotCmd.NB_INF_UPC_VER] >> 4 & 15;
				strArrays2[3] = mSCmdMap4.ToString();
				strArrays2[4] = ".";
				int num4 = this.m_s_CmdMap[NinebotCmd.NB_INF_UPC_VER] & 15;
				strArrays2[5] = num4.ToString();
				dCLABELUPCVER.Text = string.Concat(strArrays2);
				if (!(this.IDC_LABEL_UPCVER.Text != this.IDC_LABEL_UPCVER_SEL.Text) || !(this.IDC_LABEL_UPCVER.Text != "V0.0.0") || !(this.IDC_LABEL_UPCVER_SEL.Text != "V0.0.0"))
				{
					this.IDC_LABEL_UPCVER.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_UPCVER.ForeColor = Color.Red;
				}
				Label dCLABELANCVER = this.IDC_LABEL_ANCVER;
				string[] str3 = new string[] { "V", null, null, null, null, null };
				int mSCmdMap5 = this.m_s_CmdMap[NinebotCmd.NB_INF_ANC_VER] >> 8 & 15;
				str3[1] = mSCmdMap5.ToString();
				str3[2] = ".";
				int num5 = this.m_s_CmdMap[NinebotCmd.NB_INF_ANC_VER] >> 4 & 15;
				str3[3] = num5.ToString();
				str3[4] = ".";
				int mSCmdMap6 = this.m_s_CmdMap[NinebotCmd.NB_INF_ANC_VER] & 15;
				str3[5] = mSCmdMap6.ToString();
				dCLABELANCVER.Text = string.Concat(str3);
				if (!(this.IDC_LABEL_ANCVER.Text != this.IDC_LABEL_ANCVER_SEL.Text) || !(this.IDC_LABEL_ANCVER.Text != "V0.0.0") || !(this.IDC_LABEL_ANCVER_SEL.Text != "V0.0.0"))
				{
					this.IDC_LABEL_ANCVER.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_ANCVER.ForeColor = Color.Red;
				}
				Label dCLABELTAGVER = this.IDC_LABEL_TAGVER;
				string[] strArrays3 = new string[] { "V", null, null, null, null, null };
				int num6 = this.m_s_CmdMap[NinebotCmd.NB_INF_TAG_VER] >> 8 & 15;
				strArrays3[1] = num6.ToString();
				strArrays3[2] = ".";
				int mSCmdMap7 = this.m_s_CmdMap[NinebotCmd.NB_INF_TAG_VER] >> 4 & 15;
				strArrays3[3] = mSCmdMap7.ToString();
				strArrays3[4] = ".";
				int num7 = this.m_s_CmdMap[NinebotCmd.NB_INF_TAG_VER] & 15;
				strArrays3[5] = num7.ToString();
				dCLABELTAGVER.Text = string.Concat(strArrays3);
				if (!(this.IDC_LABEL_TAGVER.Text != this.IDC_LABEL_TAGVER_SEL.Text) || !(this.IDC_LABEL_TAGVER.Text != "V0.0.0") || !(this.IDC_LABEL_TAGVER_SEL.Text != "V0.0.0"))
				{
					this.IDC_LABEL_TAGVER.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_TAGVER.ForeColor = Color.Red;
				}
				Label dCLABELFEIMIVER = this.IDC_LABEL_FEIMIVER;
				string[] str4 = new string[] { "V", null, null, null, null, null };
				int mSCmdMap8 = this.m_s_CmdMap[NinebotCmd.NB_INF_FEIMI_VER] >> 8 & 15;
				str4[1] = mSCmdMap8.ToString();
				str4[2] = ".";
				int num8 = this.m_s_CmdMap[NinebotCmd.NB_INF_FEIMI_VER] >> 4 & 15;
				str4[3] = num8.ToString();
				str4[4] = ".";
				int mSCmdMap9 = this.m_s_CmdMap[NinebotCmd.NB_INF_FEIMI_VER] & 15;
				str4[5] = mSCmdMap9.ToString();
				dCLABELFEIMIVER.Text = string.Concat(str4);
				if (!(this.IDC_LABEL_FEIMIVER.Text != this.IDC_LABEL_FEIMIVER_SEL.Text) || !(this.IDC_LABEL_FEIMIVER.Text != "V0.0.0") || !(this.IDC_LABEL_FEIMIVER_SEL.Text != "V0.0.0"))
				{
					this.IDC_LABEL_FEIMIVER.ForeColor = Color.Blue;
				}
				else
				{
					this.IDC_LABEL_FEIMIVER.ForeColor = Color.Red;
				}
				if ((this.m_s_CmdMap[NinebotCmd.NB_INF_BOOL] & NinebotCmd.NB_BOOLMARK_LOCK) == 0)
				{
					this.IDC_BTN_LOCK.Enabled = true;
					this.IDC_BTN_UNLOCK.Enabled = false;
				}
				else
				{
					this.IDC_BTN_LOCK.Enabled = false;
					this.IDC_BTN_UNLOCK.Enabled = true;
				}
				if ((this.m_s_CmdMap[NinebotCmd.NB_INF_BOOL] & NinebotCmd.NB_BOOLMARK_ACT) == 0)
				{
					this.IDC_BTN_ACT.Enabled = true;
					this.IDC_BTN_UNACT.Enabled = false;
				}
				else
				{
					this.IDC_BTN_ACT.Enabled = false;
					this.IDC_BTN_UNACT.Enabled = true;
				}
			}
			this.IDC_LABEL_COUNT.Text = this.m_ui_RecvCount.ToString();
		}

		private void Timer_IAP_Tick(object sender, EventArgs e)
		{
			IAP_Form mUsIAPTimer = this;
			mUsIAPTimer.m_us_IAPTimer = (ushort)(mUsIAPTimer.m_us_IAPTimer + 1);
		}

		private void Timer_SendData_Tick(object sender, EventArgs e)
		{
			if (this.m_bol_ReadBack)
			{
				this.m_bol_ReadBack = false;
				this.m_b_NoDataCount = 0;
			}
			else
			{
				IAP_Form mBNoDataCount = this;
				mBNoDataCount.m_b_NoDataCount = (byte)(mBNoDataCount.m_b_NoDataCount + 1);
				if (this.m_b_NoDataCount >= 15)
				{
					this.m_b_NoDataCount = 15;
					this.m_ui_RecvCount = 0;
				}
			}
			if (!this.m_bol_IAPing)
			{
				switch (this.m_b_SendCount)
				{
					case 0:
					{
						this.ReadWords(NinebotCmd.NB_INF_SN, 7, this.m_DriverID);
						break;
					}
					case 1:
					{
						this.ReadWords(NinebotCmd.NB_CPUID_A, 6, this.m_DriverID);
						break;
					}
					case 2:
					{
						this.ReadWords(MiniBatteryCmdMap.BMS_INF_FW_VERSION, 1, this.m_BMSID_1);
						break;
					}
					case 3:
					{
						this.ReadWords(NinebotCmd.NB_INF_VER_BLE, 1, this.m_DriverID);
						break;
					}
					case 4:
					{
						this.ReadWords(NinebotCmd.NB_QUK_ERROR, 2, this.m_DriverID);
						break;
					}
					case 5:
					{
						this.ReadWords(NinebotCmd.NB_INF_FW_VERSION, 4, this.m_DriverID);
						break;
					}
					case 6:
					{
						this.ReadWords(NinebotCmd.NB_CTL_ASS_ZERO_PITCH, 1, this.m_DriverID);
						break;
					}
					case 7:
					{
						this.ReadWords(NinebotCmd.NB_INF_SYS_CUR, 5, this.m_DriverID);
						break;
					}
					case 8:
					{
						if (this.IDC_COMBO_CAR.Text == "Kickscooter" || this.IDC_COMBO_CAR.Text == "MK3" || this.IDC_COMBO_CAR.Text == "MK2")
						{
							this.ReadWords(MiniBatteryCmdMap.BMS_INF_FW_VERSION, 1, this.m_BMSID_2);
							break;
						}
						else
						{
							if (this.IDC_COMBO_CAR.Text != "Steeldust")
							{
								break;
							}
							this.ReadWords(MiniBatteryCmdMap.BMS_INF_FW_VERSION, 1, this.m_BMSID_2);
							Thread.Sleep(20);
							this.ReadWords(MiniBatteryCmdMap.BMS_INF_FW_VERSION, 1, this.m_BMSID_3);
							break;
						}
					}
					case 9:
					{
						this.ReadWords(MiniBatteryCmdMap.BMS_INF_CAP_COULO, 2, this.m_BMSID_1);
						break;
					}
					case 10:
					{
						this.ReadWords(MiniBatteryCmdMap.BMS_INF_CAP_COULO, 2, this.m_BMSID_2);
						Thread.Sleep(20);
						this.ReadWords(MiniBatteryCmdMap.BMS_INF_CAP_COULO, 2, this.m_BMSID_3);
						break;
					}
					case 11:
					{
						this.ReadWords(NinebotCmd.NB_INF_UPC_VER, 1, this.m_UPCID);
						break;
					}
					case 12:
					{
						this.ReadWords(NinebotCmd.NB_INF_ANC_VER, 2, this.m_ANCID);
						break;
					}
					case 13:
					{
						this.ReadWords(18, 1, this.m_UPCID);
						break;
					}
					case 14:
					{
						this.ReadWords(74, 4, this.m_FEIMIID);
						break;
					}
					case 15:
					{
						this.ReadWords(78, 2, this.m_FEIMIID);
						break;
					}
					case 16:
					{
						this.ReadWords(NinebotCmd.NB_INF_FEIMI_VER, 1, this.m_FEIMIID);
						break;
					}
				}
				if (this.IDC_COMBO_CAR.Text != "Plus")
				{
					IAP_Form aPForm = this;
					byte mBSendCount = (byte)(aPForm.m_b_SendCount + 1);
					byte num = mBSendCount;
					aPForm.m_b_SendCount = mBSendCount;
					if (num > 10)
					{
						this.m_b_SendCount = 0;
					}
				}
				else
				{
					IAP_Form aPForm1 = this;
					byte mBSendCount1 = (byte)(aPForm1.m_b_SendCount + 1);
					byte num1 = mBSendCount1;
					aPForm1.m_b_SendCount = mBSendCount1;
					if (num1 > 16)
					{
						this.m_b_SendCount = 0;
						return;
					}
				}
			}
		}

		private void Timer_Update_SN_ACT_Tick(object sender, EventArgs e)
		{
			if (this.m_bol_SNing)
			{
				return;
			}
			if (this.m_bol_Acting)
			{
				if (this.m_b_SNActTryCount >= 5)
				{
					this.m_bol_Acting = false;
					this.m_b_SNActTryCount = 0;
					this.IDC_EDIT_INFO.AppendText("\r\nVehicle activation failed！\r\n");
					return;
				}
				IAP_Form mBSNActTryCount = this;
				mBSNActTryCount.m_b_SNActTryCount = (byte)(mBSNActTryCount.m_b_SNActTryCount + 1);
				if ((this.m_s_CmdMap[NinebotCmd.NB_INF_BOOL] & NinebotCmd.NB_BOOLMARK_ACT) == 0)
				{
					this.IDC_BTN_ACT_Click(null, null);
					return;
				}
				this.m_bol_Acting = false;
				this.m_b_SNActTryCount = 0;
				this.IDC_EDIT_INFO.AppendText("\r\nVehicle activated！\r\n");
				return;
			}
			if (this.m_bol_UnActing)
			{
				if (this.m_b_SNActTryCount < 5)
				{
					IAP_Form aPForm = this;
					aPForm.m_b_SNActTryCount = (byte)(aPForm.m_b_SNActTryCount + 1);
					if ((this.m_s_CmdMap[NinebotCmd.NB_INF_BOOL] & NinebotCmd.NB_BOOLMARK_ACT) != 0)
					{
						this.IDC_BTN_UNACT_Click(null, null);
						return;
					}
					this.m_bol_UnActing = false;
					this.m_b_SNActTryCount = 0;
					this.IDC_EDIT_INFO.AppendText("\r\nThe vehicle has been restored to the factory state！\r\n");
					return;
				}
				this.m_bol_UnActing = false;
				this.m_b_SNActTryCount = 0;
				this.IDC_EDIT_INFO.AppendText("\r\nVehicle recovery failed！\r\n");
			}
		}

		private enum IAP_INFO
		{
			IAP_DRIVER,
			IAP_BMS_1,
			IAP_BMS_2,
			IAP_BMS_3,
			IAP_BLE,
			IAP_UPC,
			IAP_ANC,
			IAP_TAG,
			IAP_FEIMI,
			IAP_CHANNAL
		}

		private enum IAP_RESULT
		{
			IAP_OK,
			IAPERROR_SIZE,
			IAPERROR_ERASE,
			IAPERROR_WRITEFLASH,
			IAPERROR_UNLOCK,
			IAPERROR_INDEX,
			IAPERROR_BUSY,
			IAPERROR_FORM,
			IAPERROR_CRC,
			IAPERROR_OTHER
		}

		private enum NEW_COM
		{
			COM_LEN,
			COM_ID,
			COM_ME,
			COM_CMD,
			COM_INDEX,
			COM_DATA
		}

		private enum OLD_COM
		{
			COM_LEN,
			COM_ID,
			COM_CMD,
			COM_INDEX,
			COM_DATA
		}
	}
}