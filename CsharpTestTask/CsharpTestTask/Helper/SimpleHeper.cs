using CsharpTestTask.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTestTask.Helper
{
    public class SimpleHeper
    {
        static string[] statesArray = { "First Contact", "Conversation", "Harmonization Of Contract", "Cooperation" };
        public static long getNowTimeInMillisecond()
        {
            DateTime now = DateTime.Now;
            DateTime old = new DateTime(1970, 1, 1);
            TimeSpan t = now - old;
            long timestamp = (long)t.TotalMilliseconds;
            return timestamp;
        }

        public static string getDateTimeByMills(long time)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds(time).ToLocalTime();

            return date.ToString("MM/dd/yyyy").Replace(".", "/");
        }

        public static long getTimeInMillisecond(string value)
        {
            string[] formats = { "MM/dd/yyyy" };
            var time = DateTime.ParseExact(value, formats, new CultureInfo("en-US"), DateTimeStyles.None);

            DateTime old = new DateTime(1970, 1, 1);
            TimeSpan t = time - old;
            long timestamp = (long)t.TotalMilliseconds;
            return timestamp;
        }

        public static int getDealStaus(DealStatus d)
        {
            

            int index = -1;
            if (d == DealStatus.FirstContact)
            {
                index = 0;
            }
            else if (d == DealStatus.Conversation)
            {
                index = 1;
            }
            else if (d == DealStatus.HarmonizationOfContract)
            {
                index = 2;
            }
            else if (d == DealStatus.Cooperation)
            {
                index = 3;
            }

            return index;
        }

        public static string getStringDealStaus(DealStatus d)
        {


            int index = 1;
            if (d == DealStatus.FirstContact)
            {
                index = 0;
            }
            else if (d == DealStatus.Conversation)
            {
                index = 1;
            }
            else if (d == DealStatus.HarmonizationOfContract)
            {
                index = 2;
            }
            else if (d == DealStatus.Cooperation)
            {
                index = 3;
            }

            return statesArray[index];
        }


        public static string getDealStatusByPosition(int position)
        {
            return statesArray[position];
        }

        public static DealStatus getDealStatusByValue(int  position)
        {
            string value = statesArray[position];

            if (value == statesArray[0])
            {
                return DealStatus.FirstContact;
            }
            else if (value == statesArray[1])
            {
                return DealStatus.Conversation;
            }
            else if (value == statesArray[2])
            {
                return DealStatus.HarmonizationOfContract;
            }
            else if (value == statesArray[3])
            {
                return DealStatus.Cooperation;
            }

            return DealStatus.FirstContact;
        }


    }
}
