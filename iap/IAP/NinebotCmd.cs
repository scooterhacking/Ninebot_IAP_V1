using System;

namespace IAP
{
	internal class NinebotCmd
	{
		public const byte CMD_CMAP_WR_NR = 3;

		public static byte CMD_CMAP_RD;

		public static byte CMD_CMAP_WR;

		public static byte CMD_CMAP_ACK_RD;

		public static byte CMD_CMAP_ACK_WR;

		public static short NB_CMDMAP_LEN;

		public static byte NB_CMDMAP_INDLEN;

		public static byte NB_CMDMAP_SUBLEN;

		public static byte NB_INF_UPC_VER;

		public static byte NB_INF_ANC_VER;

		public static byte NB_INF_TAG_VER;

		public static byte NB_INF_FEIMI_VER;

		public static byte NB_QUK_ERROR;

		public static byte NB_QUK_ALERM;

		public static byte NB_QUK_BOOL;

		public static byte NB_QUK_WORKMODE;

		public static byte NB_QUK_BTC;

		public static byte NB_QUK_SPEED;

		public static byte NB_QUK_AVRSPEED;

		public static byte NB_QUK_RID_MIL_L;

		public static byte NB_QUK_RID_MIL_H;

		public static byte NB_QUK_RID_MIL_SIG;

		public static byte NB_QUK_RUN_TIM_SIG;

		public static byte NB_QUK_BODY_TEMP;

		public static byte NB_QUK_DRV_VOLT;

		public static byte NB_QUK_SYS_CUR;

		public static byte NB_QUK_SYS_TOP_SPD;

		public static byte NB_INF_SN;

		public static byte NB_INF_BTPASSWORD;

		public static byte NB_INF_FW_VERSION;

		public static byte NB_INF_ERROR;

		public static byte NB_INF_ALERM;

		public static byte NB_INF_BOOL;

		public static byte NB_INF_WORKMODE;

		public static byte NB_INF_STEP_SWITCH;

		public static byte NB_INF_LINK_ANGLE;

		public static byte NB_INF_BTC;

		public static byte NB_INF_CRT_LIT_SPEED;

		public static byte NB_INF_PRD_RID_MIL;

		public static byte NB_INF_SPEED;

		public static byte NB_INF_SPEED_L;

		public static byte NB_INF_SPEED_R;

		public static byte NB_INF_RID_MIL_L;

		public static byte NB_INF_RID_MIL_H;

		public static byte NB_INF_ASS_MIL_L;

		public static byte NB_INF_ASS_MIL_H;

		public static byte NB_INF_REM_MIL_L;

		public static byte NB_INF_REM_MIL_H;

		public static byte NB_INF_RID_MIL_SIG;

		public static byte NB_INF_ASS_MIL_SIG;

		public static byte NB_INF_REM_MIL_SIG;

		public static byte NB_INF_RUN_TIM_L;

		public static byte NB_INF_RUN_TIM_H;

		public static byte NB_INF_RID_TIM_L;

		public static byte NB_INF_RID_TIM_H;

		public static byte NB_INF_ASS_TIM_L;

		public static byte NB_INF_ASS_TIM_H;

		public static byte NB_INF_REM_TIM_L;

		public static byte NB_INF_REM_TIM_H;

		public static byte NB_INF_RUN_TIM_SIG;

		public static byte NB_INF_RID_TIM_SIG;

		public static byte NB_INF_ASS_TIM_SIG;

		public static byte NB_INF_REM_TIM_SIG;

		public static byte NB_INF_BODY_TEMP;

		public static byte NB_INF_BAT1_TEMP;

		public static byte NB_INF_BAT2_TEMP;

		public static byte NB_INF_DRV_VOLT;

		public static byte NB_INF_BAT_VOLT_1;

		public static byte NB_INF_BAT_VOLT_2;

		public static byte NB_INF_SYS1_VOLT_12;

		public static byte NB_INF_SYS1_VOLT_5;

		public static byte NB_INF_SYS_CUR;

		public static byte NB_INF_MOT11_CURT_P;

		public static byte NB_INF_MOT12_CURT_P;

		public static byte NB_INF_YAW_ANGLE;

