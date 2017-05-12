using System;
using System.Collections.Generic;
using System.Text;

namespace курсовая
{
    [Serializable]
    public class Details
    {   //объявляем поля класса Details
        private string time; //время, на котрое назначено выполнение задания
        private string day; // день, когда надо выполнить
        private string month; // месяц выполнения задания
        private string time_end; //время окончания
        private string day_end; // день окончания
        private string month_end; //месяц окончания
        private string idea; // описание дела
        private string important; //важность этого дела

        //объявляем конструктор
        public Details(string time, string day, string idea, string important, string month, string time_end, string day_end, string month_end)
        {
            this.time = time;
            this.day = day;
            this.month = month;
            this.idea = idea;
            this.important = important;
            this.day_end = day_end;
            this.time_end = time_end;
            this.month_end = month_end;

        }

        //объявляем свойства
        public string Time1
        {
            get { return time; }
            set { time = value; }
        }
        public string Time1_end
        {
            get { return time_end; }
            set { time_end = value; }
        }
        
        public string Day1
        {
            get { return day; }
            set { day = value; }
        }
        
        public string Day1_end
        {
            get { return day_end; }
            set { day_end = value; }
        }

        public string Month1
        {
            get { return month; }
            set { month = value; }
        }
        public string Month1_end
        {
            get { return month_end; }
            set { month_end = value; }
        }

        public string Idea1
        {
            get { return idea; }
            set { idea = value; }
        }

        public string Important1
        {
            get { return important; }
            set { important = value; }
        }

        public string Show()
        {
            string str = "Время: " + time + "Время окончания" + time_end + " - День: " + day + "День окончания" + day_end +  "-Месяц" + month + "Месяц окончания " + month_end + " - Встреча: " + idea + " - Важность:" + important;
            return str;
        }

    }

}
