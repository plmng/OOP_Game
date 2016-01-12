namespace Methods.Models
{
    using System;

    internal class Student
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, string additionalInformation)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AdditionalInformation = additionalInformation;
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
                    throw new ArgumentNullException("value", "first name can not be null or empty string");
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
                    throw new ArgumentNullException("value", "last name can not be null or empty string");
                }

                this.lastName = value;
            }
        }

        public string AdditionalInformation { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime thisStudentDateOfBirth = this.ExtractDateOfBirth(this.AdditionalInformation);
            DateTime otherStudentDateOfBirth = other.ExtractDateOfBirth(other.AdditionalInformation);
            
            return thisStudentDateOfBirth < otherStudentDateOfBirth;
        }

        private DateTime ExtractDateOfBirth(string information)
        {
            string dateCandidate = information.Substring(information.Length - 10);
            DateTime date;
            if (!DateTime.TryParse(dateCandidate, out date))
            {
                throw new ArgumentException("Student's additional information not have valid date of birth information provided.");
            }

            return date;
        }
    }
}