		public static byte NB_INF_YAW_RATE;

		public static byte NB_INF_PITCH_ANGLE;

		public static byte NB_INF_ROLL_ANGLE;

		public static byte NB_INF_PITCH_RATE;

		public static byte NB_INF_ROLL_RATE;

		public static byte NB_INF_AVRSPEED;

		public static byte NB_INF_VER_BMS;

		public static byte NB_INF_VER_BLE;

		public static byte NB_INF_ACT_DATE;

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

		public static byte NB_CTL_DOTRENEW;

		public static byte NB_CTL_IS_XIAOMI;

		public static byte NB_CTL_STR_SENS;

		public static byte NB_CTL_HARDNESS;

		public static byte NB_CTL_ASS_ZERO_PITCH;

		public static byte NB_CTL_IS_CHILDREN_MODE;

		public static byte NB_CTL_LIMIT_ONEFOOT;

		public static byte NB_CTL_TECHING_STEP;

		public static byte NB_CTL_TECHING_LEFT_ANGLE;

		public static byte NB_CTL_TECHING_RIGHT_ANGLE;

		public static byte NB_ONE_SYSVOLT_GAIN;

		public static byte NB_ONE_RESET_COUNT;

		public static byte NB_ONE_PITCH_OFFSET;

		public static byte NB_ONE_GYRO_OFFSET_X;

		public static byte NB_ONE_GYRO_OFFSET_Z;

		public static byte NB_ONE_GYRO_OFFSET_Y;

		public static byte NB_ONE_LED_MODE;

		public static byte NB_ONE_LED_NUM;

		public static byte NB_ONE_LED_COLOR1;

		public static byte NB_ONE_LED_COLOR2;

		public static byte NB_ONE_LED_COLOR3;

		public static byte NB_ONE_LED_COLOR4;

		public static byte MINI_CTL_FUN_BOOL;

		public static byte NB_CPUID_A;

		public static byte NB_CPUID_B;

		public static byte NB_CPUID_C;

		public static byte NB_CPUID_D;

		public static byte NB_CPUID_E;

		public static byte NB_CPUID_F;

		public static ushort NB_FUN_BOOLMARK_FLIGHT;

		public static ushort NB_FUN_BOOLMARK_BREAKLED;

		public static ushort NB_FUN_BOOLMARK_POWEROFF_AT_LOCK;

		public static ushort NB_FUN_BOOLMARK_NO_ALARM_AT_LOCK;

		public static ushort NB_FUN_BOOLMARK_CHILDREN_MODE;

		public static ushort NB_FUN_BOOLMARK_HIGH_SPEE;

		public static ushort NB_BOOLMARK_LIMITSPEED;

		public static ushort NB_BOOLMARK_LOCK;

		public static ushort NB_BOOLMARK_BEEP;

		public static ushort NB_BOOLMARK_REMOTECTRL;

		public static ushort NB_BOOLMARK_VOERTEMP;

		public static ushort NB_BOOLMARK_STUDENT_DRIVER;

		public static ushort NB_BOOLMARK_APPROVED_DRIVER;

		public static ushort NB_BOOLMARK_FACTORY_TEST_MODE;

		public static ushort NB_BOOLMARK_MENON;

		public static ushort NB_BOOLMARK_ACT;

		public static ushort NB_BOOLMARK_TEACHED;

		public static ushort NB_BOOLMARK_TEACH_STEP_OK;

		public static ushort NB_BOOLMARK_BE_LIFTED;

		public static ushort NB_BOOLMARK_BOTH_FEET;

		public static byte NB_WORKMODE_STANDBY;

		public static byte NB_WORKMODE_ASSIST;

		public static byte NB_WORKMODE_NORMAL;

		public static byte NB_WORKMODE_LOCK;

		public static byte NB_WORKMODE_REMOTE;

		public static byte MINI_BLED_MODE_CLOSE;

		public static byte MINI_BLED_MODE_1COLOR;

		public static byte MINI_BLED_MODE_ALLCOLOR;

		public static byte MINI_BLED_MODE_2C_APART;

		public static byte MINI_BLED_MODE_ALLC_APART;

		public static byte MINI_BLED_MODE_1C_STAR;

