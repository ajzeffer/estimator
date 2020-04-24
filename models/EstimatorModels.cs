using System;
using System.Collections.Generic;
using System.Linq;
namespace estimator.models
{

    public class TshirtSize
    {
        public string Description { get; set; }
        public TshirtSizeEnum TshirtSizeEnum { get; set; }
        public int MinDaysEffort { get; set; }
        public int MaxDaysEffort { get; set; }


    }

    public class Effort
    {
        public decimal Days { get; private set; }
        public decimal Weeks { get; private set; }
        public decimal Months { get; private set; }
        public TshirtSize TshirtSize{get; private set;}
        private Effort(decimal days, decimal weeks, decimal months)
        {
            Days = days;
            Weeks = weeks;
            Months = Months;
            TshirtSize = DaysToTshirtSize(days);
        }

        public static Effort Create(TimeIncrement timeIncrement, decimal timeValue)
        {
            switch (timeIncrement)
            {
                case TimeIncrement.Days:
                    return new Effort(days: timeValue, weeks: DaysToWeeks(timeValue), months: DaysToMonths(timeValue));

                case TimeIncrement.Weeks:
                    return new Effort(WeeksToDays(timeValue), timeValue, WeeksToMonths(timeValue));

                case TimeIncrement.Months:
                    return new Effort(MonthsToDays(timeValue), weeks: MonthsToWeeks(timeValue), timeValue);
                default:
                    return new Effort(days: timeValue, weeks: DaysToWeeks(timeValue), months: DaysToMonths(timeValue));
            }
        }

        private TshirtSize DaysToTshirtSize(decimal days){
            var tshirtSizes = new TshirtSizes();
            return tshirtSizes.Tshirts.FirstOrDefault(x => days>= x.MinDaysEffort&& days <= x.MaxDaysEffort);
        }
        private static decimal DaysToWeeks(decimal days) => Math.Round( days / 7, 2);

        private static decimal DaysToMonths(decimal days) => Math.Round(days / 30, 2);
        private static decimal WeeksToMonths(decimal weeks) => Math.Round(weeks / 4, 2);
        private static decimal WeeksToDays(decimal weeks) => Math.Round(weeks * 7, 2);
        private static decimal MonthsToDays(decimal months) => Math.Round(months * 30, 2);
        private static decimal MonthsToWeeks(decimal months) => Math.Round(months / 4, 2);
    }

    public enum TshirtSizeEnum
    {
        Xs, S, M, L, XL, XXL, XXXL
    }
    public enum TimeIncrement
    {
        Days, Weeks, Months
    }

    public   class TshirtSizes
    {
        public   List<TshirtSize> Tshirts = new List<TshirtSize>();
        public   TshirtSizes()
        {
            Tshirts.Add(new TshirtSize { Description = "XS", TshirtSizeEnum = TshirtSizeEnum.Xs, MinDaysEffort = 0, MaxDaysEffort = 7 });
            Tshirts.Add(new TshirtSize { Description = "S", TshirtSizeEnum = TshirtSizeEnum.S, MinDaysEffort = 7, MaxDaysEffort = 14 });
            Tshirts.Add(new TshirtSize { Description = "M", TshirtSizeEnum = TshirtSizeEnum.M, MinDaysEffort = 15, MaxDaysEffort = 28 });
            Tshirts.Add(new TshirtSize { Description = "L", TshirtSizeEnum = TshirtSizeEnum.L, MinDaysEffort = 29, MaxDaysEffort = 56 });
            Tshirts.Add(new TshirtSize { Description = "XL", TshirtSizeEnum = TshirtSizeEnum.XL, MinDaysEffort = 57, MaxDaysEffort = 89 });
            Tshirts.Add(new TshirtSize { Description = "XXL", TshirtSizeEnum = TshirtSizeEnum.XXL, MinDaysEffort = 90, MaxDaysEffort = 179 });
            Tshirts.Add(new TshirtSize { Description = "XXXL", TshirtSizeEnum = TshirtSizeEnum.XXXL, MinDaysEffort = 180, MaxDaysEffort = 10000 });
        }
    }

}