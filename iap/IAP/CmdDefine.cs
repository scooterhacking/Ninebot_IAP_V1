using System;

namespace IAP
{
	internal class CmdDefine
	{
		public static byte CMD_BLE_MST_SCAN;

		public static byte CMD_BLE_MST_RESET;

		public static byte CMD_BLE_MST_SEND_NAME;

		public static byte CMD_BLE_MST_CONN_NAME;

		public static byte CMD_BLE_MST_CONN_OK;

		public static byte CMD_BLE_MST_CONN;

		public static byte BLE_MASTER_ID;

		public static byte V_FEIMI_ID;

		public static byte V_PC_ID;

		public static byte V_BLE_ID;

		public static byte V_CAN_ID;

		public static byte V_UPC_ID;

		public static byte V_ANC_ID;

		public static byte V_TAG_ID;

		public static byte V_Plus_ID;

		public static byte V_Plus_DIS_ID;

		public static byte V_Plus_BMS_ID;

		public static byte V_KART_ID;

		public static byte V_MK3_ID;

		public static byte V_MK3_DIS_ID;

		public static byte V_MK3_BMS_ID1;

		public static byte V_MK3_BMS_ID2;

		public static byte V_SCOOTER_ID;

		public static byte V_SCOOTER_DIS_ID;

		public static byte V_SCOOTER_BMS_ID1;

		public static byte V_SCOOTER_BMS_ID2;

		public static byte V_Nano_ID;

		public static byte V_Nano_DIS_ID;

		public static byte V_Nano_BMS_ID;

		public static byte V_STEELDUST_ECU_ID;

		public static byte V_STEELDUST_MCU_ID;

		public static byte V_STEELDUST_DIS_ID;

		public static byte V_STEELDUST_BLE_ID;

		public static byte V_STEELDUST_BMS1_ID;

		public static byte V_STEELDUST_BMS2_ID;

		public static byte V_STEELDUST_BMS3_ID;

		public static byte V_STEELDUST_MQTT_ID;

		public static byte V_STEELDUST_MC20_ID;

		public static byte V_STEELDUST_NEW_BROADCAST_ID;

		public static byte V_MINI_ID;

		public static byte V_MINI_DIS_ID;

		public static byte V_MINI_BMS_ID;

		public static byte V_MINI_R_ID;

		public static byte V_MINI_DIS_R_ID;

		public static byte V_MINI_BMS_R_ID;

		public static byte V_ESC_ID;

		public static byte V_ESC_DIS_ID;

		public static byte V_ESC_BMS_ID;

		public static byte V_ESC_R_ID;

		public static byte V_ESC_DIS_R_ID;

		public static byte V_ESC_BMS_R_ID;

		public static byte V_MK2_ID;

		public static byte V_MK2_DIS_ID;

		public static byte V_MK2_BMS1_ID;

		public static byte V_MK2_BMS2_ID;

		public static byte V_MK2_R_ID;

		public static byte V_MK2_DIS_R_ID;

		public static byte V_MK2_BMS1_R_ID;

		public static byte V_MK2_BMS2_R_ID;

		public static byte CMD_RD;

		public static byte CMD_WR;

		public static byte CMD_WR_NR;

		public static byte CMD_SYNC;

		public static byte CMD_EXRD;

		public static byte CMD_CLEARERROR;

		public static byte CMD_IAP_BEGIN;

		public static byte CMD_IAP_WR;

		public static byte CMD_IAP_CRC;

		public static byte CMD_IAP_RESET;

		public static byte CMD_IAP_ACK;

		public static byte CMD_POWER_OFF;

		public static byte CMD_CTL;

		public static byte CMD_CTL_WR_SN;

		public static byte CMD_CTL_CALIB;

		public static byte CMD_CTL_SAVEFLASH;

		public static byte CMD_CTL_TEST;

		public static byte CMD_CTL_SENDDRVD;

		public static byte CMD_CTL_STOPDRVD;

		public static byte CMD_CTL_SENDPADD;

		public static byte CMD_CTL_STOPPADD;

		public static byte CMD_DRV;

		public static byte CMD_DRV_SCP;

		public static byte CMD_DRV_VELOCITY_NOI;

		public static byte CMD_DRV_VELOCITY;

		public static byte CMD_DRV_CHECK;

		public static byte CMD_DRV_PWMDIS;

		public static byte CMD_DRV_BEEP;

		public static byte CMD_DRV_POWON_S;

		public static byte CMD_DRV_POWERON;

		public static byte CMD_DRV_POWEROFF;

		public static byte CMD_DRV_SCP_LONG;

		public static byte CMD_AHRS;

		public static byte CMD_AHRS_EXRD;

		public static byte CMD_AHRS_BRC;

		public static byte CMD_ONE_CALIB_VOLT;

		public static byte CMD_MINI_SET_BTNAME;

		public static byte CMD_MINI_BEEP;

		public static byte CMD_MINI_BMS_SET_LOCKBIT;

		public static byte CMD_MINI_POWRERON;

		public static byte CMD_MINI_POWREROFF;

		public static byte CMD_MINI_HEARTBEAT;

