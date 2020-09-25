using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSQLServer
{
    class HexConvertFunctions
    {
        public static void hexToDateTime()
        {
            //2004/05/23 2:25:10
            //0x000094F0
            //0x00EDA008

            //08A0ED00 F0940000
            string dateg = "0x10000C00000094F000EDA008";
            DateTime dateTime = new DateTime(1900, 1, 1);
            dateTime = dateTime.AddDays(0x000094F0);
            dateTime = dateTime.AddSeconds(0x08A0ED00 / 300);
            string formatear = format(dateTime);
            Console.WriteLine(formatear);
        }

        public static int hexToBinary(string hex)
        {
            string fHex = "";
            int value = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                if (i == 8)
                {
                    while (i < 12)
                    {
                        fHex += hex[i];
                        i++;
                    }
                    value = Convert.ToInt32(fHex, 16);
                    return value;
                }
            }
            return -1;
        }

        public static int hexToBit(string hex)
        {
            for (int i = 0; i < hex.Length; i++)
            {
                if (hex[11].Equals('A'))
                {
                    return 1;
                }
                else if (hex[11].Equals('B'))
                {
                    return 0;
                }
            }
            return -1;
        }

        public static int hexToChar(string hex)
        {
            string fHex = "";
            int value = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                if (i == 7)
                {
                    while (i < 12)
                    {
                        i++;
                        fHex += hex[i];
                    }
                    value = Convert.ToInt32(fHex, 16);
                    return value;
                }
            }
            return -1;
        }

        public static void hexToSmalldate()
        {
            //0x10000C0008A0ED00F0940000010000
            //2004/05/23 2:25:00
            //0x94F0
            //0x0361
            DateTime date = new DateTime(1900, 1, 1);
            date = date.AddDays(0x94F0);
            date = date.AddMinutes(0x0361);
            string formatear = format(date);
            Console.WriteLine(formatear);
        }
        public static string format(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        public static int hexToInt(string hex)
        {
            string tiny = "TinyInt is: ", big = "BigInt is: ", normal = "Int is: ";
            string getInt = "0x";
            string final = "";
            int value = 0;
            for (int i = 7; i < hex.Length; i++)
            {
                if (hex[7].Equals('8'))
                {
                    while (i != 11)
                    {
                        i++;
                        getInt += hex[i];
                    }
                    value = Convert.ToInt32(getInt, 16);
                    return value;
                }
                else if (hex[7].Equals('5'))
                {
                    while (i != 11)
                    {
                        i++;
                        getInt += hex[i];
                    }
                    value = Convert.ToInt32(getInt, 16);
                    return value;
                }
                else if (hex[7].Equals('C'))
                {
                    while (i != 11)
                    {
                        i++;
                        getInt += hex[i];
                    }
                    value = Convert.ToInt32(getInt, 16);
                    return value;
                }
            }
            return 0;
        }
        public static double hexToFloat4Bytes(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            double f = BitConverter.ToSingle(raw, 0);
            return f;
        }
        public static double hexToFloat8Bytes(string hex)
        {
            hex = LittleEndian(hex);
            var int64Val = Convert.ToInt64(hex, 16);
            var doubleVal = BitConverter.Int64BitsToDouble(int64Val);
            return doubleVal;
        }
        public static string LittleEndian(string num)
        {
            long number = Convert.ToInt64(num, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
                retval += b.ToString("X2");
            return retval;
        }
        public static string equiss(DateTime equis)
        {
            return equis.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public static double hexToMoney(string hex)
        {
            hex = LittleEndian(hex);
            double d = 0;
            for (int n = hex.Length - 1; n >= 0; n--)
            {
                d += System.Uri.FromHex(hex[n]) * Math.Pow(16, hex.Length - 1 - n);
            }
            hex = d.ToString();
            string punto = "." + hex.Substring(hex.Length - 4);
            hex = hex.Substring(0, hex.Length - 4) + punto;
            return double.Parse(hex);
        }

        static string hexStringToString(string hexString)
        {
            if (hexString == null || (hexString.Length & 1) == 1)
            {
                throw new ArgumentException();
            }
            var sb = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 2)
            {
                var hexChar = hexString.Substring(i, 2);
                if (hexChar != "0x")
                {
                    sb.Append((char)Convert.ToByte(hexChar, 16));
                }
            }
            return sb.ToString();
        }
        public static DateTime hexToSmallDatetime(long hexa)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            dt = dt.AddDays(0x94F0);
            dt = dt.AddMinutes(0x0361);
            return dt;
        }
    }
}