		public static byte MINI_BLED_MODE_ALLC_STAR;

		public static byte MINI_BLED_MODE_POLICE;

		public static byte MINI_BLED_MODE_POLICE_2;

		public static byte MINI_BLED_MODE_POLICE_3;

		public static byte MINI_ERROR_CODE_VCCP;

		public static byte MINI_ERROR_CODE_SYS_SW_ON;

		public static byte MINI_ERROR_CODE_BAT_POW_CTRL;

		public static byte MINI_ERROR_CODE_KEY_POW_CTRL;

		public static byte MINI_ERROR_CODE_12V;

		public static byte MINI_ERROR_CODE_5V;

		public static byte MINI_ERROR_CODE_3V3;

		public static byte MINI_ERROR_CODE_TEST_MODE;

		public static byte MINI_ERROR_CODE_XTL;

		public static byte MINI_ERROR_CODE_ADC_PHA;

		public static byte MINI_ERROR_CODE_ADC_PHB;

		public static byte MINI_ERROR_CODE_ADC_PHC;

		public static byte MINI_ERROR_CODE_ADC_PHA2;

		public static byte MINI_ERROR_CODE_ADC_PHB2;

		public static byte MINI_ERROR_CODE_ADC_PHC2;

		public static byte MINI_BMS_ERROR_VERSION;

		public static byte MINI_ERROR_CODE_FSW1;

		public static byte MINI_ERROR_CODE_FSW2;

		public static byte MINI_ERROR_CODE_LHALL;

		public static byte MINI_ERROR_CODE_HX711;

		public static byte MINI_BMS_ERROR_COM;

		public static byte MINI_BMS_ERROR_PASSWORD;

		public static byte MINI_ERROR_COM_BLE;

		public static byte MINI_ERROR_CODE_SYS_VOL;

		public static byte MINI_ERROR_CODE_POWER_OFF;

		public static byte MINI_ERROR_FLASH;

		public static byte MINI_ERROR_PASSWORD;

		public static byte MINI_ERROR_CODE_AHRS;

		public static byte MINI_ERROR_CODE_DRIVER1;

		public static byte MINI_ERROR_CODE_DRIVER2;

		public static byte MINI_ERROR_JUMP;

		public static byte MINI_ERROR_CODE_6DS3;

		public static byte MINI_ERROR_CODE_HALL1_A;

		public static byte MINI_ERROR_CODE_HALL1_B;

		public static byte MINI_ERROR_CODE_HALL1_C;

		public static byte MINI_ERROR_CODE_HALL2_A;

		public static byte MINI_ERROR_CODE_HALL2_B;

		public static byte MINI_ERROR_CODE_HALL2_C;

		public static byte MINI_ERROR_CODE_COM;

		public static byte MINI_ERROR_CODE_HX711_SIMPLE;

		public static byte MINI_ERROR_CODE_SMT_PMOS;

		public static byte MINI_ERROR_CODE_SMT_NMOS;

		public static byte MINI_BMS_ERROR_TEMP;

		public static byte MINI_BMS_ERROR_CELL_VOL;

		public static ushort NB_ALARM_MARK_LOWPOWER;

		public static ushort NB_ALARM_MARK_BACKWARD;

		public static ushort NB_ALARM_MARK_OVERTEMP;

		public static ushort NB_ALARM_MARK_OVERLOAD;

		public static ushort NB_ALARM_MARK_OVERANGLE;

		public static ushort NB_ALARM_MARK_LOCKED;

		public static ushort NB_ALARM_MARK_SPEED;

		public static ushort NB_ALARM_MARK_HIGH_VOL;

		public static ushort NB_ALARM_MARK_OVERPWM;

		public static ushort NB_ALARM_MARK_OVERWATT;

		public static ushort NB_ALARM_MARK_CURRENT;

		public static ushort NB_ALARM_MARK_LOWTEMP;

		public static ushort NB_ALARM_MARK_TEST;

