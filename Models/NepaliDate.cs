using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ADToBSDateConverter
{
    class NepaliDate
    {
        string[] bsMonths = new string[] { "बैशाख", "जेठ", "असार", "सावन", "भदौ", "असोज", "कार्तिक", "मंसिर", "पौष", "माघ", "फागुन", "चैत" };
        string[] nepaliNumbers =new string[] { "०", "१", "२", "३", "४", "५", "६", "७", "८", "९" };
        public string getNepaliDate(DateTime date)
        {
            int adYear = date.Year;
            int adMonth = date.Month;
            int adDate= date.Day;

            var bsYear = adYear + 57;
            var bsMonth = (adMonth + 9) % 12;
            bsMonth = bsMonth == 0 ? 12 : bsMonth;
            var bsDate = 1;

            if (adMonth < 4)
            {
                bsYear -= 1;
            }
            else if (adMonth == 4)
            {
                var bsYearFirstAdDate = getAdDateByBsDate(bsYear, 1, 1);
                if (adDate < bsYearFirstAdDate)
                {
                    bsYear -= 1;
                }
            }

            var bsMonthFirstAdDate = getAdDateByBsDate(bsYear, bsMonth, 1);
            if (adDate >= 1 && adDate < bsMonthFirstAdDate)
            {
                bsMonth = (bsMonth != 1) ? bsMonth - 1 : 12;
                var bsMonthDays = Convert.ToInt32(getBsMonthDays(bsYear, bsMonth));
                bsDate = bsMonthDays - (bsMonthFirstAdDate - adDate) + 1;
            }
            else
            {
                bsDate = adDate - bsMonthFirstAdDate + 1;
            }
            string bsMonthTitle = bsMonths[bsMonth-1];
            string getDateNepaliNumber = getNepaliNumber(bsDate);
            string getYearNepaliNumber = getNepaliNumber(bsYear);
            return getDateNepaliNumber + " " + bsMonthTitle + ", " + getYearNepaliNumber;                

        }

        private string getNepaliNumber(int bsDate)
        {
            string numberString = ""+bsDate;
            string requiredNumber = "";
            for(int i = 0; i < numberString.Length; i++)
            {
                int number = Convert.ToInt32(numberString[i].ToString());
                requiredNumber = requiredNumber + nepaliNumbers[number];
            }
            return requiredNumber;
        }

        public dynamic calendarData()
        {
            var calendarData = Newtonsoft.Json.JsonConvert.DeserializeObject(@"{       
        bsDays: ['आईत', 'सोम', 'मंगल', 'बुध', 'बिही', 'शुक्र', 'शनि'],     
        bsMonthUpperDays: [
            [30, 31],
            [31, 32],
            [31, 32],
            [31, 32],
            [31, 32],
            [30, 31],
            [29, 30],
            [29, 30],
            [29, 30],
            [29, 30],
            [29, 30],
            [30, 31]
        ],
        extractedBsMonthData: [
            [0, 1, 1, 22, 1, 3, 1, 1, 1, 3, 1, 22, 1, 3, 1, 3, 1, 22, 1, 3, 1, 19, 1, 3, 1, 1, 3, 1, 2, 2, 1, 3, 1],
            [1, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 2, 2, 2, 3, 2, 2, 2, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 1, 3, 1, 1, 2],
            [0, 1, 2, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 3, 1, 1, 2],
            [1, 2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 2, 2, 1, 3, 1, 2, 2, 2, 1, 2],
            [59, 1, 26, 1, 28, 1, 2, 1, 12],
            [0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 5, 1, 1, 2, 2, 1, 3, 1, 2, 1, 2],
            [0, 12, 1, 3, 1, 3, 1, 5, 1, 11, 1, 3, 1, 3, 1, 18, 1, 3, 1, 3, 1, 18, 1, 3, 1, 3, 1, 27, 1, 2],
            [1, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 3, 1, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 15, 2, 4],
            [0, 1, 2, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 3, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 2, 2, 2, 15, 2, 4],
            [1, 1, 3, 1, 3, 1, 14, 1, 3, 1, 1, 1, 3, 1, 14, 1, 3, 1, 3, 1, 3, 1, 18, 1, 3, 1, 3, 1, 3, 1, 14, 1, 3, 15, 1, 2, 1, 1],
            [0, 1, 1, 3, 1, 3, 1, 10, 1, 3, 1, 3, 1, 1, 1, 3, 1, 3, 1, 10, 1, 3, 1, 3, 1, 3, 1, 3, 1, 14, 1, 3, 1, 3, 1, 3, 1, 3, 1, 10, 1, 20, 1, 1, 1],
            [1, 2, 2, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 3, 1, 3, 1, 2, 2, 2, 2, 2, 2, 2, 1, 3, 1, 3, 1, 20, 3]
        ],
        minBsYear: 1970,
        maxBsYear: 2100      
        }");
            return calendarData;
        }

      public int  getAdDateByBsDate(int bsYear,int bsMonth,int bsDate)
        {

            var daysNumFromMinBsYear =getTotalDaysNumFromMinBsYear(bsYear, bsMonth, bsDate);
            var adDate = Convert.ToDateTime("1913-4-12");
            adDate=adDate.AddDays(Convert.ToDouble(daysNumFromMinBsYear));
            return adDate.Day;
        }
        public int? getTotalDaysNumFromMinBsYear(int bsYear,int bsMonth,int bsDate)
        {
            if (bsYear < 1970 || bsYear > 2100)
            {
                return null;
            }

            var daysNumFromMinBsYear = 0;
            var diffYears = bsYear - 1970;
            for (var month = 1; month <= 12; month++)
            {
                if (month < bsMonth)
                {
                    daysNumFromMinBsYear += getMonthDaysNumFormMinBsYear(month, diffYears + 1);
                }
                else
                {
                    daysNumFromMinBsYear += getMonthDaysNumFormMinBsYear(month, diffYears);
                }
            }

            if (bsYear > 2085 && bsYear < 2088)
            {
                daysNumFromMinBsYear += bsDate - 2;
            }
            else if (bsYear == 2085 && bsMonth > 5)
            {
                daysNumFromMinBsYear += bsDate - 2;
            }
            else if (bsYear > 2088)
            {
                daysNumFromMinBsYear += bsDate - 4;
            }
            else if (bsYear == 2088 && bsMonth > 5)
            {
                daysNumFromMinBsYear += bsDate - 4;
            }
            else
            {
                daysNumFromMinBsYear += bsDate;
            }

            return daysNumFromMinBsYear;
        }


        public int getMonthDaysNumFormMinBsYear(int bsMonth,int yearDiff)
        {
            var yearCount = 0;
            var monthDaysFromMinBsYear = 0;
            if (yearDiff == 0)
            {
                return 0;
            }

            var bsMonthDataString = (Convert.ToString(calendarData().extractedBsMonthData[bsMonth - 1]));
            var bsMonthData = JsonConvert.DeserializeObject<List<int>>(bsMonthDataString); 
            for (var i = 0; i < bsMonthData.Count; i++)
            {
                if (bsMonthData[i] == 0)
                {
                    continue;
                }

                var bsMonthUpperDaysIndex = i % 2;
                if (yearDiff > yearCount + bsMonthData[i])
                {
                    yearCount += bsMonthData[i];
                    var muDays = calendarData().bsMonthUpperDays[bsMonth - 1][bsMonthUpperDaysIndex];
                    monthDaysFromMinBsYear += Convert.ToInt32(muDays.ToString()) * bsMonthData[i];
                }
                else
                {
                    var muDays = calendarData().bsMonthUpperDays[bsMonth - 1][bsMonthUpperDaysIndex];
                    monthDaysFromMinBsYear += Convert.ToInt32(muDays.ToString()) * (yearDiff - yearCount);
                    yearCount = yearDiff - yearCount;
                    break;
                }
            }

            return monthDaysFromMinBsYear;
        }

        public int? getBsMonthDays(int bsYear, int bsMonth)
        {

            var yearCount = 0;
            var totalYears = (bsYear + 1) - 1970;
            var bsMonthDataString = (Convert.ToString(calendarData().extractedBsMonthData[bsMonth - 1]));
            var bsMonthData = JsonConvert.DeserializeObject<List<int>>(bsMonthDataString);
            for (var i = 0; i < bsMonthData.Count; i++)
            {
                if (bsMonthData[i] == 0)
                {
                    continue;
                }

                var bsMonthUpperDaysIndex = i % 2;
                yearCount += bsMonthData[i];
                if (totalYears <= yearCount)
                {
                    if ((bsYear == 2085 && bsMonth == 5) || (bsYear == 2088 && bsMonth == 5))
                    {
                        return Convert.ToInt32(Convert.ToString(calendarData().bsMonthUpperDays[bsMonth - 1][bsMonthUpperDaysIndex])) - 2;
                    }
                    else
                    {
                        return Convert.ToInt32(Convert.ToString(calendarData().bsMonthUpperDays[bsMonth - 1][bsMonthUpperDaysIndex])) ;
                    }
                }
            }

            return null;
        }
    }
}