		public static byte CMD_MINI_TEST_MODE;

		public static byte CMD_MINI_ACT;

		public static byte CMD_MINI_UNACT;

		public static byte CMD_MINI_ACTALL;

		public static byte CMD_MINI_ACT_BATTERY_ONLY;

		public static byte CMD_MINI_UNACT_BATTERY_ONLY;

		public static byte NB_INF_VER_BMS;

		public static byte NB_INF_VER_BLE;

		public static byte NB_CTL_LOCK;

		public static byte NB_CTL_UNLOCK;

		public static byte NB_CTL_SPEED_LIMIT;

		public static byte NB_CTL_NOMALSPEED;

		public static byte NB_CTL_LITSPEED;

		public static byte NB_CTL_CALIB_GYRO;

		public static byte NB_CTL_CALIB_EULAR;

		public static byte NB_CTL_ENGINE;

		public static byte NB_CTL_REBOOT;

		public static byte NB_CTL_POWEROFF;

		public static byte NB_CTL_REMOTE;

		public static byte NB_CTL_REM_SPD;

		public static byte NB_CTL_REM_DIF_SPD;

		public static byte NB_CTL_REM_MAX_SPD;

		public static byte NB_CTL_REM_MAX_DIF_SPD;

		public static byte NB_CTL_REM_MAX_ACC;

		public static short NB_CMDMAP_LEN;

		public static int IAP_CHANNEL_NUM;

		public static int IAP_CH_CTRL;

		public static int IAP_CH_DRIVER;

		public static int IAP_CH_BMS;

		public static int IAP_CH_BLE;

