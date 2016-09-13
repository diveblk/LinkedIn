using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using tessnet2;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;


namespace tess
{
    class Program
    {
        static void Main(string[] args)
        {
            String pdfText;

            List<Item> itemSku = new List<Item>
            {
                new Item() {sku =   "EQCATALOG",    masterSku=  "", desc=   "EQUIBRAND CATALOG",    desc2=  "", upc=    "610393101439", brand=  "GENERAL",  code=   "CACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "3DXWFCL",  masterSku=  "3DXW", desc=   "3DX BELL BOOT WESTERN",    desc2=  "FUCHSIA LARGE",    upc=    "610393088051", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "FUCHSIA",  dem2=   "LARGE" },
                new Item() {sku =   "3DXWFCM",  masterSku=  "3DXW", desc=   "3DX BELL BOOT WESTERN",    desc2=  "FUCHSIA MED",  upc=    "610393088068", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "FUCHSIA",  dem2=   "MEDIUM"    },
                new Item() {sku =   "3DXWFCS",  masterSku=  "3DXW", desc=   "3DX BELL BOOT WESTERN",    desc2=  "FUCHSIA SMALL",    upc=    "610393088075", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "FUCHSIA",  dem2=   "SMALL" },
                new Item() {sku =   "3DXWWHL",  masterSku=  "3DXW", desc=   "3DX BELL BOOT WESTERN",    desc2=  "WHITE LARGE",  upc=    "610393088082", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "3DXWWHM",  masterSku=  "3DXW", desc=   "3DX BELL BOOT WESTERN",    desc2=  "WHITE MED",    upc=    "610393088099", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "3DXWWHS",  masterSku=  "3DXW", desc=   "3DX BELL BOOT WESTERN",    desc2=  "WHITE SMALL",  upc=    "610393088105", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "AFP100C30",    masterSku=  "AFP100C",  desc=   "ALPACA FELT PAD",  desc2=  "1 CONTOURED 30X32",    upc=    "610393104683", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30X32",    dem2=   ""  },
                new Item() {sku =   "AFP100C32",    masterSku=  "AFP100C",  desc=   "ALPACA FELT PAD",  desc2=  "1 CONTOURED 31X32",    upc=    "610393104676", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31X32",    dem2=   ""  },
                new Item() {sku =   "AFP340C30",    masterSku=  "AFP340C",  desc=   "ALPACA FELT PAD",  desc2=  "3/4 CONTOURED 30X32",  upc=    "610393104669", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30X32",    dem2=   ""  },
                new Item() {sku =   "AFP340C32",    masterSku=  "AFP340C",  desc=   "ALPACA FELT PAD",  desc2=  "3/4 CONTOURED 31X32",  upc=    "610393104652", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31X32",    dem2=   ""  },
                new Item() {sku =   "ALPHOB",   masterSku=  "ALPHOB",   desc=   "ALPACA BLEND HOBBLE",  desc2=  "", upc=    "610393081465", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "ASAFE-BLA",    masterSku=  "ASAFE-BLA",    desc=   "ANKLE SAFE - BLACK",   desc2=  "", upc=    "804381008408", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "ASAFE-S-BLA",  masterSku=  "ASAFE-S-BLA",  desc=   "ANKLE SAFE - SMALL-BLACK", desc2=  "", upc=    "804381028512", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "ASWW", masterSku=  "ASWW", desc=   "AQUA SHIELD WRIST WRAP",   desc2=  "", upc=    "804381008996", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "AWCSB100BKL",  masterSku=  "AWCSB100", desc=   "AIR WAVE CLASSIC SPLINT BOOT", desc2=  "BLACK LARGE",  upc=    "610393104034", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "AWCSB100BKM",  masterSku=  "AWCSB100", desc=   "AIR WAVE CLASSIC SPLINT BOOT", desc2=  "BLACK MEDIUM", upc=    "610393104041", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "AWCSB100BKS",  masterSku=  "AWCSB100", desc=   "AIR WAVE CLASSIC SPLINT BOOT", desc2=  "BLACK SMALL",  upc=    "610393104058", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "AWCSB100WHL",  masterSku=  "AWCSB100", desc=   "AIR WAVE CLASSIC SPLINT BOOT", desc2=  "WHITE LARGE",  upc=    "610393104065", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "AWCSB100WHM",  masterSku=  "AWCSB100", desc=   "AIR WAVE CLASSIC SPLINT BOOT", desc2=  "WHITE MEDIUM", upc=    "610393104072", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "AWCSB100WHS",  masterSku=  "AWCSB100", desc=   "AIR WAVE CLASSIC SPLINT BOOT", desc2=  "WHITE SMALL",  upc=    "610393104089", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "AWEW100BK",    masterSku=  "AWEW", desc=   "AIR WAVE EZ WRAP II FRONT",    desc2=  "BLACK STD SIZE ",  upc=    "610393103990", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT" },
                new Item() {sku =   "AWEW200BK",    masterSku=  "AWEW", desc=   "AIR WAVE EZ WRAP II HIND", desc2=  "BLACK STD SIZE ",  upc=    "610393104003", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND"  },
                new Item() {sku =   "AWEW100WH",    masterSku=  "AWEW", desc=   "AIR WAVE EZ WRAP II FRONT",    desc2=  "WHITE STD SIZE ",  upc=    "610393104010", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT" },
                new Item() {sku =   "AWEW200WH",    masterSku=  "AWEW", desc=   "AIR WAVE EZ WRAP II HIND ",    desc2=  "WHITE STD SIZE ",  upc=    "610393104027", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND"  },
                new Item() {sku =   "BAFLAG",   masterSku=  "BAFLAG",   desc=   "RATTLER BREAKAWAY FLAG",   desc2=  "", upc=    "610393093567", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "BATBK",    masterSku=  "BAT",  desc=   "BOOT ACCESSORY TOTE",  desc2=  "BLACK",    upc=    "610393067339", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "BAT16CT",  masterSku=  "BAT",  desc=   "BOOT ACCESSORY TOTE 2016", desc2=  "CHOCOLATE TRIBAL", upc=    "610393102351", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CHOCOLATE TRIBAL", dem2=   ""  },
                new Item() {sku =   "BAT16CK",  masterSku=  "BAT",  desc=   "BOOT ACCESSORY TOTE 2016", desc2=  "CORAL KNIGHT", upc=    "610393102344", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "BAT16PD",  masterSku=  "BAT",  desc=   "BOOT ACCESSORY TOTE 2016", desc2=  "PLUM DAZE",    upc=    "610393102368", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLUM DAZE",    dem2=   ""  },
                new Item() {sku =   "BAT15S",   masterSku=  "BAT",  desc=   "BOOT ACCESSORY TOTE 2015", desc2=  "SERAPE",   upc=    "610393101859", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "SERAPE",   dem2=   ""  },
                new Item() {sku =   "BAT15TD",  masterSku=  "BAT",  desc=   "BOOT ACCESSORY TOTE 2015", desc2=  "TEAL DIAMOND", upc=    "610393101842", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "BBA-BLA-12",   masterSku=  "BBA-BLA",  desc=   "BOOMERS BANDAGES BLACK 12",    desc2=  "", upc=    "804381007852", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "12",   dem2=   ""  },
                new Item() {sku =   "BBA-BLA-14",   masterSku=  "BBA-BLA",  desc=   "BOOMERS BANDAGES BLACK 14",    desc2=  "", upc=    "804381007869", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "14",   dem2=   ""  },
                new Item() {sku =   "BBA-BLA-16",   masterSku=  "BBA-BLA",  desc=   "BANDAGE/SHIP BOOT BLACK 16",   desc2=  "", upc=    "804381007876", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "16",   dem2=   ""  },
                new Item() {sku =   "BBA-NAV-12",   masterSku=  "BBA-NVY",  desc=   "BOOMERS BANDAGES NAVY 12", desc2=  "", upc=    "804381007883", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "12",   dem2=   ""  },
                new Item() {sku =   "BBA-NAV-14",   masterSku=  "BBA-NVY",  desc=   "BOOMERS BANDAGES NAVY 14", desc2=  "", upc=    "804381007890", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "14",   dem2=   ""  },
                new Item() {sku =   "BBA-NAV-16",   masterSku=  "BBA-NVY",  desc=   "BANDAGE/SHIP BOOT  NAVY 16",   desc2=  "", upc=    "804381007906", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "16",   dem2=   ""  },
                new Item() {sku =   "BB-BLA-L", masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOT LARGE",  desc2=  "", upc=    "804381012757", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "BB-BLA-M", masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOTS MEDIUM",    desc2=  "", upc=    "804381012825", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "BB-BLA-MINI",  masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOTS MINI",  desc2=  "", upc=    "804381026877", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "MINI", dem2=   ""  },
                new Item() {sku =   "BB-BLA-S", masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOT SMALL",  desc2=  "", upc=    "804381012818", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "BB-BLA-XL",    masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOT X-LARGE",    desc2=  "", upc=    "804381012832", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "XL",   dem2=   ""  },
                new Item() {sku =   "BB-BLA-XS",    masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOT X-SMALL",    desc2=  "", upc=    "804381017554", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "XS",   dem2=   ""  },
                new Item() {sku =   "BB-BLA-XXS",   masterSku=  "BB-BLA",   desc=   "NO TURN BELL BOOTS XXS",   desc2=  "", upc=    "804381026853", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "XXS",  dem2=   ""  },
                new Item() {sku =   "BB-BLAR-L",    masterSku=  "BB-BLAR",  desc=   "BELL BOOTS BLACK RUBBER LARGE",    desc2=  "", upc=    "804381015796", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "BB-BLAR-M",    masterSku=  "BB-BLAR",  desc=   "BELL BOOTS BLACK RUBBER MEDIUM",   desc2=  "", upc=    "804381015802", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "BB-BLAR-S",    masterSku=  "BB-BLAR",  desc=   "BELL BOOTS BLACK RUBBER SMALL",    desc2=  "", upc=    "804381015819", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "BB-BLAR-XL",   masterSku=  "BB-BLAR",  desc=   "BELL BOOTS BLACK RUBBER X-LRG",    desc2=  "", upc=    "804381015826", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "X-LRG",    dem2=   ""  },
                new Item() {sku =   "BBIT2DDR25SS", masterSku=  "BBIT2DDR25SS", desc=   "BARREL BIT  D RING",   desc2=  "SNAFFLE MOUTH",    upc=    "610393092911", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2DDR29SS", masterSku=  "BBIT2DDR29SS", desc=   "BARREL BIT D RING",    desc2=  "SQUARE SNAFFLE",   upc=    "610393092904", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2LS24SS",  masterSku=  "BBIT2LS",  desc=   "BARREL BIT LONG SHANK",    desc2=  "3PC/W THIN MTH WIRE",  upc=    "610393097954", brand=  "WEQUINE",  code=   "BITS", dem1=   "Small Twisted Wire",   dem2=   ""  },
                new Item() {sku =   "BBIT2LS22SS",  masterSku=  "BBIT2LS",  desc=   "BARREL BIT LONG SHANK",    desc2=  "3PC W/ THICK MTH WIRE",    upc=    "610393097947", brand=  "WEQUINE",  code=   "BITS", dem1=   "Twisted Wire", dem2=   ""  },
                new Item() {sku =   "BBIT2LSG21SS", masterSku=  "BBIT2LSG21SS", desc=   "BARREL BIT LONG SHANK",    desc2=  "GAG W/ THICK MOUTH WIRE",  upc=    "610393092898", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2LSG22SS", masterSku=  "BBIT2LSG22SS", desc=   "BARREL BIT LONG SHANK",    desc2=  "GAG 3PC W/ THICK MTH WIRE",    upc=    "610393092881", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2LSG24SS", masterSku=  "BBIT2LSG24SS", desc=   "BARREL BIT LONG SHANK",    desc2=  "GAG 3PC/W THIN MTH WIRE",  upc=    "610393092874", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2LSG30SI", masterSku=  "BBIT2LSG30SI", desc=   "BARREL BIT LONG SHANK",    desc2=  "CHAIN SWEET IRON", upc=    "610393093369", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2LSG33SS", masterSku=  "BBIT2LSG33SS", desc=   "BARREL BIT LONG SHANK",    desc2=  "GAG W/SQUARE O-RING MP",   upc=    "610393092867", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2SS24SS",  masterSku=  "BBIT2SS",  desc=   "BARREL BIT SHORT SHANK",   desc2=  "3PC/W THIN MTH WIRE",  upc=    "610393097978", brand=  "WEQUINE",  code=   "BITS", dem1=   "Small Twisted Wire",   dem2=   ""  },
                new Item() {sku =   "BBIT2SS22SS",  masterSku=  "BBIT2SS",  desc=   "BARREL BIT SHORT SHANK",   desc2=  "3PC W/ THICK MTH WIRE",    upc=    "610393097961", brand=  "WEQUINE",  code=   "BITS", dem1=   "Twisted Wire", dem2=   ""  },
                new Item() {sku =   "BBIT2SSG21SS", masterSku=  "BBIT2SSG21SS", desc=   "BARREL BIT SHORT SHANK",   desc2=  "GAG W/ THICK MOUTH WIRE",  upc=    "610393092850", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2SSG22SS", masterSku=  "BBIT2SSG22SS", desc=   "BARREL BIT SHORT SHANK",   desc2=  "GAG 3PC W/ THICK MTH WIRE",    upc=    "610393092843", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2SSG24SS", masterSku=  "BBIT2SSG24SS", desc=   "BARREL BIT SHORT SHANK",   desc2=  "GAG 3PC/W THIN MTH WIRE",  upc=    "610393092836", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2SSG30SI", masterSku=  "BBIT2SSG30SI", desc=   "BARREL BIT SHORT SHANK",   desc2=  "CHAIN SWEET IRON", upc=    "610393093352", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BBIT2SSG33SS", masterSku=  "BBIT2SSG33SS", desc=   "BARREL BIT SHORT SHANK",   desc2=  "GAG W/SQUARE O-RING MP",   upc=    "610393092829", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC100A2D", masterSku=  "BC100A2D", desc=   "1 BC CHOC HARNESS",    desc2=  "ANTIQUE 2 DOTS",   upc=    "610393104584", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC100CHR", masterSku=  "BC100CHR", desc=   "1 BREAST COLLAR",  desc2=  "CHOCOLATE HARNESS RH BRAID",   upc=    "610393073248", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC100-BLA",    masterSku=  "BC100FLEECE",  desc=   "BREAST COLLAR FLEECE BLACK",   desc2=  "", upc=    "804381017400", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "BC100-BRN",    masterSku=  "BC100FLEECE",  desc=   "BREAST COLLAR FLEECE  BROWN",  desc2=  "", upc=    "804381019473", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "BC100HSD", masterSku=  "BC100HSD", desc=   "1 BC TAN HARNESS", desc2=  "SQUARE DOTS",  upc=    "610393100586", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC100NHR", masterSku=  "BC100NHR", desc=   "1 HARNESS BC RAWHIDE BRAID",   desc2=  "", upc=    "610393100579", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC100NROTCD",  masterSku=  "BC100ROTCD",   desc=   "1 BC NAT RO",  desc2=  "TURQUOISE AND COPPER DOTS",    upc=    "610393103815", brand=  "MARTIN",   code=   "BC",   dem1=   "BC100NROTCD",  dem2=   ""  },
                new Item() {sku =   "BC100CROTD",   masterSku=  "BC100ROTDCH",  desc=   "1 BC CHOC R/O",    desc2=  "TURQUOISE DOTS",   upc=    "610393100609", brand=  "MARTIN",   code=   "BC",   dem1=   "CHOC", dem2=   ""  },
                new Item() {sku =   "BC200H",   masterSku=  "BC200H",   desc=   "2 BC HARNESS", desc2=  "HEAVY OIL",    upc=    "610393100159", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC234HW",  masterSku=  "BC234HW",  desc=   "2-3/4 BC HARNESS WING",    desc2=  "HEAVY OIL",    upc=    "610393100135", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC2ALP",   masterSku=  "BC2ALP",   desc=   "BC 2 NAT. ALPACA", desc2=  "", upc=    "610393100067", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC2MA",    masterSku=  "BC2MA",    desc=   "BC 2 NAT. MOHAIR/ALPACA MIX",  desc2=  "BLEND",    upc=    "610393100050", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC2MOHAIR",    masterSku=  "BC2MOHAIR",    desc=   "BC 2  MOHAIR", desc2=  "", upc=    "610393100357", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC300ALP", masterSku=  "BC300ALP", desc=   "3 NAT. ALPACA BC", desc2=  "", upc=    "610393100166", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC300MA",  masterSku=  "BC300MA",  desc=   "3 NAT. MOHAIR/ALPACA BC",  desc2=  "", upc=    "610393100180", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC300MOHAIR",  masterSku=  "BC300MOHAIR",  desc=   "3  MOHAIR BC", desc2=  "", upc=    "610393100173", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW3SRH",  masterSku=  "BC3SRH",   desc=   "BCW 3 STEER ROPER HARNESS",    desc2=  "", upc=    "610393103907", brand=  "MARTIN",   code=   "BC",   dem1=   "BCW 3 STEER ROPER HARNESS",    dem2=   ""  },
                new Item() {sku =   "BC4VH",    masterSku=  "BC4VH",    desc=   "BC 4 V  HARNESS",  desc2=  "", upc=    "610393091785", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BC-BLA/WHI",   masterSku=  "BCAP", desc=   "BALL CAP BLACK WHITE LETTERING",   desc2=  "", upc=    "804381027218", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK WHITE LETTERING",    dem2=   ""  },
                new Item() {sku =   "BC-BLA",   masterSku=  "BCAP", desc=   "BALL CAP BLACK-Ladies",    desc2=  "", upc=    "804381012764", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "BC-CAMO",  masterSku=  "BCAP", desc=   "BALL CAP CAMO",    desc2=  "", upc=    "804381027225", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "BC-HL",    masterSku=  "BCAP", desc=   "BALL CAP HOTLEAF", desc2=  "", upc=    "804381029724", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "BC-NAV",   masterSku=  "BCAP", desc=   "BALL CAP NAVY WITH WHITE MESH",    desc2=  "", upc=    "804381025825", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "NAVY", dem2=   ""  },
                new Item() {sku =   "BC-HLPK",  masterSku=  "BCAP", desc=   "BALL CAP HOTLEAF PINK",    desc2=  "", upc=    "804381029717", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PINK HOT LEAF",    dem2=   ""  },
                new Item() {sku =   "BC-L", masterSku=  "BCAP", desc=   "BALL CAP LADIES -PINK",    desc2=  "", upc=    "804381025818", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "BCC100C",  masterSku=  "BCC100C",  desc=   "COLT BC 1 CHST",   desc2=  "CAMO BORDER / DIPPED", upc=    "610393100517", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCC134C",  masterSku=  "BCC134C",  desc=   "COLT BC 1-3/4 CAMO BORDER",    desc2=  "", upc=    "610393100524", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCLW13416LC",  masterSku=  "BCLW13416LC",  desc=   "1 BC CHESTNUT W/ SCROLL",  desc2=  "LASER DESIGN", upc=    "610393103884", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCLW13416LS",  masterSku=  "BCLW13416LS",  desc=   "1 3/4 BC NAT W/",  desc2=  "LASER SAFARI DESIGN",  upc=    "610393103891", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCLW134SDC",   masterSku=  "BCLW134SDC",   desc=   "1-3/4 BC PLAIN DOTS",  desc2=  "CHESTNUT/NATURAL", upc=    "610393100081", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCLW134SDN",   masterSku=  "BCLW134SDN",   desc=   "1-3/4 BC PLAIN DOTS",  desc2=  "NATURAL/NATURAL",  upc=    "610393100098", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW150MB", masterSku=  "BCW150MB", desc=   "BCW-1 1/2 MINIBASKET NAT", desc2=  "", upc=    "610393089089", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW150MBC",    masterSku=  "BCW150MBC",    desc=   "BCW-1 1/2  MINIBASKET CHST",   desc2=  "", upc=    "610393089072", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW150SDC",    masterSku=  "BCW150SDC",    desc=   "BCW-1 1/2 SCALLOP W/ DOTS CH", desc2=  "CAMO BORDER",  upc=    "610393089096", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW150SDN",    masterSku=  "BCW150SDN",    desc=   "BCW-1 1/2 SCALLOP W/ DOTS NAT",    desc2=  "CAMO BORDER",  upc=    "610393089102", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200B",  masterSku=  "BCW200B",  desc=   "BCW-2 BASKETSTMP NAT", desc2=  "", upc=    "610393088501", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200CHC",    masterSku=  "BCW200CHC",    desc=   "BC 2 CHOCOLATE CROC",  desc2=  "", upc=    "610393105024", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200FTBC",   masterSku=  "BCW200FTBC",   desc=   "BCW-2 BASKETSTMP CHEST",   desc2=  "", upc=    "610393088532", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200MTB",    masterSku=  "BCW200MTB",    desc=   "BCW-2 MARTIN BSKT NAT",    desc2=  "", upc=    "610393088587", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200MTBC",   masterSku=  "BCW200MTBC",   desc=   "BCW-2 MARTIN BSKT CH", desc2=  "", upc=    "610393088594", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200RODC",   masterSku=  "BCW200RODC",   desc=   "BCW-2 ROUGHOUT DOTS CHST", desc2=  "", upc=    "610393089423", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW200TQC",    masterSku=  "BCW200TQC",    desc=   "BC 2 TURQUOISE CROC",  desc2=  "", upc=    "610393103938", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234B",  masterSku=  "BCW234B",  desc=   "BCW-2 3/4 BASKETSTAMP",    desc2=  "", upc=    "610393088617", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234BH", masterSku=  "BCW234BH", desc=   "BCW-2 3/4 HARNESS/LAT",    desc2=  "", upc=    "610393088624", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234CHC",    masterSku=  "BCW234CHC",    desc=   "BC 2 3/4 CHOCOLATE CROC",  desc2=  "", upc=    "610393103914", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234FTBC",   masterSku=  "BCW234FTBC",   desc=   "BCW-2 3/4 BASKETSTAMP CH", desc2=  "", upc=    "610393088686", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234FTSS",   masterSku=  "BCW234FTSS",   desc=   "BCW-2 3/4 SPIDER STAMP NAT",   desc2=  "", upc=    "610393088716", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234FTSSC",  masterSku=  "BCW234FTSSC",  desc=   "BCW-2 3/4 SPIDER STAMP CH",    desc2=  "", upc=    "610393088723", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234MB", masterSku=  "BCW234MB", desc=   "BCW-2-34 MINIBSKT NAT",    desc2=  "", upc=    "610393088754", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234MBC",    masterSku=  "BCW234MBC",    desc=   "BCW-2-34 MINIBSKT CHST",   desc2=  "", upc=    "610393088761", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234MTB",    masterSku=  "BCW234MTB",    desc=   "BCW-2 3/4 MARTIN BSKT NAT",    desc2=  "", upc=    "610393088792", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234MTBC",   masterSku=  "BCW234MTBC",   desc=   "BCW-2 3/4 MARTIN BSKT CH", desc2=  "", upc=    "610393088808", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234RODC",   masterSku=  "BCW234RODC",   desc=   "BCW-2 3/4 ROUGHOUT DOTS CHST", desc2=  "", upc=    "610393089416", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234TQC",    masterSku=  "BCW234TQC",    desc=   "BC 2 3/4 TURQUOISE CROC",  desc2=  "", upc=    "610393103921", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234W",  masterSku=  "BCW234W",  desc=   "BCW-2 3/4 WAFFLESTMP NAT", desc2=  "", upc=    "610393088945", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW234WC", masterSku=  "BCW234WC", desc=   "BCW-2 3/4 WAFFLESTMP CH",  desc2=  "", upc=    "610393088952", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW4SRB",  masterSku=  "BCW4SRB",  desc=   "BCW-4 BASKETSTMP NAT", desc2=  "", upc=    "610393088969", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCW4SRRO", masterSku=  "BCW4SRRO", desc=   "BCW - 4 STEER ROPER ROUGH-OUT",    desc2=  "", upc=    "610393089157", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BCWS", masterSku=  "BCWS", desc=   "BREAST COLLAR WITHER STRAP",   desc2=  "", upc=    "610393091778", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BE-CHE",   masterSku=  "BE-CHE",   desc=   "ELASTIC BILLET CHESTNT LEATHER",   desc2=  "", upc=    "804381006237", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BHC",  masterSku=  "BHC",  desc=   "BIT HOBBLE CORD",  desc2=  "", upc=    "610393096377", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BHDALLYWRAP12",    masterSku=  "BHDALLYWRAP12",    desc=   "BUDDY HUNTERS DALLY WRAPS",    desc2=  "12 PER PACKAGE",   upc=    "086023300020", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "BHL",  masterSku=  "BHL",  desc=   "LEATHER BIT HOBBLE",   desc2=  "", upc=    "610393007663", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BHMT", masterSku=  "BHMT", desc=   "BIT HOBBLE MULE TAPE", desc2=  "", upc=    "610393091891", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BHR",  masterSku=  "BHR",  desc=   "RAWHIDE BIT HOBBLE",   desc2=  "", upc=    "610393007656", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BHS-BLA-H",    masterSku=  "BHS-BLA-H",    desc=   "BOOMERS HOCK SOCK BLACK HORSE",    desc2=  "", upc=    "804381007944", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITAA20",  masterSku=  "BITAA20",  desc=   "CLASSIC EQUINE BIT ",  desc2=  "ARGENTINE ARROW SNAFFLE MP",   upc=    "610393014159", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITAA22",  masterSku=  "BITAA22",  desc=   "CLASSIC EQUINE BIT ",  desc2=  "ARGENTINE TWIST WIRE DOGBONE M",   upc=    "610393014326", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITCCD20", masterSku=  "BITCCD20", desc=   "CLOVER CENTER D-RING", desc2=  "SNAFFLE MOUTH",    upc=    "610393068329", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITCSS10", masterSku=  "BITCSS10", desc=   "CALVARY STAR SCROLL",  desc2=  "CORRECTION MP",    upc=    "610393071657", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITCSS41", masterSku=  "BITCSS41", desc=   "CALVARY STAR SCROLL",  desc2=  "SHORT SPOON W/ ROLLER",    upc=    "610393071664", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITCSS52", masterSku=  "BITCSS52", desc=   "CALVARY STAR SCROLL",  desc2=  "PORTED MOUTH W/ ROLLER",   upc=    "610393071671", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITHSS11", masterSku=  "BITHSS11", desc=   "HORSESHOE 7 SHANK W/GS TRIM",  desc2=  "COPPER WRAPPED CORRCTN MOUTH", upc=    "610393046969", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITHSS27", masterSku=  "BITHSS27", desc=   "HORSESHOE 7 SHANK W/GS TRIM",  desc2=  "FRENCH MOUTH COPPER INLAY",    upc=    "610393046976", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITHSS60", masterSku=  "BITHSS60", desc=   "HORSESHOE 7 SHANK W/GS TRIM",  desc2=  "LOW PORT BARREL MOUTH",    upc=    "610393046983", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITHSS70", masterSku=  "BITHSS70", desc=   "HORSESHOE 7 SHANK W/GS TRIM",  desc2=  "SQUARE HINGE PORT MOUTH",  upc=    "610393046990", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITLSS30", masterSku=  "BITLSS30", desc=   "LIGHTNING SEVEN SHANK",    desc2=  "CHAIN MP", upc=    "610393071688", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITLSS41", masterSku=  "BITLSS41", desc=   "LIGHTNING SEVEN SHANK",    desc2=  "SHORT SPOON MP W/ ROLLER", upc=    "610393071695", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITLSS60", masterSku=  "BITLSS60", desc=   "LIGHTNING SEVEN SHANK",    desc2=  "LOW PORT BARREL MP",   upc=    "610393071701", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITMS41",  masterSku=  "BITMS41",  desc=   "BIT MOONSHANK-SPOON W/ROLLER", desc2=  "", upc=    "610393067131", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITMS42",  masterSku=  "BITMS42",  desc=   "BIT MOONSHANK-SPADE W/ROLLER", desc2=  "", upc=    "610393067148", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITMS51",  masterSku=  "BITMS51",  desc=   "BIT MOONSHANK HOODED MED PORT",    desc2=  "", upc=    "610393067124", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITMS52",  masterSku=  "BITMS52",  desc=   "BIT MOONSHANK-PORTED MOUTH",   desc2=  "W/ROLLER", upc=    "610393067155", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITWD10",  masterSku=  "BITWD10",  desc=   "WAVE DOT SHANK",   desc2=  "CORRECTION MP",    upc=    "610393076584", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITWD41",  masterSku=  "BITWD41",  desc=   "WAVE DOT SHANK",   desc2=  "SPOON W/ROLLER MP",    upc=    "610393076591", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BITWD52",  masterSku=  "BITWD52",  desc=   "WAVE DOT SHANK",   desc2=  "PORTED MOUTH/W ROLLER MP", upc=    "610393076607", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BOZOSP",   masterSku=  "BOZOSP",   desc=   "BOZO SIDEPULL",    desc2=  "", upc=    "610393068091", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BOZOSPS",  masterSku=  "BOZOSPS",  desc=   "BOZO SIDEPULL SHORT SHANK",    desc2=  "", upc=    "610393084664", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR1BNK16BK",   masterSku=  "BR1BNK16BK",   desc=   "BARREL REINS 1  BRAIDED NYLON W/ KNOTS",   desc2=  "BLACK",    upc=    "610393104393", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR1BNK16FCGR", masterSku=  "BR1BNK16FCGR", desc=   "BARREL REINS 1  BRAIDED NYLON W/ KNOTS",   desc2=  "FUCHSIA GREEN",    upc=    "610393104409", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR1BNK16GRGY", masterSku=  "BR1BNK16GRGY", desc=   "BARREL REINS 1  BRAIDED NYLON W/ KNOTS",   desc2=  "GREEN STEEL GREY", upc=    "610393104423", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR1BNK16PRGY", masterSku=  "BR1BNK16PRGY", desc=   "BARREL REINS 1  BRAIDED NYLON W/ KNOTS",   desc2=  "PURPLE STEEL GREY",    upc=    "610393104416", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR34BL",   masterSku=  "BR34BL",   desc=   "3/4 BIO/LAT BARREL REINS", desc2=  "", upc=    "610393079271", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR34L",    masterSku=  "BR34L",    desc=   "BARREL REIN 3/4 LATIGO",   desc2=  "", upc=    "610393066837", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR58B2L",  masterSku=  "BR58B2L",  desc=   "BARREL REINS 5/8 2 PLAT BRAID",    desc2=  "CHOCOLATE HARNESS",    upc=    "610393060224", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR58BLL",  masterSku=  "BR58BLL",  desc=   "BARREL REINS 5/8 W/CHOC LACE", desc2=  "CHOC HARNESS ENDS",    upc=    "610393072142", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR5BBM",   masterSku=  "BR5BBM",   desc=   "5 BRAID BARREL REINS", desc2=  "BLENDED MOHAIR",   upc=    "610393088228", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BR78B5LK", masterSku=  "BR78B5LK", desc=   "BARREL REINS 7/8 5 PLAT BRAID",    desc2=  "W/KNOTS",  upc=    "610393060231", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BRH58B3",  masterSku=  "BRH58B3",  desc=   "5/8 HARNESS BARREL REIN",  desc2=  "3 BRAID",  upc=    "610393085173", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BSCRAPER", masterSku=  "BSCRAPER", desc=   "CASHEL BOOT SCRAPER",  desc2=  "", upc=    "804381030713", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP123216BKTL",   masterSku=  "BTFP123216BKTL",   desc=   "BLANKET TOP 1/2 FELT BOTTOM",  desc2=  "32X34 BLACK TEAL", upc=    "610393104294", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP123216CFPR",   masterSku=  "BTFP123216CFPR",   desc=   "BLANKET TOP 1/2 FELT BOTTOM",  desc2=  "32X34 COFFEE PURPLE",  upc=    "610393104270", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP123216CHTQ",   masterSku=  "BTFP123216CHTQ",   desc=   "BLANKET TOP 1/2 FELT BOTTOM",  desc2=  "32X34 CHOCOLATE TURQUOISE",    upc=    "610393104287", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP123416NVBL",   masterSku=  "BTFP123416NVBL",   desc=   "BLANKET TOP 1/2 FELT BOTTOM",  desc2=  "34X38 NAVY BLUE",  upc=    "610393104324", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP123416SLTN",   masterSku=  "BTFP123416SLTN",   desc=   "BLANKET TOP 1/2 FELT BOTTOM",  desc2=  "34X38 SLATE TAN",  upc=    "610393104317", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP123416TNRD",   masterSku=  "BTFP123416TNRD",   desc=   "BLANKET TOP 1/2 FELT BOTTOM",  desc2=  "34X38 TAN RED",    upc=    "610393104300", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP343216BKTL",   masterSku=  "BTFP343216BKTL",   desc=   "BLANKET TOP 3/4 FELT BOTTOM",  desc2=  "32X34 BLACK TEAL", upc=    "610393104331", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP343216CFPR",   masterSku=  "BTFP343216CFPR",   desc=   "BLANKET TOP 3/4 FELT BOTTOM",  desc2=  "32X34 COFFEE PURPLE",  upc=    "610393104348", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP343216CHTQ",   masterSku=  "BTFP343216CHTQ",   desc=   "BLANKET TOP 3/4 FELT BOTTOM",  desc2=  "32X34 CHOCOLATE TURQUOISE",    upc=    "610393104355", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP343416NVBL",   masterSku=  "BTFP343416NVBL",   desc=   "BLANKET TOP 3/4 FELT BOTTOM",  desc2=  "34X38 NAVY BLUE",  upc=    "610393104362", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP343416SLTN",   masterSku=  "BTFP343416SLTN",   desc=   "BLANKET TOP 3/4 FELT BOTTOM",  desc2=  "34X38 SLATE TAN",  upc=    "610393104379", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BTFP343416TNRD",   masterSku=  "BTFP343416TNRD",   desc=   "BLANKET TOP 3/4 FELT BOTTOM",  desc2=  "34X38 TAN RED",    upc=    "610393104386", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "BUCKSTP12",    masterSku=  "BUCKSTP12",    desc=   "BUCKET STRAP ",    desc2=  "W/NYLON WEBBING & LOGO",   upc=    "610393013213", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CALFHDBK", masterSku=  "CALFHD",   desc=   "CALF HEAD BLACK",  desc2=  "", upc=    "610393096810", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "CALFHDGR", masterSku=  "CALFHD",   desc=   "CALF HEAD GREEN",  desc2=  "", upc=    "610393096827", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "CALFHDPK", masterSku=  "CALFHD",   desc=   "CALF HEAD PINK",   desc2=  "", upc=    "610393096803", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "CAP-4",    masterSku=  "CAP-4",    desc=   "CASHEL CAP MED BLACK 4",   desc2=  "", upc=    "804381006183", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "CAP-5 1/2",    masterSku=  "CAP-5 1/2",    desc=   "CASHEL CAP LONG BLACK 5 1/2",  desc2=  "", upc=    "804381006206", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "CAP-BRIM", masterSku=  "CAP-BRIM", desc=   "SUNBONNET BRIM",   desc2=  "", upc=    "804381008989", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "CARDH-102",    masterSku=  "CARDH",    desc=   "CARDHOLDER CHEST BASKETSTAMP", desc2=  "", upc=    "804381030041", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHEST BASKETSTAMP",    dem2=   ""  },
                new Item() {sku =   "CARDH-108",    masterSku=  "CARDH",    desc=   "CARDHOLDER CHEST DAISY",   desc2=  "", upc=    "804381030102", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHEST DAISY",  dem2=   ""  },
                new Item() {sku =   "CARDH-107",    masterSku=  "CARDH",    desc=   "CARDHOLDER CHEST DESERT FLOWER",   desc2=  "", upc=    "804381030096", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHEST DESERT FLOWER",  dem2=   ""  },
                new Item() {sku =   "CARDH-109",    masterSku=  "CARDH",    desc=   "CARDHOLDER CHEST SPRING FLOWER",   desc2=  "", upc=    "804381030119", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHEST SPRING FLOWER",  dem2=   ""  },
                new Item() {sku =   "CARDH-104",    masterSku=  "CARDH",    desc=   "CARDHOLDER CHEST WEAVE",   desc2=  "", upc=    "804381030065", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHEST WEAVE",  dem2=   ""  },
                new Item() {sku =   "CARDH-101",    masterSku=  "CARDH",    desc=   "CARDHOLD CHOC BASKETSTAMP",    desc2=  "", upc=    "804381030034", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHOC BASKETSTAMP", dem2=   ""  },
                new Item() {sku =   "CARDH-103",    masterSku=  "CARDH",    desc=   "CARDHOLDER CHOC WEAVE",    desc2=  "", upc=    "804381030058", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CHOC WEAVE",   dem2=   ""  },
                new Item() {sku =   "CARDH-110",    masterSku=  "CARDH",    desc=   "CARDHOLDER NAT PRAIRIE FLOWER",    desc2=  "", upc=    "804381030157", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "NAT PRAIRIE FLOWER",   dem2=   ""  },
                new Item() {sku =   "CARDH-105",    masterSku=  "CARDH",    desc=   "CARDHOLDER NAT SPIDERSTAMP",   desc2=  "", upc=    "804381030072", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "NAT SPIDERSTAMP",  dem2=   ""  },
                new Item() {sku =   "CARDH-106",    masterSku=  "CARDH",    desc=   "CARDHOLDER 2 TONE FLOWER", desc2=  "", upc=    "804381030089", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "TONE FLOWER",  dem2=   ""  },
                new Item() {sku =   "CATCH12",  masterSku=  "CATCH12",  desc=   "CATCH ROPE 3/8 35' XS",    desc2=  "BOX OF 12",    upc=    "610393100692", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CAVDROPE", masterSku=  "CAVDROPE", desc=   "DOUBLE ROPE CAVESSON", desc2=  "", upc=    "610393094465", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CAVH", masterSku=  "CAVH", desc=   "CAVESON ", desc2=  "ADJUSTABLE ROUND HARNESS", upc=    "610393006819", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CAVRAWHIDE",   masterSku=  "CAVRAWHIDE",   desc=   "RAWHIDE BRAIDED CAVESSON", desc2=  "", upc=    "610393094458", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CAVSTRING",    masterSku=  "CAVSTRING",    desc=   "STRING CAVESSON",  desc2=  "", upc=    "610393094601", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CB15", masterSku=  "CB15", desc=   "COOLER BAG 15",    desc2=  "", upc=    "610393099309", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CB15HL",   masterSku=  "CB15HL",   desc=   "COOLER BAG 15 HOTLEAF",    desc2=  "", upc=    "610393102269", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CBFP100C", masterSku=  "CBFP", desc=   "CLASSIC BLENDED FELT PAD 1",   desc2=  "CONTOURED 31X32",  upc=    "610393046624", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31 X 32 - 1 FELT", dem2=   ""  },
                new Item() {sku =   "CBFP340C", masterSku=  "CBFP", desc=   "CLASSIC BLENDED FELT PAD 3/4", desc2=  "CONTOURED 31X32",  upc=    "610393046631", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31 X 32 - 3/4 FELT",   dem2=   ""  },
                new Item() {sku =   "CC10215BBNV",  masterSku=  "CC102",    desc=   "SINGLE COMPARTMENT ROPE BAG",  desc2=  "2015 BLACKBERRY NAVY", upc=    "610393098333", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "BLACKBERRY NAVY",  dem2=   ""  },
                new Item() {sku =   "CC10215CHTN",  masterSku=  "CC102",    desc=   "SINGLE COMPARTMENT ROPE BAG",  desc2=  "2015 CHOCOLATE TAN",   upc=    "610393098340", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "CHOCOLATE TAN",    dem2=   ""  },
                new Item() {sku =   "CC10216PDRD",  masterSku=  "CC102",    desc=   "SINGLE COMPARTMENT ROPE BAG",  desc2=  "2016 PLAID RED",   upc=    "610393102566", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "PLAID RED",    dem2=   ""  },
                new Item() {sku =   "CC200215BBTN", masterSku=  "CC2002",   desc=   "DELUXE ROPE BAG 2015", desc2=  "BLACKBERRY TAN",   upc=    "610393098401", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "BLACKBERRY TAN",   dem2=   ""  },
                new Item() {sku =   "CC200215NVCH", masterSku=  "CC2002",   desc=   "DELUXE ROPE BAG 2015", desc2=  "NAVY CHOCOLATE",   upc=    "610393098395", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "NAVY CHOCOLATE",   dem2=   ""  },
                new Item() {sku =   "CC200215PDBK", masterSku=  "CC2002",   desc=   "DELUXE ROPE BAG 2015", desc2=  "PLAID BLACK",  upc=    "610393098388", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "PLAID BLACK",  dem2=   ""  },
                new Item() {sku =   "CC200215RPDLG",    masterSku=  "CC2002",   desc=   "RATTLER DELUXE ROPE BAG 2015", desc2=  "PLAID LIME GREEN", upc=    "610393098371", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "PLAID LIME GREEN", dem2=   ""  },
                new Item() {sku =   "CC200415NV",   masterSku=  "CC2004",   desc=   "SUPER DELUXE ROPE BAG 2015",   desc2=  "NAVY CHOCOLATE",   upc=    "610393100364", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "NAVY CHOCOLATE",   dem2=   ""  },
                new Item() {sku =   "CC200415BK",   masterSku=  "CC2004",   desc=   "SUPER DELUXE ROPE BAG 2015",   desc2=  "PLAID BLACK",  upc=    "610393098319", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "PLAID BLACK",  dem2=   ""  },
                new Item() {sku =   "CC4PRITHCHIE", masterSku=  "CC4PRITCHIE",  desc=   "UNISEX RITCHIE CAP",   desc2=  "4-PACK",   upc=    "610393097626", brand=  "CLASSIC",  code=   "CAPS", dem1=   "UNISEX",   dem2=   ""  },
                new Item() {sku =   "CC4PWC",   masterSku=  "CC4PWC",   desc=   "WOMEN'S CLASSIC CAP",  desc2=  "4-PACK",   upc=    "610393090603", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC4PWM",   masterSku=  "CC4PWM",   desc=   "WOMEN'S MARTIN CAP",   desc2=  "4-PACK",   upc=    "610393090610", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC4PWR",   masterSku=  "CC4PWR",   desc=   "WOMEN'S RATTLER CAP",  desc2=  "4-PACK",   upc=    "610393090627", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC6P6P",   masterSku=  "CC6P6P",   desc=   "CLASSIC CAP 6 PNL 6 PACK", desc2=  "", upc=    "610393010427", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC6P6PCE", masterSku=  "CC6P6PCE", desc=   "CLASSIC EQUINE CAP 6 PNL", desc2=  "6 PACK",   upc=    "610393066912", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC6P6PFITTEDRB",   masterSku=  "CC6P6PFITTEDRB",   desc=   "FITTED CLASSIC CAPS 6 PNL 6 PK",   desc2=  "REGULAR BILL", upc=    "610393083674", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC6P6PKID",    masterSku=  "CC6P6PKID",    desc=   "CLASSIC CAP 6 PANEL/6 PACK KID",   desc2=  "", upc=    "610393005959", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CC4PWCE",  masterSku=  "CC6PWCE",  desc=   "WOMEN'S CLASSIC EQUINE CAP",   desc2=  "4-PACK",   upc=    "610393097619", brand=  "CLASSIC",  code=   "CAPS", dem1=   "4-PACK",   dem2=   ""  },
                new Item() {sku =   "CCBPBK",   masterSku=  "CCBPBK",   desc=   "CLASSIC CONTOUR BARREL PAD BLK",   desc2=  "", upc=    "610393013701", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CCC",  masterSku=  "CCC",  desc=   "CAVESON/CRN CHANNEL .75 x 1.5",    desc2=  "", upc=    "804381006213", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "1.5",  dem2=   ""  },
                new Item() {sku =   "CCC-II",   masterSku=  "CCC",  desc=   "CAVESON/CRN CHANNEL II .75x 2",    desc2=  "", upc=    "804381017271", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "2",    dem2=   ""  },
                new Item() {sku =   "CCC100N31-24", masterSku=  "CCC100N31",    desc=   "CLASSIC COLT CINCH 31 STRAND", desc2=  "MOHAIR 24 NATURAL",    upc=    "610393091464", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "24",   dem2=   "COLT 31"   },
                new Item() {sku =   "CCC100N31-26", masterSku=  "CCC100N31",    desc=   "CLASSIC COLT CINCH 31 STRAND", desc2=  "MOHAIR 26 NATURAL",    upc=    "610393091471", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "COLT 31"   },
                new Item() {sku =   "CCCH", masterSku=  "CCCH", desc=   "CURB CHAIN CHANNEL",   desc2=  "", upc=    "804381021926", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "CCF100",   masterSku=  "CCF100",   desc=   "CLASSIC CONTOUR FLEX PAD", desc2=  "1",    upc=    "610393003641", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CCF340",   masterSku=  "CCF340",   desc=   "CLASSIC CONTOUR FLEX PAD", desc2=  "3/4",  upc=    "610393099293", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CCHROBK",  masterSku=  "CCHROBK",  desc=   "HANGING ROPE ORGANIZER BLACK", desc2=  "", upc=    "610393067391", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CCPRO14BKC",   masterSku=  "CCPRO",    desc=   "PROFESSIONAL ROPE BAG",    desc2=  "BLACK CLASSIC",    upc=    "610393094205", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "CLASSIC",  dem2=   ""  },
                new Item() {sku =   "CCPRO14BKR",   masterSku=  "CCPRO",    desc=   "PROFESSIONAL ROPE BAG",    desc2=  "BLACK RATTLER",    upc=    "610393094212", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "RATTLER",  dem2=   ""  },
                new Item() {sku =   "CDN100BL", masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLACK LARGE",  upc=    "610393010090", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "CDN100BM", masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLACK MEDIUM", upc=    "610393010106", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100BS", masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLACK SMALL",  upc=    "610393010113", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "CDN100BXL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLACK EXTRA LARGE",    upc=    "610393010120", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "X-LARGE"   },
                new Item() {sku =   "CDN100BLL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLUE LARGE",   upc=    "610393080475", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLUE", dem2=   "LARGE" },
                new Item() {sku =   "CDN100BLM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLUE MEDIUM",  upc=    "610393080468", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLUE", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100BLS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "BLUE SMALL",   upc=    "610393080451", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLUE", dem2=   "SMALL" },
                new Item() {sku =   "CDN100CHL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "CHOCOLATE LARGE",  upc=    "610393080086", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CHOCOLATE",    dem2=   "LARGE" },
                new Item() {sku =   "CDN100CHM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "CHOCOLATE MEDIUM", upc=    "610393080093", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CHOCOLATE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100CHS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "CHOCOLATE SMALL",  upc=    "610393080109", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CHOCOLATE",    dem2=   "SMALL" },
                new Item() {sku =   "CDN100COL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "CORAL LARGE",  upc=    "610393095028", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CORAL",    dem2=   "LARGE" },
                new Item() {sku =   "CDN100COM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "CORAL MEDIUM", upc=    "610393095035", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CORAL",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100COS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "CORAL SMALL",  upc=    "610393095042", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CORAL",    dem2=   "SMALL" },
                new Item() {sku =   "CDN100FCL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "FUCHSIA LARGE",    upc=    "610393084107", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "FUCHSIA",  dem2=   "LARGE" },
                new Item() {sku =   "CDN100FCM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "FUCHSIA MED",  upc=    "610393084114", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "FUCHSIA",  dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100FCS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "FUCHSIA SMALL",    upc=    "610393086835", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "FUCHSIA",  dem2=   "SMALL" },
                new Item() {sku =   "CDN100GYL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "GREY LARGE",   upc=    "610393098623", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "GREY", dem2=   "LARGE" },
                new Item() {sku =   "CDN100GYM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "GREY MEDIUM",  upc=    "610393098616", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "GREY", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100GYS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "GREY SMALL",   upc=    "610393098609", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "GREY", dem2=   "SMALL" },
                new Item() {sku =   "CDN100LGL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "LIME GREEN LARGE", upc=    "610393070605", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "LIME", dem2=   "LARGE" },
                new Item() {sku =   "CDN100LGM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "LIME GREEN MEDIUM",    upc=    "610393070599", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "LIME", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100LGS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "LIME GREEN SMALL", upc=    "610393086866", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "LIME", dem2=   "SMALL" },
                new Item() {sku =   "CDN100PRL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "PURPLE  LARGE",    upc=    "610393071404", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "PURPLE",   dem2=   "LARGE" },
                new Item() {sku =   "CDN100PRM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "PURPLE  MEDIUM",   upc=    "610393071411", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "PURPLE",   dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100PRS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "PURPLE  SMALL",    upc=    "610393086842", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "PURPLE",   dem2=   "SMALL" },
                new Item() {sku =   "CDN100RDL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "RED LARGE",    upc=    "610393080505", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "RED",  dem2=   "LARGE" },
                new Item() {sku =   "CDN100RDM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "RED MEDIUM",   upc=    "610393080499", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "RED",  dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100RDS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "RED SMALL",    upc=    "610393080482", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "RED",  dem2=   "SMALL" },
                new Item() {sku =   "CDN100TLL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "TEAL LARGE",   upc=    "610393101910", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TEAL", dem2=   "LARGE" },
                new Item() {sku =   "CDN100TLM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "TEAL MEDIUM",  upc=    "610393101927", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TEAL", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100TLS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "TEAL SMALL",   upc=    "610393101903", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TEAL", dem2=   "SMALL" },
                new Item() {sku =   "CDN100LBL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "TURQUOISE LARGE",  upc=    "610393070582", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TURQUOISE",    dem2=   "LARGE" },
                new Item() {sku =   "CDN100LBM",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "TURQUOISE MEDIUM", upc=    "610393070575", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TURQUOISE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100LBS",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "TURQUOISE SMALL",  upc=    "610393086859", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TURQUOISE",    dem2=   "SMALL" },
                new Item() {sku =   "CDN100WL", masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "WHITE LARGE",  upc=    "610393010137", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "CDN100WM", masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "WHITE MEDIUM", upc=    "610393010144", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CDN100WS", masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "WHITE SMALL",  upc=    "610393010151", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "CDN100WXL",    masterSku=  "CDN100",   desc=   "CE DYNO NO-TURN BELL BOOT",    desc2=  "WHITE EXTRA LARGE",    upc=    "610393010168", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "X-LARGE"   },
                new Item() {sku =   "CDNDL16CTL",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "CHOCOLATE TRIBAL LARGE",   upc=    "610393101958", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CHOCOLATE TRIBAL", dem2=   "LARGE" },
                new Item() {sku =   "CDNDL16CTM",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "CHOCOLATE TRIBAL MEDIUM",  upc=    "610393101941", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CHOCOLATE TRIBAL", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDNDL16CTS",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "CHOCOLATE TRIBAL SMALL",   upc=    "610393101934", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "CHOCOLATE TRIBAL", dem2=   "SMALL" },
                new Item() {sku =   "CDNDL16PPL",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "PURPLE PEACOCK LARGE", upc=    "610393102436", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "PURPLE PEACOCK",   dem2=   "LARGE" },
                new Item() {sku =   "CDNDL16PPM",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "PURPLE PEACOCK MEDIUM",    upc=    "610393102443", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "PURPLE PEACOCK",   dem2=   "MEDIUM"    },
                new Item() {sku =   "CDNDL16PPS",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "PURPLE PEACOCK SMALL", upc=    "610393102450", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "PURPLE PEACOCK",   dem2=   "SMALL" },
                new Item() {sku =   "CDNDL15TDL",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "TEAL DIAMOND LARGE",   upc=    "610393101798", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TEAL DIAMOND", dem2=   "LARGE" },
                new Item() {sku =   "CDNDL15TDM",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "TEAL DIAMOND MEDIUM",  upc=    "610393101804", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TEAL DIAMOND", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDNDL15TDS",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "TEAL DIAMOND SMALL",   upc=    "610393101811", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "TEAL DIAMOND", dem2=   "SMALL" },
                new Item() {sku =   "CDNDL15WLL",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "WHITE LIPS LARGE", upc=    "610393101743", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE LIPS",   dem2=   "LARGE" },
                new Item() {sku =   "CDNDL15WLM",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "WHITE LIPS MEDIUM",    upc=    "610393101750", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE LIPS",   dem2=   "MEDIUM"    },
                new Item() {sku =   "CDNDL15WLS",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "WHITE LIPS SMALL", upc=    "610393101767", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE LIPS",   dem2=   "SMALL" },
                new Item() {sku =   "CDNDL16ZPL",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "ZEBRA PURPLE LARGE",   upc=    "610393102252", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "ZEBRA PURPLE", dem2=   "LARGE" },
                new Item() {sku =   "CDNDL16ZPM",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "ZEBRA PURPLE MEDIUM",  upc=    "610393102245", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "ZEBRA PURPLE", dem2=   "MEDIUM"    },
                new Item() {sku =   "CDNDL16ZPS",   masterSku=  "CDNDL",    desc=   "DYNO DESIGNER LINE BELL BOOT", desc2=  "ZEBRA PURPLE SMALL",   upc=    "610393102238", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "ZEBRA PURPLE", dem2=   "SMALL" },
                new Item() {sku =   "CE-BLA-L", masterSku=  "CE-BLA",   desc=   "COMFORT EARS BLACK LARGE WB",  desc2=  "", upc=    "804381008217", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CE-BLA-M", masterSku=  "CE-BLA",   desc=   "COMFORT EARS BLACK MED ARB-HRS",   desc2=  "", upc=    "804381008613", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CE-BLA-M/L-M", masterSku=  "CE-BLA",   desc=   "COMFORT EARS BLK MED/LRG MULE",    desc2=  "", upc=    "804381008422", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "MULE", dem2=   ""  },
                new Item() {sku =   "CECHB15BK",    masterSku=  "CECHB15BK",    desc=   "CE BASIC HAY BAG 2015",    desc2=  "BLACK",    upc=    "610393098418", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CEHGCBK",  masterSku=  "CEHGC",    desc=   "CLASSIC EQUINE HANGING ",  desc2=  "GROOM CASE BLACK", upc=    "610393008530", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "CEHGC16CT",    masterSku=  "CEHGC",    desc=   "CE HANGING GROOM CASE 2016",   desc2=  "CHOCOLATE TRIBAL", upc=    "610393102320", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CHOCOLATE TRIBAL", dem2=   ""  },
                new Item() {sku =   "CEHGC16CK",    masterSku=  "CEHGC",    desc=   "CE HANGING GROOM CASE 2016",   desc2=  "CORAL KNIGHT", upc=    "610393102313", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "CEHGC16PD",    masterSku=  "CEHGC",    desc=   "CE HANGING GROOM CASE 2016",   desc2=  "PLUM DAZE",    upc=    "610393102337", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLUM DAZE",    dem2=   ""  },
                new Item() {sku =   "CEHGC15S", masterSku=  "CEHGC",    desc=   "CE HANGING GROOM CASE 2015",   desc2=  "SERAPE",   upc=    "610393101835", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "SERAPE",   dem2=   ""  },
                new Item() {sku =   "CEHGC15TD",    masterSku=  "CEHGC",    desc=   "CE HANGING GROOM CASE 2015",   desc2=  "TEAL DIAMOND", upc=    "610393101828", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "CEMB15",   masterSku=  "CEMB15",   desc=   "CE MEDS BAG 2015", desc2=  "", upc=    "610393100326", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CENS14BKL",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BLACK LARGE",  upc=    "610393096124", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "CENS14BKM",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BLACK MEDIUM", upc=    "610393096131", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CENS14BKS",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BLACK SMALL",  upc=    "610393096148", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "CENS14BKXL",   masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BLACK X LARGE",    upc=    "610393096186", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BLACK",    dem2=   "X-LARGE"   },
                new Item() {sku =   "CENS14BGL",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BURGUNDY LARGE",   upc=    "610393096094", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BURGUNDY", dem2=   "LARGE" },
                new Item() {sku =   "CENS14BGM",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BURGUNDY MEDIUM",  upc=    "610393096100", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BURGUNDY", dem2=   "MEDIUM"    },
                new Item() {sku =   "CENS14BGS",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BURGUNDY SMALL",   upc=    "610393096117", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BURGUNDY", dem2=   "SMALL" },
                new Item() {sku =   "CENS14BGXL",   masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "BURGUNDY X LARGE", upc=    "610393096209", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "BURGUNDY", dem2=   "X-LARGE"   },
                new Item() {sku =   "CENS14CHRL",   masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "CHARCOAL LARGE",   upc=    "610393096155", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "CHARCOAL", dem2=   "LARGE" },
                new Item() {sku =   "CENS14CHRM",   masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "CHARCOAL MEDIUM",  upc=    "610393096162", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "CHARCOAL", dem2=   "MEDIUM"    },
                new Item() {sku =   "CENS14CHRS",   masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "CHARCOAL SMALL",   upc=    "610393096179", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "CHARCOAL", dem2=   "SMALL" },
                new Item() {sku =   "CENS14CHRXL",  masterSku=  "CENS", desc=   "CE NYLON SHEET 2014",  desc2=  "CHARCOAL X LARGE", upc=    "610393096193", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "CHARCOAL", dem2=   "X-LARGE"   },
                new Item() {sku =   "CENS16HLL",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2016",  desc2=  "HOT LEAF LARGE",   upc=    "610393102726", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "HOT LEAF", dem2=   "LARGE" },
                new Item() {sku =   "CENS16HLM",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2016",  desc2=  "HOT LEAF MEDIUM",  upc=    "610393102719", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "HOT LEAF", dem2=   "MEDIUM"    },
                new Item() {sku =   "CENS16HLS",    masterSku=  "CENS", desc=   "CE NYLON SHEET 2016",  desc2=  "HOT LEAF SMALL",   upc=    "610393102733", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "HOT LEAF", dem2=   "SMALL" },
                new Item() {sku =   "CENS16HLXL",   masterSku=  "CENS", desc=   "CE NYLON SHEET 2016",  desc2=  "HOT LEAF X LARGE", upc=    "610393102740", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "HOT LEAF", dem2=   "X-LARGE"   },
                new Item() {sku =   "CEPFCBKL", masterSku=  "CEPFC",    desc=   "CE POLAR FLEECE COOLER",   desc2=  "BLACK LARGE",  upc=    "610393087382", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CEPFCBKM", masterSku=  "CEPFC",    desc=   "CE POLAR FLEECE COOLER",   desc2=  "BLACK MEDIUM", upc=    "610393087399", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CEPFCECNVKL",  masterSku=  "CEPFCEC",  desc=   "ECO POLAR FLEECE COOLER",  desc2=  "NAVY LARGE",   upc=    "610393099514", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CEPFCECNVKM",  masterSku=  "CEPFCEC",  desc=   "ECO POLAR FLEECE COOLER",  desc2=  "NAVY MEDIUM",  upc=    "610393099507", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CEQSW154", masterSku=  "CEQSW154", desc=   "CE QUILTED STANDING WRAP 2015",    desc2=  "4 PK 2 - 12 and  2 - 14",  upc=    "610393099330", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESGW12BK",    masterSku=  "CESGW",    desc=   "CLASSIC STRESS GUARD WRAP 12", desc2=  "BLACK",    upc=    "610393067070", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "12",   dem2=   ""  },
                new Item() {sku =   "CESGW14BK",    masterSku=  "CESGW",    desc=   "CLASSIC STRESS GUARD WRAP 14", desc2=  "BLACK",    upc=    "610393067063", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "14",   dem2=   ""  },
                new Item() {sku =   "CESPCW3216BKTL",   masterSku=  "CESPCW3216BKTL",   desc=   "ESP CONTOURED WOOL 32X34 3/4", desc2=  "BLACK TEAL",   upc=    "610393104188", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3216CFPR",   masterSku=  "CESPCW3216CFPR",   desc=   "ESP CONTOURED WOOL 32X34 3/4", desc2=  "COFFEE PURPLE",    upc=    "610393104195", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3216CHTQ",   masterSku=  "CESPCW3216CHTQ",   desc=   "ESP CONTOURED WOOL 32X34 3/4", desc2=  "CHOCOLATE  TURQUOISE", upc=    "610393104201", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3416-1NVBL", masterSku=  "CESPCW3416-1NVBL", desc=   "ESP CONTOURED WOOL 34X38 1",   desc2=  "NAVY BLUE",    upc=    "610393104225", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3416-1SLTN", masterSku=  "CESPCW3416-1SLTN", desc=   "ESP CONTOURED WOOL 34X38 1",   desc2=  "SLATE TAN",    upc=    "610393104249", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3416-1TNRD", masterSku=  "CESPCW3416-1TNRD", desc=   "ESP CONTOURED WOOL 34X38 1",   desc2=  "TAN RED",  upc=    "610393104263", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3416NVBL",   masterSku=  "CESPCW3416NVBL",   desc=   "ESP CONTOURED WOOL 34X38 3/4", desc2=  "NAVY BLUE",    upc=    "610393104218", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3416SLTN",   masterSku=  "CESPCW3416SLTN",   desc=   "ESP CONTOURED WOOL 34X38 3/4", desc2=  "SLATE TAN",    upc=    "610393104232", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPCW3416TNRD",   masterSku=  "CESPCW3416TNRD",   desc=   "ESP CONTOURED WOOL 34X38 3/4", desc2=  "TAN RED",  upc=    "610393104256", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPF1",   masterSku=  "CESPF1",   desc=   "CLASSIC ESP FELT 1",   desc2=  "31 X 32",  upc=    "610393048338", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPF1B",  masterSku=  "CESPF1B",  desc=   "CLASSIC ESP FELT 1 BARREL PAD",    desc2=  "", upc=    "610393066868", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPFF1",  masterSku=  "CESPFF1",  desc=   "CLASSIC ESP FELT FLEECE 1",    desc2=  "31 X 32",  upc=    "610393099934", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3216BKTQ",    masterSku=  "CESPW3216BKTQ",    desc=   "CLASSIC ESP WOOL 32X34",   desc2=  "BLACK TURQUOISE",  upc=    "610393101651", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3216BRTN",    masterSku=  "CESPW3216BRTN",    desc=   "CLASSIC ESP WOOL 32X34",   desc2=  "BROWN TAN",    upc=    "610393101699", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3216SLFC",    masterSku=  "CESPW3216SLFC",    desc=   "CLASSIC ESP WOOL 32X34",   desc2=  "SLATE FUCSHIA",    upc=    "610393101682", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3216SLOR",    masterSku=  "CESPW3216SLOR",    desc=   "CLASSIC ESP WOOL 32X34",   desc2=  "SLATE ORANGE", upc=    "610393101675", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3216SLTQ",    masterSku=  "CESPW3216SLTQ",    desc=   "CLASSIC ESP WOOL 32X34",   desc2=  "SLATE TURQUOISE",  upc=    "610393101668", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3416BKTN",    masterSku=  "CESPW3416BKTN",    desc=   "CLASSIC ESP WOOL 34X38",   desc2=  "BLACK TAN",    upc=    "610393101606", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3416CHBR",    masterSku=  "CESPW3416CHBR",    desc=   "CLASSIC ESP WOOL 34X38",   desc2=  "CHOCOLATE BROWN",  upc=    "610393101644", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3416SLTN",    masterSku=  "CESPW3416SLTN",    desc=   "CLASSIC ESP WOOL 34X38",   desc2=  "SLATE TAN",    upc=    "610393101637", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3416SLWN",    masterSku=  "CESPW3416SLWN",    desc=   "CLASSIC ESP WOOL 34X38",   desc2=  "SLATE WINE",   upc=    "610393101620", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESPW3416TNBR",    masterSku=  "CESPW3416TNBR",    desc=   "CLASSIC ESP WOOL 34X38",   desc2=  "TAN BROWN",    upc=    "610393101613", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESSHIMS", masterSku=  "CESSHIMS", desc=   "CE SADDLE SHIMS",  desc2=  "FOAM 2-5 1-3 3/4 24 1/4 WIDE", upc=    "610393093680", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CESWB154", masterSku=  "CESWBW154",    desc=   "CE STANDING WRAP BANDAGE 2015",    desc2=  "4 PACK 12 FT", upc=    "610393100319", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "CEWPBK",   masterSku=  "CEWPBK",   desc=   "CLASSIC WORK PAD", desc2=  "BLACK",    upc=    "610393087900", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CEWPBR",   masterSku=  "CEWPBR",   desc=   "CLASSIC WORK PAD", desc2=  "BROWN",    upc=    "610393000008", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CF100BKL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "BLACK LARGE",  upc=    "610393099521", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CF100BKM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "BLACK MEDIUM", upc=    "610393099538", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CF100BKS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "BLACK SMALL",  upc=    "610393099545", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CF200BKL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "BLACK LARGE",  upc=    "610393099699", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CF200BKM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "BLACK MEDIUM", upc=    "610393099705", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CF200BKS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "BLACK SMALL",  upc=    "610393099712", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CF100BLL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "BLUE LARGE",   upc=    "610393099552", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLUE", dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CF100BLM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "BLUE MEDIUM",  upc=    "610393099569", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLUE", dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CF100BLS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "BLUE SMALL",   upc=    "610393099576", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLUE", dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CF200BLL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "BLUE LARGE",   upc=    "610393099729", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLUE", dem2=   "HIND LARGE"    },
                new Item() {sku =   "CF200BLM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "BLUE MEDIUM",  upc=    "610393099736", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLUE", dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CF200BLS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "BLUE SMALL",   upc=    "610393099743", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLUE", dem2=   "HIND SMALL"    },
                new Item() {sku =   "CF100PRL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "PURPLE LARGE", upc=    "610393099583", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CF100PRM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "PURPLE MEDIUM",    upc=    "610393099590", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CF100PRS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "PURPLE SMALL", upc=    "610393099873", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CF200PRL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "PURPLE LARGE", upc=    "610393099750", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "HIND LARGE"    },
                new Item() {sku =   "CF200PRM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "PURPLE MEDIUM",    upc=    "610393099767", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CF200PRS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "PURPLE SMALL", upc=    "610393099774", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "HIND SMALL"    },
                new Item() {sku =   "CF100RDL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "RED LARGE",    upc=    "610393099606", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CF100RDM", masterSku=  "CFIT", desc=   "CROSS FIT  BOOT FRONT",    desc2=  "RED MEDIUM",   upc=    "610393099613", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CF100RDS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "RED SMALL",    upc=    "610393099620", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CF200RDL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "RED LARGE",    upc=    "610393099781", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "HIND LARGE"    },
                new Item() {sku =   "CF200RDM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "RED MEDIUM",   upc=    "610393099798", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CF200RDS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "RED SMALL",    upc=    "610393099804", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "HIND SMALL"    },
                new Item() {sku =   "CF100TQL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "TURQUOISE LARGE",  upc=    "610393099637", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CF100TQM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "TURQUOISE MEDIUM", upc=    "610393099644", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CF100TQS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "TURQUOISE SMALL",  upc=    "610393099651", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CF200TQL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "TURQUOISE LARGE",  upc=    "610393099811", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CF200TQM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "TURQUOISE MEDIUM", upc=    "610393099828", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CF200TQS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "TURQUOISE SMALL",  upc=    "610393099835", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CF100WHL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "WHITE LARGE",  upc=    "610393099668", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CF100WHM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "WHITE MEDIUM", upc=    "610393099675", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CF100WHS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT FRONT", desc2=  "WHITE SMALL",  upc=    "610393099682", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CF200WHL", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "WHITE LARGE",  upc=    "610393099842", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CF200WHM", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "WHITE MEDIUM", upc=    "610393099859", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CF200WHS", masterSku=  "CFIT", desc=   "CROSS FIT BOOT HIND",  desc2=  "WHITE SMALL",  upc=    "610393099866", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CFMAL",    masterSku=  "CFML", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  " LONG NOSE",   upc=    "804381014645", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMDL",    masterSku=  "CFML", desc=   "FLY MASK DRAFT",   desc2=  "LONG NOSE",    upc=    "804381014690", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "CFMFL",    masterSku=  "CFML", desc=   "FLY MASK FOAL/MINI",   desc2=  "LONG NOSE",    upc=    "804381014737", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "CFMHL",    masterSku=  "CFML", desc=   "FLY MASK HORSE",   desc2=  "LONG NOSE",    upc=    "804381014775", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBL",   masterSku=  "CFML", desc=   "FLY MASK WARMBLOOD",   desc2=  "LONG NOSE",    upc=    "804381014959", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMWL",    masterSku=  "CFML", desc=   "FLY MASK WEANLING/SM PONY",    desc2=  "LONG NOSE",    upc=    "804381014997", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WEANLING", dem2=   ""  },
                new Item() {sku =   "CFMYL",    masterSku=  "CFML", desc=   "FLY MASK YEARLING/LG PONY",    desc2=  "LONG NOSE",    upc=    "804381015031", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMALE",   masterSku=  "CFMLE",    desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "LONG NOSE EARS",   upc=    "804381014652", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMDLE",   masterSku=  "CFMLE",    desc=   "FLY MASK DRAFT",   desc2=  "LONG NOSE EARS",   upc=    "804381014706", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "CFMFLE",   masterSku=  "CFMLE",    desc=   "FLY MASK FOAL/MINI",   desc2=  "LONG NOSE EARS",   upc=    "804381014744", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "CFMHLE",   masterSku=  "CFMLE",    desc=   "FLY MASK HORSE",   desc2=  "LONG NOSE EARS",   upc=    "804381014782", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBLE",  masterSku=  "CFMLE",    desc=   "FLY MASK WARMBLOOD",   desc2=  "LONG NOSE EARS",   upc=    "804381014966", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMWLE",   masterSku=  "CFMLE",    desc=   "FLY MASK WEANLING/SM PONY",    desc2=  "LONG NOSE EARS",   upc=    "804381015000", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WEANLING", dem2=   ""  },
                new Item() {sku =   "CFMYLE",   masterSku=  "CFMLE",    desc=   "FLY MASK YEARLING/LG PONY",    desc2=  "LONG NOSE EARS",   upc=    "804381015048", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMALE-PNK",   masterSku=  "CFMLE-PNK",    desc=   "FLY MASK ARAB/SM HORSE",   desc2=  " LONG NOSE EARS PINK", upc=    "804381017738", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHLE-PNK",   masterSku=  "CFMLE-PNK",    desc=   "FLY MASK HORSE",   desc2=  "LONG NOSE EARS PINK",  upc=    "804381017721", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBLE-PNK",  masterSku=  "CFMLE-PNK",    desc=   "*FLY MASK WARMBLOOD",  desc2=  "LONG NOSE EARS PINK",  upc=    "804381017950", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMMALE",  masterSku=  "CFMMLE",   desc=   "FLY MASK MULE ARAB",   desc2=  "LONG NOSE EARS",   upc=    "804381014850", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMMDLE",  masterSku=  "CFMMLE",   desc=   "FLY MASK MULE DRAFT",  desc2=  "LONG NOSE EARS",   upc=    "804381014805", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "CFMMFLE",  masterSku=  "CFMMLE",   desc=   "FLY MASK MULE FOAL",   desc2=  "LONG NOSE EARS",   upc=    "804381014829", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "CFMMHLE",  masterSku=  "CFMMLE",   desc=   "FLY MASK MULE HORSE",  desc2=  "LONG NOSE EARS",   upc=    "804381014874", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMMWBLE", masterSku=  "CFMMLE",   desc=   "FLY MASK MULE WARMBLOOD",  desc2=  "LONG NOSE EARS",   upc=    "804381014898", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMMWLE",  masterSku=  "CFMMLE",   desc=   "FLY MASK MULE WEANLING",   desc2=  "LONG NOSE EARS",   upc=    "804381014911", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WEANLING", dem2=   ""  },
                new Item() {sku =   "CFMMYLE",  masterSku=  "CFMMLE",   desc=   "FLY MASK MULE YEARLING",   desc2=  "LONG NOSE EARS",   upc=    "804381014935", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMMASE",  masterSku=  "CFMMSE",   desc=   "FLY MASK MULE ARAB",   desc2=  "STD EARS", upc=    "804381014867", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMMDSE",  masterSku=  "CFMMSE",   desc=   "FLY MASK MULE DRAFT",  desc2=  "STD EARS", upc=    "804381014812", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "CFMMFSE",  masterSku=  "CFMMSE",   desc=   "FLY MASK MULE FOAL",   desc2=  "STD EARS", upc=    "804381014836", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "CFMMHSE",  masterSku=  "CFMMSE",   desc=   "FLY MASK MULE HORSE",  desc2=  "STD EARS", upc=    "804381014881", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMMWBSE", masterSku=  "CFMMSE",   desc=   "FLY MASK MULE WARMBLOOD",  desc2=  "STD EARS", upc=    "804381014904", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMMWSE",  masterSku=  "CFMMSE",   desc=   "FLY MASK MULE WEANLING",   desc2=  "STD EARS", upc=    "804381014928", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WEANLING", dem2=   ""  },
                new Item() {sku =   "CFMMYSE",  masterSku=  "CFMMSE",   desc=   "FLY MASK MULE YEARLING",   desc2=  "STD EARS", upc=    "804381014942", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMAS",    masterSku=  "CFMS", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD",  upc=    "804381014669", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMDS",    masterSku=  "CFMS", desc=   "FLY MASK DRAFT",   desc2=  "STD",  upc=    "804381014713", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "CFMFS",    masterSku=  "CFMS", desc=   "FLY MASK FOAL/MINI",   desc2=  "STD",  upc=    "804381014751", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "CFMHS",    masterSku=  "CFMS", desc=   "FLY MASK HORSE",   desc2=  "STD",  upc=    "804381014799", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBS",   masterSku=  "CFMS", desc=   "FLY MASK WARMBLOOD",   desc2=  "STD",  upc=    "804381014973", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMWS",    masterSku=  "CFMS", desc=   "FLY MASK WEANLING/SM PONY",    desc2=  "STD",  upc=    "804381015017", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WEANLING", dem2=   ""  },
                new Item() {sku =   "CFMYS",    masterSku=  "CFMS", desc=   "FLY MASK YEARLING/LG PONY",    desc2=  "STD",  upc=    "804381015055", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMAS-16BW",   masterSku=  "CFMS-16",  desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD BLUE WEAVE DOTS",  upc=    "804381030225", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE WEAVE DOTS",  dem2=   "ARAB"  },
                new Item() {sku =   "CFMHS-16BW",   masterSku=  "CFMS-16",  desc=   "FLY MASK HORSE",   desc2=  "STD BLUE WEAVE DOTS",  upc=    "804381030270", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE WEAVE DOTS",  dem2=   "HORSE" },
                new Item() {sku =   "CFMAS-16CZ",   masterSku=  "CFMS-16",  desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD CORAL TURQUOISE ZIG ZAG",  upc=    "804381030218", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "CORAL TURQUOISE ZIG ZAG",  dem2=   "ARAB"  },
                new Item() {sku =   "CFMHS-16CZ",   masterSku=  "CFMS-16",  desc=   "FLY MASK HORSE",   desc2=  "STD CORAL TURQUOISE ZIG ZAG",  upc=    "804381030287", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "CORAL TURQUOISE ZIG ZAG",  dem2=   "HORSE" },
                new Item() {sku =   "CFMAS-16HL",   masterSku=  "CFMS-16",  desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD HOTLEAF",  upc=    "804381030201", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HOTLEAF",  dem2=   "ARAB"  },
                new Item() {sku =   "CFMHS-16HL",   masterSku=  "CFMS-16",  desc=   "FLY MASK HORSE",   desc2=  "STD HOTLEAF",  upc=    "804381030294", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HOTLEAF",  dem2=   "HORSE" },
                new Item() {sku =   "CFMAS-16PP",   masterSku=  "CFMS-16",  desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD PURPLE PEACOCK",   upc=    "804381030195", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PURPLE PEACOCK",   dem2=   "ARAB"  },
                new Item() {sku =   "CFMHS-16PP",   masterSku=  "CFMS-16",  desc=   "FLY MASK HORSE",   desc2=  "STD PURPLE PEACOCK",   upc=    "804381030300", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PURPLE PEACOCK",   dem2=   "HORSE" },
                new Item() {sku =   "CFMAS-BL", masterSku=  "CFMS-BL",  desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD BLUE", upc=    "804381029335", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHS-BL", masterSku=  "CFMS-BL",  desc=   "FLY MASK HORSE",   desc2=  "STD BLUE", upc=    "804381029311", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBS-BL",    masterSku=  "CFMS-BL",  desc=   "FLY MASK WARMBLOOD",   desc2=  "STD BLUE", upc=    "804381029359", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMYS-BL", masterSku=  "CFMS-BL",  desc=   "FLY MASK YEARLING/LG PONY",    desc2=  "STD BLUE", upc=    "804381029380", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMASE",   masterSku=  "CFMSE",    desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS", upc=    "804381014683", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMDSE",   masterSku=  "CFMSE",    desc=   "FLY MASK DRAFT",   desc2=  "STD EARS", upc=    "804381014720", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "CFMFSE",   masterSku=  "CFMSE",    desc=   "FLY MASK FOAL/MINI",   desc2=  "STD EARS", upc=    "804381014768", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "CFMHSE",   masterSku=  "CFMSE",    desc=   "FLY MASK HORSE",   desc2=  "STD EARS", upc=    "804381014843", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBSE",  masterSku=  "CFMSE",    desc=   "FLY MASK WARMBLOOD",   desc2=  "STD EARS", upc=    "804381014980", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMWSE",   masterSku=  "CFMSE",    desc=   "FLY MASK WEANLING/SM PONY",    desc2=  "STD EARS", upc=    "804381015024", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WEANLING", dem2=   ""  },
                new Item() {sku =   "CFMYSE",   masterSku=  "CFMSE",    desc=   "FLY MASK YEARLING/LG PONY",    desc2=  "STD EARS", upc=    "804381015062", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMASE-16BW",  masterSku=  "CFMSE-16", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS BLUE WEAVE DOTS", upc=    "804381030263", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE WEAVE DOTS",  dem2=   "ARAB"  },
                new Item() {sku =   "CFMHSE-16BW",  masterSku=  "CFMSE-16", desc=   "FLY MASK HORSE",   desc2=  "STD EARS BLUE WEAVE DOTS", upc=    "804381030324", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE WEAVE DOTS",  dem2=   "HORSE" },
                new Item() {sku =   "CFMASE-16CZ",  masterSku=  "CFMSE-16", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS CORAL TURQUOISE ZIG ZAG", upc=    "804381030256", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "CORAL TURQUOISE ZIG ZAG",  dem2=   "ARAB"  },
                new Item() {sku =   "CFMHSE-16CZ",  masterSku=  "CFMSE-16", desc=   "FLY MASK HORSE",   desc2=  "STD EARS CORAL TURQUOISE ZIG ZAG", upc=    "804381030317", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "CORAL TURQUOISE ZIG ZAG",  dem2=   "HORSE" },
                new Item() {sku =   "CFMASE-16HL",  masterSku=  "CFMSE-16", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS HOTLEAF", upc=    "804381030249", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HOTLEAF",  dem2=   "ARAB"  },
                new Item() {sku =   "CFMHSE-16HL",  masterSku=  "CFMSE-16", desc=   "FLY MASK HORSE",   desc2=  "STD EARS HOTLEAF", upc=    "804381030331", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HOTLEAF",  dem2=   "HORSE" },
                new Item() {sku =   "CFMASE-16PP",  masterSku=  "CFMSE-16", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS PURPLE PEACOCK",  upc=    "804381030232", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PURPLE PEACOCK",   dem2=   "ARAB"  },
                new Item() {sku =   "CFMHSE-16PP",  masterSku=  "CFMSE-16", desc=   "FLY MASK HORSE",   desc2=  "STD EARS PURPLE PEACOCK",  upc=    "804381030348", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PURPLE PEACOCK",   dem2=   "HORSE" },
                new Item() {sku =   "CFMASE-BL",    masterSku=  "CFMSE-BL", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS BLUE",    upc=    "804381029342", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHSE-BL",    masterSku=  "CFMSE-BL", desc=   "FLY MASK HORSE",   desc2=  "STD EARS BLUE",    upc=    "804381029328", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBSE-BL",   masterSku=  "CFMSE-BL", desc=   "FLY MASK WARMBLOOD",   desc2=  "STD EARS BLUE",    upc=    "804381029366", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMYSE-BL",    masterSku=  "CFMSE-BL", desc=   "FLY MASK YEARLING/LG PONY",    desc2=  "STD EARS BLUE",    upc=    "804381029373", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "CFMASE-ORA",   masterSku=  "CFMSE-ORA",    desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS ORANGE",  upc=    "804381023784", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHSE-ORA",   masterSku=  "CFMSE-ORA",    desc=   "FLY MASK HORSE",   desc2=  "STD EARS ORANGE",  upc=    "804381023807", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBSE-ORA",  masterSku=  "CFMSE-ORA",    desc=   "FLY MASK WARMBLOOD",   desc2=  "STD EARS ORANGE",  upc=    "804381023821", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMASE-PNK",   masterSku=  "CFMSE-PNK",    desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD EARS PINK",    upc=    "804381017745", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHSE-PNK",   masterSku=  "CFMSE-PNK",    desc=   "FLY MASK HORSE",   desc2=  "STD EARS PINK",    upc=    "804381017479", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBSE-PNK",  masterSku=  "CFMSE-PNK",    desc=   "*FLY MASK WARMBLOOD",  desc2=  "STD EARS PINK",    upc=    "804381017868", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMAS-ORA",    masterSku=  "CFMS-ORA", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD ORANGE",   upc=    "804381023777", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHS-ORA",    masterSku=  "CFMS-ORA", desc=   "FLY MASK HORSE",   desc2=  "STD ORANGE",   upc=    "804381023791", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBS-ORA",   masterSku=  "CFMS-ORA", desc=   "FLY MASK WARMBLOOD",   desc2=  "STD ORANGE",   upc=    "804381023814", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CFMAS-PNK",    masterSku=  "CFMS-PNK", desc=   "FLY MASK ARAB/SM HORSE",   desc2=  "STD PINK", upc=    "804381018230", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "CFMHS-PNK",    masterSku=  "CFMS-PNK", desc=   "FLY MASK HORSE",   desc2=  "STD PINK", upc=    "804381018247", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "CFMWBS-PNK",   masterSku=  "CFMS-PNK", desc=   "*FLY MASK WARMBLOOD",  desc2=  "STD PINK", upc=    "804381018322", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARM BLOOD",   dem2=   ""  },
                new Item() {sku =   "CG-BLA",   masterSku=  "CG-BLA",   desc=   "BIT GUARD",    desc2=  "BLACK",    upc=    "804381026556", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "CGLOVE08KD",   masterSku=  "CGLOVE08", desc=   "CLASSIC ROPING GLOVE", desc2=  "08 KID - Orange",  upc=    "610393078021", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "KIDS", dem2=   "COTTON"    },
                new Item() {sku =   "CGLOVE08L",    masterSku=  "CGLOVE08", desc=   "CLASSIC ROPING GLOVE", desc2=  "08 LARGE - Green", upc=    "610393077994", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "LARGE",    dem2=   "COTTON"    },
                new Item() {sku =   "CGLOVE08M",    masterSku=  "CGLOVE08", desc=   "CLASSIC ROPING GLOVE", desc2=  "08 MEDIUM - Blue", upc=    "610393078007", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "MEDIUM",   dem2=   "COTTON"    },
                new Item() {sku =   "CGLOVE08S",    masterSku=  "CGLOVE08", desc=   "CLASSIC ROPING GLOVE", desc2=  "08 SMALL - Red",   upc=    "610393078038", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "SMALL",    dem2=   "COTTON"    },
                new Item() {sku =   "CGLOVE08XL",   masterSku=  "CGLOVE08", desc=   "CLASSIC ROPING GLOVE", desc2=  "08 EXTRA LARGE - Purple",  upc=    "610393078014", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "X-LARGE",  dem2=   "COTTON"    },
                new Item() {sku =   "CHCURB",   masterSku=  "CHCURB",   desc=   "COWHORSE CURB STRAP",  desc2=  "HARNESS",  upc=    "610393067810", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CIN-DS-20",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 20 BLK", desc2=  "FEATHER FLEX", upc=    "610393504131", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "20"    },
                new Item() {sku =   "CIN-DS-22",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 22  BLK",    desc2=  "FEATHER FLEX", upc=    "610393504148", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "22"    },
                new Item() {sku =   "CIN-DS-24",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 24  BLK",    desc2=  "FEATHER FLEX", upc=    "610393050317", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "24"    },
                new Item() {sku =   "CIN-DS-26",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 26  BLK",    desc2=  "FEATHER FLEX", upc=    "610393050324", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "26"    },
                new Item() {sku =   "CIN-DS-28",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 28  BLK",    desc2=  "FEATHER FLEX", upc=    "610393050331", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "28"    },
                new Item() {sku =   "CIN-DS-30",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 30  BLK",    desc2=  "FEATHER FLEX", upc=    "610393050348", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "30"    },
                new Item() {sku =   "CIN-DS-32",    masterSku=  "CIN-DS",   desc=   "SHAPED DRESSAGE GIRTH 32  BLK",    desc2=  "FEATHER FLEX", upc=    "610393050355", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "BLACK",    dem2=   "32"    },
                new Item() {sku =   "CIN-JP-36",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  36  BRN",   desc2=  "FEATHER FLEX", upc=    "804381023487", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "36",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-38",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  38  BRN",   desc2=  "FEATHER FLEX", upc=    "804381023494", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "38",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-40",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  40  BRN",   desc2=  "FEATHER FLEX", upc=    "804381023500", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "40",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-42",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  42  BRN",   desc2=  "FEATHER FLEX", upc=    "804381023517", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "42",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-44",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  44  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509457", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "44",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-46",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  46  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509464", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "46",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-48",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  48  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509471", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "48",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-50",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  50  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509488", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "50",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-52",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  52  BRN",   desc2=  "FEATHER FLEX", upc=    "610393519494", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "52",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-54",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  54  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509501", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "54",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-56",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  56  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509518", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "56",   dem2=   ""  },
                new Item() {sku =   "CIN-JP-58",    masterSku=  "CIN-JP",   desc=   "SHAPED JUMP GIRTH  58  BRN",   desc2=  "FEATHER FLEX", upc=    "610393509525", brand=  "CASHEL",   code=   "CSHLCINCH",    dem1=   "58",   dem2=   ""  },
                new Item() {sku =   "CKB100BK", masterSku=  "CKB100BK", desc=   "CLASSIC KNEE BOOT",    desc2=  "", upc=    "610393044989", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "CLASSICFLAG",  masterSku=  "CLASSICFLAG",  desc=   "CLASSIC JUDGES FLAG",  desc2=  "", upc=    "610393093673", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "CLS100B L",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK L FRONT",  upc=    "610393003474", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100B M",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK M FRONT",  upc=    "610393003481", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100B S",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK S FRONT",  upc=    "610393003504", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200B L",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK L HIND",   upc=    "610393003566", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200B M",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK M HIND",   upc=    "610393003573", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200B S",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK S HIND",   upc=    "610393003580", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100CHL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CHOCOLATE FRONT LARGE",    upc=    "610393080130", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100CHM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CHOCOLATE FRONT MEDIUM",   upc=    "610393080123", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100CHS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CHOCOLATE FRONT SMALL",    upc=    "610393080116", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200CHL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CHOCOLATE HIND LARGE", upc=    "610393080161", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200CHM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CHOCOLATE HIND MEDIUM",    upc=    "610393080154", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200CHS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CHOCOLATE HIND SMALL", upc=    "610393080147", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100COL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CORAL FRONT LARGE",    upc=    "610393093529", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100COM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CORAL FRONT MEDIUM",   upc=    "610393093512", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100COS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CORAL FRONT SMALL",    upc=    "610393093505", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200COL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CORAL HIND LARGE", upc=    "610393093536", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200COM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CORAL HIND MEDIUM",    upc=    "610393093543", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200COS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "CORAL HIND SMALL", upc=    "610393093550", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100FCL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "FUCHSIA FRONT LARGE",  upc=    "610393084077", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100FCM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "FUCHSIA FRONT MED",    upc=    "610393084084", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100FCS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "FUCHSIA FRONT SMALL",  upc=    "610393086675", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200FCL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "FUCHSIA HIND LARGE",   upc=    "610393084046", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200FCM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "FUCHSIA HIND MED", upc=    "610393084053", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200FCS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "FUCHSIA HIND SMALL",   upc=    "610393086682", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS10012GPL",  masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "12 GREEN PLAID LARGE", upc=    "610393090139", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREEN PLAID",  dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS10012GPM",  masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "12 GREEN PLAID MEDIUM",    upc=    "610393090122", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREEN PLAID",  dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS10012GPS",  masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "12 GREEN PLAID SMALL", upc=    "610393090115", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREEN PLAID",  dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS20012GPL",  masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "12 GREEN PLAID LARGE", upc=    "610393090191", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREEN PLAID",  dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS20012GPM",  masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "12 GREEN PLAID MEDIUM",    upc=    "610393090184", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREEN PLAID",  dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS20012GPS",  masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "12 GREEN PLAID SMALL", upc=    "610393090177", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREEN PLAID",  dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100LGL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "LIME GREEN FRONT LARGE",   upc=    "610393069869", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIME", dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100LGM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "LIME GREEN FRONT MEDIUM",  upc=    "610393069852", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIME", dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100LGS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "LIME GREEN FRONT SMALL",   upc=    "610393086750", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIME", dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200LGL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "LIME GREEN HIND LARGE",    upc=    "610393069883", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIME", dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200LGM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "LIME GREEN HIND MEDIUM",   upc=    "610393069876", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIME", dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200LGS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "LIME GREEN HIND SMALL",    upc=    "610393086767", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIME", dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100PRL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "PURPLE LGE FRONT", upc=    "610393047904", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100PRM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "PURPLE MED FRONT", upc=    "610393047911", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100PRS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "PURPLE SM FRONT",  upc=    "610393047881", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200PRL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "PURPLE LGE HIND",  upc=    "610393047942", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200PRM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "PURPLE MED HIND",  upc=    "610393047935", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200PRS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "PURPLE SM HIND",   upc=    "610393047928", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE",   dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100R L",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "RED L FRONT",  upc=    "610393011622", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100R M",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "RED M FRONT",  upc=    "610393003528", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100R S",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "RED S FRONT",  upc=    "610393011639", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200R L",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "RED L HIND",   upc=    "610393044668", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200R M",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "RED M HIND",   upc=    "610393003603", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200R S",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "RED S HIND",   upc=    "610393011677", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "RED",  dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100BLL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "ROYAL BLUE L FRONT",   upc=    "610393011608", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ROYAL BLUE",   dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100BLM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "ROYAL BLUE M FRONT",   upc=    "610393003511", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ROYAL BLUE",   dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100BLS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "ROYAL BLUE S FRONT",   upc=    "610393011615", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ROYAL BLUE",   dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200BLL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "ROYAL BLUE L HIND",    upc=    "610393011646", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ROYAL BLUE",   dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200BLM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "ROYAL BLUE M HIND",    upc=    "610393003597", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ROYAL BLUE",   dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200BLS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "ROYAL BLUE S HIND",    upc=    "610393011653", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ROYAL BLUE",   dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100SGYL",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "STEEL GREY FRONT LARGE",   upc=    "610393097824", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100SGYM",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "STEEL GREY FRONT MED", upc=    "610393097831", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100SGYS",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "STEEL GREY FRONT SMALL",   upc=    "610393097848", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200SGYL",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "STEEL GREY HIND LARGE",    upc=    "610393097879", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200SGYM",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "STEEL GREY HIND MED",  upc=    "610393097862", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200SGYS",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "STEEL GREY HIND SMALL",    upc=    "610393097855", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100TLL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "TEAL LARGE",   upc=    "610393102108", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TEAL", dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100TLM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "TEAL MEDIUM",  upc=    "610393102092", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TEAL", dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100TLS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "TEAL SMALL",   upc=    "610393102085", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TEAL", dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200TLL",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "TEAL LARGE",   upc=    "610393102078", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TEAL", dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200TLM",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "TEAL MEDIUM",  upc=    "610393102061", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TEAL", dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200TLS",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "TEAL SMALL",   upc=    "610393102054", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TEAL", dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100LB L",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "TURQUOISE LARGE FRONT",    upc=    "610393086712", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100LB M",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "TURQUOISE MED FRONT",  upc=    "610393067230", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100LB S",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "TURQUOISE SMALL FRONT",    upc=    "610393086729", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200LB L",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "TURQUOISE LARGE  HIND",    upc=    "610393086736", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200LB M",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "TURQUOISE MED HIND",   upc=    "610393067254", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200LB S",   masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM",    desc2=  "TURQUOISE SMALL HIND", upc=    "610393086743", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TURQUOISE",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS100W L",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHI L FRONT",  upc=    "610393003535", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS100W M",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHI M FRONT",  upc=    "610393003542", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS100W S",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHI S FRONT",  upc=    "610393003559", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS200W L",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHI L HIND",   upc=    "610393003610", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS200W M",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHI M HIND",   upc=    "610393003627", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS200W S",    masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHI S HIND",   upc=    "610393003634", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS10016ZCBL", masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "16 ZEBRA COLORBURST LARGE",    upc=    "610393102047", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ZEBRA COLORBURST", dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS10016ZCBM", masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "16 ZEBRA COLORBURST MEDIUM",   upc=    "610393102030", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ZEBRA COLORBURST", dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "CLS10016ZCBS", masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "16 ZEBRA COLORBURST SMALL",    upc=    "610393102023", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ZEBRA COLORBURST", dem2=   "FRONT SMALL"   },
                new Item() {sku =   "CLS20016ZCBL", masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "16 ZEBRA COLORBURST LARGE",    upc=    "610393102016", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ZEBRA COLORBURST", dem2=   "HIND LARGE"    },
                new Item() {sku =   "CLS20016ZCBM", masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "16 ZEBRA COLORBURST MEDIUM",   upc=    "610393102009", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ZEBRA COLORBURST", dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "CLS20016ZCBS", masterSku=  "CLS",  desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "16 ZEBRA COLORBURST SMALL",    upc=    "610393101996", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "ZEBRA COLORBURST", dem2=   "HIND SMALL"    },
                new Item() {sku =   "CLS10011TPM",  masterSku=  "CLS10011TP",   desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "11 TIGER MEDIUM",  upc=    "610393086606", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CLS10011TPL",  masterSku=  "CLS10011TP",   desc=   "CLASSIC LEGACY SYSTEM FRONT",  desc2=  "11 TIGER LARGE",   upc=    "610393086613", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "TIGER",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "CLS20011TPL",  masterSku=  "CLS20011TP",   desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "11 TIGER LARGE",   upc=    "610393086620", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CLS20011TPM",  masterSku=  "CLS20011TP",   desc=   "CLASSIC LEGACY SYSTEM HIND",   desc2=  "11 TIGER MEDIUM",  upc=    "610393086637", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CNB100B L",    masterSku=  "CNB100",   desc=   "CLASSIC NEOPRENE BELL BLK L",  desc2=  "", upc=    "610393003313", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "CNB100B M",    masterSku=  "CNB100",   desc=   "CLASSIC NEOPRENE BELL BLK M",  desc2=  "", upc=    "610393003320", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CNB100B S",    masterSku=  "CNB100",   desc=   "CLASSIC NEOPRENE BELL BLK S",  desc2=  "", upc=    "610393003337", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "CNB100W L",    masterSku=  "CNB100",   desc=   "CLASSIC NEOPRENE BELL WHI L",  desc2=  "", upc=    "610393003344", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "CNB100W M",    masterSku=  "CNB100",   desc=   "CLASSIC NEOPRENE BELL WHI M",  desc2=  "", upc=    "610393003351", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CNB100W S",    masterSku=  "CNB100",   desc=   "CLASSIC NEOPRENE BELL WHI S",  desc2=  "", upc=    "610393003368", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "CNTKVBK L",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR BLK L",   upc=    "610393012278", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "CNTKVBK M",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR BLK M",   upc=    "610393012285", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CNTKVBK S",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR BLK S",   upc=    "610393012292", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "CNTKVBKXL",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR BLK XL",  upc=    "610393010755", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "X-LARGE"   },
                new Item() {sku =   "CNTKVWH L",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR WHI L",   upc=    "610393012421", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "CNTKVWH M",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR WHI M",   upc=    "610393012438", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CNTKVWH S",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR WHI S",   upc=    "610393012445", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "CNTKVWHXL",    masterSku=  "CNTKV",    desc=   "CLASSIC NO TURN BELL BOOT",    desc2=  "W/KEVLAR WHI XL",  upc=    "610393010809", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "X-LARGE"   },
                new Item() {sku =   "CNV-E",    masterSku=  "CNV-E",    desc=   "CASHEL ENGLISH CONVERTER", desc2=  "-PAIR",    upc=    "804381000488", brand=  "CASHEL",   code=   "CSHLBILLET",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "CNV-W",    masterSku=  "CNV-W",    desc=   "CASHEL WESTERN CONVERTER", desc2=  "", upc=    "804381009467", brand=  "CASHEL",   code=   "CSHLBILLET",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "COLORBOOK",    masterSku=  "COLORBOOK",    desc=   "COLOR BOOK BUNDLE OF 12",  desc2=  "", upc=    "610393002460", brand=  "CLASSIC",  code=   "CKIDPROD", dem1=   "", dem2=   ""  },
                new Item() {sku =   "COOLER",   masterSku=  "COOLER",   desc=   "COLDSAVER COOLER ",    desc2=  "18840",    upc=    "610393104911", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "COP100CB", masterSku=  "COP100CB", desc=   "CONTOURPEDIC SADDLE PAD - BLK",    desc2=  "", upc=    "610393003436", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "COP300CB", masterSku=  "COP300CB", desc=   "CONTOURPEDIC SADDLE PAD BLK ", desc2=  "30X30",    upc=    "610393003450", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "COPRCB",   masterSku=  "COPRCB",   desc=   "CONTOUR PEDIC REINER BLACK",   desc2=  "31X32",    upc=    "610393089362", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CRC100N26",    masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR 26 NATURL", upc=    "610393004259", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "ROPER LEATHER" },
                new Item() {sku =   "CRC100N28",    masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR 28 NATURL", upc=    "610393004266", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER LEATHER" },
                new Item() {sku =   "CRC100NN28",   masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR NYLON CENTER 28",   upc=    "610393088143", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER NYLON"   },
                new Item() {sku =   "CRC100N30",    masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR 30 NATURAL",    upc=    "610393004273", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER LEATHER" },
                new Item() {sku =   "CRC100NN30",   masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR NYLON CENTER 30",   upc=    "610393088150", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER NYLON"   },
                new Item() {sku =   "CRC100N32",    masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR 32 NATURL", upc=    "610393004280", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER LEATHER" },
                new Item() {sku =   "CRC100NN32",   masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR NYLON CENTER 32",   upc=    "610393088136", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER NYLON"   },
                new Item() {sku =   "CRC100N34",    masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR 34 NATURL", upc=    "610393004297", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER LEATHER" },
                new Item() {sku =   "CRC100NN34",   masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR NYLON CENTER 34",   upc=    "610393088167", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER NYLON"   },
                new Item() {sku =   "CRC100N36",    masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR 36 NATURL", upc=    "610393004303", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER LEATHER" },
                new Item() {sku =   "CRC100NN36",   masterSku=  "CRC10",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR NYLON CENTER 36",   upc=    "610393088174", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER NYLON"   },
                new Item() {sku =   "CRC100N31-28", masterSku=  "CRC100N31",    desc=   "CLASSIC ROPER CINCH 31 STRAND",    desc2=  "MOHAIR 28 NATURAL",    upc=    "610393102627", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER 31"  },
                new Item() {sku =   "CRC100N31-30", masterSku=  "CRC100N31",    desc=   "CLASSIC ROPER CINCH 31 STRAND",    desc2=  "MOHAIR 30 NATURAL",    upc=    "610393102634", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER 31"  },
                new Item() {sku =   "CRC100N31-32", masterSku=  "CRC100N31",    desc=   "CLASSIC ROPER CINCH 31 STRAND",    desc2=  "MOHAIR 32 NATURAL",    upc=    "610393102610", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER 31"  },
                new Item() {sku =   "CRC100N31-34", masterSku=  "CRC100N31",    desc=   "CLASSIC ROPER CINCH 31 STRAND",    desc2=  "MOHAIR 34 NATURAL",    upc=    "610393102603", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER 31"  },
                new Item() {sku =   "CRC100N31-36", masterSku=  "CRC100N31",    desc=   "CLASSIC ROPER CINCH 31 STRAND",    desc2=  "MOHAIR 36 NATURAL",    upc=    "610393102597", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER 31"  },
                new Item() {sku =   "CRCA26",   masterSku=  "CRCA", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "ALPACA 26",    upc=    "610393076003", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "ROPER" },
                new Item() {sku =   "CRCA28",   masterSku=  "CRCA", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "ALPACA 28",    upc=    "610393076010", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER" },
                new Item() {sku =   "CRCA30",   masterSku=  "CRCA", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "ALPACA 30",    upc=    "610393076027", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER" },
                new Item() {sku =   "CRCA32",   masterSku=  "CRCA", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "ALPACA 32",    upc=    "610393076034", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER" },
                new Item() {sku =   "CRCA34",   masterSku=  "CRCA", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "ALPACA 34",    upc=    "610393076041", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER" },
                new Item() {sku =   "CRCA36",   masterSku=  "CRCA", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "ALPACA 36",    upc=    "610393076058", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER" },
                new Item() {sku =   "CRCB26",   masterSku=  "CRCB", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "BLEND 26", upc=    "610393003832", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "ROPER" },
                new Item() {sku =   "CRCB28",   masterSku=  "CRCB", desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "BLEND 28", upc=    "610393003849", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER" },
                new Item() {sku =   "CRCB30",   masterSku=  "CRCB", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "BLEND 30", upc=    "610393003856", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER" },
                new Item() {sku =   "CRCB32",   masterSku=  "CRCB", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "BLEND 32", upc=    "610393003863", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER" },
                new Item() {sku =   "CRCB34",   masterSku=  "CRCB", desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "BLEND 34", upc=    "610393003870", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER" },
                new Item() {sku =   "CRCB36",   masterSku=  "CRCB", desc=   "CLASSIC ROPER CINCH 27 STRAND ",   desc2=  "BLEND 36", upc=    "610393003887", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER" },
                new Item() {sku =   "CRCMA26",  masterSku=  "CRCMA",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR/ALPACA 26", upc=    "610393091495", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "ROPER" },
                new Item() {sku =   "CRCMA28",  masterSku=  "CRCMA",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR/ALPACA 28", upc=    "610393091501", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER" },
                new Item() {sku =   "CRCMA30",  masterSku=  "CRCMA",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR/ALPACA 30", upc=    "610393091518", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER" },
                new Item() {sku =   "CRCMA32",  masterSku=  "CRCMA",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR/ALPACA 32", upc=    "610393091525", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER" },
                new Item() {sku =   "CRCMA34",  masterSku=  "CRCMA",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR/ALPACA 34", upc=    "610393091532", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER" },
                new Item() {sku =   "CRCMA36",  masterSku=  "CRCMA",    desc=   "CLASSIC ROPER CINCH 27 STRAND",    desc2=  "MOHAIR/ALPACA 36", upc=    "610393091488", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER" },
                new Item() {sku =   "CRJL", masterSku=  "CRJL", desc=   "CALF ROPING JERK LINE",    desc2=  "", upc=    "610393014531", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "CRJLP",    masterSku=  "CRJLP",    desc=   "CALF ROPING JERKLINE PULLEY",  desc2=  "", upc=    "843542013042", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "CRJLPCT",  masterSku=  "CRJLPCT",  desc=   "CR JERKLINE PULLEY & CORD TIE",    desc2=  "", upc=    "610393096384", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "CRNR", masterSku=  "CRNR", desc=   "CALF ROPING NECK ROPE",    desc2=  "", upc=    "610393007571", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "CRNRSQ",   masterSku=  "CRNRSQ",   desc=   "CALF ROPING NECK ROPE",    desc2=  "SQUARE BRAID", upc=    "610393093871", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DS-RW-L",  masterSku=  "CRWEDGE",  desc=   "DRESSAGE/LF REVWEDGE LARGE",   desc2=  "", upc=    "804381003069", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "DRESSAGE"  },
                new Item() {sku =   "JP-RW-L",  masterSku=  "CRWEDGE",  desc=   "JUMP REVERSE WEDGE LARGE", desc2=  "", upc=    "804381004301", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "JUMP"  },
                new Item() {sku =   "WE-RW-L",  masterSku=  "CRWEDGE",  desc=   "WESTERN REVWEDGE L",   desc2=  "", upc=    "804381005964", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "WESTERN"   },
                new Item() {sku =   "DS-RW-M",  masterSku=  "CRWEDGE",  desc=   "DRESSAGE/LF REVWEDGE MEDIUM",  desc2=  "", upc=    "804381003052", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "DRESSAGE"  },
                new Item() {sku =   "WG-RW-M",  masterSku=  "CRWEDGE",  desc=   "WESTERN GAME REVWEDGE",    desc2=  "", upc=    "804381006022", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "GAME/ARAB" },
                new Item() {sku =   "JP-RW-M",  masterSku=  "CRWEDGE",  desc=   "JUMP REVERSEWEDGE MEDIUM", desc2=  "", upc=    "804381004295", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "JUMP"  },
                new Item() {sku =   "WE-RW-M",  masterSku=  "CRWEDGE",  desc=   "WESTERN REVWEDGE M",   desc2=  "", upc=    "804381005957", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "WESTERN"   },
                new Item() {sku =   "DS-RW-XL", masterSku=  "CRWEDGE",  desc=   "DRESSAGE/LF REVWEDGE X-LARGE", desc2=  "", upc=    "804381025108", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "XL",   dem2=   "DRESSAGE"  },
                new Item() {sku =   "WE-RW-XL", masterSku=  "CRWEDGE",  desc=   "WESTERN REVWEDGE XL",  desc2=  "", upc=    "804381005971", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "XL",   dem2=   "WESTERN"   },
                new Item() {sku =   "CSB100B L",    masterSku=  "CSB100",   desc=   "CLASSIC SPLINT BOOT BLK L",    desc2=  "", upc=    "610393004426", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "CSB100B M",    masterSku=  "CSB100",   desc=   "CLASSIC SPLINT BOOT BLK M",    desc2=  "", upc=    "610393004433", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CSB100B S",    masterSku=  "CSB100",   desc=   "CLASSIC SPLINT BOOT BLK S",    desc2=  "", upc=    "610393004440", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "CSB100W L",    masterSku=  "CSB100",   desc=   "CLASSIC SPLINT BOOT WHI L",    desc2=  "", upc=    "610393004457", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "CSB100W M",    masterSku=  "CSB100",   desc=   "CLASSIC SPLINT BOOT WHI M",    desc2=  "", upc=    "610393004464", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CSB100W S",    masterSku=  "CSB100",   desc=   "CLASSIC SPLINT BOOT WHI S",    desc2=  "", upc=    "610393004471", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "CSC100N31-24", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 24 NATURAL",   upc=    "610393082202", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "24",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSC100N31-26", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 26 NATURAL",   upc=    "610393082219", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSC100N31-28", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 28 NATURAL",   upc=    "610393082226", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSC100N31-30", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 30 NATURAL",   upc=    "610393082233", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSC100N31-32", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 32 NATURAL",   upc=    "610393082240", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSC100N31-34", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 34 NATURAL",   upc=    "610393082257", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSC100N31-36", masterSku=  "CSC100",   desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 MOH 36 NATURAL",   upc=    "610393082264", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCA31-26",    masterSku=  "CSCA", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 ALPACA 26",    upc=    "610393082288", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCA31-28",    masterSku=  "CSCA", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 ALPACA 28",    upc=    "610393082271", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCA31-30",    masterSku=  "CSCA", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 ALPACA 30",    upc=    "610393081427", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCA31-32",    masterSku=  "CSCA", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 ALPACA 32",    upc=    "610393082578", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCA31-34",    masterSku=  "CSCA", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 ALPACA 34",    upc=    "610393082561", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCA31-36",    masterSku=  "CSCA", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "100 ALPACA 36",    upc=    "610393082554", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-24",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 24", upc=    "610393082325", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "24",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-26",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 26", upc=    "610393082295", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-28",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 28", upc=    "610393082301", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-30",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 30", upc=    "610393082318", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-32",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 32", upc=    "610393082332", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-34",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 34", upc=    "610393082349", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCB31-36",    masterSku=  "CSCB", desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "BLEND 36", upc=    "610393082356", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "STRAIGHT 31"   },
                new Item() {sku =   "CSCC", masterSku=  "CSCC", desc=   "CURB STRAP",   desc2=  "SI CHAIN SS CLIPS",    upc=    "610393068763", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSCMA31-26",   masterSku=  "CSCMA",    desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "MOHAIR/ALPACA 26", upc=    "610393091549", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "CSCMA31-28",   masterSku=  "CSCMA",    desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "MOHAIR/ALPACA 28", upc=    "610393091594", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "CSCMA31-30",   masterSku=  "CSCMA",    desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "MOHAIR/ALPACA 30", upc=    "610393091587", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "CSCMA31-32",   masterSku=  "CSCMA",    desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "MOHAIR/ALPACA 32", upc=    "610393091570", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "CSCMA31-34",   masterSku=  "CSCMA",    desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "MOHAIR/ALPACA 34", upc=    "610393091563", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "CSCMA31-36",   masterSku=  "CSCMA",    desc=   "CLASSIC STRAIGHT CINCH 31 STRD",   desc2=  "MOHAIR/ALPACA 36", upc=    "610393091556", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "CSDCST",   masterSku=  "CSDCST",   desc=   "CURB STRAP 5 LINK",    desc2=  "DOG CHAIN W/ADJ STRING TIE",   upc=    "610393001944", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSDCST7",  masterSku=  "CSDCST7",  desc=   "CURB STRAP 7 LINK",    desc2=  "DOG CHAIN W/ADJ STRING TIE",   upc=    "610393097497", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSHC3",    masterSku=  "CSHC3",    desc=   "HARNESS CURB CHAIN ",  desc2=  "W/3CHAIN LINKS",   upc=    "610393007458", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSHC5",    masterSku=  "CSHC5",    desc=   "HARNESS CURB CHAIN ",  desc2=  "W/5CHAIN LINKS",   upc=    "610393007373", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSL",  masterSku=  "CSL",  desc=   "CURB STRAP - LATIGO",  desc2=  "", upc=    "610393000596", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSLC3",    masterSku=  "CSLC3",    desc=   "LATIGO CURB CHAIN ",   desc2=  "W/3CHAIN LINKS",   upc=    "610393007526", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSLC5",    masterSku=  "CSLC5",    desc=   "LATIGO CURB CHAIN ",   desc2=  "W/5CHAIN LINKS",   upc=    "610393007465", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSLHH",    masterSku=  "CSLHH",    desc=   "LEATHER AND HORSE HAIR ",  desc2=  "CURB STRAP",   upc=    "610393007670", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSNC3",    masterSku=  "CSNC3",    desc=   "NYLON CURB CHAIN", desc2=  "W/ 3 CHAIN LINK",  upc=    "610393099262", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSNC5",    masterSku=  "CSNC5",    desc=   "NYLON CURB CHAIN", desc2=  "W/ 5 CHAIN LINK",  upc=    "610393099255", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSPF", masterSku=  "CSPF", desc=   "CASHEL PERFORMANCE FELT PAD",  desc2=  "", upc=    "804381029533", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSSCH",    masterSku=  "CSSCH",    desc=   "ENGLISH CURB CHAIN",   desc2=  "FLAT SS CHAIN W/HOOKS",    upc=    "610393002156", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSSCL",    masterSku=  "CSSCL",    desc=   "CURB STRAP",   desc2=  "FLAT CHAIN - LATIGO STRAPS",   upc=    "610393000602", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSSCN",    masterSku=  "CSSCN",    desc=   "CURB STRAP",   desc2=  "FLAT CHAIN - NYLON STRAPS",    upc=    "610393099248", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSSCR",    masterSku=  "CSSCR",    desc=   "CURB STRAP",   desc2=  "FLAT CHAIN -HARNESS STRAPS",   upc=    "610393007533", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSW100BL", masterSku=  "CSW100",   desc=   "CE SAFETY WRAP",   desc2=  "BLACK LARGE",  upc=    "610393081977", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "CSW100BM", masterSku=  "CSW100",   desc=   "CE SAFETY WRAP",   desc2=  "BLACK MEDIUM", upc=    "610393081960", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CSW100BS", masterSku=  "CSW100",   desc=   "CE SAFETY WRAP",   desc2=  "BLACK SMALL",  upc=    "610393081953", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "CSW100WL", masterSku=  "CSW100",   desc=   "CE SAFETY WRAP",   desc2=  "WHITE LARGE",  upc=    "610393081946", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "CSW100WM", masterSku=  "CSW100",   desc=   "CE SAFETY WRAP",   desc2=  "WHITE MEDIUM", upc=    "610393081939", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "CSW100WS", masterSku=  "CSW100",   desc=   "CE SAFETY WRAP",   desc2=  "WHITE SMALL",  upc=    "610393081922", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "CSWFP3216BEBL",    masterSku=  "CSWFP3216BEBL",    desc=   "SENSORFLEX WOOL FELT PAD 32X34",   desc2=  "BEIGE BLUE",   upc=    "610393101538", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3216BEBR",    masterSku=  "CSWFP3216BEBR",    desc=   "SENSORFLEX WOOL FELT PAD 32X34",   desc2=  "BEIGE BROWN",  upc=    "610393101545", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3216SLFC",    masterSku=  "CSWFP3216SLFC",    desc=   "SENSORFLEX WOOL FELT PAD 32X34",   desc2=  "SLATE FUCHSIA",    upc=    "610393101514", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3216SLTL",    masterSku=  "CSWFP3216SLTL",    desc=   "SENSORFLEX WOOL FELT PAD 32X34",   desc2=  "SLATE TEAL",   upc=    "610393101521", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3216TNCH",    masterSku=  "CSWFP3216TNCH",    desc=   "SENSORFLEX WOOL FELT PAD 32X34",   desc2=  "TAN CHOCOLATE",    upc=    "610393101507", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3416BKBR",    masterSku=  "CSWFP3416BKBR",    desc=   "SENSORFLEX WOOL FELT PAD 34X38",   desc2=  "BLACK BROWN",  upc=    "610393101552", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3416BKNV",    masterSku=  "CSWFP3416BKNV",    desc=   "SENSORFLEX WOOL FELT PAD 34X38",   desc2=  "BLACK NAVY",   upc=    "610393101569", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3416TNBG",    masterSku=  "CSWFP3416TNBG",    desc=   "SENSORFLEX WOOL FELT PAD 34X38",   desc2=  "TAN BURGUNDY", upc=    "610393101576", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3416TNBL",    masterSku=  "CSWFP3416TNBL",    desc=   "SENSORFLEX WOOL FELT PAD 34X38",   desc2=  "TAN BLUE", upc=    "610393101583", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSWFP3416TNBR",    masterSku=  "CSWFP3416TNBR",    desc=   "SENSORFLEX WOOL FELT PAD 34X38",   desc2=  "TAN BROWN",    upc=    "610393101590", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CSYNGLRHL",    masterSku=  "CSYNGLR",  desc=   "CLASSIC SYNTHETIC ROPING GLOVE",   desc2=  "RIGHT HAND LARGE", upc=    "610393046556", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CSYNGLRHM",    masterSku=  "CSYNGLR",  desc=   "CLASSIC SYNTHETIC ROPING GLOVE",   desc2=  "RIGHT HAND MEDIUM",    upc=    "610393046563", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CSYNGLRHS",    masterSku=  "CSYNGLR",  desc=   "CLASSIC SYNTHETIC ROPING GLOVE",   desc2=  "RIGHT HAND SMALL", upc=    "610393046570", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "CSYNGLRHXL",   masterSku=  "CSYNGLR",  desc=   "CLASSIC SYNTHETIC ROPING GLOVE",   desc2=  "RIGHT HAND X-LARGE",   upc=    "610393046587", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "X LARGE",  dem2=   ""  },
                new Item() {sku =   "DS-W-L",   masterSku=  "CWEDGE",   desc=   "DRESSAGE/LF WEDGE LARGE",  desc2=  "", upc=    "804381002888", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "DRESSAGE"  },
                new Item() {sku =   "JP-W-L",   masterSku=  "CWEDGE",   desc=   "JUMP WEDGE LARGE", desc2=  "", upc=    "804381004127", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "JUMP"  },
                new Item() {sku =   "LP-W-L",   masterSku=  "CWEDGE",   desc=   "WEDGE NARROW L - CASHEL LOLLIP",   desc2=  "", upc=    "804381015666", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "NARROW"    },
                new Item() {sku =   "WE-W-L",   masterSku=  "CWEDGE",   desc=   "WESTERN WEDGE L",  desc2=  "", upc=    "804381005933", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "WESTERN"   },
                new Item() {sku =   "DS-W-M",   masterSku=  "CWEDGE",   desc=   "DRESSAGE/LF WEDGE MEDIUM", desc2=  "", upc=    "804381002871", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "DRESSAGE"  },
                new Item() {sku =   "WG-W-M",   masterSku=  "CWEDGE",   desc=   "WESTERN GAME/ARAB WEDGE",  desc2=  "", upc=    "804381006015", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "GAME/ARAB" },
                new Item() {sku =   "JP-W-M",   masterSku=  "CWEDGE",   desc=   "JUMP WEDGE MEDIUM",    desc2=  "", upc=    "804381004110", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "JUMP"  },
                new Item() {sku =   "LP-W-M",   masterSku=  "CWEDGE",   desc=   "WEDGE NARROW M - CASHEL LOLLIP",   desc2=  "", upc=    "804381009511", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "NARROW"    },
                new Item() {sku =   "WE-W-M",   masterSku=  "CWEDGE",   desc=   "WESTERN WEDGE M",  desc2=  "", upc=    "804381005926", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "WESTERN"   },
                new Item() {sku =   "JP-W-S",   masterSku=  "CWEDGE",   desc=   "JUMP WEDGE SMALL", desc2=  "", upc=    "804381004103", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "SMALL",    dem2=   "JUMP"  },
                new Item() {sku =   "DS-W-XL",  masterSku=  "CWEDGE",   desc=   "DRESSAGE/LF WEDGE X-LARGE",    desc2=  "", upc=    "804381002895", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "XL",   dem2=   "DRESSAGE"  },
                new Item() {sku =   "WE-W-XL",  masterSku=  "CWEDGE",   desc=   "WESTERN WEDGE XL", desc2=  "", upc=    "804381005940", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "XL",   dem2=   "WESTERN"   },
                new Item() {sku =   "CWP-L",    masterSku=  "CWP",  desc=   "COLLAPSIBLE WATER PAIL",   desc2=  "LARGE",    upc=    "804381022602", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CWP-M",    masterSku=  "CWP",  desc=   "COLLAPSIBLE WATER PAIL",   desc2=  "MEDIUM",   upc=    "804381022619", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CXBNVS",   masterSku=  "CXBNV",    desc=   "CE X TRAINER BLANKET", desc2=  "NAVY SMALL",   upc=    "610393096445", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "CXSBKL",   masterSku=  "CXS",  desc=   "CE WINDBREAKER SHEET", desc2=  "BLACK LARGE",  upc=    "610393096551", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "CXSBKM",   masterSku=  "CXS",  desc=   "CE WINDBREAKER SHEET", desc2=  "BLACK MEDIUM", upc=    "610393096568", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "CXSBKS",   masterSku=  "CXS",  desc=   "CE WINDBREAKER SHEET", desc2=  "BLACK SMALL",  upc=    "610393096575", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "CXSBKXL",  masterSku=  "CXS",  desc=   "CE WINDBREAKER SHEET", desc2=  "BLACK X LARGE",    upc=    "610393096582", brand=  "WEQUINE",  code=   "BLANKETS", dem1=   "X-LARGE",  dem2=   ""  },
                new Item() {sku =   "DAD-SA-BLA",   masterSku=  "DAD-SA-BLA",   desc=   "DADDLE SADDLE BLACK",  desc2=  "", upc=    "804381018070", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "DALLYWRAP12",  masterSku=  "DALLYWRAP12",  desc=   "DALLY WRAP-12 PER PACKAGE",    desc2=  "", upc=    "610393067599", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DC-BLA-ENG",   masterSku=  "DC-BLA-ENG",   desc=   "DUST COVER BLACK ENGLISH", desc2=  "", upc=    "804381013600", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "DGROOMTBK",    masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE",    desc2=  "BLACK",    upc=    "610393071114", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "DGROOMT16CT",  masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE 2016",   desc2=  "CHOCOLATE TRIBAL", upc=    "610393102382", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CHOCOLATE TRIBAL", dem2=   ""  },
                new Item() {sku =   "DGROOMT16CK",  masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE 2016",   desc2=  "CORAL KNIGHT", upc=    "610393102375", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "DGROOMT13FS",  masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE 2013",   desc2=  "FLOWER STRIPES",   upc=    "610393093178", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "FLOWER STRIPES",   dem2=   ""  },
                new Item() {sku =   "DGROOMT16PD",  masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE 2016",   desc2=  "PLUM DAZE",    upc=    "610393102399", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLUM DAZE",    dem2=   ""  },
                new Item() {sku =   "DGROOMT15S",   masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE 2015",   desc2=  "SERAPE",   upc=    "610393101866", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "SERAPE",   dem2=   ""  },
                new Item() {sku =   "DGROOMT15TD",  masterSku=  "DGROOMT",  desc=   "DELUXE GROOM TOTE 2015",   desc2=  "TEAL DIAMOND", upc=    "610393101873", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "DS-1/0-L", masterSku=  "DS-",  desc=   "DRESSAGE/LF 1 LARGE",  desc2=  "", upc=    "804381002741", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "1" },
                new Item() {sku =   "DS-1/2-L", masterSku=  "DS-",  desc=   "*DRESSAGE/LF 1/2  LARGE",  desc2=  "", upc=    "804381002468", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "1/2"   },
                new Item() {sku =   "DS-3/4-L", masterSku=  "DS-",  desc=   "DRESSAGE/LF 3/4  LARGE",   desc2=  "", upc=    "804381002604", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "3/4"   },
                new Item() {sku =   "DS-3/4-M", masterSku=  "DS-",  desc=   "DRESSAGE/LF 3/4  MEDIUM",  desc2=  "", upc=    "804381002598", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "3/4"   },
                new Item() {sku =   "DS-1/0-XL",    masterSku=  "DS-",  desc=   "DRESSAGE/LF 1  X-LARGE",   desc2=  "", upc=    "804381002758", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "X LARGE",  dem2=   "1" },
                new Item() {sku =   "DVDAG1HD", masterSku=  "DVDAG1HD", desc=   "DVD ALDO GARIBAY", desc2=  "HEADING 1",    upc=    "884501561556", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDAG1HL", masterSku=  "DVDAG1HL", desc=   "DVD ALDO GARIBAY", desc2=  "HEELING 1",    upc=    "884501561570", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDBC1",   masterSku=  "DVDBC1",   desc=   "DVD BARNES COOPER 1",  desc2=  "", upc=    "610393069838", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDBG1",   masterSku=  "DVDBG1",   desc=   "DVD BENNY GUITRONE 1", desc2=  "", upc=    "643157373223", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDC01",   masterSku=  "DVDC01",   desc=   "DVD CODY OHL 1",   desc2=  "", upc=    "610393066851", brand=  "RATTLER",  code=   "RVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDDK1",   masterSku=  "DVDDK1",   desc=   "DVD DENA KIRKPATRICK", desc2=  "STAGES OF TRAINING",   upc=    "610393084541", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDJB1",   masterSku=  "DVDJB1",   desc=   "DVD JAKE BARNES I",    desc2=  "", upc=    "610393047812", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDJOEBSINGLE",    masterSku=  "DVDJOEBSINGLE",    desc=   "DVD JOE BEAVER",   desc2=  "SINGLE",   upc=    "610393100678", brand=  "RATTLER",  code=   "RVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDJDY1",  masterSku=  "DVDJY1",   desc=   "DVD JD YATES 1",   desc2=  "TRAINING THE HEAD HORSE",  upc=    "610393049496", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "HEAD HORSES",  dem2=   ""  },
                new Item() {sku =   "DVDJDY2",  masterSku=  "DVDJY1",   desc=   "DVD JD YATES 2",   desc2=  "TRAINING THE HEEL HORSE",  upc=    "643157320296", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "HEEL HORSES",  dem2=   ""  },
                new Item() {sku =   "DVDPH1",   masterSku=  "DVDPH",    desc=   "DVD PHIL HAUGEN 1",    desc2=  "FOUNDATION AND FUNDAMENTALS",  upc=    "094922818393", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "FOUNDATION AND FUNDAMENTALS",  dem2=   ""  },
                new Item() {sku =   "DVDPH2",   masterSku=  "DVDPH",    desc=   "DVD PHIL HAUGEN 2",    desc2=  "FOUNDATION TO FINISH", upc=    "711508262653", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "FOUNDATION TO FINISH", dem2=   ""  },
                new Item() {sku =   "DVDRG1HD", masterSku=  "DVDRG1HD", desc=   "DVD RICKY GREEN",  desc2=  "HEADING METHOD 1", upc=    "610393006048", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG1HL", masterSku=  "DVDRG1HL", desc=   "DVD RICKY GREEN",  desc2=  "HEELING METHOD 1", upc=    "610393006055", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG2HD", masterSku=  "DVDRG2HD", desc=   "DVD RICKY GREEN",  desc2=  "HEADING METHOD 2", upc=    "610393006062", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG2HL", masterSku=  "DVDRG2HL", desc=   "DVD RICKY GREEN",  desc2=  "HEELING METHOD 2", upc=    "610393006079", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG3HD", masterSku=  "DVDRG3HD", desc=   "DVD RICKY GREEN",  desc2=  "HEADING METHOD 3", upc=    "610393006000", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG3HL", masterSku=  "DVDRG3HL", desc=   "DVD RICKY GREEN",  desc2=  "HEELING METHOD 3", upc=    "610393006017", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG4HD", masterSku=  "DVDRG4HD", desc=   "DVD RICKEY GREEN", desc2=  "HEADING METHOD 4", upc=    "610393078717", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRG4HL", masterSku=  "DVDRG4HL", desc=   "DVD RICKEY GREEN", desc2=  "HEELING METHOD 4", upc=    "610393078724", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDRS1",   masterSku=  "DVDRS1",   desc=   "DVD RICH SKELTON VOL 1",   desc2=  "", upc=    "610393067001", brand=  "RATTLER",  code=   "RVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDTM1HD", masterSku=  "DVDTM1HD", desc=   "DVD TYLER MAGNUS", desc2=  "HEADING 1",    upc=    "610393068107", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDTM1HL", masterSku=  "DVDTM1HL", desc=   "DVD TYLER MAGNUS", desc2=  "HEELING 1",    upc=    "610393068114", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDWWCSHD",    masterSku=  "DVDWWCSHD",    desc=   "DVD WALT WOODARD", desc2=  "CHAMPION STYLE HEADING",   upc=    "610393089683", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "DVDWWCSHL",    masterSku=  "DVDWWCSHL",    desc=   "DVD WALT WOODARD", desc2=  "CHAMPION STYLE HEELING",   upc=    "610393089690", brand=  "CLASSIC",  code=   "CVIDEOS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "EFMAS",    masterSku=  "EFM",  desc=   "E STANDARD FLYMASK",   desc2=  "ARAB/SMALL HORSE", upc=    "804381030485", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "EFMHS",    masterSku=  "EFM",  desc=   "E STANDARD FLYMASK",   desc2=  "HORSE",    upc=    "804381030508", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "EFMWBS",   masterSku=  "EFM",  desc=   "E STANDARD FLYMASK",   desc2=  "WARMBLOOD",    upc=    "804381030492", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "EFMYS",    masterSku=  "EFM",  desc=   "E STANDARD FLYMASK",   desc2=  "YEARLING/LG PONY", upc=    "804381030478", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "EGP-UL-WH/WH", masterSku=  "EGP-UL-WH/WH", desc=   "BABY SDL PAD WHITE  PKG 3",    desc2=  "COTTON TWILL DIAMON QLTD", upc=    "610393044866", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "EMBB", masterSku=  "EMBB", desc=   "MAGNTX BELL BOOT", desc2=  "", upc=    "610393085753", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "", dem2=   ""  },
                new Item() {sku =   "EMHW", masterSku=  "EMHW", desc=   "MAGNTX HOCK WRAP", desc2=  "", upc=    "610393085661", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "", dem2=   ""  },
                new Item() {sku =   "EMKW", masterSku=  "EMKW", desc=   "MAGNTX KNEE WRAP", desc2=  "", upc=    "610393085678", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "", dem2=   ""  },
                new Item() {sku =   "EMMASK",   masterSku=  "EMMASK",   desc=   "MAGNTX MASK",  desc2=  "", upc=    "610393085685", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "", dem2=   ""  },
                new Item() {sku =   "EMRP", masterSku=  "EMRP", desc=   "MAGNTX RELIEF PAD",    desc2=  "", upc=    "610393085692", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "", dem2=   ""  },
                new Item() {sku =   "EMSHEETL", masterSku=  "EMSHEET",  desc=   "MAGNTX SHEET", desc2=  "LARGE 80-82",  upc=    "610393085708", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "EMSHEETM", masterSku=  "EMSHEET",  desc=   "MAGNTX SHEET", desc2=  "MEDIUM 76-78", upc=    "610393085715", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "EMSHEETS", masterSku=  "EMSHEET",  desc=   "MAGNTX SHEET", desc2=  "SMALL 72-74",  upc=    "610393085722", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "EMSHEETXS",    masterSku=  "EMSHEET",  desc=   "MAGNTX SHEET", desc2=  "EXTRA SMALL 68-70",    upc=    "610393085739", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "X- SMALL", dem2=   ""  },
                new Item() {sku =   "EMTW", masterSku=  "EMTW", desc=   "MAGNTX TENDON WRAP",   desc2=  "", upc=    "610393085746", brand=  "WEQUINE",  code=   "MAGNETIC", dem1=   "", dem2=   ""  },
                new Item() {sku =   "EPN-L",    masterSku=  "EPLUG",    desc=   "EAR PLUG W/O STRING LRG HORSE",    desc2=  "", upc=    "804381020509", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   "W/O STRING"    },
                new Item() {sku =   "EP-II-L",  masterSku=  "EPLUG",    desc=   "EARPLUG LRG(LRG HORSE)W/STRING",   desc2=  "", upc=    "804381006282", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   "WITH STRING"   },
                new Item() {sku =   "EPN-M",    masterSku=  "EPLUG",    desc=   "EAR PLUG W/O STRING AVG HORSE",    desc2=  "", upc=    "804381020493", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   "W/O STRING"    },
                new Item() {sku =   "EP-II-M",  masterSku=  "EPLUG",    desc=   "EARPLUGS MEDIUM(AVERAGE HORSE)",   desc2=  "", upc=    "804381006275", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   "WITH STRING"   },
                new Item() {sku =   "EPN-S",    masterSku=  "EPLUG",    desc=   "EAR PLUG W/O STRING SMALL/PONY",   desc2=  "", upc=    "804381020486", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   "W/O STRING"    },
                new Item() {sku =   "EP-II-S",  masterSku=  "EPLUG",    desc=   "EARPLUGS SMALL(PONY)", desc2=  "", upc=    "804381006268", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   "WITH STRING"   },
                new Item() {sku =   "EPN-XL",   masterSku=  "EPLUG",    desc=   "EAR PLUG W/O STRING X-LARGE",  desc2=  "", upc=    "804381020523", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X-LARGE",  dem2=   "W/O STRING"    },
                new Item() {sku =   "EP-II-XL", masterSku=  "EPLUG",    desc=   "EARPLUGS X-LARGE(DRAFT/MULE)", desc2=  "", upc=    "804381006299", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X-LARGE",  dem2=   "WITH STRING"   },
                new Item() {sku =   "EW200SGBK",    masterSku=  "EWSG", desc=   "CE EZ WRAP II HIND BLACK", desc2=  "STD SIZE NEOPRENE VELCRO", upc=    "610393013749", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "BACK"  },
                new Item() {sku =   "EW100SGBK",    masterSku=  "EWSG", desc=   "CE EZ WRAP II FRONT BLACK",    desc2=  "STD SIZE NEOPRENE VELCRO", upc=    "610393013725", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT" },
                new Item() {sku =   "EW200SGWH",    masterSku=  "EWSG", desc=   "CE EZ WRAP II HIND WHITE", desc2=  "STD SIZE NEOPRENE VELCRO", upc=    "610393013756", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "BACK"  },
                new Item() {sku =   "EW100SGWH",    masterSku=  "EWSG", desc=   "CE EZ WRAP II FRONT WHITE",    desc2=  "STD SIZE NEOPRENE VELCRO", upc=    "610393013732", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT" },
                new Item() {sku =   "EZK-2.5",  masterSku=  "EZK",  desc=   "EZ KNEE 2 1/2",    desc2=  "", upc=    "804381000464", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "2 1/2",    dem2=   ""  },
                new Item() {sku =   "EZK-3.0",  masterSku=  "EZK",  desc=   "EZ KNEE 3",    desc2=  "", upc=    "804381000471", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "3",    dem2=   ""  },
                new Item() {sku =   "FB15", masterSku=  "FB",   desc=   "FAN BAG",  desc2=  "", upc=    "610393103235", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "FB134",    masterSku=  "FB134",    desc=   "FLANK BILLET (PAIR OF BILLETS)",   desc2=  "NO TOOLING - GRANBURY",    upc=    "610393000626", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FB134C",   masterSku=  "FB134C",   desc=   "CHESTNUT FLANK BILLET / PAIR", desc2=  "NO TOOLING - GRANBURY",    upc=    "610393047621", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FB134N",   masterSku=  "FB134N",   desc=   "FLANK BILLET W/ NEOLITE CENTER",   desc2=  "NATURAL- NO TOOLING GRANBURY", upc=    "610393094571", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FB134NC",  masterSku=  "FB134NC",  desc=   "FLANK BILLET W/ NEOLITE CENTER",   desc2=  "CHESTNUT - NO TOOLING GRANBURY",   upc=    "610393094588", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FC212",    masterSku=  "FC212",    desc=   "2-1/2 NATURAL FLANK CINCH",    desc2=  "", upc=    "610393000633", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FC412",    masterSku=  "FC412",    desc=   "4-1/2 NATURAL FLANK CINCH",    desc2=  "GRANBURY", upc=    "610393000640", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FC7",  masterSku=  "FC7",  desc=   "7 NATURAL FLANK CINCH",    desc2=  "GRANBURY", upc=    "610393075983", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FC7XL",    masterSku=  "FC7XL",    desc=   "7 NATURAL FLANK CINCH +4", desc2=  "GRANBURY", upc=    "610393089454", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FC812",    masterSku=  "FC812",    desc=   "8-1/2 NATURAL FLANK CINCH",    desc2=  "GRANBURY", upc=    "610393000657", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FCHS", masterSku=  "FCHS", desc=   "FLANK CINCH HOBBLE",   desc2=  "STRAP-BIOTHANE",   upc=    "610393067087", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "REGULAR",  dem2=   ""  },
                new Item() {sku =   "FCHSR",    masterSku=  "FCHS", desc=   "FLANK CINCH HOBBLE ROPER", desc2=  "STRAP-BIOTHANE",   upc=    "610393079684", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "ROPER",    dem2=   ""  },
                new Item() {sku =   "FCINCH2S26",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "STRAIGHT 26",  upc=    "610393089225", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "FCINCH2R28",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "ROPER 28", upc=    "610393089171", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER" },
                new Item() {sku =   "FCINCH2S28",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "STRAIGHT 28",  upc=    "610393089232", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "FCINCH2R30",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "ROPER 30", upc=    "610393089188", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER" },
                new Item() {sku =   "FCINCH2S30",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "STRAIGHT 30",  upc=    "610393089249", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "FCINCH2R32",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "ROPER 32", upc=    "610393089195", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER" },
                new Item() {sku =   "FCINCH2S32",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "STRAIGHT 32",  upc=    "610393089256", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "FCINCH2R34",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "ROPER 34", upc=    "610393089201", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER" },
                new Item() {sku =   "FCINCH2S34",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "STRAIGHT 34",  upc=    "610393089263", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "FCINCH2R36",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "ROPER 36", upc=    "610393089218", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER" },
                new Item() {sku =   "FCINCH2S36",   masterSku=  "FCINCH",   desc=   "FLEECE CINCH 2",   desc2=  "STRAIGHT 36",  upc=    "610393089270", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "FFRCBK28", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BLACK 28", upc=    "610393094762", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BLACK",    dem2=   "28"    },
                new Item() {sku =   "FFRCBK30", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BLACK 30", upc=    "610393094755", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BLACK",    dem2=   "30"    },
                new Item() {sku =   "FFRCBK32", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BLACK 32", upc=    "610393094748", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BLACK",    dem2=   "32"    },
                new Item() {sku =   "FFRCBK34", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BLACK 34", upc=    "610393094731", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BLACK",    dem2=   "34"    },
                new Item() {sku =   "FFRCBK36", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BLACK 36", upc=    "610393094724", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BLACK",    dem2=   "36"    },
                new Item() {sku =   "FFRCBR28", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BROWN 28", upc=    "610393094717", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BROWN",    dem2=   "28"    },
                new Item() {sku =   "FFRCBR30", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BROWN 30", upc=    "610393094700", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BROWN",    dem2=   "30"    },
                new Item() {sku =   "FFRCBR32", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BROWN 32", upc=    "610393094694", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BROWN",    dem2=   "32"    },
                new Item() {sku =   "FFRCBR34", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BROWN 34", upc=    "610393094687", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BROWN",    dem2=   "34"    },
                new Item() {sku =   "FFRCBR36", masterSku=  "FFRC", desc=   "FEATHER FLEX ROPER CINCH", desc2=  "BROWN 36", upc=    "610393094670", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "ROPER - BROWN",    dem2=   "36"    },
                new Item() {sku =   "FFSCBK26", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BLACK 26", upc=    "610393094779", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BLACK", dem2=   "26"    },
                new Item() {sku =   "FFSCBK28", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BLACK 28", upc=    "610393094786", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BLACK", dem2=   "28"    },
                new Item() {sku =   "FFSCBK30", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BLACK 30", upc=    "610393094793", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BLACK", dem2=   "30"    },
                new Item() {sku =   "FFSCBK32", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BLACK 32", upc=    "610393094809", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BLACK", dem2=   "32"    },
                new Item() {sku =   "FFSCBK34", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BLACK 34", upc=    "610393094816", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BLACK", dem2=   "34"    },
                new Item() {sku =   "FFSCBK36", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BLACK 36", upc=    "610393094823", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BLACK", dem2=   "36"    },
                new Item() {sku =   "FFSCBR26", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BROWN 26", upc=    "610393094830", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BROWN", dem2=   "26"    },
                new Item() {sku =   "FFSCBR28", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BROWN 28", upc=    "610393094847", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BROWN", dem2=   "28"    },
                new Item() {sku =   "FFSCBR30", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BROWN 30", upc=    "610393094854", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BROWN", dem2=   "30"    },
                new Item() {sku =   "FFSCBR32", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BROWN 32", upc=    "610393094861", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BROWN", dem2=   "32"    },
                new Item() {sku =   "FFSCBR34", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BROWN 34", upc=    "610393094878", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BROWN", dem2=   "34"    },
                new Item() {sku =   "FFSCBR36", masterSku=  "FFSC", desc=   "FEATHER FLEX STRAIGHT CINCH",  desc2=  "BROWN 36", upc=    "610393094885", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "STRAIGHT - BROWN", dem2=   "36"    },
                new Item() {sku =   "FKR318XS", masterSku=  "FKR318XS", desc=   "CLASSIC FIRE CRACKER KID ROPE",    desc2=  "3/16 X 18'",   upc=    "610393049038", brand=  "CLASSIC",  code=   "CKIDROPES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "FL-G2-L",  masterSku=  "FL-G2",    desc=   "SOFT SADDLE LINER LRG",    desc2=  "LARGE",    upc=    "804381028307", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "FL-G2-M",  masterSku=  "FL-G2",    desc=   "SOFT SADDLE LINER MED",    desc2=  "MEDIUM",   upc=    "804381028314", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "FL-WE-1/2-M",  masterSku=  "FL-WE",    desc=   "FELT LINER WESTERN 1/2",   desc2=  "", upc=    "804381015758", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "1/2 WESTERN",  dem2=   ""  },
                new Item() {sku =   "FL-WE-1/4-M",  masterSku=  "FL-WE",    desc=   "FELT LINER WESTERN 1/4",   desc2=  "", upc=    "804381015765", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "1/4 WESTERN",  dem2=   ""  },
                new Item() {sku =   "FM-NN-L",  masterSku=  "FM-NN",    desc=   "NOSE NET - GREY MESH - LARGE", desc2=  "", upc=    "804381025733", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "FM-NN-M",  masterSku=  "FM-NN",    desc=   "NOSE NET - GREY MESH - MEDIUM",    desc2=  "", upc=    "804381025740", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "FM-NN-S",  masterSku=  "FM-NN",    desc=   "NOSE NET - GREY MESH - SMALL", desc2=  "", upc=    "804381025726", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "FOUNTAUTO",    masterSku=  "FOUNTAUTO",    desc=   "INSULATED TWO DRINK",  desc2=  "18720",    upc=    "610393095349", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTAUTOSINGLE",  masterSku=  "FOUNTAUTOSINGLE",  desc=   "INSULATED SINGLE DRINK",   desc2=  "18770",    upc=    "", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTEZ",  masterSku=  "FOUNTEZ",  desc=   "WATER HOSE ONE DRINK", desc2=  "18710",    upc=    "610393095356", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTHTCABLE", masterSku=  "FOUNTHTCABLE", desc=   "SELF REGULATING HEAT CABLE",   desc2=  "16276 FOR AUTOFOUNT",  upc=    "847987062764", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTIHEATER250",  masterSku=  "FOUNTIHEATER250",  desc=   "IMMERSION HEATER 250 WATT",    desc2=  "16311 FOR AUTOFOUNT",  upc=    "847987063112", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTSHROUD20",    masterSku=  "FOUNTSHROUD20",    desc=   "20 SHROUD FOR STALL FOUNT",    desc2=  "18744",    upc=    "610393095400", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTSHROUD30",    masterSku=  "FOUNTSHROUD30",    desc=   "30 SHROUD FOR STALL FOUNT",    desc2=  "18746",    upc=    "610393095394", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTSTALLHEAT",   masterSku=  "FOUNTSTALLHEAT",   desc=   "HEATED STALL", desc2=  "18740",    upc=    "610393095387", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTSTALLNOHEAT", masterSku=  "FOUNTSTALLNOHEAT", desc=   "STALL FOUNT NO HEAT",  desc2=  "18748",    upc=    "610393095370", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTTHERMALTE2",  masterSku=  "FOUNTTHERMALTE2",  desc=   "THERMAL TUBE EXTENSION 2'",    desc2=  "16416",    upc=    "847987064164", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTTHERMALTT1",  masterSku=  "FOUNTTHERMALTT1",  desc=   "THERMAL TUBE TOP 1'",  desc2=  "18158",    upc=    "847987081581", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTTHERMALTT2",  masterSku=  "FOUNTTHERMALTT2",  desc=   "THERMAL TUBE TOP 2'",  desc2=  "16417",    upc=    "847987064171", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTTHERMALTT4",  masterSku=  "FOUNTTHERMALTT4",  desc=   "THERMAL TUBE TOP 4'",  desc2=  "16612",    upc=    "847987066120", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTULTRA",   masterSku=  "FOUNTULTRA",   desc=   "INS HEATED TWO DRINK", desc2=  "18730",    upc=    "610393095363", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTULTRASINGLE", masterSku=  "FOUNTULTRASINGLE", desc=   "INS HEATED SINGLE DRINK",  desc2=  "18780",    upc=    "847987087804", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FOUNTWATERMETER",  masterSku=  "FOUNTWATERMETER",  desc=   "WATER METER FOR ANY FOUNTAIN", desc2=  "18645",    upc=    "847987086456", brand=  "WEQUINE",  code=   "WATERS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "FRB-D",    masterSku=  "FRBBAG",   desc=   "FEED RITE BAG - DRAFT",    desc2=  "", upc=    "804381025566", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "FRB",  masterSku=  "FRBBAG",   desc=   "FEED RITE BAG HORSE",  desc2=  "", upc=    "804381020981", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "FRB-M",    masterSku=  "FRBBAG",   desc=   "FEED RITE BAG - MINI", desc2=  "", upc=    "804381025573", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MINI", dem2=   ""  },
                new Item() {sku =   "FRB-P",    masterSku=  "FRBBAG",   desc=   "FEED RITE BAG - PONY", desc2=  "", upc=    "804381026006", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PONY", dem2=   ""  },
                new Item() {sku =   "FS-BG-LRG",    masterSku=  "FS-BG",    desc=   "FLYSHEET BELLY GUARD 82-84",   desc2=  "", upc=    "804381019350", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "FS-BG-MED",    masterSku=  "FS-BG",    desc=   "FLYSHEET BELLY GUARD 74-80",   desc2=  "", upc=    "804381019329", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "FS-BG-SML",    masterSku=  "FS-BG",    desc=   "FLYSHEET BELLY GUARD 66-72",   desc2=  "", upc=    "804381019947", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "FSE-74/76",    masterSku=  "FSE",  desc=   "FLYSHEET E 74/76", desc2=  "", upc=    "804381027935", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "74-76",    dem2=   ""  },
                new Item() {sku =   "FSE-77/79",    masterSku=  "FSE",  desc=   "FLYSHEET E 77/79", desc2=  "", upc=    "804381027928", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "77-79",    dem2=   ""  },
                new Item() {sku =   "FSE-80/82",    masterSku=  "FSE",  desc=   "FLYSHEET E 80/82", desc2=  "", upc=    "804381027911", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "80-82",    dem2=   ""  },
                new Item() {sku =   "FSE-HL-74/76", masterSku=  "FSE-HL",   desc=   "FLYSHEET E  HOTLEAF 74/76",    desc2=  "", upc=    "804381030393", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "74-76",    dem2=   ""  },
                new Item() {sku =   "FSE-HL-77/79", masterSku=  "FSE-HL",   desc=   "FLYSHEET E  HOTLEAF 77/79",    desc2=  "", upc=    "804381030409", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "77-79",    dem2=   ""  },
                new Item() {sku =   "FSE-HL-80/82", masterSku=  "FSE-HL",   desc=   "FLYSHEET E  HOTLEAF 80/82",    desc2=  "", upc=    "804381030416", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "80-82",    dem2=   ""  },
                new Item() {sku =   "FSL-57/59",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "57/59",    upc=    "804381025955", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "57-59",    dem2=   ""  },
                new Item() {sku =   "FSL-66/68",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "66/68",    upc=    "804381024293", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "66-68",    dem2=   ""  },
                new Item() {sku =   "FSL-70/72",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "70/72",    upc=    "804381024323", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "70-72",    dem2=   ""  },
                new Item() {sku =   "FSL-74/76",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "74/76",    upc=    "804381024330", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "74-76",    dem2=   ""  },
                new Item() {sku =   "FSL-77/79",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "77/79",    upc=    "804381024347", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "77-79",    dem2=   ""  },
                new Item() {sku =   "FSL-80/82",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "80/82",    upc=    "804381024354", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "80-82",    dem2=   ""  },
                new Item() {sku =   "FSL-83/85",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "83/85",    upc=    "804381026136", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "83-85",    dem2=   ""  },
                new Item() {sku =   "FSL-94/96",    masterSku=  "FSL",  desc=   "LIGHT WEIGHT FLYSHEET",    desc2=  "94/96",    upc=    "804381029960", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "94-96",    dem2=   ""  },
                new Item() {sku =   "FS-NG-SML",    masterSku=  "FS-NG",    desc=   "FLYSHEET NECK GUARD 66-72",    desc2=  "", upc=    "804381019374", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "66-72",    dem2=   ""  },
                new Item() {sku =   "FS-NG-MED",    masterSku=  "FS-NG",    desc=   "FLYSHEET NECK GUARD 74-80",    desc2=  "", upc=    "804381019381", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "74-80",    dem2=   ""  },
                new Item() {sku =   "FS-NG-LRG",    masterSku=  "FS-NG",    desc=   "FLYSHEET NECK GUARD 82-84",    desc2=  "", upc=    "804381019367", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "82-84",    dem2=   ""  },
                new Item() {sku =   "GC-E", masterSku=  "GC",   desc=   "GIRTH CHANNEL ENGLISH 3/4",    desc2=  "4' long 3/4 thick X 5W .", upc=    "804381006305", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "ENGLISH",  dem2=   ""  },
                new Item() {sku =   "GFP100C30",    masterSku=  "GFP100C",  desc=   "GREY FELT PAD",    desc2=  "1  CONTOURED 30X32",   upc=    "610393089355", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30 X 32",  dem2=   ""  },
                new Item() {sku =   "GFP100C32",    masterSku=  "GFP100C",  desc=   "GREY FELT PAD",    desc2=  "1 CONTOURED 31X32",    upc=    "610393089348", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31 X 32",  dem2=   ""  },
                new Item() {sku =   "GFP100C30TL",  masterSku=  "GFP100CTL",    desc=   "GREY FELT PAD W/ TOOLED LEATHERS", desc2=  "1 CONTOUR 30X32",  upc=    "610393103297", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30X32",    dem2=   ""  },
                new Item() {sku =   "GFP100C32TL",  masterSku=  "GFP100CTL",    desc=   "GREY FELT PAD W/ TOOLED LEATHERS", desc2=  "1 CONTOUR 31X32",  upc=    "610393103303", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31X32",    dem2=   ""  },
                new Item() {sku =   "GFP120C30",    masterSku=  "GFP120C",  desc=   "GREY FELT PAD",    desc2=  "1/2  CONTOURED 30X32", upc=    "610393090481", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30 X 32",  dem2=   ""  },
                new Item() {sku =   "GFP120C32",    masterSku=  "GFP120C",  desc=   "GREY FELT PAD",    desc2=  "1/2 CONTOURED 31X32",  upc=    "610393090498", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31 X 32",  dem2=   ""  },
                new Item() {sku =   "GFP120C30TL",  masterSku=  "GFP120CTL",    desc=   "GREY FELT PAD W/ TOOLED LEATHERS", desc2=  "1/2 CONTOUR 30X32",    upc=    "610393103310", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30X32",    dem2=   ""  },
                new Item() {sku =   "GFP120C32TL",  masterSku=  "GFP120CTL",    desc=   "GREY FELT PAD W/ TOOLED LEATHERS", desc2=  "1/2 CONTOUR 31X32",    upc=    "610393103327", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31X32",    dem2=   ""  },
                new Item() {sku =   "GFP340C30",    masterSku=  "GFP340C",  desc=   "GREY FELT PAD",    desc2=  "3/4  CONTOURED 30X32", upc=    "610393089331", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30 X 32",  dem2=   ""  },
                new Item() {sku =   "GFP340C32",    masterSku=  "GFP340C",  desc=   "GREY FELT PAD",    desc2=  "3/4 CONTOURED 31X32",  upc=    "610393089324", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31 X 32",  dem2=   ""  },
                new Item() {sku =   "GFP340C30TL",  masterSku=  "GFP340CTL",    desc=   "GREY FELT PAD W/ TOOLED LEATHERS", desc2=  "3/4 CONTOUR 30X32",    upc=    "610393103341", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30X32",    dem2=   ""  },
                new Item() {sku =   "GFP340C32TL",  masterSku=  "GFP340CTL",    desc=   "GREY FELT PAD W/ TOOLED LEATHERS", desc2=  "3/4 CONTOUR 31X32",    upc=    "610393103334", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31X32",    dem2=   ""  },
                new Item() {sku =   "GMART16RR",    masterSku=  "GMART16RR",    desc=   "GMART ROPING REIN",    desc2=  "", upc=    "610393103952", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GMART16SR",    masterSku=  "GMART16SR",    desc=   "GMART SPLIT REIN", desc2=  "", upc=    "610393103945", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GMH-A",    masterSku=  "GMH",  desc=   "GRAZING MUZZLE HALTER - ARAB", desc2=  "", upc=    "804381022589", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "GMH-H",    masterSku=  "GMH",  desc=   "GRAZING MUZZLE HALTER - HORSE",    desc2=  "", upc=    "804381022565", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "GMH-M",    masterSku=  "GMH",  desc=   "GRAZING MUZZEL HALTER - MINI", desc2=  "", upc=    "804381022572", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MINI", dem2=   ""  },
                new Item() {sku =   "GMH-P",    masterSku=  "GMH",  desc=   "GRAZING MUZZLE HALTER - PONY", desc2=  "", upc=    "804381022596", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PONY", dem2=   ""  },
                new Item() {sku =   "GRR 330MS",    masterSku=  "GRR",  desc=   "GOLD 3/8 30 MS RHB",   desc2=  "", upc=    "610393008004", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "GRR 330 S",    masterSku=  "GRR",  desc=   "GOLD 3/8 30 S RHB",    desc2=  "", upc=    "610393007984", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "GRR 330XS",    masterSku=  "GRR",  desc=   "GOLD 3/8 30 XS RHB",   desc2=  "", upc=    "610393008011", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "GRR 3302X",    masterSku=  "GRR",  desc=   "GOLD 3/8 30 XXS RHB",  desc2=  "", upc=    "610393007991", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "GRR 335HM",    masterSku=  "GRR",  desc=   "GOLD 3/8 35 HM RHB",   desc2=  "", upc=    "610393008059", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "GRR 335 M",    masterSku=  "GRR",  desc=   "GOLD 3/8 35 M RHB",    desc2=  "", upc=    "610393008035", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "GRR 335MH",    masterSku=  "GRR",  desc=   "GOLD 3/8 35 MH RHB",   desc2=  "", upc=    "610393008066", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "GRR 335MS",    masterSku=  "GRR",  desc=   "GOLD 3/8 35 MS RHB",   desc2=  "", upc=    "610393008073", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "GT4 330MS",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 30' MS",  desc2=  "", upc=    "610393014579", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "GT4 330 S",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 30' S",   desc2=  "", upc=    "610393014562", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "GT4 330XS",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 30' XS",  desc2=  "", upc=    "610393014555", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "GT4 3302X",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 30' XXS", desc2=  "", upc=    "610393014548", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "GT4 335HM",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 35' HM",  desc2=  "", upc=    "610393014609", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "GT4 335 M",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 35' M",   desc2=  "", upc=    "610393014593", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "GT4 335MH",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 35' MH",  desc2=  "", upc=    "610393014616", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "GT4 335MS",    masterSku=  "GT4",  desc=   "RATTLER GT4 ROPE 3/8 35' MS",  desc2=  "", upc=    "610393014586", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "GT4S335HM",    masterSku=  "GT4S", desc=   "GT4 LITE 3/8 35' HM",  desc2=  "", upc=    "610393084701", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "GT4S335 M",    masterSku=  "GT4S", desc=   "GT4 LITE 3/8 35' M",   desc2=  "", upc=    "610393084695", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "GT4S335MH",    masterSku=  "GT4S", desc=   "GT4 LITE 3/8 35' MH",  desc2=  "", upc=    "610393084718", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "GT4S335MS",    masterSku=  "GT4S", desc=   "GT4 LITE 3/8 35' MS",  desc2=  "", upc=    "610393084725", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "GTCGBIT31",    masterSku=  "GTCGBIT31",    desc=   "GOOSETREE CG BIT", desc2=  "SS SNAFFLE W/CHAIN MIDDLE MP", upc=    "610393087917", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDBIT12", masterSku=  "GTDBIT12", desc=   "GOOSETREE DELIGHT BIT",    desc2=  "SS TWISTED WIRE MP",   upc=    "610393081212", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDBIT13", masterSku=  "GTDBIT13", desc=   "GOOSETREE DELIGHT BIT",    desc2=  "DR. BRISTOL MP",   upc=    "610393084466", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDBIT30", masterSku=  "GTDBIT30", desc=   "GOOSETREE DELIGHT BIT",    desc2=  "CHAIN MP", upc=    "610393084473", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDBIT31", masterSku=  "GTDBIT31", desc=   "GOOSETREE DELIGHT BIT",    desc2=  "SS SNAFFLE W/CHAIN MIDDLE MP", upc=    "610393081229", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDGLS13", masterSku=  "GTDGLS13", desc=   "GOOSETREE DOUBLE GAG", desc2=  "LONG SHANK DR. BRISTOL MP",    upc=    "610393084527", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDGLS30", masterSku=  "GTDGLS30", desc=   "GOOSETREE DOUBLE GAG", desc2=  "LONG SHANK CHAIN MP",  upc=    "610393084534", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDGSS13", masterSku=  "GTDGSS13", desc=   "GOOSETREE DOUBLE GAG", desc2=  "SHORT SHANK DR. BRISTOL MP",   upc=    "610393084510", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTDGSS30", masterSku=  "GTDGSS30", desc=   "GOOSETREE DOUBLE GAG", desc2=  "SHORT SHANK CHAIN MP", upc=    "610393084503", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTHACK",   masterSku=  "GTHACK",   desc=   "GOOSETREE HACKAMORE",  desc2=  "", upc=    "610393087924", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTPLS12",  masterSku=  "GTPLS12",  desc=   "GOOSETREE PICK UP BIT",    desc2=  "LONG SHANK SS TWISTED WIRE MP",    upc=    "610393092812", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTPLS13",  masterSku=  "GTPLS13",  desc=   "GOOSETREE PICK UP BIT",    desc2=  "LONG SHANK DR. BRISTOL MP",    upc=    "610393092805", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTPSS12",  masterSku=  "GTPSS12",  desc=   "GOOSETREE PICK UP BIT",    desc2=  "SHORT SHANK SS TWISTED WIRE MP",   upc=    "610393092799", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTPSS13",  masterSku=  "GTPSS13",  desc=   "GOOSETREE PICK UP BIT",    desc2=  "SHORT SHANK DR. BRISTOL MP",   upc=    "610393092782", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTQD13",   masterSku=  "GTQD13",   desc=   "GOOSETREE QUICK DRAW", desc2=  "DR BRISTOL MP",    upc=    "610393097985", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTSBIT12", masterSku=  "GTSBIT12", desc=   "GOOSETREE SIMPLICITY BIT", desc2=  "SS TWISTED WIRE MP",   upc=    "610393081236", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTSBIT13", masterSku=  "GTSBIT13", desc=   "GOOSETREE SIMPLICITY BIT", desc2=  "DR. BRISTOL MP",   upc=    "610393084480", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTSBIT30", masterSku=  "GTSBIT30", desc=   "GOOSETREE SIMPLICITY BIT", desc2=  "CHAIN MP", upc=    "610393084497", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "GTSBIT31", masterSku=  "GTSBIT31", desc=   "GOOSETREE SIMPLICITY BIT", desc2=  "SS SNAFFLE W/CHAIN MIDDLE MP", upc=    "610393081243", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HACKGD",   masterSku=  "HACKGD",   desc=   "HACKAMORE GIST DIAMOND",   desc2=  "", upc=    "610393071749", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HACKSSGC", masterSku=  "HACKSSGC", desc=   "HACKAMORE SHORT SHANK GIST CLO",   desc2=  "GIST CLOVER",  upc=    "610393071756", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HACKSSPS", masterSku=  "HACKSSPS", desc=   "HACKAMORE SS PERFORMANCE SERIE",   desc2=  "", upc=    "610393071213", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HACKTB2",  masterSku=  "HACKTB2",  desc=   "HACKAMORE TOOL BOX SERIES 2",  desc2=  "", upc=    "610393099279", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HALTER08BK",   masterSku=  "HALTER08BK",   desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "BLACK",    upc=    "610393078908", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "HALTER15BKTN", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "BLACK TAN",    upc=    "610393097718", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK TAN",    dem2=   ""  },
                new Item() {sku =   "HALTER16CHTQ", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "CHOCOLATE TURQUOISE",  upc=    "610393102641", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "CHOCOLATE TURQUOISE",  dem2=   ""  },
                new Item() {sku =   "HALTER15FCLG", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "FUCHSIA LIME GREEN",   upc=    "610393097725", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "FUCHSIA LIME GREEN",   dem2=   ""  },
                new Item() {sku =   "HALTER16LGTL", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "LIME GREEN TEAL",  upc=    "610393101736", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "LIME GREEN TEAL",  dem2=   ""  },
                new Item() {sku =   "HALTER15ORFC", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "ORANGE FUCSHIA",   upc=    "610393097732", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "ORANGE FUCSHIA",   dem2=   ""  },
                new Item() {sku =   "HALTER15PRWH", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "PURPLE WHITE", upc=    "610393097749", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "PURPLE WHITE", dem2=   ""  },
                new Item() {sku =   "HALTER15TQYL", masterSku=  "HALTER15", desc=   "ROPE HALTER W/ 8' LEAD",   desc2=  "TURQUOISE YELLOW", upc=    "610393097756", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "TURQUOISE YELLOW", dem2=   ""  },
                new Item() {sku =   "HALTERBH", masterSku=  "HALTERBH", desc=   "HALTER BROWN HARNESS 1",   desc2=  "", upc=    "610393096346", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "HALTERBKLBK",  masterSku=  "HALTERBKLBK",  desc=   "HALTER ADJ BUCKLE",    desc2=  "BLACK",    upc=    "610393097008", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "HALTERLBS",    masterSku=  "HALTERLBS",    desc=   "NYLON HALTER W/LEATHER COVER", desc2=  "BASKET STAMPED & LEAD ROPE",   upc=    "610393048451", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "HALTERMT", masterSku=  "HALTERMT", desc=   "HALTER MULE TAPE", desc2=  "", upc=    "610393095851", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "HALTERRNBK",   masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "BLACK INLAID", upc=    "610393099224", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK INLAID", dem2=   ""  },
                new Item() {sku =   "HALTERRNBKWH", masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "BLACK/WHITE RAWHIDE",  upc=    "610393099217", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK/WHITE RAWHIDE",  dem2=   ""  },
                new Item() {sku =   "HALTERRNBL",   masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "BLUE INLAID",  upc=    "610393099200", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLUE INLAID",  dem2=   ""  },
                new Item() {sku =   "HALTERRNGR",   masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "GREEN INLAID", upc=    "610393099194", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "GREEN INLAID", dem2=   ""  },
                new Item() {sku =   "HALTERRNPK",   masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "PINK INLAID",  upc=    "610393099187", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "PINK INLAID",  dem2=   ""  },
                new Item() {sku =   "HALTERRNPKTQ", masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "PINK TURQUOISE RAWHIDE",   upc=    "610393101729", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "PINK TURQUOISE RAWHIDE",   dem2=   ""  },
                new Item() {sku =   "HALTERRN", masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "PLAIN",    upc=    "610393099231", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "PLAIN",    dem2=   ""  },
                new Item() {sku =   "HALTERRNPRTL", masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "PURPLE TEAL RAWHIDE",  upc=    "610393101712", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "PURPLE TEAL RAWHIDE",  dem2=   ""  },
                new Item() {sku =   "HALTERRNRD",   masterSku=  "HALTERRN", desc=   "ROPE HALTER W RAWHIDE NOSE",   desc2=  "RED INLAID",   upc=    "610393099170", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "RED INLAID",   dem2=   ""  },
                new Item() {sku =   "HALTERBRRN",   masterSku=  "HALTERRN", desc=   "ROPE HALTER BROWN W RAWHIDE NOSE", desc2=  "PLAIN",    upc=    "610393102306", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "Solid Brown",  dem2=   ""  },
                new Item() {sku =   "HALTERBKA",    masterSku=  "HALTERSTD",    desc=   "HALTER BLACK (AVERAGE)",   desc2=  "", upc=    "610393091600", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK",    dem2=   "AVERAGE"   },
                new Item() {sku =   "HALTERBKS",    masterSku=  "HALTERSTD",    desc=   "HALTER BLACK (SMALL)", desc2=  "", upc=    "610393091617", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "HALTEROGA",    masterSku=  "HALTERSTD",    desc=   "HALTER OLIVE GREEN (AVERAGE)", desc2=  "", upc=    "610393091655", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "OLIVE",    dem2=   "AVERAGE"   },
                new Item() {sku =   "HALTEROGS",    masterSku=  "HALTERSTD",    desc=   "HALTER OLIVE GREEN (SMALL)",   desc2=  "", upc=    "610393091648", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "OLIVE",    dem2=   "SMALL" },
                new Item() {sku =   "HALTERPRA",    masterSku=  "HALTERSTD",    desc=   "HALTER PURPLE (AVERAGE)",  desc2=  "", upc=    "610393100128", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "PURPLE",   dem2=   "AVERAGE"   },
                new Item() {sku =   "HALTERTNA",    masterSku=  "HALTERSTD",    desc=   "HALTER TAN (AVERAGE)", desc2=  "", upc=    "610393091631", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "TAN",  dem2=   "AVERAGE"   },
                new Item() {sku =   "HALTERTNS",    masterSku=  "HALTERSTD",    desc=   "HALTER TAN (SMALL)",   desc2=  "", upc=    "610393091624", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "TAN",  dem2=   "SMALL" },
                new Item() {sku =   "HARNHOB",  masterSku=  "HARNHOB",  desc=   "HARNESS HOBBLES",  desc2=  "", upc=    "610393006840", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HAYH-BLA", masterSku=  "HAYH-BLA", desc=   "HAY HANDLER - BLACK",  desc2=  "", upc=    "804381008705", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HAYNET-GR",    masterSku=  "HAYNET",   desc=   "HAY NET",  desc2=  "GREEN",    upc=    "804381027836", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "HAYNET-PK",    masterSku=  "HAYNET",   desc=   "HAY NET",  desc2=  "PINK", upc=    "804381027843", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "HAYNET-RD",    masterSku=  "HAYNET",   desc=   "HAY NET",  desc2=  "RED",  upc=    "804381027867", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "RED",  dem2=   ""  },
                new Item() {sku =   "HAYNET-RB",    masterSku=  "HAYNET",   desc=   "HAY NET",  desc2=  "ROYAL BLUE",   upc=    "804381027850", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "ROYAL BLUE",   dem2=   ""  },
                new Item() {sku =   "HAYNET-YL",    masterSku=  "HAYNET",   desc=   "HAY NET",  desc2=  "YELLOW",   upc=    "804381027874", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "YELLOW",   dem2=   ""  },
                new Item() {sku =   "HB111SL",  masterSku=  "HB111SL",  desc=   "HEADSTALL BROWB 3/4 STCH", desc2=  "HARNESS SS BKL/LEA",   upc=    "610393072333", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB113ROSBC",   masterSku=  "HB113ROSBC",   desc=   "HS BB CHST CAMO STAMPED",  desc2=  "ROCKIN OUT SHERIDAN BKL & CONC",   upc=    "610393097145", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB11ROFL", masterSku=  "HB11ROFL", desc=   "HS BB CHST",   desc2=  "ROCKIN OUT FLORAL BKL TIES",   upc=    "610393097152", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB121DSL", masterSku=  "HB121DSL", desc=   "HS BB CHEST/DOTS BARBWIRE",    desc2=  "SS BKL LATIGO TIES",   upc=    "610393100210", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB141CPNT",    masterSku=  "HB141CPNT",    desc=   "HS BB CHST RO HARNESS",    desc2=  "COPPER PATINA BKLS NT KNOTS",  upc=    "610393104461", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB149SNT", masterSku=  "HB149SNT", desc=   "HS BB ROUGHOUT CHESTNUT DOTS", desc2=  "SS BKL NT KNOTS",  upc=    "610393103501", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB16A2D",  masterSku=  "HB16A2D",  desc=   "HS BB CHOC HARNESS ANTIQUE 2 DOTS",    desc2=  "CART BKL NT KNOTS",    upc=    "610393104577", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB16LCANT",    masterSku=  "HB16LCANT",    desc=   "HS BB LASER CHESTNUT", desc2=  "CART BKL NECKTIE KNOT",    upc=    "610393103877", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB16LSANT",    masterSku=  "HB16LSANT",    desc=   "HS BB LASER SAFARI",   desc2=  "CART BKL NECKTIE KNOT",    upc=    "610393103860", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB16NROTCD",   masterSku=  "HB16NROTCD",   desc=   "HS BB NAT RO TQ COPPER DOTS",  desc2=  "", upc=    "610393103822", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB21ANT",  masterSku=  "HB21ANT",  desc=   "HARNESS BROWBAND", desc2=  "W/ NT KNOTS",  upc=    "610393103594", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB23SNT",  masterSku=  "HB23SNT",  desc=   "HS BB HARNESS RH BRD", desc2=  "NECK TIE KNOT",    upc=    "610393103402", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB2SDAS",  masterSku=  "HB2SDAS",  desc=   "HS BB HARN SQUARE DOTS",   desc2=  "CART BKL CH SCREWS",   upc=    "610393100302", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB424AL",  masterSku=  "HB424AL",  desc=   "HS BB 3/4 LATIGO DBL& STITCH", desc2=  "CART BKLS LATIGO TIES",    upc=    "610393096278", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB61SNT",  masterSku=  "HB61SNT",  desc=   "HS BB ROUGHOUT NATURAL",   desc2=  "SS BKL NT KNOTS",  upc=    "610393103570", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB625SNT", masterSku=  "HB625SNT", desc=   "HS BB NAT RO ROPE COPPER PARACHUTE DOTS",  desc2=  "SS BKL NECKTIE KNOT",  upc=    "610393103846", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB81ASNT", masterSku=  "HB81ASNT", desc=   "HS BB CHOC HARNESS",   desc2=  "ANTIQUE SILVER BKLS NT KNOTS", upc=    "610393104447", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB83SNT",  masterSku=  "HB83SNT",  desc=   "HS BB CHOCOLATE HARNESS RH BRD",   desc2=  "NECK TIE KNOT",    upc=    "610393103372", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB86TQDAL",    masterSku=  "HB86TQDAL",    desc=   "HS BB CHOC RO TQ DOTS",    desc2=  "CART BKL LATIGO TIES", upc=    "610393100227", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB871ANT", masterSku=  "HB871ANT", desc=   "HS BB CHOC SKIRTING",  desc2=  "CART BKL NT KNOTS",    upc=    "610393103556", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB8725AS", masterSku=  "HB8725AS", desc=   "HS BB CHOC ROPE",  desc2=  "CART BUCKLE CH SCREWS",    upc=    "610393100296", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB91DNT",  masterSku=  "HB91DNT",  desc=   "HS BB BROWN HARNESS",  desc2=  "DIAMONDS BKLS NT KNOTS",   upc=    "610393103488", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB91SNT",  masterSku=  "HB91SNT",  desc=   "HS BB BROWN HARNESS",  desc2=  "SPLASH BKLS NT KNOTS", upc=    "610393103464", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB924AL",  masterSku=  "HB924AL",  desc=   "HS BB 3/4 HARN DBL& STITCH",   desc2=  "CART BKLS LATIGO TIES",    upc=    "610393096261", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB92SL",   masterSku=  "HB92SL",   desc=   "HS BROWN HARNESS RH LACE", desc2=  "BROW BAND",    upc=    "610393071527", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBBF-BLA", masterSku=  "HBBF-BLA", desc=   "HAY BALE BAG FULL SIZE BLACK", desc2=  "", upc=    "804381023968", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBBH-BLA", masterSku=  "HBBH-BLA", desc=   "HAY BALE BAG HALF SIZE BLACK", desc2=  "", upc=    "804381023975", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HB-BLA",   masterSku=  "HB-BLA",   desc=   "HAY BAG BLACK",    desc2=  "", upc=    "804381000211", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBDDB323", masterSku=  "HBDDB323", desc=   "HS BB DRW BIT 3",  desc2=  "O-RING",   upc=    "610393100340", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBLG17",   masterSku=  "HBLG17",   desc=   "HS BB LOOMIS GAG", desc2=  "SMOOTH SNAFFLE",   upc=    "610393081366", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBLG21",   masterSku=  "HBLG21",   desc=   "HS BB LOOMIS GAG", desc2=  "TWISTED WIRE SNAFFLE", upc=    "610393081397", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBM-BLA",  masterSku=  "HBM-BLA",  desc=   "HAY BAG MESH LARGE  BLACK",    desc2=  "", upc=    "804381024422", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HBP31SNT", masterSku=  "HBP31SNT", desc=   "HS BB 1/2 STITCHED HARNESS",   desc2=  "SS BKLS NT KNOTS", upc=    "610393103532", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HC121SL",  masterSku=  "HC121SL",  desc=   "HS BB CHEST/BARBWIRE", desc2=  "SS BKL LATIGO TIES",   upc=    "610393100197", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HCURB",    masterSku=  "HCURB",    desc=   "HARNESS CURB STRAP",   desc2=  "", upc=    "610393079295", brand=  "MARTIN",   code=   "CURBS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "HE121SL",  masterSku=  "HE121SL",  desc=   "HS SE CHEST BWIRE",    desc2=  "SS BLK LATIGO TIES",   upc=    "610393100258", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HEAT 330MS",   masterSku=  "HEAT", desc=   "HEAT 3/8 30' MS",  desc2=  "", upc=    "610393079035", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "HEAT 330 S",   masterSku=  "HEAT", desc=   "HEAT 3/8 30' S",   desc2=  "", upc=    "610393079042", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "HEAT 330XS",   masterSku=  "HEAT", desc=   "HEAT 3/8 30' XS",  desc2=  "", upc=    "610393079011", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "HEAT 3302X",   masterSku=  "HEAT", desc=   "HEAT 3/8 30' XXS", desc2=  "", upc=    "610393079028", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "HEAT 335HM",   masterSku=  "HEAT", desc=   "HEAT 3/8 35' HM",  desc2=  "", upc=    "610393079066", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "HEAT 335 M",   masterSku=  "HEAT", desc=   "HEAT 3/8 35' M",   desc2=  "", upc=    "610393079073", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "HEAT 335MH",   masterSku=  "HEAT", desc=   "HEAT 3/8 35' MH",  desc2=  "", upc=    "610393079097", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "HEAT 335MS",   masterSku=  "HEAT", desc=   "HEAT 3/8 35' MS",  desc2=  "", upc=    "610393079059", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "HEAT 335 S",   masterSku=  "HEAT", desc=   "HEAT 3/8 35' S",   desc2=  "", upc=    "610393084671", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "S" },
                new Item() {sku =   "HF111SL",  masterSku=  "HF111SL",  desc=   "HEADSTALL SLIPEAR 3/4 STCH",   desc2=  "BROWN HARN SS BKL/L",  upc=    "610393072340", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF113ROSBC",   masterSku=  "HF113ROSBC",   desc=   "HS SE CHST CAMO STAMPED",  desc2=  "ROCKIN OUT SHERIDAN BKL & CONC",   upc=    "610393097138", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF11ROFL", masterSku=  "HF11ROFL", desc=   "HS SE CHST",   desc2=  "ROCKIN OUT FLORAL BKL TIES",   upc=    "610393097169", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF121DSL", masterSku=  "HF121DSL", desc=   "HS SLIP EAR CHEST DOTS BWIRE", desc2=  "SS BKL LATIGO TIES",   upc=    "610393100272", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF141CPNT",    masterSku=  "HF141CPNT",    desc=   "HS SE CHST RO HARNESS",    desc2=  "COPPER PATINA BKLS NT KNOTS",  upc=    "610393104454", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF149SNT", masterSku=  "HF149SNT", desc=   "HS SE ROUGHOUT CHESTNUT DOTS", desc2=  "SS BKL NT KNOTS",  upc=    "610393103518", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF21ANT",  masterSku=  "HF21ANT",  desc=   "HARNESS SLIPEAR",  desc2=  "W/NT KNOTS",   upc=    "610393103600", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF23SNT",  masterSku=  "HF23SNT",  desc=   "HS SE  HARNESS RH BRD",    desc2=  "NECK TIE KNOT",    upc=    "610393103624", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF61SNT",  masterSku=  "HF61SNT",  desc=   "HS SE ROUGHOUT NATURAL",   desc2=  "SS BKL NT KNOTS",  upc=    "610393103587", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF625SNT", masterSku=  "HF625SNT", desc=   "HS SE NAT RO ROPE COPPER PARACHUTE DOTS",  desc2=  "SS BKL NECKTIE KNOT",  upc=    "610393103839", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF81ASNT", masterSku=  "HF81ASNT", desc=   "HS SE CHOC HARNESS",   desc2=  "ANTIQUE SILVER BKLS NT KNOTS", upc=    "610393104430", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF83SNT",  masterSku=  "HF83SNT",  desc=   "HS SE CHOCOLATE HARNESS RH BRD",   desc2=  "NECK TIE KNOT",    upc=    "610393103365", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF871ANT", masterSku=  "HF871ANT", desc=   "HS SE CHOC SKIRTING",  desc2=  "CART BKL NT KNOTS",    upc=    "610393103563", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF8725AS", masterSku=  "HF8725AS", desc=   "HS SE CHOCOLATE ROPE", desc2=  "CART BKL CH SCREWS",   upc=    "610393100241", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF91DNT",  masterSku=  "HF91DNT",  desc=   "HS SE BROWN HARNESS",  desc2=  "DIAMONDS BKLS NT KNOTS",   upc=    "610393103495", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF91SNT",  masterSku=  "HF91SNT",  desc=   "HS SE BROWN HARNESS",  desc2=  "SPLASH BKLS NT KNOTS", upc=    "610393103471", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HF92SL",   masterSku=  "HF92SL",   desc=   "HS BROWN HARNESS RH LACE", desc2=  "SLIP EAR", upc=    "610393071534", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HFLG17",   masterSku=  "HFLG17",   desc=   "HS SE LOOMIS GAG", desc2=  "SMOOTH SNAFFLE",   upc=    "610393081373", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HFLG21",   masterSku=  "HFLG21",   desc=   "HS SE LOOMIS GAG", desc2=  "TWISTED WIRE SNAFFLE", upc=    "610393081380", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HFP31SNT", masterSku=  "HFP31SNT", desc=   "HS SE 1/2 STITCHED HARNESS",   desc2=  "SS BKLS NT KNOTS", upc=    "610393103549", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HH-BLA",   masterSku=  "HH-BLA",   desc=   "HORSE HELMET BLACK",   desc2=  "", upc=    "804381006381", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HI149SNT", masterSku=  "HI149SNT", desc=   "HS SPLIT EAR CHEST RO DOTS",   desc2=  "SS BLK NT KNOTS",  upc=    "610393103525", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HI21ANT",  masterSku=  "HI21ANT",  desc=   "HARNESS SPLITEAR", desc2=  "W/ NT KNOTS",  upc=    "610393103617", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HKNIFE",   masterSku=  "HKNIFE",   desc=   "HORSEMAN'S KNIFE", desc2=  "", upc=    "804381027898", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HKNIFESCAB",   masterSku=  "HKNIFESCAB",   desc=   "HORSEMAN'S KNIFE SCABBARD",    desc2=  "", upc=    "804381031000", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HKNOT6",   masterSku=  "HKNOT6",   desc=   "HORN KNOT",    desc2=  "RED & BLUE",   upc=    "610393091235", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "TJACKHLLL",    masterSku=  "HLJACKET", desc=   "CASHEL JACKET HOTLEAF LADIES ",    desc2=  "LARGE",    upc=    "804381030515", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "TJACKHLLM",    masterSku=  "HLJACKET", desc=   "CASHEL JACKET HOTLEAF LADIES", desc2=  "MEDIUM",   upc=    "804381030997", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "TJACKHLLS",    masterSku=  "HLJACKET", desc=   "CASHEL JACKET HOTLEAF LADIES", desc2=  "SMALL",    upc=    "804381030522", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "TJACKHLLXL",   masterSku=  "HLJACKET", desc=   "CASHEL JACKET HOTLEAF LADIES", desc2=  "X LARGE",  upc=    "804381030539", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X LARGE",  dem2=   ""  },
                new Item() {sku =   "TJACKHLLXS",   masterSku=  "HLJACKET", desc=   "CASHEL JACKET HOTLEAF LADIES ",    desc2=  "X SMALL",  upc=    "804381030546", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X SMALL",  dem2=   ""  },
                new Item() {sku =   "HORNWRAP10BK", masterSku=  "HORNWRAP", desc=   "HORN WRAP",    desc2=  "2010 BLACK BLACK STRAP",   upc=    "610393084121", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "BLACK/BLACK STRAP",    dem2=   ""  },
                new Item() {sku =   "HORNWRAP14BKGS",   masterSku=  "HORNWRAP", desc=   "HORN WRAP",    desc2=  "2014 BLACK GREEN STRAP",   upc=    "610393096292", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "BLACK/GREEN STRAP",    dem2=   ""  },
                new Item() {sku =   "HORNWRAP14BKRS",   masterSku=  "HORNWRAP", desc=   "HORN WRAP",    desc2=  "2014 BLACK RED STRAP", upc=    "610393096285", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "BLACK/RED STRAP",  dem2=   ""  },
                new Item() {sku =   "HR16CBT",  masterSku=  "HR16CBT",  desc=   "HS RANAHAN SERIES 1 SPLIT EAR ",   desc2=  "CHEST BORDER TOOLED SS BKL NT KNOT",   upc=    "610393104607", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HR16CHT",  masterSku=  "HR16CHT",  desc=   "HS RANAHAN SERIES 1 SPLIT EAR ",   desc2=  "CHOC TOOLED SS BKL NT KNOT",   upc=    "610393104621", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HR16CT",   masterSku=  "HR16CT",   desc=   "HS RANAHAN SERIES 1 SPLIT EAR ",   desc2=  "CHEST TOOLED SS BKL NT KNOT",  upc=    "610393104614", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HR16NROBT",    masterSku=  "HR16NROBT",    desc=   "HS RANAHAN SERIES 1 SPLIT EAR ",   desc2=  "NAT RO BORDER TOOLED SS BKL NT KNOT",  upc=    "610393104638", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HR16NT",   masterSku=  "HR16NT",   desc=   "HS RANAHAN SERIES 1 SPLIT EAR ",   desc2=  "NAT TOOLED SS BKL NT KNOT",    upc=    "610393104645", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HT23SNT",  masterSku=  "HT23SNT",  desc=   "HS TF HARNESS RH BRD", desc2=  "NECK TIE KNOT",    upc=    "610393103419", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HT83SNT",  masterSku=  "HT83SNT",  desc=   "HS TF CHOCOLATE HARNESS RH BRD",   desc2=  "NECK TIE KNOT",    upc=    "610393103389", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HTDR", masterSku=  "HTDR", desc=   "HEADSET TIEDOWN - ROPE NOSE",  desc2=  "", upc=    "610393001241", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HTDRA",    masterSku=  "HTDRA",    desc=   "ADJ HEADSETTER TIE DOWN",  desc2=  "", upc=    "610393095004", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HTDRL",    masterSku=  "HTDRL",    desc=   "HEADSET TIEDOWN",  desc2=  "ROPE LEA COVER",   upc=    "610393001258", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "HTR-CRH-CA",   masterSku=  "HTR-CHR",  desc=   "CHARITY ROPE HALTER",  desc2=  "CAMOFLAUGE",   upc=    "804381028345", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "HTR-CRH-OR",   masterSku=  "HTR-CHR",  desc=   "CHARITY ROPE HALTER",  desc2=  "ORANGE",   upc=    "804381028352", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "ORANGE",   dem2=   ""  },
                new Item() {sku =   "HTR-CRH-PK",   masterSku=  "HTR-CHR",  desc=   "CHARITY ROPE HALTER",  desc2=  "PINK", upc=    "804381028369", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "HTR-KL-H", masterSku=  "HTR-KL",   desc=   "KNOTLESS HATLER W/9' LEAD",    desc2=  "HORSE",    upc=    "804381030812", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "HTR-KL-P", masterSku=  "HTR-KL",   desc=   "KNOTLESS HATLER W/9' LEAD",    desc2=  "PONY", upc=    "804381030829", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PONY", dem2=   ""  },
                new Item() {sku =   "HTR-KL-WB",    masterSku=  "HTR-KL",   desc=   "KNOTLESS HATLER W/9' LEAD",    desc2=  "WARMBLOOD",    upc=    "804381030836", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "HTR-LEAD-CAMO",    masterSku=  "HTR-LEAD", desc=   "LEAD ROPE 9' CAMOFLAUGE",  desc2=  "", upc=    "804381028598", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "HTR-LEAD-OR",  masterSku=  "HTR-LEAD", desc=   "LEAD ROPE 9' ORANGE",  desc2=  "", upc=    "804381028338", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "ORANGE",   dem2=   ""  },
                new Item() {sku =   "HTR-LEAD-PK",  masterSku=  "HTR-LEAD", desc=   "LEAD ROPE 9' PINK",    desc2=  "", upc=    "804381028321", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "HW21AL",   masterSku=  "HW21AL",   desc=   "HS  1 PC SLIT EAR HARNESS",    desc2=  "CART BKL LATIGO TIES", upc=    "610393100562", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HWL113AL", masterSku=  "HWL113AL", desc=   "HS 1 PC SLIT EAR CHST THT LTCH",   desc2=  "CAMO BD CART BKL LATIGO TIES", upc=    "610393100555", brand=  "MARTIN",   code=   "HEADSTALLS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "HWR16",    masterSku=  "HWR16",    desc=   "HANGING WASH RACK",    desc2=  "", upc=    "610393103280", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "IP14BK",   masterSku=  "IPAD", desc=   "IPAD PACK 14", desc2=  "BLACK",    upc=    "610393096223", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "IP16CK",   masterSku=  "IPAD", desc=   "IPAD PACK 16", desc2=  "CORAL KNIGHT", upc=    "610393102689", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "IP15HL",   masterSku=  "IPAD", desc=   "IPAD PACK 15", desc2=  "HOTLEAF",  upc=    "610393102290", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "HOTLEAF",  dem2=   ""  },
                new Item() {sku =   "IP16TD",   masterSku=  "IPAD", desc=   "IPAD PACK 16", desc2=  "TEAL DIAMOND", upc=    "610393102672", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "IS45150CR",    masterSku=  "IS45150CR",    desc=   "45 Chest Martin Shooter 15",   desc2=  "Roughout 1/2 Breed Oak Spider*",   upc=    "", brand=  "MARTIN",   code=   "HVSADDLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "JBBIT1",   masterSku=  "JBBIT1",   desc=   "JOE BEAVER BIT",   desc2=  "7 1/2 SHANK HP MP",    upc=    "610393094021", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "JBBIT2",   masterSku=  "JBBIT2",   desc=   "JOE BEAVER BIT",   desc2=  "7 1/2 SHANK LP MP",    upc=    "610393094038", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "JBBIT3",   masterSku=  "JBBIT3",   desc=   "JOE BEAVER BIT",   desc2=  "8 SHANK HP MP",    upc=    "610393094045", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "JMK 528 S",    masterSku=  "JMK 528 S",    desc=   "JR MONEYMAKER KID ROPE ",  desc2=  "5/16 28' S",   upc=    "610393008714", brand=  "CLASSIC",  code=   "CKIDROPES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "JP-1/2-L", masterSku=  "JP-1/2-L", desc=   "JUMP 1/2 LARGE",   desc2=  "", upc=    "804381003700", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "JP-1/2-M", masterSku=  "JP-1/2-M", desc=   "JUMP 1/2 MEDIUM",  desc2=  "", upc=    "804381003694", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "JP-3/4-L", masterSku=  "JP-3/4-L", desc=   "JUMP 3/4 LARGE",   desc2=  "", upc=    "804381003847", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "JP-3/4-M", masterSku=  "JP-3/4-M", desc=   "JUMP 3/4 MEDIUM",  desc2=  "", upc=    "804381003830", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "JRBAG15PDLG",  masterSku=  "JRBAG",    desc=   "JUNIOR ROPE BAG 15",   desc2=  "PLAID LIME GREEN", upc=    "610393098364", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "PLAID LIME GREEN", dem2=   ""  },
                new Item() {sku =   "JRBAG16PDRD",  masterSku=  "JRBAG",    desc=   "JUNIOR ROPE BAG 16",   desc2=  "PLAID RED",    upc=    "610393102559", brand=  "CLASSIC",  code=   "CROPEBAGS",    dem1=   "PLAID RED",    dem2=   ""  },
                new Item() {sku =   "KIDGROOMPK",   masterSku=  "KIDGROOMKIT",  desc=   "MY FIRST GROOM KIT PINK",  desc2=  "", upc=    "610393078731", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "KIDGROOM", masterSku=  "KIDGROOMKIT",  desc=   "MY FIRST GROOM KIT",   desc2=  "", upc=    "610393077987", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "RED",  dem2=   ""  },
                new Item() {sku =   "KSCABCB",  masterSku=  "KSCABCB",  desc=   "KNIFE SCABBARD - BSKT CHEST",  desc2=  "[T30]",    upc=    "610393082172", brand=  "MARTIN",   code=   "OTHER",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "KSCABCS",  masterSku=  "KSCABCS",  desc=   "KNIFE SCABBARD - SMOOTH CHEST",    desc2=  "", upc=    "610393082189", brand=  "MARTIN",   code=   "OTHER",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "LDL-EA",   masterSku=  "LDL-EA",   desc=   "LOOP-D-LOO",   desc2=  "", upc=    "804381019978", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "LEAD14BK", masterSku=  "LEAD", desc=   "14 FT LEAD ROPE",  desc2=  "BLACK",    upc=    "610393094427", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK",    dem2=   "14"    },
                new Item() {sku =   "LEAD9BK",  masterSku=  "LEAD", desc=   "9 FT LEAD ROPE",   desc2=  "BLACK",    upc=    "610393091662", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "BLACK",    dem2=   "9" },
                new Item() {sku =   "LEAD9CA",  masterSku=  "LEAD", desc=   "9 FT LEAD ROPE",   desc2=  "CAMO", upc=    "610393091679", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "CAMO", dem2=   "9" },
                new Item() {sku =   "LEAD23SBK",    masterSku=  "LEAD23SBK",    desc=   "23' LEAD ROPE W/BULL SNAP",    desc2=  "BLACK",    upc=    "610393094441", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "LEAD9MT",  masterSku=  "LEAD9MT",  desc=   "9 FT LEAD ROPE",   desc2=  "MULE TAPE",    upc=    "610393102757", brand=  "MARTIN",   code=   "HALTERS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "LG3A-BL",  masterSku=  "LG3",  desc=   "LEG GUARD ARAB/SM HORSE",  desc2=  "BLUE", upc=    "804381030720", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE", dem2=   "ARAB/SM HORSE" },
                new Item() {sku =   "LG3H-BL",  masterSku=  "LG3",  desc=   "LEG GUARD HORSE",  desc2=  "BLUE", upc=    "804381030775", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE", dem2=   "HORSE" },
                new Item() {sku =   "LG3WB-BL", masterSku=  "LG3",  desc=   "LEG GUARD WARMBLOOD",  desc2=  "BLUE", upc=    "804381030782", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "BLUE", dem2=   "WARMBLOOD" },
                new Item() {sku =   "LG3A", masterSku=  "LG3",  desc=   "LEG GUARD ARAB/SM HORSE ", desc2=  "", upc=    "804381021049", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "ARAB/SM HORSE" },
                new Item() {sku =   "LG3D", masterSku=  "LG3",  desc=   "LEG GUARD DRAFT",  desc2=  "", upc=    "804381021025", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "DRAFT" },
                new Item() {sku =   "LG3H", masterSku=  "LG3",  desc=   "LEG GUARD  HORSE", desc2=  "", upc=    "804381021032", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "HORSE" },
                new Item() {sku =   "LG3M", masterSku=  "LG3",  desc=   "LEG GUARD MINI",   desc2=  "", upc=    "804381021346", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "MINI"  },
                new Item() {sku =   "LG3P", masterSku=  "LG3",  desc=   "LEG GUARD  LRG PONY",  desc2=  "", upc=    "804381021056", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "PONY"  },
                new Item() {sku =   "LG3SP",    masterSku=  "LG3",  desc=   "LEG GUARD SMALL PONY", desc2=  "", upc=    "804381021339", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "SMALL PONY"    },
                new Item() {sku =   "LG3WB",    masterSku=  "LG3",  desc=   "LEG GUARD WARMBLOOD",  desc2=  "", upc=    "804381021018", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "GREY", dem2=   "WARMBLOOD" },
                new Item() {sku =   "LG3A-OR",  masterSku=  "LG3",  desc=   "LEG GUARD ARAB/SM HORSE",  desc2=  "ORANGE",   upc=    "804381030744", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ORANGE",   dem2=   "ARAB/SM HORSE" },
                new Item() {sku =   "LG3H-OR",  masterSku=  "LG3",  desc=   "LEG GUARD HORSE",  desc2=  "ORANGE",   upc=    "804381030768", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ORANGE",   dem2=   "HORSE" },
                new Item() {sku =   "LG3WB-OR", masterSku=  "LG3",  desc=   "LEG GUARD WARMBLOOD",  desc2=  "ORANGE",   upc=    "804381030799", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ORANGE",   dem2=   "WARMBLOOD" },
                new Item() {sku =   "LG3A-PK",  masterSku=  "LG3",  desc=   "LEG GUARD ARAB/SM HORSE",  desc2=  "PINK", upc=    "804381030737", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PINK", dem2=   "ARAB/SM HORSE" },
                new Item() {sku =   "LG3H-PK",  masterSku=  "LG3",  desc=   "LEG GUARD HORSE",  desc2=  "PINK", upc=    "804381030751", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PINK", dem2=   "HORSE" },
                new Item() {sku =   "LG3WB-PK", masterSku=  "LG3",  desc=   "LEG GUARD WARMBLOOD",  desc2=  "PINK", upc=    "804381030805", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "PINK", dem2=   "WARMBLOOD" },
                new Item() {sku =   "LL134",    masterSku=  "LL134",    desc=   "LONG LATIGO - 1 3/4",  desc2=  "Granbury", upc=    "610393001289", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "LSB100B L",    masterSku=  "LSB100B",  desc=   "LEATHER SPLINT BOOT BUCKLE L", desc2=  "", upc=    "610393008738", brand=  "WEQUINE",  code=   "LEATHRBOOT",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "LSB100B M",    masterSku=  "LSB100B",  desc=   "LEATHER SPLINT BOOT BUCKLE M", desc2=  "", upc=    "610393008745", brand=  "WEQUINE",  code=   "LEATHRBOOT",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "LSB100B S",    masterSku=  "LSB100B",  desc=   "LEATHER SPLINT BOOT BUCKLE S", desc2=  "", upc=    "610393008752", brand=  "WEQUINE",  code=   "LEATHRBOOT",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "LSB200N",  masterSku=  "LSB200N",  desc=   "LEATHER SKID BOOT",    desc2=  "NYLON",    upc=    "610393087443", brand=  "WEQUINE",  code=   "LEATHRBOOT",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "LT16CK",   masterSku=  "LTOTE",    desc=   "LARGE TOTE 16",    desc2=  "CORAL KNIGHT", upc=    "610393102665", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "LT15HL",   masterSku=  "LTOTE",    desc=   "LARGE TOTE 15",    desc2=  "HOTLEAF",  upc=    "610393102276", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "HOTLEAF",  dem2=   ""  },
                new Item() {sku =   "LT16TD",   masterSku=  "LTOTE",    desc=   "LARGE TOTE 16",    desc2=  "TEAL DIAMOND", upc=    "610393102658", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "LVBB10",   masterSku=  "LVBB10",   desc=   "LV B BIT 6 1/2 SHANK", desc2=  "SNAFFLE MP",   upc=    "610393097886", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVBB11",   masterSku=  "LVBB11",   desc=   "LV B BIT 7 1/2 SHANK", desc2=  "DOGBONE SNAFFLE MP",   upc=    "610393097893", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVBB12",   masterSku=  "LVBB12",   desc=   "LV B BIT 8 1/2 SHANK", desc2=  "PORTED MP",    upc=    "610393097909", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVBB7",    masterSku=  "LVBB7",    desc=   "LV B BIT 5 1/2 SHANK", desc2=  "SNAFFLE MP",   upc=    "610393097916", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVBB8",    masterSku=  "LVBB8",    desc=   "LV B BIT 6 1/2 SHANK", desc2=  "O RING SNAFFLE MP",    upc=    "610393097923", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVBB9",    masterSku=  "LVBB9",    desc=   "LV B BIT 7 3/4 SHANK", desc2=  "PORTED MP",    upc=    "610393097930", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVCH2",    masterSku=  "LVCH2",    desc=   "LV COWHORSE BIT #2 P4",    desc2=  "7 1/2 SHANK MASTER VERSATILITY",   upc=    "804381030973", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVCH3",    masterSku=  "LVCH3",    desc=   "LV COWHORSE BIT #3 P5",    desc2=  "8 SHANK MASTER RESPONDER", upc=    "610393103709", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVCH4",    masterSku=  "LVCH4",    desc=   "LV COWHORSE BIT #4 P2",    desc2=  "8 SHANK MASTER FOUNDATION",    upc=    "804381030980", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVCH5",    masterSku=  "LVCH5",    desc=   "LV COWHORSE BIT #5 P3",    desc2=  "8 1/2  SHANK MASTER TRADITIONALIST",   upc=    "610393103723", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVCH6",    masterSku=  "LVCH6",    desc=   "LV COWHORSE BIT #6 P3",    desc2=  "8 3/4 SHANK MASTER HEADSETTER",    upc=    "610393103730", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVRB1",    masterSku=  "LVRB1",    desc=   "LV ROPER BIT #1 ", desc2=  "6 1/2 SHANK DOGBONE MP MASTER EDUCATOR",   upc=    "610393103747", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVRB2",    masterSku=  "LVRB2",    desc=   "LV ROPER BIT #2 ", desc2=  "8 3/4 SHANK CHAIN MP THE POWER RATER", upc=    "610393103754", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVRB3",    masterSku=  "LVRB3",    desc=   "LV ROPER BIT #3 ", desc2=  "8 SHANK SQ PORT MP MASTER GRADUATE",   upc=    "610393103761", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVRB5",    masterSku=  "LVRB5",    desc=   "LV ROPER BIT #5 ", desc2=  "7 3/4 SHANK CORR MP  MASTER QUALIFIER",    upc=    "610393103778", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVRB6",    masterSku=  "LVRB6",    desc=   "LV ROPER BIT #6 ", desc2=  "7 3/4 MP SQ PORT ROLLER MP MASTER NEXT LEVEL", upc=    "610393103785", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "LVRB8",    masterSku=  "LVRB8",    desc=   "LV ROPER BIT #8  ",    desc2=  "7 3/4 SHANK 3 PC MP MASTER INTERPERTER",   upc=    "610393103792", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "MAGICLOOP",    masterSku=  "MAGICLOOP",    desc=   "MAGIC LOOP BREAK AWAY HONDA",  desc2=  "", upc=    "610393007090", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "MC6P4P",   masterSku=  "MC6P4P",   desc=   "MEN'S MARTIN CAPS",    desc2=  "4 PACK",   upc=    "610393095325", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "MF-18-BLA",    masterSku=  "MF-18-BLA",    desc=   "MANURE FORK 18 TINE BLACK",    desc2=  "", upc=    "804381024828", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "MFH",  masterSku=  "MFH",  desc=   "MANURE FORK HANDLE",   desc2=  "", upc=    "804381030379", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "MONEL4-I", masterSku=  "MONEL-4I", desc=   "METAL  BOUND WOOD STIRRUPS",   desc2=  "4",    upc=    "610393089386", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "4",    dem2=   ""  },
                new Item() {sku =   "MRR 330MS",    masterSku=  "MRR",  desc=   "MM 3/8 30 MS RHB", desc2=  "", upc=    "610393010915", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "MRR 330 S",    masterSku=  "MRR",  desc=   "MM 3/8 30 S RHB",  desc2=  "", upc=    "610393010892", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "MRR 330XS",    masterSku=  "MRR",  desc=   "MM 3/8 30 XS RHB", desc2=  "", upc=    "610393010922", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "MRR 3302X",    masterSku=  "MRR",  desc=   "MM 3/8 30 XXS RHB",    desc2=  "", upc=    "610393010908", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "MRR 335HM",    masterSku=  "MRR",  desc=   "MM 3/8 35 HM RHB", desc2=  "", upc=    "610393010977", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "MRR 335 M",    masterSku=  "MRR",  desc=   "MM 3/8 35 M RHB",  desc2=  "", upc=    "610393010946", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "MRR 335MH",    masterSku=  "MRR",  desc=   "MM 3/8 35 MH RHB", desc2=  "", upc=    "610393010984", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "MRR 335MS",    masterSku=  "MRR",  desc=   "MM 3/8 35 MS RHB", desc2=  "", upc=    "610393010991", brand=  "CLASSIC",  code=   "C3-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "MTHOB",    masterSku=  "MTHOB",    desc=   "HOBBLES MULE TAPE",    desc2=  "", upc=    "610393091884", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "N30-BLA",  masterSku=  "N30-BLA",  desc=   "NAVAJO 30X31 SOLID BLACK", desc2=  "", upc=    "804381027348", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N30-TAN",  masterSku=  "N30-TAN",  desc=   "NAVAJO 30X31 SOLID TAN",   desc2=  "", upc=    "804381027089", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-BLA",  masterSku=  "N32-BLA",  desc=   "NAVAJO 32x34 SOLID BLACK", desc2=  "", upc=    "804381027065", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-TAN",  masterSku=  "N32-TAN",  desc=   "NAVAJO 32x34 SOLID TAN",   desc2=  "", upc=    "804381027072", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32X64-BLA",   masterSku=  "N32X64-BLA",   desc=   "NAVAJO 32 X 64 BLACK/WHITE",   desc2=  "", upc=    "804381025962", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32X64-BLU",   masterSku=  "N32X64-BLU",   desc=   "NAVAJO 32 X 64 BLUE/WHITE",    desc2=  "", upc=    "804381025979", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32X64-GRN",   masterSku=  "N32X64-GRN",   desc=   "NAVAJO 32 X 64 GREEN/WHITE",   desc2=  "", upc=    "804381025986", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32X64-RED",   masterSku=  "N32X64-RED",   desc=   "NAVAJO 32 X 64 RED/WHITE", desc2=  "", upc=    "804381026655", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-ZZ-BLA",   masterSku=  "N32-ZZ-BLA",   desc=   "NAVAJO 32x34 ZIGZAG BLACK",    desc2=  "", upc=    "804381024453", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-ZZ-GRN",   masterSku=  "N32-ZZ-GRN",   desc=   "NAVAJO 32x34 ZIGZAG GREEN",    desc2=  "", upc=    "804381024477", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-ZZ-NAV",   masterSku=  "N32-ZZ-NAV",   desc=   "NAVAJO 32x34 ZIGZAG NAVY", desc2=  "", upc=    "804381024484", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-ZZ-NEO",   masterSku=  "N32-ZZ-NEO",   desc=   "NAVAJO 32x34 ZIGZAG NEON", desc2=  "", upc=    "804381024460", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-ZZ-RED",   masterSku=  "N32-ZZ-RED",   desc=   "NAVAJO 32x34 ZIGZAG RED",  desc2=  "", upc=    "804381024491", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N32-ZZ-TAN",   masterSku=  "N32-ZZ-TAN",   desc=   "NAVAJO 32x34 ZIGZAG TAN",  desc2=  "", upc=    "804381024507", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-BLA",  masterSku=  "N34-BLA",  desc=   "NAVAJO 34X36 SOLID BLACK", desc2=  "", upc=    "804381027027", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-CK-CRM-BLA",   masterSku=  "N34-CK-CRM-BLA",   desc=   "*NAVAJO 34x36 CHECK CRM  BLACK",   desc2=  "", upc=    "804381012900", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-CK-CRM-GRN",   masterSku=  "N34-CK-CRM-GRN",   desc=   "*NAVAJO 34x36 CHECK CRM GREEN",    desc2=  "", upc=    "804381012917", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-CK-RED-BLA",   masterSku=  "N34-CK-RED-BLA",   desc=   "*NAVAJO 34x36 CHECK RED BLACK",    desc2=  "", upc=    "804381012924", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-MLT-BLU-BLA",  masterSku=  "N34-MLT-BLU-BLA",  desc=   "*NAVAJO 34x36 MULTI BLUE BLACK",   desc2=  "", upc=    "804381012931", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-MLT-GRN-RED",  masterSku=  "N34-MLT-GRN-RED",  desc=   "*NAVAJO 34x36 MULTI GRN RED",  desc2=  "", upc=    "804381012955", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-MLT-PNK-TEA",  masterSku=  "N34-MLT-PNK-TEA",  desc=   "*NAVAJO 34x36 MULTI  PINK TEAL",   desc2=  "", upc=    "804381012894", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-TAN",  masterSku=  "N34-TAN",  desc=   "*NAVAJO 34X36 SOLID TAN",  desc2=  "", upc=    "804381027041", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-ZZ-BLA",   masterSku=  "N34-ZZ-BLA",   desc=   "*NAVAJO 34x36 ZIGZAG BLACK",   desc2=  "", upc=    "804381022763", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-ZZ-GRN",   masterSku=  "N34-ZZ-GRN",   desc=   "*NAVAJO 34x36 ZIGZAG GREEN",   desc2=  "", upc=    "804381022770", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-ZZ-NAV",   masterSku=  "N34-ZZ-NAV",   desc=   "*NAVAJO 34x36 ZIGZAG NAVY",    desc2=  "", upc=    "804381022787", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-ZZ-NEO",   masterSku=  "N34-ZZ-NEO",   desc=   "*NAVAJO 34x36 ZIGZAG BLACK NEON",  desc2=  "", upc=    "804381023371", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-ZZ-RED",   masterSku=  "N34-ZZ-RED",   desc=   "*NAVAJO 34x36 ZIGZAG RED", desc2=  "", upc=    "804381022794", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "N34-ZZ-TAN",   masterSku=  "N34-ZZ-TAN",   desc=   "*NAVAJO 34x36 ZIGZAG TAN", desc2=  "", upc=    "804381022800", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB1002HB", masterSku=  "NB1002HB", desc=   "NOSEBAND SINGLE ROPE", desc2=  "2 COLOR HARNESS BRAIDED",  upc=    "610393092010", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100BHL", masterSku=  "NB100BHL", desc=   "NOSEBAND", desc2=  "BROWN HARNESS LEATHER-RH LACE",    upc=    "610393071572", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100HCAV",    masterSku=  "NB100HCAV",    desc=   "NOSEBAND WITH CAVESON",    desc2=  "", upc=    "610393006802", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100RORD",    masterSku=  "NB100RORD",    desc=   "NOSEBAND SINGLE ROPE RO",  desc2=  "ROPE BORDER COPPER PARACHUTE DOTS",    upc=    "610393103853", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100RORS",    masterSku=  "NB100RORS",    desc=   "SINGLE ROPE NAT NB COVER (RO)",    desc2=  "RUNNING S BORDER", upc=    "610393100531", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100SR",  masterSku=  "NB100SR",  desc=   "NOSEBAND - SINGLE ROPE",   desc2=  "", upc=    "610393001319", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100SRCH",    masterSku=  "NB100SRCH",    desc=   "NOSEBAND SINGLE ROPE", desc2=  "CHOC HARNESS COVERED", upc=    "610393091747", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100SRL", masterSku=  "NB100SRL", desc=   "NOSEBAND", desc2=  "SINGLE ROPE LEATHER COVERED",  upc=    "610393001340", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB100SRPT",    masterSku=  "NB100SRPT",    desc=   "NOSEBAND", desc2=  "SINGLE ROPE PLASTIC TUBE", upc=    "610393068077", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB200DRBR",    masterSku=  "NB200DRBR",    desc=   "NOSEBAND", desc2=  "DOUBLE ROPE-BRAIDED RH",   upc=    "610393001357", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB200DRCHB",   masterSku=  "NB200DRCHB",   desc=   "NOSEBAND DBL ROPE",    desc2=  "CHOC HARNESS CVRD-RH KNOTS",   upc=    "610393091761", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB200DRHB",    masterSku=  "NB200DRHB",    desc=   "NOSEBAND DBL ROPE",    desc2=  "HARNESS CVRD-RH KNOTS",    upc=    "610393091754", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB200DRL", masterSku=  "NB200DRL", desc=   "NOSEBAND", desc2=  "DOUBLE ROPE LEATHER COVERED",  upc=    "610393001364", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB200RORS",    masterSku=  "NB200RORS",    desc=   "DOUBLE ROPE NAT NB COVER (RO)",    desc2=  "RUNNING S BORDER", upc=    "610393100548", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NB250DRLC",    masterSku=  "NB250DRLC",    desc=   "NOSEBAND - DBL ROPE ", desc2=  "LEA CVRD W/CAVESSON",  upc=    "610393001388", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NBB-16",   masterSku=  "NBB",  desc=   "NO BOW BANDAGES 16x31",    desc2=  "Large",    upc=    "804381022664", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "NBB-14",   masterSku=  "NBB",  desc=   "NO BOW BANDAGE 14x31", desc2=  "Medium",   upc=    "804381022657", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "NBB-12",   masterSku=  "NBB",  desc=   "NO BOW BANDAGE 12x31", desc2=  "Small",    upc=    "804381022640", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "NBB-18",   masterSku=  "NBB",  desc=   "NO BOW BANDAGES 18X31",    desc2=  "X-Large",  upc=    "804381022671", brand=  "CASHEL",   code=   "CSHLEGPRO",    dem1=   "X-LARGE",  dem2=   ""  },
                new Item() {sku =   "NBCHL",    masterSku=  "NBCHL",    desc=   "NOSE BAND CHOCOLATE HARNESS",  desc2=  "HARNESS LINED",    upc=    "610393093895", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NBH",  masterSku=  "NBH",  desc=   "NOTHIN BUT HORNS BREAKAWAY",   desc2=  "", upc=    "610393100821", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "NBHHL",    masterSku=  "NBHHL",    desc=   "NOSE BAND NATURAL HARNESS",    desc2=  "HARNESS LINED",    upc=    "610393093888", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NBHLL",    masterSku=  "NBHLL",    desc=   "NOSE BAND NATURAL HARNESS",    desc2=  "LATIGO LINED", upc=    "610393072302", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "NBN",  masterSku=  "NBN",  desc=   "NOTHIN BUT NECK BREAKAWAY",    desc2=  "", upc=    "854595005120", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "NSB201BK", masterSku=  "NSB201BK", desc=   "NEOPRENE SKID BOOT",   desc2=  "BLACK",    upc=    "610393087498", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "NSB201WH", masterSku=  "NSB201WH", desc=   "NEOPRENE SKID BOOT",   desc2=  "WHITE",    upc=    "610393087504", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "NV4 330MS",    masterSku=  "NV4",  desc=   "NV4 3/8 30' MS",   desc2=  "", upc=    "610393068244", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "NV4 330 S",    masterSku=  "NV4",  desc=   "NV4 3/8 30' S",    desc2=  "", upc=    "610393068237", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "NV4 330XS",    masterSku=  "NV4",  desc=   "NV4 3/8 30' XS",   desc2=  "", upc=    "610393068220", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "NV4 3302X",    masterSku=  "NV4",  desc=   "NV4 3/8 30' XXS",  desc2=  "", upc=    "610393068213", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "NV4 335HM",    masterSku=  "NV4",  desc=   "NV4 3/8 35' HM",   desc2=  "", upc=    "610393068275", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "NV4 335 M",    masterSku=  "NV4",  desc=   "NV4 3/8 35' M",    desc2=  "", upc=    "610393068268", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "NV4 335MH",    masterSku=  "NV4",  desc=   "NV4 3/8 35' MH",   desc2=  "", upc=    "610393068282", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "NV4 335MS",    masterSku=  "NV4",  desc=   "NV4 3/8 35' MS",   desc2=  "", upc=    "610393068251", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "OL134",    masterSku=  "OL134",    desc=   "OFFSIDE LATIGO - 1 3/4",   desc2=  "Granbury.",    upc=    "610393001395", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "OL134DS",  masterSku=  "OL134DS",  desc=   "OFFSIDE LATIGO - DOUBLE SEWN", desc2=  "1-3/4",    upc=    "610393086668", brand=  "MARTIN",   code=   "FLANKCINCH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "OUH",  masterSku=  "OUH",  desc=   "3/8 OVER & UNDER HARNESS", desc2=  "", upc=    "610393081472", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "OUHP", masterSku=  "OUHP", desc=   "3/8 OVER & UNDER HARNESS", desc2=  "W/ POPPER",    upc=    "610393081489", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "P32BLA",   masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "BLACK",    upc=    "804381028277", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "P32ZBLA",  masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "ZZ BLACK", upc=    "804381028062", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "P32ZGRN",  masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "ZZ GREEN", upc=    "804381028079", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "P32ZNAV",  masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "ZZ NAVY",  upc=    "804381028086", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "NAVY", dem2=   ""  },
                new Item() {sku =   "P32ZRED",  masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "ZZ RED",   upc=    "804381028109", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "RED",  dem2=   ""  },
                new Item() {sku =   "P32ZTAN",  masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "ZZ TAN",   upc=    "804381028116", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "TAN",  dem2=   ""  },
                new Item() {sku =   "P32TAN",   masterSku=  "P32",  desc=   "PERFORMANCE PAD 32X34",    desc2=  "TAN",  upc=    "804381028284", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "TAN",  dem2=   ""  },
                new Item() {sku =   "P34BLA",   masterSku=  "P34BLA",   desc=   "PERFORMANCE PAD 34X34",    desc2=  "BLACK",    upc=    "804381028123", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34GB",    masterSku=  "P34GB",    desc=   "PERFORMANCE PAD 34X36",    desc2=  "GREEN BLACK",  upc=    "804381028130", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34GRT",   masterSku=  "P34GRT",   desc=   "PERFORMANCE PAD 34X36",    desc2=  "GREEN RED TAN",    upc=    "804381028147", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34RB",    masterSku=  "P34RB",    desc=   "PERFORMANCE PAD 34X36",    desc2=  "RED BLACK",    upc=    "804381028154", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34TAN",   masterSku=  "P34TAN",   desc=   "PERFORMANCE PAD 34X34",    desc2=  "TAN",  upc=    "804381028161", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34TB",    masterSku=  "P34TB",    desc=   "PERFORMANCE PAD 34X36",    desc2=  "TAN BLACK",    upc=    "804381013266", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34TG",    masterSku=  "P34TG",    desc=   "PERFORMANCE PAD 34X36",    desc2=  "TAN GREEN",    upc=    "804381028185", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34TNBLBK",    masterSku=  "P34TNBLBK",    desc=   "PERFORMANCE PAD 34X36",    desc2=  "TAN BLUE BLACK",   upc=    "804381028574", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34TPB",   masterSku=  "P34TPB",   desc=   "PERFORMANCE PAD 34X36",    desc2=  "TEAL PINK BLACK",  upc=    "804381028192", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34ZBLA",  masterSku=  "P34ZBLA",  desc=   "PERFORMANCE PAD 34X36",    desc2=  "ZZ BLACK", upc=    "804381028208", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34ZGRN",  masterSku=  "P34ZGRN",  desc=   "PERFORMANCE PAD 34X36",    desc2=  "ZZ GREEN", upc=    "804381028215", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34ZNAV",  masterSku=  "P34ZNAV",  desc=   "PERFORMANCE PAD 34X36",    desc2=  "ZZ NAVY",  upc=    "804381028222", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34ZRED",  masterSku=  "P34ZRED",  desc=   "PERFORMANCE PAD 34X36",    desc2=  "ZZ RED",   upc=    "804381028246", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "P34ZTAN",  masterSku=  "P34ZTAN",  desc=   "PERFORMANCE PAD 34X36",    desc2=  "ZZ TAN",   upc=    "804381028253", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "PC214RO",  masterSku=  "PC214RO",  desc=   "NAT PULLING COLLAR",   desc2=  "ROUGH OUT",    upc=    "610393089409", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "PHBTD",    masterSku=  "PHBTD",    desc=   "PH BUNGIE TIE DOWN",   desc2=  "", upc=    "610393098661", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "PHFLEXRIG",    masterSku=  "PHFLEXRIG",    desc=   "PH FLEXION RIG",   desc2=  "", upc=    "610393099910", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "PHMARTINGALERR",   masterSku=  "PHMARTINGALESRRR", desc=   "PH MARTINGALE-ROPING REIN",    desc2=  "", upc=    "610393099897", brand=  "MARTIN",   code=   "TRAINING", dem1=   "ROPING REIN",  dem2=   ""  },
                new Item() {sku =   "PHMARTINGALESR",   masterSku=  "PHMARTINGALESRRR", desc=   "PH MARTINGALE-SPLIT REIN", desc2=  "", upc=    "610393099880", brand=  "MARTIN",   code=   "TRAINING", dem1=   "SPLIT REIN",   dem2=   ""  },
                new Item() {sku =   "PHREIN",   masterSku=  "PHREIN",   desc=   "PH BLK BRAIDED REIN 1/2",  desc2=  "", upc=    "610393099903", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "POLOW4BK", masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG-BLACK",    desc2=  "", upc=    "610393013244", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "POLOW14CLD",   masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "CHOCOLATE LIME DOTS",  upc=    "610393098463", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE LIME DOTS",  dem2=   ""  },
                new Item() {sku =   "POLOW15CTT",   masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "CHOCOLATE TEAL TWIST", upc=    "610393101972", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CHOCOLATE TEAL TWIST", dem2=   ""  },
                new Item() {sku =   "POLOW16CGL",   masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "CORAL GOLD LACE",  upc=    "610393101965", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL GOLD LACE",  dem2=   ""  },
                new Item() {sku =   "POLOW4CO", masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "CORAL",    upc=    "610393093291", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "CORAL",    dem2=   ""  },
                new Item() {sku =   "POLOW14FBL",   masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "FUCHSIA BLUE LACE",    upc=    "610393098470", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA BLUE LACE",    dem2=   ""  },
                new Item() {sku =   "POLOW4FC", masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "FUCHSIA",  upc=    "610393093697", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "FUCHSIA",  dem2=   ""  },
                new Item() {sku =   "POLOW16GFT",   masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "GREY FUCHSIA TRIANGLE",    upc=    "610393101989", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "GREY FUCHSIA TRIANGLE",    dem2=   ""  },
                new Item() {sku =   "POLOW4LB", masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "LIGHT BLUE",   upc=    "610393070681", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "LIGHT BLUE",   dem2=   ""  },
                new Item() {sku =   "POLOW16PP",    masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "PURPLE PEACOCK",   upc=    "610393101774", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "PURPLE PEACOCK",   dem2=   ""  },
                new Item() {sku =   "POLOW4SGY",    masterSku=  "POLOW",    desc=   "POLOWRAP WITH WASH BAG",   desc2=  "STEEL GREY",   upc=    "610393103228", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "STEEL GREY",   dem2=   ""  },
                new Item() {sku =   "POLOW15WL",    masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG",  desc2=  "WHITE LIPS",   upc=    "610393101781", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE LIPS",   dem2=   ""  },
                new Item() {sku =   "POLOW4WH", masterSku=  "POLOW",    desc=   "POLO WRAP WITH WASH BAG-WHITE",    desc2=  "", upc=    "610393013251", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   ""  },
                new Item() {sku =   "PP-BLA-WE-L",  masterSku=  "PP-BLA-WE",    desc=   "PAD PAL BLACK WESTERN SQUARE L",   desc2=  "32 X 32",  upc=    "804381007074", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "32 X 32",  dem2=   ""  },
                new Item() {sku =   "PP-BLA-WE-XL", masterSku=  "PP-BLA-WE",    desc=   "PAD PAL BLACK WEST SQUARE XL", desc2=  "34 X 34",  upc=    "804381007081", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "34 X 34",  dem2=   ""  },
                new Item() {sku =   "PSB200",   masterSku=  "PSB200",   desc=   "PERFORMANCE SKID BOOT",    desc2=  "", upc=    "610393013480", brand=  "WEQUINE",  code=   "LEATHRBOOT",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "PSB200B",  masterSku=  "PSB200B",  desc=   "PERFORMANCE SKID BOOT BUCKLES",    desc2=  "", upc=    "610393092164", brand=  "WEQUINE",  code=   "LEATHRBOOT",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "PT100BKL", masterSku=  "PT100",    desc=   "PRO TECH BOOTS FRONT", desc2=  "BLACK LARGE",  upc=    "610393070131", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "PT100BKM", masterSku=  "PT100",    desc=   "PRO TECH BOOTS FRONT", desc2=  "BLACK MEDIUM", upc=    "610393070124", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "PT100BKS", masterSku=  "PT100",    desc=   "PRO TECH BOOTS FRONT", desc2=  "BLACK SMALL",  upc=    "610393070117", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "PT100WL",  masterSku=  "PT100",    desc=   "PRO TECH BOOTS FRONT", desc2=  "WHITE LARGE",  upc=    "610393070162", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT LARGE"   },
                new Item() {sku =   "PT100WM",  masterSku=  "PT100",    desc=   "PRO TECH BOOTS FRONT", desc2=  "WHITE MEDIUM", upc=    "610393070155", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT MEDIUM"  },
                new Item() {sku =   "PT100WS",  masterSku=  "PT100",    desc=   "PRO TECH BOOTS FRONT", desc2=  "WHITE SMALL",  upc=    "610393070148", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT SMALL"   },
                new Item() {sku =   "PT201BKL", masterSku=  "PT201",    desc=   "PRO TECH BOOTS HIND",  desc2=  "BLACK LARGE",  upc=    "610393090962", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "PT201BKM", masterSku=  "PT201",    desc=   "PRO TECH BOOTS HIND",  desc2=  "BLACK MED",    upc=    "610393090979", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "PT201BKS", masterSku=  "PT201",    desc=   "PRO TECH BOOTS HIND",  desc2=  "BLACK SMALL",  upc=    "610393090986", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "PT201WL",  masterSku=  "PT201",    desc=   "PRO TECH BOOTS HIND",  desc2=  "WHITE LARGE",  upc=    "610393090993", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND LARGE"    },
                new Item() {sku =   "PT201WM",  masterSku=  "PT201",    desc=   "PRO TECH BOOTS HIND",  desc2=  "WHITE MEDIUM", upc=    "610393091006", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND MEDIUM"   },
                new Item() {sku =   "PT201WS",  masterSku=  "PT201",    desc=   "PRO TECH BOOTS HIND",  desc2=  "WHITE SMALL",  upc=    "610393091013", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND SMALL"    },
                new Item() {sku =   "PTNT2BKL", masterSku=  "PTNT2",    desc=   "PRO TECH NO TURN 2",   desc2=  "BLACK LARGE",  upc=    "610393092447", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "LARGE" },
                new Item() {sku =   "PTNT2BKM", masterSku=  "PTNT2",    desc=   "PRO TECH NO TURN 2",   desc2=  "BLACK MED",    upc=    "610393092461", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "MEDIUM"    },
                new Item() {sku =   "PTNT2BKS", masterSku=  "PTNT2",    desc=   "PRO TECH NO TURN 2",   desc2=  "BLACK SMALL",  upc=    "610393092454", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "BLACK",    dem2=   "SMALL" },
                new Item() {sku =   "PTNT2WHL", masterSku=  "PTNT2",    desc=   "PRO TECH NO TURN 2",   desc2=  "WHITE LARGE",  upc=    "610393092492", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "LARGE" },
                new Item() {sku =   "PTNT2WHM", masterSku=  "PTNT2",    desc=   "PRO TECH NO TURN 2",   desc2=  "WHITE MED",    upc=    "610393092485", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "MEDIUM"    },
                new Item() {sku =   "PTNT2WHS", masterSku=  "PTNT2",    desc=   "PRO TECH NO TURN 2",   desc2=  "WHITE SMALL",  upc=    "610393092478", brand=  "WEQUINE",  code=   "BELLBOOT", dem1=   "WHITE",    dem2=   "SMALL" },
                new Item() {sku =   "PTP2BK",   masterSku=  "PTP2BK",   desc=   "PERFORMANCE TRAINER PAD 2",    desc2=  "BLACK",    upc=    "610393098180", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "PTP2BR",   masterSku=  "PTP2BK",   desc=   "PERFORMANCE TRAINER PAD 2",    desc2=  "BROWN",    upc=    "610393103358", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "PWRS330MS",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 30' MS",    desc2=  "", upc=    "610393009964", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "PWRS330 S",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 30' S", desc2=  "", upc=    "610393009957", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "PWRS330XS",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 30' XS",    desc2=  "", upc=    "610393009940", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "PWRS3302X",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 30' XXS",   desc2=  "", upc=    "610393009933", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "PWRS335HM",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 35' ",  desc2=  "HARD MEDIUM",  upc=    "610393011875", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "PWRS335 M",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 35' MEDIUM",    desc2=  "", upc=    "610393011813", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "PWRS335MH",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 35' ",  desc2=  "MEDUIM HARD",  upc=    "610393011882", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "PWRS335MS",    masterSku=  "PWRS", desc=   "POWERLINE LITE 3/8 35' ",  desc2=  "MEDIUM SOFT",  upc=    "610393011806", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "QR-BA",    masterSku=  "QR-BA",    desc=   "QUIET RIDE BUG ARMOR 2 PIECE", desc2=  "", upc=    "804381008101", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "QR-BG",    masterSku=  "QR-BG",    desc=   "QUIET RIDE BELLY GUARD",   desc2=  "", upc=    "804381009443", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "QR-BUG-NET",   masterSku=  "QR-BUG-NET",   desc=   "QUIET RIDE BUG NET",   desc2=  "", upc=    "804381009504", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "QR-HD",    masterSku=  "QR-HD",    desc=   "QUIET RIDE HOOD",  desc2=  "", upc=    "804381009436", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "QRAL", masterSku=  "QRL",  desc=   "QUIET RIDE LONG NOSE", desc2=  "SM QTR HORSE/ARAB/COB",    upc=    "804381008026", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "QRDL", masterSku=  "QRL",  desc=   "QUIET RIDE DRAFT LONG",    desc2=  "", upc=    "804381009863", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "QRHL", masterSku=  "QRL",  desc=   "QUIET RIDE LONG NOSE", desc2=  "HORSE",    upc=    "804381008064", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "QRWBL",    masterSku=  "QRL",  desc=   "QUIET RIDE LONG NOSE", desc2=  "WARMBLOOD",    upc=    "804381008132", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "QRYL", masterSku=  "QRL",  desc=   "QUIET RIDE LONG NOSE", desc2=  "YEARLING/LG PONY", upc=    "804381008583", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "QRALE",    masterSku=  "QRLE", desc=   "QUIET RIDE LONG NOSE EARS",    desc2=  "SM QTR HORSE/ARAB/COB",    upc=    "804381008033", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "QRDLE",    masterSku=  "QRLE", desc=   "QUIET RIDE DRAFT LONG EARS",   desc2=  "", upc=    "804381008170", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "QRFLE",    masterSku=  "QRLE", desc=   "*QUIET RIDE FOAL/MINI",    desc2=  "LONG EARS",    upc=    "804381008484", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "FOAL", dem2=   ""  },
                new Item() {sku =   "QRHLE",    masterSku=  "QRLE", desc=   "QUIET RIDE LONG EARS", desc2=  "HORSE",    upc=    "804381008071", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "QRWBLE",   masterSku=  "QRLE", desc=   "QUIET RIDE LONG EARS", desc2=  "WARMBLOOD",    upc=    "804381008149", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "QRYLE",    masterSku=  "QRLE", desc=   "QUIET RIDE LONG EARS", desc2=  "YEARLING/LG PONY", upc=    "804381008606", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "QRMALE",   masterSku=  "QRMLE",    desc=   "QR MULE SM QTR HSE/ARB/COB LWE",   desc2=  "", upc=    "804381009207", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "QRMHLE",   masterSku=  "QRMLE",    desc=   "QR MULE HORSE LONG EAR",   desc2=  "", upc=    "804381009238", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "QRMYLE",   masterSku=  "QRMLE",    desc=   "QR MULE YEARLING LONG EAR",    desc2=  "", upc=    "804381009337", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "QRMASE",   masterSku=  "QRMSE",    desc=   "QR MULE SM QTR HSE/ARB/COB SWE",   desc2=  "", upc=    "804381009214", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "QRMDSE",   masterSku=  "QRMSE",    desc=   "QR MULE DRAFT STD EAR",    desc2=  "", upc=    "804381009245", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "QRMHSE",   masterSku=  "QRMSE",    desc=   "QR MULE HORSE STD EAR",    desc2=  "std 13 EAR",   upc=    "804381009221", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "QRMWBSE",  masterSku=  "QRMSE",    desc=   "QR MULE WARMBLOOD STD EAR",    desc2=  "", upc=    "804381009245", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "QR-NN-LRG",    masterSku=  "QR-NN",    desc=   "QUIET RIDE NOSE NET LARGE",    desc2=  "", upc=    "804381020394", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "QR-NN-MED",    masterSku=  "QR-NN",    desc=   "QUIET RIDE NOSE NET MEDIUM",   desc2=  "", upc=    "804381020950", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "QR-NN-SML",    masterSku=  "QR-NN",    desc=   "QUIET RIDE NOSE NET SMALL",    desc2=  "", upc=    "804381020967", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "QRAS", masterSku=  "QRS",  desc=   "QUIET RIDE STD",   desc2=  "SM QTR HORSE/ARAB/COB",    upc=    "804381008040", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "QRDS", masterSku=  "QRS",  desc=   "QUIET RIDE DRAFT STD", desc2=  "", upc=    "804381008187", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "QRHS", masterSku=  "QRS",  desc=   "QUIET RIDE STD",   desc2=  "HORSE",    upc=    "804381008088", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "QRWBS",    masterSku=  "QRS",  desc=   "QUIET RIDE STD",   desc2=  "WARMBLOOD",    upc=    "804381008156", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "QRYS", masterSku=  "QRS",  desc=   "QUIET RIDE STD",   desc2=  "YEARLING/LG PONY", upc=    "804381008552", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "QRASE",    masterSku=  "QRSE", desc=   "QUIET RIDE STD EARS",  desc2=  "SM QTR HORSE/ARAB/COB",    upc=    "804381008057", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "ARAB", dem2=   ""  },
                new Item() {sku =   "QRDSE",    masterSku=  "QRSE", desc=   "QUIET RIDE DRAFT STD EARS",    desc2=  "", upc=    "804381008194", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "DRAFT",    dem2=   ""  },
                new Item() {sku =   "QRHSE",    masterSku=  "QRSE", desc=   "QUIET RIDE STD EARS",  desc2=  "HORSE",    upc=    "804381008095", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "HORSE",    dem2=   ""  },
                new Item() {sku =   "QRWBSE",   masterSku=  "QRSE", desc=   "QUIET RIDE STD EARS",  desc2=  "WARMBLOOD",    upc=    "804381008125", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "WARMBLOOD",    dem2=   ""  },
                new Item() {sku =   "QRYSE",    masterSku=  "QRSE", desc=   "QUIET RIDE STD EARS",  desc2=  "YEARLING/LG PONY", upc=    "804381008576", brand=  "CASHEL",   code=   "CSHLFLYPRO",   dem1=   "YEARLING", dem2=   ""  },
                new Item() {sku =   "RBANDS",   masterSku=  "RBANDSB",  desc=   "RUBBER BRAIDING BANDS BLACK",  desc2=  "800 PC TUB",   upc=    "804381027881", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "RBANDSBR", masterSku=  "RBANDSB",  desc=   "RUBBER BRAIDING BANDS BROWN",  desc2=  "800 PC TUB",   upc=    "610393096254", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "RBANDSW",  masterSku=  "RBANDSB",  desc=   "RUBBER BRAIDING BANDS WHITE",  desc2=  "800 PC TUB",   upc=    "610393095141", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "WHITE",    dem2=   ""  },
                new Item() {sku =   "RBB",  masterSku=  "RBBAG",    desc=   "ROLLING BALE BAG", desc2=  "2 STRAND BALES",   upc=    "610393502663", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "2 STRAND", dem2=   ""  },
                new Item() {sku =   "RBB-L",    masterSku=  "RBBAG",    desc=   "ROLLING BALE BAG - LARGE", desc2=  "3 STRAND BALES",   upc=    "804381026846", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "3 STRAND", dem2=   ""  },
                new Item() {sku =   "RBGS3",    masterSku=  "RBGS3",    desc=   "RATTLER BOYS GOAT STRING 3 PLY",   desc2=  "", upc=    "610393009117", brand=  "RATTLER",  code=   "GOATSTRING",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "RC6P4P",   masterSku=  "RC6P4P",   desc=   "RATTLER CAP 6 PNL 4 PACK", desc2=  "", upc=    "610393097268", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "RCB",  masterSku=  "RCB",  desc=   "ROLLING CREW BAG", desc2=  "", upc=    "804381028420", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "RCSBRSMH", masterSku=  "RCSBR",    desc=   "BL RACER CALF STRING", desc2=  "SMALL MEDIUM HARD",    upc=    "610393045504", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "MD HD",    dem2=   ""  },
                new Item() {sku =   "RCSBRSM",  masterSku=  "RCSBR",    desc=   "BL RACER CALF STRING", desc2=  "SMALL MEDIUM", upc=    "610393045498", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "MD",   dem2=   ""  },
                new Item() {sku =   "RCSBRSSM", masterSku=  "RCSBR",    desc=   "BL RACER CALF STRING", desc2=  "SMALL SOFT MEDIUM",    upc=    "610393045481", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "SF MD",    dem2=   ""  },
                new Item() {sku =   "RCSBRSS",  masterSku=  "RCSBR",    desc=   "BL RACER CALF STRING", desc2=  "SMALL SOFT",   upc=    "610393045474", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "SF",   dem2=   ""  },
                new Item() {sku =   "RCSRRSMH", masterSku=  "RCSRR",    desc=   "RED RACER CALF STRING",    desc2=  "SMALL MEDIUM HARD",    upc=    "610393094083", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "MD HD",    dem2=   ""  },
                new Item() {sku =   "RCSRRSM",  masterSku=  "RCSRR",    desc=   "RED RACER CALF STRING",    desc2=  "SMALL MEDIUM", upc=    "610393094069", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "MD",   dem2=   ""  },
                new Item() {sku =   "RCSRRSSM", masterSku=  "RCSRR",    desc=   "RED RACER CALF STRING",    desc2=  "SMALL SOFT MEDIUM",    upc=    "610393094052", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "SF MD",    dem2=   ""  },
                new Item() {sku =   "RCSRRSS",  masterSku=  "RCSRR",    desc=   "RED RACER CALF STRING",    desc2=  "SMALL SOFT",   upc=    "610393094076", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "SF",   dem2=   ""  },
                new Item() {sku =   "RCSTUBEBL",    masterSku=  "RCSTUBEBL",    desc=   "RATTLER CALF STRING TUBE", desc2=  "BLUE", upc=    "610393100333", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "RCSSFH",   masterSku=  "RCSWR",    desc=   "RATTLER CALF STRING ", desc2=  "SMALL-FULL HARD",  upc=    "610393000244", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4 FULL", dem2=   "HD"    },
                new Item() {sku =   "RCSSFMH",  masterSku=  "RCSWR",    desc=   "RATTLER CALF STRING ", desc2=  "SMALL-FULL MED HARD",  upc=    "610393000763", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4 FULL", dem2=   "MD HD" },
                new Item() {sku =   "RCSSFM",   masterSku=  "RCSWR",    desc=   "RATTLER CALF STRING ", desc2=  "SMALL-FULL MEDIUM",    upc=    "610393000343", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4 FULL", dem2=   "MD"    },
                new Item() {sku =   "RCSSFSM",  masterSku=  "RCSWR",    desc=   "RATTLER CALF STRING ", desc2=  "SMALL-FULL SOFT MED",  upc=    "610393000787", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4 FULL", dem2=   "SF MD" },
                new Item() {sku =   "RCSSH",    masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "SMALL H",  upc=    "610393012735", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4",  dem2=   "HD"    },
                new Item() {sku =   "RCSSMH",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "SMALL MH", upc=    "610393012728", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4",  dem2=   "MD HD" },
                new Item() {sku =   "RCSSM",    masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "SMALL M",  upc=    "610393012711", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4",  dem2=   "MD"    },
                new Item() {sku =   "RCSSSM",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "SMALL SM", upc=    "610393012704", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4",  dem2=   "SF MD" },
                new Item() {sku =   "RCSSS",    masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "SMALL S",  upc=    "610393012698", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4",  dem2=   "SF"    },
                new Item() {sku =   "RCSSXS",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "SMALL XS", upc=    "610393012681", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "1/4",  dem2=   "X SF"  },
                new Item() {sku =   "RCSXSH",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "X SMALL H",    upc=    "610393012650", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "3/16", dem2=   "HD"    },
                new Item() {sku =   "RCSXSMH",  masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "X SMALL MH",   upc=    "610393012636", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "3/16", dem2=   "MD HD" },
                new Item() {sku =   "RCSXSM",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "X SMALL M",    upc=    "610393012667", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "3/16", dem2=   "MD"    },
                new Item() {sku =   "RCSXSSM",  masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "X SMALL SM",   upc=    "610393012643", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "3/16", dem2=   "SF MD" },
                new Item() {sku =   "RCSXSS",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "X SMALL S",    upc=    "610393012674", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "3/16", dem2=   "SF"    },
                new Item() {sku =   "RCSXXS",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "X SMALL XS",   upc=    "610393012629", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "3/16", dem2=   "X SF"  },
                new Item() {sku =   "RCSMH",    masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "MEDIUM H", upc=    "610393012797", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "5/16", dem2=   "HD"    },
                new Item() {sku =   "RCSMMH",   masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "MEDIUM MH",    upc=    "610393012780", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "5/16", dem2=   "MD HD" },
                new Item() {sku =   "RCSMM",    masterSku=  "RCSWR",    desc=   "RATTLER CALF PIGGIN STRING ",  desc2=  "MEDIUM M", upc=    "610393012773", brand=  "RATTLER",  code=   "CALFSTRING",   dem1=   "5/16", dem2=   "MD"    },
                new Item() {sku =   "RGBIT18",  masterSku=  "RGBIT18",  desc=   "RICKEY GREEN BIT", desc2=  "SNAFFLE MP",   upc=    "610393080635", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "RGBIT30",  masterSku=  "RGBIT30",  desc=   "RICKEY GREEN BIT", desc2=  "CHAIN MP", upc=    "610393080642", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "RGBIT40",  masterSku=  "RGBIT40",  desc=   "RICKEY GREEN BIT", desc2=  "HIGH PORT MP", upc=    "610393080628", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "RGBIT41",  masterSku=  "RGBIT41",  desc=   "RICKEY GREEN BIT", desc2=  "SHORT SPOON W/ ROLLER MP", upc=    "610393080659", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "RGS3H",    masterSku=  "RGS3", desc=   "RATTLER GOAT STRING",  desc2=  "3 PLY - HARD", upc=    "610393089621", brand=  "RATTLER",  code=   "GOATSTRING",   dem1=   "HD",   dem2=   ""  },
                new Item() {sku =   "RGS3MS",   masterSku=  "RGS3", desc=   "RATTLER GOAT STRING",  desc2=  "3 PLY - MED. SOFT",    upc=    "610393089607", brand=  "RATTLER",  code=   "GOATSTRING",   dem1=   "MD SF",    dem2=   ""  },
                new Item() {sku =   "RGS3M",    masterSku=  "RGS3", desc=   "RATTLER GOAT STRING",  desc2=  "3 PLY - MEDIUM",   upc=    "610393089614", brand=  "RATTLER",  code=   "GOATSTRING",   dem1=   "MD",   dem2=   ""  },
                new Item() {sku =   "RGS3S",    masterSku=  "RGS3", desc=   "RATTLER GOAT STRING",  desc2=  "3 PLY - SOFT", upc=    "610393001913", brand=  "RATTLER",  code=   "GOATSTRING",   dem1=   "SF",   dem2=   ""  },
                new Item() {sku =   "RGSTUBEBL",    masterSku=  "RGSTUBE",  desc=   "RATTLER GOAT STRING TUBE", desc2=  "BLUE", upc=    "610393096339", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "BLUE", dem2=   ""  },
                new Item() {sku =   "RGSTUBEGR",    masterSku=  "RGSTUBE",  desc=   "RATTLER GOAT STRING TUBE", desc2=  "GREEN",    upc=    "610393096322", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "RGSTUBEPK",    masterSku=  "RGSTUBE",  desc=   "RATTLER GOAT STRING TUBE", desc2=  "PINK", upc=    "610393096315", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "RGSTUBEPR",    masterSku=  "RGSTUBE",  desc=   "RATTLER GOAT STRING TUBE", desc2=  "PURPLE",   upc=    "610393096308", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "PURPLE",   dem2=   ""  },
                new Item() {sku =   "RK4POLY",  masterSku=  "RK4POLY",  desc=   "RATTLER KID ROPE 4 STRAND POLY",   desc2=  "7.5 26'",  upc=    "610393105017", brand=  "RATTLER",  code=   "RKIDROPES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RM",   masterSku=  "RM",   desc=   "RINGMASTER CINCH PROTECT", desc2=  "", upc=    "804381000266", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "RMF",  masterSku=  "RMF",  desc=   "RINGMASTER FLEECE",    desc2=  "", upc=    "804381020202", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "ROPECAN",  masterSku=  "ROPECAN",  desc=   "RATTLER ROPE CAN BLACK",   desc2=  "", upc=    "610393082066", brand=  "RATTLER",  code=   "RROPECAN", dem1=   "", dem2=   ""  },
                new Item() {sku =   "ROPEHOB",  masterSku=  "ROPEHOB",  desc=   "ROPE HOBBLE - RH BUTTON",  desc2=  "", upc=    "610393074313", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "ROPEPWD",  masterSku=  "ROPEPWD",  desc=   "ROPER SPORTS POWDER",  desc2=  "", upc=    "610393005621", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR12BH",   masterSku=  "RR12BH",   desc=   "ROPING REIN 1/2 HARNESS",  desc2=  "", upc=    "610393072104", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR12CHB",  masterSku=  "RR12CHB",  desc=   "ROPING REINS 1/2", desc2=  "CHOCOLATE HARNESS RH BRAID",   upc=    "610393071503", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR12L",    masterSku=  "RR12L",    desc=   "ROPING REIN 1/2 LATIGO",   desc2=  "", upc=    "610393001425", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR34B5L",  masterSku=  "RR34B5L",  desc=   "ROPING REIN 3/4 ", desc2=  "5 PLAIT LATIGO",   upc=    "610393001449", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR3RFB",   masterSku=  "RR3RFB",   desc=   "ROPING REIN 3 STRAND ROPE",    desc2=  "FLAT BRAID DOUBLE SNAPS",  upc=    "610393078892", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58B3L",  masterSku=  "RR58B3L",  desc=   "ROPING REIN 5/8 ", desc2=  "3 PLAIT LATIGO",   upc=    "610393001463", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58BH",   masterSku=  "RR58BH",   desc=   "ROPING REIN 5/8 HARNESS",  desc2=  "", upc=    "610393072111", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58BIO",  masterSku=  "RR58BIO",  desc=   "5/8 BIO NATURAL ROPE REIN",    desc2=  "BIOTHANE ONE SNAP",    upc=    "610393100029", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58BIO2", masterSku=  "RR58BIO2", desc=   "5/8 BIO BROWN ROPING REIN",    desc2=  "BIOTHANE 2 SNAPS", upc=    "610393103808", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58HDB",  masterSku=  "RR58HDB",  desc=   "ROPING REIN 5/8 HARNESS",  desc2=  "DBL BUCKLE",   upc=    "610393088242", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58HQB",  masterSku=  "RR58HQB",  desc=   "ROPING REIN 5/8 HARNESS",  desc2=  "QC BUTTON KNOT",   upc=    "610393081519", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR58BHR",  masterSku=  "RR58HRHR", desc=   "ROPING REIN 5/8",  desc2=  "ROUND SEWN HARNESS",   upc=    "610393072050", brand=  "MARTIN",   code=   "REINS",    dem1=   "HARNESS",  dem2=   ""  },
                new Item() {sku =   "RR58L",    masterSku=  "RR58L",    desc=   "ROPING REIN 5/8 LATIGO",   desc2=  "", upc=    "610393001517", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RR78B5L",  masterSku=  "RR78B5L",  desc=   "ROPING REIN 7/8 ", desc2=  "5 PLAIT LATIGO",   upc=    "610393001524", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "RRR 330MS",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 30' MS", desc2=  "", upc=    "610393013602", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "RRR 330 S",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 30' S",  desc2=  "", upc=    "610393072449", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "RRR 330XS",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 30' XS", desc2=  "", upc=    "610393072456", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "RRR 3302X",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 30' XXS",    desc2=  "", upc=    "610393072432", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "RRR 335HM",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 35' HM", desc2=  "", upc=    "610393072487", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "RRR 335 M",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 35' M",  desc2=  "", upc=    "610393072470", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "RRR 335MS",    masterSku=  "RRR",  desc=   "RATTLER RADAR 3/8 35' MS", desc2=  "", upc=    "610393072500", brand=  "RATTLER",  code=   "R4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "RSEC12P",  masterSku=  "RSEC12P",  desc=   "ROPE STRAP ELASTIC CLASSIC",   desc2=  "12 PACK",  upc=    "610393093970", brand=  "CLASSIC",  code=   "CACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "RSER12P",  masterSku=  "RSER12P",  desc=   "ROPE STRAP ELASTIC RATTLER",   desc2=  "12 PACK",  upc=    "610393093987", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "RSLB", masterSku=  "RSLB", desc=   "ROPE STRAP W/ BUTTON KNOT",    desc2=  "", upc=    "610393081502", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "RSS25FSM", masterSku=  "RSS",  desc=   "2-STRAND STEER STRING ",   desc2=  "5/16 FULL S MED",  upc=    "610393009056", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16 FULL",    dem2=   "SF MD" },
                new Item() {sku =   "RSS5FSM",  masterSku=  "RSS",  desc=   "RATTLER STEER STRING ",    desc2=  "5/16 FULL SM", upc=    "610393012865", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16 FULL",    dem2=   "SF MD" },
                new Item() {sku =   "RSS5FS",   masterSku=  "RSS",  desc=   "RATTLER STEER STRING ",    desc2=  "5/16 FULL S",  upc=    "610393012858", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16 FULL",    dem2=   "SF"    },
                new Item() {sku =   "RSS25FS",  masterSku=  "RSS",  desc=   "2-STRAND STEER STRING ",   desc2=  "5/16 FULL SOFT",   upc=    "610393009049", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16 FULL",    dem2=   "SF"    },
                new Item() {sku =   "RSS25TSM", masterSku=  "RSS",  desc=   "2-STRAND STEER STRING ",   desc2=  "5/16 SOFT MED",    upc=    "610393009018", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16", dem2=   "SF MD" },
                new Item() {sku =   "RSS5SM",   masterSku=  "RSS",  desc=   "RATTLER STEER STRING 5/16 SM", desc2=  "", upc=    "610393012827", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16", dem2=   "SF MD" },
                new Item() {sku =   "RSS25TS",  masterSku=  "RSS",  desc=   "2-STRAND STEER STRING ",   desc2=  "5/16 SOFT",    upc=    "610393009001", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16", dem2=   "SF"    },
                new Item() {sku =   "RSS5S",    masterSku=  "RSS",  desc=   "RATTLER STEER STRING 5/16 S",  desc2=  "", upc=    "610393012810", brand=  "RATTLER",  code=   "STEERSTRNG",   dem1=   "5/16", dem2=   "SF"    },
                new Item() {sku =   "RW-H", masterSku=  "RW-H", desc=   "RUMP WARMER HORSE",    desc2=  "", upc=    "804381023272", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "RXSH-1/0-M",   masterSku=  "RXSH-",    desc=   "RACE EXERCISE SHAPED 1",   desc2=  "", upc=    "804381005568", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "1",    dem2=   ""  },
                new Item() {sku =   "RXSH-1/2-M",   masterSku=  "RXSH-",    desc=   "RACE EXERCISE SHAPED 1/2", desc2=  "", upc=    "804381005520", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "1/2",  dem2=   ""  },
                new Item() {sku =   "RXSH-3/4-M",   masterSku=  "RXSH-",    desc=   "RACE EXERCISE SHAPED 3/4", desc2=  "", upc=    "804381005544", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "3/4",  dem2=   ""  },
                new Item() {sku =   "SA-BC162CH",   masterSku=  "SA-BC162CH",   desc=   "BC 2016 2",    desc2=  "CHOCOLATE",    upc=    "804381030850", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-BR-BLA",    masterSku=  "SA-BR",    desc=   "BIOTHANE REINS BLACK 9'",  desc2=  "5/8",  upc=    "804381026167", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SA-BR-BRN",    masterSku=  "SA-BR",    desc=   "BIOTHENE REINS BROWN 9'",  desc2=  "5/8",  upc=    "804381026174", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SA-BR-NAT",    masterSku=  "SA-BR",    desc=   "BIOTHANE REINS NATURAL 9'",    desc2=  "5/8",  upc=    "804381029731", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "NATURAL",  dem2=   ""  },
                new Item() {sku =   "SA-BC152CHBS", masterSku=  "SA-CBSKT", desc=   "BC 2015 2",    desc2=  "CHOCOLATE BASKETSTAMP",    upc=    "804381028864", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREAST COLLAR",    dem2=   ""  },
                new Item() {sku =   "SA-HB15CHBS",  masterSku=  "SA-CBSKT", desc=   "HS BROWBAND 2015", desc2=  "CHOCOLATE BASKETSTAMP",    upc=    "804381028901", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEAD STALL",   dem2=   ""  },
                new Item() {sku =   "SA-CDSTRING",  masterSku=  "SA-CDSTRING",  desc=   "CASHEL CLIP & DEE STRING SET", desc2=  "", upc=    "804381022503", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-BC152CSBS", masterSku=  "SA-CHBSKT",    desc=   "BC 2015 2",    desc2=  "CHESTNUT BASKET",  upc=    "804381028888", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREAST COLLAR",    dem2=   ""  },
                new Item() {sku =   "SA-HB15CSBS",  masterSku=  "SA-CHBSKT",    desc=   "HS BROWBAND 2015", desc2=  "CHESTNUT BASKET",  upc=    "804381028925", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEAD STALL",   dem2=   ""  },
                new Item() {sku =   "SA-BC152CSBW", masterSku=  "SA-CHEBWR",    desc=   "BC 2015 2",    desc2=  "CHESTNUT BARBWIRE",    upc=    "804381028895", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREAST COLLAR",    dem2=   ""  },
                new Item() {sku =   "SA-CKBR-12",   masterSku=  "SA-CKBR",  desc=   "COWBOY KID BARREL RACER",  desc2=  "12",   upc=    "804381029786", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "12",   dem2=   ""  },
                new Item() {sku =   "SA-CKCU-12",   masterSku=  "SA-CKCU-12",   desc=   "COWBOY KID CUTTER",    desc2=  "12",   upc=    "804381029779", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-CKRA-12",   masterSku=  "SA-CKRA",  desc=   "COWBOY KID RANCHER",   desc2=  "12",   upc=    "804381029762", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "12",   dem2=   ""  },
                new Item() {sku =   "SA-CKWA-12",   masterSku=  "SA-CKWA-12",   desc=   "COWBOY KID WADE",  desc2=  "12",   upc=    "804381029748", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-CO15",  masterSku=  "SA-CO",    desc=   "CASHEL OUTFITTER SADDLE 15",   desc2=  "RUNNING S BORDER*",    upc=    "804381019596", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "15",   dem2=   ""  },
                new Item() {sku =   "SA-CO16",  masterSku=  "SA-CO",    desc=   "CASHEL OUTFITTER SADDLE 16",   desc2=  "RUNNING S BORDER", upc=    "804381019602", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "16",   dem2=   ""  },
                new Item() {sku =   "SA-CO17",  masterSku=  "SA-CO",    desc=   "CASHEL OUTFITTER SADDLE 17",   desc2=  "RUNNING S BORDER", upc=    "804381019619", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "17",   dem2=   ""  },
                new Item() {sku =   "SA-COBC",  masterSku=  "SA-COUT",  desc=   "CASHEL OUTFITTER BREAST COLLAR",   desc2=  "2 RUNNING S TOOL", upc=    "804381019664", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREASTCOLLAR", dem2=   ""  },
                new Item() {sku =   "SA-COHS",  masterSku=  "SA-COUT",  desc=   "CASHEL OUTFITTER HEADSTALL",   desc2=  "RUNNING S TOOL",   upc=    "804381019671", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEADSTALL",    dem2=   ""  },
                new Item() {sku =   "SA-COSR",  masterSku=  "SA-COUT",  desc=   "CASHEL OUTFITTER SPLIT REINS", desc2=  "RUNNING S TOOL",   upc=    "804381019688", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SPLIT REIN",   dem2=   ""  },
                new Item() {sku =   "SA-CKRO-12",   masterSku=  "SA-CRRO",  desc=   "COWBOY KID ROPER", desc2=  "12",   upc=    "804381029755", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "12",   dem2=   ""  },
                new Item() {sku =   "SA-CT15",  masterSku=  "SA-CT",    desc=   "CASHEL TRAIL SADDLE 15",   desc2=  "DIAMOND BORDER",   upc=    "804381014324", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "15",   dem2=   ""  },
                new Item() {sku =   "SA-CT16",  masterSku=  "SA-CT",    desc=   "CASHEL TRAIL SADDLE 16",   desc2=  "DIAMOND BORDER",   upc=    "804381014348", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "16",   dem2=   ""  },
                new Item() {sku =   "SA-CT17",  masterSku=  "SA-CT",    desc=   "CASHEL TRAIL SADDLE 17",   desc2=  "DIAMOND BORDER",   upc=    "804381014362", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "17",   dem2=   ""  },
                new Item() {sku =   "SA-CT15-W",    masterSku=  "SA-CT1",   desc=   "CASHEL TRAIL SADDLE 15 - WIDE",    desc2=  "7 GULLET - DIAMOND BORDER",    upc=    "804381031611", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "15",   dem2=   ""  },
                new Item() {sku =   "SA-CT16-W",    masterSku=  "SA-CT1",   desc=   "CASHEL TRAIL SADDLE 16 - WIDE",    desc2=  "7 GULLET - DIAMOND BORDER*",   upc=    "804381031635", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "16",   dem2=   ""  },
                new Item() {sku =   "SA-CT17-W",    masterSku=  "SA-CT1",   desc=   "CASHEL TRAIL SADDLE 17 - WIDE",    desc2=  "7 GULLET - DIAMOND BORDER*",   upc=    "804381031628", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "17",   dem2=   ""  },
                new Item() {sku =   "SA-CTBC",  masterSku=  "SA-CTRAIL",    desc=   "CASHEL TRAIL 1 CHOC BC",   desc2=  "DIAMOND TOOL", upc=    "804381019695", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREASTCOLLAR", dem2=   ""  },
                new Item() {sku =   "SA-CTFCA", masterSku=  "SA-CTRAIL",    desc=   "CASHEL TRAIL FLK CINCH ASSEMB",    desc2=  "DIAMOND TOOL", upc=    "804381019725", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "FLANK ASMB",   dem2=   ""  },
                new Item() {sku =   "SA-CTHS",  masterSku=  "SA-CTRAIL",    desc=   "CASHEL TRAIL CHOC BB HS",  desc2=  " DIAMOND TOOL",    upc=    "804381019701", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEADSTALL",    dem2=   ""  },
                new Item() {sku =   "SA-CTSR",  masterSku=  "SA-CTRAIL",    desc=   "CASHEL TRAIL 5/8 CHOC SR", desc2=  "DIAMOND TOOL", upc=    "804381019718", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SPLIT REIN",   dem2=   ""  },
                new Item() {sku =   "SA-BC152CHWV", masterSku=  "SA-CWEAVE",    desc=   "BC 2015 2",    desc2=  "CHOCOLATE WEAVE",  upc=    "804381028871", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREAST COLLAR",    dem2=   ""  },
                new Item() {sku =   "SA-HB15CHWV",  masterSku=  "SA-CWEAVE",    desc=   "HS BROWBAND 2015", desc2=  "CHOCOLATE WEAVE",  upc=    "804381028918", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEAD STALL",   dem2=   ""  },
                new Item() {sku =   "SA-DCCL",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR CARD",   desc2=  "LARGE 21", upc=    "804381028833", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "LARGE",    dem2=   "CARD"  },
                new Item() {sku =   "SA-DCDL",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR DIAMOND",    desc2=  "LARGE 21", upc=    "804381028826", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "LARGE",    dem2=   "DIAMOND"   },
                new Item() {sku =   "SA-DCFL",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR FLOWER", desc2=  "LARGE 21", upc=    "804381028796", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "LARGE",    dem2=   "FLOWER"    },
                new Item() {sku =   "SA-DCSL",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SCROLL", desc2=  "LARGE 21", upc=    "804381028710", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "LARGE",    dem2=   "SCROLL"    },
                new Item() {sku =   "SA-DC1L",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SQUARE SCROLL",  desc2=  "LARGE 21", upc=    "804381031031", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "LARGE",    dem2=   "SQUARE SCROLL" },
                new Item() {sku =   "SA-DC1XXL",    masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SQUARE SCROLL",  desc2=  "XXL 25",   upc=    "804381031079", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "LARGE",    dem2=   "SQUARE SCROLL" },
                new Item() {sku =   "SA-DCCM",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR CARD",   desc2=  "MEDIUM 18",    upc=    "804381028840", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "MEDIUM",   dem2=   "CARD"  },
                new Item() {sku =   "SA-DCDM",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR DIAMOND",    desc2=  "MEDIUM 18",    upc=    "804381028819", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "MEDIUM",   dem2=   "DIAMOND"   },
                new Item() {sku =   "SA-DCFM",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR FLOWER", desc2=  "MEDIUM 18 ",   upc=    "804381028789", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "MEDIUM",   dem2=   "FLOWER"    },
                new Item() {sku =   "SA-DCSM",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SCROLL", desc2=  "MEDIUM 18",    upc=    "804381028734", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "MEDIUM",   dem2=   "SCROLL"    },
                new Item() {sku =   "SA-DC1M",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SQUARE SCROLL",  desc2=  "MEDIUM 18",    upc=    "804381031048", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "MEDIUM",   dem2=   "SQUARE SCROLL" },
                new Item() {sku =   "SA-DCCS",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR CARD",   desc2=  "SMALL 15", upc=    "804381028857", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SMALL",    dem2=   "CARD"  },
                new Item() {sku =   "SA-DCDS",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR DIAMOND",    desc2=  "SMALL 15", upc=    "804381028802", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SMALL",    dem2=   "DIAMOND"   },
                new Item() {sku =   "SA-DCFS",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR FLOWER", desc2=  "SMALL 15", upc=    "804381028772", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SMALL",    dem2=   "FLOWER"    },
                new Item() {sku =   "SA-DCSS",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SCROLL", desc2=  "SMALL 15", upc=    "804381028741", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SMALL",    dem2=   "SCROLL"    },
                new Item() {sku =   "SA-DC1S",  masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SQUARE SCROLL",  desc2=  "SMALL 15", upc=    "804381031055", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SMALL",    dem2=   "SQUARE SCROLL" },
                new Item() {sku =   "SA-DCCXL", masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR CARD",   desc2=  "X LARGE 23",   upc=    "804381029540", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "X-LARGE",  dem2=   "CARD"  },
                new Item() {sku =   "SA-DCDXL", masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR DIAMOND",    desc2=  "X LARGE 23",   upc=    "804381029564", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "X-LARGE",  dem2=   "DIAMOND"   },
                new Item() {sku =   "SA-DCFXL", masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR FLOWER", desc2=  "X LARGE 23",   upc=    "804381029595", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "X-LARGE",  dem2=   "FLOWER"    },
                new Item() {sku =   "SA-DCSXL", masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SCROLL", desc2=  "X LARGE 23",   upc=    "804381029625", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "X-LARGE",  dem2=   "SCROLL"    },
                new Item() {sku =   "SA-DC1XL", masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SQUARE SCROLL",  desc2=  "XL 23",    upc=    "804381031062", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "X-LARGE",  dem2=   "SQUARE SCROLL" },
                new Item() {sku =   "SA-DCCXXL",    masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR CARD",   desc2=  "XX LARGE 25",  upc=    "804381029557", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "XX-LARGE", dem2=   "CARD"  },
                new Item() {sku =   "SA-DCDXXL",    masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR DIAMOND",    desc2=  "XX LARGE 25",  upc=    "804381029571", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "XX-LARGE", dem2=   "DIAMOND"   },
                new Item() {sku =   "SA-DCFXXL",    masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR FLOWER", desc2=  "XX LARGE 25",  upc=    "804381029588", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "XX-LARGE", dem2=   "FLOWER"    },
                new Item() {sku =   "SA-DCSXXL",    masterSku=  "SA-DC",    desc=   "CASHEL DOG COLLAR SCROLL", desc2=  "XX LARGE 25",  upc=    "804381029632", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "XX-LARGE", dem2=   "SCROLL"    },
                new Item() {sku =   "SADDLECBAG",   masterSku=  "SADDLECBAG",   desc=   "SADDLE CARRYING BAG",  desc2=  "", upc=    "610393097299", brand=  "MARTIN",   code=   "OTHER",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-FCA",   masterSku=  "SA-FCA",   desc=   "CASHEL FLANK CINCH PLAIN ASSEMBLY",    desc2=  " ",    upc=    "804381028703", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-BC152GATOR",    masterSku=  "SA-GPRINT",    desc=   "BC 2015 2",    desc2=  "GATOR PRINT",  upc=    "804381028956", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREAST COLLAR",    dem2=   ""  },
                new Item() {sku =   "SA-HB15GATOR", masterSku=  "SA-GPRINT",    desc=   "HS BROWBAND 2015", desc2=  "GATOR PRINT",  upc=    "804381028949", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEAD STALL",   dem2=   ""  },
                new Item() {sku =   "SA-HB15CSBW",  masterSku=  "SA-HB15CSBW",  desc=   "HS BROWBAND 2015", desc2=  "CHESTNUT BARBWIRE",    upc=    "804381028932", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB15RB",    masterSku=  "SA-HB15RB",    desc=   "HS BROWBAND 2015", desc2=  "RAWHIDE BROWBAND", upc=    "804381029410", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB15RT",    masterSku=  "SA-HB15RT",    desc=   "HS BROWBAND 2015", desc2=  "RAWHIDE TRIM", upc=    "804381029427", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB15RTBR",  masterSku=  "SA-HB15RTBR",  desc=   "HS BROWBAND 2015", desc2=  "RAWHIDE TRIM BROWN INLAID",    upc=    "804381029434", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16BK",    masterSku=  "SA-HB16BK",    desc=   "HS BROWBAND 2016", desc2=  "BLACK",    upc=    "610393103631", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHAD",  masterSku=  "SA-HB16CHAD",  desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE ANTIQUE DOTS",   upc=    "804381030874", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHBW",  masterSku=  "SA-HB16CHBW",  desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE BARBWIRE",   upc=    "804381030904", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHFL",  masterSku=  "SA-HB16CHFL",  desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE FLORAL", upc=    "804381030881", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHSC",  masterSku=  "SA-HB16CHSC",  desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE SHIELDS",    upc=    "804381030911", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHSD",  masterSku=  "SA-HB16CHSD",  desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE SILVER DOTS",    upc=    "610393103648", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHSWV", masterSku=  "SA-HB16CHSWV", desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE SMALL WEAVE",    upc=    "804381030867", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16CHVS",  masterSku=  "SA-HB16CHVS",  desc=   "HS BROWBAND 2016", desc2=  "CHOCOLATE V STAMP",    upc=    "804381030898", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16H", masterSku=  "SA-HB16H", desc=   "HS BROWBAND 2016", desc2=  "HARNESS",  upc=    "804381029991", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HB16HLL",   masterSku=  "SA-HB16HLL",   desc=   "HS BROWBAND 2016", desc2=  "HARNESS LATIGO LINED", upc=    "804381029984", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HBCB",  masterSku=  "SA-HBCB",  desc=   "HS BROWBAND CHOCOLATE",    desc2=  "BASKET STAMP [ROWEL BKL]", upc=    "804381028482", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HBCD",  masterSku=  "SA-HBCD",  desc=   "HS BROWBAND CHOCOLATE",    desc2=  "DOTS [CARD BKL]",  upc=    "804381028475", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HBCS",  masterSku=  "SA-HBCS",  desc=   "HS BROWBAND CHOCOLATE",    desc2=  "SNAKE STAMP",  upc=    "804381028468", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HBDRAFT",   masterSku=  "SA-HBDRAFT",   desc=   "HS BROWBAND DRAFT",    desc2=  "SILVER HARDWARE",  upc=    "804381028680", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HBMULE",    masterSku=  "SA-HBMULE",    desc=   "HS BROWBAND MULE", desc2=  "GOLD", upc=    "804381028697", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HF16H", masterSku=  "SA-HF16H", desc=   "HS SLIPEAR 2016",  desc2=  "HARNESS",  upc=    "804381030010", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HFCR",  masterSku=  "SA-HFCR",  desc=   "HS SLIP EAR CHOCOLATE",    desc2=  "RAWHIDE TRIM", upc=    "804381028451", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HI16H", masterSku=  "SA-HI16H", desc=   "HS SPLIT EAR 2016",    desc2=  "HARNESS",  upc=    "804381030003", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HT15RT",    masterSku=  "SA-HT15RT",    desc=   "HS TIEFRONT 2015", desc2=  "RAWHIDE TRIM", upc=    "804381029403", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-HTCAD", masterSku=  "SA-HTCAD", desc=   "HS TIEFRONT CHOCOLATE",    desc2=  "ANTIQUE DOTS", upc=    "804381028567", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SALUM2",   masterSku=  "SALUM2",   desc=   "STIRRUP - 2 ALUMINUM", desc2=  "", upc=    "610393009971", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SALUM2TI", masterSku=  "SALUM2TI", desc=   "TREAD INSERT ONLY ",   desc2=  "2 ALUM STIRRUP 4 1/4", upc=    "715519585909", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SALUM2W",  masterSku=  "SALUM2W",  desc=   "STIRRUP - 2 ALUMINUM WIDE",    desc2=  "", upc=    "610393089638", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SALUM3TI", masterSku=  "SALUM3TI", desc=   "TREAD INSERT ONLY / 3 ALUM",   desc2=  "STIRRUP 4 3/4",    upc=    "610393093338", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-MB-4",  masterSku=  "SA-MB-4",  desc=   "MONEL STIRRUPS BRASS 4",   desc2=  "", upc=    "804381028437", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-BC-CAMO",   masterSku=  "SA-MOCAMO-BC", desc=   "BREAST COLLAR LEATHER - CAMO", desc2=  "", upc=    "804381025122", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "SA-HS/SR-CAMO",    masterSku=  "SA-MOCAMO-HR", desc=   "HEADSTALL & SPLIT REINS CAMO", desc2=  "", upc=    "804381023296", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "SA-NYBIL-BLA", masterSku=  "SA-NYBIL-BLA", desc=   "NYLON BILLET BLACK",   desc2=  "", upc=    "804381012252", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-NYBIL-BRN", masterSku=  "SA-NYBIL-BRN", desc=   "NYLON BILLET BROWN",   desc2=  "", upc=    "804381026396", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-NYLAT-BLA", masterSku=  "SA-NYLAT-BLA", desc=   "NYLON LATIGO BLACK",   desc2=  "", upc=    "804381012269", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-NYLAT-BRN", masterSku=  "SA-NYLAT-BRN", desc=   "NYLON LATIGO BROWN",   desc2=  "", upc=    "804381026389", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-QCSRCS",    masterSku=  "SA-QCSR",  desc=   "QUICK CHANGE SPLIT REINS", desc2=  "CHESTNUT", upc=    "804381028963", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CHESTNUT", dem2=   ""  },
                new Item() {sku =   "SA-QCSRCH",    masterSku=  "SA-QCSR",  desc=   "QUICK CHANGE SPLIT REINS", desc2=  "CHOCOLATE",    upc=    "804381028970", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CHOCOLATE",    dem2=   ""  },
                new Item() {sku =   "SA-QCSRCHRBK", masterSku=  "SA-QCSRCHR",   desc=   "QUICK CHANGE SPLIT REINS CHOCOLATE",   desc2=  "RAWHIDE TRIM BLACK",   upc=    "804381030928", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SA-QCSRCHRBL", masterSku=  "SA-QCSRCHR",   desc=   "QUICK CHANGE SPLIT REINS CHOCOLATE",   desc2=  "RAWHIDE TRIM BLUE",    upc=    "804381030935", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BLUE", dem2=   ""  },
                new Item() {sku =   "SA-QCSRCHRGR", masterSku=  "SA-QCSRCHR",   desc=   "QUICK CHANGE SPLIT REINS CHOCOLATE",   desc2=  "RAWHIDE TRIM GREEN",   upc=    "804381030966", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "SA-QCSRCHRPK", masterSku=  "SA-QCSRCHR",   desc=   "QUICK CHANGE SPLIT REINS CHOCOLATE",   desc2=  "RAWHIDE TRIM PINK",    upc=    "804381030942", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "SA-QCSRCHRRD", masterSku=  "SA-QCSRCHR",   desc=   "QUICK CHANGE SPLIT REINS CHOCOLATE",   desc2=  "RAWHIDE TRIM RED", upc=    "804381030959", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "RED",  dem2=   ""  },
                new Item() {sku =   "SA-RA8",   masterSku=  "SA-RA8",   desc=   "8' ADJUSTABLE REINS CHOCOLATE",    desc2=  "", upc=    "804381028444", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SAS3LCC",  masterSku=  "SAS3LCC",  desc=   "CHEST STIRRUP ALUM ANGLED  3", desc2=  "LEATHER COVERED CHST", upc=    "610393094403", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SAS3LCN",  masterSku=  "SAS3LCN",  desc=   "NAT STIRRUP ALUM ANGLED  3",   desc2=  "LEATHER COVERED NATURAL",  upc=    "610393094410", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-SS15CSBW",  masterSku=  "SA-SS15",  desc=   "SPUR STRAP 2015",  desc2=  "CHESTNUT BARBWIRE",    upc=    "804381029014", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CHESTNUT BARBWIRE",    dem2=   ""  },
                new Item() {sku =   "SA-SS15CSBS",  masterSku=  "SA-SS15",  desc=   "SPUR STRAP 2015",  desc2=  "CHESTNUT BASKET",  upc=    "804381029007", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CHESTNUT BASKET",  dem2=   ""  },
                new Item() {sku =   "SA-SS15CHBS",  masterSku=  "SA-SS15",  desc=   "SPUR STRAP 2015",  desc2=  "CHOCOLATE BASKETSTAMP",    upc=    "804381028987", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CHOCOLATE BASKETSTAMP",    dem2=   ""  },
                new Item() {sku =   "SA-SS15CHWV",  masterSku=  "SA-SS15",  desc=   "SPUR STRAP 2015",  desc2=  "CHOCOLATE WEAVE",  upc=    "804381028994", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CHOCOLATE WEAVE",  dem2=   ""  },
                new Item() {sku =   "SA-SS15GATOR", masterSku=  "SA-SS15",  desc=   "SPUR STRAP 2015",  desc2=  "GATOR PRINT",  upc=    "804381029021", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "GATOR PRINT",  dem2=   ""  },
                new Item() {sku =   "SA-SS-2",  masterSku=  "SA-SS-2",  desc=   "SLANTED STIRRUP 2 X 4",    desc2=  "", upc=    "804381026600", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-SS-2E", masterSku=  "SA-SS-2E", desc=   "SLANTED STIRRUP ENGRAVED 2",   desc2=  "", upc=    "804381030423", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-SS-3",  masterSku=  "SA-SS-3",  desc=   "SLANTED STIRRUP 3 X 5.5",  desc2=  "", upc=    "804381026617", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-SSHR-FL",   masterSku=  "SA-SSHR-FL",   desc=   "SEAT SHRINKER FLEECE", desc2=  "", upc=    "804381021988", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SA-COSS",  masterSku=  "SA-SSL-OUTFITTER", desc=   "CASHEL OUTFITTER SPUR STRAPS", desc2=  "RUNNING S TOOL",   upc=    "804381019770", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "OUTFITTER",    dem2=   ""  },
                new Item() {sku =   "SA-TBSS",  masterSku=  "SA-SSL-TRAIL BLAZER",  desc=   "CASHEL TRAILBLAZER CHOC SS",   desc2=  "MINI CAMO TOOL",   upc=    "804381019794", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "TRAIL BLAZER", dem2=   ""  },
                new Item() {sku =   "SA-CTSS",  masterSku=  "SA-SSL-TRAIL", desc=   "CASHEL TRAIL CHOC SS", desc2=  "DIAMOND BORDER",   upc=    "804381019787", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "CASHEL TRAIL", dem2=   ""  },
                new Item() {sku =   "SA-TB15",  masterSku=  "SA-TB",    desc=   "CASHEL TRAILBLAZER SADDLE 15", desc2=  "MINI CAMO BORDER", upc=    "804381019626", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "15",   dem2=   ""  },
                new Item() {sku =   "SA-TB16",  masterSku=  "SA-TB",    desc=   "CASHEL TRAILBLAZER SADDLE 16", desc2=  "MINI CAMO BORDER", upc=    "804381019633", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "16",   dem2=   ""  },
                new Item() {sku =   "SA-TB17",  masterSku=  "SA-TB",    desc=   "CASHEL TRAILBLAZER SADDLE 17", desc2=  "MINI CAMO BORDER*",    upc=    "804381019640", brand=  "CASHEL",   code=   "CSHLSADDLE",   dem1=   "17",   dem2=   ""  },
                new Item() {sku =   "SA-TBBC",  masterSku=  "SA-TBLZ",  desc=   "CASHEL TRAILBLAZER 1 CHOC BC", desc2=  "MINI CAMO TOOL",   upc=    "804381019732", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "BREASTCOLLAR", dem2=   ""  },
                new Item() {sku =   "SA-TBFCA", masterSku=  "SA-TBLZ",  desc=   "CASHEL TRAILBLAZER FC ASM",    desc2=  "MINI CAMO TOOL",   upc=    "804381019763", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "FLANK ASMB",   dem2=   ""  },
                new Item() {sku =   "SA-TBHS",  masterSku=  "SA-TBLZ",  desc=   "CASHEL TRAILBLAZER CHOC BB HS",    desc2=  "MINI CAMO TOOL",   upc=    "804381019749", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "HEADSTALL",    dem2=   ""  },
                new Item() {sku =   "SA-TBSR",  masterSku=  "SA-TBLZ",  desc=   "CASHEL TRAILBLAZER 5/8 CHO SR",    desc2=  "MINI CAMO TOOL",   upc=    "804381019756", brand=  "CASHEL",   code=   "CSHLSTRAP",    dem1=   "SPLIT REIN",   dem2=   ""  },
                new Item() {sku =   "SBB2", masterSku=  "SBB2", desc=   "STIRRUP - NAT 2 BELL BOTTOM",  desc2=  "", upc=    "610393002453", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SBB3", masterSku=  "SBB3", desc=   "STIRRUP - NAT 3 BELL BOTTOM",  desc2=  "", upc=    "610393002293", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-BH-BLA",    masterSku=  "SB-BH",    desc=   "BOTTLE HOLDER - BLACK",    desc2=  "Bottle Not Included",  upc=    "804381021445", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-BH-BRN",    masterSku=  "SB-BH",    desc=   "BOTTLE HOLDER - BROWN",    desc2=  "Bottle Not Included",  upc=    "804381021452", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-BH-CAM",    masterSku=  "SB-BH",    desc=   "BOTTLE HOLDER - CAMO", desc2=  "Bottle Not Included",  upc=    "804381021469", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "SB-BHG-BLA",   masterSku=  "SB-BHG",   desc=   "BOTTLE HOLDER W/GPS CASE", desc2=  "BLACK",    upc=    "804381020653", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-BHG-BRN",   masterSku=  "SB-BHG",   desc=   "BOTTLE HOLDER W/GPS CASE", desc2=  "BROWN",    upc=    "804381020691", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-CNT-BLA",   masterSku=  "SB-CNT",   desc=   "CANTLE BAG  BLACK",    desc2=  "600D", upc=    "804381016540", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-CNT-BRN",   masterSku=  "SB-CNT",   desc=   "CANTLE BAG  BROWN",    desc2=  "600D", upc=    "804381016519", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-DX-BLA-II", masterSku=  "SB-DX-II", desc=   "DELUXE SADDLE BAG BLACK II",   desc2=  "", upc=    "804381019398", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-DX-BRN-II", masterSku=  "SB-DX-II", desc=   "DELUXE SADDLE BAG BROWN II",   desc2=  "", upc=    "804381019824", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-DX-HL-II",  masterSku=  "SB-DX-II", desc=   "DELUXE SADDLE BAG II", desc2=  "HOTLEAF",  upc=    "804381029694", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "SB-EN-RB-S-BLA",   masterSku=  "SB-EN-RB-S-BLA",   desc=   "ENDURANCE SADDLE PACK REAR BAG",   desc2=  "SMALL BLACK",  upc=    "804381028529", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-EN-S-BLA",  masterSku=  "SB-EN-S-BLA",  desc=   "ENGLISH FRONT BAG SMALL BLACK",    desc2=  "600D", upc=    "804381020622", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-EN-S-BRN",  masterSku=  "SB-EN-S-BRN",  desc=   "ENGLISH FRONT BAG SMALL BROWN",    desc2=  "600D", upc=    "804381020646", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-HB-LBBH-BLA",   masterSku=  "SB-HB-LBBH",   desc=   "LUNCH BAG BOTTLE HOLDER",  desc2=  "BLACK",    upc=    "804381025863", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-HB-LBBH-BRN",   masterSku=  "SB-HB-LBBH",   desc=   "LUNCH BAG BOTTLE HOLDER",  desc2=  "BROWN",    upc=    "804381025856", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-HB-LBBH-HL",    masterSku=  "SB-HB-LBBH",   desc=   "LUNCH BAG BOTTLE HOLDER",  desc2=  "HOTLEAF",  upc=    "804381029656", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "SB-HB-M-BLA-II",   masterSku=  "SB-HB-M-II",   desc=   "H B BOTTLE HOLDER/PHONE BLA II",   desc2=  "", upc=    "804381019404", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-HB-M-BRN-II",   masterSku=  "SB-HB-M-II",   desc=   "HB BOTTLE HLDER/PHONE BROWN II",   desc2=  "", upc=    "804381019831", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-HB-M-CAM-II",   masterSku=  "SB-HB-M-II",   desc=   "H B BOTTLE HOLDER/PHNE CAMO II",   desc2=  "", upc=    "804381019541", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "SB-HB-M-HL-II",    masterSku=  "SB-HB-M-II",   desc=   "HB BOTTLE HOLDER/PHONE II",    desc2=  "HOTLEAF",  upc=    "804381029670", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "SB-HB-S-BLA-II",   masterSku=  "SB-HB-S-II",   desc=   "SMALL HORN BAG/PHONE BLACK II",    desc2=  "", upc=    "804381019428", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-HB-S-BRN-II",   masterSku=  "SB-HB-S-II",   desc=   "SMALL HORN BAG/PHONE BROWN II",    desc2=  "", upc=    "804381019848", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-HB-S-CAM-II",   masterSku=  "SB-HB-S-II",   desc=   "SMALL HORN BAG/PHONE CAMO II", desc2=  "", upc=    "804381019435", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "SB-HB-S-HL-II",    masterSku=  "SB-HB-S-II",   desc=   "SMALL HORN BAG/PHONE II",  desc2=  "HOTLEAF",  upc=    "804381029663", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "SB-INS-LRG",   masterSku=  "SB-INS",   desc=   "SADDLE BAG INSERT LARGE",  desc2=  "Fits Large Deluxe Bags",   upc=    "804381019343", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SB-INS-MED",   masterSku=  "SB-INS",   desc=   "SADDLE BAG INSERT MEDIUM", desc2=  "Fits Standard Saddle Bags",    upc=    "804381019800", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SB-INS-SML",   masterSku=  "SB-INS",   desc=   "SADDLE BAG INSERT SMALL",  desc2=  "Fits Medium Horn Bag", upc=    "804381019336", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "SB-LB-BLA",    masterSku=  "SB-LB",    desc=   "SADDLEBAG LUNCH BAG BLACK",    desc2=  "", upc=    "804381024279", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-LB-BRN",    masterSku=  "SB-LB",    desc=   "SADDLEBAG LUNCH BAG BROWN",    desc2=  "", upc=    "804381024286", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-LB-HL", masterSku=  "SB-LB",    desc=   "SADDLE BAG LUNCH BAG", desc2=  "HOTLEAF",  upc=    "804381029649", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOTLEAF",  dem2=   ""  },
                new Item() {sku =   "SB-L-CNTS",    masterSku=  "SB-L-CNTS",    desc=   "LEATHER SHAPED CANTEL BAG",    desc2=  "CSHL-01",  upc=    "804381025887", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-L-HB-M",    masterSku=  "SB-L-HB-M",    desc=   "LEATHER HORN BAG", desc2=  "MEDIUM",   upc=    "804381025894", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-L-HB-S",    masterSku=  "SB-L-HB-S",    desc=   "LEATHER HORN BAG", desc2=  "SMALL",    upc=    "804381025900", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-L-RB-L",    masterSku=  "SB-L-RB-L",    desc=   "LEATHER REAR BAG LARGE",   desc2=  "CSHL-05",  upc=    "804381026044", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-L-RB-M",    masterSku=  "SB-L-RB-M",    desc=   "LEATHER REAR BAG", desc2=  "MEDIUM",   upc=    "804381025917", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SB-RB-M-BLA",  masterSku=  "SB-RB-M",  desc=   "REAR SADDLE BAG MEDIUM",   desc2=  "BLACK",    upc=    "804381020660", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-RB-M-BRN",  masterSku=  "SB-RB-M",  desc=   "REAR SADDLE BAG MEDIUM",   desc2=  "BROWN",    upc=    "804381020677", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-RB-M-HL",   masterSku=  "SB-RB-M",  desc=   "REAR SADDLE BAG MEDIUM",   desc2=  "HOTLEAF",  upc=    "804381029687", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "SB-STD-BLA-II",    masterSku=  "SB-STD-II",    desc=   "SADDLE BAG STANDARD BLACK II", desc2=  "", upc=    "804381019442", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SB-STD-BRN-II",    masterSku=  "SB-STD-II",    desc=   "SADDLE BAG STANDARD BROWN II", desc2=  "", upc=    "804381019855", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SB-STD-CAM-II",    masterSku=  "SB-STD-II",    desc=   "SADDLE BAG STANDARD CAMO II",  desc2=  "", upc=    "804381019459", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "CAMO", dem2=   ""  },
                new Item() {sku =   "SCBPS-BLA",    masterSku=  "SCBPS",    desc=   "PRUNER/SAW COMBO SCABBARD",    desc2=  "BLACK",    upc=    "804381024576", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SCBPS-BRN",    masterSku=  "SCBPS",    desc=   "PRUNER/SAW COMBO SCABBARD",    desc2=  "BROWN",    upc=    "804381024583", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SCBR-BLA", masterSku=  "SCBR-BLA", desc=   "RIFLE SCABBARD BLACK", desc2=  "", upc=    "804381024590", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SCBR-HL",  masterSku=  "SCBR-HL",  desc=   "RIFLE SCABBARD HOT LEAF",  desc2=  "", upc=    "804381030027", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SC-E-M",   masterSku=  "SC-E-M",   desc=   "STIRRUP CUSHION ENGLISH MED",  desc2=  "", upc=    "804381000273", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SCRB-BK",  masterSku=  "SCRB", desc=   "RIFLE STOCK AMMO HOLDER",  desc2=  "BLACK",    upc=    "804381030164", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "SCRB-BR",  masterSku=  "SCRB", desc=   "RIFLE STOCK AMMO HOLDER",  desc2=  "BROWN",    upc=    "804381030171", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BROWN",    dem2=   ""  },
                new Item() {sku =   "SCRB-HL",  masterSku=  "SCRB", desc=   "RIFLE STOCK AMMO HOLDER",  desc2=  "HOTLEAF",  upc=    "804381030188", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "SC-W-L",   masterSku=  "SC-W-L",   desc=   "STIRRUP CUSHION WESTERN LARGE",    desc2=  "", upc=    "804381000303", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SC-W-M",   masterSku=  "SC-W-M",   desc=   "STIRRUP CUSHION WESTERN MEDIUM",   desc2=  "", upc=    "804381000297", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SC-W-XL",  masterSku=  "SC-W-XL",  desc=   "STIRRUP CUSHWESTERN XLARGE",   desc2=  "", upc=    "804381008330", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SDR3", masterSku=  "SDR3", desc=   "STIRRUP - 3 DEEP ROPER",   desc2=  "", upc=    "610393001937", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SDR3X",    masterSku=  "SDR3X",    desc=   "3 EXTRA DR STIRRP NATURAL",    desc2=  "(Rawhide Covered)",    upc=    "610393079370", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SDR4", masterSku=  "SDR4", desc=   "NAT STIRRUP - 4 DEEP ROPER",   desc2=  "", upc=    "610393001180", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SDRW3",    masterSku=  "SDRW3",    desc=   "STIRRUP-EXTRA WIDE OVERSHOE",  desc2=  "DEEP ROPER",   upc=    "610393002514", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SEALUM2",  masterSku=  "SEALUM2",  desc=   "STIRRUP- 2 ENGRAVED ALUMINUM", desc2=  "", upc=    "610393067384", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SEALUM2RT",    masterSku=  "SEALUM2RT",    desc=   "2 ENGRAVED ALUM STIRRUP W/RT", desc2=  "W/RUBBER TREAD",   upc=    "610393067056", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SEALUM3",  masterSku=  "SEALUM3",  desc=   "STIRRUP- 3 ENGRAVED ALUMINUM", desc2=  "", upc=    "610393067377", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SEALUMOB114",  masterSku=  "SEALUMOB114",  desc=   "STIRRUP 1 1/4 OXBOW",  desc2=  "ENGRAVED ALUMINUM",    upc=    "610393075822", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SEFB15",   masterSku=  "SEFB15",   desc=   "STIRRUPS 1 1/2 FLAT BOTTOM",   desc2=  "ENGRAVED ALUMINUM",    upc=    "610393089393", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SFP132",   masterSku=  "SFP132",   desc=   "SENSORFLEX FELT TOP PAD 1",    desc2=  "31X32",    upc=    "610393081304", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SHBIT74",  masterSku=  "SHBIT74",  desc=   "SHOULDER HOLDER BIT",  desc2=  "LOW PORT MP",  upc=    "610393084954", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SHBIT75",  masterSku=  "SHBIT75",  desc=   "SHOULDER HOLDER BIT",  desc2=  "HIGH PORT MP", upc=    "610393084947", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SHINGUARD",    masterSku=  "SHINGUARD",    desc=   "SHINGUARD",    desc2=  "", upc=    "610393047690", brand=  "WEQUINE",  code=   "SHINGUARDS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SHSC", masterSku=  "SHS",  desc=   "STIRRUP HOBBLE SET",   desc2=  "CHESTNUT", upc=    "610393096926", brand=  "MARTIN",   code=   "OTHER",    dem1=   "CHESTNUT", dem2=   ""  },
                new Item() {sku =   "SHSN", masterSku=  "SHS",  desc=   "STIRRUP HOBBLE SET",   desc2=  "NATURAL",  upc=    "610393096933", brand=  "MARTIN",   code=   "OTHER",    dem1=   "NATURAL",  dem2=   ""  },
                new Item() {sku =   "SIDEPULL", masterSku=  "SIDEPULL", desc=   "SIDE PULL",    desc2=  "", upc=    "610393006826", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SLOBBERHL",    masterSku=  "SLOBBER",  desc=   "SLOBBER / HARNESS LARGE",  desc2=  "HEAVY OIL",    upc=    "610393100104", brand=  "MARTIN",   code=   "REINS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SLOBBERL", masterSku=  "SLOBBER",  desc=   "LATIGO SLOBBER",   desc2=  "", upc=    "610393100111", brand=  "MARTIN",   code=   "REINS",    dem1=   "LATIGO",   dem2=   ""  },
                new Item() {sku =   "SLOBBERH", masterSku=  "SLOBBER",  desc=   "SLOBBER STRAPS HARNESS",   desc2=  "", upc=    "610393084732", brand=  "MARTIN",   code=   "REINS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SMART",    masterSku=  "SMART",    desc=   "STRING MARTINGALE",    desc2=  "", upc=    "610393007793", brand=  "MARTIN",   code=   "TRAINING", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SOB1", masterSku=  "SOB1", desc=   "STIRRUP 1 OXBOW",  desc2=  "", upc=    "610393002231", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SOS",  masterSku=  "SOS",  desc=   "STEP-UP STIRRUP IN A BAG", desc2=  "", upc=    "804381026389", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SOS-XL",   masterSku=  "SOS-XL",   desc=   "STEP UP STIRRUP X-LONG 76",    desc2=  "", upc=    "804381023227", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR", masterSku=  "SPUR", desc=   "COMFORT SPUR SMOOTH",  desc2=  "", upc=    "804381011163", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR12MF", masterSku=  "SPUR12F",  desc=   "1/2 BAND LARGE SIZE",  desc2=  "FLOWER DESIGN",    upc=    "610393008844", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SPUR12YF", masterSku=  "SPUR12F",  desc=   "1/2 BAND MEDIUM SIZE", desc2=  "SIZE FLOWER DESIGN",   upc=    "610393022130", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SPUR12MA2",    masterSku=  "SPUR12MA2",    desc=   "1/2 BAND AZTEC W/CONCHO ", desc2=  "GS TRIM AND 1 1/2 NECK",   upc=    "610393047126", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR12YCD",    masterSku=  "SPUR12YCD",    desc=   "1/2 BAND MEDIUM SIZE", desc2=  "CLOVER DOT",   upc=    "610393068411", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR12YSC",    masterSku=  "SPUR12YSC",    desc=   "1/2 BAND SCROLL",  desc2=  "MEDIUM",   upc=    "610393094090", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR1MCB", masterSku=  "SPUR1MCB", desc=   "1 LARGE CLOVER BAR",   desc2=  "", upc=    "610393093949", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR1MSSPS",   masterSku=  "SPUR1MSSPS",   desc=   "SPUR SS PERFORMANCE SERIES",   desc2=  "1 BAND LARGE", upc=    "610393071183", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR34MDD",    masterSku=  "SPUR34MDD",    desc=   "3/4 LARGE DIAMOND DOT",    desc2=  "", upc=    "610393093956", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR34MDS",    masterSku=  "SPUR34MDS",    desc=   "3/4 LARGE DIAMOND SCROLL", desc2=  "", upc=    "610393071640", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR34MS", masterSku=  "SPUR34MS", desc=   "3/4 LARGE SCROLL", desc2=  "", upc=    "610393093963", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR34MSDOT",  masterSku=  "SPUR34SDOT",   desc=   "3/4 BAND LARGE SIZE",  desc2=  "STAR DOT DESIGN",  upc=    "610393068305", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SPUR34YSDOT",  masterSku=  "SPUR34SDOT",   desc=   "3/4 BAND MEDIUM SIZE", desc2=  "STAR DOT DESIGN",  upc=    "610393068312", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SPUR58MD", masterSku=  "SPUR58D",  desc=   "SPUR 5/8 BAND LARGE SIZE", desc2=  "DIAMOND DESIGN",   upc=    "610393070537", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SPUR58YD", masterSku=  "SPUR58D",  desc=   "SPUR 5/8 BAND MEDIUM SIZE",    desc2=  "DIAMOND DESIGN",   upc=    "610393067162", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SPUR58MDC",    masterSku=  "SPUR58DC", desc=   "SPUR 5/8 BAND LARGE SIZE", desc2=  "DIAMOND DESIGN CHUBBY ROWEL",  upc=    "610393084602", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SPUR58YDC",    masterSku=  "SPUR58DC", desc=   "SPUR 5/8 BAND MEDIUM SIZE",    desc2=  "DIAMOND DESIGN CHUBBY ROWEL",  upc=    "610393084619", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SPUR58MSSPS",  masterSku=  "SPUR58YSSPS",  desc=   "SPUR SS PERFORMANCE SERIES",   desc2=  "5/8 BAND LARGE",   upc=    "610393071190", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SPUR58YSSPS",  masterSku=  "SPUR58YSSPS",  desc=   "SPUR SS PERFORMANCE SERIES",   desc2=  "5/8 BAND MEDIUM",  upc=    "610393071206", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SPURMBC",  masterSku=  "SPURBC",   desc=   "SPUR LARGE SIZE BUMPER",   desc2=  "CHUBBY ROWEL", upc=    "610393084596", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SPURYBC",  masterSku=  "SPURBC",   desc=   "SPUR MEDIUM SIZE BUMPER",  desc2=  "CHUBBY ROWEL", upc=    "610393084589", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SPURBSCROLL",  masterSku=  "SPURBSCROLL",  desc=   "BUMPER SPUR",  desc2=  "SCROLL",   upc=    "610393080666", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPURCS101",    masterSku=  "SPURCS101",    desc=   "SPUR COWBOY SERIES 2010",  desc2=  "1 BAND",   upc=    "610393084626", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPURCS101CG",  masterSku=  "SPURCS101CG",  desc=   "SPUR COWBOY SERIES 2010",  desc2=  "1 BAND CHAP GUARD",    upc=    "610393084633", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPURCS1034CG", masterSku=  "SPURCS1034CG", desc=   "SPUR COWBOY SERIES 2010",  desc2=  "3/4 BAND CHAP GUARD",  upc=    "610393084640", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPURCT14", masterSku=  "SPURCT14", desc=   "SPUR CUTTER SERIES",   desc2=  "2014", upc=    "610393095813", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR-E",   masterSku=  "SPUR-E",   desc=   "COMFORT SPUR ENGLISH SMOOTH",  desc2=  "", upc=    "804381027287", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPUR-R",   masterSku=  "SPUR-R",   desc=   "COMFORT SPUR W/ ROWEL",    desc2=  "", upc=    "804381027270", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPURRN14", masterSku=  "SPURRN14", desc=   "SPUR REINER SERIES",   desc2=  "2014", upc=    "610393095820", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPURRP14", masterSku=  "SPURRP14", desc=   "SPUR ROPER SERIES",    desc2=  "2014", upc=    "610393095837", brand=  "WEQUINE",  code=   "SPURS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SPYDR 330MS",  masterSku=  "SPYDR",    desc=   "SPYDR 3/8 30' MS", desc2=  "", upc=    "610393085081", brand=  "CLASSIC",  code=   "C5-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "SPYDR 330 S",  masterSku=  "SPYDR",    desc=   "SPYDR 3/8 30' S",  desc2=  "", upc=    "610393085067", brand=  "CLASSIC",  code=   "C5-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "SPYDR 330XS",  masterSku=  "SPYDR",    desc=   "SPYDR 3/8 30' XS", desc2=  "", upc=    "610393085098", brand=  "CLASSIC",  code=   "C5-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "SPYDR 3302X",  masterSku=  "SPYDR",    desc=   "SPYDR 3/8 30' XXS",    desc2=  "", upc=    "610393085074", brand=  "CLASSIC",  code=   "C5-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "SPYDR 335 M",  masterSku=  "SPYDR",    desc=   "SPYDR 3/8 35' M",  desc2=  "", upc=    "610393085104", brand=  "CLASSIC",  code=   "C5-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "SPYDR 335MS",  masterSku=  "SPYDR",    desc=   "SPYDR 3/8 35' MS", desc2=  "", upc=    "610393085111", brand=  "CLASSIC",  code=   "C5-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "SR12H",    masterSku=  "SR12H",    desc=   "SPLIT REIN 1/2 HARNSS-MED OIL",    desc2=  "", upc=    "610393001555", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SR1MT",    masterSku=  "SR1MT",    desc=   "SR 1' MULE TAPE",  desc2=  "", upc=    "610393091877", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SR34H",    masterSku=  "SR34H",    desc=   "SPLIT REIN 3/4 HARNSS-MED OIL",    desc2=  "", upc=    "610393001579", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SR34LL",   masterSku=  "SR34LL",   desc=   "3/4 LATIGO SPLIT REINS (LOOP)",    desc2=  "", upc=    "610393091228", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SR58H",    masterSku=  "SR58H",    desc=   "SPLIT REIN 5/8 HRNSS -MED OIL",    desc2=  "", upc=    "610393001616", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SR58LL",   masterSku=  "SR58LL",   desc=   "5/8 LATIGO SPLIT REINS (LOOP)",    desc2=  "", upc=    "610393091198", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS34B",    masterSku=  "SS34B",    desc=   "SPUR STRAP",   desc2=  "3/4 SKIRT BUCKAROO BSKTSTAMP", upc=    "610393001722", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS34CROSC",    masterSku=  "SS34CROSC",    desc=   "SS BUCKAROO CHOCOLATE RO", desc2=  "SAN CARLOS",   upc=    "610393091839", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS34CSCB", masterSku=  "SS34CSCB", desc=   "SS BUCKAROO CHOCOLATE",    desc2=  "SAN CARLOS/BASKET",    upc=    "610393091815", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS34NSCB", masterSku=  "SS34NSCB", desc=   "SS BUCKAROO NAT",  desc2=  "SAN CARLOS/BASKET",    upc=    "610393091792", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS34ROSC", masterSku=  "SS34ROSC", desc=   "SS BUCKAROO NAT RO",   desc2=  "SAN CARLOS",   upc=    "610393091822", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS58BHL",  masterSku=  "SS58BHL",  desc=   "SPUR STRAP",   desc2=  "5/8 BROWN HARNESS-RH LACE",    upc=    "610393071565", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSB-BLA-L",    masterSku=  "SSB-BLA",  desc=   "STALL SORE BOOT BLACK LARGE",  desc2=  "", upc=    "804381030386", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SSB-BLA",  masterSku=  "SSB-BLA",  desc=   "STALL SORE BOOT BLACK REGULAR",    desc2=  "", upc=    "804381020400", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "REGULAR",  dem2=   ""  },
                new Item() {sku =   "SSCBHD",   masterSku=  "SSCBHD",   desc=   "SPUR STRAP COWBOY",    desc2=  "BRWN HARNESS DIAMONDS BUCKLES",    upc=    "610393096889", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSCBHS",   masterSku=  "SSCBHS",   desc=   "SPUR STRAP COWBOY",    desc2=  "BRWN HARNESS SPLASH BUCKLES",  upc=    "610393096896", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSC",  masterSku=  "SSCBY",    desc=   "SPUR STRAP - COWBOY",  desc2=  "T20",  upc=    "610393002224", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SSCY", masterSku=  "SSCBY",    desc=   "SPUR STRAP - YOUTH",   desc2=  "", upc=    "610393002286", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "YOUTH",    dem2=   ""  },
                new Item() {sku =   "SSCCHHAS", masterSku=  "SSCCHHAS", desc=   "SPUR STRAP COWBOY",    desc2=  "CHOCOLATE HARNESS ANTIQUE SILVER BKLS",    upc=    "610393104553", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSCHH",    masterSku=  "SSCHH",    desc=   "SPUR STRAP CHISHOLM HARNESS",  desc2=  "", upc=    "610393084787", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSCCROCP", masterSku=  "SSCROCP",  desc=   "SPUR STRAP COWBOY",    desc2=  "CHESTNUT RO COPPER PATINA BKLS",   upc=    "610393104560", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "CHESTNUT RO COPPER PATINA BKLS",   dem2=   ""  },
                new Item() {sku =   "SS-1/0-M", masterSku=  "SSCUSH",   desc=   "SCHOOLING SQUARE 1 24 x 29",   desc2=  "", upc=    "804381005650", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "1 - 24 X 29",  dem2=   ""  },
                new Item() {sku =   "SS-1/2-M", masterSku=  "SSCUSH",   desc=   "SCHOOLING SQUARE 1/2", desc2=  "", upc=    "804381005629", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "1/2",  dem2=   ""  },
                new Item() {sku =   "SS-3/4-M", masterSku=  "SSCUSH",   desc=   "SCHOOLING SQUARE 3/4", desc2=  "", upc=    "804381005643", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "3/4",  dem2=   ""  },
                new Item() {sku =   "SSDWCHMD", masterSku=  "SSDWCHMD", desc=   "SS DOVE WING CHOCOLATE",   desc2=  "MOUNTAIN DAISY",   upc=    "610393103983", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSDWCHRFW",    masterSku=  "SSDWCHRFW",    desc=   "SS DOVE WING CHOC",    desc2=  "ROSE FLOWER WOMENS",   upc=    "610393104591", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSDWRFW",  masterSku=  "SSDWRFW",  desc=   "SS DOVE WING NAT", desc2=  "ROSE FLOWER WOMENS",   upc=    "610393103976", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSDWROBT", masterSku=  "SSDWROBT", desc=   "SS DOVE WING RO",  desc2=  "BORDER TOOLED",    upc=    "610393103969", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSG2-L-BLA",   masterSku=  "SSG2-",    desc=   "SOFT SADDLE G2 LARGE BLACK",   desc2=  "", upc=    "804381027959", brand=  "CASHEL",   code=   "CSHLSFTSDL",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SSG2-M-BLA",   masterSku=  "SSG2-",    desc=   "SOFT SADDLE G2 MEDIUM BLACK",  desc2=  "", upc=    "804381027942", brand=  "CASHEL",   code=   "CSHLSFTSDL",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SSG2-XL-BLA",  masterSku=  "SSG2-",    desc=   "SOFT SADDLE G2 X-LARGE BLACK", desc2=  "", upc=    "804381031017", brand=  "CASHEL",   code=   "CSHLSFTSDL",   dem1=   "XL",   dem2=   ""  },
                new Item() {sku =   "SSHIELD-BLA-ENG",  masterSku=  "SSHIELD-BLA-ENG",  desc=   "SADDLE SHIELD - ENGLISH BLACK",    desc2=  "", upc=    "804381008934", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSHRINKER",    masterSku=  "SSHRINKER",    desc=   "SEAT SHRINKER",    desc2=  "", upc=    "610393010175", brand=  "MARTIN",   code=   "SSHRINKER",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSLAO",    masterSku=  "SSLAO",    desc=   "SPUR STRAP LEAF",  desc2=  "ACORN OAK TOOL",   upc=    "610393082035", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSLK", masterSku=  "SSLAT",    desc=   "SPUR STRAP KID LATIGO",    desc2=  "", upc=    "610393007755", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "KID",  dem2=   ""  },
                new Item() {sku =   "SSLL", masterSku=  "SSLAT",    desc=   "SPUR STRAP LARGE LATIGO",  desc2=  "", upc=    "610393007731", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "SSLM", masterSku=  "SSLAT",    desc=   "SPUR STRAP MEDIUM LATIGO", desc2=  "", upc=    "610393007717", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "SSLS", masterSku=  "SSLAT",    desc=   "SPUR STRAP SMALL LATIGO",  desc2=  "", upc=    "610393007694", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "SSLCB",    masterSku=  "SSLCB",    desc=   "SPUR STRAP LEAF",  desc2=  "MINI CAMO BORDER T20", upc=    "610393082042", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSLCBS",   masterSku=  "SSLCBS",   desc=   "SS LEAF CHST", desc2=  "BASKET STAMP", upc=    "610393100739", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSLCRSB",  masterSku=  "SSLCRSB",  desc=   "SS LEAF CHEST",    desc2=  "RUNNING S BORDER", upc=    "610393100371", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSLR", masterSku=  "SSLR", desc=   "SPUR STRAP LATIGO AND RAWHIDE",    desc2=  "", upc=    "610393007267", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SS-PAD-BLA",   masterSku=  "SS-PAD-BLA",   desc=   "SOFT SADDLE PAD BLACK 2015",   desc2=  "", upc=    "804381030843", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT5RG25SS",   masterSku=  "SSPSBIT5RG25SS",   desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "5 RING GAG TWISTED WIRE MP",   upc=    "610393078762", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT65RG25SS",  masterSku=  "SSPSBIT65RG25SS",  desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "6 1/2 RING GAG TWISTED WIRE",  upc=    "610393078793", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT6SS20", masterSku=  "SSPSBIT6SS20", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "6 STRT SHANK SNAFFLE", upc=    "610393071220", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT6SS61", masterSku=  "SSPSBIT6SS61", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "6 STRT SHANK  SHORT CORRECT",  upc=    "610393071237", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT7SS10", masterSku=  "SSPSBIT7SS10", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "7 STRT SHANK CORRECTION",  upc=    "610393071244", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT7SS20", masterSku=  "SSPSBIT7SS20", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "7 STRT SHANK SNAFFLE", upc=    "610393071251", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT7SS24", masterSku=  "SSPSBIT7SS24", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "7 STRT SHANK FLOATING  SPADE", upc=    "610393071268", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT7SS29", masterSku=  "SSPSBIT7SS29", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "7 STRT SHANK SMOOTH DOGBONE",  upc=    "610393071275", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT7SS30", masterSku=  "SSPSBIT7SS30", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "7 STRT SHANK CHAIN MP",    upc=    "610393078755", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT7SS32", masterSku=  "SSPSBIT7SS32", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "7 STRT SHANK PORTED CHAIN MP", upc=    "610393078748", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT8CS10", masterSku=  "SSPSBIT8CS10", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "8 CALVARY SHANK CORRECTION",   upc=    "610393071282", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSPSBIT8CS43", masterSku=  "SSPSBIT8CS43", desc=   "SS PERFORMANCE SERIES BIT",    desc2=  "8 CALVARY SHANK PORTED",   upc=    "610393071299", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSRCB",    masterSku=  "SSRCB",    desc=   "SS RANCHER  CAMO BORDER",  desc2=  "", upc=    "610393100418", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSRCTW",   masterSku=  "SSRCTW",   desc=   "SS RANCHER CHESTNUT",  desc2=  "TWISTED WIRE TOOLING", upc=    "610393093864", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSRDF",    masterSku=  "SSRDF",    desc=   "SS RANCHER",   desc2=  "DESERT FLOWER",    upc=    "610393100425", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSRWCAF",  masterSku=  "SSRWCAF",  desc=   "SS RW CHESTNUT",   desc2=  "ALPINE FLOWER",    upc=    "610393094595", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSSB", masterSku=  "SSSB", desc=   "SPUR STRAP SQUARE ",   desc2=  "SMALL BASKET STAMP",   upc=    "610393088235", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSSS", masterSku=  "SSSS", desc=   "SPUR STRAP SQUARE SLIDE",  desc2=  "", upc=    "610393096919", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSSV", masterSku=  "SSSV", desc=   "SS SQUARE  NAT",   desc2=  "VINES ANTIQUED",   upc=    "610393100388", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSTCROSC", masterSku=  "SSTCROSC", desc=   "SS TOMBSTONE CHOCOLATE RO",    desc2=  "SANCARLOS",    upc=    "610393091860", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSTCSCB",  masterSku=  "SSTCSCB",  desc=   "SS TOMBSTONE CHOCOLATE",   desc2=  "SAN CARLOS/BASKET",    upc=    "610393091853", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSTNSCB",  masterSku=  "SSTNSCB",  desc=   "SS TOMBSTONE NAT", desc2=  "SAN CARLOS/BASKET",    upc=    "610393091846", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SSTROSC",  masterSku=  "SSTROSC",  desc=   "SS TOMBSTONE NAT RO",  desc2=  "SAN CARLOS",   upc=    "610393091808", brand=  "MARTIN",   code=   "SPURSTRAPS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "STEERHDBK",    masterSku=  "STEERHD",  desc=   "STEER HEAD BLACK", desc2=  "", upc=    "610393096834", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "STEERHDGR",    masterSku=  "STEERHD",  desc=   "STEER HEAD GREEN", desc2=  "", upc=    "610393096858", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "STEERHDPK",    masterSku=  "STEERHD",  desc=   "STEER HEAD PINK",  desc2=  "", upc=    "610393096841", brand=  "RATTLER",  code=   "RACCESS",  dem1=   "PINK", dem2=   ""  },
                new Item() {sku =   "STRIKL10", masterSku=  "STRIKE",   desc=   "STRIKER LEFT HAND 10", desc2=  "", upc=    "610393067452", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10",   dem2=   "STRIKER LEFT"  },
                new Item() {sku =   "STRIKE10", masterSku=  "STRIKE",   desc=   "STRIKER 10",   desc2=  "", upc=    "610393067414", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10",   dem2=   "STRIKER"   },
                new Item() {sku =   "STRIKE1025",   masterSku=  "STRIKE",   desc=   "STRIKER 10.25",    desc2=  "", upc=    "610393068701", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10.25",    dem2=   "STRIKER"   },
                new Item() {sku =   "STRIKL105",    masterSku=  "STRIKE",   desc=   "STRIKER LEFT HAND 10.5",   desc2=  "", upc=    "610393067469", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10.5", dem2=   "STRIKER LEFT"  },
                new Item() {sku =   "STRIKE105",    masterSku=  "STRIKE",   desc=   "STRIKER 10.5", desc2=  "", upc=    "610393067438", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10.5", dem2=   "STRIKER"   },
                new Item() {sku =   "STRIKE107",    masterSku=  "STRIKE",   desc=   "STRIKER 10.7", desc2=  "", upc=    "610393067445", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10.75",    dem2=   "STRIKER"   },
                new Item() {sku =   "STRIKE85", masterSku=  "STRIKE",   desc=   "STRIKER 8.5",  desc2=  "", upc=    "610393094977", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "8.5",  dem2=   "STRIKER"   },
                new Item() {sku =   "STRIKE9",  masterSku=  "STRIKE",   desc=   "STRIKER 9.0",  desc2=  "", upc=    "610393084688", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "9",    dem2=   "STRIKER"   },
                new Item() {sku =   "STRIKE95", masterSku=  "STRIKE",   desc=   "STRIKER 9.5",  desc2=  "", upc=    "610393067421", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "9.5",  dem2=   "STRIKER"   },
                new Item() {sku =   "STROBE",   masterSku=  "STROBE",   desc=   "SAFETY STROBE",    desc2=  "", upc=    "804381009498", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "STSL", masterSku=  "STSL", desc=   "STIRRUP SLIPPER BLACK",    desc2=  "", upc=    "804381000457", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "SV2",  masterSku=  "SV2",  desc=   "STIRRUP - 2 ROPER",    desc2=  "", upc=    "610393001531", brand=  "MARTIN",   code=   "STIRRUPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "SWYE-.75-1.5", masterSku=  "SWYE-.75-1.5", desc=   "ENGLISH SWAYBACK PAD .75-1.5", desc2=  "", upc=    "804381012283", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "SWYG-.75-1.5", masterSku=  "SWYG-.75-1.5", desc=   "WE-SHAPED SWAYBACK PAD.75-1.5",    desc2=  "", upc=    "804381019893", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "SWYW-.75-1.5-M",   masterSku=  "SWYW-.75-1.5", desc=   "WE SWAYBACK PAD.75-1.5 MED",   desc2=  "", upc=    "804381019916", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "28 X 28",  dem2=   ""  },
                new Item() {sku =   "SWYW-.75-1.5-L",   masterSku=  "SWYW-.75-1.5", desc=   "WE SWAYBACK PAD.75-1.5 LARGE", desc2=  "", upc=    "804381019909", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "30 X 30",  dem2=   ""  },
                new Item() {sku =   "SWYW-.75-1.5-XL",  masterSku=  "SWYW-.75-1.5", desc=   "WE SWAYBACK PAD.75-1.5 XL",    desc2=  "", upc=    "804381019930", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "32 X 32",  dem2=   ""  },
                new Item() {sku =   "SWYW-32B", masterSku=  "SWYW-32B", desc=   "SWAYBACK NAVAJO",  desc2=  "32X34 BLACK",  upc=    "804381026662", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "SWYW-32T", masterSku=  "SWYW-32T", desc=   "SWAYBACK NAVAJO",  desc2=  "32X34 TAN",    upc=    "804381026679", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "SWYW-34B", masterSku=  "SWYW-34B", desc=   "SWAYBACK NAVAJO",  desc2=  "34X36 BLACK",  upc=    "804381022336", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "SWYW-34T", masterSku=  "SWYW-34T", desc=   "SWAYBACK NAVAJO",  desc2=  "34X36 TAN",    upc=    "804381022343", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "", dem2=   ""  },
                new Item() {sku =   "TA-CF-L",  masterSku=  "TA-CFEEDER",   desc=   "TRAILER CORNER FEEDER-LARGE",  desc2=  "", upc=    "804381024217", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "TA-CF",    masterSku=  "TA-CFEEDER",   desc=   "TRAILER CORNER FEEDER",    desc2=  "", upc=    "804381024248", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "REGULAR",  dem2=   ""  },
                new Item() {sku =   "TA-HLK",   masterSku=  "TA-HLK",   desc=   "HIGH LINE KIT",    desc2=  "", upc=    "804381027966", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TA-HLS",   masterSku=  "TA-HLS",   desc=   "HIGH LINE SWIVEL", desc2=  "", upc=    "804381028260", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TA-TSC32", masterSku=  "TA-TSC",   desc=   "TRIPLE SHOCK CORD 32", desc2=  "", upc=    "804381025924", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "32",   dem2=   ""  },
                new Item() {sku =   "TA-TSC48", masterSku=  "TA-TSC",   desc=   "TRIPLE SHOCK CORD 48", desc2=  "", upc=    "804381025931", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "48",   dem2=   ""  },
                new Item() {sku =   "TA-TSC60", masterSku=  "TA-TSC",   desc=   "TRIPLE SHOCK CORD 60", desc2=  "", upc=    "804381025948", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "60",   dem2=   ""  },
                new Item() {sku =   "TB-BLA",   masterSku=  "TB",   desc=   "TAIL BAG BLACK",   desc2=  "", upc=    "804381000310", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "TB-BUR",   masterSku=  "TB",   desc=   "TAIL BAG BURGUNDY",    desc2=  "", upc=    "804381000334", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BURGUNDY", dem2=   ""  },
                new Item() {sku =   "TB-GRN",   masterSku=  "TB",   desc=   "TAIL BAG GREEN",   desc2=  "", upc=    "804381000341", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "TB-HL",    masterSku=  "TB",   desc=   "TAIL BAG HOT LEAF",    desc2=  "", upc=    "804381029700", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "HOT LEAF", dem2=   ""  },
                new Item() {sku =   "TB-NAV",   masterSku=  "TB",   desc=   "TAIL BAG NAVY",    desc2=  "", upc=    "804381000327", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "NAVY", dem2=   ""  },
                new Item() {sku =   "TB-RED",   masterSku=  "TB",   desc=   "TAIL BAG RED", desc2=  "", upc=    "804381000358", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "RED",  dem2=   ""  },
                new Item() {sku =   "TBBIT25RG25SS",    masterSku=  "TBBIT25RG25SS",    desc=   "TOOL BOX BIT2 5 RING GAG", desc2=  "TWISTED WIRE MP",  upc=    "610393093932", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT26RG25SS",    masterSku=  "TBBIT26RG25SS",    desc=   "TOOL BOX BIT2 6 1/2 RING GAG", desc2=  "TWISTED WIRE MP",  upc=    "610393093925", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT26SS20",  masterSku=  "TBBIT26SS20",  desc=   "TOOL BOX BIT2 6 STRT SHANK",   desc2=  "SNAFFLE",  upc=    "610393093376", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT26SS61",  masterSku=  "TBBIT26SS61",  desc=   "TOOL BOX BIT2 6 STRT SHANK",   desc2=  "SHORT CORRECTION", upc=    "610393093383", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT27SS10",  masterSku=  "TBBIT27SS10",  desc=   "TOOL BOX BIT2 7 STRT SHANK",   desc2=  "CORRECTION",   upc=    "610393093390", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT27SS20",  masterSku=  "TBBIT27SS20",  desc=   "TOOL BOX BIT2 7 STRT SHANK",   desc2=  "SNAFFLE",  upc=    "610393093406", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT27SS29",  masterSku=  "TBBIT27SS29",  desc=   "TOOL BOX BIT2 7 STRT SHANK",   desc2=  "SMOOTH DOGBONE",   upc=    "610393093420", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT27SS60",  masterSku=  "TBBIT27SS60",  desc=   "TOOL BOX BIT2 7 STRT SHANK",   desc2=  "LOW PORT BARREL MP",   upc=    "610393093918", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT28CS10",  masterSku=  "TBBIT28CS10",  desc=   "TOOL BOX BIT2 8 CALVARY SHANK",    desc2=  "CORRECTION",   upc=    "610393093437", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT28CS70",  masterSku=  "TBBIT28CS70",  desc=   "TOOL BOX BIT2 8 CALVARY SHANK",    desc2=  "SQUARE HINGEPORT MP",  upc=    "610393093901", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT2DR20",   masterSku=  "TBBIT2DR20",   desc=   "TOOL BOX BIT D RING",  desc2=  "SNAFFLE MP",   upc=    "610393097992", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT2DR25",   masterSku=  "TBBIT2DR25",   desc=   "TOOL BOX BIT D RING",  desc2=  "TWISTED WIRE SNAFFLE MP",  upc=    "610393098005", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT4OR20",   masterSku=  "TBBIT4OR20",   desc=   "TOOL BOX BIT 4 O RING",    desc2=  " SNAFFLE", upc=    "610393067612", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBIT4OR25",   masterSku=  "TBBIT4OR25",   desc=   "TOOL BOX BIT 4 O RING",    desc2=  "TWISTED WIRE SNAFFLE", upc=    "610393067605", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TBBITDR20",    masterSku=  "TBBITDR20",    desc=   "TOOL BOX BIT D RING",  desc2=  "SNAFFLE",  upc=    "610393095844", brand=  "WEQUINE",  code=   "BITS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-A", masterSku=  "TC-A", desc=   "AUSTRALIAN TUSH CUSHION 1/2 FO",   desc2=  "", upc=    "804381006435", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-E2",    masterSku=  "TC-E2",    desc=   "ENGLISH TUSH CUSHION 1/2 FOAM",    desc2=  "", upc=    "804381006442", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-E3",    masterSku=  "TC-E3",    desc=   "ENGLISH TUSH CUSHION 3/4 FOAM",    desc2=  "", upc=    "804381011811", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TCFE", masterSku=  "TCFE", desc=   "TUSH CUSH FLEECE/FM ENGLISH",  desc2=  "", upc=    "804381019879", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TCFE-BLA", masterSku=  "TCFE-BLA", desc=   "TC FLEECE/FM ENGLISH BLACK",   desc2=  "", upc=    "804381021391", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TCFWL",    masterSku=  "TCFWL",    desc=   "TUSH CUSH FLEECE/FM WEST LONG",    desc2=  "", upc=    "804381019862", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TCFWL-BLA",    masterSku=  "TCFWL-BLA",    desc=   "TC FLEECE/FM WEST LONG BLACK", desc2=  "", upc=    "804381021407", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TCFWX",    masterSku=  "TCFWX",    desc=   "TUSH CUSH FLEECE/FM WEST LARGE",   desc2=  "16.5 W x 18 L x  .75 thick  ", upc=    "804381019886", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TCFWX-BLA",    masterSku=  "TCFWX-BLA",    desc=   "TCFLEECE/FM WEST LARGE BLACK", desc2=  "16.5 W x 18 L x  .75 thick   ",    upc=    "804381021414", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-W2",    masterSku=  "TC-W2",    desc=   "WESTERN TUSH CUSHION 1/2 FOAM",    desc2=  "", upc=    "804381006473", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-W2L",   masterSku=  "TC-W2L",   desc=   "LONG WESTERN TUSH CUSHION 1/2 ",   desc2=  "", upc=    "804381008835", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-W3",    masterSku=  "TC-W3",    desc=   "WESTERN TUSH CUSHION 3/4 FOAM",    desc2=  "", upc=    "804381011828", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-W3L",   masterSku=  "TC-W3L",   desc=   "LONG WESTERN TUSH CUSHION 3/4 ",   desc2=  "", upc=    "804381015109", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TC-WLUX",  masterSku=  "TC-WLUX",  desc=   "LUXURY WESTERN TUSH CUSHION",  desc2=  "", upc=    "804381009474", brand=  "CASHEL",   code=   "CSHLTHCUSH",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TD1H", masterSku=  "TD1H", desc=   "TIEDOWN - 1 HARNESS LEATHER",  desc2=  "", upc=    "610393002347", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TD34H",    masterSku=  "TD34H",    desc=   "TIEDOWN - 3/4 HARNESS LEATHER",    desc2=  "", upc=    "610393002354", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TDBIO",    masterSku=  "TDBIO",    desc=   "TIEDOWN - BIOTHANE",   desc2=  "", upc=    "610393002361", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TDBIO1C",  masterSku=  "TDBIO1C",  desc=   "TIEDOWN - CAMO BIOTHANE",  desc2=  "", upc=    "610393097640", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TDBIO34",  masterSku=  "TDBIO34",  desc=   "3/4 BIOTHANE TIE DOWN STRAP",  desc2=  "", upc=    "610393048383", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TDHOBB",   masterSku=  "TDHOBB",   desc=   "TIE DOWN HOBBLE W/BUTTON KNOT",    desc2=  "", upc=    "610393081496", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TDO-F",    masterSku=  "TDO-F",    desc=   "TRAILER DOOR-GANIZER FULL DOOR",   desc2=  "", upc=    "804381017349", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TDO-H",    masterSku=  "TDO-H",    desc=   "TRAILER DOOR-GANIZER HALF DOOR",   desc2=  "", upc=    "804381017356", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TJACKETLL",    masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET LADIES",   desc2=  "LARGE",    upc=    "804381029229", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   "LADIES"    },
                new Item() {sku =   "TJACKETML",    masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET MEN'S",    desc2=  "LARGE",    upc=    "804381029267", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   "MEN"   },
                new Item() {sku =   "TJACKETLM",    masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET LADIES",   desc2=  "MEDIUM",   upc=    "804381029236", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   "LADIES"    },
                new Item() {sku =   "TJACKETMM",    masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET MEN'S",    desc2=  "MEDIUM",   upc=    "610393098715", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   "MEN"   },
                new Item() {sku =   "TJACKETLS",    masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET LADIES",   desc2=  "SMALL",    upc=    "804381029243", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   "LADIES"    },
                new Item() {sku =   "TJACKETMS",    masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET MEN'S",    desc2=  "SMALL",    upc=    "804381029274", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   "MEN"   },
                new Item() {sku =   "TJACKETLXL",   masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET LADIES",   desc2=  "X LARGE",  upc=    "804381029250", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X LARGE",  dem2=   "LADIES"    },
                new Item() {sku =   "TJACKETMXL",   masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET MEN'S",    desc2=  "X LARGE",  upc=    "804381029281", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X LARGE",  dem2=   "MEN"   },
                new Item() {sku =   "TJACKETLXS",   masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET LADIES",   desc2=  "X SMALL",  upc=    "804381029212", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X SMALL",  dem2=   "LADIES"    },
                new Item() {sku =   "TJACKETMXXL",  masterSku=  "TJACKET",  desc=   "CASHEL TRAIL JACKET MEN'S",    desc2=  "XX LARGE", upc=    "804381029298", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "XX LARGE", dem2=   "MEN"   },
                new Item() {sku =   "TK-BLA",   masterSku=  "TK-BLA",   desc=   "TRAIL KIT BLACK",  desc2=  "", upc=    "804381008392", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TLHB2004BK",   masterSku=  "TLHB", desc=   "HAY BAG 2004 TOP LOAD BLACK",  desc2=  "", upc=    "610393014968", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "TLHB2015CHBK", masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2015", desc2=  "CHOCOLATE BLACK",  upc=    "610393099477", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CHOCOLATE BLACK",  dem2=   ""  },
                new Item() {sku =   "TLHB2016CT",   masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2016", desc2=  "CHOCOLATE TRIBAL", upc=    "610393102412", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CHOCOLATE TRIBAL", dem2=   ""  },
                new Item() {sku =   "TLHB2016CK",   masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2016", desc2=  "CORAL KNIGHT", upc=    "610393102405", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "TLHB2013FS",   masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2013", desc2=  "FLOWER STRIPES",   upc=    "610393093222", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "FLOWER STRIPES",   dem2=   ""  },
                new Item() {sku =   "TLHB2015NVBB", masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2015", desc2=  "NAVY BLACKBERRY",  upc=    "610393099484", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "NAVY BLACKBERRY",  dem2=   ""  },
                new Item() {sku =   "TLHB2015PDBK", masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2015", desc2=  "PLAID BLACK",  upc=    "610393099491", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLAID BLACK",  dem2=   ""  },
                new Item() {sku =   "TLHB2016PDRD", masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2016", desc2=  "PLAID RED",    upc=    "610393102573", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLAID RED",    dem2=   ""  },
                new Item() {sku =   "TLHB2016PD",   masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2016", desc2=  "PLUM DAZE",    upc=    "610393102429", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLUM DAZE",    dem2=   ""  },
                new Item() {sku =   "TLHB2015S",    masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2015", desc2=  "SERAPE",   upc=    "610393101880", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "SERAPE",   dem2=   ""  },
                new Item() {sku =   "TLHB2015TD",   masterSku=  "TLHB", desc=   "TOPLOAD HAY BAG 2015", desc2=  "TEAL DIAMOND", upc=    "610393101897", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "TS-BLA",   masterSku=  "TSHIELD",  desc=   "TAIL SHIELD BLACK",    desc2=  "", upc=    "804381012412", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "BLACK",    dem2=   ""  },
                new Item() {sku =   "TS-GRN",   masterSku=  "TSHIELD",  desc=   "TAIL SHIELD FOREST GREEN", desc2=  "", upc=    "804381012559", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "GREEN",    dem2=   ""  },
                new Item() {sku =   "TS-PUR",   masterSku=  "TSHIELD",  desc=   "TAIL SHIELD PURPLE",   desc2=  "", upc=    "804381013457", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "PURPLE",   dem2=   ""  },
                new Item() {sku =   "TS-RED",   masterSku=  "TSHIELD",  desc=   "TAIL SHIELD RED",  desc2=  "", upc=    "804381012504", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "RED",  dem2=   ""  },
                new Item() {sku =   "TS-ROY",   masterSku=  "TSHIELD",  desc=   "TAIL SHIELD ROYAL",    desc2=  "", upc=    "804381013464", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "ROYAL BLUE",   dem2=   ""  },
                new Item() {sku =   "TSHIRTCEM6P",  masterSku=  "TSHIRTCEM6P",  desc=   "TEE SHIRT CE MEN", desc2=  "6 PACK",   upc=    "610393094229", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTCEW6P",  masterSku=  "TSHIRTCEW6P",  desc=   "TEE SHIRT CE WOMEN",   desc2=  "6 PACK",   upc=    "610393085760", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTCM6P",   masterSku=  "TSHIRTCM6P",   desc=   "TEE SHIRT CLASSIC MEN",    desc2=  "6 PACK",   upc=    "610393085777", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTCW6P",   masterSku=  "TSHIRTCW6P",   desc=   "TEE SHIRT CLASSIC WOMEN",  desc2=  "6 PACK",   upc=    "610393091020", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTMM6P",   masterSku=  "TSHIRTMM6P",   desc=   "TEE SHIRT MARTIN MEN", desc2=  "6 PACK",   upc=    "610393089874", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTMW6P",   masterSku=  "TSHIRTMW6P",   desc=   "TEE SHIRT MARTIN WOMEN",   desc2=  "6 PACK",   upc=    "610393089881", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTRM6P",   masterSku=  "TSHIRTRM6P",   desc=   "TEE SHIRT RATTLER MEN",    desc2=  "6 PACK",   upc=    "610393089867", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TSHIRTRW6P",   masterSku=  "TSHIRTRW6P",   desc=   "TEE SHIRT RATTLER WOMEN",  desc2=  "6 PACK",   upc=    "610393091037", brand=  "WEQUINE",  code=   "WEARABLES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUG32",    masterSku=  "TUG32",    desc=   "BREAST COLLAR TUG",    desc2=  "1'X32 ADJUSTABLE", upc=    "610393005751", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUG32C",   masterSku=  "TUG32C",   desc=   "BREASTCOLLAR TUG", desc2=  "CHESTNUT 1'X24",   upc=    "610393067575", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUGH24",   masterSku=  "TUGH24",   desc=   "BREAST COLLAR TUG",    desc2=  "HARNESS 3/4x24",   upc=    "610393002378", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUGH32",   masterSku=  "TUGH32",   desc=   "BREAST COLLAR TUG",    desc2=  "HARNESS 1x24", upc=    "610393002385", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUGL24",   masterSku=  "TUGL24",   desc=   "BREAST COLLAR TUG",    desc2=  "LATIGO 3/4x24",    upc=    "610393002392", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUGL32",   masterSku=  "TUGL32",   desc=   "BREAST COLLAR TUG",    desc2=  "LATIGO 1x24",  upc=    "610393002408", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUGS24",   masterSku=  "TUGS24",   desc=   "BREAST COLLAR TUG",    desc2=  "SKIRTING 3/4x24",  upc=    "610393002484", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "TUGS32",   masterSku=  "TUGS32",   desc=   "BREAST COLLAR TUG",    desc2=  "SKIRTING 1x24",    upc=    "610393002491", brand=  "MARTIN",   code=   "BC",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "USC4PW",   masterSku=  "USC4PW",   desc=   "USTRC CAP WOMAN",  desc2=  "4-PACK",   upc=    "610393097251", brand=  "CLASSIC",  code=   "CAPS", dem1=   "", dem2=   ""  },
                new Item() {sku =   "VB",   masterSku=  "VB",   desc=   "CASHEL VELCRO BRUSH",  desc2=  "", upc=    "804381012078", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "", dem2=   ""  },
                new Item() {sku =   "VCINCHS26",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - STRAIGHT 26", desc2=  "", upc=    "610393003740", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "26",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "VCINCHR28",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - ROPER 28",    desc2=  "", upc=    "610393003665", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "ROPER" },
                new Item() {sku =   "VCINCHS28",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - STRAIGHT 28", desc2=  "", upc=    "610393003757", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "28",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "VCINCHR30",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - ROPER 30",    desc2=  "", upc=    "610393014050", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "ROPER" },
                new Item() {sku =   "VCINCHS30",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - STRAIGHT 30", desc2=  "", upc=    "610393003795", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "30",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "VCINCHR32",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - ROPER 32",    desc2=  "", upc=    "610393003672", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "ROPER" },
                new Item() {sku =   "VCINCHS32",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - STRAIGHT 32", desc2=  "", upc=    "610393003801", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "32",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "VCINCHR34",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - ROPER 34",    desc2=  "", upc=    "610393003702", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "ROPER" },
                new Item() {sku =   "VCINCHS34",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - STRAIGHT 34", desc2=  "", upc=    "610393003818", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "34",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "VCINCHR36",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - ROPER 36",    desc2=  "", upc=    "610393003733", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "ROPER" },
                new Item() {sku =   "VCINCHS36",    masterSku=  "VCINCH",   desc=   "NEOPRENE CINCH - STRAIGHT 36", desc2=  "", upc=    "610393003825", brand=  "WEQUINE",  code=   "CINCH",    dem1=   "36",   dem2=   "STRAIGHT"  },
                new Item() {sku =   "VESTBLL",  masterSku=  "VESTB",    desc=   "CASHEL BARN VEST LADIES",  desc2=  "LARGE",    upc=    "804381030683", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   "LADIES"    },
                new Item() {sku =   "VESTBML",  masterSku=  "VESTB",    desc=   "CASHEL BARN VEST MENS",    desc2=  "LARGE",    upc=    "804381030607", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   "MENS"  },
                new Item() {sku =   "VESTBLM",  masterSku=  "VESTB",    desc=   "CASHEL BARN VEST LADIES",  desc2=  "MEDIUM",   upc=    "804381030690", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   "LADIES"    },
                new Item() {sku =   "VESTBMM",  masterSku=  "VESTB",    desc=   "CASHEL BARN VEST MENS",    desc2=  "MEDIUM",   upc=    "804381030614", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   "MENS"  },
                new Item() {sku =   "VESTBLS",  masterSku=  "VESTB",    desc=   "CASHEL BARN VEST LADIES",  desc2=  "SMALL",    upc=    "804381030676", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   "LADIES"    },
                new Item() {sku =   "VESTBMS",  masterSku=  "VESTB",    desc=   "CASHEL BARN VEST MENS",    desc2=  "SMALL",    upc=    "804381030621", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   "MENS"  },
                new Item() {sku =   "VESTBLXL", masterSku=  "VESTB",    desc=   "CASHEL BARN VEST LADIES",  desc2=  "X LARGE",  upc=    "804381030669", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X LARGE",  dem2=   "LADIES"    },
                new Item() {sku =   "VESTBMXL", masterSku=  "VESTB",    desc=   "CASHEL BARN VEST MENS",    desc2=  "X LARGE",  upc=    "804381030638", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X LARGE",  dem2=   "MENS"  },
                new Item() {sku =   "VESTBLXS", masterSku=  "VESTB",    desc=   "CASHEL BARN VEST LADIES",  desc2=  "X SMALL",  upc=    "804381030652", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X SMALL",  dem2=   "LADIES"    },
                new Item() {sku =   "VESTBMXXL",    masterSku=  "VESTB",    desc=   "CASHEL BARN VEST MENS",    desc2=  "XX LARGE", upc=    "804381030645", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "XX LARGE", dem2=   "MENS"  },
                new Item() {sku =   "VESTHLLL", masterSku=  "VESTHLL",  desc=   "CASHEL VEST HOTLEAF LADIES",   desc2=  "LARGE",    upc=    "804381030553", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "LARGE",    dem2=   ""  },
                new Item() {sku =   "VESTHLLM", masterSku=  "VESTHLL",  desc=   "CASHEL VEST HOTLEAF LADIES",   desc2=  "MEDIUM",   upc=    "804381030560", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "MEDIUM",   dem2=   ""  },
                new Item() {sku =   "VESTHLLS", masterSku=  "VESTHLL",  desc=   "CASHEL VEST HOTLEAF LADIES",   desc2=  "SMALL",    upc=    "804381030577", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "SMALL",    dem2=   ""  },
                new Item() {sku =   "VESTHLLXL",    masterSku=  "VESTHLL",  desc=   "CASHEL VEST HOTLEAF LADIES",   desc2=  "X LARGE",  upc=    "804381030584", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X LARGE",  dem2=   ""  },
                new Item() {sku =   "VESTHLLXS",    masterSku=  "VESTHLL",  desc=   "CASHEL VEST HOTLEAF LADIES",   desc2=  "X SMALL",  upc=    "804381030591", brand=  "CASHEL",   code=   "CSHLACCESS",   dem1=   "X SMALL",  dem2=   ""  },
                new Item() {sku =   "VIPER10",  masterSku=  "VIPER",    desc=   "VIPER 10.0",   desc2=  "", upc=    "610393085128", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10",   dem2=   "VIPER" },
                new Item() {sku =   "VIPER1025",    masterSku=  "VIPER",    desc=   "VIPER 10.25",  desc2=  "", upc=    "610393085135", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10.25",    dem2=   "VIPER" },
                new Item() {sku =   "VIPER105", masterSku=  "VIPER",    desc=   "VIPER 10.5",   desc2=  "", upc=    "610393085142", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "10.5", dem2=   "VIPER" },
                new Item() {sku =   "VIPER9",   masterSku=  "VIPER",    desc=   "VIPER 9.0",    desc2=  "", upc=    "610393085159", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "9",    dem2=   "VIPER" },
                new Item() {sku =   "VIPER95",  masterSku=  "VIPER",    desc=   "VIPER 9.5",    desc2=  "", upc=    "610393085166", brand=  "RATTLER",  code=   "CALFROPES",    dem1=   "9.5",  dem2=   "VIPER" },
                new Item() {sku =   "WALT 204", masterSku=  "WALT 204", desc=   "W 204 - BRAIDED NOSE BAND",    desc2=  "", upc=    "610393066684", brand=  "MARTIN",   code=   "NOSEBANDS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WD16CK",   masterSku=  "WD1",  desc=   "WEEKENDER DUFFEL 16",  desc2=  "CORAL KNIGHT", upc=    "610393102702", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "CORAL KNIGHT", dem2=   ""  },
                new Item() {sku =   "WD15HL",   masterSku=  "WD1",  desc=   "WEEKENDER DUFFEL 15",  desc2=  "HOTLEAF",  upc=    "610393102283", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "HOTLEAF",  dem2=   ""  },
                new Item() {sku =   "WD15PDBK", masterSku=  "WD1",  desc=   "WEEKEND DUFFEL 15",    desc2=  "PLAID BLACK",  upc=    "610393099927", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "PLAID BLACK",  dem2=   ""  },
                new Item() {sku =   "WD16TD",   masterSku=  "WD1",  desc=   "WEEKENDER DUFFEL 16",  desc2=  "TEAL DIAMOND", upc=    "610393102696", brand=  "WEQUINE",  code=   "WEACCESS", dem1=   "TEAL DIAMOND", dem2=   ""  },
                new Item() {sku =   "WE-1/0-L", masterSku=  "WE-",  desc=   "WESTERN 1 L",  desc2=  "", upc=    "804381005902", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "1" },
                new Item() {sku =   "WE-3/4-L", masterSku=  "WE-",  desc=   "WESTERN 3/4 L",    desc2=  "", upc=    "804381005872", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "LARGE",    dem2=   "3/4"   },
                new Item() {sku =   "WE-3/4-M", masterSku=  "WE-",  desc=   "WESTERN 3/4 M",    desc2=  "", upc=    "804381005865", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "MEDIUM",   dem2=   "3/4"   },
                new Item() {sku =   "WE-1/0-XL",    masterSku=  "WE-",  desc=   "WESTERN 1 XL", desc2=  "", upc=    "804381005919", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "X-LARGE",  dem2=   "1" },
                new Item() {sku =   "WE-3/4-XL",    masterSku=  "WE-",  desc=   "WESTERN 3/4 XL",   desc2=  "", upc=    "804381005889", brand=  "CASHEL",   code=   "CSHLPAD",  dem1=   "X-LARGE",  dem2=   "3/4"   },
                new Item() {sku =   "WFP130",   masterSku=  "WFP130",   desc=   "BIOFIT CORRECTION PAD 7/8",    desc2=  "30X30",    upc=    "610393079790", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WFP132",   masterSku=  "WFP132",   desc=   "BIOFIT CORRECTION PAD 7/8",    desc2=  "31X32",    upc=    "610393079769", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WFP2132",  masterSku=  "WFP2132",  desc=   "BIOFIT CORRECTION PAD FLEECE", desc2=  "1 31X32",  upc=    "610393089294", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WFS30",    masterSku=  "WFS30",    desc=   "BIOFIT SHIM PAD",  desc2=  "30X32",    upc=    "610393096735", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WFS32",    masterSku=  "WFS32",    desc=   "BIOFIT SHIM PAD",  desc2=  "31X32",    upc=    "610393096742", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WFSF32",   masterSku=  "WFSF32",   desc=   "BIOFIT SHIM PAD FLEECE",   desc2=  "31X32",    upc=    "610393099941", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WRR12BH",  masterSku=  "WRR12BH",  desc=   "WALT  ROPING REIN 1/2",    desc2=  "HARNESS",  upc=    "610393072067", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "WRR58BH",  masterSku=  "WRR58BH",  desc=   "WALT 5/8 ROPING REIN", desc2=  "HARNESS",  upc=    "610393072074", brand=  "MARTIN",   code=   "REINS",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "XKR41425XS",   masterSku=  "XKR41425XS",   desc=   "XTREME KID ROPE 4 STRAND", desc2=  "1/4 25' XS ASSORTED COLORS",   upc=    "610393005805", brand=  "CLASSIC",  code=   "CKIDROPES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "CLS10BXL", masterSku=  "X-LARGE LEGACY SYSTEM LEG BOOTS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLK XL FRONT", upc=    "610393009391", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "FRONT X-LARGE" },
                new Item() {sku =   "CLS20BXL", masterSku=  "X-LARGE LEGACY SYSTEM LEG BOOTS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "BLACK XL HIND",    upc=    "610393009469", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "BLACK",    dem2=   "HIND X-LARGE"  },
                new Item() {sku =   "CLS10WXL", masterSku=  "X-LARGE LEGACY SYSTEM LEG BOOTS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHITE XL FRONT",   upc=    "610393009445", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "FRONT X-LARGE" },
                new Item() {sku =   "CLS20WXL", masterSku=  "X-LARGE LEGACY SYSTEM LEG BOOTS",  desc=   "CLASSIC LEGACY SYSTEM ",   desc2=  "WHITE XL HIND",    upc=    "610393009513", brand=  "WEQUINE",  code=   "LEGBOOTS", dem1=   "WHITE",    dem2=   "HIND X-LARGE"  },
                new Item() {sku =   "XR4 330MS",    masterSku=  "XR4",  desc=   "XR4 3/8 30' MS",   desc2=  "", upc=    "610393008578", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "XR4 330 S",    masterSku=  "XR4",  desc=   "XR4 3/8 30' S",    desc2=  "", upc=    "610393008547", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "XR4 330XS",    masterSku=  "XR4",  desc=   "XR4 3/8 30' XS",   desc2=  "", upc=    "610393008554", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "XR4 3302X",    masterSku=  "XR4",  desc=   "XR4 3/8 30' XXS",  desc2=  "", upc=    "610393010397", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "XR4 335HM",    masterSku=  "XR4",  desc=   "XR4 3/8 35' HM",   desc2=  "", upc=    "610393008608", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "XR4 335 M",    masterSku=  "XR4",  desc=   "XR4 3/8 35' M",    desc2=  "", upc=    "610393008592", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "XR4 335MH",    masterSku=  "XR4",  desc=   "XR4 3/8 35' MH",   desc2=  "", upc=    "610393008615", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "XR4 335MS",    masterSku=  "XR4",  desc=   "XR4 3/8 35' MS",   desc2=  "", upc=    "610393008585", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "XR4S330MS",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 30' MS",  desc2=  "", upc=    "610393005928", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "MS"    },
                new Item() {sku =   "XR4S330 S",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 30' S",   desc2=  "", upc=    "610393005911", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "S" },
                new Item() {sku =   "XR4S330XS",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 30' XS",  desc2=  "", upc=    "610393005935", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XS"    },
                new Item() {sku =   "XR4S3302X",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 30' XXS", desc2=  "", upc=    "610393009926", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "30",   dem2=   "XXS"   },
                new Item() {sku =   "XR4S335HM",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 35'HM",   desc2=  "", upc=    "610393011912", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "HM"    },
                new Item() {sku =   "XR4S335 M",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 35' MED", desc2=  "", upc=    "610393011905", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "M" },
                new Item() {sku =   "XR4S335MH",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 35' MH",  desc2=  "", upc=    "610393011929", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MH"    },
                new Item() {sku =   "XR4S335MS",    masterSku=  "XR4S", desc=   "XR4 LITE 3/8 35' MS",  desc2=  "", upc=    "610393011899", brand=  "CLASSIC",  code=   "C4-STRAND",    dem1=   "35",   dem2=   "MS"    },
                new Item() {sku =   "ZBT3416-1CFBK",    masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 34X38 1",  desc2=  "COFFEE BLACK", upc=    "610393104164", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "COFFEE BLACK", dem2=   "34X38 1"   },
                new Item() {sku =   "ZBT3416CFBK",  masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 34X38 3/4",    desc2=  "COFFEE BLACK", upc=    "610393104096", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "COFFEE BLACK", dem2=   "34X38 3/4" },
                new Item() {sku =   "ZBT3216CFTL",  masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 32X34 3/4",    desc2=  "COFFEE TEAL",  upc=    "610393104126", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "COFFEE TEAL",  dem2=   "32X34 3/4" },
                new Item() {sku =   "ZBT3216CRCH",  masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 32X34 3/4",    desc2=  "CREAM CHOCOLATE",  upc=    "610393104133", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "CREAM CHOCOLATE",  dem2=   "32X34 3/4" },
                new Item() {sku =   "ZBT3416-1NVTN",    masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 34X38 1",  desc2=  "NAVY TAN", upc=    "610393104157", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "NAVY TAN", dem2=   "34X38 1"   },
                new Item() {sku =   "ZBT3416NVTN",  masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 34X38 3/4",    desc2=  "NAVY TAN", upc=    "610393104102", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "NAVY TAN", dem2=   "34X38 3/4" },
                new Item() {sku =   "ZBT3216SLFC",  masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 32X34 3/4",    desc2=  "SLATE FUCHSIA",    upc=    "610393104140", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "SLATE FUCHSIA",    dem2=   "32X34 3/4" },
                new Item() {sku =   "ZBT3416-1TNRD",    masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 34X38 1",  desc2=  "TAN RED",  upc=    "610393104171", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "TAN RED",  dem2=   "34X38 1"   },
                new Item() {sku =   "ZBT3416TNRD",  masterSku=  "ZBT",  desc=   "ZONE SERIES BLANKET TOP 34X38 3/4",    desc2=  "TAN RED",  upc=    "610393104119", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "TAN RED",  dem2=   "34X38 3/4" },
                new Item() {sku =   "ZFB",  masterSku=  "ZFB",  desc=   "ZONE SERIES FELT TOP FLEECE BT",   desc2=  "31X32",    upc=    "610393092270", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "ZFT30",    masterSku=  "ZFT",  desc=   "ZONE SERIES FELT TOP FELT BTM",    desc2=  "30X32",    upc=    "610393092256", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "30X32",    dem2=   ""  },
                new Item() {sku =   "ZFT31",    masterSku=  "ZFT",  desc=   "ZONE SERIES FELT TOP FELT BTM",    desc2=  "31X32",    upc=    "610393092263", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "31X32",    dem2=   ""  },
                new Item() {sku =   "ZFTFB31",  masterSku=  "ZFTFB31",  desc=   "ZONE SERIES FELT TOP FOAM BOTTOM", desc2=  "31X32",    upc=    "610393103273", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "ZOOM5F30XS",   masterSku=  "ZOOM5F30XS",   desc=   "ZOOM 5/16 FULL 30' XS",    desc2=  "", upc=    "610393079080", brand=  "CLASSIC",  code=   "CKIDROPES",    dem1=   "", dem2=   ""  },
                new Item() {sku =   "ZSTCH",    masterSku=  "ZSTCH",    desc=   "ZONE SERIES SUEDE TOP FELT BTM",   desc2=  "31X32 CHOCOLATE",  upc=    "610393092287", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "CHOCOLATE",    dem2=   ""  },
                new Item() {sku =   "ZSTNV",    masterSku=  "ZSTCH",    desc=   "ZONE SERIES SUEDE TOP FELT BTM",   desc2=  "31X32 NAVY",   upc=    "610393103686", brand=  "WEQUINE",  code=   "SADDLEPAD",    dem1=   "NAVY", dem2=   ""  }
            };

            Console.WriteLine(itemSku[0].dem1);

            try
            {
                string[] lines, linesQty;
                string Results = "";
                string resultLineFix;
                string output = "";
                string csv = "No,Qty" + Environment.NewLine;
                int qtyRank = 0, value, tempRank;
                List<int> qtyRankArr = new List<int> { };
                lines = new string[1000];
                linesQty = new string[1000];
                List<Item> itemFound = new List<Item> { };
                List<string> shortSku = new List<string> {
                    "SPUR", "RM"
                };

                Program p = new Program();

                List<Image> returnedImages =  p.GetAllPages(Directory.GetCurrentDirectory() + @"\test2.tif");

                var ocr = new Tesseract();

                Console.WriteLine("Loading tessdata at: " + Directory.GetCurrentDirectory() + @"\tessdata");
                ocr.Init(Directory.GetCurrentDirectory() + @"\tessdata", "eng", false);

                int i = 0, pageNumber = 0;

                foreach (Image img in returnedImages)
                {
                    pageNumber += 1;
                    var image2 = new Bitmap(img);
                    var result = ocr.DoOCR(image2, Rectangle.Empty);

                    foreach (Word word in result)
                    {

                        pdfText = word.Text;

                        if (word.Text.ToUpper() == "QTY" || word.Text.ToUpper() == "ORDER" || word.Text.ToUpper() == "ORD" || word.Text.ToUpper() == "ORDERED")
                        {
                            qtyRank = word.Left;
                            qtyRankArr.Add(word.Left);
                            Console.WriteLine("Qty Col Found: " + qtyRank + " Text: " + word.Text + "\n");
                            output += "Qty Col Found: " + qtyRank + " Text: " + word.Text + Environment.NewLine;
                        }

                        foreach (int xx in qtyRankArr)//trys to find qty, and also avoids prices
                        {
                            if (word.Left >= (xx - 90) && word.Left < (xx + 90))
                            {

                                if (Int32.TryParse(word.Text.Replace(".00","").Replace(".0000",""), out value))
                                {
                                    if (linesQty[word.LineIndex + pageNumber * 100] != word.Text)
                                    {
                                        linesQty[word.LineIndex + pageNumber * 100] += word.Text;
                                    }

                                }
                                else
                                {

                                }
                            }
                        }

                        lines[word.LineIndex + pageNumber * 100] += word.Text.Replace(@"I\/I", "M") + ' ';

                        Results += word.Text + " ";
                    }
                }
               
                foreach (string resultLine in lines)
                {
                    if (resultLine != null)
                    {
                        resultLineFix = resultLine;
                        foreach(string sent in resultLine.Split(' '))//Removes pricing from image before rules
                        {
                            if (sent.Contains('$'))
                            {
                                resultLineFix = resultLineFix.Replace(sent,"");
                            }
                            if(sent.Length > 1)
                            {
                                if (sent[0] == '5' && Regex.IsMatch('$' + sent.Remove(0, 1), @"\$\d+\.\d{2}", RegexOptions.IgnoreCase))
                                {
                                    resultLineFix = resultLineFix.Replace(sent, "");
                                }
                                if (sent[0] == '5' && Regex.IsMatch('$' + sent.Remove(0, 1), @"\$\d+\,\d{2}", RegexOptions.IgnoreCase))
                                {
                                    resultLineFix = resultLineFix.Replace(sent, "");
                                }
                                if (sent[0] == 'S' && Regex.IsMatch('$' + sent.Remove(0, 1), @"\$\d+\.\d{2}", RegexOptions.IgnoreCase))
                                {
                                    resultLineFix = resultLineFix.Replace(sent, "");
                                }
                                if (sent[0] == 'S' && Regex.IsMatch('$' + sent.Remove(0, 1), @"\$\d+\,\d{2}", RegexOptions.IgnoreCase))
                                {
                                    resultLineFix = resultLineFix.Replace(sent, "");
                                }
                            }
                            
                        }

                        resultLineFix = resultLineFix.Replace(",", "");//removes common symboles before rules
                        resultLineFix = resultLineFix.Replace("—", "-");
                        //resultLineFix = resultLineFix.Replace(".", "");
                        resultLineFix = resultLineFix.Replace("(", "");
                        resultLineFix = resultLineFix.Replace(")", "");
                        resultLineFix = resultLineFix.Replace("{", "");
                        resultLineFix = resultLineFix.Replace("}", "");
                        resultLineFix = resultLineFix.Replace("[", "");
                        resultLineFix = resultLineFix.Replace("]", "");
                        resultLineFix = resultLineFix.Replace("/", " ");
                        resultLineFix = resultLineFix.Replace("|", " ");

                        resultLineFix = resultLineFix.ToUpper().Replace("MEOIUN", "MED MEDIUM");//fixes and adds types for rules mostly for dem1 and dem2
                        resultLineFix = resultLineFix.ToUpper().Replace("MED", "MED MEDIUM");
                        resultLineFix = resultLineFix.ToUpper().Replace("LRG", "LRG LARGE");
                        resultLineFix = resultLineFix.ToUpper().Replace("HARD", "HARD HARD");

                        if (Regex.IsMatch(resultLineFix, "\\b" + "M" + "\\b", RegexOptions.IgnoreCase)){
                            resultLineFix = resultLineFix.ToUpper().Replace("M", "M MED MEDIUM");
                        }

                        resultLineFix = resultLineFix.ToUpper().Replace("WHT", "WHT WHITE");
                        resultLineFix = resultLineFix.ToUpper().Replace("BLK", "BLK BLACK");
                        resultLineFix = resultLineFix.ToUpper().Replace("BRN", "BRN BROWN");

                        if(Regex.IsMatch(resultLineFix, @"(?i)(?s)HARD.*?MEDIUM", RegexOptions.IgnoreCase) && resultLineFix.IndexOf("HARD")< resultLineFix.IndexOf("MEDIUM"))//ensures the difference between ropes HM and MH
                        {
                            resultLineFix = resultLineFix.Replace("HARD", "").Replace("MEDIUM", "") + " HM";
                        }
                        if (Regex.IsMatch(resultLineFix, @"(?i)(?s)MEDIUM.*?HARD", RegexOptions.IgnoreCase) && resultLineFix.IndexOf("HARD") > resultLineFix.IndexOf("MEDIUM"))
                        {
                            resultLineFix = resultLineFix.Replace("HARD", "").Replace("MEDIUM", "") + " MH";
                        }

                        if (resultLineFix.Length > 0) { Console.WriteLine(resultLineFix); }

                        output += Environment.NewLine + resultLineFix + System.Environment.NewLine;

                        foreach (Item txt in itemSku)//every line is parsed to find the best instance of a sku
                        {
                            tempRank = 0;//for each sku we assign points based on what a line contains

                            //All lines can have multiple mods, such as containing a word shaired in the desc

                            //if (Regex.IsMatch(resultLineFix, "\\b" + txt.brand + "\\b", RegexOptions.IgnoreCase) && txt.dem2.Length > 0)
                            //{
                            //    tempRank += 3;
                            //    output += "Mod(brand): ";
                            //}

                            if (Regex.IsMatch(resultLineFix, "\\b" + txt.dem2 + "\\b", RegexOptions.IgnoreCase) && txt.dem2.Length > 0)
                            {
                                tempRank += 2;
                                output += "Mod(dem2): ";
                            }

                            if (Regex.IsMatch(resultLineFix, "\\b" + txt.dem1 + "\\b", RegexOptions.IgnoreCase) && txt.dem1.Length > 0)
                            {
                                tempRank += 2;
                                output += "Mod(dem1): ";
                            }
                            if (resultLineFix.Contains(txt.masterSku) && txt.masterSku.Length > 3)
                            {
                                tempRank += 2;
                                output += "Mod(master): ";
                            }
                            if (Regex.IsMatch(resultLineFix, "\\b" + txt.sku.Replace(" ", "") + "\\b", RegexOptions.IgnoreCase) && txt.sku.Length > 5)
                            {
                                tempRank += 12;
                                output += "Mod(sku(noSpace)): ";
                            }

                            if (txt.sku.Length > 5)
                            {
                                foreach(string txx in resultLineFix.Split(' '))
                                {
                                    if (Compute(txt.sku, txx) <= 1)
                                    {
                                        tempRank += 4;
                                        output += "Mod(sku): ";
                                    }
                                } 
                            }

                            if (tempRank > 0)
                            {
                                output += "Sku: " + txt.sku + " TempRank: " + tempRank + Environment.NewLine;
                            }
                            foreach (string ttx in txt.dem1.Split(' '))
                            {
                                if (resultLine.ToUpper().Contains(ttx.ToUpper()))
                                {
                                    tempRank += 1;
                                }
                            }
                            foreach (string ttx in txt.dem2.Split(' '))
                            {
                                if (resultLine.ToUpper().Contains(ttx.ToUpper()))
                                {
                                    tempRank += 1;
                                }
                            }
                            foreach (string ttx in txt.dem1.Split(' '))
                            {
                                if (resultLine.ToUpper().Contains(ttx.ToUpper()) && ttx.Length > 3)
                                {
                                    tempRank += 1;
                                }
                            }
                            foreach (string ttx in txt.dem2.Split(' '))
                            {
                                if (resultLine.ToUpper().Contains(ttx.ToUpper()) && ttx.Length > 3)
                                {
                                    tempRank += 1;
                                }
                            }

                            //All lines can only have one category, looks for highest first such as an exact sku to being 1 Levenshtein distance

                            if (Regex.IsMatch(resultLineFix, "\\b" + txt.sku + "\\b", RegexOptions.IgnoreCase) && shortSku.Contains(txt.masterSku)==false)
                            {
                                output += "Item Found(sku): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (100 + tempRank) + System.Environment.NewLine;
                                tempRank += 100;
                            }
                            else if (
                                (Regex.IsMatch(resultLineFix, "\\b" + txt.upc + "\\b", RegexOptions.IgnoreCase) 
                                && shortSku.Contains(txt.masterSku) == false)
                                && txt.upc.Length > 10)
                            {
                                output += "Item Found(upc): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (100 + tempRank) + System.Environment.NewLine;
                                tempRank += 93;
                            }

                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.masterSku).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.dem1).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.dem2).ToUpper().Replace(" ", "")))
                                && txt.dem1.Length > 0
                                && txt.dem2.Length > 0
                                )
                            {
                                output += "Item Found(Master+dem1+dem2): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (90 + tempRank) + System.Environment.NewLine;
                                tempRank += 90;
                            }
                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.masterSku).ToUpper().Replace(" ", ""))) 
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc).ToUpper().Replace(" ", ""))) 
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc2).ToUpper().Replace(" ", ""))) 
                                && txt.desc.Length > 0 
                                && txt.desc2.Length > 0
                                )
                            {
                                output += "Item Found(Master+desc1+desc2): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (85 + tempRank) + System.Environment.NewLine;
                                tempRank += 85;
                            }
                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.dem1).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.dem2).ToUpper().Replace(" ", "")))
                                && txt.desc.Length > 0
                                && txt.dem1.Length > 0
                                && txt.dem2.Length > 0
                                )
                            {
                                output += "Item Found(desc1+dem1+dem2): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (80 + tempRank) + System.Environment.NewLine;
                                tempRank += 80;
                            }
                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc2).ToUpper().Replace(" ", "")))
                                && txt.desc.Length > 0
                                && txt.desc2.Length > 0
                                )
                            {
                                output += "Item Found(desc1+desc2): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (40 + tempRank) + System.Environment.NewLine;                         
                                tempRank += 40;
                            }
                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.dem1).ToUpper().Replace(" ", "")))
                                && txt.desc.Length > 0
                                && txt.dem1.Length > 0
                                )
                            {
                                output += "Item Found(desc1+dem1): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (35 + tempRank) + System.Environment.NewLine;
                                tempRank += 35;
                            }
                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.desc).ToUpper().Replace(" ", "")))
                                && (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.dem2).ToUpper().Replace(" ", "")))
                                && txt.desc.Length > 0
                                && txt.dem2.Length > 0
                                )
                            {
                                output += "Item Found(desc1+dem2): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (30 + tempRank) + System.Environment.NewLine;
                                tempRank += 30;
                            }

                            else if (
                                (resultLineFix.Replace(" ", "").ToUpper().Contains((txt.masterSku).ToUpper().Replace(" ", "")))
                                && txt.masterSku.Length > 3
                                && shortSku.Contains(txt.masterSku) == false
                                )
                            {
                                output += "Item Found(MasterSkuOnly): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (30 + tempRank) + System.Environment.NewLine;
                                tempRank += 10;
                            }

                            else//Highly expermintal, uses Levenshtein distance
                            {
                                foreach (string txt2 in resultLine.Split(' '))
                                {
                                    if (txt2.Length == txt.sku.Length && txt.sku.Length > 2 
                                        && txt.sku.Length == 6)
                                    {
                                        if (Compute(txt2, txt.sku) <= 1)
                                        {
                                            output += "Item Found(fuzz1(6)): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (11 + tempRank) + System.Environment.NewLine;
                                            tempRank += 11;
                                        }
                                    }
                                    if (txt2.Length == txt.sku.Length && txt.sku.Length > 2 
                                        && 7 > txt.sku.Length)
                                    {
                                        if (Compute(txt2, txt.sku) <= 1
                                            && shortSku.Contains(txt.masterSku) == false)
                                        {
                                            output += "Item Found(fuzz1): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (26 + tempRank) + System.Environment.NewLine;
                                            tempRank += 26;
                                        }
                                    }
                                    else if (txt2.Length == txt.sku.Length 
                                        && 7 <= txt.sku.Length)
                                        {
                                            if (Compute(txt2, txt.sku) <= 2)
                                            {
                                                output += "Item Found(fuzzy2): " + txt.sku + " Qty: " + linesQty[i] + " Rank " + (11 + tempRank) + System.Environment.NewLine;
                                                tempRank += 11;
                                            }
                                        }
                                }
                            }

                            if (Int32.TryParse(linesQty[i], out value))//try to get the qty for each ranked item
                            {
                                itemFound.Add(new Item() { sku = txt.sku, qty = value, rank = tempRank, line = i });
                            }
                            else
                            {
                                itemFound.Add(new Item() { sku = txt.sku, qty = 0, rank = tempRank, line = i });
                            }
                        }
                    }
                    i++;
                }

                Console.WriteLine("-----ITEMS FOUND-----");
                output += Environment.NewLine + "-----ITEMS FOUND-----" + Environment.NewLine;
                foreach (Item txt in itemFound)//prints items ranked 15 or higher
                {
                    if (txt.rank > 15)
                    {
                        Console.WriteLine("Sku: " + txt.sku + " Rank: " + txt.rank + " Qty: " + txt.qty + " Line: " + txt.line);
                    }
                }

                foreach (Item txt in itemFound)
                {
                    if (txt.rank > 15)
                    {
                        output += "Sku: " + txt.sku + " Rank: " + txt.rank + " Qty: " + txt.qty + " Line: " + txt.line + Environment.NewLine;
                    }
                }

                Console.WriteLine("\n-----ITEMS FOUND MAX RANK-----");
                output += Environment.NewLine + "-----ITEMS FOUND MAX RANK-----" + Environment.NewLine;
                foreach (Item txt in itemFound.GroupBy(item => item.line)//prints the highest ranked item for each line of each page
                    .Select(grp => grp.Aggregate((max, cur) =>
                            (max == null || cur.rank > max.rank) ? cur : max)))
                {
                    if(txt.rank > 5)
                    {
                        output += "Sku: " + txt.sku + " Rank: " + txt.rank + " Qty: " + txt.qty + " Page: " + txt.line.ToString().Substring(0,1) + " Line: " + txt.line % 100 + Environment.NewLine;
                        csv += txt.sku + "," + txt.qty + Environment.NewLine;
                        Console.WriteLine("Sku: " + txt.sku + " Rank: " + txt.rank + " Qty: " + txt.qty + " Line: " + txt.line);
                    }
                }

                File.WriteAllText(Directory.GetCurrentDirectory() + "/output.txt", output);//.txt file to see how the ranking is working
                File.WriteAllText(Directory.GetCurrentDirectory() + "/output.csv", csv);//.csv file used for uploading after being reviewed

                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine("error: " + exception);

                Console.ReadLine();
            }

        }
        public static int Compute(string s, string t) //Levenshtein distance formula
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }

        private List<Image> GetAllPages(string file)//gets all pages from a given image and returns it as a .tif
        {
            List<Image> images = new List<Image>();
            Bitmap bitmap = (Bitmap)Image.FromFile(file);
            int count = bitmap.GetFrameCount(FrameDimension.Page);
            for (int idx = 0; idx < count; idx++)
            {
                bitmap.SelectActiveFrame(FrameDimension.Page, idx);
                MemoryStream byteStream = new MemoryStream();
                bitmap.Save(byteStream, ImageFormat.Tiff);

                images.Add(Image.FromStream(byteStream));
            }
            return images;
        }

    }

    class Item//item class for all Equibrand catalog items
    {
        string _sku, _masterSku, _desc, _desc2, _dem1, _dem2, _brand, _code, _upc;
        int _qty, _rank, _line;

        public string sku
        {
            get
            {
                return this._sku;
            }
            set
            {
                this._sku = value;
            }
        }

        public string masterSku
        {
            get
            {
                return this._masterSku;
            }
            set
            {
                this._masterSku = value;
            }
        }

        public string upc
        {
            get
            {
                return this._upc;
            }
            set
            {
                this._upc = value;
            }
        }

        public string desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        public string desc2
        {
            get
            {
                return this._desc2;
            }
            set
            {
                this._desc2 = value;
            }
        }

        public string brand
        {
            get
            {
                return this._brand;
            }
            set
            {
                this._brand = value;
            }
        }

        public string code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        public string dem1
        {
            get
            {
                return this._dem1;
            }
            set
            {
                this._dem1 = value;
            }
        }

        public string dem2
        {
            get
            {
                return this._dem2;
            }
            set
            {
                this._dem2 = value;
            }
        }

        public int qty
        {
            get
            {
                return this._qty;
            }
            set
            {
                this._qty = value;
            }
        }

        public int rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }
        public int line
        {
            get
            {
                return this._line;
            }
            set
            {
                this._line = value;
            }
        }

    }
}

