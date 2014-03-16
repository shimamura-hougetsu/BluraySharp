﻿using System.ComponentModel;

namespace BluraySharp.Common
{
	[TypeConverter(typeof(BdLangConverter))]
	public enum BdLang
	{
		LANG_IVL = 0x0,

		LANG_AAR,
		LANG_ABK,
		LANG_ACE,
		LANG_ACH,
		LANG_ADA,
		LANG_ADY,
		LANG_AFA,
		LANG_AFH,
		LANG_AFR,
		LANG_AIN,
		LANG_AKA,
		LANG_AKK,
		LANG_ALB,
		LANG_ALE,
		LANG_ALG,
		LANG_ALT,
		LANG_AMH,
		LANG_ANG,
		LANG_ANP,
		LANG_APA,
		LANG_ARA,
		LANG_ARC,
		LANG_ARG,
		LANG_ARM,
		LANG_ARN,
		LANG_ARP,
		LANG_ART,
		LANG_ARW,
		LANG_ASM,
		LANG_AST,
		LANG_ATH,
		LANG_AUS,
		LANG_AVA,
		LANG_AVE,
		LANG_AWA,
		LANG_AYM,
		LANG_AZE,
		LANG_BAD,
		LANG_BAI,
		LANG_BAK,
		LANG_BAL,
		LANG_BAM,
		LANG_BAN,
		LANG_BAQ,
		LANG_BAS,
		LANG_BAT,
		LANG_BEJ,
		LANG_BEL,
		LANG_BEM,
		LANG_BEN,
		LANG_BER,
		LANG_BHO,
		LANG_BIH,
		LANG_BIK,
		LANG_BIN,
		LANG_BIS,
		LANG_BLA,
		LANG_BNT,
		LANG_BOD,
		LANG_BOS,
		LANG_BRA,
		LANG_BRE,
		LANG_BTK,
		LANG_BUA,
		LANG_BUG,
		LANG_BUL,
		LANG_BUR,
		LANG_BYN,
		LANG_CAD,
		LANG_CAI,
		LANG_CAR,
		LANG_CAT,
		LANG_CAU,
		LANG_CEB,
		LANG_CEL,
		LANG_CES,
		LANG_CHA,
		LANG_CHB,
		LANG_CHE,
		LANG_CHG,
		LANG_CHI,
		LANG_CHK,
		LANG_CHM,
		LANG_CHN,
		LANG_CHO,
		LANG_CHP,
		LANG_CHR,
		LANG_CHU,
		LANG_CHV,
		LANG_CHY,
		LANG_CMC,
		LANG_COP,
		LANG_COR,
		LANG_COS,
		LANG_CPE,
		LANG_CPF,
		LANG_CPP,
		LANG_CRE,
		LANG_CRH,
		LANG_CRP,
		LANG_CSB,
		LANG_CUS,
		LANG_CYM,
		LANG_CZE,
		LANG_DAK,
		LANG_DAN,
		LANG_DAR,
		LANG_DAY,
		LANG_DEL,
		LANG_DEN,
		LANG_DEU,
		LANG_DGR,
		LANG_DIN,
		LANG_DIV,
		LANG_DOI,
		LANG_DRA,
		LANG_DSB,
		LANG_DUA,
		LANG_DUM,
		LANG_DUT,
		LANG_DYU,
		LANG_DZO,
		LANG_EFI,
		LANG_EGY,
		LANG_EKA,
		LANG_ELL,
		LANG_ELX,
		LANG_ENG,
		LANG_ENM,
		LANG_EPO,
		LANG_EST,
		LANG_EUS,
		LANG_EWE,
		LANG_EWO,
		LANG_FAN,
		LANG_FAO,
		LANG_FAS,
		LANG_FAT,
		LANG_FIJ,
		LANG_FIL,
		LANG_FIN,
		LANG_FIU,
		LANG_FON,
		LANG_FRA,
		LANG_FRE,
		LANG_FRM,
		LANG_FRO,
		LANG_FRR,
		LANG_FRS,
		LANG_FRY,
		LANG_FUL,
		LANG_FUR,
		LANG_GAA,
		LANG_GAY,
		LANG_GBA,
		LANG_GEM,
		LANG_GEO,
		LANG_GER,
		LANG_GEZ,
		LANG_GIL,
		LANG_GLA,
		LANG_GLE,
		LANG_GLG,
		LANG_GLV,
		LANG_GMH,
		LANG_GOH,
		LANG_GON,
		LANG_GOR,
		LANG_GOT,
		LANG_GRB,
		LANG_GRC,
		LANG_GRE,
		LANG_GRN,
		LANG_GSW,
		LANG_GUJ,
		LANG_GWI,
		LANG_HAI,
		LANG_HAT,
		LANG_HAU,
		LANG_HAW,
		LANG_HEB,
		LANG_HER,
		LANG_HIL,
		LANG_HIM,
		LANG_HIN,
		LANG_HIT,
		LANG_HMN,
		LANG_HMO,
		LANG_HRV,
		LANG_HSB,
		LANG_HUN,
		LANG_HUP,
		LANG_HYE,
		LANG_IBA,
		LANG_IBO,
		LANG_ICE,
		LANG_IDO,
		LANG_III,
		LANG_IJO,
		LANG_IKU,
		LANG_ILE,
		LANG_ILO,
		LANG_INA,
		LANG_INC,
		LANG_IND,
		LANG_INE,
		LANG_INH,
		LANG_IPK,
		LANG_IRA,
		LANG_IRO,
		LANG_ISL,
		LANG_ITA,
		LANG_JAV,
		LANG_JBO,
		LANG_JPN,
		LANG_JPR,
		LANG_JRB,
		LANG_KAA,
		LANG_KAB,
		LANG_KAC,
		LANG_KAL,
		LANG_KAM,
		LANG_KAN,
		LANG_KAR,
		LANG_KAS,
		LANG_KAT,
		LANG_KAU,
		LANG_KAW,
		LANG_KAZ,
		LANG_KBD,
		LANG_KHA,
		LANG_KHI,
		LANG_KHM,
		LANG_KHO,
		LANG_KIK,
		LANG_KIN,
		LANG_KIR,
		LANG_KMB,
		LANG_KOK,
		LANG_KOM,
		LANG_KON,
		LANG_KOR,
		LANG_KOS,
		LANG_KPE,
		LANG_KRC,
		LANG_KRL,
		LANG_KRO,
		LANG_KRU,
		LANG_KUA,
		LANG_KUM,
		LANG_KUR,
		LANG_KUT,
		LANG_LAD,
		LANG_LAH,
		LANG_LAM,
		LANG_LAO,
		LANG_LAT,
		LANG_LAV,
		LANG_LEZ,
		LANG_LIM,
		LANG_LIN,
		LANG_LIT,
		LANG_LOL,
		LANG_LOZ,
		LANG_LTZ,
		LANG_LUA,
		LANG_LUB,
		LANG_LUG,
		LANG_LUI,
		LANG_LUN,
		LANG_LUO,
		LANG_LUS,
		LANG_MAC,
		LANG_MAD,
		LANG_MAG,
		LANG_MAH,
		LANG_MAI,
		LANG_MAK,
		LANG_MAL,
		LANG_MAN,
		LANG_MAO,
		LANG_MAP,
		LANG_MAR,
		LANG_MAS,
		LANG_MAY,
		LANG_MDF,
		LANG_MDR,
		LANG_MEN,
		LANG_MGA,
		LANG_MIC,
		LANG_MIN,
		LANG_MIS,
		LANG_MKD,
		LANG_MKH,
		LANG_MLG,
		LANG_MLT,
		LANG_MNC,
		LANG_MNI,
		LANG_MNO,
		LANG_MOH,
		LANG_MON,
		LANG_MOS,
		LANG_MRI,
		LANG_MSA,
		LANG_MUL,
		LANG_MUN,
		LANG_MUS,
		LANG_MWL,
		LANG_MWR,
		LANG_MYA,
		LANG_MYN,
		LANG_MYV,
		LANG_NAH,
		LANG_NAI,
		LANG_NAP,
		LANG_NAU,
		LANG_NAV,
		LANG_NBL,
		LANG_NDE,
		LANG_NDO,
		LANG_NDS,
		LANG_NEP,
		LANG_NEW,
		LANG_NIA,
		LANG_NIC,
		LANG_NIU,
		LANG_NLD,
		LANG_NNO,
		LANG_NOB,
		LANG_NOG,
		LANG_NON,
		LANG_NOR,
		LANG_NQO,
		LANG_NSO,
		LANG_NUB,
		LANG_NWC,
		LANG_NYA,
		LANG_NYM,
		LANG_NYN,
		LANG_NYO,
		LANG_NZI,
		LANG_OCI,
		LANG_OJI,
		LANG_ORI,
		LANG_ORM,
		LANG_OSA,
		LANG_OSS,
		LANG_OTA,
		LANG_OTO,
		LANG_PAA,
		LANG_PAG,
		LANG_PAL,
		LANG_PAM,
		LANG_PAN,
		LANG_PAP,
		LANG_PAU,
		LANG_PEO,
		LANG_PER,
		LANG_PHI,
		LANG_PHN,
		LANG_PLI,
		LANG_POL,
		LANG_PON,
		LANG_POR,
		LANG_PRA,
		LANG_PRO,
		LANG_PUS,
		LANG_QAA,
		LANG_QUE,
		LANG_RAJ,
		LANG_RAP,
		LANG_RAR,
		LANG_ROA,
		LANG_ROH,
		LANG_ROM,
		LANG_RON,
		LANG_RUM,
		LANG_RUN,
		LANG_RUP,
		LANG_RUS,
		LANG_SAD,
		LANG_SAG,
		LANG_SAH,
		LANG_SAI,
		LANG_SAL,
		LANG_SAM,
		LANG_SAN,
		LANG_SAS,
		LANG_SAT,
		LANG_SCN,
		LANG_SCO,
		LANG_SEL,
		LANG_SEM,
		LANG_SGA,
		LANG_SGN,
		LANG_SHN,
		LANG_SID,
		LANG_SIN,
		LANG_SIO,
		LANG_SIT,
		LANG_SLA,
		LANG_SLK,
		LANG_SLO,
		LANG_SLV,
		LANG_SMA,
		LANG_SME,
		LANG_SMI,
		LANG_SMJ,
		LANG_SMN,
		LANG_SMO,
		LANG_SMS,
		LANG_SNA,
		LANG_SND,
		LANG_SNK,
		LANG_SOG,
		LANG_SOM,
		LANG_SON,
		LANG_SOT,
		LANG_SPA,
		LANG_SQI,
		LANG_SRD,
		LANG_SRN,
		LANG_SRP,
		LANG_SRR,
		LANG_SSA,
		LANG_SSW,
		LANG_SUK,
		LANG_SUN,
		LANG_SUS,
		LANG_SUX,
		LANG_SWA,
		LANG_SWE,
		LANG_SYC,
		LANG_SYR,
		LANG_TAH,
		LANG_TAI,
		LANG_TAM,
		LANG_TAT,
		LANG_TEL,
		LANG_TEM,
		LANG_TER,
		LANG_TET,
		LANG_TGK,
		LANG_TGL,
		LANG_THA,
		LANG_TIB,
		LANG_TIG,
		LANG_TIR,
		LANG_TIV,
		LANG_TKL,
		LANG_TLH,
		LANG_TLI,
		LANG_TMH,
		LANG_TOG,
		LANG_TON,
		LANG_TPI,
		LANG_TSI,
		LANG_TSN,
		LANG_TSO,
		LANG_TUK,
		LANG_TUM,
		LANG_TUP,
		LANG_TUR,
		LANG_TUT,
		LANG_TVL,
		LANG_TWI,
		LANG_TYV,
		LANG_UDM,
		LANG_UGA,
		LANG_UIG,
		LANG_UKR,
		LANG_UMB,
		LANG_UND,
		LANG_URD,
		LANG_UZB,
		LANG_VAI,
		LANG_VEN,
		LANG_VIE,
		LANG_VOL,
		LANG_VOT,
		LANG_WAK,
		LANG_WAL,
		LANG_WAR,
		LANG_WAS,
		LANG_WEL,
		LANG_WEN,
		LANG_WLN,
		LANG_WOL,
		LANG_XAL,
		LANG_XHO,
		LANG_YAO,
		LANG_YAP,
		LANG_YID,
		LANG_YOR,
		LANG_YPK,
		LANG_ZAP,
		LANG_ZBL,
		LANG_ZEN,
		LANG_ZGH,
		LANG_ZHA,
		LANG_ZHO,
		LANG_ZND,
		LANG_ZUL,
		LANG_ZUN,
		LANG_ZXX,
		LANG_ZZA
	}
}