		static NinebotCmd()
		{
			NinebotCmd.CMD_CMAP_RD = 1;
			NinebotCmd.CMD_CMAP_WR = 2;
			NinebotCmd.CMD_CMAP_ACK_RD = 4;
			NinebotCmd.CMD_CMAP_ACK_WR = 5;
			NinebotCmd.NB_CMDMAP_LEN = 256;
			NinebotCmd.NB_CMDMAP_INDLEN = 16;
			NinebotCmd.NB_CMDMAP_SUBLEN = 16;
			NinebotCmd.NB_INF_UPC_VER = 10;
			NinebotCmd.NB_INF_ANC_VER = 11;
			NinebotCmd.NB_INF_TAG_VER = 12;
			NinebotCmd.NB_INF_FEIMI_VER = 13;
			NinebotCmd.NB_QUK_ERROR = 176;
			NinebotCmd.NB_QUK_ALERM = 177;
			NinebotCmd.NB_QUK_BOOL = 178;
			NinebotCmd.NB_QUK_WORKMODE = 179;
			NinebotCmd.NB_QUK_BTC = 180;
			NinebotCmd.NB_QUK_SPEED = 181;
			NinebotCmd.NB_QUK_AVRSPEED = 182;
			NinebotCmd.NB_QUK_RID_MIL_L = 183;
			NinebotCmd.NB_QUK_RID_MIL_H = 184;
			NinebotCmd.NB_QUK_RID_MIL_SIG = 185;
			NinebotCmd.NB_QUK_RUN_TIM_SIG = 186;
			NinebotCmd.NB_QUK_BODY_TEMP = 187;
			NinebotCmd.NB_QUK_DRV_VOLT = 188;
			NinebotCmd.NB_QUK_SYS_CUR = 189;
			NinebotCmd.NB_QUK_SYS_TOP_SPD = 191;
			NinebotCmd.NB_INF_SN = 16;
			NinebotCmd.NB_INF_BTPASSWORD = 23;
			NinebotCmd.NB_INF_FW_VERSION = 26;
			NinebotCmd.NB_INF_ERROR = 27;
			NinebotCmd.NB_INF_ALERM = 28;
			NinebotCmd.NB_INF_BOOL = 29;
			NinebotCmd.NB_INF_WORKMODE = 31;
			NinebotCmd.NB_INF_STEP_SWITCH = 32;
			NinebotCmd.NB_INF_LINK_ANGLE = 33;
			NinebotCmd.NB_INF_BTC = 34;
			NinebotCmd.NB_INF_CRT_LIT_SPEED = 35;
			NinebotCmd.NB_INF_PRD_RID_MIL = 37;
			NinebotCmd.NB_INF_SPEED = 38;
			NinebotCmd.NB_INF_SPEED_L = 39;
			NinebotCmd.NB_INF_SPEED_R = 40;
			NinebotCmd.NB_INF_RID_MIL_L = 41;
			NinebotCmd.NB_INF_RID_MIL_H = 42;
			NinebotCmd.NB_INF_ASS_MIL_L = 43;
			NinebotCmd.NB_INF_ASS_MIL_H = 44;
			NinebotCmd.NB_INF_REM_MIL_L = 45;
			NinebotCmd.NB_INF_REM_MIL_H = 46;
			NinebotCmd.NB_INF_RID_MIL_SIG = 47;
			NinebotCmd.NB_INF_ASS_MIL_SIG = 48;
			NinebotCmd.NB_INF_REM_MIL_SIG = 49;
			NinebotCmd.NB_INF_RUN_TIM_L = 50;
			NinebotCmd.NB_INF_RUN_TIM_H = 51;
			NinebotCmd.NB_INF_RID_TIM_L = 52;
			NinebotCmd.NB_INF_RID_TIM_H = 53;
			NinebotCmd.NB_INF_ASS_TIM_L = 54;
			NinebotCmd.NB_INF_ASS_TIM_H = 55;
			NinebotCmd.NB_INF_REM_TIM_L = 56;
			NinebotCmd.NB_INF_REM_TIM_H = 57;
			NinebotCmd.NB_INF_RUN_TIM_SIG = 58;
			NinebotCmd.NB_INF_RID_TIM_SIG = 59;
			NinebotCmd.NB_INF_ASS_TIM_SIG = 60;
			NinebotCmd.NB_INF_REM_TIM_SIG = 61;
			NinebotCmd.NB_INF_BODY_TEMP = 62;
			NinebotCmd.NB_INF_BAT1_TEMP = 63;
			NinebotCmd.NB_INF_BAT2_TEMP = 64;
			NinebotCmd.NB_INF_DRV_VOLT = 71;
			NinebotCmd.NB_INF_BAT_VOLT_1 = 72;
			NinebotCmd.NB_INF_BAT_VOLT_2 = 73;
			NinebotCmd.NB_INF_SYS1_VOLT_12 = 74;
			NinebotCmd.NB_INF_SYS1_VOLT_5 = 75;
			NinebotCmd.NB_INF_SYS_CUR = 80;
			NinebotCmd.NB_INF_MOT11_CURT_P = 83;
			NinebotCmd.NB_INF_MOT12_CURT_P = 84;
			NinebotCmd.NB_INF_YAW_ANGLE = 95;
			NinebotCmd.NB_INF_YAW_RATE = 96;
			NinebotCmd.NB_INF_PITCH_ANGLE = 97;
			NinebotCmd.NB_INF_ROLL_ANGLE = 98;
			NinebotCmd.NB_INF_PITCH_RATE = 99;
			NinebotCmd.NB_INF_ROLL_RATE = 100;
			NinebotCmd.NB_INF_AVRSPEED = 101;
			NinebotCmd.NB_INF_VER_BMS = 103;
			NinebotCmd.NB_INF_VER_BLE = 104;
			NinebotCmd.NB_INF_ACT_DATE = 105;
			NinebotCmd.NB_CTL_LOCK = 112;
			NinebotCmd.NB_CTL_UNLOCK = 113;
			NinebotCmd.NB_CTL_SPEED_LIMIT = 114;
			NinebotCmd.NB_CTL_NOMALSPEED = 115;
			NinebotCmd.NB_CTL_LITSPEED = 116;
			NinebotCmd.NB_CTL_CALIB_GYRO = 117;
			NinebotCmd.NB_CTL_CALIB_EULAR = 118;
			NinebotCmd.NB_CTL_ENGINE = 119;
			NinebotCmd.NB_CTL_REBOOT = 120;
			NinebotCmd.NB_CTL_POWEROFF = 121;
			NinebotCmd.NB_CTL_REMOTE = 122;
			NinebotCmd.NB_CTL_REM_SPD = 123;
			NinebotCmd.NB_CTL_REM_DIF_SPD = 124;
			NinebotCmd.NB_CTL_REM_MAX_SPD = 125;
			NinebotCmd.NB_CTL_REM_MAX_DIF_SPD = 126;
			NinebotCmd.NB_CTL_REM_MAX_ACC = 127;
			NinebotCmd.NB_CTL_DOTRENEW = 155;
			NinebotCmd.NB_CTL_IS_XIAOMI = 160;
			NinebotCmd.NB_CTL_STR_SENS = 161;
			NinebotCmd.NB_CTL_HARDNESS = 162;
			NinebotCmd.NB_CTL_ASS_ZERO_PITCH = 163;
			NinebotCmd.NB_CTL_IS_CHILDREN_MODE = 164;
			NinebotCmd.NB_CTL_LIMIT_ONEFOOT = 165;
			NinebotCmd.NB_CTL_TECHING_STEP = 166;
			NinebotCmd.NB_CTL_TECHING_LEFT_ANGLE = 167;
			NinebotCmd.NB_CTL_TECHING_RIGHT_ANGLE = 168;
			NinebotCmd.NB_ONE_SYSVOLT_GAIN = 192;
			NinebotCmd.NB_ONE_RESET_COUNT = 193;
			NinebotCmd.NB_ONE_PITCH_OFFSET = 194;
			NinebotCmd.NB_ONE_GYRO_OFFSET_X = 195;
			NinebotCmd.NB_ONE_GYRO_OFFSET_Z = 196;
			NinebotCmd.NB_ONE_GYRO_OFFSET_Y = 197;
			NinebotCmd.NB_ONE_LED_MODE = 198;
			NinebotCmd.NB_ONE_LED_NUM = 199;
			NinebotCmd.NB_ONE_LED_COLOR1 = 200;
			NinebotCmd.NB_ONE_LED_COLOR2 = 202;
			NinebotCmd.NB_ONE_LED_COLOR3 = 204;
			NinebotCmd.NB_ONE_LED_COLOR4 = 206;
			NinebotCmd.MINI_CTL_FUN_BOOL = 211;
			NinebotCmd.NB_CPUID_A = 218;
			NinebotCmd.NB_CPUID_B = 219;
			NinebotCmd.NB_CPUID_C = 220;
			NinebotCmd.NB_CPUID_D = 221;
			NinebotCmd.NB_CPUID_E = 222;
			NinebotCmd.NB_CPUID_F = 223;
			NinebotCmd.NB_FUN_BOOLMARK_FLIGHT = 1;
			NinebotCmd.NB_FUN_BOOLMARK_BREAKLED = 2;
			NinebotCmd.NB_FUN_BOOLMARK_POWEROFF_AT_LOCK = 4;
			NinebotCmd.NB_FUN_BOOLMARK_NO_ALARM_AT_LOCK = 8;
			NinebotCmd.NB_FUN_BOOLMARK_CHILDREN_MODE = 16;
			NinebotCmd.NB_FUN_BOOLMARK_HIGH_SPEE = 32;
			NinebotCmd.NB_BOOLMARK_LIMITSPEED = 1;
			NinebotCmd.NB_BOOLMARK_LOCK = 2;
			NinebotCmd.NB_BOOLMARK_BEEP = 4;
			NinebotCmd.NB_BOOLMARK_REMOTECTRL = 16;
			NinebotCmd.NB_BOOLMARK_VOERTEMP = 32;
			NinebotCmd.NB_BOOLMARK_STUDENT_DRIVER = 64;
			NinebotCmd.NB_BOOLMARK_APPROVED_DRIVER = 128;
			NinebotCmd.NB_BOOLMARK_FACTORY_TEST_MODE = 256;
			NinebotCmd.NB_BOOLMARK_MENON = 1024;
			NinebotCmd.NB_BOOLMARK_ACT = 2048;
			NinebotCmd.NB_BOOLMARK_TEACHED = 4096;
			NinebotCmd.NB_BOOLMARK_TEACH_STEP_OK = 8192;
			NinebotCmd.NB_BOOLMARK_BE_LIFTED = 16384;
			NinebotCmd.NB_BOOLMARK_BOTH_FEET = 32768;
			NinebotCmd.NB_WORKMODE_STANDBY = 0;
			NinebotCmd.NB_WORKMODE_ASSIST = 1;
			NinebotCmd.NB_WORKMODE_NORMAL = 2;
			NinebotCmd.NB_WORKMODE_LOCK = 3;
			NinebotCmd.NB_WORKMODE_REMOTE = 4;
			NinebotCmd.MINI_BLED_MODE_CLOSE = 0;
			NinebotCmd.MINI_BLED_MODE_1COLOR = 1;
			NinebotCmd.MINI_BLED_MODE_ALLCOLOR = 2;
			NinebotCmd.MINI_BLED_MODE_2C_APART = 3;
			NinebotCmd.MINI_BLED_MODE_ALLC_APART = 4;
			NinebotCmd.MINI_BLED_MODE_1C_STAR = 5;
			NinebotCmd.MINI_BLED_MODE_ALLC_STAR = 6;
			NinebotCmd.MINI_BLED_MODE_POLICE = 7;
			NinebotCmd.MINI_BLED_MODE_POLICE_2 = 8;
			NinebotCmd.MINI_BLED_MODE_POLICE_3 = 9;
			NinebotCmd.MINI_ERROR_CODE_VCCP = 1;
			NinebotCmd.MINI_ERROR_CODE_SYS_SW_ON = 2;
			NinebotCmd.MINI_ERROR_CODE_BAT_POW_CTRL = 3;
			NinebotCmd.MINI_ERROR_CODE_KEY_POW_CTRL = 4;
			NinebotCmd.MINI_ERROR_CODE_12V = 5;
			NinebotCmd.MINI_ERROR_CODE_5V = 6;
			NinebotCmd.MINI_ERROR_CODE_3V3 = 7;
			NinebotCmd.MINI_ERROR_CODE_TEST_MODE = 8;
			NinebotCmd.MINI_ERROR_CODE_XTL = 9;
			NinebotCmd.MINI_ERROR_CODE_ADC_PHA = 11;
			NinebotCmd.MINI_ERROR_CODE_ADC_PHB = 12;
			NinebotCmd.MINI_ERROR_CODE_ADC_PHC = 13;
			NinebotCmd.MINI_ERROR_CODE_ADC_PHA2 = 14;
			NinebotCmd.MINI_ERROR_CODE_ADC_PHB2 = 15;
			NinebotCmd.MINI_ERROR_CODE_ADC_PHC2 = 16;
			NinebotCmd.MINI_BMS_ERROR_VERSION = 17;
			NinebotCmd.MINI_ERROR_CODE_FSW1 = 18;
			NinebotCmd.MINI_ERROR_CODE_FSW2 = 19;
			NinebotCmd.MINI_ERROR_CODE_LHALL = 21;
			NinebotCmd.MINI_ERROR_CODE_HX711 = 22;
			NinebotCmd.MINI_BMS_ERROR_COM = 23;
			NinebotCmd.MINI_BMS_ERROR_PASSWORD = 24;
			NinebotCmd.MINI_ERROR_COM_BLE = 25;
			NinebotCmd.MINI_ERROR_CODE_SYS_VOL = 26;
			NinebotCmd.MINI_ERROR_CODE_POWER_OFF = 27;
			NinebotCmd.MINI_ERROR_FLASH = 28;
			NinebotCmd.MINI_ERROR_PASSWORD = 29;
			NinebotCmd.MINI_ERROR_CODE_AHRS = 30;
			NinebotCmd.MINI_ERROR_CODE_DRIVER1 = 31;
			NinebotCmd.MINI_ERROR_CODE_DRIVER2 = 32;
			NinebotCmd.MINI_ERROR_JUMP = 34;
			NinebotCmd.MINI_ERROR_CODE_6DS3 = 35;
			NinebotCmd.MINI_ERROR_CODE_HALL1_A = 36;
			NinebotCmd.MINI_ERROR_CODE_HALL1_B = 37;
			NinebotCmd.MINI_ERROR_CODE_HALL1_C = 38;
			NinebotCmd.MINI_ERROR_CODE_HALL2_A = 39;
			NinebotCmd.MINI_ERROR_CODE_HALL2_B = 40;
			NinebotCmd.MINI_ERROR_CODE_HALL2_C = 41;
			NinebotCmd.MINI_ERROR_CODE_COM = 46;
			NinebotCmd.MINI_ERROR_CODE_HX711_SIMPLE = 47;
			NinebotCmd.MINI_ERROR_CODE_SMT_PMOS = 48;
			NinebotCmd.MINI_ERROR_CODE_SMT_NMOS = 49;
			NinebotCmd.MINI_BMS_ERROR_TEMP = 51;
			NinebotCmd.MINI_BMS_ERROR_CELL_VOL = 52;
			NinebotCmd.NB_ALARM_MARK_LOWPOWER = 1;
			NinebotCmd.NB_ALARM_MARK_BACKWARD = 2;
			NinebotCmd.NB_ALARM_MARK_OVERTEMP = 4;
			NinebotCmd.NB_ALARM_MARK_OVERLOAD = 8;
			NinebotCmd.NB_ALARM_MARK_OVERANGLE = 16;
			NinebotCmd.NB_ALARM_MARK_LOCKED = 32;
			NinebotCmd.NB_ALARM_MARK_SPEED = 64;
			NinebotCmd.NB_ALARM_MARK_HIGH_VOL = 128;
			NinebotCmd.NB_ALARM_MARK_OVERPWM = 256;
			NinebotCmd.NB_ALARM_MARK_OVERWATT = 512;
			NinebotCmd.NB_ALARM_MARK_CURRENT = 1024;
			NinebotCmd.NB_ALARM_MARK_LOWTEMP = 2048;
			NinebotCmd.NB_ALARM_MARK_TEST = 2048;
		}

		public NinebotCmd()
		{
		}
	}
}