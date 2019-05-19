using System;

namespace IAP
{
	internal class MiniBatteryCmdMap
	{
		public static byte BMS_CMDTYPE_RD;

		public static byte BMS_CMDTYPE_WR;

		public static byte BMS_CMDTYPE_WR_NR;

		public static short BMS_CMDMAP_LEN;

		public static byte BMS_CMDMAP_INDLEN;

		public static byte BMS_CMDMAP_SUBLEN;

		public static byte BMS_RES_PASSWORD;

		public static byte BMS_SET_CELL_OCHG_VOL;

		public static byte BMS_SET_CELL_OCHG_RCV_VOL;

		public static byte BMS_SET_CELL_ODIS_VOL;

		public static byte BMS_SET_CELL_ODIS_RCV_VOL;

		public static byte BMS_SET_CELL_BLAOP_VOL;

		public static byte BMS_SET_CELL_DIFBLAOP_VOL;

		public static byte BMS_SET_CELL_BLADIF_VOL;

		public static byte BMS_SET_ODISCRT_CRT1;

		public static byte BMS_SET_ODISCRT_TIME1;

		public static byte BMS_SET_ODISCRT_CRT2;

		public static byte BMS_SET_ODISCRT_TIME2;

		public static byte BMS_SET_OCHGCRT_CRT;

		public static byte BMS_SET_OCHGCRT_TIME;

		public static byte BMS_SET_PMOS;

		public static byte BMS_INF_SN;

		public static byte BMS_INF_FW_VERSION;

		public static byte BMS_INF_DSG_FULL_CAP;

		public static byte BMS_INF_CRT_FULL_CAP;

		public static byte BMS_INF_DSG_VOL;

		public static byte BMS_INF_DIS_LOOP;

		public static byte BMS_INF_CHG_CNT;

		public static byte BMS_INF_CHG_CAP_L;

		public static byte BMS_INF_CHG_CAP_H;

		public static byte BMS_INF_OCRT_ODIS_CNT;

		public static byte BMS_INF_PRD_DATE;

		public static byte BMS_INF_FUSE_DATE;

		public static byte BMS_INF_F_CODE;

		public static byte BMS_INF_B_CODE;

		public static byte BMS_INF_BOOL;

		public static byte BMS_INF_CRT_CAP;

		public static byte BMS_INF_CAP_PCT;

		public static byte BMS_INF_CRT;

		public static byte BMS_INF_VOL;

		public static byte BMS_INF_TEMP;

		public static byte BMS_INF_BLA_STATE;

		public static byte BMS_INF_ODIS_STATE;

		public static byte BMS_INF_OCHG_STATE;

		public static byte BMS_INF_CAP_COULO;

		public static byte BMS_INF_CAP_VOL;

		public static byte BMS_INF_CAP_HEALTH;

		public static byte BMS_INF_CELL_VOL_0;

		public static byte BMS_INF_BEEN_ACT;

		public static byte BMS_INF_PCB_VER;

		public static byte BMS_CPUID_A;

		public static byte BMS_CPUID_B;

		public static byte BMS_CPUID_C;

		public static byte BMS_CPUID_D;

		public static byte BMS_CPUID_E;

		public static byte BMS_CPUID_F;

		public static ushort BMS_BOOLMARK_PASSWORD;

		public static ushort BMS_BOOLMARK_ACT;

		public static ushort BMS_BOOLMARK_DMOS;

		public static ushort BMS_BOOLMARK_CMOS;

		public static ushort BMS_BOOLMARK_WRITE_CMD;

		public static ushort BMS_BOOLMARK_DISCHARGE;

		public static ushort BMS_BOOLMARK_CHARGE;

		public static ushort BMS_BOOLMARK_CHARGERIN;

		public static ushort BMS_BOOLMARK_DISOVER;

		public static ushort BMS_BOOLMARK_CHGOVER;

		public static ushort BMS_BOOLMARK_VOERTEMP;

		public static ushort BMS_BOOLMARK_TEST_MODE;

		public static ushort BMS_BOOLMARK_MINI_POWERON;

		public static byte BMS_ERROR_SPI;

		public static byte BMS_ERROR_OVR_CHG;

		public static byte BMS_ERROR_LOAD;

		public static byte BMS_ERROR_JUMP_APP;

		public static byte BMS_ERROR_PASSWORD;

		public static byte BMS_ERROR_PUPIN;

