namespace Exceptions_Homework.StudentExamSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        
        public Student(string firstName, string lastName, IList<IExam> exams)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public Student(string firstName, string lastName)
            : this(firstName, lastName, new List<IExam>())
        {
            this.Exams = new List<IExam>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                   throw new ArgumentNullException("FirstName", "First Name can not be null or empty");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "Last Name can not be null or empty");
                }

                this.lastName = value;
            }
        }
        
        public IList<IExam> Exams { get; set; }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams.Count == 0)
            {
                throw new InvalidOperationException("Cannot calculate average on missing exams");
            }

            double[] examScores = new double[this.Exams.Count];

            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                int gradeRange = examResults[i].MaximumGrade - examResults[i].MinimumGrade;
                double normalizedGrade = examResults[i].Grade - examResults[i].MinimumGrade;

                examScores[i] = normalizedGrade / gradeRange;
            }

            return examScores.Average();
        }

        private IList<ExamResult> CheckExams()
        {
            return this.Exams.Select(t => t.Check()).ToList();
        }
    }
}