		static CmdDefine()
		{
			CmdDefine.CMD_BLE_MST_SCAN = 241;
			CmdDefine.CMD_BLE_MST_RESET = 242;
			CmdDefine.CMD_BLE_MST_SEND_NAME = 243;
			CmdDefine.CMD_BLE_MST_CONN_NAME = 244;
			CmdDefine.CMD_BLE_MST_CONN_OK = 245;
			CmdDefine.CMD_BLE_MST_CONN = 246;
			CmdDefine.BLE_MASTER_ID = 255;
			CmdDefine.V_FEIMI_ID = 12;
			CmdDefine.V_PC_ID = 61;
			CmdDefine.V_BLE_ID = 62;
			CmdDefine.V_CAN_ID = 63;
			CmdDefine.V_UPC_ID = 8;
			CmdDefine.V_ANC_ID = 9;
			CmdDefine.V_TAG_ID = 10;
			CmdDefine.V_Plus_ID = 4;
			CmdDefine.V_Plus_DIS_ID = 6;
			CmdDefine.V_Plus_BMS_ID = 7;
			CmdDefine.V_KART_ID = 12;
			CmdDefine.V_MK3_ID = 20;
			CmdDefine.V_MK3_DIS_ID = 22;
			CmdDefine.V_MK3_BMS_ID1 = 17;
			CmdDefine.V_MK3_BMS_ID2 = 18;
			CmdDefine.V_SCOOTER_ID = 32;
			CmdDefine.V_SCOOTER_DIS_ID = 33;
			CmdDefine.V_SCOOTER_BMS_ID1 = 34;
			CmdDefine.V_SCOOTER_BMS_ID2 = 35;
			CmdDefine.V_Nano_ID = 36;
			CmdDefine.V_Nano_DIS_ID = 38;
			CmdDefine.V_Nano_BMS_ID = 39;
			CmdDefine.V_STEELDUST_ECU_ID = 1;
			CmdDefine.V_STEELDUST_MCU_ID = 2;
			CmdDefine.V_STEELDUST_DIS_ID = 3;
			CmdDefine.V_STEELDUST_BLE_ID = 4;
			CmdDefine.V_STEELDUST_BMS1_ID = 5;
			CmdDefine.V_STEELDUST_BMS2_ID = 6;
			CmdDefine.V_STEELDUST_BMS3_ID = 7;
			CmdDefine.V_STEELDUST_MQTT_ID = 8;
			CmdDefine.V_STEELDUST_MC20_ID = 9;
			CmdDefine.V_STEELDUST_NEW_BROADCAST_ID = 61;
			CmdDefine.V_MINI_ID = 10;
			CmdDefine.V_MINI_DIS_ID = 11;
			CmdDefine.V_MINI_BMS_ID = 12;
			CmdDefine.V_MINI_R_ID = 13;
			CmdDefine.V_MINI_DIS_R_ID = 14;
			CmdDefine.V_MINI_BMS_R_ID = 15;
			CmdDefine.V_ESC_ID = 32;
			CmdDefine.V_ESC_DIS_ID = 33;
			CmdDefine.V_ESC_BMS_ID = 34;
			CmdDefine.V_ESC_R_ID = 35;
			CmdDefine.V_ESC_DIS_R_ID = 36;
			CmdDefine.V_ESC_BMS_R_ID = 37;
			CmdDefine.V_MK2_ID = 17;
			CmdDefine.V_MK2_DIS_ID = 11;
			CmdDefine.V_MK2_BMS1_ID = 19;
			CmdDefine.V_MK2_BMS2_ID = 20;
			CmdDefine.V_MK2_R_ID = 17;
			CmdDefine.V_MK2_DIS_R_ID = 14;
			CmdDefine.V_MK2_BMS1_R_ID = 19;
			CmdDefine.V_MK2_BMS2_R_ID = 20;
			CmdDefine.CMD_RD = 1;
			CmdDefine.CMD_WR = 2;
			CmdDefine.CMD_WR_NR = 3;
			CmdDefine.CMD_SYNC = 4;
			CmdDefine.CMD_EXRD = 5;
			CmdDefine.CMD_CLEARERROR = 6;
			CmdDefine.CMD_IAP_BEGIN = 7;
			CmdDefine.CMD_IAP_WR = 8;
			CmdDefine.CMD_IAP_CRC = 9;
			CmdDefine.CMD_IAP_RESET = 10;
			CmdDefine.CMD_IAP_ACK = 11;
			CmdDefine.CMD_POWER_OFF = 11;
			CmdDefine.CMD_CTL = 16;
			CmdDefine.CMD_CTL_WR_SN = 24;
			CmdDefine.CMD_CTL_CALIB = 17;
			CmdDefine.CMD_CTL_SAVEFLASH = 18;
			CmdDefine.CMD_CTL_TEST = 19;
			CmdDefine.CMD_CTL_SENDDRVD = 20;
			CmdDefine.CMD_CTL_STOPDRVD = 21;
			CmdDefine.CMD_CTL_SENDPADD = 22;
			CmdDefine.CMD_CTL_STOPPADD = 23;
			CmdDefine.CMD_DRV = 32;
			CmdDefine.CMD_DRV_SCP = 32;
			CmdDefine.CMD_DRV_VELOCITY_NOI = 33;
			CmdDefine.CMD_DRV_VELOCITY = 34;
			CmdDefine.CMD_DRV_CHECK = 35;
			CmdDefine.CMD_DRV_PWMDIS = 36;
			CmdDefine.CMD_DRV_BEEP = 37;
			CmdDefine.CMD_DRV_POWON_S = 38;
			CmdDefine.CMD_DRV_POWERON = 39;
			CmdDefine.CMD_DRV_POWEROFF = 40;
			CmdDefine.CMD_DRV_SCP_LONG = 41;
			CmdDefine.CMD_AHRS = 48;
			CmdDefine.CMD_AHRS_EXRD = 48;
			CmdDefine.CMD_AHRS_BRC = 49;
			CmdDefine.CMD_ONE_CALIB_VOLT = 50;
			CmdDefine.CMD_MINI_SET_BTNAME = 80;
			CmdDefine.CMD_MINI_BEEP = 81;
			CmdDefine.CMD_MINI_BMS_SET_LOCKBIT = 82;
			CmdDefine.CMD_MINI_POWRERON = 83;
			CmdDefine.CMD_MINI_POWREROFF = 84;
			CmdDefine.CMD_MINI_HEARTBEAT = 85;
			CmdDefine.CMD_MINI_TEST_MODE = 86;
			CmdDefine.CMD_MINI_ACT = 87;
			CmdDefine.CMD_MINI_UNACT = 88;
			CmdDefine.CMD_MINI_ACTALL = 89;
			CmdDefine.CMD_MINI_ACT_BATTERY_ONLY = 90;
			CmdDefine.CMD_MINI_UNACT_BATTERY_ONLY = 91;
			CmdDefine.NB_INF_VER_BMS = 103;
			CmdDefine.NB_INF_VER_BLE = 104;
			CmdDefine.NB_CTL_LOCK = 112;
			CmdDefine.NB_CTL_UNLOCK = 113;
			CmdDefine.NB_CTL_SPEED_LIMIT = 114;
			CmdDefine.NB_CTL_NOMALSPEED = 115;
			CmdDefine.NB_CTL_LITSPEED = 116;
			CmdDefine.NB_CTL_CALIB_GYRO = 117;
			CmdDefine.NB_CTL_CALIB_EULAR = 118;
			CmdDefine.NB_CTL_ENGINE = 119;
			CmdDefine.NB_CTL_REBOOT = 120;
			CmdDefine.NB_CTL_POWEROFF = 121;
			CmdDefine.NB_CTL_REMOTE = 122;
			CmdDefine.NB_CTL_REM_SPD = 123;
			CmdDefine.NB_CTL_REM_DIF_SPD = 124;
			CmdDefine.NB_CTL_REM_MAX_SPD = 125;
			CmdDefine.NB_CTL_REM_MAX_DIF_SPD = 126;
			CmdDefine.NB_CTL_REM_MAX_ACC = 127;
			CmdDefine.NB_CMDMAP_LEN = 256;
			CmdDefine.IAP_CHANNEL_NUM = 4;
			CmdDefine.IAP_CH_CTRL = 0;
			CmdDefine.IAP_CH_DRIVER = 1;
			CmdDefine.IAP_CH_BMS = 2;
			CmdDefine.IAP_CH_BLE = 3;
		}

		public CmdDefine()
		{
		}
	}
}