		static MiniBatteryCmdMap()
		{
			MiniBatteryCmdMap.BMS_CMDTYPE_RD = 1;
			MiniBatteryCmdMap.BMS_CMDTYPE_WR = 2;
			MiniBatteryCmdMap.BMS_CMDTYPE_WR_NR = 3;
			MiniBatteryCmdMap.BMS_CMDMAP_LEN = 128;
			MiniBatteryCmdMap.BMS_CMDMAP_INDLEN = 8;
			MiniBatteryCmdMap.BMS_CMDMAP_SUBLEN = 16;
			MiniBatteryCmdMap.BMS_RES_PASSWORD = 0;
			MiniBatteryCmdMap.BMS_SET_CELL_OCHG_VOL = 1;
			MiniBatteryCmdMap.BMS_SET_CELL_OCHG_RCV_VOL = 2;
			MiniBatteryCmdMap.BMS_SET_CELL_ODIS_VOL = 3;
			MiniBatteryCmdMap.BMS_SET_CELL_ODIS_RCV_VOL = 4;
			MiniBatteryCmdMap.BMS_SET_CELL_BLAOP_VOL = 5;
			MiniBatteryCmdMap.BMS_SET_CELL_DIFBLAOP_VOL = 6;
			MiniBatteryCmdMap.BMS_SET_CELL_BLADIF_VOL = 7;
			MiniBatteryCmdMap.BMS_SET_ODISCRT_CRT1 = 8;
			MiniBatteryCmdMap.BMS_SET_ODISCRT_TIME1 = 9;
			MiniBatteryCmdMap.BMS_SET_ODISCRT_CRT2 = 10;
			MiniBatteryCmdMap.BMS_SET_ODISCRT_TIME2 = 11;
			MiniBatteryCmdMap.BMS_SET_OCHGCRT_CRT = 12;
			MiniBatteryCmdMap.BMS_SET_OCHGCRT_TIME = 13;
			MiniBatteryCmdMap.BMS_SET_PMOS = 15;
			MiniBatteryCmdMap.BMS_INF_SN = 16;
			MiniBatteryCmdMap.BMS_INF_FW_VERSION = 23;
			MiniBatteryCmdMap.BMS_INF_DSG_FULL_CAP = 24;
			MiniBatteryCmdMap.BMS_INF_CRT_FULL_CAP = 25;
			MiniBatteryCmdMap.BMS_INF_DSG_VOL = 26;
			MiniBatteryCmdMap.BMS_INF_DIS_LOOP = 27;
			MiniBatteryCmdMap.BMS_INF_CHG_CNT = 28;
			MiniBatteryCmdMap.BMS_INF_CHG_CAP_L = 29;
			MiniBatteryCmdMap.BMS_INF_CHG_CAP_H = 30;
			MiniBatteryCmdMap.BMS_INF_OCRT_ODIS_CNT = 31;
			MiniBatteryCmdMap.BMS_INF_PRD_DATE = 32;
			MiniBatteryCmdMap.BMS_INF_FUSE_DATE = 33;
			MiniBatteryCmdMap.BMS_INF_F_CODE = 34;
			MiniBatteryCmdMap.BMS_INF_B_CODE = 35;
			MiniBatteryCmdMap.BMS_INF_BOOL = 48;
			MiniBatteryCmdMap.BMS_INF_CRT_CAP = 49;
			MiniBatteryCmdMap.BMS_INF_CAP_PCT = 50;
			MiniBatteryCmdMap.BMS_INF_CRT = 51;
			MiniBatteryCmdMap.BMS_INF_VOL = 52;
			MiniBatteryCmdMap.BMS_INF_TEMP = 53;
			MiniBatteryCmdMap.BMS_INF_BLA_STATE = 54;
			MiniBatteryCmdMap.BMS_INF_ODIS_STATE = 55;
			MiniBatteryCmdMap.BMS_INF_OCHG_STATE = 56;
			MiniBatteryCmdMap.BMS_INF_CAP_COULO = 57;
			MiniBatteryCmdMap.BMS_INF_CAP_VOL = 58;
			MiniBatteryCmdMap.BMS_INF_CAP_HEALTH = 59;
			MiniBatteryCmdMap.BMS_INF_CELL_VOL_0 = 64;
			MiniBatteryCmdMap.BMS_INF_BEEN_ACT = 80;
			MiniBatteryCmdMap.BMS_INF_PCB_VER = 81;
			MiniBatteryCmdMap.BMS_CPUID_A = 112;
			MiniBatteryCmdMap.BMS_CPUID_B = 113;
			MiniBatteryCmdMap.BMS_CPUID_C = 114;
			MiniBatteryCmdMap.BMS_CPUID_D = 115;
			MiniBatteryCmdMap.BMS_CPUID_E = 116;
			MiniBatteryCmdMap.BMS_CPUID_F = 117;
			MiniBatteryCmdMap.BMS_BOOLMARK_PASSWORD = 1;
			MiniBatteryCmdMap.BMS_BOOLMARK_ACT = 2;
			MiniBatteryCmdMap.BMS_BOOLMARK_DMOS = 4;
			MiniBatteryCmdMap.BMS_BOOLMARK_CMOS = 8;
			MiniBatteryCmdMap.BMS_BOOLMARK_WRITE_CMD = 16;
			MiniBatteryCmdMap.BMS_BOOLMARK_DISCHARGE = 32;
			MiniBatteryCmdMap.BMS_BOOLMARK_CHARGE = 64;
			MiniBatteryCmdMap.BMS_BOOLMARK_CHARGERIN = 128;
			MiniBatteryCmdMap.BMS_BOOLMARK_DISOVER = 256;
			MiniBatteryCmdMap.BMS_BOOLMARK_CHGOVER = 512;
			MiniBatteryCmdMap.BMS_BOOLMARK_VOERTEMP = 1024;
			MiniBatteryCmdMap.BMS_BOOLMARK_TEST_MODE = 2048;
			MiniBatteryCmdMap.BMS_BOOLMARK_MINI_POWERON = 4096;
			MiniBatteryCmdMap.BMS_ERROR_SPI = 2;
			MiniBatteryCmdMap.BMS_ERROR_OVR_CHG = 3;
			MiniBatteryCmdMap.BMS_ERROR_LOAD = 4;
			MiniBatteryCmdMap.BMS_ERROR_JUMP_APP = 5;
			MiniBatteryCmdMap.BMS_ERROR_PASSWORD = 6;
			MiniBatteryCmdMap.BMS_ERROR_PUPIN = 7;
		}

		public MiniBatteryCmdMap()
		{
		}
	}
}